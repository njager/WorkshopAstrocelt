using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class S_CardDatabase : MonoBehaviour
{
    //Ask will how to iterate objects into a list
    private S_Global g_global;

    public int i_cardCount;

    [Header("Card Prefabs")]
    public GameObject cardPrefab0; //Wicked Strike, ID 0
    public GameObject cardPrefab1; //Lasting Blow, ID 1
    public GameObject cardPrefab2; //Magic Armor, ID 2

    Dictionary<int, GameObject> dict_CardDatabase = new Dictionary<int, GameObject>();

    void Awake()
    {
        g_global = S_Global.Instance;
        dict_CardDatabase.Add(0, cardPrefab0);
        dict_CardDatabase.Add(1, cardPrefab0);
        dict_CardDatabase.Add(2, cardPrefab0);
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
}
