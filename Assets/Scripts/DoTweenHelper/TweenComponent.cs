using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	public abstract class TweenComponent : MonoBehaviour, ITweener
	{
		public Tween Instance = null;

		public string ID { get; set; }
		public float duration { get; set; }
		public bool isRelative { get; set; } = false;
		public float delay { get; set; }
		public bool isLoop { get; set; } = false;
		public int loopTimes { get; set; }
		public TweenLoopType loopType { get; set; }
		public bool isAutoKill { get; set; } = false;
		public bool isLinkGameobject { get; set; } = false;
		public LinkBehaviour linkActionType { get; set; }
		public GameObject linkGameobject { get; set; }
		public Ease easeType { get; set; } = Ease.Linear;
		public bool isInsertSequence { get; set; }
		public float insertSequencePos { get; set; }
		
		public abstract Tween CreateTween();

		public Tween DoTween()
		{
			return Instance;
		}
	}
}