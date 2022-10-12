using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public abstract class AbstractInspectorBasedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField]
    private List<TKey> keyList = new List<TKey>();

    [SerializeField]
    private List<TValue> valueList = new List<TValue>();

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        this.Clear();
        for (int index = 0; index < this.keyList.Count && index < this.valueList.Count; index++)
        {
            this[this.keyList[index]] = this.valueList[index];
        }
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        // Clear out the values
        this.keyList.Clear();
        this.valueList.Clear();

        foreach (var element in this)
        {
            this.keyList.Add(element.Key);
            this.valueList.Add(element.Value);
        }
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    
    public void SetKeyList(List<TKey> _newKeyList) 
    {
        keyList = _newKeyList; 
    }

    public void SetValuesList(List<TValue> _newValueList) 
    {
        valueList = _newValueList;
    }
}
