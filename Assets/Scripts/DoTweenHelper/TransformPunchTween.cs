﻿using System;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public abstract class TransformPunchTween : TweenAnimation<Transform, Vector3>
	{
		/// <summary>
		/// 冲击次数
		/// </summary>
		public int punchNum;
		
		/// <summary>
		/// 惯性(0~1)
		/// 大于0,冲击到EndPoint时会继续运动一段距离
		/// </summary>
		public float inertia;
		
	}
}