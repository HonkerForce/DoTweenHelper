using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Renderer))]
	public class MaterialColorTween : TweenAnimation<Renderer, Color>
	{
		protected Material material;

		public string propertyName = "";

		public bool isOnlyAlpha;

		public bool isUseGradient;

		public Gradient gradient;

		public MaterialColorTween()
		{
			material = target.material;
		}

		public override Tween CreateTween()
		{
			if (isUseGradient)
			{
				if (String.IsNullOrEmpty(propertyName))
				{
					return material.DOGradientColor(gradient, duration);
				}
				else
				{
					return material.DOGradientColor(gradient, propertyName, duration);
				}
			}
			else
			{
				if (String.IsNullOrEmpty(propertyName))
				{
					return material.DOColor(endValue, duration).SetOptions(isOnlyAlpha);
				}
				else
				{
					return material.DOColor(endValue, propertyName, duration).SetOptions(isOnlyAlpha);
				}
			}
		}
	}
}