using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Camera))]
	public abstract class CameraShakeTween : TweenAnimation<Camera, Vector3>
	{
		public int shakeNum;
		public float shakeRandom;
		public ShakeRandomType randMode;
		public bool isFadeOut;
	}
}