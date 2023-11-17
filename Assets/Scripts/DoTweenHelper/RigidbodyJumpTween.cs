using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyJumpTween : JumpTween<Rigidbody>
	{
		public override bool canPreview { get; } = true;
		public override Tween CreateTween()
		{
			return target?.DOJump(endValue, jumpMaxHeight, jumpNum, duration, snapping);
		}
	}
}