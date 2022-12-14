using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class S_Card : MonoBehaviour
{
    //Private varibales
    private S_Global g_global;

    [Header("Template it's built on")]
    public S_CardTemplate crd_cardTemplate;

    [Header("Sprite Asset")]
    public SpriteRenderer crd_a_cardBackgroundArtAsset;

    [Header("Card Database Index")]
    public int crd_i_cardDataBaseIndex;

    [Header("Card Basics")]
    public string crd_str_cardName;
    public string crd_str_headerText;
    public string crd_str_bodyText;
    public string crd_str_flavorText;

    [Header("Main Effect Numbers")]
    public int crd_i_damageValue;
    public int crd_i_shieldValue;
    public int crd_i_energyCost; //Cast to a string for energy cost text

    [Header("Status Effect Numbers")]
    public int crd_i_effectValue1; // Effect Value 1
    public int crd_i_effectValue2; // Effect Value 2
    public int crd_i_effectValue3; // Effect Value 3

    [Header("Resistant and Frality Float Values")]
    public float crd_f_resistantValue;
    public float crd_f_fralitizeValue;

    [Header("Status Effect IDs")]
    public string crd_str_statusEffectID1;
    public string crd_str_statusEffectID2;
    public string crd_str_statusEffectID3;

    [Header("Card Rarity Tier")]
    public bool crd_b_commonTier;
    public bool crd_b_uncommonTier;
    public bool crd_b_rareTier;
    public bool crd_b_veryRareTier;
    public bool crd_b_legendaryTier;

    [Header("Color Types")]
    public bool crd_b_redColorType;
    public bool crd_b_blueColorType;
    public bool crd_b_yellowColorType;
    public bool crd_b_whiteColorType;
    public string crd_str_color;

    [Header("Primary Destination")]
    public bool crd_b_affectsNone;
    public bool crd_b_affectsPlayer;
    public bool crd_b_affectsOne;
    public bool crd_b_affectsAllEnemies;
    public bool crd_b_affectsAllCharacters;

    [Header("Secondary Destination")]
    public bool crd_b_playerEffect;
    public bool crd_b_enemyEffect;

    [Header("Main Effect Types")]
    public bool crd_b_attackMainEffect;
    public bool crd_b_shieldMainEffect;
    public bool crd_b_uniqueMainEffect;

    [Header("Status Effect Triggers")]
    public bool crd_b_noEffect;
    public bool crd_b_acidStatusEffect;
    public bool crd_b_bleedStatusEffect;
    public bool crd_b_frailtyStatusEffect;
    public bool crd_b_stunnedStatusEffect;
    public bool crd_b_resistantStatusEffect;

    [Header("Potential Status Effect Values")]
    public float crd_f_damagePercentage; // If not using effect value, use this
    public float crd_f_turnCount;

    [Header("Card Graphic References")]
    public TextMeshProUGUI crd_tx_header; // Header Textbox
    public TextMeshProUGUI crd_tx_body; // Body Text Box
    public TextMeshProUGUI crd_tx_flavor; // Flavor Text Box
    public TextMeshProUGUI crd_tx_energyCost; // Energy Cost for card

    [Header("Card Dragger References")]
    //public S_CardDragger sc_c_cardDraggerReference;
    public S_Enemy crd_e_grabbedEnemy;

    [Header("Card Background Art Assets")]
    public Sprite crd_a_redBackground;
    public Sprite crd_a_blueBackground;
    public Sprite crd_a_yellowBackground;
    public Sprite crd_a_whiteBackground;

    [Header("Shield Sound Effect")]
    public bool crd_b_shieldSoundEffect;

    [Header("Attack Sound Effect")]
    public bool crd_b_attackSoundEffect;

    [Header("Card Position Index and Position")]
    public bool crd_b_resetPositionFlag;
    public Vector3 crd_v3_cardPosition;
    public Vector3 crd_v3_initialCardPosition;

    [Header("CardDrag Bool")]
    public bool crd_b_cardIsDragged;

    [Header("Tween Storage")]
    public Tweener an_storedTween;

    private GameObject crd_hoverCharacter;

    // Will likely need to toggle bools for icons on the card itself at some point - Note for later

    //Functions
    private void Awake()
    {
        g_global = S_Global.Instance;

        //Separate cards, ended up not being needed
        // g_global.c_i_cardIDNum += 1;
        //c_i_cardID = g_global.c_i_cardIDNum;
    }

    /// <summary>
    /// To make it clearer for myself offloading the start behavior to another function
    /// -Josh
    /// </summary>
    /// <param name="_cardData"></param>
    public void FetchCardData(S_CardTemplate _cardData)
    {
        // Database Index
        crd_i_cardDataBaseIndex = _cardData.CardDatabaseID;

        // Template
        crd_cardTemplate = _cardData;

        //set attack and defense
        crd_i_damageValue = _cardData.DamageValue;
        crd_i_shieldValue = _cardData.ShieldValue;

        //Load strings
        crd_str_cardName = _cardData.CardName;
        crd_str_headerText = _cardData.HeaderText;
        crd_str_bodyText = _cardData.BodyText;
        crd_str_flavorText = _cardData.FlavorText;

        //Load ints/floats
        crd_i_energyCost = _cardData.EnergyCost;
        crd_i_effectValue1 = _cardData.StackCount1;
        crd_i_effectValue2 = _cardData.StackCount2;
        crd_i_effectValue3 = _cardData.StackCount3;

        // Set card rarirty tier
        crd_b_commonTier = _cardData.Common;
        crd_b_uncommonTier = _cardData.Uncommon;
        crd_b_rareTier = _cardData.Rare;
        crd_b_veryRareTier = _cardData.VeryRare;
        crd_b_legendaryTier = _cardData.Legendary;

        //Toggle Primary Destination
        crd_b_affectsNone = _cardData.AffectsNone;
        crd_b_affectsPlayer = _cardData.AffectsPlayer;
        crd_b_affectsOne = _cardData.Affects1Character;
        crd_b_affectsAllEnemies = _cardData.AffectsAllEnemies;
        crd_b_affectsAllCharacters = _cardData.AffectsAllCharacters;

        //Toggle Secondary Destination
        crd_b_playerEffect = _cardData.PlayerEffect;
        crd_b_enemyEffect = _cardData.EnemyEffect;

        //Toggle Main Effects
        crd_b_attackMainEffect = _cardData.AttackEffect;
        crd_b_shieldMainEffect = _cardData.ShieldEffect;
        crd_b_uniqueMainEffect = _cardData.UniqueEffect;

        //Toggle Status Effects
        crd_b_noEffect = _cardData.NoEffect;
        crd_b_acidStatusEffect = _cardData.AcidicStatusEffect;
        crd_b_bleedStatusEffect = _cardData.BleedStatusEffect;
        crd_b_frailtyStatusEffect = _cardData.FralityStatusEffect;
        crd_b_stunnedStatusEffect = _cardData.StunnedStatusEffect;
        crd_b_resistantStatusEffect = _cardData.ResistantStatusEffect;

        //Toggle Color Types, will need to adapt for synergies

        //Red Type
        if (_cardData.RedColorType == true)
        {
            //Toggle Bools
            crd_b_redColorType = true;
            crd_b_blueColorType = false;
            crd_b_yellowColorType = false;
            crd_b_whiteColorType = false;

            //Toggle Graphics
            crd_a_cardBackgroundArtAsset.sprite = crd_a_redBackground;
        }
        //Blue Type
        else if (_cardData.BlueColorType == true)
        {
            //Toggle Bools
            crd_b_redColorType = false;
            crd_b_blueColorType = true;
            crd_b_yellowColorType = false;
            crd_b_whiteColorType = false;

            //Toggle Graphics
            crd_a_cardBackgroundArtAsset.sprite = crd_a_blueBackground;
        }
        //Yellow Type
        else if (_cardData.YellowColorType == true)
        {
            //Toggle Bools
            crd_b_redColorType = false;
            crd_b_blueColorType = false;
            crd_b_yellowColorType = true;
            crd_b_whiteColorType = false;

            //Toggle Graphics
            crd_a_cardBackgroundArtAsset.sprite = crd_a_yellowBackground;
        }
        //White Type
        else if (_cardData.WhiteColorType == true)
        {
            //Toggle Bools
            crd_b_redColorType = false;
            crd_b_blueColorType = false;
            crd_b_yellowColorType = false;
            crd_b_whiteColorType = true;

            //Toggle Graphics
            crd_a_cardBackgroundArtAsset.sprite = crd_a_whiteBackground;
        }

        //set the text for the card
        SetText();

        // Set String Color
        crd_str_color = _cardData.ColorString;

        // Set sound effect for Shielding
        crd_b_shieldSoundEffect = _cardData.PhysicalOrMagicalBoolForShield;

        // Set sound effect for Attacking
        crd_b_attackSoundEffect = _cardData.PhysicalOrMagicalBoolForAttack;

        // Use helper function for Status Effect Order
        CheckStatusEffectOrder(_cardData);
    }

    public void SetText()
    {
        crd_tx_header.text = crd_str_headerText;
        crd_tx_body.text = crd_str_bodyText;
        crd_tx_flavor.text = crd_str_flavorText;
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
        if (crd_b_noEffect == true)
        {
            return;
        }
        else
        {
            if (_cardData.IDForStatusEffectOne != 0) // Check the first ID
            {
                if (_cardData.IDForStatusEffectOne == 1) // Check for bleed
                {
                    crd_str_statusEffectID1 = "acid";
                }
                else if (_cardData.IDForStatusEffectOne == 2) // Check for bleed
                {
                    crd_str_statusEffectID1 = "bleed";
                }
                else if (_cardData.IDForStatusEffectOne == 3) // Check for resist
                {
                    crd_str_statusEffectID1 = "frail";
                }
                else if (_cardData.IDForStatusEffectOne == 4) // Check for bleed
                {
                    crd_str_statusEffectID1 = "resist";
                }
                else if (_cardData.IDForStatusEffectOne == 5) // Check for stun
                {
                    crd_str_statusEffectID1 = "stun";
                }
            }

            if (_cardData.IDForStatusEffectTwo != 0) // Check ID Two, if there isn't any it won't do anything
            {
                if (_cardData.IDForStatusEffectTwo == 1) // Check for bleed
                {
                    crd_str_statusEffectID2 = "acid";
                }
                else if (_cardData.IDForStatusEffectTwo == 2) // Check for bleed
                {
                    crd_str_statusEffectID2 = "bleed";
                }
                else if (_cardData.IDForStatusEffectTwo == 3) // Check for resist
                {
                    crd_str_statusEffectID2 = "frail";
                }
                else if (_cardData.IDForStatusEffectTwo == 4) // Check for bleed
                {
                    crd_str_statusEffectID2 = "resist";
                }
                else if (_cardData.IDForStatusEffectTwo == 5) // Check for stun
                {
                    crd_str_statusEffectID2 = "stun";
                }
            }

            if (_cardData.IDForStatusEffectThree != 0) // Check ID Three, , if there isn't any it won't do anything
            {
                if (_cardData.IDForStatusEffectThree == 1) // Check for bleed
                {
                    crd_str_statusEffectID3 = "acid";
                }
                else if (_cardData.IDForStatusEffectThree == 2) // Check for bleed
                {
                    crd_str_statusEffectID3 = "bleed";
                }
                else if (_cardData.IDForStatusEffectThree == 3) // Check for resist
                {
                    crd_str_statusEffectID3 = "frail";
                }
                else if (_cardData.IDForStatusEffectThree == 4) // Check for bleed
                {
                    crd_str_statusEffectID3 = "resist";
                }
                else if (_cardData.IDForStatusEffectThree == 5) // Check for stun
                {
                    crd_str_statusEffectID3 = "stun";
                }
            }
        }
    }

    /// <summary>
    /// Play the given Status Effects, check for player and enemy respectively
    /// - Josh
    /// </summary>
    private void TriggerStatusEffects(GameObject _character)
    {
        if (_character.GetComponent<S_Enemy>() != null) // If the given character was an enemy
        {
            S_Enemy _givenEnemy = _character.GetComponent<S_Enemy>();
            if (crd_b_acidStatusEffect == true) // If Bleed effect is on card, toggle for enemy
            {
                if (crd_str_statusEffectID1 == "acid") // In slot 1
                {
                    g_global.g_enemyState.EnemyAcidStatusEffect(crd_i_effectValue1, _givenEnemy.e_i_enemyCount);
                }
                else if (crd_str_statusEffectID2 == "acid") // In slot 2
                {
                    g_global.g_enemyState.EnemyAcidStatusEffect(crd_i_effectValue2, _givenEnemy.e_i_enemyCount);
                }
                else if (crd_str_statusEffectID3 == "acid") // In slot 3
                {
                    g_global.g_enemyState.EnemyAcidStatusEffect(crd_i_effectValue3, _givenEnemy.e_i_enemyCount);
                }
            }
            if (crd_b_bleedStatusEffect == true) // If Bleed effect is on card, toggle for enemy
            {
                if (crd_str_statusEffectID1 == "bleed") // In slot 1
                {
                    g_global.g_enemyState.EnemyBleedStatusEffect(crd_i_effectValue1, _givenEnemy.e_i_enemyCount);
                }
                else if (crd_str_statusEffectID2 == "bleed") // In slot 2
                {
                    g_global.g_enemyState.EnemyBleedStatusEffect(crd_i_effectValue2, _givenEnemy.e_i_enemyCount);
                }
                else if (crd_str_statusEffectID3 == "bleed") // In slot 3
                {
                    g_global.g_enemyState.EnemyBleedStatusEffect(crd_i_effectValue3, _givenEnemy.e_i_enemyCount);
                }
            }
            if (crd_b_frailtyStatusEffect == true) 
            {
                if (crd_str_statusEffectID1 == "frail") // In slot 1
                {
                    g_global.g_enemyState.EnemyFrailtyStatusEffect(crd_i_effectValue1, _givenEnemy.e_i_enemyCount);
                }
                else if (crd_str_statusEffectID2 == "frail") // In slot 2
                {
                    g_global.g_enemyState.EnemyFrailtyStatusEffect(crd_i_effectValue2, _givenEnemy.e_i_enemyCount);
                }
                else if (crd_str_statusEffectID3 == "frail") // In slot 3
                {
                    g_global.g_enemyState.EnemyFrailtyStatusEffect(crd_i_effectValue3, _givenEnemy.e_i_enemyCount);
                }

            }
            if (crd_b_resistantStatusEffect == true)
            {
                if (crd_str_statusEffectID1 == "resist") // In slot 1
                {
                    g_global.g_enemyState.EnemyResistantStatusEffect(crd_i_effectValue1, _givenEnemy.e_i_enemyCount);
                }
                else if (crd_str_statusEffectID2 == "resist") // In slot 2
                {
                    g_global.g_enemyState.EnemyResistantStatusEffect(crd_i_effectValue2, _givenEnemy.e_i_enemyCount);
                }
                else if (crd_str_statusEffectID3 == "resist") // In slot 3
                {
                    g_global.g_enemyState.EnemyResistantStatusEffect(crd_i_effectValue3, _givenEnemy.e_i_enemyCount);
                }
            }
            if (crd_b_stunnedStatusEffect == true)
            {
                if (crd_str_statusEffectID1 == "stun") // In slot 1
                {
                    g_global.g_enemyState.EnemyStunStatusEffect(crd_i_effectValue1, _givenEnemy.e_i_enemyCount);
                }
                else if (crd_str_statusEffectID2 == "stun") // In slot 2
                {
                    g_global.g_enemyState.EnemyStunStatusEffect(crd_i_effectValue2, _givenEnemy.e_i_enemyCount);
                }
                else if (crd_str_statusEffectID3 == "stun") // In slot 3
                {
                    g_global.g_enemyState.EnemyStunStatusEffect(crd_i_effectValue3, _givenEnemy.e_i_enemyCount);
                }
            }
            
        }
        else if (_character.GetComponent<S_Player>() != null) // If the given character was the player
        {
            if (crd_b_acidStatusEffect == true) 
            {
                // There is empirically a bleed effect, question is where
                if (crd_str_statusEffectID1 == "acid") // In slot 1
                {
                    g_global.g_playerState.PlayerAcidStatusEffect(crd_i_effectValue1);
                }
                else if (crd_str_statusEffectID2 == "acid") // In slot 2
                {
                    g_global.g_playerState.PlayerAcidStatusEffect(crd_i_effectValue2);
                }
                else if (crd_str_statusEffectID3 == "acid") // In slot 3
                {
                    g_global.g_playerState.PlayerAcidStatusEffect(crd_i_effectValue3);
                }

            }
            if (crd_b_bleedStatusEffect == true) // If Bleed effect is on card, toggle for enemy
            {
                // There is empirically a bleed effect, question is where
                if (crd_str_statusEffectID1 == "bleed") // In slot 1
                {
                    g_global.g_playerState.PlayerBleedingStatusEffect(crd_i_effectValue1);
                }
                else if (crd_str_statusEffectID2 == "bleed") // In slot 2
                {
                    g_global.g_playerState.PlayerBleedingStatusEffect(crd_i_effectValue2);
                }
                else if (crd_str_statusEffectID3 == "bleed") // In slot 3
                {
                    g_global.g_playerState.PlayerBleedingStatusEffect(crd_i_effectValue3);
                }

            }
            if (crd_b_frailtyStatusEffect == true) 
            {
                // There is empirically a bleed effect, question is where
                if (crd_str_statusEffectID1 == "frail") // In slot 1
                {
                    g_global.g_playerState.PlayerFrailtyStatusEffect(crd_i_effectValue1);

                }
                else if (crd_str_statusEffectID2 == "frail") // In slot 2
                {
                    g_global.g_playerState.PlayerFrailtyStatusEffect(crd_i_effectValue2);
                }
                else if (crd_str_statusEffectID3 == "frail") // In slot 3
                {
                    g_global.g_playerState.PlayerFrailtyStatusEffect(crd_i_effectValue3);
                }

            }
            if (crd_b_resistantStatusEffect == true)
            {
                // Locate stun effect
                if (crd_str_statusEffectID1 == "resist") // In slot 1
                {
                    g_global.g_playerState.PlayerResistantEffect(crd_i_effectValue1);
                }
                else if (crd_str_statusEffectID2 == "resist") // In slot 2
                {
                    g_global.g_playerState.PlayerResistantEffect(crd_i_effectValue2);
                }
                else if (crd_str_statusEffectID3 == "resist") // In slot 3
                {
                    g_global.g_playerState.PlayerResistantEffect(crd_i_effectValue3);
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
        if (crd_b_attackMainEffect == true)
        {
            if (_character.GetComponent<S_Enemy>() != null)
            {
                // Attack
                TriggerAttackCard(_character.GetComponent<S_Enemy>());

                // If there are status effects, then trigger them as well
                if (!crd_b_noEffect)
                {
                    if (crd_b_enemyEffect == true) // If the status effects are for the enemy
                    {
                        TriggerStatusEffects(_character);
                    }
                    else if (crd_b_playerEffect == true) // If the status effects are for the player
                    {
                        TriggerStatusEffects(g_global.g_player.gameObject);
                    }
                }

                g_global.g_altar.SetCardBeingActiveBool(true);
                //g_global.g_ConstellationManager.SetStarLockOutBool(true);
            }
            else
            {
                Debug.Log("DEBUG: Don't use an attack card on the player!");
                ResetPosition();
            }
        }
        else if (crd_b_shieldMainEffect == true)
        {
            if (_character.GetComponent<S_Player>() != null)
            {
                // Then shield the player
                TriggerShieldCard();

                // If there are status effects, then trigger them as well
                if (!crd_b_noEffect)
                {
                    if (crd_b_enemyEffect == true) // If the status effects are for the enemy
                    {
                        TriggerStatusEffects(_character);
                    }
                    else if (crd_b_playerEffect == true) // If the status effects are for the player
                    {
                        TriggerStatusEffects(g_global.g_player.gameObject);
                    }
                }

                // Unpause IEnumerator
                if (g_global.g_ls_p_playerHand.Count > 0)
                {
                    //Debug.Log("Triggered the bool");
                    g_global.g_altar.SetCardBeingActiveBool(true);
                    //g_global.g_ConstellationManager.SetStarLockOutBool(true);
                }
            }
            else
            {
                Debug.Log("DEBUG: Don't use a shield card on an enemy!");
                ResetPosition();
            }
        }
        else if (crd_b_uniqueMainEffect == true)
        {
            // Note using any unique cards but we'd trigger special behavior here
        }
    }


    /// <summary>
    /// If the main effect is attack, then attack
    /// Sound effect plays here to avoid problems
    /// If true = magic, physical = false
    /// - Josh
    /// </summary>
    private void TriggerAttackCard(S_Enemy _enemy)
    {

        _enemy.EnemyAttacked(_enemy.e_str_enemyType, crd_i_damageValue);
        if (crd_b_attackSoundEffect == false) // Play physical sound
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/attack-physical");
        }
        else if (crd_b_attackSoundEffect == true) // Play Magic sound
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/attack-magic");
        }
        g_global.g_player.animator.SetTrigger("attackingAnimation");
        DeleteCard();
    }

    /// <summary>
    /// If the main effect is shield, then shield
    /// - Josh
    /// </summary>
    private void TriggerShieldCard()
    {
        g_global.g_player.PlayerShielded(crd_i_shieldValue, crd_b_shieldSoundEffect);
        g_global.g_player.animator.Play("Blocking");
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
        gameObject.transform.position = crd_v3_initialCardPosition;
        crd_b_resetPositionFlag = false;
    }

    /// <summary>
    /// 
    /// </summary>
    public void CheckResetOrPlay()
    {
        if(crd_hoverCharacter != null)
        {
            Debug.Log(crd_hoverCharacter);
            PlayCard(crd_hoverCharacter);
        }
        else
        {
            ResetPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.tag == "Enemy" && crd_b_attackMainEffect)
        {
            if (crd_hoverCharacter != col.gameObject && crd_hoverCharacter != null)
            {
                //scale down
                Debug.Log("Scale Down");

                if (an_storedTween.IsPlaying())
                {
                    an_storedTween.PlayBackwards();
                }
                else
                {
                    an_storedTween = crd_hoverCharacter.transform.DOScale(new Vector3(crd_hoverCharacter.transform.localScale.x - .01f, crd_hoverCharacter.transform.localScale.y - .01f, 0), 0.2f);
                }

                //turn off the old enenemies ui
                g_global.g_UIManager.SetEnemySelectorOff(crd_hoverCharacter.GetComponent<S_Enemy>().e_i_enemyCount);
            }

            //select the new enemy as the hovercharacter and turn on their ui
            crd_hoverCharacter = col.gameObject;

            //scale Up
            Debug.Log("Scale Up");
            an_storedTween = crd_hoverCharacter.transform.DOScale(new Vector3(crd_hoverCharacter.transform.localScale.x + .01f, crd_hoverCharacter.transform.localScale.y + .01f, 0), 0.2f);

            g_global.g_UIManager.SetEnemySelectorOn(crd_hoverCharacter.GetComponent<S_Enemy>().e_i_enemyCount);
        }
        else if (col.transform.tag == "Player" && crd_b_shieldMainEffect)
        {
            if (crd_hoverCharacter != col.gameObject && crd_hoverCharacter != null)
            {
                //turn off the old enenemies ui
                g_global.g_UIManager.SetEnemySelectorOff(crd_hoverCharacter.GetComponent<S_Enemy>().e_i_enemyCount);
            }

            //set the hoverCharacter and turn on the ui selector
            crd_hoverCharacter = col.gameObject;
            g_global.g_UIManager.sc_characterGraphics.TogglePlayerSelectorUI(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject == crd_hoverCharacter)
        {
            //remove the enemy/player selector
            if(col.transform.tag == "Enemy")
            {
                //scale down
                Debug.Log("Scale Down2");
                if (an_storedTween.IsPlaying())
                {
                    an_storedTween.PlayBackwards();
                }
                else
                {
                    an_storedTween = crd_hoverCharacter.transform.DOScale(new Vector3(crd_hoverCharacter.transform.localScale.x - .01f, crd_hoverCharacter.transform.localScale.y - .01f, 0), 0.2f);
                }

                g_global.g_UIManager.SetEnemySelectorOff(crd_hoverCharacter.GetComponent<S_Enemy>().e_i_enemyCount);
            }
            else if (col.transform.tag == "Player")
            {
                g_global.g_UIManager.sc_characterGraphics.TogglePlayerSelectorUI(false);
            }

            crd_hoverCharacter = null;
        }
    }

    // Setters \\ 

    /// <summary>
    /// Set the bool value of S_Card.c_v3_initialCardPosition;
    /// - Josh 
    /// </summary>
    /// <param name="_cardInitialPosition"></param>
    public void SetCardInitialPosition(Vector3 _cardInitialPosition) 
    {
        crd_v3_initialCardPosition = _cardInitialPosition;
    }

    public void SetCardDrag(bool _bool)
    {
        crd_b_cardIsDragged = _bool;
    }

    // Getters \\ 

    /// <summary>
    /// Func that returns the card drag
    /// </summary>
    /// <returns></returns>
    public bool GetCardDrag()
    {
        return crd_b_cardIsDragged;
    }

}