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

    public Dictionary<int, GameObject> dict_CardDatabase = new Dictionary<int, GameObject>();

    void Awake()
    {
        g_global = S_Global.Instance;
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
    public GameObject GetCard(int _index)
    {
        GameObject _returnCard = dict_CardDatabase[_index];
        return _returnCard;
    }

    public void InstanceCard()
    {
        //Instantiate()
    }
}
