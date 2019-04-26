using System.Collections;
using System.Collections.Generic;
using System;
using Framework;

/// <summary>
/// Chapter数据管理
/// </summary>
public partial class ChapterDBModel : DataTableDBModelBase<ChapterDBModel, ChapterEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "Chapter"; } }

    /// <summary>
    /// 创建实体
    /// </summary>
    /// <param name="parse"></param>
    /// <returns></returns>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int colums = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            ChapterEntity entity = new ChapterEntity();
            entity.Id = ms.ReadInt();
            entity.ChapterName = ms.ReadUTF8String();
            entity.GameLevelCount = ms.ReadInt();
            entity.Uvx = ms.ReadFloat();
            entity.Uvy = ms.ReadFloat();
            m_List.Add(entity);
            m_dic[entity.Id] = entity;
        }
       
    }
}
