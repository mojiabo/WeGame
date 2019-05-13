using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

namespace Framework
{
	/// <summary>
	/// SocketTCP访问器
	/// </summary>
	public class SocketTcpRoutine
	{

		/// <summary>
		/// 客户端Socket
		/// </summary>
		private Socket m_Client;

		/// <summary>
		/// 压缩数组的长度界限
		/// </summary>
		private const int m_CompressLen = 200;
		#region 发送消息变量
		/// <summary>
		/// 发送消息队列
		/// </summary>
		private Queue<byte[]> m_SendQueue = new Queue<byte[]>();

		#endregion
		#region 接收数据所需变量
		/// <summary>
		/// 接受数据包字节缓存区
		/// </summary>
		private byte[] m_ReceiveBuffer = new byte[2048];
		/// <summary>
		/// 接收数据包的缓存数据流
		/// </summary>
		private MMO_MemoryStream m_ReceiveMS = new MMO_MemoryStream();
        /// <summary>
        /// 接收ms
        /// </summary>
        private MMO_MemoryStream m_SocketReceiveMS=new MMO_MemoryStream();

        /// <summary>
        /// 发送ms
        /// </summary>
        private MMO_MemoryStream m_SocketSendMS=new MMO_MemoryStream();


        /// <summary>
        /// 接受消息的队列
        /// </summary>
        private Queue<byte[]> m_ReceiveQueue = new Queue<byte[]>();

		private int m_ReceiveCount = 0;
		/// <summary>
		/// 这一帧发送了多少
		/// </summary>
		private int m_SendCount = 0;

		/// <summary>
		/// 是否有未处理的包
		/// </summary>
		private bool m_isUnDealBytes = false;

		private byte[] m_UnDealBytes = null;

		#endregion
		public Action OnConectOk;
		public void DisConnected()
		{
			if (m_Client != null && m_Client.Connected)

			{
				m_Client.Shutdown(SocketShutdown.Both);
				m_Client.Close();
				GameEntry.Socket.RemoveSocketTcpRoutine(this);
			}
		}
		internal void OnUpdate()
		{
			#region 接收数据
			while (true)
			{
				if (m_ReceiveCount <= GameEntry.Socket.MaxReveiceCount)
				{
					m_ReceiveCount++;
					lock (m_ReceiveQueue)
					{
						if (m_ReceiveQueue.Count > 0)
						{


							byte[] buffer = m_ReceiveQueue.Dequeue();
							//异或之后的数组
							byte[] newBuffer = new byte[buffer.Length - 3];

							bool isCompress = false;

							ushort crc = 0;

                            MMO_MemoryStream ms1 = m_SocketReceiveMS;
                            ms1.SetLength(0);
                            ms1.Write(buffer,0,buffer.Length);
                            ms1.Position = 0;

                            isCompress = ms1.ReadBool();

                            crc = ms1.ReadUShort();

                            ms1.Read(newBuffer, 0, newBuffer.Length);

							int newCrc = Crc16.CalculateCrc16(newBuffer);
							//传过来的crc是否=新包的crc
							if (newCrc == crc)
							{
								//异或原始数据
								newBuffer = SecurityUtil.Xor(newBuffer);

								if (isCompress)
								{
									newBuffer = ZlibHelper.DeCompressBytes(newBuffer);
								}


								ushort protoCode = 0;
								byte[] protoConent = new byte[buffer.Length - 2];


                                MMO_MemoryStream ms2 = m_SocketReceiveMS;
                                ms2.SetLength(0);
                                ms2.Write(buffer, 0, buffer.Length);
                                ms2.Position = 0;

                                protoCode = ms2.ReadUShort();
                                ms2.Read(protoConent, 0, protoConent.Length);

                                GameEntry.Event.SocketEvent.Dispatch(protoCode, protoConent);

							}
							else
							{
								break;
							}

						}
						break;
					}
				}
				else
				{
					m_ReceiveCount = 0;
					break;
				}
			}
			#endregion
		}

		#region Connect连接到服务器
		/// <summary>
		/// 连接到服务器
		/// </summary>
		/// <param name="ip"></param>
		/// <param name="port"></param>
		public void Connect(string ip, int port)
		{
			if (m_Client != null && m_Client.Connected) return;

			m_Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			try
			{
				m_Client.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
				Debug.Log("连接成功");
				GameEntry.Socket.RegisterSocketTcpRoutine(this);
				ReceiveNsg();
				if (OnConectOk != null)
				{
					OnConectOk();
				}
			}
			catch (Exception ex)
			{
			   
				Debug.Log("连接失败" + ex.Message);

			}
		}
		#endregion
		#region OnCheckSendQueueCallBack 检查发送队列
		/// <summary>
		/// 检查发送队列
		/// </summary>
		private void CheckSendQueue()
		{
			if (m_SendCount>=GameEntry.Socket.MaxSendCount)
			{
				m_SendCount = 0;
				return;
			}

			lock (m_SendQueue)
			{
				if (m_SendQueue.Count > 0||m_isUnDealBytes)
				{
					MMO_MemoryStream ms = m_SocketSendMS;
					ms.SetLength(0);

					if (m_isUnDealBytes) //先处理未处理的包
					{
						m_isUnDealBytes = false;
						ms.Write(m_UnDealBytes, 0, m_UnDealBytes.Length);
					}

					while (true)
					{
						if (m_SendQueue.Count == 0)
						{
							break;
						}

						byte[] buffer = m_SendQueue.Dequeue();
						if (buffer.Length+ms.Length<=GameEntry.Socket.MaxSendByteCount)
						{
							ms.Write(buffer,0,buffer.Length);
						}
						else
						{
							m_isUnDealBytes = true;

							m_UnDealBytes = buffer;

							break;
						}
					}
					m_SendCount++;
					Send(ms.ToArray());
				}
			}

		}
		#endregion
		#region MakeData封装数据包
		/// <summary>
		/// 封装数据包
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private byte[] MakeData(byte[] data)
		{
			byte[] retBuffer = null;
			//压缩
			bool isCompress = data.Length > m_CompressLen ? true : false;
			if (isCompress)
			{
				data = ZlibHelper.CompressBytes(data);
			}

			//异或
			data = SecurityUtil.Xor(data);
			//crc校验
			ushort crc = Crc16.CalculateCrc16(data);

				MMO_MemoryStream ms = m_SocketSendMS;
				ms.SetLength(0);
				ms.WriteUShort((ushort)(data.Length + 3));
				ms.WriteBool(isCompress);
				ms.WriteUShort(crc);
				ms.Write(data, 0, data.Length);

				retBuffer = ms.ToArray();
			
			return retBuffer;

		}

