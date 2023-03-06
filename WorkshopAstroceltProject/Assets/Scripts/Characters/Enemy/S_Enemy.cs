using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Linq; 

public class S_Enemy : MonoBehaviour
{
    private S_Global g_global;

    public SpriteRenderer sr_enemySprite;

    public S_EnemyAttributes e_sc_enemyAttributes;

    [Header("Enemy Type")]
    [Tooltip("This is a string, do not add quotes on it. - Josh")]
    public string e_str_enemyType; // Also in attributes, delete from here later, improper placing

    [Header("Enemy Count")]
    public int e_i_enemyCount;

    [Header("Intent Assets")]
    public GameObject e_sp_spriteIcon;
    public GameObject e_tx_intentTextObject;

    [Header("Character Card Interface")]
    public S_CharacterCardInterface e_cd_sc_characterCardInterface;

    [Header("Enemy Default Scale Vector3")]
    public Vector3 e_v3_defaultScale;

    [Header("Intent Duration Value")]
    public float f_intentDuration;

    // Getting cardball object
    public GameObject cardball;

    [Header("Nameplate Text Object")]
    [SerializeField] TextMeshProUGUI e_tx_enemyNameplate;

    private void Awake()
    {
        g_global = S_Global.Instance;

        SetCount(); 
        
        // Debug.Log("Testing for enemy count: " + e_i_enemyCount.ToString());

        g_global.e_ls_enemyList.Add(this);

        e_cd_sc_characterCardInterface.e_attachedEnemy = this;

        // Grab and set default scale
        e_v3_defaultScale = gameObject.transform.localScale;

        g_global.g_ls_activeEnemies.Add(this);
    }

    private void Start()
    {
        // If enemy 1, move spots
        if (e_i_enemyCount == 1)
        {
            gameObject.transform.SetParent(g_global.g_e_enemyPosition1.transform, false);
        }

        // If enemy 2, move spots
        if (e_i_enemyCount == 2)
        {
            gameObject.transform.SetParent(g_global.g_e_enemyPosition2.transform, false);
        }

        // If enemy 3, move spots
        if (e_i_enemyCount == 3)
        {
            gameObject.transform.SetParent(g_global.g_e_enemyPosition3.transform, false);
        }

        // Need to add in enemy 4 and 5 placement and the scene knowing if it should have 3 enemies or 5 enemies from S_GameManager or even get something set initially as a bool in S_Global we toggle
        // - Josh

        // Set the enemy nameplate
        e_tx_enemyNameplate.text = e_sc_enemyAttributes.GetEnemyName();
    }

    /// <summary>
    /// Determine the Enemy Number
    /// - Josh
    /// </summary>
    private void SetCount()
    {
        g_global.g_i_enemyCount += 1;
        e_i_enemyCount = g_global.g_i_enemyCount;
    }

