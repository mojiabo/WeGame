using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    /// <summary>
    /// 组件基类
    /// </summary>
    public abstract class BaseComponent : Component
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            GameEntry.RegisterBaseComponent(this);
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public abstract void Shutdown();
    }
}
