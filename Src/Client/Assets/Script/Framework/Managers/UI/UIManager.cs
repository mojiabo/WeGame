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
        internal void OpenUIFrom(int uIFromId,object userData=null)
        {
            Sys_UIFormEntity entity = GameEntry.DataTable.DataTableManager.Sys_UIFormDBModel.Get(uIFromId);

            if (entity==null)
            {
                Debug.LogError(uIFromId+"对应的UI窗体不存在");
                return;
            }
#if DISABLE_ASSETBUNDLE && UNITY_EDITOR

            UIFromBase fromBase = GameEntry.UI.Dequeue(uIFromId); //以后去对象池取

            if (fromBase==null)
            {
                string path = string.Format("Assets/Download/UI/UIPrefab/{0}.prefab", entity.AssetPath_Chinese);
                //加载镜像
                Object obj = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(path);
                GameObject uiObj = Object.Instantiate(obj) as GameObject;

                uiObj.SetParent(GameEntry.UI.GetUIGroup(entity.UIGroupId).Group);
                uiObj.transform.localPosition = Vector3.zero;
                uiObj.transform.localScale = Vector3.one;

                fromBase = uiObj.transform.GetComponent<UIFromBase>();
                fromBase.Init(entity.Id, entity.UIGroupId, entity.DisableUILayer == 1, entity.IsLock == 1, userData);
            }
            else
            {
                fromBase.gameObject.SetActive(true);
                fromBase.Open(userData);
            }

           
#endif

        }

        /// <summary>
        /// 关闭UI窗口
        /// </summary>
        /// <param name="fromBase"></param>
        internal void CloseUIFrom(UIFromBase fromBase)
        {
            fromBase.ToClose();
        }
    }
}
