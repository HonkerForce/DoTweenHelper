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

		// public Vector3[] path;

		void Awake()
		{
			pathTween ??= GetComponent<IPathTween>();
		}

#if UNITY_EDITOR

		private void OnDrawGizmos()
		{
			if (pathTween == null || pathTween.pathPoints.Length == 0)
			{
				return;
			}
			
			UnityEngine.Gizmos.color = Color.green;

			foreach (var point in pathTween.pathPoints)
			{
				UnityEngine.Gizmos.DrawSphere(point, radius);
			}
		}
#endif
	}
}