using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public class CameraShakeRotateTween : ShakeTween<Camera>
	{
		public override bool canPreview { get; } = true;

		public override Tween CreateTween()
		{
			return target.DOShakeRotation(duration, endValue, shakeNum, shakeRandom, isFadeOut, (ShakeRandomnessMode)randMode);
		}
	}
}