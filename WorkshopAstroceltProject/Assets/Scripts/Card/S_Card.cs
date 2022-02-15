using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_Card : MonoBehaviour
{
    public ScriptableObject c_cardTemplate;
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
    public int c_i_cardRarity;

    [Header("Card Graphic Options")]
    public GameObject c_childRedGraphic; // If Red, toggle
    public GameObject c_childBlueGraphic; // If Blue, toggle
    public GameObject c_childYellowGraphic; // If Yellow, toggle
    public GameObject c_childWhiteGraphic; // If White, toggle

    [Header("Card Graphic References")]
    public TextMeshProUGUI c_tx_header; // Header Textbox
    public TextMeshProUGUI c_tx_body; // Body Text Box
    public TextMeshProUGUI c_tx_flavor; // Flavor Text Box
    public TextMeshProUGUI c_tx_energyCost; // Energy Cost for card

    [Header("Num of Characters Affected")]
    public bool c_b_affectsSelf;
    public bool c_b_affectsOne;
    public bool c_b_affectsTwo;

    [Header("Color Types")]
    public bool c_b_redColorType;
    public bool c_b_blueColorType;
    public bool c_b_greenColorType;
    public bool c_b_whiteColorType;

    [Header("Main Effect Types")]
    public bool c_b_damageMainEffect;
    public bool c_b_healMainEffect;
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

    [Header("Potential Status Effect Values")]
    public float c_f_damagePercentage; // If not usinf effect value, use this
    public float c_f_turnCount;

    private void Awake()
    {
        global = S_Global.Instance;
    }
    
    private void Start()
    {
        FetchCardData(c_cardTemplate);
    }

    public void FetchCardData(ScriptableObject _cardData)
    {

    }
}
