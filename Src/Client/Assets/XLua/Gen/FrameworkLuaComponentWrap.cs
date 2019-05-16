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
    public class FrameworkLuaComponentWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(Framework.LuaComponent), L, translator, 0, 3, 2, 1);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Shutdown", _m_Shutdown);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadDataTable", _m_LoadDataTable);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadSocketReceiveMS", _m_LoadSocketReceiveMS);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "LoadDaTableMS", _g_get_LoadDaTableMS);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DebugLogProto", _g_get_DebugLogProto);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "DebugLogProto", _s_set_DebugLogProto);
            
			Utils.EndObjectRegister(typeof(Framework.LuaComponent), L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(typeof(Framework.LuaComponent), L, __CreateInstance, 1, 0, 0);
			
			
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UnderlyingSystemType", typeof(Framework.LuaComponent));
			
			
			Utils.EndClassRegister(typeof(Framework.LuaComponent), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			try {
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Framework.LuaComponent __cl_gen_ret = new Framework.LuaComponent();
					translator.Push(L, __cl_gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception __gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Framework.LuaComponent constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Shutdown(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Framework.LuaComponent __cl_gen_to_be_invoked = (Framework.LuaComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    
                    __cl_gen_to_be_invoked.Shutdown(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadDataTable(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Framework.LuaComponent __cl_gen_to_be_invoked = (Framework.LuaComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    string TableName = LuaAPI.lua_tostring(L, 2);
                    
                        MMO_MemoryStream __cl_gen_ret = __cl_gen_to_be_invoked.LoadDataTable( TableName );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadSocketReceiveMS(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            Framework.LuaComponent __cl_gen_to_be_invoked = (Framework.LuaComponent)translator.FastGetCSObj(L, 1);
            
            
            try {
                
                {
                    byte[] buffer = LuaAPI.lua_tobytes(L, 2);
                    
                        MMO_MemoryStream __cl_gen_ret = __cl_gen_to_be_invoked.LoadSocketReceiveMS( buffer );
                        translator.Push(L, __cl_gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_LoadDaTableMS(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Framework.LuaComponent __cl_gen_to_be_invoked = (Framework.LuaComponent)translator.FastGetCSObj(L, 1);
                translator.Push(L, __cl_gen_to_be_invoked.LoadDaTableMS);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DebugLogProto(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Framework.LuaComponent __cl_gen_to_be_invoked = (Framework.LuaComponent)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, __cl_gen_to_be_invoked.DebugLogProto);
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DebugLogProto(RealStatePtr L)
        {
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
			
                Framework.LuaComponent __cl_gen_to_be_invoked = (Framework.LuaComponent)translator.FastGetCSObj(L, 1);
                __cl_gen_to_be_invoked.DebugLogProto = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
