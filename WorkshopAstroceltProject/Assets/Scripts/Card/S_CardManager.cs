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

    public GameObject topPosition;
    public GameObject nextPosition;
    public GameObject afterPosition;
    public GameObject closePosition;
    public GameObject bottomPosition;

    public GameObject c_cardPrefabTemplate;

    public int bullshit = 0;

    private void Start()
    {
        g_global = S_Global.Instance;

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
            if(g_global.lst_p_playerHand.Count() < p_i_handSizeLimit)
            {
                //if the deck is empty move the cards over
                if (g_global.lst_p_playerDeck.Count() <= 0)
                {
                    ShuffleGraveToDeck();
                }
                
                //get a random number and get a random key from the deck
                int _rand = randomNumGenerator(g_global.lst_p_playerDeck.Count);
                int _cardKey = g_global.lst_p_playerDeck[_rand];

                //remove a key from the deck and add it to the grave
                g_global.lst_p_playerDeck.RemoveAt(_rand);
                g_global.lst_p_playerGrave.Add(_cardKey);

                //get the card game object and add it to the player hand
                S_CardTemplate _randomCard = g_global.g_CardDatabase.GetCard(_cardKey);
                g_global.lst_p_playerHand.Add(_randomCard);
                
                
            }
        }
    }

    public void NewHand()
    {
        g_global.lst_p_playerHand.Clear();
        Destroy(topPosition.transform.GetChild(0).gameObject);
        Destroy(nextPosition.transform.GetChild(0).gameObject);
        Destroy(afterPosition.transform.GetChild(0).gameObject);
        Destroy(closePosition.transform.GetChild(0).gameObject);
        Destroy(bottomPosition.transform.GetChild(0).gameObject);

        DealCards(p_i_drawPerTurn);

        print(g_global.lst_p_playerHand.Count);

        foreach (S_CardTemplate card in g_global.lst_p_playerHand)
        {

            if (bullshit == 0) 
            { 
                InstanceCard(topPosition, card);
                bullshit++;
            }
            else if (bullshit == 1)
            {
                InstanceCard(nextPosition, card);
                bullshit++;
            }
            else if (bullshit == 2)
            {
                InstanceCard(afterPosition, card);
                bullshit++;
            }
            else if(bullshit == 3)
            {
                InstanceCard(closePosition, card);
                bullshit++;
            }
            else if (bullshit >= 4)
            {
                InstanceCard(bottomPosition, card);
                bullshit=0;
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

    public void InstanceCard(GameObject _position, S_CardTemplate _cardTemplate)
    {
        print("end");
        GameObject playerCard = Instantiate(c_cardPrefabTemplate, new Vector3(0f, 0f, 0f), Quaternion.identity);
        playerCard.GetComponent<S_Card>().FetchCardData(_cardTemplate);
        playerCard.transform.SetParent(_position.gameObject.transform, false);
    }
}
