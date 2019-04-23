using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class PoolComponent : BaseComponent,IUpdateComponent
    {
        public PoolManager PoolManager
        {
            private set;
            get;
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            PoolManager = new PoolManager();
            GameEntry.RegisterUpdateComponent(this);
            m_NextRunTime = Time.time;
            InitGameObjectPool();
        }

        public override void Shutdown()
        {
            PoolManager.Dispose();
        }

        /// <summary>
        ///释放时间间隔 
        /// </summary>
        [SerializeField]
        public int m_ClearInterval = 30;
        /// <summary>
        /// 下次运行时间
        /// </summary>
        private float m_NextRunTime;

        public void OnUpdate()
        {
            if (Time.time> m_NextRunTime+ m_ClearInterval)
            {
                m_NextRunTime = Time.time;

                PoolManager.ClearClassObjectPool();
            }
        }

        #region 类的对象池
        /// <summary>
        /// 设置类的常驻数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count"></param>
        public void SetClassObjectResideCount<T>(byte count) where T : class
        {
            PoolManager.ClassObjectPool.SetClassObjectResideCount<T>(count);
        }

        /// <summary>
        /// 取出一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Dequeue<T>() where T : class, new()
        {
            return PoolManager.ClassObjectPool.DequeueClassObjectPool<T>();
        }

        /// <summary>
        /// 对象回池
        /// </summary>
        public void Enqueue(object obj)
        {
            PoolManager.ClassObjectPool.EnqueueClassObjectPool(obj);
        }
        #endregion

        #region 游戏物体对象池
        /// <summary>
        /// 对象池分组
        /// </summary>
        [SerializeField]
        private GameObjectPoolEntity[] m_GameObjectPoolGroups;

        /// <summary>
        /// 初始化游戏物体对象池
        /// </summary>
        public void InitGameObjectPool()
        {
            StartCoroutine(PoolManager.GameObjectPool.Init(m_GameObjectPoolGroups,transform));
        }

        /// <summary>
        /// 从对象池中获取对象
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="transform"></param>
        /// <param name="OnCompelete"></param>
        public void GameObjectSpawn(byte poolId, Transform prefab,System.Action<Transform> OnCompelete)
        {
            PoolManager.GameObjectPool.Spawn(poolId,prefab,OnCompelete);
        }
        /// <summary>
        /// 对象回池
        /// </summary>
        /// <param name="poolId"></param>
        /// <param name="instance"></param>
        public void GameObjectDespawn(byte poolId, Transform instance)
        {
            PoolManager.GameObjectPool.Despawn(poolId, instance);
        }
            #endregion

        }
}
