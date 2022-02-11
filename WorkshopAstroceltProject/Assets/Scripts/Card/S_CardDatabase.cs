using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CardDatabase : MonoBehaviour
{
    private S_Global g_global; 

    public int i_cardCount;

    [Header("Card Prefabs")]
    public GameObject cardPrefab0; //Wicked Strike, ID 0
    public GameObject cardPrefab1; //Wicked Strike, ID 0
    public GameObject cardPrefab2; //Wicked Strike, ID 0
    public GameObject cardPrefab3; //Wicked Strike, ID 0

    Dictionary<GameObject, int> dict_CardDatabase = new Dictionary<GameObject, int>();

    void Awake()
    {
        for (int i = 0; i < i_cardCount; i++)
        {
            dict_CardDatabase.Add(cardPrefab0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
