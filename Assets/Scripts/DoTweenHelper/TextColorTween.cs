using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Text))]
	public class TextColorTween : TweenAnimation<Text, Color>
	{
		public bool isOnlyAlpha;

		public override Tween CreateTween()
		{
			return target.DOColor(endValue, duration).SetOptions(isOnlyAlpha);
		}
	}
}