﻿using System;
using DoTweenHelper.Attribute;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	public abstract class PathTween<T_Target> : TweenAnimation<T_Target, Vector3[]>
		where T_Target : Component
	{
		/// <summary>
		/// 生成路线的类型
		/// 线性段落/平滑曲线(罗姆曲线/贝塞尔曲线)
		/// 线性段落/罗姆曲线：可传入多个不限数量的路径点
		/// 贝塞尔曲线：传入三个点，起点、终点、中间点
		/// </summary>
		public PathType pathType;

		/// <summary>
		/// 路线朝向模式，影响使用SetLookAt配置的朝向参数的生效方式
		/// </summary>
		public PathMode pathMode = PathMode.Full3D;

		/// <summary>
		/// 分辨率
		/// 分辨率越高生成线路越平滑，对性能损耗越高
		/// </summary>
		public int resolution = 10;

		/// <summary>
		/// 是否生成闭合的路径
		/// </summary>
		/// <returns>默认生成不闭合的线路</returns>
		public bool isClosePath = false;

		/// <summary>
		/// 是否控制朝向前瞻
		/// </summary>
		public bool isAhead = true;

		/// <summary>
		/// 朝向位置
		/// isAhead = false时，需要配置
		/// </summary>
		public Vector3 lookAtPosition;

		/// <summary>
		/// 前瞻展望百分比[0~1]
		/// isAhead = true时，需要配置
		/// </summary>
		public float lookAhead;

		/// <summary>
		/// 前方向，无特殊规定可为空
		/// </summary>
		public Vector3? forwardDic = null;

		/// <summary>
		/// 旋转中心轴方向，无特殊规定可为空
		/// </summary>
		/// <returns></returns>
		public Vector3? up = null;

		/// <summary>
		/// 
		/// </summary>
		[EnumField] public AxisConstraint lockPosition;

		/// <summary>
		/// 
		/// </summary>
		[EnumField] public AxisConstraint lockRotation;
	}
}