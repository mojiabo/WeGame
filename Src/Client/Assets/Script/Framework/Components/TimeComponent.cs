using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
	public class TimeComponent : BaseComponent,IUpdateComponent
	{
		protected override void OnAwake()
		{
			base.OnAwake();
			GameEntry.RegisterUpdateComponent(this);
			TimeManager = new TimeManager();
		}

		#region 定时器相关
		private TimeManager TimeManager;

		/// <summary>
		/// 创建定时器
		/// </summary>
		/// <returns></returns>
		public TimeAction CreateTimeAction()
		{
			return new TimeAction();
		}

		/// <summary>
		/// 注册定时器
		/// </summary>
		/// <param name="timeAction"></param>
		internal void RegisterTimeAction(TimeAction timeAction)
		{
			TimeManager.RegisterTimeAction(timeAction);
		}

		/// <summary>
		/// 移除定时器
		/// </summary>
		/// <param name="timeAction"></param>
		internal void RemoveTimeAction(TimeAction timeAction)
		{
			TimeManager.RemoveTimeAction(timeAction);
		}
		#endregion

		public void OnUpdate()
		{
			TimeManager.OnUpdate();
		}
		public override void Shutdown()
		{
			TimeManager.Dispose();
		}
	}
}
