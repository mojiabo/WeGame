using System.Collections;
using Framework;

/// <summary>
/// GameLevelRegion实体
/// </summary>
public partial class GameLevelRegionEntity : DataTableEntityBase
{
    /// <summary>
    /// 游戏关卡Id
    /// </summary>
    public int GameLevelId;

    /// <summary>
    /// 区域Id
    /// </summary>
    public int RegionId;

    /// <summary>
    /// 初始化精灵
    /// </summary>
    public string InitSprite;

}
