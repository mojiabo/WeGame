using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public enum Language
    {
        Chinese=0,
        English=1,
    }

    public class LocalizationComponent : BaseComponent
    {
        [SerializeField]
        private Language m_CurrLanguage;
        /// <summary>
        /// 当前语言要和表的字段一致
        /// </summary>
        public Language CurrLanguage
        {
            get { return m_CurrLanguage; }
         
        }

        private LocalizationManager m_LocalizationManager;

        protected override void OnAwake()
        {
            base.OnAwake();
            m_LocalizationManager = new LocalizationManager();
#if !UNITY_EDITOR
              Init();
#endif

        }

        private void Init()
        {
            switch (Application.systemLanguage)
            {
                default:
                case SystemLanguage.ChineseSimplified:
                case SystemLanguage.ChineseTraditional:
                case SystemLanguage.Chinese:
                    m_CurrLanguage = Language.Chinese;
                    break;
                case SystemLanguage.English:
                    m_CurrLanguage = Language.English;
                    break;
            }
        }

        /// <summary>
        /// 获取本地化内容
        /// </summary>
        /// <param name="key"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public string GetString(string key, params object[] args)
        {
           return m_LocalizationManager.GetString(key, args);
        }


        public override void Shutdown()
        {

        }
    }
}
