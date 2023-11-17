using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(CanvasGroup))]
	public class CanvasFadeTween : ColorFadeTween<CanvasGroup>
	{
		public override bool canPreview { get; } = true;
		
		public bool snapping;
		
		public override Tween CreateTween()
		{
			isOnlyAlpha = true;
			return target.DOFade(endValue, duration).SetOptions(snapping);
		}
	}
}