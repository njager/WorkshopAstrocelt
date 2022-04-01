using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_IntentManager : MonoBehaviour
{
    private S_Global g_global;

    [Header("Sprite Icons")]
    public Sprite e_sp_enemyAttack;
    public Sprite e_sp_enemyShield; //sprite = sp
    public Sprite e_sp_enemyAbility; 

    [Header("Enemy Status Strings")]
    public string e_b_enemy1IconCheck;
    public string e_b_enemy2IconCheck;
    public string e_b_enemy3IconCheck;
    public string e_b_enemy4IconCheck;
    public string e_b_enemy5IconCheck;

    public void Awake()
    {
        g_global = S_Global.Instance;
    }

    /// <summary>
    /// Based off the dice roll, change enemy icons or not
    /// Hardcoded for magician update to be smarter
    /// </summary>
    /// <param name="_enemyToChange"></param>
    public void EnemyIconNextTurn(S_Enemy _enemyToChange)
    {
        int _chanceSelected = IntentDiceRoll();
        if (_chanceSelected == 1 || _chanceSelected == 2) // Set Enemy up for Attack
        {
            _enemyToChange.e_sp_spriteIcon.GetComponent<Image>().sprite = e_sp_enemyAttack;
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
        else if (_chanceSelected == 3)
        {
            _enemyToChange.e_sp_spriteIcon.GetComponent<Image>().sprite = e_sp_enemyShield;
            if (_enemyToChange.e_i_enemyCount == 1)
            {
                e_b_enemy1IconCheck = "shield";
            }
            else if (_enemyToChange.e_i_enemyCount == 2)
            {
                e_b_enemy2IconCheck = "shield";
            }
            else if (_enemyToChange.e_i_enemyCount == 3)
            {
                e_b_enemy3IconCheck = "shield";
            }
            else if (_enemyToChange.e_i_enemyCount == 4)
            {
                e_b_enemy4IconCheck = "shield";
            }
            else if (_enemyToChange.e_i_enemyCount == 5)
            {
                e_b_enemy5IconCheck = "shield";
            }
        }
        else if (_chanceSelected == 4)
        {
            _enemyToChange.e_sp_spriteIcon.GetComponent<Image>().sprite = e_sp_enemyAbility;
            if (_enemyToChange.e_i_enemyCount == 1)
            {
                e_b_enemy1IconCheck = "ability";
            }
            else if (_enemyToChange.e_i_enemyCount == 2)
            {
                e_b_enemy2IconCheck = "ability";
            }
            else if (_enemyToChange.e_i_enemyCount == 3)
            {
                e_b_enemy3IconCheck = "ability";
            }
            else if (_enemyToChange.e_i_enemyCount == 4)
            {
                e_b_enemy4IconCheck = "ability";
            }
            else if (_enemyToChange.e_i_enemyCount == 5)
            {
                e_b_enemy5IconCheck = "ability";
            }
        }
    }

    /// <summary>
    /// This is a dice roll to see if indicators will change
    /// </summary>
    /// <returns></returns>
    private int IntentDiceRoll()
    {
        int _chance = Random.Range(1, 5); // Hardcoded
        return _chance;
    }
}
