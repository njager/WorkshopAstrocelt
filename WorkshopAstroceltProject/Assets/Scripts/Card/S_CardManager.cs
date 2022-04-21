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
        for(int i=0; i<_deal; i++)
        {
            //prevent deck drawing if hand is too big
            if(g_global.ls_p_playerHand.Count() < p_i_handSizeLimit)
            {
                //if the deck is empty move the cards over
                if (g_global.ls_p_playerDeck.Count() <= 0)
                {
                    ShuffleGraveToDeck();
                }
                
                //get a random number and get a random key from the deck
                int _rand = randomNumGenerator(g_global.ls_p_playerDeck.Count()-1);
                int _cardKey = g_global.ls_p_playerDeck[_rand];

                //remove a key from the deck and add it to the grave
                g_global.ls_p_playerDeck.RemoveAt(_rand);
                g_global.lst_p_playerGrave.Add(_cardKey);

                //get the card game object and add it to the player hand
                S_CardTemplate _randomCard = g_global.g_CardDatabase.GetCard(_cardKey);

                //add the card to the hand
                g_global.ls_p_playerHand.Add(_randomCard);

            }
        }
    }

    /// <summary>
    /// This gets called from turn manager and is the new hand the player gets at a start of a turn
    /// - Riley
    /// </summary>
    public void NewHand()
    {
        //remove all the previous cards from the field
        //foreach(GameObject _card in g_global.ls_p_playerHand)
        //{
        //    Destroy(_card);
        //}

        //clear the player hand
        g_global.ls_p_playerHand.Clear();

        //deal the new cards
        DealCards(p_i_drawPerTurn);
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
            g_global.ls_p_playerDeck.Add(_cardKey);
        }
        //clear the grave
        g_global.lst_p_playerGrave.Clear();
    }

    /// <summary>
    /// Create the card from the template and instantiate it to outside the field.
    /// This gets called from the dealcards function
    /// -Riley Halloran
    /// </summary>
    /// <param name="_cardTemplate"></param>
    public void InstanceCard(S_CardTemplate _cardTemplate)
    {
        GameObject playerCard = Instantiate(c_cardPrefabTemplate, new Vector3(0f, 0f, 0f), Quaternion.identity);
        playerCard.GetComponent<S_Card>().FetchCardData(_cardTemplate);
        playerCard.transform.SetParent(c_cardHolder.gameObject.transform, false);

        //control where it attaches to
        playerCard.gameObject.transform.SetAsFirstSibling();

        //change the altar text
        LoadFirstCard(playerCard);
    }

    /// <summary>
    /// This method removes the first card from the list (Which is the last card). 
    /// This gets called from the Card Dragger function
    /// -Riley Halloran
    /// </summary>
    /// <param name="_cardTemplate"></param>
    public void RemoveFirstCard()
    {
        g_global.ls_p_playerHand.RemoveAt(0);
    }


    /// <summary>
    /// This is where the call to change the altar text is
    /// -Riley Halloran
    /// </summary>
    public void LoadFirstCard(GameObject _card)
    {
        S_Card _cardScript = _card.GetComponent<S_Card>();

        //g_global.g_altar.ChangeCard(_cardScript);
    }
}
