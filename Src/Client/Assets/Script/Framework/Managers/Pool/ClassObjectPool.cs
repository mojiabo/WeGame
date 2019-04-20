using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    /// <summary>
    /// 类对象池
    /// </summary>
    public class ClassObjectPool:System.IDisposable
    {
        private Dictionary<int, Queue<object>> m_ClassObjectPool;

        public ClassObjectPool()
        {
            m_ClassObjectPool = new Dictionary<int, Queue<object>>();
        }

        /// <summary>
        /// 取出一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Dequeue<T>() where T : class,new()
        {
            lock (m_ClassObjectPool)
            {
                int key = typeof(T).GetHashCode();

                Queue <object> queue= null;
                m_ClassObjectPool.TryGetValue(key,out queue);

                if (queue==null)
                {
                    queue = new Queue<object>();
                    m_ClassObjectPool[key] = queue;
                }

                if (queue.Count>0)
                {
                    Debug.Log("对象"+key+" 存在 从池中取");
                    return (T)queue.Dequeue();
                }
                else
                {
                    Debug.Log("对象" + key + " 不存在 进行实例化");
                    return new T();
                }
            }

        }

        /// <summary>
        /// 对象回池
        /// </summary>
        public void Enqueue(object obj)
        {
            lock (this)
            {
                int key = obj.GetType().GetHashCode();

                Queue<object> queue = null;
                m_ClassObjectPool.TryGetValue(key, out queue);

                if (queue != null)
                {
                    Debug.Log("对象" + key + " 回池");
                    queue.Enqueue(obj);
                }
            }
           
        }

        public void Dispose()
        {
            m_ClassObjectPool.Clear();
        }
    }
}
