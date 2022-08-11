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
    private S_Global g_global;
    
    [Header("Template it's built on")]
    public S_CardTemplate c_cardTemplate;

    [Header("Image Asset")]
    public Image c_a_cardBackgroundImage;
    public Image c_a_cardArtImage;
    public Image c_a_cardForegroundImage;

    [Header("Card Database Index")]
    public int c_i_cardDataBaseIndex; 

    [Header("Card Basics")]
    public string c_str_cardName;
    public string c_str_headerText;
    public string c_str_bodyText;
    public string c_str_flavorText;

    [Header("Main Effect Numbers")]
    public int c_i_damageValue;
    public int c_i_shieldValue;
    public int c_i_energyCost; //Cast to a string for energy cost text

    [Header("Status Effect Numbers")]
    public int c_i_effectValue1; // Effect Value 1
    public int c_i_effectValue2; // Effect Value 2
    public int c_i_effectValue3; // Effect Value 3
    public float c_f_bleedDamagePercentage;

    [Header("Status Effect IDs")]
    public string c_str_statusEffectID1;
    public string c_str_statusEffectID2;
    public string c_str_statusEffectID3;

    [Header("Turn Counts for Status Effects")]
    public int c_i_turnCount1;
    public int c_i_turnCount2;
    public int c_i_turnCount3; 
    
    [Header("Card Rarity")]
    public float c_f_cardRarity;

    [Header("Color Types")]
    public bool c_b_redColorType;
    public bool c_b_blueColorType;
    public bool c_b_yellowColorType;
    public bool c_b_whiteColorType;
    public string c_str_color;

    [Header("Primary Destination")]
    public bool c_b_affectsNone; 
    public bool c_b_affectsPlayer;
    public bool c_b_affectsOne;
    public bool c_b_affectsAllEnemies;
    public bool c_b_affectsAllCharacters;

    [Header("Secondary Destination")]
    public bool c_b_playerEffect;
    public bool c_b_enemyEffect; 

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
    public bool c_b_thornsStatusEffect; 

    [Header("Potential Status Effect Values")]
    public float c_f_damagePercentage; // If not using effect value, use this
    public float c_f_turnCount;

    [Header("Card Graphic References")]
    public TextMeshProUGUI c_tx_header; // Header Textbox
    public TextMeshProUGUI c_tx_body; // Body Text Box
    public TextMeshProUGUI c_tx_flavor; // Flavor Text Box
    public TextMeshProUGUI c_tx_energyCost; // Energy Cost for card

    [Header("Card Dragger References")]
    public S_CardDragger sc_c_cardDraggerReference;
    //public int c_i_cardID;
    public RectTransform initialCardTransform;

    [Header("Card Hover Height")]
    public float i_hoverHeight;

    [Header("Zoom Card Scalars")]
    public float i_hoverX;
    public float i_hoverY;

    [Header("Card Scaler References")]
    public GameObject cv_canvas;
    private GameObject c_zoomCard;

    [Header("Card Background Art Assets")]
    public Sprite c_a_redBackground;
    public Sprite c_a_blueBackground;
    public Sprite c_a_yellowBackground;
    public Sprite c_a_whiteBackground;

    [Header("Card Foreground Art Assets")]
    public Sprite c_a_redForeground;
    public Sprite c_a_blueForeground;
    public Sprite c_a_yellowForeground;
    public Sprite c_a_whiteForeground;

    [Header("Shield Sound Effect")]
    public bool c_b_shieldSoundEffect;

    [Header("Attack Sound Effect")]
    public bool c_b_attackSoundEffect;

    // Will likely need to toggle bools for icons on the card itself at some point - Note for later

    //Functions
    private void Awake()
    {
        g_global = S_Global.Instance;

        //Separate cards, ended up not being needed
       // g_global.c_i_cardIDNum += 1;
        //c_i_cardID = g_global.c_i_cardIDNum;

        cv_canvas = GameObject.Find("MainCanvas");

        initialCardTransform = gameObject.GetComponent<RectTransform>();
    }

    /// <summary>
    /// To make it clearer for myself offloading the start behavior to another function
    /// -Josh
    /// </summary>
    /// <param name="_cardData"></param>
    public void FetchCardData(S_CardTemplate _cardData)
    {
        // Database Index
        c_i_cardDataBaseIndex = _cardData.CardDatabaseID;

        // Template
        c_cardTemplate = _cardData;

        //set attack and defense
        c_i_damageValue = _cardData.DamageValue;
        c_i_shieldValue = _cardData.ShieldValue;

        //Load strings
        c_str_cardName = _cardData.CardName;
        c_str_headerText = _cardData.HeaderText;
        c_str_bodyText = _cardData.BodyText;
        c_str_flavorText = _cardData.FlavorText;

        //Load ints/floats
        c_i_energyCost = _cardData.EnergyCost;
        c_i_effectValue1 = _cardData.EffectValue1;
        c_i_effectValue2 = _cardData.EffectValue2;
        c_i_effectValue3 = _cardData.EffectValue3; 
        c_f_cardRarity = _cardData.CardRarity;

        //Toggle Primary Destination
        c_b_affectsNone = _cardData.AffectsNone; 
        c_b_affectsPlayer = _cardData.AffectsPlayer;
        c_b_affectsOne = _cardData.Affects1Character;
        c_b_affectsAllEnemies = _cardData.AffectsAllEnemies;
        c_b_affectsAllCharacters = _cardData.AffectsAllCharacters;

        //Toggle Secondary Destination
        c_b_playerEffect = _cardData.PlayerEffect;
        c_b_enemyEffect = _cardData.EnemyEffect; 

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
        c_b_fralitizeStatusEffect = _cardData.FralityStatusEffect;
        c_b_manipulateStatusEffect = _cardData.ManipulateStatusEffect;

        //Toggle turncounts
        c_i_turnCount1 = _cardData.TurnCountForStatusEffect1;
        c_i_turnCount2 = _cardData.TurnCountForStatusEffect2;
        c_i_turnCount3 = _cardData.TurnCountForStatusEffect3;

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
            c_a_cardBackgroundImage.sprite = c_a_redBackground;
            c_a_cardForegroundImage.sprite = c_a_redForeground;
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
            c_a_cardBackgroundImage.sprite = c_a_blueBackground;
            c_a_cardForegroundImage.sprite = c_a_blueForeground;
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
            c_a_cardBackgroundImage.sprite = c_a_yellowBackground;
            c_a_cardForegroundImage.sprite = c_a_yellowForeground;
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
            c_a_cardBackgroundImage.sprite = c_a_whiteBackground;
            c_a_cardForegroundImage.sprite = c_a_whiteForeground;
        }

        //set the text for the card
        SetText();

        // Set art asset
        c_a_cardArtImage.sprite = _cardData.CardArtAsset;

        // Set String Color
        c_str_color = _cardData.ColorString;

        // Set sound effect for Shielding
        c_b_shieldSoundEffect = _cardData.PhysicalOrMagicalBoolForShield;

        // Set sound effect for Attacking
        c_b_attackSoundEffect = _cardData.PhysicalOrMagicalBoolForAttack;

        // Build bleed percentage 
        if(c_f_cardRarity == 0) // Common
        {
            c_f_bleedDamagePercentage = 0.1f;
        }
        else if (c_f_cardRarity == 1) // Uncommon
        {
            c_f_bleedDamagePercentage = 0.15f;
        }
        else if (c_f_cardRarity == 2) // Rare
        {
            c_f_bleedDamagePercentage = 0.2f;
        }
        else if (c_f_cardRarity == 3) // Very Rare
        {
            c_f_bleedDamagePercentage = 0.3f;
        }
        else if (c_f_cardRarity == 4) // Legendary
        {
            c_f_bleedDamagePercentage = 0.4f;
        }

        // Use helper function for Status Effect Order
        CheckStatusEffectOrder(_cardData);
    }

    public void SetText()
    {
        c_tx_header.text = c_str_headerText;
        c_tx_body.text = c_str_bodyText;
        c_tx_flavor.text = c_str_flavorText;
    }

    /// <summary>
    /// Determine what values correspond to what based off an ID number
    /// Only check for IDs currently implemented
    /// IDs are listed in proper order in cards excel doc
    /// Can eventually do all status effects
    /// - Josh
    /// </summary>
    /// <param name="_cardData"></param>
    private void CheckStatusEffectOrder(S_CardTemplate _cardData)
    {
        if(c_b_noEffect == true)
        {
            Debug.Log("DEBUG: No status effects for the given card!");
            return;
        }
        else
        {
            if (_cardData.IDForStatusEffectOne != 0) // Check the first ID
            {
                if (_cardData.IDForStatusEffectOne == 1) // Check for bleed
                {
                    c_str_statusEffectID1 = "bleed";
                }
                else if (_cardData.IDForStatusEffectOne == 4) // Check for resist
                {
                    c_str_statusEffectID1 = "resist";
                }
                else if (_cardData.IDForStatusEffectOne == 6) // Check for stun
                {
                    c_str_statusEffectID1 = "stun";
                }
            }

            if (_cardData.IDForStatusEffectTwo != 0) // Check ID Two, if there isn't any it won't do anything
            {
                if (_cardData.IDForStatusEffectTwo == 1) // Check for bleed
                {
                    c_str_statusEffectID2 = "bleed";
                }
                else if (_cardData.IDForStatusEffectTwo == 4) // Check for resist
                {
                    c_str_statusEffectID2 = "resist";
                }
                else if (_cardData.IDForStatusEffectTwo == 6) // Check for stun
                {
                    c_str_statusEffectID2 = "stun";
                }
            }

            if (_cardData.IDForStatusEffectThree != 0) // Check ID Three, , if there isn't any it won't do anything
            {
                if (_cardData.IDForStatusEffectThree == 1) // Check for bleed
                {
                    c_str_statusEffectID3 = "bleed";
                }
                else if (_cardData.IDForStatusEffectThree == 4) // Check for resist
                {
                    c_str_statusEffectID3 = "resist";
                }
                else if (_cardData.IDForStatusEffectThree == 6) // Check for stun
                {
                    c_str_statusEffectID3 = "stun";
                }
            }
        }
        
    }

    /// <summary>
    /// Play the given Status Effects, check for player and enemy respectively
    /// </summary>
    private void TriggerStatusEffects(GameObject _character) 
    {
        if (_character.GetComponent<S_Enemy>() != null) // If the given character was an enemy
        {
            S_Enemy _givenEnemy = _character.GetComponent<S_Enemy>();
            Debug.Log(_givenEnemy.e_i_enemyCount);
            if (c_b_bleedStatusEffect == true) // If Bleed effect is on card, toggle for enemy
            {
                // There is empirically a bleed effect, question is where
                if(c_str_statusEffectID1 == "bleed") // In slot 1
                {
                    g_global.g_enemyState.EnemyBleedingStatusEffect(c_f_bleedDamagePercentage, c_i_turnCount1, _givenEnemy.e_i_enemyCount);
                }
                else if(c_str_statusEffectID2 == "bleed") // In slot 2
                {
                    g_global.g_enemyState.EnemyBleedingStatusEffect(c_f_bleedDamagePercentage, c_i_turnCount2, _givenEnemy.e_i_enemyCount);
                }
                else if (c_str_statusEffectID3 == "bleed") // In slot 3
                {
                    g_global.g_enemyState.EnemyBleedingStatusEffect(c_f_bleedDamagePercentage, c_i_turnCount3, _givenEnemy.e_i_enemyCount);
                }

            }
            if (c_b_stunStatusEffect == true)
            {
                // Locate stun effect
                if (c_str_statusEffectID1 == "stun") // In slot 1
                {
                    g_global.g_enemyState.EnemyStunnedStatusEffect(c_i_turnCount1, _givenEnemy.e_i_enemyCount);
                }
                else if (c_str_statusEffectID2 == "stun") // In slot 2
                {
                    g_global.g_enemyState.EnemyStunnedStatusEffect(c_i_turnCount2, _givenEnemy.e_i_enemyCount);
                }
                else if (c_str_statusEffectID3 == "stun") // In slot 3
                {
                    g_global.g_enemyState.EnemyStunnedStatusEffect(c_i_turnCount3, _givenEnemy.e_i_enemyCount);
                }
            }
            if (c_b_resistStatusEffect == true)
            {
                // Locate stun effect
                if (c_str_statusEffectID1 == "resist") // In slot 1
                {
                    g_global.g_enemyState.EnemyResistantEffect(c_i_turnCount1, _givenEnemy.e_i_enemyCount);
                }
                else if (c_str_statusEffectID2 == "resist") // In slot 2
                {
                    g_global.g_enemyState.EnemyResistantEffect(c_i_turnCount2, _givenEnemy.e_i_enemyCount);
                }
                else if (c_str_statusEffectID3 == "resist") // In slot 3
                {
                    g_global.g_enemyState.EnemyResistantEffect(c_i_turnCount3, _givenEnemy.e_i_enemyCount);
                }
            }
        }
        else if (_character.GetComponent<S_Player>() != null) // If the given character was the player
        {
            if (c_b_bleedStatusEffect == true) // If Bleed effect is on card, toggle for enemy
            {
                // There is empirically a bleed effect, question is where
                if (c_str_statusEffectID1 == "bleed") // In slot 1
                {
                    g_global.g_playerState.PlayerBleedingStatusEffect(c_f_bleedDamagePercentage, c_i_turnCount1);
                }
                else if (c_str_statusEffectID2 == "bleed") // In slot 2
                {
                    g_global.g_playerState.PlayerBleedingStatusEffect(c_f_bleedDamagePercentage, c_i_turnCount2);
                }
                else if (c_str_statusEffectID3 == "bleed") // In slot 3
                {
                    g_global.g_playerState.PlayerBleedingStatusEffect(c_f_bleedDamagePercentage, c_i_turnCount3);
                }

            }
            if (c_b_stunStatusEffect == true)
            {
                // Locate stun effect
                if (c_str_statusEffectID1 == "stun") // In slot 1
                {
                    g_global.g_playerState.PlayerStunnedStatusEffect(c_i_turnCount1);
                }
                else if (c_str_statusEffectID2 == "stun") // In slot 2
                {
                    g_global.g_playerState.PlayerStunnedStatusEffect(c_i_turnCount2);
                }
                else if (c_str_statusEffectID3 == "stun") // In slot 3
                {
                    g_global.g_playerState.PlayerStunnedStatusEffect(c_i_turnCount3);
                }
            }
            if (c_b_resistStatusEffect == true)
            {
                // Locate stun effect
                if (c_str_statusEffectID1 == "resist") // In slot 1
                {
                    g_global.g_playerState.PlayerResistantEffect(c_i_turnCount1);
                }
                else if (c_str_statusEffectID2 == "resist") // In slot 2
                {
                    g_global.g_playerState.PlayerResistantEffect(c_i_turnCount2);
                }
                else if (c_str_statusEffectID3 == "resist") // In slot 3
                {
                    g_global.g_playerState.PlayerResistantEffect(c_i_turnCount3);
                }
            }
        }
        
    }

    /// <summary>
    /// Play the card based on if it was dropped onto player or enemy
    /// - Josh
    /// </summary>
    public void PlayCard(GameObject _character)
    {
        if (c_b_attackMainEffect == true)
        {
            if (_character.GetComponent<S_Enemy>() != null)
            {
                //undo star lockout
                g_global.g_ConstellationManager.b_starLockout = true;

                // Attack
                TriggerAttackCard(_character.GetComponent<S_Enemy>());

                // If there are status effects, then trigger them as well
                if (!c_b_noEffect) 
                {
                    if(c_b_enemyEffect == true) // If the status effects are for the enemy
                    {
                        TriggerStatusEffects(_character);
                    }
                    else if(c_b_playerEffect == true) // If the status effects are for the player
                    {
                        TriggerStatusEffects(g_global.g_player.gameObject);
                    }
                }
            }
            else
            {
                Debug.Log("DEBUG: Don't use an attack card on the player!");
                ResetPosition();
            }
        }
        else if (c_b_shieldMainEffect == true)
        {
            if (_character.GetComponent<S_Player>() != null)
            {
                // Then shield the player
                TriggerShieldCard();

                // If there are status effects, then trigger them as well
                if (!c_b_noEffect)
                {
                    if (c_b_enemyEffect == true) // If the status effects are for the enemy
                    {
                        TriggerStatusEffects(_character);
                    }
                    else if (c_b_playerEffect == true) // If the status effects are for the player
                    {
                        TriggerStatusEffects(g_global.g_player.gameObject);
                    }
                }
            }
            else
            {
                Debug.Log("DEBUG: Don't use a shield card on an enemy!");
                ResetPosition();
            }
        }
        else if (c_b_uniqueMainEffect == true)
        {
            // Note using any unique cards but we'd trigger special behavior here
        }

        //call the altar to spawn the next card if you have energy
        if (g_global.g_ls_p_playerHand.Count > 0) { g_global.g_altar.CheckFirstCardball(); }
    }


    /// <summary>
    /// If the main effect is attack, then attack
    /// Sound effect plays here to avoid problems
    /// If true = magic, physical = false
    /// - Josh
    /// </summary>
    private void TriggerAttackCard(S_Enemy _enemy)
    {
        _enemy.EnemyAttacked(_enemy.e_str_enemyType, c_i_damageValue);
        if(c_b_attackSoundEffect == false) // Play physical sound
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
        }
        else if(c_b_attackSoundEffect == true) // Play Magic sound
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
        }
        DeleteCard();
    }

    /// <summary>
    /// If the main effect is shield, then shield
    /// - Josh
    /// </summary>
    private void TriggerShieldCard()
    {
        g_global.g_player.PlayerShielded(c_i_shieldValue, c_b_shieldSoundEffect);
        DeleteCard();
    }

    /// <summary>
    /// Delete the card played
    /// </summary>
    private void DeleteCard()
    {
        //if a cardball persists
        g_global.g_altar.c_b_cardSpawned = false;
        g_global.g_cardManager.RemoveFirstCard();
        Destroy(gameObject); // Remove card from play
    }

    /// <summary>
    /// Does as it says, it resets the card to it's initial position
    /// -Josh
    /// </summary>
    public void ResetPosition()
    {
        gameObject.transform.position = sc_c_cardDraggerReference.c_v3_initialPosition; 
    }
}