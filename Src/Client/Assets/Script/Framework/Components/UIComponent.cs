using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Framework
{
    public class UIComponent : BaseComponent, IUpdateComponent
    {
        [Header("标准分辨率宽度")]
        [SerializeField]
        private int m_StandardWight = 1280;

        [Header("标准分辨率高度")]
        [SerializeField]
        private int m_StandardHight = 720;

        [Header("UI摄像机")]
        public Camera UICamera;

        [Header("根画布的缩放")]
        [SerializeField]
        private CanvasScaler m_UICanvasScaler;

        [Header("根画布")]
        [SerializeField]
        private Canvas m_UIRootCanvas;

        [Header("UI分组")]
        [SerializeField]
        private UIGroup[] m_UIGroups;

        /// <summary>
        /// 标准分辨率比值
        /// </summary>
        private float m_StandardScreen;
        /// <summary>
        /// 当前分辨率比值
        /// </summary>
        private float m_CurrScreen;
        /// <summary>
        /// UI分组字典
        /// </summary>
        private Dictionary<byte, UIGroup> m_UIGroupDic;

        private UIManager m_UIManager;
        private UILayer m_UILayer;
        private UIPool m_UIPool;

        [Header("释放间隔")]
        [SerializeField]
        private float m_ClearInterval = 120;

        /// <summary>
        /// 下次运行时间
        /// </summary>
        private float m_NextRunTime=0;

        /// <summary>
        /// UI回池过期时间
        /// </summary>
        public float UIExpire=120;

        /// <summary>
        /// 对象池中最大数量
        /// </summary>
        public int UIPoolMaxCount=5;

        protected override void OnAwake()
        {
            base.OnAwake();

            GameEntry.RegisterUpdateComponent(this);

            float m_StandardScreen = m_StandardWight / (float)m_StandardHight;
            float m_CurrScreen = Screen.width / (float)Screen.height;
            NormalFromCanvasScaler();
            m_UIGroupDic = new Dictionary<byte, UIGroup>();
            int len = m_UIGroups.Length;

            for (int i = 0; i < len; i++)
            {
                UIGroup uIGroup = m_UIGroups[i];
                m_UIGroupDic[uIGroup.Id] = uIGroup;
            }

            m_UIManager = new UIManager();
            m_UILayer = new UILayer();
            m_UIPool = new UIPool();
            m_UILayer.Init(m_UIGroups);
        }

        /// <summary>
        /// 获取UI分组
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UIGroup GetUIGroup(byte id)
        {
            UIGroup uIGroup = null;
            m_UIGroupDic.TryGetValue(id, out uIGroup);
            return uIGroup;
        }


        /// <summary>
        /// 设置层级
        /// </summary>
        /// <param name="fromBase"></param>
        /// <param name="isAdd"></param>
        public void SetSortOrder(UIFormBase fromBase, bool isAdd)
        {
            m_UILayer.SetSortOrder(fromBase,isAdd);
       
        }

        #region UI适配
        /// <summary>
        /// 适配LoadingFrom缩放
        /// </summary>
        public void LoadingFromCanvasScaler()
        {
            if (m_CurrScreen > m_StandardScreen)
            {
                m_UICanvasScaler.matchWidthOrHeight = 0;
            }
            else
            {
                m_UICanvasScaler.matchWidthOrHeight = m_StandardScreen - m_CurrScreen;
            }
        }
        /// <summary>
        /// 全屏适配缩放
        /// </summary>
        public void FullFromCanvasScaler()
        {
            m_UICanvasScaler.matchWidthOrHeight = 1;
        }

        /// <summary>
        /// 普通窗口适配缩放
        /// </summary>
        public void NormalFromCanvasScaler()
        {
            m_UICanvasScaler.matchWidthOrHeight = (m_CurrScreen>= m_StandardScreen)?1:0;
        }
        #endregion

        /// <summary>
        /// 打开一个窗体
        /// </summary>
        /// <param name="uIFromId">ID</param>
        /// <param name="userData">用户数据</param>
        public void OpenUIFrom(int uIFromId, object userData = null)
        {
            m_UIPool.CheackOpenUI();
            m_UIManager.OpenUIForm(uIFromId, userData);
        }
        /// <summary>
        /// 关闭UI窗口
        /// </summary>
        /// <param name="fromBase"></param>
        internal void CloseUIFrom(UIFormBase fromBase)
        {
            m_UIManager.CloseUIForm(fromBase);
        }

        /// <summary>
        /// UI对象池中获取对象
        /// </summary>
        /// <param name="uiFromId"></param>
        /// <returns></returns>
        internal UIFormBase Dequeue(int uiFromId)
        {
           return m_UIPool.Dequeue(uiFromId);
        }

        /// <summary>
        /// UI回池
        /// </summary>
        /// <param name="uIFrom"></param>
        internal void Enqueue(UIFormBase uIFrom)
        {
            m_UIPool.Enqueue(uIFrom);
        }

        public void OnUpdate()
        {
            if (Time.time>m_NextRunTime+m_ClearInterval)
            {
                m_NextRunTime = Time.time;

                m_UIPool.CheckClear();
            }
        }
        public override void Shutdown()
        {

        }
    }
}
