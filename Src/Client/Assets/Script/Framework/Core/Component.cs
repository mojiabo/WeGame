using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    /// <summary>
    /// 组件基类
    /// </summary>
    public class Component : MonoBehaviour
    {
        private int m_InStanceId;

        private void Awake()
        {
            m_InStanceId = GetInstanceID();
            OnAwake();
        }
        /// <summary>
        /// 组件实例编号
        /// </summary>
        public int InstaceId
        {
            get { return m_InStanceId; }
        }

        protected virtual void OnAwake() { }

    }
}
