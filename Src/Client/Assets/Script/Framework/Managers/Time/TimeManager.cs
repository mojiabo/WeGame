using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
	public class TimeManager : ManagerBase,IDisposable
	{

		private LinkedList<TimeAction> m_TimeActionList;

		public TimeManager()
		{
			m_TimeActionList = new LinkedList<TimeAction>();
		}

		/// <summary>
		/// 注册定时器
		/// </summary>
		/// <param name="timeAction"></param>
		internal void RegisterTimeAction(TimeAction timeAction)
		{
			m_TimeActionList.AddLast(timeAction);
		}

		/// <summary>
		/// 移除定时器
		/// </summary>
		/// <param name="timeAction"></param>
		internal void RemoveTimeAction(TimeAction timeAction)
		{
			m_TimeActionList.Remove(timeAction);
		}

		internal void OnUpdate()
		{
			for (LinkedListNode<TimeAction>curr= m_TimeActionList.First; curr!=null; curr= curr.Next)
			{
				curr.Value.OnUpdate();
			}
		}

		public void Dispose()
		{
			m_TimeActionList.Clear();
		}
	}
}