		#endregion
		#region SendMsg发送消息 把消息加入队列
		/// <summary>
		/// 发送消息 把消息加入队列
		/// </summary>
		/// <param name="data"></param>
		public void SendMsg(byte[] data)
		{
			byte[] sendBuffer = MakeData(data);

			lock (m_SendQueue)
			{
				m_SendQueue.Enqueue(sendBuffer);
			}
		}
		#endregion
		#region Send真发送数据包的服务器
		/// <summary>
		/// 真发送数据包的服务器
		/// </summary>
		/// <param name="buffer"></param>
		private void Send(byte[] buffer)
		{

			m_Client.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallBack, m_Client);
		}
		#endregion
		#region SendCallBack发送消息回调
		private void SendCallBack(IAsyncResult ar)
		{
			m_Client.EndSend(ar);
		}
		#endregion

		//============================================

		#region ReceiveNsg 接收数据
		/// <summary>
		/// 接收数据
		/// </summary>
		private void ReceiveNsg()
		{
			//异步接收数据
			m_Client.BeginReceive(m_ReceiveBuffer, 0, m_ReceiveBuffer.Length, SocketFlags.None, ReceiveCallBack, m_Client);

		}
		#endregion
		#region ReceiveCallBack接受数据回调
		/// <summary>
		/// 接受数据回调
		/// </summary>
		/// <param name="ar"></param>
		private void ReceiveCallBack(IAsyncResult ar)
		{
			try
			{
				int len = m_Client.EndReceive(ar);

				if (len > 0)
				{
				   //已经接收到数据
				   //把接受到数据 写入缓冲数据流尾部
					m_ReceiveMS.Position = m_ReceiveMS.Length;
					//把指定长度的字节写入数据流
					m_ReceiveMS.Write(m_ReceiveBuffer, 0, len);

					//如果缓存>2说明至少有一个不完整的包发送过来了,客户端定义Ushort就是2
					if (m_ReceiveMS.Length > 2)
					{
						//循环 拆分包
						while (true)
						{
							//把数据流指针位置放在0
							m_ReceiveMS.Position = 0;
							//包体的长度
							int currMsgLen = m_ReceiveMS.ReadUShort();
							//总包的长度
							int currFullMsgLen = 2 + currMsgLen;
							//如果缓存流的数据》=整包，说明至少接收有一个完整
							if (m_ReceiveMS.Length >= currFullMsgLen)
							{
								//定义包体的数组
								byte[] buffer = new byte[currMsgLen];
								//把数据流指针位置放在2，也就是包体的位置
								m_ReceiveMS.Position = 2;
								//把数据流读到数组里buffer也就是我们要的数据
								m_ReceiveMS.Read(buffer, 0, currMsgLen);

								lock (m_ReceiveQueue)
								{
									m_ReceiveQueue.Enqueue(buffer);
								}
								//===========================处理剩余字节====================================
								//剩余字节
								int reMainLen = (int)m_ReceiveMS.Length - currFullMsgLen;
								if (reMainLen > 0)
								{
									m_ReceiveMS.Position = currFullMsgLen;
									byte[] reMainBuffer = new byte[reMainLen];
									m_ReceiveMS.Read(reMainBuffer, 0, reMainLen);
									//清空数据流
									m_ReceiveMS.Position = 0;
									m_ReceiveMS.SetLength(0);
									//把剩余字节重新写入数据流
									m_ReceiveMS.Write(reMainBuffer, 0, reMainBuffer.Length);

									reMainBuffer = null;

								}
								else
								{
									//清空数据流
									m_ReceiveMS.Position = 0;
									m_ReceiveMS.SetLength(0);
									break;
								}
							}
							else
							{//还没有收到完整的包


								break;
							}

						}

					}
					ReceiveNsg();

				}
				else
				{
					//客户端断开
					Debug.Log(string.Format("服务器{0}断开连接", m_Client.RemoteEndPoint.ToString()));
				}
			}
			catch
			{
				Debug.Log(string.Format("服务器{0}断开连接", m_Client.RemoteEndPoint.ToString()));
			}
		}
		#endregion
	}
}
