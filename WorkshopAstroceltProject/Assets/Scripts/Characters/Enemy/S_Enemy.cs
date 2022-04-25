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
    [SerializeField] GameObject a_audioPlayer;

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

        a_audioPlayer = GameObject.Find("/Audio/Sound Effects/Attack/Vanilla");
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
        //sound effect goes here
        a_audioPlayer.SetActive(true);

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

    public void EnemyShielded(int _shieldVal)
    {
        e_enemyAttributes.e_i_shield += _shieldVal;
        Debug.Log("Enemy Shields");
    }

    public void EnemyHealed(int _healthVal)
    {
        e_enemyAttributes.e_i_health += _healthVal;
        Debug.Log("Enemy Heals");
    }

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

    // Require enemy type in case we need to do death behavior
    public void EnemyDied(string _enemyType)
    {
        g_global.g_i_enemyCount -= 1;
        Debug.Log("Enemy Perished");
        g_global.g_selectorManager.SelectorReset();
        e_enemyAttributes.e_i_health = 0;
        gameObject.SetActive(false);
    }

    public void ChangeIcon()
    {
        g_global.g_iconManager.EnemyIconNextTurn(this);
    }

    // Trigger intent when mouse enters
    public void OnHoverEnter()
    {
        //Debug.Log("Triggered Intent!");
        if (g_global.g_iconManager.b_intentFlashBool == true)
        {
            e_sp_spriteIcon.GetComponent<Image>().DOFade(255, f_intentDuration);
            e_tx_intentTextObject.GetComponent<TextMeshProUGUI>().DOFade(255, f_intentDuration);
        }
    }

    // Trigger intent when mouse exits
    public void OnHoverExit()
    {
        //Debug.Log("Stopping Intent!");
        if (g_global.g_iconManager.b_intentFlashBool == true)
        {
            e_sp_spriteIcon.GetComponent<Image>().DOFade(0, f_intentDuration);
            e_tx_intentTextObject.GetComponent<TextMeshProUGUI>().DOFade(0, f_intentDuration);
        }
    }

    public void IncreaseIntentAlpha()
    {
        e_sp_spriteIcon.GetComponent<Image>().DOFade(255, 0);
        e_tx_intentTextObject.GetComponent<TextMeshProUGUI>().DOFade(255, 0);
    }

    // Eventually use this
    private void SetEnemyHealthText(int _healthVal)
    {

    }

    //Only do this to 5
    private void SetEnemyShieldText(int _shieldVal)
    {

    }
}
