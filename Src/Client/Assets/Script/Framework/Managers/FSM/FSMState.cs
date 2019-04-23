using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    /// <summary>
    /// 状态机状态
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FSMState<T> where T : class
    {
        /// <summary>
        /// 对应的状态机
        /// </summary>
        public FSM<T> CurrFsm;


        /// <summary>
        /// 进入状态机
        /// </summary>
        public virtual void OnEnter() { }

        /// <summary>
        /// 更新状态机
        /// </summary>
        public virtual void OnUpdate() { }

        /// <summary>
        /// 离开状态机
        /// </summary>
        public virtual void OnLeave() { }

        /// <summary>
        /// 销毁状态机
        /// </summary>
        public virtual void OnDestroy() { }
    }
}
