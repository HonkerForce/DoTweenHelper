using DG.DOTweenEditor;
using DG.Tweening;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DoTweenHelper.Editor
{
	[CustomEditor(typeof(TweenControl), true)]
	public class TweenControlEditor 
#if UNITY_EDITOR
		: UnityEditor.Editor
#endif
	{
		private TweenControl control;
		private Sequence tweens;

		private bool isPause = true;
		private bool isNeedRewind = false;

		void Awake()
		{ 
			control = target as TweenControl;
		}

#if UNITY_EDITOR
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			base.OnInspectorGUI();

			EditorGUILayout.BeginHorizontal();

			if (isNeedRewind)
			{
				if (GUILayout.Button("(※重新播放先点我)重置", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
				{
					StopInEditor();
				}
			}
			else if (isPause)
			{
				if (GUILayout.Button("播放", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
				{
					PlayInEditor();
				}
			}
			else
			{
				if (GUILayout.Button("暂停", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
				{
					PauseInEditor();
				}
			}

			EditorGUILayout.EndHorizontal();

			serializedObject.ApplyModifiedProperties();
		}

		void PlayInEditor()
		{
			if (isPause)
			{
				if (tweens == null)
				{
					int count = 0;
					tweens = DOTween.Sequence();
					ITween[] coms = null;
					if (control.isPlayChildren)
					{
						coms = control.GetComponentsInChildren<ITween>();
					}
					else
					{
						coms = control.GetComponents<ITween>();
					}
					foreach (var tween in coms)
					{
						if (!tween.canPreview || !tween.isControlled)
						{
							continue;
						}

						if (tween.from && control.isPreviewFrom)
						{
							tweens?.Insert(0, tween.DoTween());
							count++;
						}
						if (!tween.from && !control.isPreviewFrom)
						{
							tweens?.Insert(0, tween.DoTween());
							count++;
						}
					}
					
					DOTweenEditorPreview.Start();
					DOTweenEditorPreview.PrepareTweenForPreview(tweens, andPlay: false);

					// 回调的注册必须放在PrepareTweenForPreview之后，不然注册的回调会失效
					tweens.OnPlay(() => isPause = false);
					tweens.OnPause(() => isPause = true);
					if (control.isAutoRewind)
					{
						tweens?.OnComplete(StopInEditor);
					}
					else if (count > 0)
					{
						tweens?.OnComplete(() => isNeedRewind = true);
					}
					else
					{
						StopInEditor();
					}
				}
			}
			tweens?.Play();
		}

		void PauseInEditor()
		{
			if (tweens != null)
			{
				tweens?.Pause();
			}
		}

		void StopInEditor()
		{
			DOTweenEditorPreview.Stop(!control.isPreviewFrom);

			isPause = true;
			isNeedRewind = false;
			tweens?.Kill();
			tweens = null;

			Repaint();
		}
#endif
	}
}