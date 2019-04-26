using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;
public class TestProcedure : MonoBehaviour {

	// Use this for initialization
	void Start () {

        VarInt varInt = VarInt.Alloc(10);
        int x = varInt;
    
      
        StartCoroutine(Test1(varInt));
        varInt.Release();
      //  Debug.Log("x==" + x);
    }

    IEnumerator Test1(VarInt a)
    {
        a.Retain(); //在使用协程的时候注意 先要保留，不然可能被其他地方覆盖掉   Retain（VarInt.Alloc） Release成对使用
        yield return new WaitForSeconds(5);
        Debug.Log("a==" + a.Value);
        a.Release();
    }

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameEntry.Procedure.ChangeState(ProcedureState.PreLoad);
            Debug.Log(GameEntry.Procedure.CurrProcedure);
        }

        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    Debug.Log(GameEntry.Procedure.CurrProcedure);
        //}
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    GameEntry.Procedure.ChangeState(ProcedureState.ChangeScene);
        //}
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    GameEntry.Procedure.SetData("Name","youyou");
        //    GameEntry.Procedure.SetData("Code", 123321);
        //    GameEntry.Procedure.ChangeState(ProcedureState.EnterGame);
        //}
    }
}
