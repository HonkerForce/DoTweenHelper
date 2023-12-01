using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public class CameraFOVTween : TweenAnimation<Camera, float>
	{
		public override bool canPreview { get; } = true;

		public bool snapping;

		public override Tween CreateTween()
		{
			var ret = target.DOFieldOfView(endValue, duration).SetOptions(snapping);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}