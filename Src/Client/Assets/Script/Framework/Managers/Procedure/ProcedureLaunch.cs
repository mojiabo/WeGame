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
            Debug.Log("ProcedureLaunch：OnEnter");

            string url = GameEntry.Http.RealWebAccountUrl + "/api/init";

            Dictionary<string, object> dic = GameEntry.Pool.DequeueClassObject<Dictionary<string, object>>();
            dic.Clear();

            GameEntry.Data.SystemDataManager.CurrChannelConfig.ChannelId = 0;
            GameEntry.Data.SystemDataManager.CurrChannelConfig.InnerVersion = 1001;

            dic["ChannelId"] = GameEntry.Data.SystemDataManager.CurrChannelConfig.ChannelId;
            dic["InnerVersion"] = GameEntry.Data.SystemDataManager.CurrChannelConfig.InnerVersion;
            GameEntry.Http.SendData(url, OnWebAccountInit, true, dic);
        }

        /// <summary>
        /// web回调
        /// </summary>
        /// <param name="args"></param>
        private void OnWebAccountInit(HttpCallBackArgs args)
        {
            if (!args.HasError)
            {
                LitJson.JsonData data = LitJson.JsonMapper.ToObject(args.Value);
                LitJson.JsonData config = LitJson.JsonMapper.ToObject(data["Value"].ToString());

                GameEntry.Data.SystemDataManager.CurrChannelConfig.ServerTime = long.Parse(config["ServerTime"].ToString());
                GameEntry.Data.SystemDataManager.CurrChannelConfig.SourceVersion = config["SourceVersion"].ToString();
                GameEntry.Data.SystemDataManager.CurrChannelConfig.SourceUrl = config["SourceUrl"].ToString();
                GameEntry.Data.SystemDataManager.CurrChannelConfig.RechargeUrl = config["RechargeUrl"].ToString();
                GameEntry.Data.SystemDataManager.CurrChannelConfig.TDAppId = config["TDAppId"].ToString();
                GameEntry.Data.SystemDataManager.CurrChannelConfig.IsOpenTD = int.Parse(config["IsOpenTD"].ToString()) == 1;

                Debug.Log("RechargeUrl" + GameEntry.Data.SystemDataManager.CurrChannelConfig.RechargeUrl);


                GameEntry.Procedure.ChangeState(ProcedureState.CheckVersion);
            }
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
