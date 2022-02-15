using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_Card : MonoBehaviour
{
    private ScriptableObject cardTemplate;
    private S_Global global;

    public int c_i_cardIndex; 

    [Header("Card Basics")]
    public string c_str_cardName;
    public string c_str_headerText;
    public string c_str_bodyText;
    public string c_str_flavorText;

    public int c_i_energyCost; //Cast to a string for energy cost text
    public int c_i_effectValue;

    public int c_i_cardRarity;
     
    [Header("Card Graphic References")]
    public GameObject c_childGraphic; // The graphic itself
    public TextMeshProUGUI c_tx_header; // Header Textbox
    public TextMeshProUGUI c_tx_body; // Body Text Box
    public TextMeshProUGUI c_tx_flavor; // Flavor Text Box
    public TextMeshProUGUI c_tx_energyCost; // Energy Cost for card

    [Header("Color Types")]
    public bool c_b_redColorType;
    public bool c_b_blueColorType;
    public bool c_b_greenColorType;
    public bool c_b_whiteColorType;

    [Header("Effect Types")]
    public bool c_b_damageEffectType;
    public bool c_b_healEffectType;
    public bool c_b_shieldEffectType;

    [Header("Status Effect Triggers")]
    public bool c_b_bleedStatusEffectType;
    public bool c_b_stunnedStatusEffectType;
    public bool c_b_poisonStatusEffectType;

    private void Awake()
    {
        global = S_Global.Instance;
    }
    
    private void Start()
    {
        
    }
}
