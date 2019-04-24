using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class FSMManager : ManagerBase,IDisposable
    {
        private Dictionary<int, FSMBase> m_FSMDic;

        public FSMManager()
        {
            m_FSMDic = new Dictionary<int, FSMBase>();
        }

        /// <summary>
        /// 创建状态机
        /// </summary>
        /// <typeparam name="T">拥有者类型</typeparam>
        /// <param name="fsmId">状态机编号</param>
        /// <param name="owner">拥有者</param>
        /// <param name="status">状态数组</param>
        /// <returns></returns>
        public FSM<T> CreateFSM<T>(int fsmId,T owner,FSMState<T>[]status)where T:class
        {
            FSM<T> fsm = new FSM<T>(fsmId,owner,status);
            m_FSMDic[fsmId] = fsm;
            return fsm;
        }

        /// <summary>
        /// 销毁状态机
        /// </summary>
        /// <param name="fsmId"></param>
        public void DestoryFSM(int fsmId)
        {
            FSMBase fsm = null;

            if (m_FSMDic.TryGetValue(fsmId,out fsm))
            {
                fsm.ShutDown();
                m_FSMDic.Remove(fsmId);
            }

        }

        public void Dispose()
        {
            foreach (KeyValuePair<int, FSMBase> fsm in m_FSMDic)
            {
                fsm.Value.ShutDown();
            }
            m_FSMDic.Clear();
        }
    }
}
