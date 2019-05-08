using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class ProcedureCheckVersion : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
            GameEntry.Procedure.ChangeState(ProcedureState.PreLoad);
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
