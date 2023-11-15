using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[Serializable]
	public sealed class TweenControl : MonoBehaviour, ITweenControl
	{
		private Sequence Instance = null;

		[SerializeField] private string _ID;

		[SerializeField] private bool _isAutoPlay;

		[SerializeField] private bool _isPlayChildren;

		[SerializeField] private bool _isAutoRewind = true;

		public Sequence Get
		{
			get => Instance;
		}
		
		public string ID { get => _ID; set => _ID = value; }
		public bool isAutoPlay { get => _isAutoPlay; set => _isAutoPlay = value; }
		public bool isPlayChildren { get => _isPlayChildren; set => _isPlayChildren = value; }
		public bool isAutoRewind { get => _isAutoRewind; set =>_isAutoRewind = value; }

		public void Play()
		{
			Instance?.Restart(true);
		}

		public void Pause()
		{
			Instance?.Pause();
		}

		public void Stop()
		{
			Instance?.Rewind(true);
		}

		void Start()
		{
			Instance ??= DOTween.Sequence();
			var tweeners = GetComponents<ITween>();

			foreach (var tweener in tweeners)
			{
				Instance?.Insert(tweener.delay, tweener.DoTween());
			}

			Instance?.SetId(ID);
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
			Instance?.Kill();
		}
	}
}