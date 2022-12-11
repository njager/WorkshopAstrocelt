using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using System.Linq;

//[CustomEditor(typeof(ThreeElementTuple))]
public class ThreeElementTupleEditor : MonoBehaviour //Editor
{
    /*public List<(string, int, int)> tupleList;

    private void OnEnable()
    {

        var serializedMyList = serializedObject.FindProperty("tupleList");

        var array = new (string, int, int)[serializedMyList.arraySize];
        for (int i = 0; i < serializedMyList.arraySize; i++)
        {
            var element = serializedMyList.GetArrayElementAtIndex(i);

            var item1 = element.FindPropertyRelative("Item1");
            var item2 = element.FindPropertyRelative("Item2");
            var item3 = element.FindPropertyRelative("Item3");

            array[i] = (item1.stringValue, item2.intValue, item3.intValue);
        }

        tupleList = new List<(string, int, int)>(array);
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();
        for (int i = 0; i < tupleList.Count; i++)
        {
            var tuple = tupleList[i];
            EditorGUILayout.BeginHorizontal();
            tuple.Item1 = EditorGUILayout.TextField("Element 0", tuple.Item1);
            tuple.Item2 = EditorGUILayout.IntField("Element 1", tuple.Item2);
            tuple.Item3 = EditorGUILayout.IntField("Element 2", tuple.Item3);
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }
    */
}
