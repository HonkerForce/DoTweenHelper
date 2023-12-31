using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(RectTransform))]
	public class RectTransformSizeDeltaTween : TweenAnimation<RectTransform, Vector2>
	{
		public override bool canPreview { get; } = true;

		public AxisConstraint lockAxis;

		public bool snapping;
		
		public override Tween CreateTween()
		{
			var ret = target.DOSizeDelta(endValue, duration, snapping).SetOptions(lockAxis);
			if (from)
			{
				ret = ret.From();
			}

			return ret;
		}
	}
}