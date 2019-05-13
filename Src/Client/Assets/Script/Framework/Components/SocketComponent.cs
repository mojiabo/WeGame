using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class SocketComponent : BaseComponent,IUpdateComponent
    {
        private SocketManager m_SocketManager;

        //public MMO_MemoryStream CommonMemoryStream
        //{
        //    private set;
        //    get;
        //}

        /// <summary>
        /// 接收ms
        /// </summary>
        public MMO_MemoryStream SocketReceiveMS
        {
            private set;
            get;
        }

        /// <summary>
        /// 发送ms
        /// </summary>
        public MMO_MemoryStream SocketSendMS
        {
            private set;
            get;
        }


        /// <summary>
        /// 每帧最大发送包数量
        /// </summary>
        [Header("每帧最大发送数量")]
        public int MaxSendCount=5;
        /// <summary>
        /// 每次发包的最大字节
        /// </summary>
        [Header("每次发包的最大字节")]
        public int MaxSendByteCount;

        /// <summary>
        /// 每帧最大发送包数量
        /// </summary>
        [Header("每帧最大接受数量")]
        public int MaxReveiceCount = 5;

        protected override void OnAwake()
        {
            base.OnAwake();
            GameEntry.RegisterUpdateComponent(this);
            m_SocketManager = new SocketManager();
            SocketReceiveMS = new MMO_MemoryStream();
            SocketSendMS = new MMO_MemoryStream();
          //  CommonMemoryStream = new MMO_MemoryStream();
        }
        protected override void OnStart()
        {
            base.OnStart();

            m_MainSocket = CreateSocketTcpRoutine();

            SocketProtoListener.AddProtoListener();
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
            SocketProtoListener.RemoveProtoListener();
            GameEntry.Pool.EnqueueClassObject(m_MainSocket);
            m_SocketManager.Dispose();
            SocketReceiveMS.Dispose();
            SocketReceiveMS.Close();
            SocketSendMS.Dispose();
            SocketSendMS.Close();
            // CommonMemoryStream.Dispose();
            // CommonMemoryStream.Close();
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
