using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class TestPool : MonoBehaviour
    {

        public Transform transform1;
        public Transform transform2;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    StartCoroutine(CreateObj());
            //}
            //if (Input.GetKeyDown(KeyCode.B))
            //{
            //    GameEntry.Pool.InitGameObjectPool(); //切场景初始化 =销毁
            //}
        }

        IEnumerator CreateObj()
        {
            for (int i = 0; i < 20; i++)
            {
                yield return new WaitForSeconds(0.5f);
                GameEntry.Pool.GameObjectSpawn(1, transform1, (Transform tran) => 
                {
                    tran.transform.localPosition = new Vector3(0, 0, i * 2);
                    tran.gameObject.SetActive(true);
                    StartCoroutine(DeSpawn(1, tran));

                });
                GameEntry.Pool.GameObjectSpawn(2, transform2, (Transform tran) =>
                {
                    tran.gameObject.SetActive(true);
                    tran.transform.localPosition = new Vector3(0, 0, i * 2);
                    StartCoroutine(DeSpawn(2, tran));

                });
            }

        }

        IEnumerator DeSpawn(byte poolId,Transform instance)
        {

             yield return new WaitForSeconds(20f);
            GameEntry.Pool.GameObjectDespawn(poolId,instance);


        }
    }
}
