using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyLookTween : LookAtTween<Rigidbody>
	{
		public override bool canPreview { get; } = true;
		public override Tween CreateTween()
		{
			return target?.DOLookAt(endValue, duration, lockAxis, up);
		}
	}
}