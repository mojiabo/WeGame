using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    /// <summary>
    /// 资源包信息实体
    /// </summary>
    public class AssetBundleInfoEntity
    {
        /// <summary>
        /// 资源包名称
        /// </summary>
        public string AssetBundleName;
        /// <summary>
        /// MD5
        /// </summary>
        public string MD5;
        /// <summary>
        /// 大小（k）
        /// </summary>
        public int Size;
        /// <summary>
        /// 是否初始资源
        /// </summary>
        public bool IsFirstData;
        /// <summary>
        /// 是否已经加密
        /// </summary>
        public bool IsEncrypt;
    }
}
