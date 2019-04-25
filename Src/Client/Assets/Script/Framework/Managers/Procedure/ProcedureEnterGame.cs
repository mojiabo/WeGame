using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class ProcedureEnterGame : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("ProcedureEnterGame-->OnEnter");
            string name = GameEntry.Procedure.GetData<string>("Name");
            int code = GameEntry.Procedure.GetData<int>("Code");
            Debug.Log("Name=="+name);
            Debug.Log("Code==" + code);
           
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
