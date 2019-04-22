using System;
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
        private Dictionary<int, Queue<object>> m_ClassObjectPoolDic;
#if UNITY_EDITOR
        public Dictionary<string,int> InspectorDic=new Dictionary<string,int>();
#endif
        public ClassObjectPool()
        {
            m_ClassObjectPoolDic = new Dictionary<int, Queue<object>>();
        }

        /// <summary>
        /// 取出一个类的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T DequeueClassObjectPool<T>() where T : class,new()
        {
            lock (m_ClassObjectPoolDic)
            {
                int key = typeof(T).GetHashCode();

                Queue <object> queue= null;
                m_ClassObjectPoolDic.TryGetValue(key,out queue);

                if (queue==null)
                {
                    queue = new Queue<object>();
                    m_ClassObjectPoolDic[key] = queue;
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
        /// 类对象回池
        /// </summary>
        public void EnqueueClassObjectPool(object obj)
        {
            lock (m_ClassObjectPoolDic)
            {
                int key = obj.GetType().GetHashCode();

                Queue<object> queue = null;
                m_ClassObjectPoolDic.TryGetValue(key, out queue);

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

        /// <summary>
        /// 类的对象池释放
        /// </summary>
        public void Clear()
        {
            Debug.Log("释放对象池");

            List<int> lst = new List<int>(m_ClassObjectPoolDic.Keys);

            int lstCount = lst.Count;
            int queueCount = 0;

            for (int i = 0; i < lstCount; i++)
            {
                int key = lst[i];

                Queue<object> queue = m_ClassObjectPoolDic[key];

#if UNITY_EDITOR
                string className = string.Empty;   
#endif

                queueCount = queue.Count;
                while (queueCount>0)
                {
                    queueCount--;
                    object obj = queue.Dequeue();//野指针

#if UNITY_EDITOR
                    className = obj.GetType().Name;
                    InspectorDic[className]--;
#endif

                }

                if (queueCount==0)
                {
                    m_ClassObjectPoolDic[key] = null;
                    m_ClassObjectPoolDic.Remove(key);

#if UNITY_EDITOR
                    InspectorDic.Remove(className);
#endif
                }

            }

            GC.Collect();
        }

        public void Dispose()
        {
            m_ClassObjectPoolDic.Clear();
        }
    }
}
