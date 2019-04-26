using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class HttpManager : ManagerBase
    {
        /// <summary>
        /// 发送Http数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="calBack"></param>
        /// <param name="isPost"></param>
        /// <param name="json"></param>
        public void SendData(string url, HttpSendDataCallBack calBack, bool isPost = false, Dictionary<string, object> dic = null)
        {
            HttpRoutine http=GameEntry.Pool.DequeueClassObject<HttpRoutine>();
            http.SendData( url,calBack,isPost,dic);

        }

    }
}
