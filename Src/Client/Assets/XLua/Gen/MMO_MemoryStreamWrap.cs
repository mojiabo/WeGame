#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class MMO_MemoryStreamWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(MMO_MemoryStream), L, translator, 0, 20, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadShort", _m_ReadShort);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteShort", _m_WriteShort);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadUShort", _m_ReadUShort);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteUShort", _m_WriteUShort);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadInt", _m_ReadInt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteInt", _m_WriteInt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadUInt", _m_ReadUInt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteUInt", _m_WriteUInt);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadLong", _m_ReadLong);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteLong", _m_WriteLong);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadULong", _m_ReadULong);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteULong", _m_WriteULong);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadFloat", _m_ReadFloat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteFloat", _m_WriteFloat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadDouble", _m_ReadDouble);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteDouble", _m_WriteDouble);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadBool", _m_ReadBool);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteBool", _m_WriteBool);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ReadUTF8String", _m_ReadUTF8String);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WriteUTF8String", _m_WriteUTF8String);
			
			
			
			
			Utils.EndObjectRegister(typeof(MMO_MemoryStream), L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(typeof(MMO_MemoryStream), L, __CreateInstance, 1, 0, 0);
			
			
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UnderlyingSystemType", typeof(MMO_MemoryStream));
			
			
			Utils.EndClassRegister(typeof(MMO_MemoryStream), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					MMO_MemoryStream __cl_gen_ret = new MMO_MemoryStream();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					byte[] buffer = LuaAPI.lua_tobytes(L, 2);
					
					MMO_MemoryStream __cl_gen_ret = new MMO_MemoryStream(buffer);
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to MMO_MemoryStream constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadShort(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        short __cl_gen_ret = __cl_gen_to_be_invoked.ReadShort(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteShort(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    short value = (short)LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.WriteShort( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadUShort(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        ushort __cl_gen_ret = __cl_gen_to_be_invoked.ReadUShort(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteUShort(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ushort value = (ushort)LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.WriteUShort( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadInt(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        int __cl_gen_ret = __cl_gen_to_be_invoked.ReadInt(  );
                        LuaAPI.xlua_pushinteger(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteInt(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    int value = LuaAPI.xlua_tointeger(L, 2);
                    
                    __cl_gen_to_be_invoked.WriteInt( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadUInt(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        uint __cl_gen_ret = __cl_gen_to_be_invoked.ReadUInt(  );
                        LuaAPI.xlua_pushuint(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteUInt(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    uint value = LuaAPI.xlua_touint(L, 2);
                    
                    __cl_gen_to_be_invoked.WriteUInt( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadLong(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        long __cl_gen_ret = __cl_gen_to_be_invoked.ReadLong(  );
                        LuaAPI.lua_pushint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteLong(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    long value = LuaAPI.lua_toint64(L, 2);
                    
                    __cl_gen_to_be_invoked.WriteLong( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadULong(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        ulong __cl_gen_ret = __cl_gen_to_be_invoked.ReadULong(  );
                        LuaAPI.lua_pushuint64(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteULong(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    ulong value = LuaAPI.lua_touint64(L, 2);
                    
                    __cl_gen_to_be_invoked.WriteULong( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadFloat(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        float __cl_gen_ret = __cl_gen_to_be_invoked.ReadFloat(  );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteFloat(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    float value = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.WriteFloat( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadDouble(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        double __cl_gen_ret = __cl_gen_to_be_invoked.ReadDouble(  );
                        LuaAPI.lua_pushnumber(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteDouble(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    double value = LuaAPI.lua_tonumber(L, 2);
                    
                    __cl_gen_to_be_invoked.WriteDouble( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadBool(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        bool __cl_gen_ret = __cl_gen_to_be_invoked.ReadBool(  );
                        LuaAPI.lua_pushboolean(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteBool(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    bool value = LuaAPI.lua_toboolean(L, 2);
                    
                    __cl_gen_to_be_invoked.WriteBool( value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ReadUTF8String(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                        string __cl_gen_ret = __cl_gen_to_be_invoked.ReadUTF8String(  );
                        LuaAPI.lua_pushstring(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WriteUTF8String(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            MMO_MemoryStream __cl_gen_to_be_invoked = (MMO_MemoryStream)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string str = LuaAPI.lua_tostring(L, 2);
                    
                    __cl_gen_to_be_invoked.WriteUTF8String( str );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
