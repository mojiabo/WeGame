using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Framework
{
    public class PoolManager : ManagerBase, IDisposable
    {
        public ClassObjectPool ClassObjectPool
        {
            private set;
            get;
        }

        public GameObjectPool GameObjectPool
        {
            private set;
            get;
        }

        public PoolManager()
        {
            ClassObjectPool = new ClassObjectPool();
            GameObjectPool = new GameObjectPool();
        }

        /// <summary>
        /// 释放类对象池
        /// </summary>
        public void ClearClassObjectPool()
        {

            ClassObjectPool.Clear();
        }

        public void Dispose()
        {
            ClassObjectPool.Dispose();
            GameObjectPool.Dispose();
        }
    }
}
