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
        /// <summary>
        /// 类的对象在池中的数量
        /// </summary>
        public Dictionary<int, byte> ClassObjectCount
        {
            private set;
            get;
        }
        /// <summary>
        /// 类对象池字典
        /// </summary>
        private Dictionary<int, Queue<object>> m_ClassObjectPoolDic;
#if UNITY_EDITOR
        public Dictionary<Type,int> InspectorDic=new Dictionary<Type,int>();
#endif
        public ClassObjectPool()
        {
            m_ClassObjectPoolDic = new Dictionary<int, Queue<object>>();
            ClassObjectCount = new Dictionary<int, byte>();
        }

        /// <summary>
        /// 设置类的长度数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count"></param>
        public void SetClassObjectResideCount<T>(byte count) where  T :class
        {
            int key = typeof(T).GetHashCode();
            ClassObjectCount[key] = count;
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
                    object obj = queue.Dequeue();
#if UNITY_EDITOR
                    Type t = obj.GetType();
                    if (InspectorDic.ContainsKey(t))
                    {
                        InspectorDic[t]--;
                    }
                    else
                    {
                        InspectorDic[t] = 0;
                    }
#endif

                    Debug.Log("对象"+key+" 存在 从池中取");
                    return (T)obj;
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
                Type t=obj.GetType();
                if (InspectorDic.ContainsKey(t))
                {
                    InspectorDic[t]++;
                }
                else
                {
                    InspectorDic[t] = 1;
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
            lock (m_ClassObjectPoolDic)
            {
                Debug.Log("释放类的对象池");

                int queueCount = 0;
                var enumerator=m_ClassObjectPoolDic.GetEnumerator();

                while (enumerator.MoveNext())
                {
                    int key = enumerator.Current.Key;

                    Queue<object> queue = m_ClassObjectPoolDic[key];

#if UNITY_EDITOR
                    Type t = null;
#endif

                    queueCount = queue.Count;

                    byte resideCount = 0; //内存长度数量
                    ClassObjectCount.TryGetValue(key, out resideCount);

                    while (queueCount > resideCount)
                    {
                        queueCount--;
                        object obj = queue.Dequeue();//野指针

#if UNITY_EDITOR
                        t = obj.GetType();
                        InspectorDic[t]--;
#endif

                    }

                    if (queueCount == 0)
                    {
#if UNITY_EDITOR
                        if (t != null)
                        {
                            InspectorDic.Remove(t);
                        }
#endif
                    }


                }        
                GC.Collect();
            }        
        }

        public void Dispose()
        {
            m_ClassObjectPoolDic.Clear();
        }
    }
}
