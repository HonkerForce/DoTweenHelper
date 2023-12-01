using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public class CameraAspectTween : TweenAnimation<Camera, float>
	{
		public override bool canPreview { get; } = true;

		public bool snapping;
		
		public override Tween CreateTween()
		{
			var ret = target.DOAspect(endValue, duration).SetOptions(snapping);
			if (from) ret = ret?.From();
			return ret;
		}
	}
}