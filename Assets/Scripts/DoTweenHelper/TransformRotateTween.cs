using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class TransformRotateTween : RotateTween<Transform>
	{
		public bool isFrom = false;
		
		public override Tween CreateTween()
		{
			var ret = target?.DORotate(endValue, duration, rotateMode).SetRelative(isRelative).SetOptions(isUseShortest360Route);
			if (isFrom)
			{
				ret.From();
			}

			return ret;
		}
	}
}