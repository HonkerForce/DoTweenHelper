using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class TransformScaleTween : TweenAnimation<Transform, Vector3>
	{
		public override bool canPreview { get; } = true;

		/// <summary>
		/// 是否平滑生成为整数坐标
		/// </summary>
		public bool snapping;

		/// <summary>
		/// 是否从传入值渐变到当前值
		/// </summary>
		protected bool isFrom;
		
		public override Tween CreateTween()
		{
			var ret = target.DOScale(endValue, duration).SetOptions(snapping);
			if (isFrom)
			{
				ret = ret.From();
			}

			return ret;
		}
	}
}