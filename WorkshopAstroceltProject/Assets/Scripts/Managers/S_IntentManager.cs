using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro; 

public class S_IntentManager : MonoBehaviour
{
    private S_Global g_global;

    [Header("Sprite Icons")]
    public Sprite e_sp_enemyShield; //sprite = sp
    public Sprite e_sp_enemyAbility; 

    [Header("Enemy Status Strings")]
    public string e_b_enemy1IconCheck;
    public string e_b_enemy2IconCheck;
    public string e_b_enemy3IconCheck;
    public string e_b_enemy4IconCheck;
    public string e_b_enemy5IconCheck;

    [Header("Intent UI Elements")]
    public Sprite e_sp_enemyAttackLevel1;
    public Sprite e_sp_enemyAttackLevel2;
    public Sprite e_sp_enemyAttackLevel3;
    public Sprite e_sp_enemyAttackLevel4;
    public Sprite e_sp_enemyAttackLevel5;

    [Header("Intent Fade Boolean")]
    public bool b_intentFlashBool;

    [Header("Intent Timer Values")]
    [Tooltip("Jager, tweak these vaues for Tweening - Josh")] [SerializeField] float f_intentTimer;
    private float f_intentTimerMax;
    [SerializeField] float f_doIntentFadeAlpha;
    [SerializeField] float f_doIntentFadeDuration;

    private void Awake()
    {
        g_global = S_Global.Instance;

        b_intentFlashBool = false;
    }

    /// <summary>
    /// Based off the dice roll, change enemy icons to correlate to their next turn action
    /// </summary>
    /// <param name="_enemyToChange"></param>
    public void EnemyIconNextTurn(S_Enemy _enemyToChange)
    {
        int _chanceSelected = 100 - IntentDiceRoll();
        //Debug.Log("Roll is " + _chanceSelected + " for " + _enemyToChange.e_i_enemyCount);
        if (_chanceSelected <= _enemyToChange.e_sc_enemyAttributes.e_i_specialAbilityRate) // Set Enemy up for Special Ability
        {
            UIChangesForIntent(_enemyToChange, 3);
            if (_enemyToChange.e_i_enemyCount == 1) // Enemy 1 special ability next turn
            {
                e_b_enemy1IconCheck = "ability";
            }
            else if (_enemyToChange.e_i_enemyCount == 2) // Enemy 2 special ability next turn
            {
                e_b_enemy2IconCheck = "ability";
            }
            else if (_enemyToChange.e_i_enemyCount == 3) // Enemy 3 special ability next turn
            {
                e_b_enemy3IconCheck = "ability";
            }
            else if (_enemyToChange.e_i_enemyCount == 4) // Enemy 4 special ability next turn
            {
                e_b_enemy4IconCheck = "ability";
            }
            else if (_enemyToChange.e_i_enemyCount == 5) // Enemy 5 special ability next turn
            {
                e_b_enemy5IconCheck = "ability";
            }
        }
        else if (_chanceSelected <= _enemyToChange.e_sc_enemyAttributes.e_i_shieldRate && _chanceSelected >= _enemyToChange.e_sc_enemyAttributes.e_i_specialAbilityRate) // Set Enemy up for Shield
        {
            UIChangesForIntent(_enemyToChange, 2);
            if (_enemyToChange.e_i_enemyCount == 1) // Enemy 1 shielding next turn
            {
                e_b_enemy1IconCheck = "shield";
            }
            else if (_enemyToChange.e_i_enemyCount == 2) // Enemy 2 shielding next turn
            {
                e_b_enemy2IconCheck = "shield";
            } 
            else if (_enemyToChange.e_i_enemyCount == 3) // Enemy 3 shielding next turn
            {
                e_b_enemy3IconCheck = "shield";
            }
            else if (_enemyToChange.e_i_enemyCount == 4) // Enemy 4 shielding next turn
            {
                e_b_enemy4IconCheck = "shield";
            }
            else if (_enemyToChange.e_i_enemyCount == 5) // Enemy 5 shielding next turn
            {
                e_b_enemy5IconCheck = "shield";
            }
        }
        else if (_chanceSelected <= _enemyToChange.e_sc_enemyAttributes.e_i_attackRate && _chanceSelected >= _enemyToChange.e_sc_enemyAttributes.e_i_shieldRate) // Set Enemy up for Attack
        {
            UIChangesForIntent(_enemyToChange, 1);
            if (_enemyToChange.e_i_enemyCount == 1) //Enemy 1 is attacking next turn
            {
                e_b_enemy1IconCheck = "attack";
            }
            else if (_enemyToChange.e_i_enemyCount == 2) //Enemy 2 is attacking next turn
            {
                e_b_enemy2IconCheck = "attack";
            }
            else if (_enemyToChange.e_i_enemyCount == 3) //Enemy 3 is attacking next turn
            {
                e_b_enemy3IconCheck = "attack";
            }
            else if (_enemyToChange.e_i_enemyCount == 4) //Enemy 4 is attacking next turn
            {
                e_b_enemy4IconCheck = "attack";
            }
            else if (_enemyToChange.e_i_enemyCount == 5) //Enemy 5 is attacking next turn
            {
                e_b_enemy5IconCheck = "attack";
            }
        }

    }

