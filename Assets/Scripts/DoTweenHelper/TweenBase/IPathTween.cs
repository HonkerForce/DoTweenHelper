
using DoTweenHelper.Attribute;
using UnityEngine;

namespace DoTweenHelper
{
	[ShowPathInScene]
	public interface IPathTween : ITween
	{
		ref Vector3[] pathPoints { get; }
	}
}