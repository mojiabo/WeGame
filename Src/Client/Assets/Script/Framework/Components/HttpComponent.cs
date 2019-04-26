using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class HttpComponent : BaseComponent
    {
        [SerializeField]
        [Header("正式账号服务器url")]
        private string m_WebAccountUrl;

        [SerializeField]
        [Header("测试的账号服务器url")]
        private string m_TestWebAccountUrl;

        [SerializeField]
        [Header("是否测试环境")]
        private bool m_IsTest;

        /// <summary>
        /// 真实的服务器url
        /// </summary>
        public string RealWebAccountUrl
        {
            get { return m_IsTest ? m_TestWebAccountUrl : m_WebAccountUrl; }
        }

        private HttpManager m_HttpManager;

        protected override void OnAwake()
        {
            base.OnAwake();

            m_HttpManager = new HttpManager();
        }

        /// <summary>
        /// 发送Http数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="calBack"></param>
        /// <param name="isPost"></param>
        /// <param name="json"></param>
        public void SendData(string url, HttpSendDataCallBack calBack, bool isPost = false, Dictionary<string, object> dic = null)
        {

            m_HttpManager.SendData(url, calBack, isPost, dic);
        }

        public override void Shutdown()
        {

        }
    }
}
