using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	public sealed class TweenControl : MonoBehaviour, ITweenControl
	{
		private Sequence tweeners = null;
		private Sequence fromTweeners = null;

		[SerializeField] private string _ID;

		[SerializeField] private bool _isAutoPlay;

		[SerializeField] private bool _isPlayChildren;

		[SerializeField] private bool _isAutoRewind = true;

		public Sequence Get
		{
			get => tweeners;
		}
		
		public string ID { get => _ID; set => _ID = value; }
		public bool isAutoPlay { get => _isAutoPlay; set => _isAutoPlay = value; }
		public bool isPlayChildren { get => _isPlayChildren; set => _isPlayChildren = value; }
		public bool isAutoRewind { get => _isAutoRewind; set =>_isAutoRewind = value; }

		public void Play()
		{
			tweeners?.Restart(true);
		}

		public void Pause()
		{
			tweeners?.Pause();
		}

		public void Stop()
		{
			tweeners?.Rewind(true);
		}

		public void Rollback()
		{
			if (fromTweeners == null)
			{
				this.fromTweeners = DOTween.Sequence();
				var tweeners = GetComponents<ITween>();
				// bool first = false;
				foreach (var tweener in tweeners)
				{
					// var delay = tweener.delay;
					// if (!first)
					// {
					// 	first = true;
					// 	delay = 0;
					// }
					this.fromTweeners?.Insert(0, tweener.DoTween(true));
				}
			}

			fromTweeners.Restart(false);
		}

		void Start()
		{
			this.tweeners ??= DOTween.Sequence();
			var tweeners = GetComponents<ITween>();

			foreach (var tweener in tweeners)
			{
				this.tweeners?.Insert(tweener.delay, tweener.DoTween());
			}

			this.tweeners?.SetId(ID).Pause();
			
			if (isAutoPlay)
			{
				Play();
			}
		}

		void OnEnable()
		{
			if (isAutoPlay)
			{
				Play();
			}
			else
			{
				Pause();
			}
		}

		void OnDisable()
		{
			tweeners?.Rewind(true);
		}

		void OnDestroy()
		{
			tweeners?.Kill();
		}
	}
}