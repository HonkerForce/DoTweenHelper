using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class TransformShakeMoveTween : ShakeTween<Transform>
	{
		public override bool canPreview { get; } = true;

		public bool snapping;
		
		public override Tween CreateTween()
		{
			return target.DOShakePosition(duration, endValue, shakeNum, shakeRandom, snapping, isFadeOut, (ShakeRandomnessMode)randMode);
		}
	}
}