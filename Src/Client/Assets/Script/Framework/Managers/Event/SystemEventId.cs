using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    /// <summary>
    /// 系统事件编号(采用四位 10001（10表示模块 01表示编号） )
    /// </summary>
    public class SystemEventId
    {
        /// <summary>
        /// 加载表格完毕
        /// </summary>
        public const ushort LoadDataTableCompelete = 1001;
        /// <summary>
        /// 加载单一表格完毕
        /// </summary>
        public const ushort LoadDataOneTableCompelete = 1002;
    }
}
