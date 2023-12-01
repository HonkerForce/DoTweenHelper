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

		public bool isGriadient;

		/// <summary>
		/// 颜色混合器
		/// </summary>
		public Gradient gradient;
		
		public override Tween CreateTween()
		{
			if (!isGriadient)
			{
				var ret = target?.DOColor(endValue, duration).SetOptions(isOnlyAlpha);
				if (from)
				{
					ret = ret?.From();
				}

				return ret;
			}
			else
			{
				return target?.DOGradientColor(gradient, duration);
			}
		}
	}
}