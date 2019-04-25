using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class VarInt:Variable<int>
    {
        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <returns></returns>
        public static VarInt Alloc()
        {
            VarInt varInt = GameEntry.Pool.DequeueVarObject<VarInt>();
            varInt.Value = 0;
            varInt.Retain();
            return varInt;
        }

        /// <summary>
        /// 分配一个对象
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static VarInt Alloc(int value)
        {
            VarInt var = Alloc();
            var.Value = value;
            return var;
        }

        public static implicit operator int(VarInt var)
        {
            return var.Value;
        }

    }
}