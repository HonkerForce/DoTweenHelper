using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Text))]
	public class TextFadeTween : ColorFadeTween<Text>
	{
		public override bool canPreview { get; } = true;

		public override Tween CreateTween()
		{
			return target.DOFade(endValue, duration).SetOptions(isOnlyAlpha);
		}
	}
}