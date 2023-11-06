using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public class CameraOrthoSizeTween : TweenAnimation<Camera, float>
	{
		public bool snapping;
		
		public override Tween CreateTween()
		{
			return target.DOOrthoSize(endValue, duration).SetOptions(snapping);
		}
	}
}