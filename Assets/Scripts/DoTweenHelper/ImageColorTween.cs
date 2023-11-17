using System;
using DG.Tweening;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Image))]
	public class ImageColorTween : ColorTween<Image>
	{
		public override bool canPreview { get; } = true;

		/// <summary>
		/// 颜色混合器
		/// </summary>
		public Gradient gradient;
		
		public override Tween CreateTween()
		{
			if (gradient == null)
			{
				return target?.DOColor(endValue, duration).SetOptions(isOnlyAlpha);
			}
			else
			{
				return target?.DOGradientColor(gradient, duration);
			}
		}
	}
}