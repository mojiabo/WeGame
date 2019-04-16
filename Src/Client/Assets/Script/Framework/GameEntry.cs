using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class GameEntry : MonoBehaviour
    {
        #region 组件属性
        /// <summary>
        /// 事件组件
        /// </summary>
        public static EventComponent Event
        {
            get;
            private set;
        }
        /// <summary>
        /// 数据组件
        /// </summary>
        public static DataComponent Data
        {
            get;
            private set;
        }
        /// <summary>
        /// 数据表组件
        /// </summary>
        public static DataTableComponent DataTable
        {
            get;
            private set;
        }
        /// <summary>
        /// 下载组件
        /// </summary>
        public static DownloadComponent Download
        {
            get;
            private set;
        }
        /// <summary>
        /// 状态机组件
        /// </summary>
        public static FSMComponent FSM
        {
            get;
            private set;
        }
        /// <summary>
        /// 游戏物体组件
        /// </summary>
        public static GameObjComponent GameObj
        {
            get;
            private set;
        }
        /// <summary>
        /// HTTP组件
        /// </summary>
        public static HttpComponent Http
        {
            get;
            private set;
        }
        /// <summary>
        /// 本地化组件
        /// </summary>
        public static LocalizationComponent Localization
        {
            get;
            private set;
        }

        /// <summary>
        /// 对象池组件
        /// </summary>
        public static PoolComponent Pool
        {
            get;
            private set;
        }
        /// <summary>
        /// 流程组件
        /// </summary>
        public static ProcedureComponent Procedure
        {
            get;
            private set;
        }
        /// <summary>
        /// 资源组件
        /// </summary>
        public static ResourceComponent Resource
        {
            get;
            private set;
        }
        /// <summary>
        /// 场景组件
        /// </summary>
        public static SceneComponent Scene
        {
            get;
            private set;
        }
        /// <summary>
        /// 设置组件
        /// </summary>
        public static SettingComponent Setting
        {
            get;
            private set;
        }
        /// <summary>
        /// Socket组件
        /// </summary>
        public static SocketComponent Socket
        {
            get;
            private set;
        }
        /// <summary>
        /// 计时器组件
        /// </summary>
        public static TimeComponent Time
        {
            get;
            private set;
        }
        /// <summary>
        /// 界面组件
        /// </summary>
        public static UIComponent UI
        {
            get;
            private set;
        }
        #endregion

        /// <summary>
        /// 基础组件列表
        /// </summary>
        private static LinkedList<Component> m_BaseComponentList = new LinkedList<Component>();

        #region 注册组件 RegisterBaseComponent
        /// <summary>
        /// 注册组件
        /// </summary>
        /// <param name="component"></param>
        internal static void RegisterBaseComponent(Component component)
        {
            Type type = component.GetType();

            LinkedListNode<Component> curr = m_BaseComponentList.First;
            while (curr!=null)
            {
                if (curr.Value.GetType()== type)
                {
                    return;
                }
                curr=curr.Next;
            }
            Debug.Log(type.Name+"注册到列表");
            m_BaseComponentList.AddLast(component);
        }
        #endregion

        #region 获取组件 GetBaseComponent
        internal static T GetBaseComponent<T>()where T : Component
        {
            return (T)GetBaseComponent(typeof(T));
        }
        /// <summary>
        /// 获取组件
        /// </summary>
        /// <param name="component"></param>
        internal static Component GetBaseComponent(Type type)
        {
            LinkedListNode<Component> curr = m_BaseComponentList.First;
            while (curr != null)
            {
                if (curr.Value.GetType() == type)
                {
                    Debug.Log(type.Name + "获取到列表");
                    return curr.Value;
                }
                curr = curr.Next;
            }
            
            return null;
        }
        #endregion

        private static void InitBaseComponents()
        {
            Event = GetBaseComponent<EventComponent>();
            Data = GetBaseComponent<DataComponent>();
            DataTable = GetBaseComponent<DataTableComponent>();
            Download = GetBaseComponent<DownloadComponent>();
            FSM = GetBaseComponent<FSMComponent>();
            GameObj = GetBaseComponent<GameObjComponent>();
            Http = GetBaseComponent<HttpComponent>();
            Localization = GetBaseComponent<LocalizationComponent>();
            Pool = GetBaseComponent<PoolComponent>();
            Procedure = GetBaseComponent<ProcedureComponent>();
            Resource = GetBaseComponent<ResourceComponent>();
            Scene = GetBaseComponent<SceneComponent>();
            Setting = GetBaseComponent<SettingComponent>();
            Socket = GetBaseComponent<SocketComponent>();
            Time = GetBaseComponent<TimeComponent>();
            UI = GetBaseComponent<UIComponent>();
        }

        void Start()
        {
            InitBaseComponents();
        }

        void Update()
        {

        }
    }
}

