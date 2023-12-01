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
		private TweenControl com;
		private Sequence tweens;

		private bool isPause = true;
		private bool isNeedRewind = false;

		void Awake()
		{ 
			com = target as TweenControl;
		}

#if UNITY_EDITOR
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			base.OnInspectorGUI();

			EditorGUILayout.BeginHorizontal();
			if (isPause)
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

			if (!isNeedRewind)
			{
				if (GUILayout.Button("重置", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
				{
					StopInEditor();
				}
			}
			else
			{
				if (GUILayout.Button("(※重新播放先点我)重置", GUILayout.ExpandWidth(true), GUILayout.Height(40)))
				{
					StopInEditor();
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
					tweens = DOTween.Sequence();
					ITween[] coms = null;
					if (com.isPlayChildren)
					{
						coms = com.GetComponentsInChildren<ITween>();
					}
					else
					{
						coms = com.GetComponents<ITween>();
					}
					foreach (var tween in coms)
					{
						if (tween.from || !tween.canPreview)
						{
							continue;
						}
						tweens?.Insert(tween.delay, tween.DoTween());
					}

					DOTweenEditorPreview.Start();
					DOTweenEditorPreview.PrepareTweenForPreview(tweens, andPlay: false);
					
					// 回调的注册必须放在PrepareTweenForPreview之后，不然注册的回调会失效
					tweens.OnPlay(() => isPause = false);
					tweens.OnPause(() => isPause = true);
					if (com.isAutoRewind)
					{
						tweens.onComplete += StopInEditor;
					}
					else
					{
						tweens.OnComplete(() => isNeedRewind = true);
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
			DOTweenEditorPreview.Stop(true);
			isPause = true;
			isNeedRewind = false;
			tweens?.Kill();
			tweens = null;

			Repaint();
		}
#endif
	}
}