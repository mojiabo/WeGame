using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class ResourceComponent : Component, IUpdateComponent
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);
        }
        public void OnUpdate()
        {
           
        }
    }
}
