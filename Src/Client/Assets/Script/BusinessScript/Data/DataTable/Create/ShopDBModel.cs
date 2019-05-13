using System.Collections;
using System.Collections.Generic;
using System;
using Framework;

/// <summary>
/// Shop数据管理
/// </summary>
public partial class ShopDBModel : DataTableDBModelBase<ShopDBModel, ShopEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    public override string DataTableName { get { return "Shop"; } }

    /// <summary>
    /// 加载列表
    /// </summary>
    protected override void LoadList(MMO_MemoryStream ms)
    {
        int rows = ms.ReadInt();
        int columns = ms.ReadInt();

        for (int i = 0; i < rows; i++)
        {
            ShopEntity entity = new ShopEntity();
            entity.Id = ms.ReadInt();
            entity.ShopCategoryId = ms.ReadInt();
            entity.GoodsType = ms.ReadInt();
            entity.GoodsId = ms.ReadInt();
            entity.OldPrice = ms.ReadInt();
            entity.Price = ms.ReadInt();
            entity.SellStatus = ms.ReadInt();

            m_List.Add(entity);
            m_Dic[entity.Id] = entity;
        }
    }
}