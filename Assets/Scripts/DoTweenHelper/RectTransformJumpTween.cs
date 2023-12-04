using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(RectTransform))]
	public class RectTransformJumpTween : JumpTween<RectTransform>
	{
		public override bool canPreview { get; } = true;

		public override Tween CreateTween()
		{
			endValue.z = 0;
			return target.DOJumpAnchorPos(endValue, jumpMaxHeight, jumpNum, duration, snapping);
		}
	}
}