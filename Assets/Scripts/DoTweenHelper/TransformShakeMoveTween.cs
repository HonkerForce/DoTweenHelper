using DG.Tweening;

namespace DoTweenHelper
{
	public class TransformShakeMoveTween : TransformShakeTween
	{
		public bool snapping;
		
		public override Tween CreateTween()
		{
			return target.DOShakePosition(duration, shakeRange, shakeNum, shakeRandom, snapping, isFadeOut, (ShakeRandomnessMode)randMode);
		}
	}
}