using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TestAsync : MonoBehaviour {

    // Use this for initialization
    void Start() {
        //方式1
        //Task.Factory.StartNew(TestMethod); //常用的异步方法---->开新线程
        //方式2
        //TestMehodAsync();
    }

    // Update is called once per frame
    void Update() {

    }

    void TestMethod()
    {
        for (int i = 0; i < 10000; i++)
        {
            Debug.Log(i);
        }
    }

    async void TestMehodAsync()
    {
        for (int i = 0; i < 10000; i++)
        {
            Debug.Log(i);
            await Task.Delay(1);//延迟1毫秒
        }
        //这里再调用普通的方法 普通的方法里面是不会异步的
    }

    async void TestAsyncRet()
    {
        int res = await Test1(); //这里会等待返回值
        
    }

    async Task<int> Test1()
    {
        int ret = 0;
        for (int i = 0; i < 10000; i++)
        {
            ret += i;
            await Task.Delay(1);
        }
        return ret;
    }

}
