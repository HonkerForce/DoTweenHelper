﻿using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class TransformShakeRotateTween : ShakeTween<Transform>
	{
		public override bool canPreview { get; } = true;

		public override Tween CreateTween()
		{
			var ret = target.DOShakeRotation(duration, endValue, shakeNum, shakeRandom, isFadeOut, (ShakeRandomnessMode)randMode);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}