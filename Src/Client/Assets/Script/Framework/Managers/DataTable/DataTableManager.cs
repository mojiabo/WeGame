using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace Framework
{
    public class DataTableManager : ManagerBase
    {
        public DataTableManager()
        {
            InitDBModel();
        }

        /// <summary>
        /// 章表
        /// </summary>
        public ChapterDBModel ChapterDBModel
        {
            private set;
            get;
        }

        /// <summary>
        /// 系统UI表
        /// </summary>
        public Sys_UIFormDBModel Sys_UIFormDBModel
        {
            private set;
            get;
        }
        /// <summary>
        /// 本地化表
        /// </summary>
        public LocalizationDBModel LocalizationDBModel
        {
            private set;
            get;
        }

        /// <summary>
        /// 初始化DBModel
        /// </summary>
        private void InitDBModel()
        {
            LocalizationDBModel = new LocalizationDBModel();
            ChapterDBModel = new ChapterDBModel();
            Sys_UIFormDBModel = new Sys_UIFormDBModel();
        }

        /// <summary>
        /// 异步加载表格
        /// </summary>
        public void LoadDataTableAsync()
        {
            Task.Factory.StartNew(LoadDataTable);
        }

        /// <summary>
        /// 加载表格
        /// </summary>
        private void LoadDataTable()
        {
            ChapterDBModel.LoadData();
            Sys_UIFormDBModel.LoadData();
            LocalizationDBModel.LoadData();

            GameEntry.Event.CommonEvent.Dispatch(SystemEventId.LoadDataTableCompelete);
        }

        public void Clear()
        {
            ChapterDBModel.Clear();
            Sys_UIFormDBModel.Clear();
            LocalizationDBModel.Clear();
        }
    }
}
