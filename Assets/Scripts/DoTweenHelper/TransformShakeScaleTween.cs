using DG.Tweening;

namespace DoTweenHelper
{
	public class TransformShakeScaleTween : TransformShakeTween
	{
		public override Tween CreateTween()
		{
			return target.DOShakeScale(duration, shakeRange, shakeNum, shakeRandom, isFadeOut, (ShakeRandomnessMode)randMode);
		}
	}
}