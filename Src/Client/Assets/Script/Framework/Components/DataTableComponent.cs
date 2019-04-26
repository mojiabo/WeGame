using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class DataTableComponent : BaseComponent
    {
        public DataTableManager DataTableManager
        {
            private set;
            get;
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            DataTableManager = new DataTableManager();

        }

        /// <summary>
        /// 异步加载表格
        /// </summary>
        public void LoadDataTableAsync()
        {
            DataTableManager.LoadDataTableAsync();
        }

        public override void Shutdown()
        {
           
        }
    }
}
