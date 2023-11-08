using DG.Tweening;

namespace DoTweenHelper
{
	/// <summary>
	/// 窗口动效：窗口创建时的，窗口尺寸从小变大
	/// </summary>
	public class WindowFromTween : TransformScaleTween
	{
		public override Tween CreateTween()
		{
			isFrom = true;

			return base.CreateTween();
		}
	}
}