    /// <summary>
    /// This is a dice roll to see if indicators will change
    /// - Josh
    /// </summary>
    /// <returns></returns>
    private int IntentDiceRoll()
    {
        int _chance = Random.Range(0, 100); // "Die roll" is in terms of percent
        return _chance;
    }

    /// <summary>
    /// Function to switch out the UI elements based off intent levels
    /// - Josh
    /// </summary>
    public void UIChangesForIntent(S_Enemy _enemy, int _enemyAction)
    {
        S_EnemyAttributes _enemyAttributeSheet = _enemy.e_sc_enemyAttributes;
        if(_enemyAction == 1)
        {
            _enemyAttributeSheet.AttackDamageRoll();
            if (_enemyAttributeSheet.e_i_enemyDamageValue == 1 || _enemyAttributeSheet.e_i_enemyDamageValue == 2) // If Attack Damage will be 1 or 2
            {
                _enemy.e_sp_spriteIcon.GetComponent<Image>().sprite = e_sp_enemyAttackLevel1;
            }
            else if (_enemyAttributeSheet.e_i_enemyDamageValue == 3 || _enemyAttributeSheet.e_i_enemyDamageValue == 4) // If Attack Damage will be 3 or 4
            {
                _enemy.e_sp_spriteIcon.GetComponent<Image>().sprite = e_sp_enemyAttackLevel2;
            }
            else if (_enemyAttributeSheet.e_i_enemyDamageValue == 5 || _enemyAttributeSheet.e_i_enemyDamageValue == 6) // If Attack Damage will be 5 or 6
            {
                _enemy.e_sp_spriteIcon.GetComponent<Image>().sprite = e_sp_enemyAttackLevel3;
            }
            else if (_enemyAttributeSheet.e_i_enemyDamageValue == 7 || _enemyAttributeSheet.e_i_enemyDamageValue == 8) // If Attack Damage will be 7 or 8
            {
                _enemy.e_sp_spriteIcon.GetComponent<Image>().sprite = e_sp_enemyAttackLevel4;
            }
            else if (_enemyAttributeSheet.e_i_enemyDamageValue >= 9) // If Attack Damage will be 9+
            {
                _enemy.e_sp_spriteIcon.GetComponent<Image>().sprite = e_sp_enemyAttackLevel5;
            }
            ChangeIntentTextUI(_enemyAttributeSheet.e_i_enemyDamageValue, _enemy);
        }
        else if(_enemyAction == 2)
        {
            _enemy.e_sp_spriteIcon.GetComponent<Image>().sprite = e_sp_enemyShield;
            ChangeIntentTextUI(_enemyAttributeSheet.e_i_shieldMax, _enemy);
        }
        else if (_enemyAction == 3)
        {
            _enemy.e_sp_spriteIcon.GetComponent<Image>().sprite = e_sp_enemyAbility;
            ChangeIntentTextUI(-1, _enemy);
        }
    }

    /// <summary>
    /// Helper Function
    /// If there's a special ability, turn off text (maybe a different tooltip eventually)
    /// Update with appropriate attack or shield numbers otherwise
    /// - Josh
    /// </summary>
    /// <param name="_valueNum"></param>
    /// <param name="_enemy"></param>
    private void ChangeIntentTextUI(int _valueNum, S_Enemy _enemy)
    {
        GameObject _textObject = _enemy.e_tx_intentTextObject;
        _textObject.SetActive(true);
        if(_valueNum == -1)
        {
            _textObject.SetActive(false);
        }
        else
        {
            TextMeshProUGUI _textText = _textObject.GetComponent<TextMeshProUGUI>();
            _textText.text = "" + _valueNum;
        }


        // Trigger the intent for next turn
        FlashIntentStart(_enemy);
    }


    public void FlashIntentStart(S_Enemy _enemy)
    {
        b_intentFlashBool = false;
        StartCoroutine(IntentFade(_enemy));
    }

    private IEnumerator IntentFade(S_Enemy _enemy)
    {
        while(!b_intentFlashBool) 
        {
            yield return new WaitForSeconds(f_intentTimer);
            _enemy.e_sp_spriteIcon.GetComponent<Image>().DOFade(f_doIntentFadeAlpha, f_doIntentFadeDuration);
            _enemy.e_tx_intentTextObject.GetComponent<TextMeshProUGUI>().DOFade(f_doIntentFadeAlpha, f_doIntentFadeDuration);

            yield return new WaitForSeconds(f_doIntentFadeDuration);
            b_intentFlashBool = true;
        }
    }

}
