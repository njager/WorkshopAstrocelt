using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMODUnity;
using FMOD.Studio;

public class S_Card : MonoBehaviour
{
    [Header("Template it's built on")]
    public S_CardTemplate c_cardTemplate;
    private Image c_cardBaseImage;
    private S_Global g_global;

    // Index from database;
    public int c_i_cardIndex;

    [Header("Card Basics")]
    public string c_str_cardName;
    public string c_str_headerText;
    public string c_str_bodyText;
    public string c_str_flavorText;

    // Number values
    public int c_i_energyCost; //Cast to a string for energy cost text
    public int c_i_effectValue; // Takes precedence for int calculations 
    
    // Rarity
    public float c_f_cardRarity;

    [Header("Color Types")]
    public bool c_b_redColorType;
    public bool c_b_blueColorType;
    public bool c_b_yellowColorType;
    public bool c_b_whiteColorType;

    [Header("Card Graphic Assets")]
    public Image c_redArtGraphic; // If Red, toggle this
    public Image c_blueArtGraphic; // If Blue, toggle this
    public Image c_yellowArtGraphic; // If Yellow, toggle this 
    public Image c_whiteArtGraphic; // If White, toggle this

    [Header("Num of Characters Affected")]
    public bool c_b_affectsPlayer;
    public bool c_b_affectsOne;
    public bool c_b_affectsTwo;

    [Header("Main Effect Types")]
    public bool c_b_attackMainEffect;
    public bool c_b_shieldMainEffect;
    public bool c_b_uniqueMainEffect;

    [Header("Status Effect Triggers")]
    public bool c_b_noEffect;
    public bool c_b_bleedStatusEffect;
    public bool c_b_stunStatusEffect;
    public bool c_b_acidStatusEffect;
    public bool c_b_empowerStatusEffect;
    public bool c_b_luckyStatusEffect;
    public bool c_b_restrainStatusEffect;
    public bool c_b_burnStatusEffect;
    public bool c_b_shockStatusEffect;
    public bool c_b_drawStatusEffect;
    public bool c_b_siphonStatusEffect;
    public bool c_b_fralitizeStatusEffect;
    public bool c_b_manipulateStatusEffect;

    [Header("Potential Status Effect Values")]
    public float c_f_damagePercentage; // If not using effect value, use this
    public float c_f_turnCount;

    [Header("Card Graphic References")]
    public TextMeshProUGUI c_tx_header; // Header Textbox
    public TextMeshProUGUI c_tx_body; // Body Text Box
    public TextMeshProUGUI c_tx_flavor; // Flavor Text Box
    public TextMeshProUGUI c_tx_energyCost; // Energy Cost for card

    public int c_i_cardID; 

    // Will likely need to toggle bools for icons on the card itself at some point - Note for later

    //Functions
    private void Awake()
    {
        g_global = S_Global.Instance;

        //Separate cards, ended up not being needed
        g_global.c_i_cardIDNum += 1;
        c_i_cardID = g_global.c_i_cardIDNum;
        c_cardBaseImage = GetComponent<Image>();
    }

