using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	/// <summary>
	/// 窗口动效：窗口创建时的，窗口尺寸从小变大
	/// </summary>
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class WindowFromTween : TransformScaleTween
	{
		public override bool canPreview { get; } = false;

		public override Tween CreateTween()
		{
			isFrom = true;

			return base.CreateTween();
		}
	}
}