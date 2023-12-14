using DG.Tweening;
using UnityEngine;

namespace DoTweenHelper
{
	[SerializeField]
	[RequireComponent(typeof(RectTransform))]
	public class RectTransformPivotTween : TweenAnimation<RectTransform, Vector2>
	{
		public override bool canPreview { get; } = true;

		public bool snapping;
		
		public override Tween CreateTween()
		{
			var ret = target.DOPivot(endValue, duration).SetOptions(snapping); 
			if (from)
			{
				ret = ret.From();
			}

			return ret;
		}
	}
}