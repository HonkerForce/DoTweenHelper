using DG.Tweening;

namespace DoTweenHelper
{
	public class CameraShakeMoveTween : CameraShakeTween
	{
		public override Tween CreateTween()
		{
			return target.DOShakePosition(duration, shakeRange, shakeNum, shakeRandom, isFadeOut, (ShakeRandomnessMode)randMode);
		}
	}
}