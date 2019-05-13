using System.Collections;
using Framework;

/// <summary>
/// Message实体
/// </summary>
public partial class MessageEntity : DataTableEntityBase
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Msg;

    /// <summary>
    /// 使用的功能模块
    /// </summary>
    public string Module;

    /// <summary>
    /// 描述
    /// </summary>
    public string Description;

}
