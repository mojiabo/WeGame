using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace Framework
{
    public abstract class FSMBase
    {
        /// <summary>
        /// 状态机编号
        /// </summary>
        public int FSMId { private set; get; }
        /// <summary>
        /// 拥有者
        /// </summary>
        public Type Ower { private set; get; }
        /// <summary>
        /// 当前状态类型
        /// </summary>
        public byte CurrStateType;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fsmId"></param>
        public FSMBase(int fsmId)
        {
            FSMId = fsmId;
        }

        /// <summary>
        /// 关闭状态机
        /// </summary>
        public abstract void ShutDown();
    }
}