    /// <summary>
    /// Enemy was attacked
    /// Updated for Magician
    /// - Josh
    /// </summary>
    /// <param name="_enemyType"></param>
    /// <param name="_damageValue"></param>
    public void EnemyAttacked(string _enemyType, int _damageValue) 
    {
       // Debug.Log("Enemy takes damage");
        if (_enemyType == "Lumberjack" || _enemyType == "Magician" || _enemyType == "Beast" || _enemyType == "Brawler" || _enemyType == "Realmwalker")
        {
            int _resistantDamageValue = (int)_damageValue / 2;
            int _frailtyDamageValue = (int)_damageValue * 2;
            if (g_global.g_enemyState.GetEnemyResistantEffectState(e_i_enemyCount) == true) // If the enemy is resisitant
            {
                if (e_sc_enemyAttributes.GetEnemyShieldValue() <= 0) // The enemy has no sheilds
                {
                    e_sc_enemyAttributes.e_i_health -= _resistantDamageValue;

                    // Attacked Particle Effect
                    e_sc_enemyAttributes.GetEnemyAttackedParticle().Play();

                    Debug.Log("Enemy Attacked!");
                }
                else // Enemy has shields
                {
                    int _tempVal = e_sc_enemyAttributes.GetEnemyShieldValue() - _resistantDamageValue;
                    if (_tempVal < 0) 
                    {
                        e_sc_enemyAttributes.SetEnemyShield(e_sc_enemyAttributes.GetEnemyShieldValue() - _resistantDamageValue);
                        if (e_sc_enemyAttributes.GetEnemyShieldValue() < 0)
                        {
                            e_sc_enemyAttributes.SetEnemyShield(0);
                        }

                        EnemyAttacked(_enemyType, Mathf.Abs(_tempVal));

                        // Attacked Particle Effect
                        e_sc_enemyAttributes.GetEnemyAttackedParticle().Play();

                        Debug.Log("Enemy didn't have enough shields!");
                    }
                    else
                    {
                        e_sc_enemyAttributes.SetEnemyShield(e_sc_enemyAttributes.GetEnemyShieldValue() - _resistantDamageValue);

                        // Sufficient Shields Particle Effect
                        e_sc_enemyAttributes.GetEnemyShieldAttackedParticle().Play();

                        Debug.Log("Enemy had shields!");
                    }
                }
            }
            else if (g_global.g_enemyState.GetEnemyFrailtyEffectState(e_i_enemyCount) == true) // If the enemy has frailty
            {
                if (e_sc_enemyAttributes.GetEnemyShieldValue() <= 0) // The enemy has no sheilds
                {
                    e_sc_enemyAttributes.e_i_health -= _frailtyDamageValue;

                    // Attacked Particle Effect
                    e_sc_enemyAttributes.GetEnemyAttackedParticle().Play();

                    Debug.Log("Enemy Attacked!");
                }
                else // Enemy has shields
                {
                    int _tempVal = e_sc_enemyAttributes.GetEnemyShieldValue() - _frailtyDamageValue;
                    if (_tempVal < 0)
                    {
                        e_sc_enemyAttributes.SetEnemyShield(e_sc_enemyAttributes.GetEnemyShieldValue() - _frailtyDamageValue);
                        if (e_sc_enemyAttributes.GetEnemyShieldValue() < 0)
                        {
                            e_sc_enemyAttributes.SetEnemyShield(0);
                        }

                        EnemyAttacked(_enemyType, Mathf.Abs(_tempVal));

                        // Attacked Particle Effect
                        e_sc_enemyAttributes.GetEnemyAttackedParticle().Play();

                        Debug.Log("Enemy didn't have enough shields!");
                    }
                    else
                    {
                        e_sc_enemyAttributes.SetEnemyShield(e_sc_enemyAttributes.GetEnemyShieldValue() - _frailtyDamageValue);

                        // Sufficient Shields Particle Effect
                        e_sc_enemyAttributes.GetEnemyShieldAttackedParticle().Play();

                        Debug.Log("Enemy had shields!");
                    }
                }
            }
            else // If the enemy is not resistant or frail
            {
                if (e_sc_enemyAttributes.GetEnemyShieldValue() <= 0) // Enemy has no shields
                {
                    e_sc_enemyAttributes.e_i_health -= _damageValue;

                    // Attacked Particle Effect
                    e_sc_enemyAttributes.GetEnemyAttackedParticle().Play();

                    Debug.Log("Enemy Attacked!");
                }
                else // Enemy has shields
                {
                    int _tempVal = e_sc_enemyAttributes.GetEnemyShieldValue() - _damageValue;
                    if (_tempVal < 0)
                    {
                        e_sc_enemyAttributes.SetEnemyShield(e_sc_enemyAttributes.GetEnemyShieldValue() - _damageValue);
                        if (e_sc_enemyAttributes.GetEnemyShieldValue() < 0)
                        {
                            e_sc_enemyAttributes.SetEnemyShield(0);

                            // Shield Break Particle Check
                            g_global.g_enemyState.GetEnemyDataSheet(1).GetEnemyShieldBreakParticle().Play();
                        }

                        EnemyAttacked(_enemyType, Mathf.Abs(_tempVal));

                        // Attacked Particle Effect 
                        e_sc_enemyAttributes.GetEnemyAttackedParticle().Play();

                        Debug.Log("Enemy didn't have enough shields!");
                    }
                    else
                    {
                        e_sc_enemyAttributes.SetEnemyShield(e_sc_enemyAttributes.GetEnemyShieldValue() - _damageValue);

                        // Sufficient Shields Particle Effect
                        e_sc_enemyAttributes.GetEnemyShieldAttackedParticle().Play();

                        Debug.Log("Enemy had shields!");
                    }
                }
            }
        }
        else // The enemy is not a predetermined type
        {
            if (e_sc_enemyAttributes.GetEnemyShieldValue() <= 0) // Enemy has no shields
            {
                e_sc_enemyAttributes.e_i_health -= _damageValue;

                // Attacked Particle Effect
                e_sc_enemyAttributes.GetEnemyAttackedParticle().Play();

                Debug.Log("Enemy Attacked!");
            }
            else // Enemy has shields
            {
                int _tempVal = e_sc_enemyAttributes.GetEnemyShieldValue() - _damageValue;
                if (_tempVal < 0)
                {
                    e_sc_enemyAttributes.SetEnemyShield(e_sc_enemyAttributes.GetEnemyShieldValue() - _damageValue);
                    if (e_sc_enemyAttributes.GetEnemyShieldValue() < 0)
                    {
                        e_sc_enemyAttributes.SetEnemyShield(0);
                    }
                    EnemyAttacked(_enemyType, Mathf.Abs(_tempVal));


                    // Attacked Particle Effect
                    e_sc_enemyAttributes.GetEnemyAttackedParticle().Play();

                    Debug.Log("Enemy didn't have enough shields!");
                }
                else
                {
                    e_sc_enemyAttributes.SetEnemyShield(e_sc_enemyAttributes.GetEnemyShieldValue() - _damageValue);

                    // Sufficient Shields Particle Effect
                    e_sc_enemyAttributes.GetEnemyShieldAttackedParticle().Play();

                    Debug.Log("Enemy had shields!");
                }
            }
        }

        // Update the UI
        UpdateEnemyHealthUI();
    }

