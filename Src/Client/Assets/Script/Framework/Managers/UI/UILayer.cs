using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class UILayer
    {
        private Dictionary<byte, ushort> m_UILayerDic;

        public UILayer()
        {
            m_UILayerDic = new Dictionary<byte, ushort>();
        }

        /// <summary>
        /// 初始化基础排序
        /// </summary>
        /// <param name="uIGroups"></param>
        internal void Init(UIGroup[] uIGroups)
        {
            int len = uIGroups.Length;
            for (int i = 0; i < len; i++)
            {
                UIGroup group = uIGroups[i];

                m_UILayerDic[group.Id] = group.BaseOrder;
            }
        }

        /// <summary>
        /// 设置层级
        /// </summary>
        /// <param name="fromBase"></param>
        /// <param name="isAdd"></param>
        internal void SetSortOrder(UIFormBase fromBase,bool isAdd)
        {
            if (isAdd)
            {
                m_UILayerDic[fromBase.UIGroupId]++;
            }
            else
            {
                m_UILayerDic[fromBase.UIGroupId]--;
            }

            fromBase.CurrCanvas.sortingOrder = m_UILayerDic[fromBase.UIGroupId];
        }
    }
}
