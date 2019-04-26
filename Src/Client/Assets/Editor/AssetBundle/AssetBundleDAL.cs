using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class AssetBundleDAL
{
    /// <summary>
    /// XML路径
    /// </summary>
    private string m_Path;
    /// <summary>
    /// 返回的数据集合
    /// </summary>
    private List<AssetBundleEntity> m_list = null;

    public AssetBundleDAL(string path)
    {
        m_Path = path;

        m_list = new List<AssetBundleEntity>();
    }

    public List<AssetBundleEntity> GetList()
    {
        m_list.Clear();
        //读取xml 吧数据添加到m_list
        XDocument xDoc = XDocument.Load(m_Path);

        XElement root = xDoc.Root;

        XElement AssetBundleNode = root.Element("AssetBundle");

        IEnumerable<XElement> lst = AssetBundleNode.Elements("Item");

        int index = 0;
        foreach (var item in lst)
        {
            AssetBundleEntity entity = new AssetBundleEntity();
            entity.Key = "Key" + ++index;
            entity.Name = item.Attribute("Name").Value;
            entity.Tag = item.Attribute("Tag").Value;
            entity.IsFirstData = item.Attribute("IsFirstData").Value.Equals("True",System.StringComparison.CurrentCultureIgnoreCase);
            entity.IsFolder = item.Attribute("IsFolder").Value.Equals("True", System.StringComparison.CurrentCultureIgnoreCase);

            IEnumerable<XElement> pathLit = item.Elements("Path");

            foreach (XElement path in pathLit)
            {
                entity.PathList.Add( path.Attribute("Value").Value);
            }

            m_list.Add(entity);
        }


        return m_list;
    }

}
