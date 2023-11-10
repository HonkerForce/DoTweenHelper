using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public class CameraPixelRectTween : TweenAnimation<Camera, Rect>
	{
		public override bool canPreview { get; } = true;

		public bool snapping;

		public override Tween CreateTween()
		{
			return target.DOPixelRect(endValue, duration).SetOptions(snapping);
		}
	}
}