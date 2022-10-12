using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInspectorBasedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField, HideInInspector]
    public List<TKey> keys = new List<TKey>();

    [SerializeField, HideInInspector]
    public List<TValue> values = new List<TValue>();

    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        this.Clear();
        for (int index = 0; index < this.keys.Count && index < this.values.Count; index++)
        {
            this[this.keys[index]] = this.values[index];
        }
    }

    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        // Clear out the values
        this.keys.Clear();
        this.values.Clear();

        foreach (var element in this)
        {
            this.keys.Add(element.Key);
            this.values.Add(element.Value);
        }
    }
}
