using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_Cardball : MonoBehaviour
{
    [Header("Card Template Prefab")]
    public GameObject c_cardTemplate;

    [Header("Card ScriptableObject")]
    public GameObject c_cardScriptableObject;

    [Header("Position Status")]
    public bool c_b_locatedInFirstPosition;
    public bool c_b_locatedInSecondPosition;
    public bool c_b_locatedInThirdPosition;
    public bool c_b_locatedInFourthPosition;
    public bool c_b_locatedInFifthPosition;

    [Header("Image Assets")]
    public Image redImageAsset;
    public Image blueImageAsset;
    public Image yellowImageAsset;
    public Image colorlessImageAsset; 

    private S_Global g_global;

    private void Awake()
    {
        g_global = S_Global.Instance;

        g_global.ls_cardBallPrefabs.Add(this);
    }

    private void Start()
    {
        if(transform.parent.tag == "CardballPosition1")
        {
            // Card ball is in first position
            c_b_locatedInFirstPosition = true;

            // Not in any other positions
            c_b_locatedInSecondPosition = false;
            c_b_locatedInThirdPosition = false;
            c_b_locatedInFourthPosition = false;
            c_b_locatedInFifthPosition = false; 
        }
        else if (transform.parent.tag == "CardballPosition2")
        {
            // Card ball is in first position
            c_b_locatedInSecondPosition = true;

            // Not in any other positions
            c_b_locatedInFirstPosition = false;
            c_b_locatedInThirdPosition = false;
            c_b_locatedInFourthPosition = false;
            c_b_locatedInFifthPosition = false;
        }
        else if (transform.parent.tag == "CardballPosition3")
        {
            // Card ball is in first position
            c_b_locatedInThirdPosition = true;

            // Not in any other positions
            c_b_locatedInFirstPosition = false;
            c_b_locatedInSecondPosition = false;
            c_b_locatedInFourthPosition = false;
            c_b_locatedInFifthPosition = false;
        }
        else if (transform.parent.tag == "CardballPosition4")
        {
            // Card ball is in first position
            c_b_locatedInFourthPosition = true;

            // Not in any other positions
            c_b_locatedInFirstPosition = false;
            c_b_locatedInSecondPosition = false;
            c_b_locatedInThirdPosition = false;
            c_b_locatedInFifthPosition = false;
        }
        else if (transform.parent.tag == "CardballPosition5")
        {
            // Card ball is in first position
            c_b_locatedInFifthPosition = true;

            // Not in any other positions
            c_b_locatedInFirstPosition = false;
            c_b_locatedInSecondPosition = false;
            c_b_locatedInThirdPosition = false;
            c_b_locatedInFourthPosition = false;
        }
        else
        {
            Debug.Log("Cardball not spawned in Altar!");
        }

        // Add the rest of these, properly parent cardballs when spawned in S_Altar
    }

    // Add in the graphic, graphic learning it's color from prefab
    // Cardballs then just need to move, probably do in S_Altar

    public void DetermineCardColor()
    {

    }

    /// <summary>
    /// - Josh
    /// </summary>
    public void CardballToCard()
    {
        // Spawn Card 
        GameObject c_card = Instantiate(c_cardTemplate, gameObject.transform.position, Quaternion.identity);
        c_card.transform.SetParent(g_global.g_altar.c_cardHolder.transform, false);

        // Load information From Template
        S_Card _cardScript = c_card.GetComponent<S_Card>();
        _cardScript.FetchCardData(c_cardScriptableObject.GetComponent<S_CardTemplate>());

        // Fulfilled Function
        DeleteCardball();
    }

    /// <summary>
    /// Now that it has built the card,
    /// delete the cardball
    /// - Josh
    /// </summary>
    public void DeleteCardball()
    {
        g_global.ls_cardBallPrefabs.Remove(this);
        Destroy(this);
    }
}
