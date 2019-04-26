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
        public CacheData CacheData
        {
            private set;
            get;
        }
        /// <summary>
        /// 用户缓存数据
        /// </summary>
        public UserData UserData
        {
            private set;
            get;
        }
        /// <summary>
        /// 系统缓存数据
        /// </summary>
        public SystemData SystemData
        {
            private set;
            get;

        }
        /// <summary>
        /// 关卡缓存数据
        /// </summary>
        public PVEMapData PVEMapData
        {
            private set;
            get;
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            CacheData = new CacheData();
            UserData = new UserData();
            SystemData = new SystemData();
            PVEMapData = new PVEMapData();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        public override void Shutdown()
        {
            CacheData.Dispose();
            UserData.Dispose();
            SystemData.Dispose();
            PVEMapData.Dispose();
        }
    }
}
