using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class S_CardManager : MonoBehaviour
{
    private S_Global g_global;
    //Shuffler 

    [Header("Card Variables")]
    public int p_i_handSizeLimit;
    public int p_i_startHandSize;
    public int p_i_drawPerTurn;

    public GameObject c_cardHolder;

    public GameObject c_cardPrefabTemplate;

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    /// <summary>
    /// This Function returns a random int from 0 to the given range
    /// this is used for getting cards from the deck
    /// System.Random kept getting negative values, unsure how, changed to different Random usage
    /// - Riley & Josh
    /// </summary>
    public int randomNumGenerator(int _num)
    {
        int _number = Random.Range(0, _num);
        return _number;
    }

    public S_CardTemplate GetCardFromDeck()
    {
        //if the deck is empty move the cards over
        if (g_global.g_ls_p_playerDeck.Count() <= 0)
        {
            ShuffleGraveToDeck();
        }

        //get a random number and get a random key from the deck
        int _rand = randomNumGenerator(g_global.g_ls_p_playerDeck.Count() - 1);
        int _cardKey = g_global.g_ls_p_playerDeck[_rand];

        //remove a key from the deck (gets added to the grave when it gets deleted)
        g_global.g_ls_p_playerDeck.RemoveAt(_rand);

        //get the card game object and add it to the player hand
        //Debug.Log("The card key is " + _cardKey);
        S_CardTemplate _randomCard = g_global.g_cardDatabase.GetCard(_cardKey);

        //add card to grave
        AddToGrave(_cardKey);

        return _randomCard;
    }

    /// <summary>
    /// Function takes a key and adds it to grave
    /// </summary>
    /// <param name="_cardKey"></param>
    public void AddToGrave(int _cardKey)
    {
        g_global.g_ls_p_playerGrave.Add(_cardKey);
    }

    /// <summary>
    /// This Function gets cards from the grave and adds all of them into the player deck
    /// - Riley
    /// </summary>
    public void ShuffleGraveToDeck()
    {
        Debug.Log("Grave to Hand");

        //loop through the grave and add it to the deck
        foreach (int _cardKey in g_global.g_ls_p_playerGrave)
        {
            g_global.g_ls_p_playerDeck.Add(_cardKey);
        }

        //clear the grave
        ClearPlayerGrave();
    }

    /// <summary>
    /// Manual clear function, other one wasn't working
    /// - Josh
    /// </summary>
    public void ClearPlayerGrave()
    {
        g_global.g_ls_p_playerGrave.Clear();
    }
}
