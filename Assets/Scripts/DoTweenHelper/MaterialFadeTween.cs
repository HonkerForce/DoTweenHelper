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

		/// <summary>
		/// 修改Render中第几个material(索引)
		/// 默认值为0
		/// </summary>
		public int index = 0;

		public string propertyName = "";

		public bool isOnlyAlpha;

		public override Tween CreateTween()
		{
			if (target == null)
			{
				return null;
			}
			if (Application.isPlaying)
			{
				if (index < target.materials.Length)
				{
					material = target.materials[index];
				}
			}
			else
			{
				if (index < target.sharedMaterials.Length)
				{
					material = target.sharedMaterials[index];
				}
			}
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