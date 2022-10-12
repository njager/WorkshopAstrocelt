using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DictionaryTypeDatabase
{
    /////////////////////////////--------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Sprite-String Dictionary \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    [System.Serializable]
    public class InspectorBasedDictionarySpriteString : AbstractInspectorBasedDictionary<Sprite, string> { }
}
