using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(AudioSource))]
	public class AudioSourceFadeTween : TweenAnimation<AudioSource, float>
	{
		public bool snapping;

		public override Tween CreateTween()
		{
			return target.DOFade(endValue, duration).SetOptions(snapping);
		}
	}
}