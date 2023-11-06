using DG.Tweening;

namespace DoTweenHelper
{
	public class TransformShakeRotateTween : TransformShakeTween
	{
		public override Tween CreateTween()
		{
			return target.DOShakeRotation(duration, shakeRange, shakeNum, shakeRandom, isFadeOut, (ShakeRandomnessMode)randMode);
		}
	}
}