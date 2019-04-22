using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    /// <summary>
    /// 类对象池
    /// 使用注意事项
    /// 1.对象使用前必须初始化，或者回池前重置
    /// 2.对象不能使用带参数构造函数
    /// </summary>
    public class ClassObjectPool:System.IDisposable
    {
        private Dictionary<int, Queue<object>> m_ClassObjectPool;
#if UNITY_EDITOR
        public Dictionary<string,int> InspectorDic=new Dictionary<string,int>();
#endif
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
#if UNITY_EDITOR
                    string className = typeof(T).Name;
                    if (InspectorDic.ContainsKey(className))
                    {
                        InspectorDic[className]--;
                    }
                    else
                    {
                        InspectorDic[className] = 0;
                    }
#endif

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
            lock (m_ClassObjectPool)
            {
                int key = obj.GetType().GetHashCode();

                Queue<object> queue = null;
                m_ClassObjectPool.TryGetValue(key, out queue);

#if UNITY_EDITOR
                string className=obj.GetType().Name;
                if (InspectorDic.ContainsKey(className))
                {
                    InspectorDic[className]++;
                }
                else
                {
                    InspectorDic[className] = 1;
                }
#endif

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
