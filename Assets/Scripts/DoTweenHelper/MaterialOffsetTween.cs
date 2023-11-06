using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Renderer))]
	public class MaterialOffsetTween : TweenAnimation<Renderer, Vector2>
	{
		protected Material material;

		public string propertyName = "";

		public bool snapping;

		public MaterialOffsetTween()
		{
			material = target.material;
		}

		public override Tween CreateTween()
		{
			if (String.IsNullOrEmpty(propertyName))
			{
				return material.DOOffset(endValue, duration).SetOptions(snapping);
			}
			else
			{
				return material.DOOffset(endValue, propertyName, duration).SetOptions(snapping);
			}
		}
	}
}