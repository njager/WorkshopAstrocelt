using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class S_CardDatabase : MonoBehaviour
{
    //Ask will how to iterate objects into a list
    private S_Global g_global;

    [Header("Vertical Slice Deck")]
    public S_CardTemplate cardScript0; // Barkskin, ID 0
    public S_CardTemplate cardScript1; // Bludgeon, ID 1
    public S_CardTemplate cardScript2; // Deflect, ID 2
    public S_CardTemplate cardScript3; // Dig In, ID 3
    public S_CardTemplate cardScript4; // Flair, ID 4
    public S_CardTemplate cardScript5; // Fortify, ID 5
    public S_CardTemplate cardScript6; // Lacerate, ID 6
    public S_CardTemplate cardScript7; // Preserve, ID 7
    public S_CardTemplate cardScript8; // Demoralize, ID 8 // Previously reposte
    public S_CardTemplate cardScript9; // Stone Strike, ID 9

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
        dict_CardDatabase.Add(0, cardScript0);
        dict_CardDatabase.Add(1, cardScript1);
        dict_CardDatabase.Add(2, cardScript2);
        dict_CardDatabase.Add(3, cardScript3);
        dict_CardDatabase.Add(4, cardScript4);
        dict_CardDatabase.Add(5, cardScript5);
        dict_CardDatabase.Add(6, cardScript6);
        dict_CardDatabase.Add(7, cardScript7);
        dict_CardDatabase.Add(8, cardScript8);
        dict_CardDatabase.Add(9, cardScript9);
        dict_CardDatabase.Add(10, battleRewardCard1); // Add Fury
        dict_CardDatabase.Add(11, battleRewardCard2); // Add Thornshield
        dict_CardDatabase.Add(12, battleRewardCard1); // Add Freeze
        dict_CardDatabase.Add(13, battleRewardCard2); // Add Reflect
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

    /// <summary>
    /// Add the battle 1 reward cards to the deck for use in hand
    /// - Josh
    /// </summary>
    public void AddBattle1RewardCards()
    {

        // Add them to deck
        g_global.g_ls_p_playerDeck.Add(10);
        g_global.g_ls_p_playerDeck.Add(11);
    }


    /// <summary>
    /// Add the battle 2 reward cards to the deck for use in hand
    /// - Josh
    /// </summary>
    public void AddBattle2RewardCards()
    {

        // Add them to deck
        g_global.g_ls_p_playerDeck.Add(12);
        g_global.g_ls_p_playerDeck.Add(13);
    }

}
