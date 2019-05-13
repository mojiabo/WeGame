using System.Collections;
using Framework;

/// <summary>
/// Chapter实体
/// </summary>
public partial class ChapterEntity : DataTableEntityBase
{
    /// <summary>
    /// 章名称
    /// </summary>
    public string ChapterName;

    /// <summary>
    /// 拥有关卡个数
    /// </summary>
    public int GameLevelCount;

    /// <summary>
    /// 背景图
    /// </summary>
    public string BG_Pic;

    /// <summary>
    /// Uvx
    /// </summary>
    public float Uvx;

    /// <summary>
    /// Uvy
    /// </summary>
    public float Uvy;

}
