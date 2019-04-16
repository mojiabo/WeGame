using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class TestEvent : MonoBehaviour
    {


        void Start()
        {
            GameEntry.Event.CommonEvent.AddEventListener(CommonEventId.RegComplete,TestCallBack);
        }

        private void TestCallBack(object userData)
        {
            Debug.Log("TestEvent=="+ userData);
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                GameEntry.Event.CommonEvent.Dispatch(CommonEventId.RegComplete,123);
            }
        }
        private void OnDestroy()
        {
            GameEntry.Event.CommonEvent.RemoveEventListener(CommonEventId.RegComplete, TestCallBack);
        }
    }
}
