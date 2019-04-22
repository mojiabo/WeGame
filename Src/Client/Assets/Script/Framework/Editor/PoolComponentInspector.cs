using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Framework
{
    [CustomEditor(typeof(PoolComponent),true)]
    public class PoolComponentInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            PoolComponent poolComponent=base.target as PoolComponent;

            GUILayout.BeginHorizontal("box");
            GUILayout.Label("类名");
            GUILayout.Label("池中数量",GUILayout.Width(50));
            GUILayout.Label("常驻数量",GUILayout.Width(50));
            GUILayout.EndHorizontal();

            if (poolComponent==null||poolComponent.PoolManager==null)
            {
                return;
            }

            foreach (var item in poolComponent.PoolManager.ClassObjectPool.InspectorDic)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label(item.Key);
                GUILayout.Label(item.Value.ToString(), GUILayout.Width(50));
                GUILayout.Label("0", GUILayout.Width(50));
                GUILayout.EndHorizontal();
            }
            Repaint();
        }

    }
}
