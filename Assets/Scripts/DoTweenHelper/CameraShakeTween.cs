using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	[ExecuteInEditMode]
	public abstract class CameraShakeTween : TweenAnimation<Camera, Vector3>
	{
		protected Vector3 shakeRange;
		public int shakeNum;
		public float shakeRandom;
		public ShakeRandomType randMode;
		public bool isFadeOut;

#if UNITY_EDITOR
		void Update()
		{
			shakeRange = endValue;
		}
#endif
	}
}