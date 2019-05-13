using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用户数据 （退出登录清空）
/// </summary>
public class UserDataManager : IDisposable
{
    /// <summary>
    /// 服务器返回的人物列表
    /// </summary>
    public List<ServerTaskEntity> m_ServerTaskList
    {
        get;
        private set;
    }

    public UserDataManager()
    {
        m_ServerTaskList = new List<ServerTaskEntity>();
    }
    /// <summary>
    /// 清空数据
    /// </summary>
    public void Clear()
    {
        m_ServerTaskList.Clear();
    }

    public void Dispose()
    {
        m_ServerTaskList.Clear();
    }

    /// <summary>
    /// 接受任务消息
    /// </summary>
    /// <param name="proto"></param>
    public void ReceiveTask(Task_SearchTaskReturnProto proto)
    {
        int len = proto.CurrTaskItemList.Count;

        for (int i = 0; i < len; i++)
        {
            Task_SearchTaskReturnProto.TaskItem taskItem = proto.CurrTaskItemList[i];

            m_ServerTaskList.Add(new ServerTaskEntity() {Id=taskItem.Id,Status=taskItem.Status });

        }
    }
}
