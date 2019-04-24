using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;
public class TestProcedure : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log(GameEntry.Procedure.CurrProcedure);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameEntry.Procedure.ChangeState(ProcedureState.ChangeScene);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameEntry.Procedure.ChangeState(ProcedureState.EnterGame);
        }
    }
}
