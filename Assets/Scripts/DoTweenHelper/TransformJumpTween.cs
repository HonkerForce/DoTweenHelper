using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	public class TransformJumpTween : TweenAnimation<Transform, Vector3>
	{
		public float jumpMaxHeight;
		public int jumpNum;
		public bool snapping;

		public override Tween CreateTween()
		{
			return target.DOJump(endValue, jumpMaxHeight, jumpNum, duration, snapping);
		}
	}
}