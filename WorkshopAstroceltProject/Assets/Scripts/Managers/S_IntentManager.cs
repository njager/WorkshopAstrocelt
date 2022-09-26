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
    public List<string> ls_e_statusStrings;

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

        ls_e_statusStrings.Add("first");
        ls_e_statusStrings.Add("second");
        ls_e_statusStrings.Add("third");
        ls_e_statusStrings.Add("fourth");
        ls_e_statusStrings.Add("fifth");
    }

    /// <summary>
    /// Changed to use the queue system
    /// enemy atribute has a list, remove from the front for the next ability and add to the back to make it go forever
    /// - Riley
    /// </summary>
    /// <param name="_enemyToChange"></param>
    public void EnemyIconNextTurn(S_Enemy _enemyToChange)
    {
        //Make a temp queue
        List<S_EnemyMoves> _tempQueue = _enemyToChange.e_sc_enemyAttributes.GetMoveQueue();

        if (_tempQueue[0].s_action.Equals("ability")) // Set Enemy up for Special Ability
        {
            //get the first element
            S_EnemyMoves _tempElement = _tempQueue[0];

            //remove from the front, add to the back
            _tempQueue.RemoveAt(0);
            _tempQueue.Add(_tempElement);

            UIChangesForIntent(_enemyToChange, 3);

            ls_e_statusStrings[_enemyToChange.e_i_enemyCount - 1] = "ability";
        }

        else if (_tempQueue[0].s_action.Equals("shield")) // Set Enemy up for Shield
        {
            //get the first element
            S_EnemyMoves _tempElement = _tempQueue[0];

            //Assign the shiled value
            _enemyToChange.e_sc_enemyAttributes.SetEnemyTempShield(_tempElement.i_actionValue);

            //remove from the front, add to the back
            _tempQueue.RemoveAt(0);
            _tempQueue.Add(_tempElement);

            UIChangesForIntent(_enemyToChange, 2);

            ls_e_statusStrings[_enemyToChange.e_i_enemyCount - 1] = "shield";
        }
        else if (_tempQueue[0].s_action.Equals("attack"))  // Set Enemy up for Attack
        {
            //get the first element
            S_EnemyMoves _tempElement = _tempQueue[0];

            //assign the attack value
            _enemyToChange.e_sc_enemyAttributes.SetEnemyDamageValue(_tempElement.i_actionValue);

            //remove from the front, add to the back
            _tempQueue.RemoveAt(0);
            _tempQueue.Add(_tempElement);

            UIChangesForIntent(_enemyToChange, 1);

            ls_e_statusStrings[_enemyToChange.e_i_enemyCount - 1] = "attack";
        }
        else
        {
            Debug.Log("Move not recognized");
        }

        //Set the move queue 
        _enemyToChange.e_sc_enemyAttributes.SetMoveQueue(_tempQueue);
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
            if (_enemyAttributeSheet.GetEnemyDamageValue() == 1 || _enemyAttributeSheet.GetEnemyDamageValue() == 2) // If Attack Damage will be 1 or 2
            {
                _enemy.e_sp_spriteIcon.GetComponent<SpriteRenderer>().sprite = e_sp_enemyAttackLevel1;
            }
            else if (_enemyAttributeSheet.GetEnemyDamageValue() == 3 || _enemyAttributeSheet.GetEnemyDamageValue() == 4) // If Attack Damage will be 3 or 4
            {
                _enemy.e_sp_spriteIcon.GetComponent<SpriteRenderer>().sprite = e_sp_enemyAttackLevel2;
            }
            else if (_enemyAttributeSheet.GetEnemyDamageValue() == 5 || _enemyAttributeSheet.GetEnemyDamageValue() == 6) // If Attack Damage will be 5 or 6
            {
                _enemy.e_sp_spriteIcon.GetComponent<SpriteRenderer>().sprite = e_sp_enemyAttackLevel3;
            }
            else if (_enemyAttributeSheet.GetEnemyDamageValue() == 7 || _enemyAttributeSheet.GetEnemyDamageValue() == 8) // If Attack Damage will be 7 or 8
            {
                _enemy.e_sp_spriteIcon.GetComponent<SpriteRenderer>().sprite = e_sp_enemyAttackLevel4;
            }
            else if (_enemyAttributeSheet.GetEnemyDamageValue() >= 9) // If Attack Damage will be 9+
            {
                _enemy.e_sp_spriteIcon.GetComponent<SpriteRenderer>().sprite = e_sp_enemyAttackLevel5;
            }
            ChangeIntentTextUI(_enemyAttributeSheet.GetEnemyDamageValue(), _enemy);
        }
        else if(_enemyAction == 2)
        {
            _enemy.e_sp_spriteIcon.GetComponent<SpriteRenderer>().sprite = e_sp_enemyShield;
            ChangeIntentTextUI(_enemyAttributeSheet.GetEnemyShieldValue(), _enemy);
        }
        else if (_enemyAction == 3)
        {
            _enemy.e_sp_spriteIcon.GetComponent<SpriteRenderer>().sprite = e_sp_enemyAbility;
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
            _enemy.e_sp_spriteIcon.GetComponent<SpriteRenderer>().DOFade(f_doIntentFadeAlpha, f_doIntentFadeDuration);
            _enemy.e_tx_intentTextObject.GetComponent<TextMeshProUGUI>().DOFade(f_doIntentFadeAlpha, f_doIntentFadeDuration);

            yield return new WaitForSeconds(f_doIntentFadeDuration);
            b_intentFlashBool = true;
        }
    }

}
