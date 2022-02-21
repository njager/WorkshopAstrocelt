using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_Card : MonoBehaviour
{
    public S_CardTemplate c_cardTemplate;
    private S_Global global;

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

    [Header("Card Graphic Options")]
    public GameObject c_childRedGraphic; // If Red, toggle
    public GameObject c_childBlueGraphic; // If Blue, toggle
    public GameObject c_childYellowGraphic; // If Yellow, toggle
    public GameObject c_childWhiteGraphic; // If White, toggle

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
    public bool c_b_poisonStatusEffect;
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

    // Will likely need to toggle bools for icons on the card itself at some point - Note for later

    //Functions
    private void Awake()
    {
        global = S_Global.Instance;
    }
    
    private void Start()
    {
        //FetchCardData(c_cardTemplate);
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
        c_b_poisonStatusEffect = _cardData.PoisonStatusEffect;
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
            c_childRedGraphic.SetActive(true);
            c_childBlueGraphic.SetActive(false);
            c_childYellowGraphic.SetActive(false);
            c_childWhiteGraphic.SetActive(false);
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
            c_childRedGraphic.SetActive(false);
            c_childBlueGraphic.SetActive(true);
            c_childYellowGraphic.SetActive(false);
            c_childWhiteGraphic.SetActive(false);
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
            c_childRedGraphic.SetActive(false);
            c_childBlueGraphic.SetActive(false);
            c_childYellowGraphic.SetActive(true);
            c_childWhiteGraphic.SetActive(false);
        }
        //White Type
        else if (_cardData.BlueColorType == true)
        {
            //Toggle Bools
            c_b_redColorType = false;
            c_b_blueColorType = false;
            c_b_yellowColorType = false;
            c_b_whiteColorType = true;

            //Toggle Graphics
            c_childRedGraphic.SetActive(false);
            c_childBlueGraphic.SetActive(false);
            c_childYellowGraphic.SetActive(false);
            c_childWhiteGraphic.SetActive(true);
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
}
