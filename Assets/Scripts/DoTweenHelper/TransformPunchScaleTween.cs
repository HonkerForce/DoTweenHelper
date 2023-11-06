using DG.Tweening;

namespace DoTweenHelper
{
	public class TransformPunchScaleTween : TransformPunchTween
	{
		public override Tween CreateTween()
		{
			return target.DOPunchScale(endValue, duration, punchNum, inertia);
		}
	}
}