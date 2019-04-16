using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public interface IUpdateComponent
    {
        /// <summary>
        /// 更新方法
        /// </summary>
        void OnUpdate();

        /// <summary>
        /// 实例Id
        /// </summary>
       // int InstanceId { get; }
    }
}