    /// <summary>
    /// Enemy shield function,
    /// needs string type for differing audio behavior
    /// - Josh
    /// </summary>
    /// <param name="_enemyType"></param>
    /// <param name="_shieldVal"></param>
    public void EnemyShielded(string _enemyType, int _shieldVal)
    {
        e_sc_enemyAttributes.SetEnemyShield(e_sc_enemyAttributes.GetEnemyShieldValue() + _shieldVal);

        if (_enemyType == "Beast" || _enemyType == "Lumberjack") // Shield Physical
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/shield-physical");

            // Play Shield Particle 
            e_sc_enemyAttributes.GetEnemyShieldAppliedParticle().Play();
        }
        else if(_enemyType == "Brawler" || _enemyType == "Magician") // Shield Magic
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/shield-magic");

            // Play Shield Particle 
            e_sc_enemyAttributes.GetEnemyShieldAppliedParticle().Play();
        }
        else if(_enemyType == "Realmwalker")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/shield-physical");
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/shield-magic");

            // Play Shield Particle 
            e_sc_enemyAttributes.GetEnemyShieldAppliedParticle().Play();
        }

        // Update the UI
        UpdateEnemyHealthUI();
    }

    /// <summary>
    /// Enemy Special ability function
    /// Has to be iterated upon per new enemy type
    /// - Josh
    /// </summary>
    /// <param name="_enemyType"></param>
    public void EnemySpecialAbility(string _enemyType)
    {
        if(_enemyType == "Lumberjack")
        {
            Debug.Log("Lumberjack doesn't have a special ability!");
            return;
        }
        else if(_enemyType == "Magician")
        {
            Debug.Log("MAGICIAN USED SPECIAL ABILITY");
            MagicianSpecialAbility();
        }
        else if(_enemyType == "Brawler")
        {
            g_global.g_playerState.PlayerBleedingStatusEffect(4);
        }
        else if(_enemyType == "Beast")
        {
            g_global.g_playerState.PlayerFrailtyStatusEffect(2);
        }
        else if (_enemyType == "Realmwalker")
        {
            g_global.g_enemyState.EnemyResistantStatusEffect(5, e_i_enemyCount);
        }
    }

    /// <summary>
    /// Enemy death function
    /// Require enemy type in case we need to do death behavior down the line
    /// </summary>
    /// <param name="_enemyType"></param>
    public void EnemyDied(string _enemyType)
    {
        g_global.g_i_enemyCount -= 1;

        Debug.Log("Enemy Perished");
        e_sc_enemyAttributes.e_i_health = 0;
        g_global.g_ls_activeEnemies.Remove(this);
        g_global.e_ls_enemyList.Remove(this);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// A function just to make clear what's happening
    /// May eventually have sound effects to it
    /// - Josh
    /// </summary>
    public void ChangeIcon()
    {
        g_global.g_iconManager.EnemyIconNextTurn(this);
    }

    /// <summary>
    /// Used to toggle intent when mouse enters
    /// - Josh
    /// </summary>
    public void OnMouseEnter()
    {
        //Debug.Log("Triggered Intent!");
        if (g_global.g_iconManager.b_intentFlashBool == true)
        {
            e_sp_spriteIcon.GetComponent<SpriteRenderer>().DOFade(255, f_intentDuration);
            e_tx_intentTextObject.GetComponent<TextMeshProUGUI>().DOFade(255, f_intentDuration);
        }
    }

    /// <summary>
    /// Used to toggle intent when mouse enters
    /// - Josh
    /// </summary>
    public void OnMouseExit()
    {
        //Debug.Log("Stopping Intent!");
        if (g_global.g_iconManager.b_intentFlashBool == true)
        {
            e_sp_spriteIcon.GetComponent<SpriteRenderer>().DOFade(0, f_intentDuration);
            e_tx_intentTextObject.GetComponent<TextMeshProUGUI>().DOFade(0, f_intentDuration);
        }
    }

    /// <summary>
    /// Used to make intent visable at beginning of enemy turn
    /// A bit wonky tbh
    /// - Josh
    /// </summary>
    public void IncreaseIntentIconAlpha()
    {
        e_sp_spriteIcon.GetComponent<SpriteRenderer>().DOFade(255, 0);
        e_tx_intentTextObject.GetComponent<TextMeshProUGUI>().DOFade(255, 0);
    }

    /// <summary>
    /// Function for enemy action within their turn phase to be triggered
    /// Now in S_Enemy  
    /// - Josh
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public IEnumerator EnemyTurnAction(int _enemyNum)
    {
        if (!g_global.g_enemyState.GetEnemySkipTurnState(_enemyNum))
        {
            // Declare Turn for UI
            g_global.g_enemyState.DeclareCurrentTurn(_enemyNum);

            //Do your action
            if (g_global.g_enemyState.GetEnemyAction(_enemyNum) == 6) // Check shielding
            {
                EnemyShielded(g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_str_enemyType, g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).GetEnemyTempShield());
            }
            else if (g_global.g_enemyState.GetEnemyAction(_enemyNum) == 7) // Check attacking
            {
                g_global.g_player.PlayerAttacked(g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).GetEnemyDamageValue());

                //Then play sounds
                if (g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_str_enemyType == "Beast")
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/attack-physical");
                }
                else if (g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_str_enemyType == "Magician")
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/attack-magic");
                }
                else if (g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_str_enemyType == "Brawler")
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/attack-magic");
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/attack-physical");
                }
            }
            else if (g_global.g_enemyState.GetEnemyAction(_enemyNum) == 8) // Check special ability
            {
                g_global.g_enemyState.GetEnemyScript(_enemyNum).EnemySpecialAbility(g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_str_enemyType);
            }

            yield return new WaitForSeconds(4);

            // Set the active enemy bool to clear so the next enemy can do their turn
            g_global.g_turnManager.e_b_enemyIsActive = true;
            //Debug.Log("Returned!");
        }
        else
        {
            Debug.Log("Enemy " + _enemyNum + "'s turn is skipped!");
            yield return new WaitForSeconds(4);
        }

        UpdateEnemyHealthUI();
    }

    /// <summary>
    /// Magician increases the cost of all cardballs for a single round
    /// </summary>
    public void MagicianSpecialAbility()
    {
        if(g_global.g_enemyState.GetMagicianAbilityBool() == true) 
        {
            g_global.g_enemyState.SetMagicianAbilityValue(1);
        }
        else 
        {
            // Set the bool
            g_global.g_enemyState.SetMagicianAbilityBool(true);

            // Add the value
            g_global.g_enemyState.SetMagicianAbilityValue(1);
        }
    }

    /// <summary>
    /// Set the enemy sprite to being a smaller size when it's not their turn
    /// - Josh
    /// </summary>
    public void SetToInactiveTurnScale() 
    {
        //e_enemySprite
    }

    /// <summary>
    /// Set the enemy sprite to being a larger size when it is their turn
    /// - Josh
    /// </summary>
    public void SetToActiveTurnScale() 
    {

    }

    /// <summary>
    /// Set the enemy sprite to "default" size when it's the player's turn
    /// - Josh
    /// </summary>
    public void SetToPlayerTurnScale() 
    {
        
    }


    /// <summary>
    /// Method to update the all health and shield elements of the UI
    /// - Josh
    /// </summary>
    public void UpdateEnemyHealthUI()
    {
        if(e_sc_enemyAttributes.GetEnemyShieldValue() > 0) 
        {
            SetEnemyShieldText();
        }
        else
        {
            SetEnemyHealthText();
        }

        // Update the Audio Percentage
        EnemyHealthAudioPercentage();
    }

    /// <summary>
    /// Trigger function to set the health elements in S_CharacterGraphics
    /// - Josh
    /// </summary>
    /// <param name="_healthValue"></param>
    private void SetEnemyHealthText()
    {
        g_global.g_UIManager.sc_characterGraphics.UpdateEnemyHealthUI(e_i_enemyCount);
        g_global.g_UIManager.sc_characterGraphics.EnemyShieldingUIToggle();
    }

    /// <summary>
    /// Trigger function to set the shield elements in S_CharacterGraphics
    /// - Josh
    /// </summary>
    private void SetEnemyShieldText()
    {
        g_global.g_UIManager.sc_characterGraphics.EnemyShieldingUIToggle();
    }


    /// <summary>
    /// On being attacked, set the audio percentage so the FMOD will conform to the new value
    /// - Josh
    /// </summary>
    private void EnemyHealthAudioPercentage()
    {
        // Set the random values
        float _randomInt1 = g_global.g_audioManager.GetRandomFloatNumber();
        float _randomInt2 = g_global.g_audioManager.GetRandomFloatNumber();

        // Add them to enemy health
        float _enemyHealth = e_sc_enemyAttributes.GetEnemyHealthValue() + _randomInt1;
        float _enemyMaxHealth = e_sc_enemyAttributes.GetEnemyMaxHealthValue() + _randomInt2;

        // Calculate and Set the Percentage
        float _temp = _enemyHealth / _enemyMaxHealth;

        if (e_str_enemyType.Equals("Bananach"))
        {
            g_global.g_audioManager.SetBossAudioPercentage(_temp * 100);
        }
        else
        {
            if(e_i_enemyCount == 1)
            {
                g_global.g_audioManager.SetEnemy1AudioPercentage(_temp * 100);
            }
            else if (e_i_enemyCount == 2)
            {
                g_global.g_audioManager.SetEnemy2AudioPercentage(_temp * 100);
            }
            else if (e_i_enemyCount == 3)
            {
                g_global.g_audioManager.SetEnemy3AudioPercentage(_temp * 100);
            }
            else if (e_i_enemyCount == 4)
            {
                g_global.g_audioManager.SetEnemy4AudioPercentage(_temp * 100);
            }
            else if (e_i_enemyCount == 5)
            {
                g_global.g_audioManager.SetEnemy5AudioPercentage(_temp * 100);
            }
        }
    }
}
