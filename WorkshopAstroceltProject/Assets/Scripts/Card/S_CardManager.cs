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

    private void Start()
    {
        g_global = S_Global.Instance;

        //once the game starts give the players some cards
        NewHand();
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

    /// <summary>
    /// This Function removes cards from the deck and adds them to the player hand
    /// - Riley
    /// </summary>
    public void DealCards(int _deal)
    {
        //loop for how many times the player is drawing
        for(int i=0; i<_deal; i++)
        {
            //prevent deck drawing if hand is too big
            if(g_global.g_ls_p_playerHand.Count() < p_i_handSizeLimit)
            {
                //if the deck is empty move the cards over
                if (g_global.g_ls_p_playerDeck.Count() <= 0)
                {
                    ShuffleGraveToDeck();
                }
                
                //get a random number and get a random key from the deck
                int _rand = randomNumGenerator(g_global.g_ls_p_playerDeck.Count()-1);
                int _cardKey = g_global.g_ls_p_playerDeck[_rand];

                //remove a key from the deck (gets added to the grave when it gets deleted)
                g_global.g_ls_p_playerDeck.RemoveAt(_rand);

                //get the card game object and add it to the player hand
                S_CardTemplate _randomCard = g_global.g_CardDatabase.GetCard(_cardKey);

                //add the card to the hand
                g_global.g_ls_p_playerHand.Add(_randomCard);

            }
        }
    }

    /// <summary>
    /// This gets called from turn manager and is the new hand the player gets at a start of a turn
    /// - Riley
    /// </summary>
    public void NewHand()
    {
        //clear the hand
        ClearPlayerHand();

        //deal the new cards now that all cards are in the deck
        DealCards(p_i_drawPerTurn);
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
    /// This method removes the first card from the list
    /// This gets called from global
    /// -Riley Halloran
    /// </summary>
    /// <param name="_cardTemplate"></param>
    public void RemoveFirstCard()
    {
        g_global.g_ls_p_playerHand.RemoveAt(0);
    }

    /// <summary>
    /// Manual clear function, other one wasn't working
    /// - Josh
    /// </summary>
    public void ClearPlayerHand() 
    {
        g_global.g_ls_p_playerHand.Clear();
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
