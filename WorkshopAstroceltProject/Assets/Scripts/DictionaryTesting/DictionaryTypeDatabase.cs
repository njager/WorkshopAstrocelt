using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class DictionaryTypeDatabase
{
    /////////////////////////////--------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Sprite-String Dictionary \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    [Serializable]
    public class InspectorBasedDictionarySpriteString : AbstractInspectorBasedDictionary<Sprite, string> 
    {
        //[SerializeField]
        //protected List<Sprite> SpriteEntries = new List<Sprite>();

        //[SerializeField]
        //protected List<string> FlavorTextEntries = new List<string>();
    }
}
