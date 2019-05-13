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
    public class GameObjectUtilWrap
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			Utils.BeginObjectRegister(typeof(GameObjectUtil), L, translator, 0, 0, 0, 0);
			
			
			
			
			
			Utils.EndObjectRegister(typeof(GameObjectUtil), L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(typeof(GameObjectUtil), L, __CreateInstance, 7, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "SetParent", _m_SetParent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLayer", _m_SetLayer_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetNull", _m_SetNull_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetText", _m_SetText_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetSliderValue", _m_SetSliderValue_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetImage", _m_SetImage_xlua_st_);
            
			
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UnderlyingSystemType", typeof(GameObjectUtil));
			
			
			Utils.EndClassRegister(typeof(GameObjectUtil), L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "GameObjectUtil does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetParent_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    UnityEngine.Transform parent = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    
                    GameObjectUtil.SetParent( obj, parent );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLayer_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.GameObject obj = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    string layerName = LuaAPI.lua_tostring(L, 2);
                    
                    GameObjectUtil.SetLayer( obj, layerName );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetNull_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.MonoBehaviour[]>(L, 1)) 
                {
                    UnityEngine.MonoBehaviour[] arr = (UnityEngine.MonoBehaviour[])translator.GetObject(L, 1, typeof(UnityEngine.MonoBehaviour[]));
                    
                    GameObjectUtil.SetNull( arr );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.Transform[]>(L, 1)) 
                {
                    UnityEngine.Transform[] arr = (UnityEngine.Transform[])translator.GetObject(L, 1, typeof(UnityEngine.Transform[]));
                    
                    GameObjectUtil.SetNull( arr );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.Sprite[]>(L, 1)) 
                {
                    UnityEngine.Sprite[] arr = (UnityEngine.Sprite[])translator.GetObject(L, 1, typeof(UnityEngine.Sprite[]));
                    
                    GameObjectUtil.SetNull( arr );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 1&& translator.Assignable<UnityEngine.GameObject[]>(L, 1)) 
                {
                    UnityEngine.GameObject[] arr = (UnityEngine.GameObject[])translator.GetObject(L, 1, typeof(UnityEngine.GameObject[]));
                    
                    GameObjectUtil.SetNull( arr );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameObjectUtil.SetNull!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetText_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			int __gen_param_count = LuaAPI.lua_gettop(L);
            
            try {
                if(__gen_param_count == 5&& translator.Assignable<UnityEngine.UI.Text>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<DG.Tweening.ScrambleMode>(L, 5)) 
                {
                    UnityEngine.UI.Text txtObj = (UnityEngine.UI.Text)translator.GetObject(L, 1, typeof(UnityEngine.UI.Text));
                    string text = LuaAPI.lua_tostring(L, 2);
                    bool isAnimation = LuaAPI.lua_toboolean(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    DG.Tweening.ScrambleMode scrambleMode;translator.Get(L, 5, out scrambleMode);
                    
                    GameObjectUtil.SetText( txtObj, text, isAnimation, duration, scrambleMode );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 4&& translator.Assignable<UnityEngine.UI.Text>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    UnityEngine.UI.Text txtObj = (UnityEngine.UI.Text)translator.GetObject(L, 1, typeof(UnityEngine.UI.Text));
                    string text = LuaAPI.lua_tostring(L, 2);
                    bool isAnimation = LuaAPI.lua_toboolean(L, 3);
                    float duration = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    GameObjectUtil.SetText( txtObj, text, isAnimation, duration );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 3&& translator.Assignable<UnityEngine.UI.Text>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.UI.Text txtObj = (UnityEngine.UI.Text)translator.GetObject(L, 1, typeof(UnityEngine.UI.Text));
                    string text = LuaAPI.lua_tostring(L, 2);
                    bool isAnimation = LuaAPI.lua_toboolean(L, 3);
                    
                    GameObjectUtil.SetText( txtObj, text, isAnimation );
                    
                    
                    
                    return 0;
                }
                if(__gen_param_count == 2&& translator.Assignable<UnityEngine.UI.Text>(L, 1)&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    UnityEngine.UI.Text txtObj = (UnityEngine.UI.Text)translator.GetObject(L, 1, typeof(UnityEngine.UI.Text));
                    string text = LuaAPI.lua_tostring(L, 2);
                    
                    GameObjectUtil.SetText( txtObj, text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to GameObjectUtil.SetText!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetSliderValue_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.UI.Slider sliderObj = (UnityEngine.UI.Slider)translator.GetObject(L, 1, typeof(UnityEngine.UI.Slider));
                    float value = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    GameObjectUtil.SetSliderValue( sliderObj, value );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetImage_xlua_st_(RealStatePtr L)
        {
            
            ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
            try {
                
                {
                    UnityEngine.UI.Image imgObj = (UnityEngine.UI.Image)translator.GetObject(L, 1, typeof(UnityEngine.UI.Image));
                    UnityEngine.Sprite sprite = (UnityEngine.Sprite)translator.GetObject(L, 2, typeof(UnityEngine.Sprite));
                    
                    GameObjectUtil.SetImage( imgObj, sprite );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception __gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + __gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
