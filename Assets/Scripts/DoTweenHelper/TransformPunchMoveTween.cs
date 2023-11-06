using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	public class TransformPunchMoveTween : TransformPunchTween
	{
		public override Tween CreateTween()
		{
			return target.DOPunchPosition(endValue, duration, punchNum, inertia);
		}
	}
}