using System;
using UnityEngine;
using DG;
using DG.Tweening;

namespace DoTweenHelper
{
	[Serializable]
	public enum TweenLoopType
	{
		Replay = LoopType.Restart,
		Comeback = LoopType.Yoyo,
		Addition = LoopType.Incremental
	}

	public interface ITween
	{
		/// <summary>
		/// 动效ID（字符串）
		/// </summary>
		string ID { get; set; }
		
		/// <summary>
		/// 运行时间
		/// </summary>
		float duration { get; set; }

		/// <summary>
		/// 延迟调用的时间间隔
		/// </summary>
		float delay { get; set; }
		
		/// <summary>
		/// 是否循环
		/// </summary>
		bool isLoop { get; set; }

		/// <summary>
		/// 循环次数(-1为无限循环)
		/// </summary>
		int loopTimes { get; set; }
		
		/// <summary>
		/// 循环类型
		/// </summary>
		TweenLoopType loopType { get; set; }
		
		/// <summary>
		/// from动画
		/// </summary>
		bool from { get; set; }
		
		/// <summary>
		/// 是否在完成后杀死(杀死后被回收或者被销毁要看Recycle设置)
		/// Recycle设置可以在全局配置默认设置，也可以针对每个tween分别SetRecyclable
		/// </summary>
		bool isAutoKill { get; set; }
		
		/// <summary>
		/// 是否链接游戏对象
		/// </summary>
		bool isLinkGameobject { get; set; }
		
		/// <summary>
		/// 链接的行为类型
		/// </summary>
		LinkBehaviour linkActionType { get; set; }

		/// <summary>
		/// 链接的游戏对象引用
		/// </summary>
		GameObject linkGameobject { get; set; }
		
		Ease easeType { get; set; }
		
		bool canPreview { get; }

		/// <summary>
		/// 创建Tween
		/// </summary>
		Tween CreateTween();

		/// <summary>
		/// 附加设置，并运行动效
		/// </summary>
		Tween DoTween(bool isRollback = false);
	}
}