using System;
using DG.Tweening;
using DoTweenHelper.Attribute;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	[ShowPathInScene]
	public class TransformPathTween : PathTween<Transform>
	{
		public override bool canPreview { get; } = true;

		public override Tween CreateTween()
		{
			var ret = target?.DOPath(endValue, duration, pathType, pathMode, resolution, isGizmosPath ? gizmosColor : null).SetOptions(isClosePath, lockPosition, lockRotation);
			if (ret == null)
			{
				return ret;
			}
			if (isAhead)
			{
				ret.SetLookAt(lookAhead, forwardDic, up);
			}
			else
			{
				ret.SetLookAt(lookAtPosition, forwardDic, up);
			}

			return ret;
		}
	}
}