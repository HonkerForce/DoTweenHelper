using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class TransformPunchScaleTween : PunchTween<Transform>
	{
		public override Tween CreateTween()
		{
			return target.DOPunchScale(endValue, duration, punchNum, inertia);
		}
	}
}