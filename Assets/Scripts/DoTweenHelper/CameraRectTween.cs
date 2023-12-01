using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public class CameraRectTween : TweenAnimation<Camera, Rect>
	{
		public override bool canPreview { get; } = true;

		public bool snapping;
		
		public override Tween CreateTween()
		{
			var ret = target.DORect(endValue, duration).SetOptions(snapping);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}