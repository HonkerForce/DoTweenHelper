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
	public class SetPathInSceneEditor : 
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
			var attributes = com?.GetType().GetCustomAttributes(typeof(SetPathInSceneAttribute), true);
			if (attributes == null || attributes.Length == 0)
			{
				return;
			}
			
			if (curPathTween == null)
			{
				if (GUILayout.Button("在Scene绘制路径点"))
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
				if (GUILayout.Button("完成绘制"))
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

		void OnSceneGUI()
		{
			Event curEvent = Event.current;
			if (curEvent == null)
			{
				return;
			}

			if (curPathTween != null)
			{
				com ??= target as MonoBehaviour;
				Selection.activeGameObject = (target as MonoBehaviour)?.gameObject;
			}

			if (curEvent.shift && curEvent.type == EventType.MouseDown && curEvent.button == 0)
			{
				var lastCamera = SceneView.lastActiveSceneView.camera;

				var pointInWorld = lastCamera.ScreenToWorldPoint(curEvent.mousePosition);
				var trans = com?.transform;
				if (trans == null)
				{
					return;
				}
				var localPoint = trans.transform.InverseTransformPoint(pointInWorld);
				if (localPoint == null)
				{
					Debug.Log("localPoint == null");
					return;
				}

				localPoint.z = 0;
				if (curPathTween != null && curPathTween.pathPoints != null)
				{
					if (!ArrayUtility.Contains(curPathTween.pathPoints, localPoint))
					{
						ArrayUtility.Add(ref curPathTween.pathPoints, localPoint);
					}
					else
					{
						ArrayUtility.Remove(ref curPathTween.pathPoints, localPoint);
					}
					
					EditorUtility.SetDirty(this);
					curEvent.Use();
				}
			}
		}
#endif
	}
}