using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class ProcedurePreLoad : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Event.CommonEvent.AddEventListener(SystemEventId.LoadDataTableCompelete, OnLoadDataTableCompelete);
            GameEntry.Event.CommonEvent.AddEventListener(SystemEventId.LoadDataOneTableCompelete, OnLoadDataOneTableCompelete);

            GameEntry.DataTable.LoadDataTableAsync();
        }
   
        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Event.CommonEvent.RemoveEventListener(SystemEventId.LoadDataTableCompelete, OnLoadDataTableCompelete);
            GameEntry.Event.CommonEvent.RemoveEventListener(SystemEventId.LoadDataOneTableCompelete, OnLoadDataOneTableCompelete);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        /// <summary>
        /// 加载单一表完毕
        /// </summary>
        /// <param name="userData"></param>
        private void OnLoadDataOneTableCompelete(object userData)
        {
            Debug.Log("加载"+ userData+"表完毕");
        }

        /// <summary>
        /// 加载所有表完毕
        /// </summary>
        /// <param name="userData"></param>
        private void OnLoadDataTableCompelete(object userData)
        {
            Debug.Log("加载所有表完毕");

            List<ChapterEntity> entity = GameEntry.DataTable.DataTableManager.ChapterDBModel.GetList();

            for (int i = 0; i < entity.Count; i++)
            {
                Debug.Log(entity[i].Id);
                Debug.Log(entity[i].ChapterName);
            }
        }

    }
}
