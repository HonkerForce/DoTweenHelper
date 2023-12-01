using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class TransformRotateTween : RotateTween<Transform>
	{
		public override bool canPreview { get; } = true;

		public override Tween CreateTween()
		{
			var ret = target?.DORotate(endValue, duration, rotateMode).SetRelative(isRelative).SetOptions(isUseShortest360Route);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}