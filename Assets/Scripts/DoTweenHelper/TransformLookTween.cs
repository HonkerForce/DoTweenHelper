using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class TransformLookTween : LookAtTween<Transform>
	{
		public override bool canPreview { get; } = true;
		public override Tween CreateTween()
		{
			var ret = target?.DODynamicLookAt(endValue, duration, lockAxis, up);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}