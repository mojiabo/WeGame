using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelInitConfigEntity
{
    /// <summary>
    /// 渠道号
    /// </summary>
    public short ChannelId;
    /// <summary>
    /// 内部版本号
    /// </summary>
    public short InnerVersion;
    /// <summary>
    ///账号服务器时间
    /// </summary>
    public long ServerTime;
    /// <summary>
    /// 资源版本号
    /// </summary>
    public string SourceVersion;
    /// <summary>
    /// 资源地址
    /// </summary>
    public string SourceUrl;
    /// <summary>
    ///充值回调地址
    /// </summary>
    public string RechargeUrl;
    /// <summary>
    /// TD统计账号
    /// </summary>
    public string TDAppId;
    /// <summary>
    /// 是否开启TD统计
    /// </summary>
    public bool IsOpenTD;
    /// <summary>
    /// 充值服务器识别码
    /// </summary>
    public string PayServerNo;

    /// <summary>
    /// 真实的资源地址
    /// </summary>
    private string m_RealSourceUrl;
    /// <summary>
    /// 真实的资源地址
    /// </summary>
    public string RealSourceUr
    {
        get
        {
            if (string.IsNullOrEmpty(m_RealSourceUrl))
            {
                string buildTarget = string.Empty;

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
                buildTarget = "Windows";
#elif UNITY_ANDROID
                buildTarget = "Android";
#elif UNITY_IPHONE
                buildTarget = "iOS";
#endif
                m_RealSourceUrl = string.Format("{0}{1}/{2}/",SourceUrl, SourceVersion, buildTarget);
            }
            return m_RealSourceUrl;
        }
    }

}
