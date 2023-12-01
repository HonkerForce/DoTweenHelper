﻿using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyRotateTween : RotateTween<Rigidbody>
	{
		public override bool canPreview { get; } = true;

		public override Tween CreateTween()
		{
			var ret = target?.DORotate(endValue, duration, rotateMode).SetOptions(isUseShortest360Route);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}