﻿using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DoTweenHelper
{
	[Serializable]
	[RequireComponent(typeof(Text))]
	public class TextInputTween : TweenAnimation<Text, string>
	{
		public bool isRichText;
		
		/// <summary>
		/// 扰乱模式，动效播放中打乱字符的模式
		/// </summary>
		public ScrambleMode scrambleMode;

		/// <summary>
		/// 扰乱字符集资源
		/// </summary>
		public TextAsset scrambleText;
		
		public override Tween CreateTween()
		{
			return target.DOText(endValue, duration, isRichText, scrambleMode, scrambleText.text);
		}
	}
}