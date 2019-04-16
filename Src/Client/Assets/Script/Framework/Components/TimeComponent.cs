using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class TimeComponent : Component,IUpdateComponent
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
    }
}
