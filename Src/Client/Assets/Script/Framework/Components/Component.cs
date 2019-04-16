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


        private void Awake()
        {
            GameEntry.RegisterBaseComponent(this);
            OnAwake();
        }

        protected virtual void OnAwake() { }

    }
}
