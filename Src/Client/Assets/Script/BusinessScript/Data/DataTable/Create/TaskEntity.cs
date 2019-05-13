using System.Collections;
using Framework;

/// <summary>
/// Task实体
/// </summary>
public partial class TaskEntity : DataTableEntityBase
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name;

    /// <summary>
    /// 状态
    /// </summary>
    public int Status;

    /// <summary>
    /// 内容
    /// </summary>
    public string Content;

}
