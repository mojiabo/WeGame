using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class PoolComponent : BaseComponent
    {
        private PoolManager m_PoolManager;

        protected override void OnAwake()
        {
            base.OnAwake();
            m_PoolManager = new PoolManager();
        }

        /// <summary>
        /// 取出一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Dequeue<T>() where T : class, new()
        {
           return m_PoolManager.ClassObjectPool.Dequeue<T>();
        }

        /// <summary>
        /// 对象回池
        /// </summary>
        public void Enqueue(object obj)
        {
            m_PoolManager.ClassObjectPool.Enqueue(obj);
        }

        public override void Shutdown()
        {
            m_PoolManager.Dispose();
        }
    }
}
