using UnityEngine;
using System.Collections;
using GoogleSheetsToUnity;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using GoogleSheetsToUnity.ThirdPary;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class TestData : ScriptableObject
{
    public string associatedSheet = "";
    public string associatedWorksheet = "";

    public List<string> items = new List<string>();
    
    public List<string> KEY = new List<string>();
    internal void UpdateStats(List<GSTU_Cell> list, string name)
    {
        items.Clear();
        string Character = "", Expression = "", line = "", Background = "", Command = "";
        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i].columnId)
            {
                case "Character":
                {
                        Character = list[i].value;
                    break;
                }
                case "Expression":
                {
                    Expression = list[i].value;
                    break;
                }
                case "line":
                {
                        line = list[i].value;
                    break;
                }
                case "Background":
                    {
                        Background = list[i].value;
                        break;
                    }
                case "Command":
                    {
                        Command = list[i].value;
                        break;
                    }
            }
        }
        Debug.Log($"{name}의 점수 수학:{Character} 국어:{Expression} 영어:{line} {Background}{Command}");
    }

}

[CustomEditor(typeof(TestData))]
public class DataEditor : Editor
{
    TestData data;

    void OnEnable()
    {
        data = (TestData)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Label("Read Data Examples");

        if (GUILayout.Button("Pull Data Method One"))
        {
            UpdateStats(UpdateMethodOne);
        }
    }

    void UpdateStats(UnityAction<GstuSpreadSheet> callback, bool mergedCells = false)
    {
        SpreadsheetManager.Read(new GSTU_Search(data.associatedSheet, data.associatedWorksheet), callback, mergedCells);
    }

    void UpdateMethodOne(GstuSpreadSheet ss)
    {
        //data.UpdateStats(ss.rows["Jim"]);
        foreach (string dataName in data.KEY)
            data.UpdateStats(ss.rows[dataName], dataName);
        EditorUtility.SetDirty(target);
    }
    
}