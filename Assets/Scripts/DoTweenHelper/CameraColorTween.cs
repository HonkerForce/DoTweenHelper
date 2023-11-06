using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public class CameraColorTween : TweenAnimation<Camera, Color>
	{
		public bool isOnlyAlpha;

		public override Tween CreateTween()
		{
			return target.DOColor(endValue, duration).SetOptions(isOnlyAlpha);
		}
	}
}