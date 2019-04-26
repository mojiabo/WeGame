 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Menu 
{
    [MenuItem("Tools/Settings")]
    public static void Settings()
    {
        SettingWindow win = EditorWindow.GetWindow<SettingWindow>();
        win.titleContent = new GUIContent("全局设置");
        win.Show();

    }
    [MenuItem("Tools/资源管理/资源打包管理")]
    public static void AssetsBundleCreate()
    {
        AssetBundleWindow win = EditorWindow.GetWindow<AssetBundleWindow>();

        win.titleContent = new GUIContent("资源打包");


        win.Show();
    }
    [MenuItem("Tools/资源管理/初始资源拷贝到StreamingAsstes")]
    public static void AssetBundleCopyToStreamingAsstes()
    {
        string topPath = Application.streamingAssetsPath + "/AssetBundle/";
        if (Directory.Exists(topPath))
        {
            Directory.Delete(topPath,true);
        }
        Directory.CreateDirectory(topPath);

        IOUtil.CopyDirectory(Application.persistentDataPath,topPath);
        AssetDatabase.Refresh();
        DebugApp.Log("拷贝完成");

    }

}
