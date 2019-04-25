using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Framework
{
    [CustomEditor(typeof(PoolComponent),true)]
    public class PoolComponentInspector : Editor
    {
        /// <summary>
        /// 释放间隔 属性
        /// </summary>
        private SerializedProperty m_ClearInterval = null;
        /// <summary>
        /// 对象池分组 属性
        /// </summary>
        private SerializedProperty m_GameObjectPoolGroups = null;
        

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            PoolComponent poolComponent=base.target as PoolComponent;

            int clearInterval = (int)EditorGUILayout.Slider("清空类对象池间隔", m_ClearInterval.intValue,10,1800);
            if (clearInterval != m_ClearInterval.intValue)
            {
                poolComponent.m_ClearInterval = clearInterval;
            }
            else
            {
                m_ClearInterval.intValue = clearInterval;
            }
            //================类对象池开始================
            GUILayout.Space(10);
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("类名");
            GUILayout.Label("池中数量",GUILayout.Width(50));
            GUILayout.Label("常驻数量",GUILayout.Width(50));
            GUILayout.EndHorizontal();

            if (poolComponent!=null&&poolComponent.PoolManager!=null)
            {
                foreach (var item in poolComponent.PoolManager.ClassObjectPool.InspectorDic)
                {
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label(item.Key.Name);
                    GUILayout.Label(item.Value.ToString(), GUILayout.Width(50));

                    int key = item.Key.GetHashCode();
                    byte resideCount = 0;
                    poolComponent.PoolManager.ClassObjectPool.ClassObjectCount.TryGetValue(key, out resideCount);

                    GUILayout.Label(resideCount.ToString(), GUILayout.Width(50));
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();
            GUILayout.Space(10);
            //================类对象池结束================

            //================变量计数开始================
            GUILayout.Space(10);
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("变量");
            GUILayout.Label("数量", GUILayout.Width(50));
            GUILayout.EndHorizontal();
           
            if (poolComponent != null)
            {
                foreach (var item in poolComponent.VarObjectInspectorDic)
                {
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label(item.Key.Name);
                    GUILayout.Label(item.Value.ToString(), GUILayout.Width(50));
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();
            GUILayout.Space(10);
            //================变量计数结束================

            EditorGUILayout.PropertyField(m_GameObjectPoolGroups,true);
            serializedObject.ApplyModifiedProperties();
            Repaint();
        }

        private void OnEnable()
        {
            m_ClearInterval = serializedObject.FindProperty("m_ClearInterval");
            m_GameObjectPoolGroups = serializedObject.FindProperty("m_GameObjectPoolGroups");

            serializedObject.ApplyModifiedProperties();

        }

    }
}
