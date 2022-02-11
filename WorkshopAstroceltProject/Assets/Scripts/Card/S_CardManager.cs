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

    private void Awake()
    {
        g_global = S_Global.Instance;

        for(int i = p_i_handSize; p_i_handSize <= p_i_handSizeLimit; i++)
        {
            int _index = randomNumGenerator();
            GameObject _randomCard = g_global.g_CardDatabase.GetCard(_index);
            g_global.lst_p_playerDeck.Add(_randomCard);
        }
    }

    public int randomNumGenerator()
    {
        System.Random rand = new System.Random();
        int _number = rand.Next(0, (p_i_handSize + 1));
        return _number;
    }
}
