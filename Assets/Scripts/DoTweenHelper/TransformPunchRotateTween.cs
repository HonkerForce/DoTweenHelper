using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class TransformPunchRotateTween : PunchTween<Transform>
	{
		public override bool canPreview { get; } = true;

		public override Tween CreateTween()
		{
			var ret = target.DOPunchRotation(endValue, duration, punchNum, inertia);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}