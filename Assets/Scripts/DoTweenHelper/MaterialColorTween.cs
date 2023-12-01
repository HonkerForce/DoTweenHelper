using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Renderer))]
	public class MaterialColorTween : ColorTween<Renderer>
	{
		public override bool canPreview { get; } = true;

		protected Material material;
		
		/// <summary>
		/// 修改Render中第几个material(索引)
		/// 默认值为0
		/// </summary>
		public int index = 0;

		public string propertyName = "";

		public bool isUseGradient;

		/// <summary>
		/// 颜色混合器引用
		/// </summary>
		public Gradient gradient;

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
				Debug.LogError("获取Render中的Material引用失败！index=" + index);
				return null;
			}
			
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
				Tweener ret = null;
				if (String.IsNullOrEmpty(propertyName))
				{
					ret = material.DOColor(endValue, duration).SetOptions(isOnlyAlpha);
				}
				else
				{
					ret = material.DOColor(endValue, propertyName, duration).SetOptions(isOnlyAlpha);
				}

				if (from)
				{
					ret = ret?.From();
				}

				return ret;
			}
		}
	}
}