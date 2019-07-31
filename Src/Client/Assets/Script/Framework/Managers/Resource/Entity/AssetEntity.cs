using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    /// <summary>
    /// 资源实体
    /// </summary>
    public class AssetEntity
    {
        /// <summary>
        /// 资源分类
        /// </summary>
        public AssetCategory Category;
        /// <summary>
        /// 资源实体
        /// </summary>
        public string AssetName;
        /// <summary>
        /// 资源完整名称
        /// </summary>
        public string AssetFullName;

        /// <summary>
        /// 所属资源包（这个资源在那个资源包里）
        /// </summary>
        public string AssetBundleName;
        /// <summary>
        /// 依赖资源
        /// </summary>
        public List<AssetDependsEntity> DependsAssetList;

    }
}
