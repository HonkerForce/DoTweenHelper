using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DoTweenHelper.Gizmos
{
	public class ShowPathPoints : MonoBehaviour
	{
		private IPathTween pathTween;

		/// <summary>
		/// 绘制标点的半径
		/// </summary>
		public float radius = 0.5f;
		
		/// <summary>
		/// 标点颜色
		/// </summary>
		public Color pointColor = Color.green;

		// public Vector3[] path;

#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			pathTween ??= GetComponent<IPathTween>();
			pathTween.pathPoints ??= new Vector3[] { };
			if (pathTween.pathPoints.Length == 0)
			{
				return;
			}
			
			UnityEngine.Gizmos.color = pointColor;
			Handles.color = pointColor;

			int index = 0;
			foreach (var point in pathTween.pathPoints)
			{
				// UnityEngine.Gizmos.DrawSphere(point, radius);
				Handles.DrawSolidDisc(point, Vector3.forward, radius);
				Handles.Label(point + new Vector3(-radius * 1.5f, radius * 1.5f, 0f), index.ToString());
				index++;
			}

			for (int i = 0; i + 1 < pathTween.pathPoints.Length; ++i)
			{
				UnityEngine.Gizmos.DrawLine(pathTween.pathPoints[i], pathTween.pathPoints[i + 1]);
			}
		}
#endif
	}
}