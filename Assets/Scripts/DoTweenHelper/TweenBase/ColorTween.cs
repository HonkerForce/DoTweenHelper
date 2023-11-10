using System;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	public abstract class ColorTween<T_Target> : TweenAnimation<T_Target, Color>
		where T_Target : Component
	{
		public bool isOnlyAlpha;
	}
}