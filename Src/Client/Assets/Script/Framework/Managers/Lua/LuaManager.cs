using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;

namespace Framework
{
    /// <summary>
    /// Lua管理器
    /// </summary>
    public class LuaManager :ManagerBase
{
        /// <summary>
        /// ȫ��LUA����
        /// </summary>
        public static LuaEnv luaEnv;

        public void Init()
        {
            //1 全局只有一个
            luaEnv = new LuaEnv();
            
#if DISABLE_ASSETBUNDLE && UNITY_EDITOR
            luaEnv.DoString(string.Format("package.path='{0}/?.bytes'", Application.dataPath+ "/Download/xLuaLogic/"));
#else
             luaEnv.AddLoader(MyLoader);
             luaEnv.DoString(string.Format("package.path='{0}/?.bytes'", Application.persistentDataPath));
#endif

            DOString("require 'Main'");
        }
        /// <summary>
        /// ִ启动lua
        /// </summary>
        /// <param name="path"></param>
        public void DOString(string path)
        {
            luaEnv.DoString(path);
        }

        private byte[] MyLoader(ref string filePath)
        {
            string path = Application.persistentDataPath + "/" + filePath + ".lua";

            byte[] buffer = null;
            using (FileStream fs = new FileStream(path,FileMode.Open))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
            }
            buffer = SecurityUtil.Xor(buffer);

            buffer = System.Text.Encoding.UTF8.GetBytes(System.Text.Encoding.UTF8.GetString(buffer));

            return buffer;

        }

    }
}
