using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyRotateTween : RotateTween<Rigidbody>
	{
		public override bool canPreview { get; } = true;

		protected bool isFrom = false;
		
		public override Tween CreateTween()
		{
			var ret = target?.DORotate(endValue, duration, rotateMode).SetOptions(isUseShortest360Route);
			if (ret != null && isFrom)
			{
				ret = ret.From();
			}

			return ret;
		}
	}
}