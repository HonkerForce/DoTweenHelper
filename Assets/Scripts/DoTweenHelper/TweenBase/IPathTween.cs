
using DoTweenHelper.Attribute;
using UnityEngine;

namespace DoTweenHelper
{
	[SetPathInScene]
	public interface IPathTween : ITween
	{
		ref Vector3[] pathPoints { get; }
	}
}