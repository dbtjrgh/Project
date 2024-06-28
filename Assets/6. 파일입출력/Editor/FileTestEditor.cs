using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FileTest))]
public class FileTestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        FileTest fileTest = target as FileTest;

        if(GUILayout.Button("Save"))
        {
            fileTest.Save();
            Debug.Log("Save 버튼 눌림");
        }
        if (GUILayout.Button("Load"))
        {
            fileTest.Load();
        }
    }
}
