using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(RunOnTheFly))]
public class RunOnTheFlyEditor : Editor 
{
    SerializedProperty saveDataSlot;
    // SerializedProperty simulateFromMenu;

    void OnEnable()
    {
        saveDataSlot = serializedObject.FindProperty("saveDataSlot");
        // simulateFromMenu = serializedObject.FindProperty("simulateFromMenu");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // EditorGUILayout.PropertyField(simulateFromMenu);
        EditorGUILayout.PropertyField(saveDataSlot);

        serializedObject.ApplyModifiedProperties();

        RunOnTheFly rotfScript = (RunOnTheFly)target;
        if(GUILayout.Button("Load From Save"))
        {
            rotfScript.LoadFromSaveSlot();
        }
        else if (GUILayout.Button("Create New Save"))
        {
            rotfScript.CreateNewSave();
        }
    }
}