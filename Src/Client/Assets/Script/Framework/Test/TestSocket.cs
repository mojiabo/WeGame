using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;

public class TestSocket : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            GameEntry.Socket.ConnetToMainSocket("192.168.31.179",1037);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            System_SendLocalTimeProto proto = new
                  System_SendLocalTimeProto();
            GameEntry.Socket.SendMsg(proto.ToArray());
        }
    }
}
