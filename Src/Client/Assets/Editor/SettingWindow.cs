using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SettingWindow : EditorWindow
{
    private List<MacorItem> m_list = new List<MacorItem>();
    private Dictionary<string, bool> m_Dic = new Dictionary<string, bool>();

    private string m_Macor =null;

    
    public void OnEnable()
    {
        m_Macor = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone);
        m_list.Clear();

        m_list.Add(new MacorItem() { Name = "DEBUG_MODEL", DisolayName = "调试模式", IsDebugl = true, IsRelease = false });
        m_list.Add(new MacorItem() { Name = "DEBUG_LOG", DisolayName = "打印日志", IsDebugl = true, IsRelease = false });
        m_list.Add(new MacorItem() { Name = "DEBUG_LOG_PROTO", DisolayName = "打印通讯日志", IsDebugl = true, IsRelease = false });
        m_list.Add(new MacorItem() { Name = "STAT_TD", DisolayName = "开启统计", IsDebugl = false, IsRelease = true });
        m_list.Add(new MacorItem() { Name = "DEBUG_ROLESTATE", DisolayName = "调试角色状态", IsDebugl = false, IsRelease = true });
        m_list.Add(new MacorItem() { Name = "DISABLE_ASSETBUNDLE", DisolayName = "禁用AssetBundle", IsDebugl = false, IsRelease = false });
        m_list.Add(new MacorItem() { Name = "HOTFIX_ENABLE", DisolayName = "开启热补丁", IsDebugl = false, IsRelease = true });
        for (int i = 0; i < m_list.Count; i++)
        {
            if (!string.IsNullOrEmpty(m_Macor) && m_Macor.IndexOf(m_list[i].Name) != -1)
            {
                m_Dic[m_list[i].Name] = true;

            }
            else
            {
                m_Dic[m_list[i].Name] = false;
            }



        }
    }
    public SettingWindow()
    {

      

    }

    private void OnGUI()
    {

        for (int i = 0; i < m_list.Count; i++)
        {
            EditorGUILayout.BeginHorizontal("box");
            m_Dic[m_list[i].Name] = GUILayout.Toggle(m_Dic[m_list[i].Name], m_list[i].DisolayName);
          

           EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.BeginHorizontal("");
        if (GUILayout.Button("保存",GUILayout.Width(100)))
        {
            SaveMacor();
        }

        if (GUILayout.Button("调试模式", GUILayout.Width(100)))
        {
            for (int i = 0; i < m_list.Count; i++)
            {
                m_Dic[m_list[i].Name] = m_list[i].IsDebugl;
            }


            SaveMacor();
        }
        if (GUILayout.Button("发布模式", GUILayout.Width(100)))
        {
            
            for (int i = 0; i < m_list.Count; i++)
            {
                m_Dic[m_list[i].Name] = m_list[i].IsRelease;
            }
            SaveMacor();
        }
        EditorGUILayout.EndHorizontal();
    }

    private void SaveMacor()
    {
        m_Macor = string.Empty;
        foreach (var item in m_Dic)
        {
            if (item.Value)
            {
                m_Macor += string.Format("{0};", item.Key);
            }
            if (item.Key.Equals("DISABLE_ASSETBUNDLE",System.StringComparison.CurrentCultureIgnoreCase))
            {
                EditorBuildSettingsScene[] scene = EditorBuildSettings.scenes;
                for (int i = 0; i < scene.Length; i++)
                {
                    if (scene[i].path.IndexOf("Download", System.StringComparison.CurrentCultureIgnoreCase)>-1)
                    {
                        scene[i].enabled = item.Value;
                    }
                }
                EditorBuildSettings.scenes = scene;

            }

        }
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, m_Macor);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, m_Macor);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, m_Macor);
    }
}



    /// <summary>
    /// 宏项目
    /// </summary>
    public class MacorItem
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name;
        /// <summary>
        /// 显示的名称
        /// </summary>
        public string DisolayName;

        /// <summary>
        /// 是否调试项
        /// </summary>
        public bool IsDebugl;
        /// <summary>
        /// 是否发布项
        /// </summary>
        public bool IsRelease;


    }

