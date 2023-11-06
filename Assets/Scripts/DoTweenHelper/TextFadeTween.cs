using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Text))]
	public class TextFadeTween : TweenAnimation<Text, float>
	{
		public bool isOnlyAlpha;

		public override Tween CreateTween()
		{
			return target.DOFade(endValue, duration).SetOptions(isOnlyAlpha);
		}
	}
}