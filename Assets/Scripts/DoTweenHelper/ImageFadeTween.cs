using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof( Image))]
	public class ImageFadeTween : ColorFadeTween<Image>
	{
		public override bool canPreview { get; }
		public override Tween CreateTween()
		{
			var ret = target?.DOFade(endValue, duration).SetOptions(isOnlyAlpha);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}