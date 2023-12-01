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
			var ret = target.DOFade(endValue, duration).SetOptions(snapping);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}