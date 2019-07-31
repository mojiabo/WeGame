using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
namespace Framework
{
    public class ResourceComponent : BaseComponent, IUpdateComponent
    {
        /// <summary>
        /// 本地文件路径
        /// </summary>
        public string LocalFilePath;
        /// <summary>
        /// 资源管理器
        /// </summary>
        private ResourceManager m_ResourceManager;

        protected override void OnAwake()
        {
            base.OnAwake();

            m_ResourceManager = new ResourceManager();

#if DISABLE_ASSETBUNDLE && UNITY_EDITOR
             LocalFilePath = Application.dataPath;
#else
            LocalFilePath = Application.persistentDataPath;
#endif       
            GameEntry.RegisterUpdateComponent(this);
        }

        /// <summary>
        /// 初始化只读区资源包信息
        /// </summary>
        public void InitStreamingAssetsBundleInfo()
        {
            m_ResourceManager.InitStreamingAssetsBundleInfo();
        }

        public void OnUpdate()
        {
        }


        public override void Shutdown()
        {
            m_ResourceManager.Dispose();
        }
    }
}
