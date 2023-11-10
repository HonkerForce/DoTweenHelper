using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class TransformPunchMoveTween : PunchTween<Transform>
	{
		public override Tween CreateTween()
		{
			return target.DOPunchPosition(endValue, duration, punchNum, inertia);
		}
	}
}