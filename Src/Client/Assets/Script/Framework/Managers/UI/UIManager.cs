using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    public class UIManager : ManagerBase
    {

        /// <summary>
        /// 已经打开的ui列表
        /// </summary>
        private LinkedList<UIFromBase> m_OpenUIFromList;
        public UIManager()
        {
            m_OpenUIFromList = new LinkedList<UIFromBase>();

        }
        /// <summary>
        /// 打开一个窗体
        /// </summary>
        /// <param name="uIFromId">ID</param>
        /// <param name="userData">用户数据</param>
        internal void OpenUIFrom(int uIFromId,object userData=null)
        {
            if (isExists(uIFromId))
            {
                return;
            }

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
                string assetPath = string.Empty;

                switch (GameEntry.Localization.CurrLanguage)
                {
                    case Language.Chinese:
                        assetPath = entity.AssetPath_Chinese;
                        break;
                    case Language.English:
                        assetPath = entity.AssetPath_English;
                        break;
                    default:
                        break;
                }

                string path = string.Format("Assets/Download/UI/UIPrefab/{0}.prefab", assetPath);
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

            m_OpenUIFromList.AddLast(fromBase);
#endif

        }

        internal bool isExists(int uiFromId)
        {
            for (LinkedListNode<UIFromBase>curr= m_OpenUIFromList.First;curr!=null;curr=curr.Next)
            {
                if (curr.Value.UIFromId==uiFromId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 关闭UI窗口
        /// </summary>
        /// <param name="fromBase"></param>
        internal void CloseUIFrom(UIFromBase fromBase)
        {
            m_OpenUIFromList.Remove(fromBase);
            fromBase.ToClose();
        }

        /// <summary>
        /// 根据UIFromId关闭UI窗口
        /// </summary>
        /// <param name="fromBase"></param>
        internal void CloseUIFrom(int uiFromId)
        {
            for (LinkedListNode<UIFromBase> curr = m_OpenUIFromList.First; curr != null; curr = curr.Next)
            {
                if (curr.Value.UIFromId == uiFromId)
                {
                    CloseUIFrom(curr.Value);
                    break;
                }
            }
        }
    }
}
