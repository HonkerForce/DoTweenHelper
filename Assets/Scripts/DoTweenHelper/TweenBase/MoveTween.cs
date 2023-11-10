using System;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	public abstract class MoveTween<T_Target> : TweenAnimation<T_Target, Vector3>
		where T_Target : Component
	{
		/// <summary>
		/// 是否平滑生成为整数坐标
		/// </summary>
		public bool snapping = false;
		
		/// <summary>
		/// 是否相对变化(绝对->赋值，相对->累加)
		/// </summary>
		public bool isRelative = false;
	}
}