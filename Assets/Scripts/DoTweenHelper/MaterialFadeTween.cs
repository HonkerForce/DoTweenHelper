using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Renderer))]
	public class MaterialFadeTween : TweenAnimation<Renderer, float>
	{
		protected Material material;

		public string propertyName = "";

		public bool isOnlyAlpha;

		public MaterialFadeTween()
		{
			material = target.material;
		}

		public override Tween CreateTween()
		{
			if (String.IsNullOrEmpty(propertyName))
			{
				return material.DOFade(endValue, duration).SetOptions(isOnlyAlpha);
			}
			else
			{
				return material.DOFade(endValue, propertyName, duration).SetOptions(isOnlyAlpha);
			}
		}
	}
}