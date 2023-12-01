﻿using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(AudioSource))]
	public class AudioSourceFadeTween : TweenAnimation<AudioSource, float>
	{
		public override bool canPreview { get; } = true;

		public bool snapping;

		public override Tween CreateTween()
		{
			var ret = target.DOFade(endValue, duration).SetOptions(snapping);
			if (from)
			{
				ret = ret?.From();
			}
			return ret;
		}
	}
}