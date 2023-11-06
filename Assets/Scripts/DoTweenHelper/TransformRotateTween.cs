using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public class TransformRotateTween : TweenAnimation<Transform, Vector3>
	{
		public bool isRelative = false;
		public RotateMode rotateMode;
		public bool isUseShortest360Route = false;
		
		public override Tween CreateTween()
		{
			return target?.DORotate(endValue, duration, rotateMode).SetRelative(isRelative).SetOptions(isUseShortest360Route);
		}
	}
}