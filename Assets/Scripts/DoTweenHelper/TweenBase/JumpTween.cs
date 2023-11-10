using System;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	public abstract class JumpTween<T_Target> : TweenAnimation<T_Target, Vector3>
		where T_Target : Component
	{
		public float jumpMaxHeight;
		public int jumpNum;
		public bool snapping;
	}
}