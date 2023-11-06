namespace DoTweenHelper
{
	public interface ITweener : ITween
	{
		/// <summary>
		/// 是否设置在sequence中的播放位置(播放时刻)
		/// </summary>
		bool isInsertSequence { get; set; }
		
		/// <summary>
		/// 在Sequence中的播放位置(播放时刻)
		/// </summary>
		float insertSequencePos { get; set; }
	}
}