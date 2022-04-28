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

    [Header("Graphic References")]
    public GameObject c_redGraphic;
    public GameObject c_blueGraphic;
    public GameObject c_yellowGraphic;
    public GameObject c_whiteGraphic;

    [Header("Text Objects")]
    public TextMeshProUGUI c_cardballText; 

    // Private variables
    private S_Global g_global;

    private void Awake()
    {
        g_global = S_Global.Instance;

        g_global.ls_cardBallPrefabs.Add(this);

        //CardballSetup();
    }

    // Cardballs then just need to move, probably do in S_Altar

    /// <summary>
    /// Determine the card position in the altar, then it's color, card energy cost, and card name from card template, set cardholder
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

        // Then the graphics
        if (c_cardData.RedColorType) // Check if Card is Red
        {
            // Cardball is Red
            c_b_redCardball = true;
            c_redGraphic.SetActive(true);

            // Rest are false
            c_b_blueCardball = false;
            c_blueGraphic.SetActive(false);
            c_b_yellowCardball = false;
            c_yellowGraphic.SetActive(false);
            c_b_colorlessCardball = false;
            c_whiteGraphic.SetActive(false);
        }
        else if (c_cardData.BlueColorType) // Check if card is Blue
        {
            // Cardball is Blue
            c_b_blueCardball = true;
            c_blueGraphic.SetActive(true);

            // Rest are false
            c_b_redCardball = false;
            c_redGraphic.SetActive(false);
            c_b_yellowCardball = false;
            c_yellowGraphic.SetActive(false);
            c_b_colorlessCardball = false;
            c_whiteGraphic.SetActive(false);
        }
        else if (c_cardData.YellowColorType) // Check if card is Yellow
        {
            // Cardball is Yellow
            c_b_yellowCardball = true;
            c_yellowGraphic.SetActive(true);

            // Rest are false
            c_b_redCardball = false;
            c_redGraphic.SetActive(false);
            c_b_blueCardball = false;
            c_blueGraphic.SetActive(false);
            c_b_colorlessCardball = false;
            c_whiteGraphic.SetActive(false);
        }
        else if (c_cardData.WhiteColorType) // Check if card is Colorless
        {
            // Cardball is Colorless
            c_b_colorlessCardball = true;
            c_whiteGraphic.SetActive(true);

            // Rest are false
            c_b_redCardball = false;
            c_redGraphic.SetActive(false);
            c_b_blueCardball = false;
            c_blueGraphic.SetActive(false);
            c_b_yellowCardball = false;
            c_yellowGraphic.SetActive(false);
        }
        else
        {
            Debug.Log("Card data is null!");
        }

        // Then determine the energy cost
        c_i_cardEnergyCost = c_cardData.EnergyCost;

        //Update text
        c_cardballText.text = "" + c_i_cardEnergyCost;

        // Then lastly the card name and body(for altar use)
        c_cardName = c_cardData.CardName;
        c_cardBody = c_cardData.BodyText;
    }

    /// <summary>
    /// Cardball gets converted to card
    /// - Josh
    /// </summary>
    public void CardballToCard()
    {
        // Spawn Card 
        GameObject c_card = Instantiate(c_cardTemplate, Vector3.zero, Quaternion.identity);
        c_card.transform.SetParent(g_global.g_altar.c_cardHolder.transform, false);

        // Load information From Template
        S_Card _cardScript = c_card.GetComponent<S_Card>();
        _cardScript.FetchCardData(c_cardData);
        g_global.g_altar.c_b_cardSpawned = true;

        // Fulfilled Function
        //StartCoroutine(WaitToHide(c_card));

        DeleteCardball();
    }

    public IEnumerator WaitToHide(GameObject _card)
    {
        yield return new WaitForSeconds(3f);
        _card.SetActive(false);

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
        Debug.Log("DEBUG: Cardball Deletion Triggered");
        g_global.ls_cardBallPrefabs.Remove(this);
        g_global.lst_p_playerGrave.Add(c_cardData.CardDatabaseID);
        StartCoroutine(g_global.g_altar.WaitForCardballDeletionToMove(gameObject));
    }

    /// <summary>
    /// Toggle altar text on when mouse enters Cardball
    /// </summary>
    public void OnHoverEnter()
    {
        if (g_global.g_altar.c_b_cardSpawned == false)
        {
            //Debug.Log("DEBUG: Toggle Cardball info on Altar - on");
            g_global.g_altar.c_tx_cardName.text = c_cardName;
            g_global.g_altar.c_tx_cardBody.text = c_cardBody;

            // Toggle Border based off cardball color
            if (c_b_redCardball == true) // If Red
            {
                // Toggle Red border
                g_global.g_altar.a_redBorder.SetActive(true);

                // Make sure rest are off
                g_global.g_altar.a_blueBorder.SetActive(false);
                g_global.g_altar.a_yellowBorder.SetActive(false);
                g_global.g_altar.a_colorlessBorder.SetActive(false);
            }
            else if (c_b_blueCardball == true) // If Blue
            {
                // Toggle Blue border
                g_global.g_altar.a_blueBorder.SetActive(true);

                // Make sure rest are off
                g_global.g_altar.a_redBorder.SetActive(false);
                g_global.g_altar.a_yellowBorder.SetActive(false);
                g_global.g_altar.a_colorlessBorder.SetActive(false);
            }
            else if (c_b_yellowCardball == true) // If Yellow
            {
                // Toggle Yellow border
                g_global.g_altar.a_yellowBorder.SetActive(true);

                // Make sure rest are off
                g_global.g_altar.a_redBorder.SetActive(false);
                g_global.g_altar.a_blueBorder.SetActive(false);
                g_global.g_altar.a_colorlessBorder.SetActive(false);
            }
            else if (c_b_colorlessCardball == true) // If Colorless
            {
                // Toggle Colorless border
                g_global.g_altar.a_colorlessBorder.SetActive(true);

                // Make sure rest are off
                g_global.g_altar.a_redBorder.SetActive(false);
                g_global.g_altar.a_blueBorder.SetActive(false);
                g_global.g_altar.a_yellowBorder.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Toggle altar text off when mouse exits Cardball
    /// - Josh
    /// </summary>
    public void OnHoverExit()
    {
        if (g_global.g_altar.c_b_cardSpawned == false)
        {
            //Debug.Log("DEBUG: Toggle Cardball info on Altar - off");
            g_global.g_altar.c_tx_cardName.text = "";
            g_global.g_altar.c_tx_cardBody.text = "";

            // Turn off all borders
            g_global.g_altar.a_redBorder.SetActive(false);
            g_global.g_altar.a_blueBorder.SetActive(false);
            g_global.g_altar.a_yellowBorder.SetActive(false);
            g_global.g_altar.a_colorlessBorder.SetActive(false);
        }
    }
}
