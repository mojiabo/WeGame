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
            GameEntry.RegisterBaseComponent(this);
            OnAwake();
        }

        public int InstaceId
        {
            get { return m_InStanceId; }
        }

        protected virtual void OnAwake() { }

    }
}
