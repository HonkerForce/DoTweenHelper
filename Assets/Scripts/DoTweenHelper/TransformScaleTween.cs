using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class TransformScaleTween : TweenAnimation<Transform, Vector3>
	{
		/// <summary>
		/// 是否平滑生成为整数坐标
		/// </summary>
		public bool snapping;
		
		public override Tween CreateTween()
		{
			return target.DOScale(endValue, duration).SetOptions(snapping);
		}
	}
}