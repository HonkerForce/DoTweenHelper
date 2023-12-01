using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Light))]
	public class LightColorTween : ColorTween<Light>
	{
		public override bool canPreview { get; } = true;
		public override Tween CreateTween()
		{
			var ret = target?.DOColor(endValue, duration).SetOptions(isOnlyAlpha);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}