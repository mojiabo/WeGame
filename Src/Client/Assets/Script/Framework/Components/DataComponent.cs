using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class DataComponent : BaseComponent
    {
        /// <summary>
        /// 临时缓存数据
        /// </summary>
        public CacheDataManager CacheData
        {
            private set;
            get;
        }
        /// <summary>
        /// 用户缓存数据
        /// </summary>
        public UserDataManager UserDataManager
        {
            private set;
            get;
        }
        /// <summary>
        /// 系统缓存数据
        /// </summary>
        public SystemDataManager SystemDataManager
        {
            private set;
            get;

        }
        /// <summary>
        /// 关卡缓存数据
        /// </summary>
        public PVEMapDataManager PVEMapDataManager
        {
            private set;
            get;
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            CacheData = new CacheDataManager();
            UserDataManager = new UserDataManager();
            SystemDataManager = new SystemDataManager();
            PVEMapDataManager = new PVEMapDataManager();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        public override void Shutdown()
        {
            CacheData.Dispose();
            UserDataManager.Dispose();
            SystemDataManager.Dispose();
            PVEMapDataManager.Dispose();
        }
    }
}
