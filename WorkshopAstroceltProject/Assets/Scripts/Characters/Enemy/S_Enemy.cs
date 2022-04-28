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

    public S_EnemyAttributes e_enemyAttributes;

    [Header("Enemy Type")]
    [Tooltip("This is a string, do not add quotes on it. - Josh")]
    public string e_str_enemyType; //Also in attributes, delete from here later, improper placing

    [Header("Enemy Count")]
    public int e_i_enemyCount;

    [Header("Intent Assets")]
    public GameObject e_sp_spriteIcon;
    public GameObject e_tx_intentTextObject;

    [Header("Enemy Sprite")]
    public GameObject e_enemySprite;

    [Header("Intent Duration Value")]
    public float f_intentDuration; 

    void Awake()
    {
        g_global = S_Global.Instance;

        SetCount(); 
        
        //Debug.Log("Testing for enemy count: " + e_i_enemyCount.ToString());

        g_global.e_l_enemyList.Add(this);

        e_enemySprite.GetComponent<S_CharacterCardInterface>().e_attachedEnemy = this;

        //a_audioPlayer = GameObject.Find("/Audio/Sound Effects/Attack/Vanilla");
    }

    private void Start()
    {
        //If enemy 1 move spots
        if (e_i_enemyCount == 1)
        {
            gameObject.transform.SetParent(g_global.g_e_enemyPosition1.transform, false);
        }

        //If enemy 2 move spots
        if (e_i_enemyCount == 2)
        {
            gameObject.transform.SetParent(g_global.g_e_enemyPosition2.transform, false);
        }

        //If enemy 3 move spots
        if (e_i_enemyCount == 3)
        {
            gameObject.transform.SetParent(g_global.g_e_enemyPosition3.transform, false);
        }
    }

    void SetCount()
    {
        g_global.g_i_enemyCount += 1;
        e_i_enemyCount = g_global.g_i_enemyCount;
        return; 
    }

    /// <summary>
    /// Enemy attacked
    /// Update for Magician
    /// - Josh
    /// </summary>
    /// <param name="_enemyType"></param>
    /// <param name="_damageVal"></param>
    public void EnemyAttacked(string _enemyType, int _damageValue)
    {
        if (_enemyType == "Lumberjack" || _enemyType == "Magician" || _enemyType == "Beast" || _enemyType == "Brawler")
        {
            int _newDamageValue = (int)_damageValue / 2;
            if(e_enemyAttributes.e_b_resistant == true)
            {
                if (e_enemyAttributes.e_i_shield <= 0)
                {
                    e_enemyAttributes.e_i_health -= _newDamageValue;
                    Debug.Log("Enemy Attacked!");
                }
                else
                {
                    int _tempVal = e_enemyAttributes.e_i_shield - _newDamageValue;
                    if (_tempVal < 0)
                    {
                        e_enemyAttributes.e_i_shield -= _newDamageValue;
                        if (e_enemyAttributes.e_i_shield < 0)
                        {
                            e_enemyAttributes.e_i_shield = 0;
                        }
                        EnemyAttacked(_enemyType, Mathf.Abs(_tempVal));
                        Debug.Log("Enemy didn't have enough shields!");
                    }
                    else
                    {
                        e_enemyAttributes.e_i_shield -= _newDamageValue;
                        Debug.Log("Enemy had shields!");
                    }
                }
            }
            else
            {
                if (e_enemyAttributes.e_i_shield <= 0)
                {
                    e_enemyAttributes.e_i_health -= _damageValue;
                    Debug.Log("Enemy Attacked!");
                }
                else
                {
                    int _tempVal = e_enemyAttributes.e_i_shield - _damageValue;
                    if (_tempVal < 0)
                    {
                        e_enemyAttributes.e_i_shield -= _damageValue;
                        if (e_enemyAttributes.e_i_shield < 0)
                        {
                            e_enemyAttributes.e_i_shield = 0;
                        }
                        EnemyAttacked(_enemyType, Mathf.Abs(_tempVal));
                        Debug.Log("Enemy didn't have enough shields!");
                    }
                    else
                    {
                        e_enemyAttributes.e_i_shield -= _damageValue;
                        Debug.Log("Enemy had shields!");
                    }
                }
            }
        }
        else
        {
            if (e_enemyAttributes.e_i_shield <= 0)
            {
                e_enemyAttributes.e_i_health -= _damageValue;
                Debug.Log("Enemy Attacked!");
            }
            else
            {
                int _tempVal = e_enemyAttributes.e_i_shield - _damageValue;
                if (_tempVal < 0)
                {
                    e_enemyAttributes.e_i_shield -= _damageValue;
                    if (e_enemyAttributes.e_i_shield < 0)
                    {
                        e_enemyAttributes.e_i_shield = 0;
                    }
                    EnemyAttacked(_enemyType, Mathf.Abs(_tempVal));
                    Debug.Log("Enemy didn't have enough shields!");
                }
                else
                {
                    e_enemyAttributes.e_i_shield -= _damageValue;
                    Debug.Log("Enemy had shields!");
                }
            }
        }
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
        e_enemyAttributes.e_i_shield += _shieldVal;
        if(_enemyType == "Beast" || _enemyType == "Lumberjack") // Shield Physical
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/shield-physical");
        }
        else if(_enemyType == "Brawler") // Shield Magic
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/shield-magic");
        }
        else if(_enemyType == "Brawler")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/shield-physical");
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/shield-magic");
        }

        Debug.Log("Enemy Shields");
    }

    /// <summary>
    /// If an enemy heals itself down the line
    /// - Josh
    /// </summary>
    /// <param name="_healthVal"></param>
    public void EnemyHealed(int _healthVal)
    {
        e_enemyAttributes.e_i_health += _healthVal;
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
            //g_global.g_playerState.PlayerStunnedStatusEffect(1);
            g_global.g_enemyState.EnemyResistantEffect(1, e_i_enemyCount);
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
        e_enemyAttributes.e_i_health = 0;
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
    public void OnHoverEnter()
    {
        //Debug.Log("Triggered Intent!");
        if (g_global.g_iconManager.b_intentFlashBool == true)
        {
            e_sp_spriteIcon.GetComponent<Image>().DOFade(255, f_intentDuration);
            e_tx_intentTextObject.GetComponent<TextMeshProUGUI>().DOFade(255, f_intentDuration);
        }
    }

    /// <summary>
    /// Used to toggle intent when mouse enters
    /// - Josh
    /// </summary>
    public void OnHoverExit()
    {
        //Debug.Log("Stopping Intent!");
        if (g_global.g_iconManager.b_intentFlashBool == true)
        {
            e_sp_spriteIcon.GetComponent<Image>().DOFade(0, f_intentDuration);
            e_tx_intentTextObject.GetComponent<TextMeshProUGUI>().DOFade(0, f_intentDuration);
        }
    }

    /// <summary>
    /// Used to make intent visable at beginning of enemy turn
    /// A bit wonky tbh
    /// - Josh
    /// </summary>
    public void IncreaseIntentAlpha()
    {
        e_sp_spriteIcon.GetComponent<Image>().DOFade(255, 0);
        e_tx_intentTextObject.GetComponent<TextMeshProUGUI>().DOFade(255, 0);
    }

    // Eventually use this for UI stuff to avoid using an update loop
    private void SetEnemyHealthText(int _healthVal)
    {

    }

    //Only do this to 5
    private void SetEnemyShieldText(int _shieldVal)
    {

    }
}
