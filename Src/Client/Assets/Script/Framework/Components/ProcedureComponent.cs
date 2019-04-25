using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class ProcedureComponent : BaseComponent,IUpdateComponent
    {
        private ProcedureManager m_ProcedureManager;

        protected override void OnAwake()
        {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);
            m_ProcedureManager = new ProcedureManager();
        }
        protected override void OnStart()
        {
            base.OnStart();
            m_ProcedureManager.Init();
        }
        /// <summary>
        /// 当前得流程状态
        /// </summary>
        public ProcedureState CurrProcedureState
        {
            get { return m_ProcedureManager.CurrProcedureState; }
        }
        /// <summary>
        /// 当前流程
        /// </summary>
        public FSMState<ProcedureManager> CurrProcedure
        {
            get { return m_ProcedureManager.CurrProcedure; }
        }


        /// <summary>
        /// 改变流程状态
        /// </summary>
        /// <param name="procedureState"></param>
        public void ChangeState(ProcedureState procedureState)
        {
            m_ProcedureManager.ChangeState(procedureState);
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetData<TData>(string key, TData value)
        {
            m_ProcedureManager.CurrFSm.SetData<TData>(key,value);
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TData GetData<TData>(string key)
        {
            return m_ProcedureManager.CurrFSm.GetData<TData>(key);
        }



        public void OnUpdate()
        {
            m_ProcedureManager.OnUpdate();
        }

        public override void Shutdown()
        {
            m_ProcedureManager.Dispose();
        }
    }
}
