using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class TransformMoveTween : TweenAnimation<Transform, Vector3>
	{
		/// <summary>
		/// 是否平滑生成为整数坐标
		/// </summary>
		public bool snapping = false;
		
		/// <summary>
		/// 是否相对变化(绝对->赋值，相对->累加)
		/// </summary>
		public bool isRelative = false;

		public override Tween CreateTween()
		{
			return target?.DOMove(endValue, duration, snapping).SetRelative(isRelative);
		}
	}
}