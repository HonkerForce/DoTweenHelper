using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public class CameraShakeMoveTween : ShakeTween<Camera>
	{
		public override bool canPreview { get; } = true;

		public override Tween CreateTween()
		{
			var ret = target.DOShakePosition(duration, endValue, shakeNum, shakeRandom, isFadeOut, (ShakeRandomnessMode)randMode);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}