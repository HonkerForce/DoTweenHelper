﻿using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public class CameraColorTween : ColorTween<Camera>
	{
		public override bool canPreview { get; } = true;

		public override Tween CreateTween()
		{
			var ret = target.DOColor(endValue, duration).SetOptions(isOnlyAlpha);
			if (from)
			{
				ret = ret?.From();
			}

			return ret;
		}
	}
}