
using DoTweenHelper.Attribute;
using UnityEngine;

namespace DoTweenHelper
{
	[SetPathInScene]
	public interface IPathTween
	{
		ref Vector3[] pathPoints { get; }

		/// <summary>
		/// 是否正在绘制路径
		/// </summary>
		bool isHandling { get; set; }
	}
}