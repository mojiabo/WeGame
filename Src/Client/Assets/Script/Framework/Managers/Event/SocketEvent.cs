using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class SocketEvent : IDisposable
    {
        /// <summary>
        /// 委托原型
        /// </summary>
       // [CSharpCallLua]
        public delegate void OnActionHandle(byte[] buffer);

        private Dictionary<ushort, List<OnActionHandle>> dic = new Dictionary<ushort, List<OnActionHandle>>();

        #region 添加监听
        /// <summary>
        /// 添加监听
        /// </summary>
        /// <param name="protoCode"></param>
        /// <param name="handler"></param>
        public void AddEventListener(ushort key, OnActionHandle handler)
        {
            List<OnActionHandle> lstHandle = null;

            dic.TryGetValue(key, out lstHandle);

            if (lstHandle == null)
            {
                lstHandle = new List<OnActionHandle>();
                dic[key] = lstHandle;
            }
            lstHandle.Add(handler);
        }
        #endregion

        #region 移除监听
        /// <summary>
        /// 移除监听
        /// </summary>
        /// <param name="protoCode"></param>
        /// <param name="handler"></param>
        public void RemoveEventListener(ushort key, OnActionHandle handler)
        {
            List<OnActionHandle> lstHandle = null;

            dic.TryGetValue(key, out lstHandle);

            if (lstHandle != null)
            {
                lstHandle.Remove(handler);
                if (lstHandle.Count == 0)
                {
                    dic.Remove(key);
                }
            }
        }
        #endregion

        #region 派发
        /// <summary>
        /// 派发
        /// </summary>
        /// <param name="protoCode"></param>
        /// <param name="buffer"></param>
        public void Dispatch(ushort key, byte[] buffer)
        {
            List<OnActionHandle> lstHandle = null;

            dic.TryGetValue(key, out lstHandle);

            if (lstHandle != null)
            {
                int lstHandleCount = lstHandle.Count;
                for (int i = 0; i < lstHandleCount; i++)
                {
                    OnActionHandle handle = lstHandle[i];

                    if (handle != null && handle.Target != null)
                    {
                        handle(buffer);
                    }
                }
            }
        }

        public void Dispatch(ushort key)
        {
            Dispatch(key, null);
        }
        #endregion

        public void Dispose()
        {
            dic.Clear();
        }
    }
}
