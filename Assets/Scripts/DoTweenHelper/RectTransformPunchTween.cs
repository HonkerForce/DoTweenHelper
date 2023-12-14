using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(RectTransform))]
	public class RectTransformPunchTween : PunchTween<RectTransform>
	{
		public override bool canPreview { get; } = true;
		
		public override Tween CreateTween()
		{
			_endValue.z = 0;
			return target.DOPunchAnchorPos(endValue, duration, punchNum, inertia);
		}
	}
}