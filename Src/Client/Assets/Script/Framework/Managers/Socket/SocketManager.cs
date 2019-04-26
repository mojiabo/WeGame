using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class SocketManager : ManagerBase,IDisposable
    {
        /// <summary>
        /// SocketTCP访问器列表
        /// </summary>
        private LinkedList<SocketTcpRoutine> m_SocketTcpRoutineList;

        public SocketManager()
        {
            m_SocketTcpRoutineList = new LinkedList<SocketTcpRoutine>();
        }

        /// <summary>
        /// 注册SocketTcp访问器
        /// </summary>
        /// <param name="routine"></param>
        internal void RegisterSocketTcpRoutine(SocketTcpRoutine routine)
        {
            m_SocketTcpRoutineList.AddFirst(routine);
        }
        /// <summary>
        /// 移除SocketTcp访问器
        /// </summary>
        /// <param name="routine"></param>
        internal void RemoveSocketTcpRoutine(SocketTcpRoutine routine)
        {
            m_SocketTcpRoutineList.Remove(routine);
        }

        internal void OnUpdate()
        {
            for (LinkedListNode<SocketTcpRoutine> curr = m_SocketTcpRoutineList.First;curr!=null;curr= curr.Next)
            {
                curr.Value.OnUpdate();
            }
        }

        public void Dispose()
        {
            m_SocketTcpRoutineList.Clear();
        }
    }
}
