using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public class CameraAspectTween : TweenAnimation<Camera, float>
	{
		public bool snapping;
		
		public override Tween CreateTween()
		{
			return target.DOAspect(endValue, duration).SetOptions(snapping);
		}
	}
}