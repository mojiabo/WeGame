using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class UIManager : ManagerBase
    {
        /// <summary>
        /// 打开一个窗体
        /// </summary>
        /// <param name="uIFromId">ID</param>
        /// <param name="userData">用户数据</param>
        public void OpenUIFrom(int uIFromId,object userData=null)
        {
            Sys_UIFormEntity entity = GameEntry.DataTable.DataTableManager.Sys_UIFormDBModel.Get(uIFromId);

            if (entity==null)
            {
                Debug.LogError(uIFromId+"对应的UI窗体不存在");
                return;
            }
#if DISABLE_ASSETBUNDLE && UNITY_EDITOR

            string path= string.Format("Assets/Download/UI/UIPrefab/{0}.prefab", entity.AssetPath_Chinese);
            //加载镜像
            Object obj = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(path);
            GameObject uiObj = Object.Instantiate(obj) as GameObject;

            uiObj.SetParent(GameEntry.UI.GetUIGroup(entity.UIGroupId).Group);
            uiObj.transform.localPosition=Vector3.zero;
            uiObj.transform.localScale = Vector3.one;
#endif

        }

    }
}
