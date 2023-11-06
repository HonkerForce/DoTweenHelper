using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	public enum ShakeRandomType
	{
		/// <summary>
		/// 完全随机
		/// </summary>
		FullRand = ShakeRandomnessMode.Full,
		
		/// <summary>
		/// 平衡随机
		/// </summary>
		BalanceRand = ShakeRandomnessMode.Harmonic,
	}
	
	[Serializable]
	[RequireComponent(typeof(Transform))]
	public abstract class TransformShakeTween : TweenAnimation<Transform, Vector3>
	{
		/// <summary>
		/// 震动幅度
		/// </summary>
		protected Vector3 shakeRange;
		
		/// <summary>
		/// 震动次数
		/// </summary>
		public int shakeNum;
		
		/// <summary>
		/// 震动方向随机性(0~180)
		/// 改变震动方向的随机值
		/// </summary>
		public float shakeRandom;

		/// <summary>
		/// 震动随机模式
		/// </summary>
		public ShakeRandomType randMode;
		
		/// <summary>
		/// 是否淡出(在运动最后回到原位置)
		/// </summary>
		public bool isFadeOut;

		public TransformShakeTween()
		{
			shakeRange = endValue;
		}
		
	}
}