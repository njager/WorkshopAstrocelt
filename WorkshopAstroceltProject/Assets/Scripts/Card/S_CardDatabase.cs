using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class S_CardDatabase : MonoBehaviour
{
    //Ask will how to iterate objects into a list
    private S_Global g_global;

    public int i_cardCount;

    public GameObject c_cardPrefabTemplate; 

    [Header("Scriptable Objects")]
    public ScriptableObject cardScript0; // temp, ID 0
    public ScriptableObject cardScript1; // temp, ID 1
    public ScriptableObject cardScript2; // temp, ID 2
    public ScriptableObject cardScript3; // temp, ID 3
    public ScriptableObject cardScript4; // temp, ID 4
    public ScriptableObject cardScript5; // temp, ID 5
    public ScriptableObject cardScript6; // temp, ID 6
    public ScriptableObject cardScript7; // temp, ID 7
    public ScriptableObject cardScript8; // temp, ID 8
    public ScriptableObject cardScript9; // temp, ID 9

    public Dictionary<int, GameObject> dict_CardDatabase = new Dictionary<int, GameObject>();

    void Awake()
    {
        g_global = S_Global.Instance;
    }

    /// <summary>
    /// Function will return the game object when given an indice
    /// -Josh
    /// </summary>
    /// <param name="_index"></param>
    /// <returns></returns>
    public GameObject GetCard(int _index)
    {
        GameObject _returnCard = dict_CardDatabase[_index];
        return _returnCard;
    }

    public void InstanceCard()
    {
        //Instantiate()
    }
}
