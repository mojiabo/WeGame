using System.Collections;
using System.Collections.Generic;
using System;
using Framework;

/// <summary>
/// 客户端发送查询背包项消息
/// </summary>
public struct Backpack_SearchProto : IProto
{
    public ushort ProtoCode { get { return 16004; } }
    public string ProtoEnName { get { return "Backpack_Search"; } }


    public byte[] ToArray()
    {
        MMO_MemoryStream ms = GameEntry.Socket.SocketSendMS;
        ms.SetLength(0);
        ms.WriteUShort(ProtoCode);


        return ms.ToArray();
    }

    public static Backpack_SearchProto GetProto(byte[] buffer)
    {
        Backpack_SearchProto proto = new Backpack_SearchProto();
        MMO_MemoryStream ms = GameEntry.Socket.SocketReceiveMS;
        ms.SetLength(0);
        ms.Write(buffer, 0, buffer.Length);
        ms.Position = 0;


        return proto;
    }
}