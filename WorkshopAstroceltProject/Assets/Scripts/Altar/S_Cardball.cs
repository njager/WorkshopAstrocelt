using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class S_Cardball : MonoBehaviour
{
    [Header("Card Name")]
    public string c_cardName;

    [Header("Card Body Text")]
    public string c_cardBody;

    [Header("Card Energy Cost")]
    public int c_i_cardEnergyCost;

    [Header("Card Template Prefab")]
    public GameObject c_cardTemplate;

    [Header("Card Data Object")]
    public S_CardTemplate c_cardData;

    [Header("Color Bools")]
    public bool c_b_redCardball;
    public bool c_b_blueCardball;
    public bool c_b_yellowCardball;
    public bool c_b_colorlessCardball;

    [Header("Position Status")]
    public bool c_b_locatedInFirstPosition;
    public bool c_b_locatedInSecondPosition;
    public bool c_b_locatedInThirdPosition;
    public bool c_b_locatedInFourthPosition;
    public bool c_b_locatedInFifthPosition;

    [Header("Image Sprite Assets")]
    public Sprite c_redImageAsset;
    public Sprite c_blueImageAsset;
    public Sprite c_yellowImageAsset;
    public Sprite c_colorlessImageAsset;

    [Header("Image Reference")]
    public Image c_cardballImage;

    [Header("Text Objects")]
    public TextMeshProUGUI c_cardballText; 

    // Private variables
    private S_Global g_global;

    private void Awake()
    {
        g_global = S_Global.Instance;

        g_global.ls_cardBallPrefabs.Add(this);
    }

    // Cardballs then just need to move, probably do in S_Altar

    /// <summary>
    /// Determine the card position in the altar, then it's color, card energy cost, and card name from card template
    /// Set those values accordingly
    /// - Josh
    /// </summary>
    public void CardballSetup()
    {
        // Determine position
        if (transform.parent.tag == "CardballPosition1")
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

        // Then the graphic
        if (c_cardData.RedColorType) // Check if Card is Red
        {
            // Cardball is Red
            c_b_redCardball = true;
            c_cardballImage.sprite = c_redImageAsset;

            // Rest are false
            c_b_blueCardball = false;
            c_b_yellowCardball = false;
            c_b_colorlessCardball = false; 
        }
        else if (c_cardData.BlueColorType) // Check if card is Blue
        {
            // Cardball is Blue
            c_b_blueCardball = true;
            c_cardballImage.sprite = c_blueImageAsset;

            // Rest are false
            c_b_redCardball = false;
            c_b_yellowCardball = false;
            c_b_colorlessCardball = false;
        }
        else if (c_cardData.YellowColorType) // Check if card is Yellow
        {
            // Cardball is Yellow
            c_b_yellowCardball = true;
            c_cardballImage.sprite = c_yellowImageAsset;

            // Rest are false
            c_b_blueCardball = false;
            c_b_redCardball = false;
            c_b_colorlessCardball = false;
        }
        else if (c_cardData.WhiteColorType) // Check if card is Colorless
        {
            // Cardball is Colorless
            c_b_colorlessCardball = true;
            c_cardballImage.sprite = c_colorlessImageAsset;

            // Rest are false
            c_b_blueCardball = false;
            c_b_yellowCardball = false;
            c_b_redCardball = false;
        }
        else
        {
            Debug.Log("Card data is null!");
        }

        // Then determine the energy cost
        c_i_cardEnergyCost = c_cardData.EnergyCost;

        //Update text
        c_cardballText.text = "" + c_i_cardEnergyCost;

        // Then lastly the card name (for altar use)
        c_cardName = c_cardData.CardName;
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
        _cardScript.FetchCardData(c_cardData);

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
