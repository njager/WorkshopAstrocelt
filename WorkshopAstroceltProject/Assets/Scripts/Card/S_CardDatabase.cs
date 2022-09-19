using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class S_CardDatabase : MonoBehaviour
{
    //Ask will how to iterate objects into a list
    private S_Global g_global;

    public List<S_CardTemplate> cardList;

    [Header("Battle 1 Rewards")]
    public S_CardTemplate battleRewardCard1; // Fury, ID 10
    public S_CardTemplate battleRewardCard2; // Thornshield, ID 11

    [Header("Battle 2 Rewards")]
    public S_CardTemplate battleRewardCard3; // Freeze, ID 12
    public S_CardTemplate battleRewardCard4; // Reflect, ID 13

    [Header("Reward Card Bools for Scene Toggle")]
    public bool encounter2;
    public bool encounter3;

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
