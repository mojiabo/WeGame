using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class TimeComponent : BaseComponent,IUpdateComponent
    {

        protected override void OnAwake()
        {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);
        }
        public void OnUpdate()
        {
         //  Debug.Log(this.name+"OnUpdate");
        }
        public override void Shutdown()
        {
           // Debug.Log(this.name+"关闭组件");
        }
    }
}
