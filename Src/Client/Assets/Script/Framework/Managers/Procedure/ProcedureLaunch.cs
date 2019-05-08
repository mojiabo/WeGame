using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class ProcedureLaunch : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();

            string url = GameEntry.Http.RealWebAccountUrl + "/api/init";

            Dictionary<string, object> dic = GameEntry.Pool.DequeueClassObject<Dictionary<string, object>>();

            dic.Clear();
            dic["ChannelId"] = 0;

            GameEntry.Http.SendData(url,OnWebAccountInit,true,dic);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private void OnWebAccountInit(HttpCallBackArgs args)
        {
            Debug.Log("HasEror"+args.HasError);
            Debug.Log("Value"+args.Value);
            GameEntry.Procedure.ChangeState(ProcedureState.CheckVersion);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }

        public override void OnLeave()
        {
            base.OnLeave();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
