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

		private Vector3 fromPosition;
		private Vector3 fromRotation;
		private Vector3 fromScale;

		private bool isPause = false;

		void Awake()
		{ 
			com = target as TweenControl;
		}

		public override void OnInspectorGUI()
		{
			// serializedObject.Update();

			base.OnInspectorGUI();
			
			if (GUILayout.Button("播放"))
			{
				PlayInEditor();
			}
			
			if (GUILayout.Button("暂停"))
			{
				PauseInEditor();
			}

			if (GUILayout.Button("重置"))
			{
				StopInEditor();
			}

			// serializedObject.ApplyModifiedProperties();
		}

		void PlayInEditor()
		{
			if (!isPause)
			{
				fromPosition = com.transform.localPosition;
				fromRotation = com.transform.localRotation.eulerAngles;
				fromScale = com.transform.localScale;
				
				tweens ??= DOTween.Sequence();
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
					if (!tween.canPreview)
					{
						continue;
					}
					tweens?.Insert(tween.delay, tween.DoTween());
				}

				DOTweenEditorPreview.Start();
				DOTweenEditorPreview.PrepareTweenForPreview(tweens, andPlay: false);
			}

			if (com.isAutoRewind)
			{
				tweens.onComplete += StopInEditor;
			}
			tweens?.Play();
		}

		void PauseInEditor()
		{
			if (tweens != null)
			{
				tweens.Pause();
				isPause = true;
			}
		}

		void StopInEditor()
		{
			DOTweenEditorPreview.Stop(true);
			isPause = false;
			tweens?.Kill();
			tweens = null;

			var trans = com.transform;
			if (trans.localPosition != fromPosition || trans.localRotation.eulerAngles != fromRotation || trans.localScale != fromScale)
			{
				trans.localPosition = fromPosition;
				trans.localRotation = Quaternion.Euler(fromRotation);
				trans.localScale = fromScale;
			}
		}
	}
}