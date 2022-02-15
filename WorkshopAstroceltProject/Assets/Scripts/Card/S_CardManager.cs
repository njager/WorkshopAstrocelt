using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class S_CardManager : MonoBehaviour
{
    private S_Global g_global;
    //Shuffler 

    [Header("Card Variables")]
    public int p_i_handSize;
    public int p_i_handSizeLimit;
    public int p_i_startHandSize;
    public int p_i_drawPerTurn;

    private void Start()
    {
        g_global = S_Global.Instance;

        //this instantiates the player Hand with random cards
        for(int i = p_i_handSize; i <= p_i_handSizeLimit; i++)
        {
            int _index = randomNumGenerator(3);
            GameObject _randomCard = g_global.g_CardDatabase.GetCard(_index);
            g_global.lst_p_playerHand.Add(_randomCard);
        }

        DealCards(p_i_startHandSize);
    }

    /// <summary>
    /// This Function returns a random int from 0 to the given range
    /// this is used for getting cards from the deck
    /// - Riley
    /// </summary>
    public int randomNumGenerator(int _num)
    {
        System.Random rand = new System.Random();
        int _number = rand.Next(0, _num);
        return _number;
    }

    /// <summary>
    /// This Function gets cards from the deck and adds them to the player hand
    /// - Riley
    /// </summary>
    public void DealCards(int _deal)
    {
        //loop for how many times the player is drawing
        for(int i=0; i<=_deal; i++)
        {
            //prevent deck drawing if hand is too big
            if(g_global.lst_p_playerHand.Count() < p_i_handSizeLimit)
            {
                //if the deck is empty move the cards over
                if (g_global.lst_p_playerDeck.Count() <= 0)
                {
                    ShuffleGraveToDeck();
                }
                else
                {
                    //get a random number and get a random key from the deck
                    int _rand = randomNumGenerator(g_global.lst_p_playerDeck.Count);
                    int _cardKey = g_global.lst_p_playerDeck[_rand];

                    //remove a key from the deck and add it to the grave
                    g_global.lst_p_playerDeck.RemoveAt(_rand);
                    g_global.lst_p_playerGrave.Add(_cardKey);

                    //get the card game object and add it to the player hand
                    GameObject _randomCard = g_global.g_CardDatabase.GetCard(_cardKey);
                    g_global.lst_p_playerHand.Add(_randomCard);
                }
                
            }
        }
    }

    /// <summary>
    /// This Function gets cards from the grave and adds all of them into the player deck
    /// - Riley
    /// </summary>
    public void ShuffleGraveToDeck()
    {
        //loop through the grave and add it to the deck
        foreach (int _cardKey in g_global.lst_p_playerGrave)
        {
            g_global.lst_p_playerDeck.Add(_cardKey);
        }
        //clear the grave
        g_global.lst_p_playerGrave.Clear();
    }
}
