using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class S_CardDatabase : MonoBehaviour
{
    //Ask will how to iterate objects into a list
    private S_Global g_global;

    public List<S_CardTemplate> cardList;

    public Dictionary<int, S_CardTemplate> dict_CardDatabase = new Dictionary<int, S_CardTemplate>();

    void Awake()
    {
        g_global = S_Global.Instance;

        // Add initial cards to dictionary
        int _key = 0;

        foreach(S_CardTemplate card in cardList)
        {
            dict_CardDatabase.Add(_key, card);
        }

    }

    /// <summary>
    /// Function will return the game object when given an indice
    /// -Josh
    /// </summary>
    /// <param name="_index"></param>
    /// <returns></returns>
    public S_CardTemplate GetCard(int _index)
    {
        S_CardTemplate _returnCard = dict_CardDatabase[_index];
        return _returnCard;
    }
}
