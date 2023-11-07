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
				tweens ??= DOTween.Sequence();
				var coms = com.GetComponents<ITween>();
				foreach (var tween in coms)
				{
					tweens?.Insert(tween.delay, tween.DoTween());
				}

				DOTweenEditorPreview.Start();
				DOTweenEditorPreview.PrepareTweenForPreview(tweens, andPlay: false);
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
			tweens = null;
		}
	}
}