    /// <summary>
    /// To make it clearer for myself offloading the start behavior to another function
    /// -Josh
    /// </summary>
    /// <param name="_cardData"></param>
    public void FetchCardData(S_CardTemplate _cardData)
    {
        //Load strings
        c_str_cardName = _cardData.CardName;
        c_str_headerText = _cardData.HeaderText;
        c_str_bodyText = _cardData.BodyText;
        c_str_flavorText = _cardData.FlavorText;

        //Load ints/floats
        c_i_energyCost = _cardData.EnergyCost;
        c_i_effectValue = _cardData.EffectValue;
        c_f_cardRarity = _cardData.CardRarity;

        //Toggle Characters affected
        c_b_affectsPlayer = _cardData.AffectsPlayer;
        c_b_affectsOne = _cardData.Affects1Character;
        c_b_affectsTwo = _cardData.Affects2Characters;

        //Toggle Main Effects
        c_b_attackMainEffect = _cardData.AttackEffect;
        c_b_shieldMainEffect = _cardData.ShieldEffect;
        c_b_uniqueMainEffect = _cardData.UniqueEffect;

        //Toggle Status Effects
        c_b_noEffect = _cardData.NoEffect;
        c_b_bleedStatusEffect = _cardData.BleedStatusEffect;
        c_b_stunStatusEffect = _cardData.StunStatusEffect;
        c_b_acidStatusEffect = _cardData.AcidStatusEffect;
        c_b_empowerStatusEffect = _cardData.EmpowerStatusEffect;
        c_b_restrainStatusEffect = _cardData.RestrainStatusEffect;
        c_b_burnStatusEffect = _cardData.BurnStatusEffect;
        c_b_shockStatusEffect = _cardData.ShockStatusEffect;
        c_b_drawStatusEffect = _cardData.DrawStatusEffect;
        c_b_siphonStatusEffect = _cardData.SiphonStatusEffect;
        c_b_fralitizeStatusEffect = _cardData.FralitizeStatusEffect;
        c_b_manipulateStatusEffect = _cardData.ManipulateStatusEffect; 

        //Toggle Color Types, will need to adapt for synergies

        //Red Type
        if (_cardData.RedColorType == true)
        {
            //Toggle Bools
            c_b_redColorType = true;
            c_b_blueColorType = false;
            c_b_yellowColorType = false;
            c_b_whiteColorType = false;

            //Toggle Graphics
            c_cardBaseImage = c_redArtGraphic;
        }
        //Blue Type
        else if (_cardData.BlueColorType == true)
        {
            //Toggle Bools
            c_b_redColorType = false;
            c_b_blueColorType = true;
            c_b_yellowColorType = false;
            c_b_whiteColorType = false;

            //Toggle Graphics
            c_cardBaseImage = c_blueArtGraphic;
        }
        //Yellow Type
        else if (_cardData.YellowColorType == true)
        {
            //Toggle Bools
            c_b_redColorType = false;
            c_b_blueColorType = false;
            c_b_yellowColorType = true;
            c_b_whiteColorType = false;

            //Toggle Graphics
            c_cardBaseImage = c_redArtGraphic;
        }
        //White Type
        else if (_cardData.WhiteColorType == true)
        {
            //Toggle Bools
            c_b_redColorType = false;
            c_b_blueColorType = false;
            c_b_yellowColorType = false;
            c_b_whiteColorType = true;

            //Toggle Graphics
            c_cardBaseImage = c_whiteArtGraphic;
        }

        SetText();

    }

    public void SetText()
    {
        c_tx_header.text = c_str_headerText;
        c_tx_body.text = c_str_bodyText;
        c_tx_flavor.text = c_str_flavorText;
        c_tx_energyCost.text = c_i_energyCost.ToString();
    }

    [Header("Unique Cards")]
    public bool c_b_unqiuePayback;


    /// <summary>
    /// Check position of card
    /// </summary>
    public void OnMouseDown()
    {
        if(transform.parent.CompareTag("Bottom"))
        {
            if(g_global.g_ConstellationManager.i_energyCount >= c_i_energyCost)
            {
                PlayCard();
            }
            else
            {
                Debug.Log("You do not have enough energy to play that card!");
            }
        }
        else
        {
            GameObject _currentBottomCard = g_global.g_cardManager.bottomPosition.transform.GetChild(0).gameObject;

            //Card is on top
            if (transform.parent.CompareTag("Top"))
            {
                transform.SetParent(g_global.g_cardManager.bottomPosition.transform, false); // Move this card to bottom of the stack
                _currentBottomCard.transform.SetParent(g_global.g_cardManager.topPosition.transform, false);
                Debug.Log("Please Select the card at the bottom for play!");
            }

            //Card is in next slot
            if (transform.parent.CompareTag("Next"))
            {
                transform.SetParent(g_global.g_cardManager.bottomPosition.transform, false); // Move this card to bottom of the stack
                _currentBottomCard.transform.SetParent(g_global.g_cardManager.nextPosition.transform, false);
                Debug.Log("Please Select the card at the bottom for play!");
            }

            //Card is in after slot
            if (transform.parent.CompareTag("After"))
            {
                transform.SetParent(g_global.g_cardManager.bottomPosition.transform, false); // Move this card to bottom of the stack
                _currentBottomCard.transform.SetParent(g_global.g_cardManager.afterPosition.transform, false);
                Debug.Log("Please Select the card at the bottom for play!");
            }

            //Card is in close slot
            if (transform.parent.CompareTag("Close"))
            {
                transform.SetParent(g_global.g_cardManager.bottomPosition.transform, false); // Move this card to bottom of the stack
                _currentBottomCard.transform.SetParent(g_global.g_cardManager.closePosition.transform, false);
                Debug.Log("Please Select the card at the bottom for play!");
            }
        }
    }

