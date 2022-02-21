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

    [Header("Card Positions")]
    public GameObject topPosition;
    public GameObject nextPosition;
    public GameObject afterPosition;
    public GameObject closePosition;
    public GameObject bottomPosition;


    [Header("Scriptable Objects")]
    public S_CardTemplate cardScript0; // Slash1, ID 0
    public S_CardTemplate cardScript1; // Slash2, ID 1
    public S_CardTemplate cardScript2; // Bludgeon1, ID 2
    public S_CardTemplate cardScript3; // Bludgeon2, ID 3
    public S_CardTemplate cardScript4; // Pierce, ID 4
    public S_CardTemplate cardScript5; // Block, ID 5
    public S_CardTemplate cardScript6; // Block, ID 6
    public S_CardTemplate cardScript7; // Dodge, ID 7
    public S_CardTemplate cardScript8; // Dodge, ID 8
    public S_CardTemplate cardScript9; // Bulwark, ID 9

    public Dictionary<int, S_CardTemplate> dict_CardDatabase = new Dictionary<int, S_CardTemplate>();

    void Awake()
    {
        g_global = S_Global.Instance;

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

        for(int i=0; i < 10; i++)
        {
            g_global.lst_p_playerDeck.Add(i);
        }
    }

    void Start()
    {
        
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
