using DoTweenHelper.Attribute;
using DoTweenHelper.Gizmos;
using UnityEditor;
using UnityEngine;

namespace DoTweenHelper.Editor
{
	[InitializeOnLoad]
	[CustomEditor(typeof(TransformPathTween))]
	public class SetPathInSceneEditor : 
#if UNITY_EDITOR
		UnityEditor.Editor
#endif
	{
		public static IPathTween curPathTween;

#if UNITY_EDITOR

		static SetPathInSceneEditor()
		{
			curPathTween = null;
		}
		
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			var mono = target as MonoBehaviour;
			var attributes = mono?.GetType().GetCustomAttributes(typeof(SetPathInSceneAttribute), true);
			if (attributes == null || attributes.Length == 0)
			{
				return;
			}
		
			base.OnInspectorGUI();
			
			if (curPathTween == null)
			{
				if (GUILayout.Button("在Scene绘制路径点"))
				{
					if (!mono.TryGetComponent<ShowPathPoints>(out var com))
					{
						com = mono.gameObject.AddComponent<ShowPathPoints>();
					}

					curPathTween = target as IPathTween;
					if (curPathTween != null)
					{
						curPathTween.isHandling = true;
					}
				}
			}
			else if (Equals(curPathTween, target))
			{
				if (GUILayout.Button("完成绘制"))
				{
					curPathTween = null;
					if (mono.TryGetComponent<ShowPathPoints>(out var com))
					{
						DestroyImmediate(com);
					}
				}
			}
			else
			{
				Debug.LogWarning((curPathTween as Component)?.gameObject.name + " 正在绘制路线，请先完成该路线绘制！");
			}

			serializedObject.ApplyModifiedProperties();
		}

		void OnSceneGUI()
		{
			Event curEvent = Event.current;

			if (curEvent.type == EventType.MouseDown && curEvent.button == 0)
			{
				Ray mouseRay = HandleUtility.GUIPointToWorldRay(curEvent.mousePosition);
				RaycastHit hit;
				if (curPathTween != null && Physics.Raycast(mouseRay, out hit))
				{
					if (!ArrayUtility.Contains(curPathTween.pathPoints, hit.point))
					{
						ArrayUtility.Add(ref curPathTween.pathPoints, hit.point);
					}
					else
					{
						ArrayUtility.Remove(ref curPathTween.pathPoints, hit.point);
					}
					
					EditorUtility.SetDirty(this);
				}
			}
		}
#endif
	}
}