using System;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(TweenControl))]
	[ExecuteInEditMode]
	public abstract class TweenAnimation<T_Target, T_Value> : MonoBehaviour, ITween 
		where T_Target : Component
	{
		private Tween Instance = null;
		
		protected T_Target target = null;

		[SerializeField] protected T_Value endValue;

		[SerializeField] protected string _ID;

		[SerializeField] protected float _duration;

		[SerializeField] protected float _delay;

		[SerializeField] protected bool _isLoop = false;

		[SerializeField] protected int _loopTimes;

		[SerializeField] protected TweenLoopType _loopType = TweenLoopType.Replay;

		[SerializeField] protected bool _isAutoKill = false;

		[SerializeField] protected bool _isLinkGameobject = false;

		[SerializeField] protected LinkBehaviour _linkActionType;

		[SerializeField] protected GameObject _LinkGameobject = null;

		[SerializeField] protected Ease _easeType = Ease.Linear;
		
		public Tween Get
		{
			get => Instance;
		}

		public string ID { get => _ID; set => _ID = value; }
		public float duration { get => _duration; set => _duration = value; }
		public float delay { get => _delay; set => _delay = value; }
		public bool isLoop { get => _isLoop; set => _isLoop = value; }
		public int loopTimes { get => _loopTimes; set => _loopTimes = value; }
		public TweenLoopType loopType { get => _loopType; set => _loopType = value; }
		public bool isAutoKill { get => _isAutoKill; set => _isAutoKill = value; }
		public bool isLinkGameobject { get => _isLinkGameobject; set => _isLinkGameobject = value; }
		public LinkBehaviour linkActionType { get => _linkActionType; set => _linkActionType = value; }
		public GameObject linkGameobject { get => _LinkGameobject; set => _LinkGameobject = value; }
		public Ease easeType { get => _easeType; set => _easeType = value; }

		void Awake()
		{
			target ??= GetComponent<T_Target>();
		}
		
		public abstract Tween CreateTween();
		public Tween DoTween()
		{
			// target ??= GetComponent<T_Target>();

			return CreateTween()
				.SetId(ID)
				.SetDelay(delay)
				.SetLoops(isLoop ? loopTimes : 1, (LoopType)loopType)
				.SetAutoKill(isAutoKill)
				.SetEase(easeType)
				.SetLink(isLinkGameobject ? linkGameobject : null, linkActionType)
				.Pause();
		}
	}
}