using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Renderer))]
	public class MaterialOffsetTween : TweenAnimation<Renderer, Vector2>
	{
		public override bool canPreview { get; } = true;

		protected Material material;

		public int index;

		public string propertyName = "";

		public bool snapping;

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

			Tweener ret = null;
			if (String.IsNullOrEmpty(propertyName))
			{
				ret = material.DOOffset(endValue, duration).SetOptions(snapping);
			}
			else
			{
				ret = material.DOOffset(endValue, propertyName, duration).SetOptions(snapping);
			}

			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}