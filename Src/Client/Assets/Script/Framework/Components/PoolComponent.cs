using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class PoolComponent : BaseComponent
    {
        public PoolManager PoolManager
        {
            private set;
            get;
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            PoolManager = new PoolManager();
        }

        /// <summary>
        /// 取出一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Dequeue<T>() where T : class, new()
        {
           return PoolManager.ClassObjectPool.Dequeue<T>();
        }

        /// <summary>
        /// 对象回池
        /// </summary>
        public void Enqueue(object obj)
        {
            PoolManager.ClassObjectPool.Enqueue(obj);
        }

        public override void Shutdown()
        {
            PoolManager.Dispose();
        }
    }
}
