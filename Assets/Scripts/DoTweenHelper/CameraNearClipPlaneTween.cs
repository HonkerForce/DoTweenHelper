using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public class CameraNearClipPlaneTween : TweenAnimation<Camera, float>
	{
		public bool snapping;

		public override Tween CreateTween()
		{
			return target.DONearClipPlane(endValue, duration).SetOptions(snapping);
		}
	}
}