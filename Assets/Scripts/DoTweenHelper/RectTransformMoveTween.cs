using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(RectTransform))]
	public class RectTransformMoveTween : TweenAnimation<RectTransform, Vector2>
	{
		public override bool canPreview { get; } = true;

		public bool snapping;
		
		public override Tween CreateTween()
		{
			var ret = target.DOAnchorPos(endValue, duration, snapping);
			if (from)
			{
				ret = ret.From();
			}

			return ret;
		}
	}
}