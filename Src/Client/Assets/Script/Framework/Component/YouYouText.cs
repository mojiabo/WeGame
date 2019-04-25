using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Framework
{
    public class YouYouText : Text
    {
        [Header("本地化语言Key")]
        [SerializeField]
        private string m_Localization;

        protected override void Start()
        {
            base.Start();
            //if (GameEntry.Localization != null)
            //{
            //    text = GameEntry.Localization.GetString(m_Localization);
            //}
        }
    }
}