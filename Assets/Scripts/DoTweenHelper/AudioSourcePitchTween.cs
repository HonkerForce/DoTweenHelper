using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(AudioSource))]
	public class AudioSourcePitchTween : TweenAnimation<AudioSource, float>
	{
		public override bool canPreview { get; } = true;

		public bool snapping;

		public override Tween CreateTween()
		{
			return target.DOPitch(endValue, duration).SetOptions(snapping);
		}
	}
}