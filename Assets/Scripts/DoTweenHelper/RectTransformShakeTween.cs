using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(RectTransform))]
	public class RectTransformShakeTween : ShakeTween<RectTransform>
	{
		public override bool canPreview { get; } = true;

		public bool snapping;
		
		public override Tween CreateTween()
		{
			endValue.z = 0;
			return target.DOShakeAnchorPos(duration, endValue, shakeNum, shakeRandom, snapping, isFadeOut, (ShakeRandomnessMode)randMode);
		}
	}
}