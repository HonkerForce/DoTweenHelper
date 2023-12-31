﻿using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Image))]
	public class ImageFillAmountTween : TweenAnimation<Image, float>
	{
		public override bool canPreview { get; } = true;

		public bool snapping;
		
		public override Tween CreateTween()
		{
			var ret = target.DOFillAmount(endValue, duration).SetOptions(snapping);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}