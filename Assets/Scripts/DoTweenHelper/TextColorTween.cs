using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Text))]
	public class TextColorTween : ColorTween<Text>
	{
		public override bool canPreview { get; } = true;

		public override Tween CreateTween()
		{
			var ret = target.DOColor(endValue, duration).SetOptions(isOnlyAlpha);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}