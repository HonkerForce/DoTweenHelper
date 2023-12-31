﻿using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyPathTween : PathTween<Rigidbody>
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

			if (from)
			{
				ret = ret.From();
			}

			return ret;
		}
	}
}