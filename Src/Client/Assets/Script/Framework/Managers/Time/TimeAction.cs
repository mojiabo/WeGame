using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
	/// <summary>
	/// 定时器
	/// </summary>
	public class TimeAction
	{
		/// <summary>
		/// 是否运行中
		/// </summary>
		public bool IsRuning
		{
			private set;
			get;
		}

		/// <summary>
		/// 当前运行时间
		/// </summary>
		private float m_CurrRunTime;

		/// <summary>
		/// 当前循环次数
		/// </summary>
		private int m_CurrLoop;

		/// <summary>
		/// 延迟时间
		/// </summary>
		private float m_DelayTime;

		/// <summary>
		/// 间隔(秒)
		/// </summary>
		private float m_Interval;

		/// <summary>
		/// 循环次数(-1表示无限循环，0是一次 1以上就是多少次)
		/// </summary>
		private int m_Loop;

		/// <summary>
		/// 开始运行
		/// </summary>
		private Action m_OnStart;

		/// <summary>
		/// 运行中 参数代表剩余次数
		/// </summary>
		private Action<int> m_OnUpdate;

		/// <summary>
		/// 运行完毕
		/// </summary>
		private Action m_OnComplete;

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="delayTime"></param>
		/// <param name="interval"></param>
		/// <param name="loop"></param>
		/// <param name="onStart"></param>
		/// <param name="onUpdate"></param>
		/// <param name="onComplete"></param>
		/// <returns></returns>
		public TimeAction Init(float delayTime, float interval, int loop, Action onStart, Action<int> onUpdate, Action onComplete)
		{
			m_DelayTime = delayTime;
			m_Interval = interval;
			m_Loop = loop;
			m_OnStart = onStart;
			m_OnUpdate = onUpdate;
			m_OnComplete = onComplete;

			return this;
		}

		/// <summary>
		/// 运行
		/// </summary>
		public void Run()
		{
			//注册定时器
			GameEntry.Time.RegisterTimeAction(this);

			//设置当前运行时间
			m_CurrRunTime = Time.time;

		}

		/// <summary>
		/// 暂停
		/// </summary>
		public void Pause()
		{
			IsRuning = false;
		}

		/// <summary>
		/// 停止
		/// </summary>
		public void Stop()
		{
			if (m_OnComplete!=null)
			{
				m_OnComplete();
			}

			IsRuning = false;

			GameEntry.Time.RemoveTimeAction(this);
		}

		public void OnUpdate()
		{
			if (!IsRuning&&Time.time>m_CurrRunTime+m_DelayTime)
			{
				IsRuning = true;
				m_CurrRunTime = Time.time;
				if (m_OnStart!=null)
				{
					m_OnStart();
				}
			}

			if (!IsRuning)
			{
				return;
			}

			if (Time.time>m_CurrRunTime)
			{
				m_CurrRunTime = Time.time + m_Interval;

				if (m_OnUpdate!=null)
				{
					m_OnUpdate(m_Loop-m_CurrLoop);
				}

				if (m_Loop>-1)
				{
					m_CurrLoop++;
					if (m_CurrLoop>=m_Loop)
					{
						Stop();
					}
				}
			}
		}
	}
}
