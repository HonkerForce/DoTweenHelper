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

		public override Tween CreateTween()
		{
			material ??= target?.sharedMaterial;
			if (material == null)
			{
				Debug.LogError("获取Render中的Material引用失败！");
				return null;
			}
			
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