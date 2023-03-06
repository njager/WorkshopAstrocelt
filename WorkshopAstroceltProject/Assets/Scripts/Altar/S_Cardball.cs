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
    public bool c_b_locatedInSpawn; 

    [Header("Graphic References")]
    public GameObject c_redGraphic;
    public GameObject c_blueGraphic;
    public GameObject c_yellowGraphic;
    public GameObject c_whiteGraphic;

    [Header("Text Objects")]
    public TextMeshProUGUI c_cardballText;

    [Header("Test Object to Use")]
    public S_TooltipTemplate tl_cardballTemplate;

    [Header("Mouse Enter Check")]
    public bool tl_b_mouseEntered;

    // Private variables
    private S_Global g_global;

    private bool c_b_pauseBool; 

    private void Awake()
    {
        g_global = S_Global.Instance;

        g_global.g_ls_cardBallPrefabs.Add(this);

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
        Debug.Log("Cardball setting up");

        //check if the energy cost should be increased
        if (g_global.g_enemyState.GetMagicianAbilityBool())
        {
            Debug.Log("I da BICH");
            c_i_cardEnergyCost += g_global.g_enemyState.GetMagicianAbilityValue();
        }

        // set all positions to false and then turn on based off of the tags
        c_b_locatedInFirstPosition = false;
        c_b_locatedInSecondPosition = false;
        c_b_locatedInThirdPosition = false;
        c_b_locatedInFourthPosition = false;
        c_b_locatedInFifthPosition = false;
        c_b_locatedInSpawn = false;

        if (transform.parent.tag == "CardballPosition1") { c_b_locatedInFirstPosition = true; }
        else if (transform.parent.tag == "CardballPosition2") { c_b_locatedInSecondPosition = true; }
        else if (transform.parent.tag == "CardballPosition3") { c_b_locatedInThirdPosition = true; }
        else if (transform.parent.tag == "CardballPosition4") { c_b_locatedInFourthPosition = true; }
        else if (transform.parent.tag == "CardballPosition5") { c_b_locatedInFifthPosition = true; }
        else if (transform.parent.tag == "CardballSpawnPosition") { c_b_locatedInSpawn = true; }
        else { Debug.Log("Cardball not spawned in Altar!"); }

        // Then set the graphics
        c_b_redCardball = false;
        c_redGraphic.SetActive(false);
        c_b_blueCardball = false;
        c_blueGraphic.SetActive(false);
        c_b_yellowCardball = false;
        c_yellowGraphic.SetActive(false);
        c_b_colorlessCardball = false;
        c_whiteGraphic.SetActive(false);


        if (c_cardData.RedColorType) // Check if Card is Red
        {
            // Cardball is Red
            c_b_redCardball = true;
            c_redGraphic.SetActive(true);
        }
        else if (c_cardData.BlueColorType) // Check if card is Blue
        {
            // Cardball is Blue
            c_b_blueCardball = true;
            c_blueGraphic.SetActive(true);
        }
        else if (c_cardData.YellowColorType) // Check if card is Yellow
        {
            // Cardball is Yellow
            c_b_yellowCardball = true;
            c_yellowGraphic.SetActive(true);
        }
        else if (c_cardData.WhiteColorType) // Check if card is Colorless
        {
            // Cardball is Colorless
            c_b_colorlessCardball = true;
            c_whiteGraphic.SetActive(true);
        }
        else { Debug.Log("Card data is null!"); }

        // Then determine the energy cost
        c_i_cardEnergyCost = c_cardData.EnergyCost;

        //Update text
        c_cardballText.text = "" + c_i_cardEnergyCost;

        // Then lastly the card name and body(for altar use)
        c_cardName = c_cardData.CardName;
        c_cardBody = c_cardData.BodyText;
    }


    /// <summary>
    /// Function to turn on all the card ball ui once the card ball moves into the proper position
    /// </summary>
    public void RevealCardBallDetails()
    {
        if (c_cardData.RedColorType) // Check if Card is Red
        {
            // Cardball is Red
            c_b_redCardball = true;
            c_redGraphic.SetActive(true);
        }
        else if (c_cardData.BlueColorType) // Check if card is Blue
        {
            // Cardball is Blue
            c_b_blueCardball = true;
            c_blueGraphic.SetActive(true);
        }
        else if (c_cardData.YellowColorType) // Check if card is Yellow
        {
            // Cardball is Yellow
            c_b_yellowCardball = true;
            c_yellowGraphic.SetActive(true);
        }
        else if (c_cardData.WhiteColorType) // Check if card is Colorless
        {
            // Cardball is Colorless
            c_b_colorlessCardball = true;
            c_whiteGraphic.SetActive(true);
        }
        else { Debug.Log("Card data is null!"); }

        // Then determine the energy cost
        c_i_cardEnergyCost = c_cardData.EnergyCost;

        //Update text
        c_cardballText.text = "" + c_i_cardEnergyCost;

        // Then lastly the card name and body(for altar use)
        c_cardName = c_cardData.CardName;
        c_cardBody = c_cardData.BodyText;
    }

    /// <summary>
    /// Method to take a cardball and convert it to a card
    /// - Josh
    /// </summary>
    public void CardballToCard()
    {
        Debug.Log("CardballToCard() called");

        Debug.Log(c_cardData);

        // Determine transform
        Transform _whereToSpawnCard = g_global.g_cardHolder.transform;
        
        // Spawn Card 
        GameObject c_card = Instantiate(c_cardTemplate, Vector3.zero, Quaternion.identity);

        //Debug.Log(c_card.transform.parent);

        c_card.transform.SetParent(_whereToSpawnCard, false);

        //set the scale of spawned cards
        c_card.transform.localScale = new Vector3(10f, 10f, 10f);

        // Grab the script from this cardball
        S_Card _cardScript = c_card.GetComponent<S_Card>();

        // Send information From Template
        _cardScript.FetchCardData(c_cardData);

        g_global.g_altar.c_b_cardSpawned = true;

        // Delete the cardball
        TrueDeleteCardball();
    }


    /// <summary>
    /// loops for the size of the cardball value
    /// decrements each iteration
    /// delays the countdown until zero and then calls delete cardball
    /// -Thoman
    /// </summary>
    
    public IEnumerator EnergyTextDecrement()
    {
        int energy_constant = c_i_cardEnergyCost;
        for (int i = energy_constant; i >=0; i--)
        {
            c_cardballText.text = "" + i;
            yield return new WaitForSeconds(.5f);
        }
        c_b_pauseBool = true;
        yield return c_b_pauseBool == true;
    }


    /// <summary>
    /// Deletes this cardball but is called when all cardballs get deleted
    /// </summary>
    /// <returns></returns>
    public IEnumerator DeleteAllCardballs()
    {
        //Debug.Log("DEBUG: Cardball Deletion Triggered");
        g_global.g_ls_cardBallPrefabs.Remove(this);
        
        yield return StartCoroutine(g_global.g_altar.MoveAndDeleteAllCardBalls(gameObject, g_global.g_altar.GetCardBeingActiveBool()));
        //StartCoroutine(CarballDestroyVFX())
    }

    public void TrueDeleteCardball() 
    {
        Debug.Log("True Delete");
        Destroy(this.gameObject);
    }

    /// <summary>
    /// Set the energy cost, have it adjust up or down for a given value
    /// false for subtract
    /// true for add
    /// - Josh
    /// </summary>
    /// <param name="_operation"></param>
    /// <param name="_value"></param>
    public void AdjustEnergyCost(bool _operation, int _value) 
    {
        if(_operation == false) 
        {
            c_i_cardEnergyCost -= _value;
        }
        else 
        {
            c_i_cardEnergyCost += _value;
        }

        // Set the text again
        c_cardballText.text = "" + c_i_cardEnergyCost;
    }

    /// <summary>
    /// Toggle altar text on when mouse enters Cardball
    /// also adjust the borders based off of the color
    /// </summary>
    public void OnHoverEnter()
    {
        if (g_global.g_altar.c_b_cardSpawned == false)
        {
            //Debug.Log("DEBUG: Toggle Cardball info on Altar - on");
            g_global.g_altar.c_tx_cardName.text = c_cardName;
            g_global.g_altar.c_tx_cardBody.text = c_cardBody;

            //change the upper card name
            g_global.g_altar.c_tx_upperCardName.text = c_cardName;

            //turn all borders off
            g_global.g_altar.a_redBorder.SetActive(false);
            g_global.g_altar.a_blueBorder.SetActive(false);
            g_global.g_altar.a_yellowBorder.SetActive(false);
            g_global.g_altar.a_colorlessBorder.SetActive(false);

            //turn all borders off
            g_global.g_altar.a_upperRedBorder.SetActive(false);
            g_global.g_altar.a_upperBlueBorder.SetActive(false);
            g_global.g_altar.a_upperYellowBorder.SetActive(false);
            g_global.g_altar.a_upperColorlessBorder.SetActive(false);

            // Toggle Border based off cardball color
            if (c_b_redCardball == true) // If Red
            {
                // Toggle Red border
                g_global.g_altar.a_redBorder.SetActive(true);
                g_global.g_altar.a_upperRedBorder.SetActive(true);
            }
            else if (c_b_blueCardball == true) // If Blue
            {
                // Toggle Blue border
                g_global.g_altar.a_blueBorder.SetActive(true);
                g_global.g_altar.a_upperBlueBorder.SetActive(true);
            }
            else if (c_b_yellowCardball == true) // If Yellow
            {
                // Toggle Yellow border
                g_global.g_altar.a_yellowBorder.SetActive(true);
                g_global.g_altar.a_upperYellowBorder.SetActive(true);
            }
            else if (c_b_colorlessCardball == true) // If Colorless
            {
                // Toggle Colorless border
                g_global.g_altar.a_colorlessBorder.SetActive(true);
                g_global.g_altar.a_upperColorlessBorder.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Toggle altar text off when mouse exits Cardball
    /// turn off the borders
    /// - Josh
    /// </summary>
    public void OnHoverExit()
    {
        if (g_global.g_altar.c_b_cardSpawned == false)
        {
            //Debug.Log("DEBUG: Toggle Cardball info on Altar - off");
            g_global.g_altar.c_tx_cardName.text = "";
            g_global.g_altar.c_tx_cardBody.text = "";

            //chang upper textbox to blank
            g_global.g_altar.c_tx_upperCardName.text = "";

            // Turn off all borders
            g_global.g_altar.a_redBorder.SetActive(false);
            g_global.g_altar.a_blueBorder.SetActive(false);
            g_global.g_altar.a_yellowBorder.SetActive(false);
            g_global.g_altar.a_colorlessBorder.SetActive(false);

            // Turn off all upper borders
            g_global.g_altar.a_upperRedBorder.SetActive(false);
            g_global.g_altar.a_upperBlueBorder.SetActive(false);
            g_global.g_altar.a_upperYellowBorder.SetActive(false);
            g_global.g_altar.a_upperColorlessBorder.SetActive(false);
        }
    }

    /// <summary>
    /// Call for VFX after cardball deleted
    /// -Thoman
    /// </summary>
    public IEnumerator CarballDestroyVFX()
    {
        Debug.Log("VFX call");
        yield return new WaitForSeconds(2);
    }
}
