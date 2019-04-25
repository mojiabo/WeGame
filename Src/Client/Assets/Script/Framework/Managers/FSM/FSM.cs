using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    /// <summary>
    /// 状态机
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FSM<T> : FSMBase where T :class
    {
        /// <summary>
        /// 当前状态
        /// </summary>
        private FSMState<T> m_CurrState;
        /// <summary>
        /// 状态字典
        /// </summary>
        private Dictionary<byte, FSMState<T>> m_StateDic;
        /// <summary>
        /// 参数字典
        /// </summary>
        private Dictionary<string, VariableBase> m_ParamDic;
        /// <summary>
        /// 构造函数
        /// </summary>
        public FSM(int fsmId,T owner, FSMState<T>[]status):base(fsmId)
        {
            m_StateDic = new Dictionary<byte, FSMState<T>>();
            m_ParamDic = new Dictionary<string, VariableBase>();

            int len = status.Length;

            for (int i = 0; i < len; i++)
            {
                FSMState<T> state = status[i];
                state.CurrFsm = this;
                m_StateDic[(byte)i] = state;
            }

            //设置默认状态
            CurrStateType = 0;

            m_CurrState = m_StateDic[CurrStateType];
        }

        public FSMState<T> GetState(byte staeteType)
        {
            FSMState<T> state = null;

            m_StateDic.TryGetValue(staeteType, out state);

            return state;
        }

        public void OnUpdate()
        {
            if (m_CurrState!=null)
            {
                m_CurrState.OnUpdate();
            }
        }

        /// <summary>
        /// 改变状态
        /// </summary>
        /// <param name="newState"></param>
        public void ChangeState(byte newState)
        {
            if (CurrStateType == newState)
            {
                return;
            }
            if (m_CurrState!=null)
            {
                m_CurrState.OnLeave();
            }

            CurrStateType = newState;

            m_CurrState = m_StateDic[CurrStateType];

            m_CurrState.OnEnter();
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetData<TData>(string key,TData value)
        {
            VariableBase itemBase = null;
            if (m_ParamDic.TryGetValue(key,out itemBase))
            {
                Debug.Log("修改已有值");
                Variable<TData>item=itemBase as Variable<TData>;
                item.Value = value;
                m_ParamDic[key] = item;
            }
            else
            {
                Debug.Log("实例化新对象");
                Variable<TData> item = new Variable<TData>();
                item.Value = value;
                m_ParamDic[key] = item;
            }
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TData GetData<TData>(string key)
        {
            VariableBase itemBase = null;
            if (m_ParamDic.TryGetValue(key, out itemBase))
            {
                Variable<TData> item = itemBase as Variable<TData>;
                return item.Value;
            }
            else
            {
                return default(TData);
            }
        }

        public override void ShutDown()
        {
            if (m_CurrState!=null)
            {
                m_CurrState.OnLeave();
            }
            foreach (KeyValuePair<byte,FSMState<T>> state in m_StateDic)
            {
                state.Value.OnDestroy();
            }
            m_StateDic.Clear();
        }
    }
}