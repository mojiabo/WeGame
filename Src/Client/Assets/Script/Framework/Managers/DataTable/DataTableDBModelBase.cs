using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Framework
{
    /// <summary>
    /// 数据表管理基类
    /// </summary>
    public abstract class DataTableDBModelBase<T, P>
    where T : class, new()
    where P : DataTableEntityBase
    {
        protected List<P> m_List;

        protected Dictionary<int, P> m_dic;

        public DataTableDBModelBase()
        {
            m_List = new List<P>();
            m_dic = new Dictionary<int, P>();
        }
        #region 需要子类实现的属性和方法
        /// <summary>
        /// 数据表名
        /// </summary>
        public abstract string DataTableName { get; }

        /// <summary>
        /// 加载数据列表
        /// </summary>
        protected abstract void LoadList(MMO_MemoryStream ms);
        #endregion

        /// <summary>
        /// 加载数据表数据
        /// </summary>
        public void LoadData()
        {
            //1.拿到表格buffer
            byte[] buffer = GameEntry.Resource.GetFileBuffer(string.Format("{0}/Download/DataTable/{1}.bytes", GameEntry.Resource.LocalFilePath,DataTableName));
            //2.加载数据
            using (MMO_MemoryStream ms=new MMO_MemoryStream(buffer))
            {
                LoadList(ms);
            }
            GameEntry.Event.CommonEvent.Dispatch(SystemEventId.LoadDataOneTableCompelete,DataTableName);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<P> GetList()
        {
            return m_List;
        }
        /// <summary>
        /// 根据编号查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public P Get(int id)
        {
            if (m_dic.ContainsKey(id))
            {
                return m_dic[id];
            }
            return null;
        }

        public void Clear()
        {
            m_List.Clear();
            m_dic.Clear();
        }
    }
}
