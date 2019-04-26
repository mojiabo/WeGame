using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Text;

/// <summary>
/// AB 绘制窗口
/// </summary>
public class AssetBundleWindow: EditorWindow
{


    private AssetBundleDAL dal;

    private List<AssetBundleEntity> m_lst;

    private Dictionary<string, bool> m_Dic;
    private string[] arrTag = {"All","Scene","Role","Effect","Audio", "UI", "None" };
    /// <summary>
    /// 标记索引
    /// </summary>
    private int tagIndex=0;
    /// <summary>
    /// 选择标记的索引
    /// </summary>
    private int selectTagIndex = -1;
    /// <summary>
    /// 打包平台Target
    /// </summary>
    private string[] arrBuildTarget = { "Windows", "Android", "iOS" };
    /// <summary>
    /// 选择打包平台Target的索引
    /// </summary>
    private int selectBuildTargetIndex = -1;
    private Vector2 pos;

#if UNITY_STANDALONE_WIN
    private BuildTarget target = BuildTarget.StandaloneWindows;
    private int buildTargetIndex = 0;
#elif UNITY_ANDROID
    private int buildTargetIndex = 1;
    private BuildTarget target = BuildTarget.Android;
#elif UNITY_IPHONE
    private int buildTargetIndex = 2;
    private BuildTarget target = BuildTarget.iOS;

#endif
    private void OnEnable()
    {
        string xmlPath = Application.dataPath + @"\Editor\AssetBundle\AssetBundleConfig.xml";
        dal = new AssetBundleDAL(xmlPath);

        m_lst = dal.GetList();

        m_Dic = new Dictionary<string, bool>();


        for (int i = 0; i < m_lst.Count; i++)
        {
            m_Dic[m_lst[i].Key] = true;
        }
    }
    public AssetBundleWindow()
    {
       
      
    }
    /// <summary>
    /// 绘制窗口
    /// </summary>
    private void OnGUI()
    {
        if (m_lst == null) return;
        #region 按钮行
        GUILayout.BeginHorizontal("box");

        selectTagIndex = EditorGUILayout.Popup(tagIndex, arrTag, GUILayout.Width(100));
        if (selectTagIndex!= tagIndex)
        {
            tagIndex = selectTagIndex;
            EditorApplication.delayCall = OnSelectTagCallBack;
        }

        selectBuildTargetIndex = EditorGUILayout.Popup(buildTargetIndex, arrBuildTarget, GUILayout.Width(100));
        if (selectBuildTargetIndex != buildTargetIndex)
        {
            buildTargetIndex = selectBuildTargetIndex;
            EditorApplication.delayCall = OnSelectTargetCallBack;
        }
        if (GUILayout.Button("保存设置", GUILayout.Width(200)))
        {
            EditorApplication.delayCall = OnSaveAssetBundleCallBack;
        }


        if (GUILayout.Button("打AssetBundle包", GUILayout.Width(200)))
        {
            EditorApplication.delayCall = OnAssetBundleCallBack;
        }

        if (GUILayout.Button("清空AssetBundle包", GUILayout.Width(200)))
        {
            EditorApplication.delayCall = OnClaerAssetBundleCallBack;
        }
        if (GUILayout.Button("拷贝数据表", GUILayout.Width(200)))
        {
            EditorApplication.delayCall = OnCopyDataTableCallBack;
        }
        if (GUILayout.Button("生成版本文件", GUILayout.Width(200)))
        {
            EditorApplication.delayCall = OnCreateVersionTextCallBack;
        }
        EditorGUILayout.Space();
        GUILayout.EndHorizontal();
        #endregion
        GUILayout.BeginHorizontal("box");
        GUILayout.Label("包名");
        GUILayout.Label("标记",GUILayout.Width(100));
        GUILayout.Label("文件夹", GUILayout.Width(200));
        GUILayout.Label("初始资源", GUILayout.Width(200));
        GUILayout.EndHorizontal();

        GUILayout.BeginVertical();

        pos=EditorGUILayout.BeginScrollView(pos);
        for (int i = 0; i < m_lst.Count; i++)
        {
            AssetBundleEntity entity = m_lst[i];

            GUILayout.BeginHorizontal("box");
            m_Dic[entity.Key] = GUILayout.Toggle(m_Dic[entity.Key], "", GUILayout.Width(20));
            GUILayout.Label(entity.Name);
            GUILayout.Label(entity.Tag, GUILayout.Width(100));
            GUILayout.Label(entity.IsFolder.ToString(), GUILayout.Width(200));
            GUILayout.Label(entity.IsFirstData.ToString(), GUILayout.Width(200));

            //GUILayout.Label(entity.Size.ToString(), GUILayout.Width(100));
            GUILayout.EndHorizontal();

            foreach (string path in entity.PathList)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Space(40);
                GUILayout.Label(path);

                GUILayout.EndHorizontal();
            }

        }




