using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	public abstract class RotateTween<T_Target> : TweenAnimation<T_Target, Vector3>
		where T_Target : Component
	{
		public bool isRelative = false;
		public RotateMode rotateMode;
		public bool isUseShortest360Route = false;
	}
}