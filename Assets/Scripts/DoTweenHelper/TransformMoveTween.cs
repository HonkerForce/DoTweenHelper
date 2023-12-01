using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class TransformMoveTween : MoveTween<Transform>
	{
		public override bool canPreview { get; } = true;

		public override Tween CreateTween()
		{
			var ret = target?.DOMove(endValue, duration, snapping).SetRelative(isRelative);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}