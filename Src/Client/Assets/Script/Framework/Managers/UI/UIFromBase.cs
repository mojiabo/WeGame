using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class UIFromBase : MonoBehaviour
    {
        /// <summary>
        /// 窗体编号
        /// </summary>
        public int UIFromId
        {
            get;
            private set;
        }

        /// <summary>
        /// 分组编号
        /// </summary>
        public byte UIGroupId
        {
            get;
            private set;
        }

        /// <summary>
        /// 当前的画布
        /// </summary>
        public Canvas CurrCanvas
        {
            get;
            private set;
        }

        /// <summary>
        /// 关闭时间
        /// </summary>
        public float CloseTime
        {
            get;
            private set;
        }

        /// <summary>
        /// 禁用层管理
        /// </summary>
        public bool DisabledUILayer
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool IsLock
        {
            get;
            private set;
        }

        /// <summary>
        /// 用户数据
        /// </summary>
        public object UserData
        {
            get;
            private set;
        }

        private void Awake()
        {
            CurrCanvas = GetComponent<Canvas>();

        }
        private void Start()
        {
            OnInit(UserData);
            Open(UserData,true);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="uiFromId"></param>
        /// <param name="groupId"></param>
        /// <param name="disabledUILayer"></param>
        /// <param name="isLock"></param>
        /// <param name="userData"></param>
        internal void Init(int uiFromId,byte groupId,bool disabledUILayer,bool isLock,object userData)
        {
            UIFromId = uiFromId;
            UIGroupId = groupId;
            DisabledUILayer = disabledUILayer;
            IsLock = isLock;
            UserData = userData;
           
        }

        internal void Open(object userData,bool isFromInit=false)
        {
            if (!isFromInit)
            {
                UserData = userData;
            }
           

            if (!DisabledUILayer)
            {
                //层级管理 增加层级
                GameEntry.UI.SetSortOrder(this,true);
            }
            OnOpen(UserData);
        }

        public void Close()
        {
            GameEntry.UI.CloseUIFrom(this);
        }

        public void ToClose()
        {
            if (!DisabledUILayer)
            {
                //层级管理 减少层级
                GameEntry.UI.SetSortOrder(this, false);
            }
            OnClose();

            CloseTime = Time.time;
            GameEntry.UI.Enqueue(this);
        }

        private void OnDestroy()
        {
            OnBeforeDestroy();
        }


        protected virtual void OnInit(object userData) { }
        protected virtual void OnOpen(object userData) { }
        protected virtual void OnClose() { }
        protected virtual void OnBeforeDestroy() { }
    }
}
