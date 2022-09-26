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

    public S_EnemyAttributes e_sc_enemyAttributes;

    [Header("Real name identifier")]
    public string e_str_enemyName;

    [Header("Enemy Type")]
    [Tooltip("This is a string, do not add quotes on it. - Josh")]
    public string e_str_enemyType; //Also in attributes, delete from here later, improper placing

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

    //getting cardball object
    public GameObject cardball;

    void Awake()
    {
        g_global = S_Global.Instance;

        SetCount(); 
        
        //Debug.Log("Testing for enemy count: " + e_i_enemyCount.ToString());

        g_global.e_ls_enemyList.Add(this);

        e_cd_sc_characterCardInterface.e_attachedEnemy = this;

        // Grab and set default scale
        e_v3_defaultScale = gameObject.transform.localScale;

        g_global.g_ls_activeEnemies.Add(this);
    }

    private void Start()
    {
        //If enemy 1, move spots
        if (e_i_enemyCount == 1)
        {
            gameObject.transform.SetParent(g_global.g_e_enemyPosition1.transform, false);
        }

        //If enemy 2, move spots
        if (e_i_enemyCount == 2)
        {
            gameObject.transform.SetParent(g_global.g_e_enemyPosition2.transform, false);
        }

        //If enemy 3, move spots
        if (e_i_enemyCount == 3)
        {
            gameObject.transform.SetParent(g_global.g_e_enemyPosition3.transform, false);
        }

        // Need to add in enemy 4 and 5 placement and the scene knowing if it should have 3 enemies or 5 enemies from S_GameManager or even get something set initially as a bool in S_Global we toggle
        // - Josh
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
    /// <param name="_damageVal"></param>
    public void EnemyAttacked(string _enemyType, int _damageValue) 
    {
        if (_enemyType == "Lumberjack" || _enemyType == "Magician" || _enemyType == "Beast" || _enemyType == "Brawler")
        {
            int _newDamageValue = (int)_damageValue / 2;
            if(e_sc_enemyAttributes.e_b_resistant == true) //If the enemy is resisitant
            {
                if (e_sc_enemyAttributes.GetEnemyShieldValue() <= 0) //The enemy has no sheilds
                {
                    e_sc_enemyAttributes.e_i_health -= _newDamageValue;
                    e_sc_enemyAttributes.e_pe_blood.Play();
                    Debug.Log("Enemy Attacked!");
                }
                else //enemy has shields
                {
                    int _tempVal = e_sc_enemyAttributes.GetEnemyShieldValue() - _newDamageValue;
                    if (_tempVal < 0) 
                    {
                        e_sc_enemyAttributes.SetEnemyShield(e_sc_enemyAttributes.GetEnemyShieldValue() - _newDamageValue);
                        if (e_sc_enemyAttributes.GetEnemyShieldValue() < 0)
                        {
                            e_sc_enemyAttributes.SetEnemyShield(0);
                        }
                        EnemyAttacked(_enemyType, Mathf.Abs(_tempVal));
                        e_sc_enemyAttributes.e_pe_blood.Play();
                        Debug.Log("Enemy didn't have enough shields!");
                    }
                    else
                    {
                        e_sc_enemyAttributes.SetEnemyShield(e_sc_enemyAttributes.GetEnemyShieldValue() - _newDamageValue);
                        Debug.Log("Enemy had shields!");
                    }
                }
            }
            else //if the enemy is not resistant
            {
                if (e_sc_enemyAttributes.GetEnemyShieldValue() <= 0) //enemy has no shields
                {
                    e_sc_enemyAttributes.e_i_health -= _damageValue;
                    e_sc_enemyAttributes.e_pe_blood.Play();
                    e_sc_enemyAttributes.e_a_animator.Play("Damaged");
                    Debug.Log("Enemy Attacked!");
                }
                else //enemy has shields
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
                        e_sc_enemyAttributes.e_pe_blood.Play();
                        e_sc_enemyAttributes.e_a_animator.Play("Damaged");
                        Debug.Log("Enemy didn't have enough shields!");
                    }
                    else
                    {
                        e_sc_enemyAttributes.SetEnemyShield(e_sc_enemyAttributes.GetEnemyShieldValue() - _damageValue);
                        Debug.Log("Enemy had shields!");
                    }
                }
            }
        }
        else //The enemy is not a predetermined type
        {
            if (e_sc_enemyAttributes.GetEnemyShieldValue() <= 0) //enemy has no shields
            {
                e_sc_enemyAttributes.e_i_health -= _damageValue;
                e_sc_enemyAttributes.e_pe_blood.Play();
                e_sc_enemyAttributes.e_a_animator.Play("Damaged");
                Debug.Log("Enemy Attacked!");
            }
            else //enemy has shields
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
                    e_sc_enemyAttributes.e_pe_blood.Play();
                    e_sc_enemyAttributes.e_a_animator.Play("Damaged");
                    Debug.Log("Enemy didn't have enough shields!");
                }
                else
                {
                    e_sc_enemyAttributes.SetEnemyShield(e_sc_enemyAttributes.GetEnemyShieldValue() - _damageValue);
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

        if(_enemyType == "Beast" || _enemyType == "Lumberjack") // Shield Physical
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/shield-physical");
        }
        else if(_enemyType == "Brawler") // Shield Magic
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/shield-magic");
        }
        else if(_enemyType == "Brawler")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/shield-physical");
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/shield-magic");
        }

        // Update the UI
        UpdateEnemyHealthUI();
    }

    /// <summary>
    /// If an enemy heals itself down the line
    /// - Josh
    /// </summary>
    /// <param name="_healthVal"></param>
    public void EnemyHealed(int _healthVal)
    {
        e_sc_enemyAttributes.e_i_health += _healthVal;
        Debug.Log("Enemy Heals");
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
        if(_enemyType == "Magician")
        {
            MagicianSpecialAbility();
        }
        if(_enemyType == "Brawler")
        {
            g_global.g_enemyState.EnemyResistantEffect(1, e_i_enemyCount); 
        }
        if(_enemyType == "Beast")
        {
            g_global.g_playerState.PlayerBleedingStatusEffect(3, 3);
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
    /// Toggle the highlight element for the enemy
    /// - Josh
    /// </summary>
    /// <param name="_enemy"></param>
    public void EnemyHighlightToggle()
    {
        /*if(e_sc_enemyAttributes.e_highlightCircle.activeInHierarchy == false) 
        {
            e_sc_enemyAttributes.e_highlightCircle.SetActive(true);
        }
        else 
        {
            e_sc_enemyAttributes.e_highlightCircle.SetActive(false);
        }*/
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
        if (!g_global.g_enemyState.EnemySkipTurnCheck(_enemyNum))
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
                //play enemy animation
                g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_a_animator.Play("attack");

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
    }

    /// <summary>
    /// magiciain unique ablility
    /// gnerates random number from 1-5
    /// deletes that card
    /// resets list
    /// - GOAT
    /// </summary>
    public void MagicianSpecialAbility()
    {
        int numDelete = Random.Range(1, 6);

        S_Cardball _cardball = g_global.g_ls_cardBallPrefabs[numDelete];
        _cardball.DeleteCardball();
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
    /// Method to update the health UI of the enemy
    /// </summary>
    private void UpdateEnemyHealthUI()
    {
        if(e_sc_enemyAttributes.GetEnemyShieldValue() > 0) 
        {
            SetEnemyShieldText(e_sc_enemyAttributes.GetEnemyShieldValue());
        }
        else
        {
            SetEnemyHealthText(e_sc_enemyAttributes.e_i_health);
        }
    }
    
    private void SetEnemyHealthText(int _healthVal)
    {

    }

    
    private void SetEnemyShieldText(int _shieldVal)
    {
        g_global.g_UIManager.sc_characterGraphics.PlayerShieldingUIToggle();
    }
}
