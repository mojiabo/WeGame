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
        private LinkedList<UIFormBase> m_OpenUIFormList;
        public UIManager()
        {
            m_OpenUIFormList = new LinkedList<UIFormBase>();

        }
        /// <summary>
        /// 打开一个窗体
        /// </summary>
        /// <param name="uIFromId">ID</param>
        /// <param name="userData">用户数据</param>
        internal void OpenUIForm(int uIFromId,object userData=null)
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

            UIFormBase formBase = GameEntry.UI.Dequeue(uIFromId); //以后去对象池取

            if (formBase==null)
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

                formBase = uiObj.transform.GetComponent<UIFormBase>();
                formBase.Init(entity.Id, entity.UIGroupId, entity.DisableUILayer == 1, entity.IsLock == 1, userData);
            }
            else
            {
                formBase.gameObject.SetActive(true);
                formBase.Open(userData);
            }

            m_OpenUIFormList.AddLast(formBase);
#endif

        }

        internal bool isExists(int uiFromId)
        {
            for (LinkedListNode<UIFormBase>curr= m_OpenUIFormList.First;curr!=null;curr=curr.Next)
            {
                if (curr.Value.UIFormId==uiFromId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 关闭UI窗口
        /// </summary>
        /// <param name="formBase"></param>
        internal void CloseUIForm(UIFormBase formBase)
        {
            m_OpenUIFormList.Remove(formBase);
            formBase.ToClose();
        }

        /// <summary>
        /// 根据UIFromId关闭UI窗口
        /// </summary>
        /// <param name="fromBase"></param>
        internal void CloseUIForm(int uiFromId)
        {
            for (LinkedListNode<UIFormBase> curr = m_OpenUIFormList.First; curr != null; curr = curr.Next)
            {
                if (curr.Value.UIFormId == uiFromId)
                {
                    CloseUIForm(curr.Value);
                    break;
                }
            }
        }
    }
}