    /// <summary>
    /// If card is on the bottom play card
    /// Also check for enemy selection for attack cards
    /// Presumed all shield cards are on player
    /// - Josh
    /// </summary>
    private void PlayCard()
    {
        if (c_b_attackMainEffect == true)
        {
            if (g_global.g_selectorManager.e_enemySelected == null)
            {
                Debug.Log("Please select an enemy to use this card on!");
                return;
            }
            else
            {
                g_global.g_ConstellationManager.i_energyCount -= c_i_energyCost;
                TriggerAttackCard();
            }
        }
        else if(c_b_shieldMainEffect == true)
        {
            g_global.g_ConstellationManager.i_energyCount -= c_i_energyCost;
            TriggerShieldCard();
        }
        

    }

    /// <summary>
    /// If Milestone 1 Card type is attack, do attack function on selected enemy
    /// </summary>
    private void TriggerAttackCard()
    {
        g_global.g_selectorManager.e_enemySelected.EnemyAttacked(g_global.g_selectorManager.e_enemySelected.e_str_enemyType, c_i_effectValue);
        PlayAttackSound();
        DeleteCard();
    }

    /// <summary>
    /// If Milestone 1 Card type is shield, do shield function on player
    /// </summary>
    private void TriggerShieldCard()
    {
        g_global.g_player.PlayerShielded(c_i_effectValue);
        DeleteCard();
    }

    /// <summary>
    /// Delete the card played
    /// </summary>
    private void DeleteCard()
    {
        MoveCards();
        g_global.g_turnManager.attackSound.SetActive(false);
        Destroy(gameObject); // Remove card from play
    }

    /// <summary>
    /// Move deck down 1
    /// </summary>
    private void MoveCards() // Works fully
    {
        if (g_global.g_cardManager.topPosition.transform.childCount > 0) //Move card from top to after
        {
            g_global.g_cardManager.topPosition.transform.GetChild(0).transform.SetParent(g_global.g_cardManager.nextPosition.transform, false);
        }
        if (g_global.g_cardManager.nextPosition.transform.childCount > 0) // Move card from next to after
        {
            g_global.g_cardManager.nextPosition.transform.GetChild(0).transform.SetParent(g_global.g_cardManager.afterPosition.transform, false);
        }
        if (g_global.g_cardManager.afterPosition.transform.childCount > 0) // Move card from after to close
        {
            g_global.g_cardManager.afterPosition.transform.GetChild(0).transform.SetParent(g_global.g_cardManager.closePosition.transform, false);
        }
        if (g_global.g_cardManager.closePosition.transform.childCount > 0) // Move card from close to bottom
        {
            g_global.g_cardManager.closePosition.transform.GetChild(0).transform.SetParent(g_global.g_cardManager.bottomPosition.transform, false);
        }
    }


    /// <summary>
    /// Attack sound
    /// </summary>
    public void PlayAttackSound()
    {
        g_global.g_turnManager.attackSound.SetActive(true);
    }
}
