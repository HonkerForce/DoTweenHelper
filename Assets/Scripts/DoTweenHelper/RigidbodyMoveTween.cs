using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyMoveTween : MoveTween<Rigidbody>
	{
		public override bool canPreview { get; } = true;

		protected bool isFrom = false;
		
		public override Tween CreateTween()
		{
			var ret = target?.DOMove(endValue, duration, snapping).SetRelative(isRelative);
			if (ret != null && isFrom)
			{
				ret = ret.From();
			}

			return ret;
		}
	}
}