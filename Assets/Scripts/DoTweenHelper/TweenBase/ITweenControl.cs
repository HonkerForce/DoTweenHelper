using System.Threading.Tasks;

namespace DoTweenHelper
{
	public interface ITweenControl
	{
		/// <summary>
		/// 字符串ID
		/// </summary>
		string ID { get; set; }
		
		/// <summary>
		/// 是否自动播放
		/// </summary>
		bool isAutoPlay { get; set; }
		
		/// <summary>
		/// 是否递归播放所有子节点动效
		/// </summary>
		bool isPlayChildren { get; set; }
		
		/// <summary>
		/// 播放完成后是否自动重置(仅对非无限循环序列有效)
		/// </summary>
		bool isAutoRewind { get; set; }

		/// <summary>
		/// 播放当前节点下的所有动效
		/// </summary>
		void Play();

		/// <summary>
		/// 暂停当前播放序列
		/// </summary>
		void Pause();

		/// <summary>
		/// 停止播放，重置动效
		/// </summary>
		/// <param name="isRollback">是否回滚之前播放的动效</param>
		Task Stop(bool isRollback);

		/// <summary>
		/// 回滚当前节点下的动效
		/// </summary>
		Task Rollback();
	}
}