using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public abstract class AbstractInspectorBasedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    [SerializeField]
    public List<TKey> keyList = new List<TKey>();

    [SerializeField]
    public List<TValue> valueList = new List<TValue>();

    [SerializeField] 
    public Dictionary<TKey, TValue> currentDictionary = new Dictionary<TKey, TValue>();

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        // Clear out the values
        keyList.Clear();
        valueList.Clear();

        foreach (var _elementPair in currentDictionary)
        {
            keyList.Add(_elementPair.Key);
            valueList.Add(_elementPair.Value);
        }
    }

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        currentDictionary = new Dictionary<TKey, TValue>();

        for (int i = 0; i < keyList.Count && i < valueList.Count; i++)
        {
            currentDictionary.Add(keyList[i], valueList[i]);
        }
    }
}
