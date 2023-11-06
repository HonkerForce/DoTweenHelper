using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public class CameraRectTween : TweenAnimation<Camera, Rect>
	{
		public bool snapping;
		
		public override Tween CreateTween()
		{
			return target.DORect(endValue, duration).SetOptions(snapping);
		}
	}
}