using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class TestTime : MonoBehaviour
    {


        void Start()
        {
    
        }



        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                TimeAction timeAction = GameEntry.Time.CreateTimeAction();
                timeAction.Init(1, 1, 8,()=> 
                {
                    Debug.Log("定时器开始");
                },(int loop)=>
                {
                    Debug.Log("定时剩余循环次数="+loop);
                },()=> 
                {
                    Debug.Log("定时完毕");
                }).Run();
            }
        }

    }
}
