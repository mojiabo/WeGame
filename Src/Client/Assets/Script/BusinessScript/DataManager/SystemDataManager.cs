using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 系统数据（游戏周期内可以不清空）
/// </summary>
public class SystemDataManager : IDisposable
{
    /// <summary>
    /// 当前服务器时间
    /// </summary>
    public long CurrServerTime;

    /// <summary>
    /// 当前渠道配置
    /// </summary>
    public ChannelInitConfigEntity CurrChannelConfig
    {
        get;
        private set;
    }
    public SystemDataManager()
    {
        CurrChannelConfig = new ChannelInitConfigEntity();
    }
    /// <summary>
    /// 清空数据
    /// </summary>
    public void Clear()
    {

    }

    public void Dispose()
    {

    }
}
