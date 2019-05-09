using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Framework
{
    public class UIPool
    {
        /// <summary>
        /// 对象池中的列表
        /// </summary>
        private LinkedList<UIFromBase> m_UIFromList;

        public UIPool()
        {
            m_UIFromList = new LinkedList<UIFromBase>();
        }

        /// <summary>
        /// 对象池中获取对象
        /// </summary>
        /// <param name="uiFromId"></param>
        /// <returns></returns>
        internal UIFromBase Dequeue(int uiFromId)
        {
            for (LinkedListNode<UIFromBase>curr= m_UIFromList.First; curr!=null; curr=curr.Next)
            {
                if (curr.Value.UIFromId==uiFromId)
                {
                    m_UIFromList.Remove(curr.Value);
                    return curr.Value;
                }
            }
            return null;
        }

        /// <summary>
        /// 回池
        /// </summary>
        /// <param name="uIFrom"></param>
        internal void Enqueue(UIFromBase uIFrom)
        {
            uIFrom.gameObject.SetActive(false);
            m_UIFromList.AddLast(uIFrom);
        }

        /// <summary>
        /// 检查释放
        /// </summary>
        internal void CheckClear()
        {
            for (LinkedListNode<UIFromBase> curr = m_UIFromList.First; curr != null;)
            {
                if (!curr.Value.IsLock&&Time.time>(curr.Value.CloseTime+GameEntry.UI.UIExpire))
                {
                    Object.Destroy(curr.Value.gameObject);

                    LinkedListNode<UIFromBase> next = curr.Next;
                    m_UIFromList.Remove(curr);
                    curr = next;
                }
                else
                {
                    curr = curr.Next;
                }
            }
        }

        internal void CheackOpenUI()
        {
            if (m_UIFromList.Count<=GameEntry.UI.UIPoolMaxCount)
            {
                return;
            }

            for (LinkedListNode<UIFromBase> curr = m_UIFromList.First; curr != null;)
            {
                if (m_UIFromList.Count <= GameEntry.UI.UIPoolMaxCount)
                {
                    break;
                }

                if (!curr.Value.IsLock)
                {
                    Object.Destroy(curr.Value.gameObject);

                    LinkedListNode<UIFromBase> next = curr.Next;
                    m_UIFromList.Remove(curr);
                    curr = next;
                }
                else
                {
                    curr = curr.Next;
                }
            }
        }
    }
}
