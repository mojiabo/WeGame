using System.Collections;
using Framework;

/// <summary>
/// Sys_Sound实体
/// </summary>
public partial class Sys_SoundEntity : DataTableEntityBase
{
    /// <summary>
    /// 描述
    /// </summary>
    public string Desc;

    /// <summary>
    /// 路径
    /// </summary>
    public string AssetPath;

    /// <summary>
    /// 是否3d声音
    /// </summary>
    public int Is3D;

    /// <summary>
    /// 音量（0-1）
    /// </summary>
    public float Volume;

}
