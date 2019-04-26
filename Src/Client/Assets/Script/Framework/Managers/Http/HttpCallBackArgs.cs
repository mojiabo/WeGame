using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    /// <summary>
    /// Http请求的回调数据
    /// </summary>
    public class HttpCallBackArgs : EventArgs
    {
        /// <summary>
        /// 是否报错
        /// </summary>
        public bool HasError;
        /// <summary>
        /// 返回数据
        /// </summary>
        public string Value;
    }
}
