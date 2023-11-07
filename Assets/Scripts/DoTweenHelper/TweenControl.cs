using System;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	public sealed class TweenControl : MonoBehaviour, ITweenControl
	{
		private Sequence Instance = null;

		[SerializeField] private string _ID;

		[SerializeField] private bool _isAutoPlay;

		public Sequence Get
		{
			get => Instance;
		}
		
		public string ID { get => _ID; set => _ID = value; }
		public bool isAutoPlay { get => _isAutoPlay; set => _isAutoPlay = value; }

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
	}
}