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

        /// <summary>
        /// 标准分辨率比值
        /// </summary>
        private float m_StandardScreen;
        /// <summary>
        /// 当前分辨率比值
        /// </summary>
        private float m_CurrScreen;

        [Header("UI分组")]
        [SerializeField]
        private UIGroup[] m_UIGroups;

        /// <summary>
        /// UI分组字典
        /// </summary>
        private Dictionary<byte, UIGroup> m_UIGroupDic;

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

        public void OnUpdate()
        {
           
        }
        public override void Shutdown()
        {

        }
    }
}
