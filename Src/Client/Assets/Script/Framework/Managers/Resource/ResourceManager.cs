using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class ResourceManager : ManagerBase
    {
        /// <summary>
        /// 根据字节数组获取资源包版本信息
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static Dictionary<string, AssetBundleInfoEntity> GetAssetBundleVersionList(byte[] buffer, ref string version)
        {
            buffer = ZlibHelper.DeCompressBytes(buffer);

            Dictionary<string, AssetBundleInfoEntity> dic = new Dictionary<string, AssetBundleInfoEntity>();

            MMO_MemoryStream ms = new MMO_MemoryStream(buffer);

            int len = ms.ReadInt();

            for (int i = 0; i < len; i++)
            {
                if (i == 0)
                {
                    version = ms.ReadUTF8String();
                }
                else
                {
                    AssetBundleInfoEntity enity = new AssetBundleInfoEntity();
                    enity.AssetBundleName = ms.ReadUTF8String();
                    enity.MD5 = ms.ReadUTF8String();
                    enity.Size = ms.ReadInt();
                    enity.IsFirstData = ms.ReadByte() == 1;
                    enity.IsEncrypt = ms.ReadByte() == 1;

                    dic[enity.AssetBundleName] = enity;
                }
            }
            return dic;

        }

        /// <summary>
        ///  StreamingAssets资源管理器
        /// </summary>
        public StreamingAssetsManager StreamingAssetsManager
        {
            get;
            private set;
        }


        public ResourceManager()
        {
            StreamingAssetsManager = new StreamingAssetsManager();
        }

        #region 只读区

        /// <summary>
        /// 只读区资源版本号
        /// </summary>
        private string m_StreamingAssetsVersion;

        /// <summary>
        /// 只读区资源包信息
        /// </summary>
        private Dictionary<string, AssetBundleInfoEntity> m_StreamingAssetsVersionDic;

        /// <summary>
        /// 初始化只读区资源包信息
        /// </summary>
        public void InitStreamingAssetsBundleInfo()
        {
            ReadStreamingAssetsBundle("VersionFile.bytes",(byte[] buffer)=>
            {

                m_StreamingAssetsVersionDic = GetAssetBundleVersionList(buffer,ref m_StreamingAssetsVersion);

            });
        }

        /// <summary>
        /// 读取只读区资源包信息
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <param name="onCompelete"></param>
        internal void ReadStreamingAssetsBundle(string fileUrl, Action<byte[]> onCompelete)
        {
            StreamingAssetsManager.ReadAssetBundle(fileUrl, onCompelete);
        }

        #endregion

        public void Dispose()
        {
            m_StreamingAssetsVersionDic.Clear();
        }
    }
}
