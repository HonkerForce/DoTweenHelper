using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Light))]
	public class LightShadowStrength : TweenAnimation<Light, float>
	{
		public override bool canPreview { get; } = true;

		public bool snapping;
		
		public override Tween CreateTween()
		{
			var ret = target?.DOShadowStrength(endValue, duration).SetOptions(snapping);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}