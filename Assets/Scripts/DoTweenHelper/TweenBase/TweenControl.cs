using System;
using System.Linq;
using System.Threading.Tasks;
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

		public Task Stop(bool isRollback)
		{
			Task task = null;
			if (isRollback)
			{
				task = Rollback();
			}

			return task;
		}

		public Task Rollback()
		{
			if (fromTweeners == null)
			{
				this.fromTweeners = DOTween.Sequence().SetAutoKill(false);
				var tweeners = GetComponents<ITween>();
				foreach (var tweener in tweeners)
				{
					this.fromTweeners?.Insert(0, tweener.DoTween(true));
				}
			}

			fromTweeners.Restart(true);
			return fromTweeners.AsyncWaitForCompletion();
		}

		void Start()
		{
			this.tweeners ??= DOTween.Sequence().SetAutoKill(false).SetId(ID);
			var tweeners = GetComponents<ITween>();

			foreach (var tweener in tweeners)
			{
				this.tweeners?.Insert(0, tweener.DoTween());
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

		void OnDestroy()
		{
			tweeners?.Kill();
			fromTweeners?.Kill();
			tweeners = null;
			fromTweeners = null;
		}
	}
}