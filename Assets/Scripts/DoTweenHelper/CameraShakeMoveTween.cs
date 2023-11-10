using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public class CameraShakeMoveTween : ShakeTween<Camera>
	{
		public override Tween CreateTween()
		{
			return target.DOShakePosition(duration, endValue, shakeNum, shakeRandom, isFadeOut, (ShakeRandomnessMode)randMode);
		}
	}
}