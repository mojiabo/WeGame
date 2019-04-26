using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class SocketComponent : BaseComponent,IUpdateComponent
    {
        private SocketManager m_SocketManager;
 
        protected override void OnAwake()
        {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);
            m_SocketManager = new SocketManager();
        }
        protected override void OnStart()
        {
            base.OnStart();

            m_MainSocket = CreateSocketTcpRoutine();
        }
        /// <summary>
        /// 注册SocketTcp访问器
        /// </summary>
        /// <param name="routine"></param>
        internal void RegisterSocketTcpRoutine(SocketTcpRoutine routine)
        {
            m_SocketManager.RegisterSocketTcpRoutine(routine);
        }
        /// <summary>
        /// 移除SocketTcp访问器
        /// </summary>
        /// <param name="routine"></param>
        internal void RemoveSocketTcpRoutine(SocketTcpRoutine routine)
        {
            m_SocketManager.RemoveSocketTcpRoutine(routine);
        }

        /// <summary>
        /// 创建SocketTcp访问器
        /// </summary>
        /// <returns></returns>
        public SocketTcpRoutine CreateSocketTcpRoutine()
        {
            return GameEntry.Pool.DequeueClassObject<SocketTcpRoutine>();
        }

        public void OnUpdate()
        {
            m_SocketManager.OnUpdate();
        }

        public override void Shutdown()
        {
            GameEntry.RemoveUpdateComponent(this);
            GameEntry.Pool.EnqueueClassObject(m_MainSocket);
            m_SocketManager.Dispose();
        }

        //========================================

        /// <summary>
        /// 主Socket
        /// </summary>
        private SocketTcpRoutine m_MainSocket;
        /// <summary>
        /// 连接主socke
        /// </summary>
        public void ConnetToMainSocket(string ip,int port)
        {
            m_MainSocket.Connect(ip,port);
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="buffer"></param>
        public void SendMsg(byte[] buffer)
        {
            m_MainSocket.SendMsg(buffer);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="buffer"></param>
        public void SendMsg(IProto proto)
        {
#if DEBUG_LOG_PROTO
            Debug.Log("<color=#ffa200>发送消息</color><color=#FFFB80>"+proto.ProtoEnName+" "+proto.ProtoCode+"</color>");
            Debug.Log("<color=#ffdeb3>===>>"+JsonUtility.ToJson(proto)+"</color>");   
#endif
            SendMsg(proto.ToArray());
        }
    }
}
