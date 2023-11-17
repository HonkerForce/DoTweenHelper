using System;
using DoTweenHelper.Attribute;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	public abstract class LookAtTween<T_Target> : TweenAnimation<T_Target, Vector3>
		where T_Target : Component
	{
		/// <summary>
		/// 锁定的轴(x|y|z)
		/// </summary>
		public AxisConstraint lockAxis;
		
		/// <summary>
		/// 旋转中心轴方向
		/// </summary>
		public Vector3 up;
	}
}