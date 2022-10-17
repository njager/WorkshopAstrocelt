using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InspectorBasedDictionarySpriteString))]
[CanEditMultipleObjects]
public class DictionaryEditor : Editor
{
    SerializedProperty keyValue;
    SerializedProperty dataValue;

    void OnEnable()
    {
        keyValue = serializedObject.FindProperty("keys");
        dataValue = serializedObject.FindProperty("values");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(keyValue);
        EditorGUILayout.PropertyField(dataValue);
        serializedObject.ApplyModifiedProperties();
    }
}
