using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Slider))]
	public class SliderValueTween : TweenAnimation<Slider, float>
	{
		public override bool canPreview { get; } = true;

		public bool snapping;
		
		public override Tween CreateTween()
		{
			var ret = target.DOValue(endValue, duration, snapping);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}