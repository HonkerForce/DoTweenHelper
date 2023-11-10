using System;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	public abstract class ColorFadeTween<T_Target> : TweenAnimation<T_Target, float>
		where T_Target : Component
	{
		public bool isOnlyAlpha;
	}
}