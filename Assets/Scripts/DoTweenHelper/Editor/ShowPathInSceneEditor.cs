using System.Collections.Generic;
using DoTweenHelper.Attribute;
using DoTweenHelper.Gizmos;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DoTweenHelper.Editor
{
	[InitializeOnLoad]
	[CustomEditor(typeof(MonoBehaviour), true)]
	public class ShowPathInSceneEditor : 
#if UNITY_EDITOR
		UnityEditor.Editor
#endif
	{
		public static IPathTween curPathTween;

		private MonoBehaviour com;

#if UNITY_EDITOR
		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			
			base.OnInspectorGUI();

			com = target as MonoBehaviour;
			var attributes = com?.GetType().GetCustomAttributes(typeof(ShowPathInSceneAttribute), true);
			if (attributes == null || attributes.Length == 0)
			{
				return;
			}
			
			if (curPathTween == null)
			{
				if (GUILayout.Button("显示路径", GUILayout.Height(30)))
				{
					if (!com.TryGetComponent<ShowPathPoints>(out var mono))
					{
						mono = com.gameObject.AddComponent<ShowPathPoints>();
					}

					curPathTween = target as IPathTween;
				}
			}
			else if (Equals(curPathTween, target))
			{
				if (GUILayout.Button("隐藏路径", GUILayout.Height(30)))
				{
					if (com.TryGetComponent<ShowPathPoints>(out var mono))
					{
						DestroyImmediate(mono);
					}
					curPathTween = null;
				}
			}
			else
			{
				Debug.LogWarning((curPathTween as Component)?.gameObject.name + " 正在绘制路线，请先完成该路线绘制！");
			}

			serializedObject.ApplyModifiedProperties();
		}

		// void OnSceneGUI()
		// {
		// 	Event curEvent = Event.current;
		// 	if (curEvent == null)
		// 	{
		// 		return;
		// 	}
		//
		// 	if (curPathTween != null)
		// 	{
		// 		Selection.activeObject = target;
		// 	}
		//
		// 	if (curEvent.shift && curEvent.type == EventType.MouseDown && curEvent.button == 0)
		// 	{
		// 		var curMousePosition = curEvent.mousePosition;
		// 		var curViewPosition = SceneView.lastActiveSceneView.camera.ScreenToViewportPoint(curMousePosition);
		// 		// var curWorldPosition = SceneView.lastActiveSceneView.camera.transform.localToWorldMatrix * curViewPosition;
		//
		// 		Debug.Log($"viewPosition:{curViewPosition} mousePosition:{curMousePosition}");
		// 		if (curPathTween != null && curPathTween.pathPoints != null)
		// 		{
		// 			if (!ArrayUtility.Contains(curPathTween.pathPoints, curViewPosition))
		// 			{
		// 				ArrayUtility.Add(ref curPathTween.pathPoints, curViewPosition);
		// 			}
		// 			else
		// 			{
		// 				ArrayUtility.Remove(ref curPathTween.pathPoints, curViewPosition);
		// 			}
		// 			
		// 			EditorUtility.SetDirty(this);
		// 			curEvent.Use();
		// 		}
		// 	}
		// }
#endif
	}
}