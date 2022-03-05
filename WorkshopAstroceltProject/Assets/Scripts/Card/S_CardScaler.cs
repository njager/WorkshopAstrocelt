using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class S_CardScaler : MonoBehaviour
{
    private S_Global g_global;
    //Card to eventually modify the rest of the elements of the card object, including it's rigidbody

    [Header("Other card elements")]
    public S_Card c_card;
    public BoxCollider2D c_BoxCollider2D;

    [Header("Text Objects")]
    public GameObject c_headerTextObject;
    public GameObject c_bodyTextObject;
    public GameObject c_energyCostTextObject;
    public GameObject c_flavorTextObject;

    [Header("Text Components")]
    public TextMeshProUGUI c_tx_headerText;
    public TextMeshProUGUI c_tx_bodyText;
    public TextMeshProUGUI c_tx_energyCostText;
    public TextMeshProUGUI c_tx_flavorText;

    //Feel free to change any of these elements around, I just thought they may be useful - Josh

    // Start is called before the first frame update
    void Awake()
    {
        g_global = S_Global.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
