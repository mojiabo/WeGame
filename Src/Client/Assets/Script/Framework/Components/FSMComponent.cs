using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class FSMComponent : BaseComponent
    {
        private FSMManager m_FSMManager;

        private int m_TemFSMId;

        protected override void OnAwake()
        {
            base.OnAwake();
            m_FSMManager = new FSMManager();
        }


        /// <summary>
        /// 创建状态机
        /// </summary>
        /// <typeparam name="T">拥有者类型</typeparam>
        /// <param name="fsmId">状态机编号</param>
        /// <param name="owner">拥有者</param>
        /// <param name="status">状态数组</param>
        /// <returns></returns>
        public FSM<T> CreateFSM<T>(T owner, FSMState<T>[] status) where T : class
        {
            return  m_FSMManager.CreateFSM<T>(m_TemFSMId++,owner,status);
        }

        /// <summary>
        /// 销毁状态机
        /// </summary>
        /// <param name="fsmId"></param>
        public void DestoryFSM(int fsmId)
        {
             m_FSMManager.DestoryFSM(fsmId);
        }


        public override void Shutdown()
        {
            m_FSMManager.Dispose();
        }
    }
}
