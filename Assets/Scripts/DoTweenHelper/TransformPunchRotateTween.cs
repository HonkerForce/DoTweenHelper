using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	public class TransformPunchRotateTween : TransformPunchTween
	{
		public override Tween CreateTween()
		{
			return target.DOPunchRotation(endValue, duration, punchNum, inertia);
		}
	}
}