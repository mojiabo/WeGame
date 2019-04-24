using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public enum ProcedureState
    {
        Launch=0,
        CheckVersion=1,
        PreLoad=2,
        ChangeScene=3,
        LogOn=4,
        SelectRole=5,
        EnterGame=6,
        WorldMap=7,
        GameLevel=8,

    }

    /// <summary>
    /// 流程管理器
    /// </summary>
    public class ProcedureManager : ManagerBase, System.IDisposable
    {
        //流程状态机
        private FSM<ProcedureManager> m_CurrFSm;
        /// <summary>
        /// 当前得流程状态
        /// </summary>
        public ProcedureState CurrProcedureState
        {
            get { return (ProcedureState)m_CurrFSm.CurrStateType; }
        }
        /// <summary>
        /// 当前流程
        /// </summary>
        public FSMState<ProcedureManager> CurrProcedure
        {
            get { return m_CurrFSm.GetState(m_CurrFSm.CurrStateType); }
        }

        public ProcedureManager()
        {

        }

        /// <summary>
        /// 初始化流程状态机
        /// </summary>
        public void Init()
        {
            FSMState<ProcedureManager>[] states = new FSMState<ProcedureManager>[9];

            states[0] = new ProcedureLaunch();
            states[1] = new ProcedureCheckVersion();
            states[2] = new ProcedurePreLoad();
            states[3] = new ProcedureChangeScene();
            states[4] = new ProcedureLogOn();
            states[5] = new ProcedureSelectRole();
            states[6] = new ProcedureEnterGame();
            states[7] = new ProcedureWorldMap();
            states[8] = new ProcedureGameLevel();

            m_CurrFSm = GameEntry.FSM.CreateFSM<ProcedureManager>(this, states);

        }

        public void OnUpdate()
        {
            m_CurrFSm.OnUpdate();
        }

        /// <summary>
        /// 改变流程状态
        /// </summary>
        /// <param name="procedureState"></param>
        public void ChangeState(ProcedureState procedureState)
        {
            m_CurrFSm.ChangeState((byte)procedureState);
        }

        public void Dispose()
        {
            m_CurrFSm.ShutDown();
        }
    }
}
