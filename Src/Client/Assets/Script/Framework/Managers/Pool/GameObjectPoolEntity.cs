using PathologicalGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    /// <summary>
    /// 物体对象池实体类
    /// </summary>
    [System.Serializable]
    public class GameObjectPoolEntity
    {
        /// <summary>
        /// 对象池ID
        /// </summary>
        public byte PoolId;

        /// <summary>
        /// 对象池名字
        /// </summary>
        public string PoolName;
        /// <summary>
        /// 开启缓存池自动清理模式
        /// </summary>
        public bool CullDespawned = true;
        /// <summary>
        /// 缓存池自动清理 下保留不清除的数量
        /// </summary>
        public int CullAbove = 5;
        /// <summary>
        /// 清除间隔 （秒）
        /// </summary>
        public int CullDelay = 2;
        /// <summary>
        /// 每次清除的数量
        /// </summary>
        public int CullMaxPerPass = 2;
        /// <summary>
        /// 对应的游戏物体对象池
        /// </summary>
        public SpawnPool Pool;
 
    }
}
