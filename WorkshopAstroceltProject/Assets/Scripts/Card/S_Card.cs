using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMODUnity;
using FMOD.Studio;

public class S_Card : MonoBehaviour
{
    //Private varibales
    private Sprite c_cardBaseImage;
    private S_Global g_global;
    
    [Header("Template it's built on")]
    public S_CardTemplate c_cardTemplate;
    
    [Header("Card Index")]
    public int c_i_cardIndex; // Not utilized at this time, may be helpful for something like score?

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
    public string c_str_color;

    [Header("Card Graphic Assets")]
    public Sprite c_redArtGraphic; // If Red, toggle this
    public Sprite c_blueArtGraphic; // If Blue, toggle this
    public Sprite c_yellowArtGraphic; // If Yellow, toggle this 
    public Sprite c_whiteArtGraphic; // If White, toggle this

    [Header("Num of Characters Affected")]
    public bool c_b_affectsPlayer;
    public bool c_b_affectsOne;
    public bool c_b_affectsAll;

    [Header("Main Effect Types")]
    public bool c_b_attackMainEffect;
    public bool c_b_shieldMainEffect;
    public bool c_b_uniqueMainEffect;

    [Header("Status Effect Triggers")]
    public bool c_b_noEffect;
    public bool c_b_bleedStatusEffect;
    public bool c_b_stunStatusEffect;
    public bool c_b_acidStatusEffect;
    public bool c_b_resistStatusEffect;
    public bool c_b_burnStatusEffect;
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

    [Header("Card Dragger References")]
    public S_CardDragger s_c_cardDraggerReference;

    public int c_i_cardID;

    [Header("Card Hover Height")]
    public float i_hoverHeight;

    [Header("Zoom Card Scalars")]
    public float i_hoverX;
    public float i_hoverY;

    public GameObject cv_canvas;
    
    private GameObject c_zoomCard;

    // Will likely need to toggle bools for icons on the card itself at some point - Note for later

    //Functions
    private void Awake()
    {
        g_global = S_Global.Instance;

        //Separate cards, ended up not being needed
        g_global.c_i_cardIDNum += 1;
        c_i_cardID = g_global.c_i_cardIDNum;
        c_cardBaseImage = GetComponent<Image>().sprite;

        cv_canvas = GameObject.Find("GreyboxCanvas");

        if (c_b_redColorType) { c_str_color = "red"; }
        else if (c_b_yellowColorType) { c_str_color = "yellow"; }
        else if (c_b_blueColorType) { c_str_color = "blue"; }
        else if(c_b_whiteColorType) { c_str_color = "white"; }
    }

    /// <summary>
    /// To make it clearer for myself offloading the start behavior to another function
    /// -Josh
    /// </summary>
    /// <param name="_cardData"></param>
    public void FetchCardData(S_CardTemplate _cardData)
    {
        c_cardTemplate = _cardData;

        this.GetComponent<S_CardDragger>().c_card = _cardData;

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
        c_b_affectsAll = _cardData.AffectsAllOtherCharacters;

        //Toggle Main Effects
        c_b_attackMainEffect = _cardData.AttackEffect;
        c_b_shieldMainEffect = _cardData.ShieldEffect;
        c_b_uniqueMainEffect = _cardData.UniqueEffect;

        //Toggle Status Effects
        c_b_noEffect = _cardData.NoEffect;
        c_b_bleedStatusEffect = _cardData.BleedStatusEffect;
        c_b_stunStatusEffect = _cardData.StunStatusEffect;
        c_b_acidStatusEffect = _cardData.AcidStatusEffect;
        c_b_resistStatusEffect = _cardData.ResistStatusEffect;
        c_b_burnStatusEffect = _cardData.BurnStatusEffect;
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
    /// Play the card based on if it was dropped onto player or enemy
    /// - Josh
    /// </summary>
    public void PlayCard(GameObject _character)
    {
        if (c_b_attackMainEffect == true)
        {
            print(c_i_energyCost);
            if(g_global.g_energyManager.useEnergy(c_i_energyCost, c_str_color))
            {
                if (_character.GetComponent<S_Enemy>() != null)
                {
                    TriggerAttackCard(_character.GetComponent<S_Enemy>());
                }
                else
                {
                    //c_cardrectTransform.position; 
                }
            }
        }
        else if(c_b_shieldMainEffect == true)
        {
            g_global.g_ConstellationManager.i_energyCount -= c_i_energyCost;
            if (_character.GetComponent<S_Player>() != null) //Had to do this for enemy, might as well do for player
            {
                TriggerShieldCard(_character.GetComponent<S_Player>());
            }
        }
    }

    /// <summary>
    /// If Milestone 1 Card type is attack, do attack function on selected enemy
    /// </summary>
    private void TriggerAttackCard(S_Enemy _enemy)
    {
        _enemy.EnemyAttacked(_enemy.e_str_enemyType, c_i_effectValue);
        PlayAttackSound();
        DeleteCard();
    }

    /// <summary>
    /// If Milestone 1 Card type is shield, do shield function on player
    /// </summary>
    private void TriggerShieldCard(S_Player _player)
    {
        _player.PlayerShielded(c_i_effectValue);
        DeleteCard();
    }

    /// <summary>
    /// Delete the card played
    /// </summary>
    private void DeleteCard()
    {
        g_global.g_turnManager.attackSound.SetActive(false);
        Destroy(gameObject); // Remove card from play
    }

    /// <summary>
    /// Attack sound
    /// </summary>
    public void PlayAttackSound()
    {
        g_global.g_turnManager.attackSound.SetActive(true);
    }

    public void ResetPosition()
    {
        s_c_cardDraggerReference.c_cardTransform.position = s_c_cardDraggerReference.c_v3_initialPosition;
    }

    /// <summary>
    /// Function that creates a hover card when moused over
    /// -Riley Halloran
    /// </summary>
    public void OnHoverEnter()
    {
        //Instantiate a new card based off the location of the mouse and the hoverHeight
        c_zoomCard = Instantiate(gameObject, new Vector2(transform.position.x, transform.position.y + i_hoverHeight), Quaternion.identity);
        c_zoomCard.transform.SetParent(cv_canvas.transform, false);

        //scale the transform of the rect
        RectTransform _rect = c_zoomCard.GetComponent<RectTransform>();
        _rect.sizeDelta = new Vector2(_rect.sizeDelta.x * i_hoverX, _rect.sizeDelta.y * i_hoverY);
    }

    /// <summary>
    /// Function that destroys the hover card when the mouse leavess
    /// -Riley Halloran
    /// </summary>
    public void OnHoverExit()
    {
        Destroy(c_zoomCard);
    }
}