        EditorGUILayout.EndScrollView();

        GUILayout.EndVertical();
    }

    /// <summary>
    /// 生成版本文件
    /// </summary>
    private void OnCreateVersionTextCallBack()
    {
        string path = Application.dataPath + "/../AssetBundles/" + arrBuildTarget[buildTargetIndex]/* + "/Download"*/;

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string strVersionTextPath = path + "/VersionFule.txt";//版本文件路径
        //如果版本文件存在 则删除
        IOUtil.DeleteFile(strVersionTextPath);

        StringBuilder sbContent = new StringBuilder();

        DirectoryInfo dirctory = new DirectoryInfo(path);
        //拿到文件夹下所有文件
        FileInfo[] arrFiles = dirctory.GetFiles("*",SearchOption.AllDirectories);
        for (int i = 0; i < arrFiles.Length; i++)
        {
            FileInfo file = arrFiles[i];
            string fullName = file.FullName;//全名 包括路径扩展名
            //相对路径
            string name = fullName.Substring(fullName.IndexOf(arrBuildTarget[buildTargetIndex])+arrBuildTarget[buildTargetIndex].Length+1);
            //if (name.Equals(arrBuildTarget[buildTargetIndex],StringComparison.CurrentCultureIgnoreCase))
            //{
            //    continue;
            //}
            string md5 = EncryptUtil.GetFileMD5(fullName);//文件的MD5
            if (md5 == null) continue;

            string size = Math.Ceiling(file.Length / 1024f).ToString();//文件大小

            bool isFirstData = false;//是否初始数据
            bool isBreak=false;
            for (int j = 0; j < m_lst.Count; j++)
            {
                foreach (string xmlPath in m_lst[j].PathList)
                {
                    string tempPath = xmlPath;
                    if (xmlPath.IndexOf(".") != -1)
                    {
                        tempPath = xmlPath.Substring(0, xmlPath.IndexOf("."));
                    }
                    if (name.IndexOf(tempPath, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        isFirstData = m_lst[j].IsFirstData;
                        isBreak = true;
                        break;
                    }
                }
                if (isBreak) break;
              
             }
            if (name.IndexOf("DataTable") !=-1|| name.IndexOf("Windows") != -1)
            {
                isFirstData = true;
            }
            string strLine = string.Format("{0} {1} {2} {3}", name, md5, size, isFirstData ? 1 : 0);
            sbContent.AppendLine(strLine);
        }
       
        IOUtil.CreateTextFile(strVersionTextPath, sbContent.ToString());
        Debug.Log("生成版本文件");
    }


    /// <summary>
    /// 拷贝数据表
    /// </summary>
    private void OnCopyDataTableCallBack()
    {
        string fromPath = Application.dataPath + "/Download/DataTable";
        string toPath = Application.dataPath + "/../AssetBundles/" + arrBuildTarget[buildTargetIndex] + "/Download/DataTable";
        IOUtil.CopyDirectory(fromPath, toPath);
        Debug.Log("拷贝完毕");
    }

    /// <summary>
    /// 保存设置
    /// </summary>
    private void OnSaveAssetBundleCallBack()
    {
        List<AssetBundleEntity> list = new List<AssetBundleEntity>();


        foreach (AssetBundleEntity entity in m_lst)
        {
            if (m_Dic[entity.Key])
            {
                entity.IsChecked = true;
                list.Add(entity);
            }
            else
            {
                entity.IsChecked = false;
                list.Add(entity);
            }
        }

        //循环设置文件夹包括子文件里边的项
        for (int i = 0; i < list.Count; i++)
        {
            AssetBundleEntity entity = list[i];
            if (entity.IsFolder)
            {
                //如果这个节点配置的是一个文件夹，那么需要遍历文件夹
                //需要把路径变成绝对路径
                string[] follderArr = new string[entity.PathList.Count];
                for (int j = 0; j < entity.PathList.Count; j++)
                {
                    follderArr[j] = Application.dataPath + "/" + entity.PathList[j];

                }
                SaveFolderSettings(follderArr, !entity.IsChecked);
            }
            else
            {
                //如果不是文件夹 只需要设置里边的项
                string[] follderArr = new string[entity.PathList.Count];
                for (int j = 0; j < entity.PathList.Count; j++)
                {
                    follderArr[j] = Application.dataPath + "/" + entity.PathList[j];
                    SaveFileSetting(follderArr[j], !entity.IsChecked);
                }
                
            }
        }
        
    }

    private void SaveFolderSettings(string[] folderArr,bool isSetNull)
    {
        foreach (string folderPath in folderArr)
        {
            //1.先看这个文件夹下的文件
            string[] arrFile = Directory.GetFiles(folderPath);

            //2.对文件进行设置
            foreach (var filePath in arrFile)
            {
                //进行设置
                SaveFileSetting(filePath, isSetNull);
            }
            //3.看这个文件夹下的子文件夹
            string[] arrFolder = Directory.GetDirectories(folderPath);
            SaveFolderSettings(arrFolder,isSetNull);
        }
    }

    private void SaveFileSetting(string filePath,bool isSetNull)
    {
        FileInfo file = new FileInfo(filePath);
        if (!file.Extension.Equals(".meta",StringComparison.CurrentCultureIgnoreCase))
        {
            int index = filePath.IndexOf("Assets/",StringComparison.CurrentCultureIgnoreCase);

            //路径
            string newPath = filePath.Substring(index);
            //文件名
            string fileName = newPath.Replace("Assets/","").Replace(file.Extension,"");

            //后缀
            string variant = file.Extension.Equals(".unity",StringComparison.CurrentCultureIgnoreCase)?"unity3d":"assetbundle";

            AssetImporter import = AssetImporter.GetAtPath(newPath);
            import.SetAssetBundleNameAndVariant(fileName, variant);
            if (isSetNull)
            {
                import.SetAssetBundleNameAndVariant(null, null);
            }
            import.SaveAndReimport();
        }
    }


    /// <summary>
    /// 清空AB包
    /// </summary>
    private void OnClaerAssetBundleCallBack()
    {

        string path = Application.dataPath + "/../AssetBundles/" + arrBuildTarget[buildTargetIndex];
        if (Directory.Exists(path))
        {
            Directory.Delete(path,true);
        }
        Debug.Log("清空完毕");


    }
    /// <summary>
    /// 打AB包
    /// </summary>
    private void OnAssetBundleCallBack()
    {
        string toPath = Application.dataPath + "/../AssetBundles/" + arrBuildTarget[buildTargetIndex];

        if (!Directory.Exists(toPath))
        {
            Directory.CreateDirectory(toPath);
        }

        BuildPipeline.BuildAssetBundles(toPath,BuildAssetBundleOptions.None,target);

        //List<AssetBundleEntity> listNeedBuild = new List<AssetBundleEntity>();


        //foreach (AssetBundleEntity entity in m_lst)
        //{
        //    if (m_Dic[entity.Key])
        //    {
        //        listNeedBuild.Add(entity);
        //    }
        //}


        //for (int i = 0; i < listNeedBuild.Count; i++)
        //{
        //    Debug.LogFormat("正在打包{0}/{1}",i+1,listNeedBuild.Count);


        //    BuildAssetBundle(listNeedBuild[i]);
        //}
        Debug.Log("打包完毕");

        
    }

    /// <summary>
    /// 选定Targert
    /// </summary>
    private void OnSelectTargetCallBack()
    {
        switch (buildTargetIndex)
        {
            case 0:
                target = BuildTarget.StandaloneWindows;
                break;
            case 1:
                target = BuildTarget.Android;
                break;
            case 2:
                target = BuildTarget.iOS;
                break;
                

        }
        Debug.LogFormat("当前选定的tag:{0}", arrBuildTarget[buildTargetIndex]);
    }
    /// <summary>
    /// 选定Tag
    /// </summary>
    private void OnSelectTagCallBack()
    {

        switch (tagIndex)
        {
            //全选
            case 0:
                foreach (AssetBundleEntity  entity in m_lst)
                {
                    m_Dic[entity.Key] = true;
                }
                break;
            case 1:
                foreach (AssetBundleEntity entity in m_lst)
                {
                    m_Dic[entity.Key] = entity.Tag.Equals("Scene",StringComparison.CurrentCultureIgnoreCase);
                }
                break;

            case 2:
                foreach (AssetBundleEntity entity in m_lst)
                {
                    m_Dic[entity.Key] = entity.Tag.Equals("Role", StringComparison.CurrentCultureIgnoreCase);
                }
                break;

            case 3:
                foreach (AssetBundleEntity entity in m_lst)
                {
                    m_Dic[entity.Key] = entity.Tag.Equals("Effect", StringComparison.CurrentCultureIgnoreCase);
                }
                break;

            case 4:
                foreach (AssetBundleEntity entity in m_lst)
                {
                    m_Dic[entity.Key] = entity.Tag.Equals("Audio", StringComparison.CurrentCultureIgnoreCase);
                }
                break;
            case 5:
                foreach (AssetBundleEntity entity in m_lst)
                {
                    m_Dic[entity.Key] = entity.Tag.Equals("UI", StringComparison.CurrentCultureIgnoreCase);
                }
                break;
            case 6:
                foreach (AssetBundleEntity entity in m_lst)
                {
                    m_Dic[entity.Key] = false;
                }
                break;
        }
        Debug.LogFormat("当前选定的tag:{0}", arrTag[tagIndex]);


    }
}
