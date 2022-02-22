using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_IconManager : MonoBehaviour
{
    private S_Global g_global;

    [Header("Sprite Icons")]
    public Sprite e_sp_enemyAttack;
    public Sprite e_sp_enemyShield; //sprite = sp

    [Header("Enemy Bools")]
    public bool e_b_enemy1IconCheck;
    public bool e_b_enemy2IconCheck;
    public bool e_b_enemy3IconCheck;
    public bool e_b_enemy4IconCheck;
    public bool e_b_enemy5IconCheck;

    public void Awake()
    {
        g_global = S_Global.Instance;
        e_b_enemy1IconCheck = false;
        e_b_enemy2IconCheck = false;
        e_b_enemy3IconCheck = false;
        e_b_enemy4IconCheck = false;
        e_b_enemy5IconCheck = false;
    }

    /// <summary>
    /// Based off the dice roll, change enemy icons or not
    /// </summary>
    /// <param name="_enemyToChange"></param>
    public void EnemyIconNextTurn(S_Enemy _enemyToChange)
    {
        int _chanceSelected = ShieldChance();
        if (_chanceSelected >= 50) // Set To Damage Next Turn
        {
            _enemyToChange.e_sp_spriteIcon.GetComponent<SpriteRenderer>().sprite = e_sp_enemyAttack;
            if (_enemyToChange.e_i_enemyCount == 1) //Enemy 1 is attacking next turn
            {
                e_b_enemy1IconCheck = true;
            }
            else if (_enemyToChange.e_i_enemyCount == 2) //Enemy 2 is attacking next turn
            {
                e_b_enemy2IconCheck = true;
            }
            else if (_enemyToChange.e_i_enemyCount == 3) //Enemy 3 is attacking next turn
            {
                e_b_enemy3IconCheck = true;
            }
            else if (_enemyToChange.e_i_enemyCount == 4) //Enemy 4 is attacking next turn
            {
                e_b_enemy4IconCheck = true;
            }
            else if (_enemyToChange.e_i_enemyCount == 5) //Enemy 5 is attacking next turn
            {
                e_b_enemy5IconCheck = true;
            }
        }
        else // Set To Shield
        {
            _enemyToChange.e_sp_spriteIcon.GetComponent<SpriteRenderer>().sprite = e_sp_enemyShield;
            if (_enemyToChange.e_i_enemyCount == 1)
            {
                e_b_enemy1IconCheck = false;
            }
            else if (_enemyToChange.e_i_enemyCount == 2)
            {
                e_b_enemy2IconCheck = false;
            }
            else if (_enemyToChange.e_i_enemyCount == 3)
            {
                e_b_enemy3IconCheck = false;
            }
            else if (_enemyToChange.e_i_enemyCount == 4)
            {
                e_b_enemy4IconCheck = false;
            }
            else if (_enemyToChange.e_i_enemyCount == 5)
            {
                e_b_enemy5IconCheck = false;
            }
        }
    }

    /// <summary>
    /// This is a dice roll to see if indicators will change
    /// </summary>
    /// <returns></returns>
    private int ShieldChance()
    {
        int _chance = Random.Range(0, 101); // Hardcoded for lumberjack, may create different ones or add this to the enemy at somepoint
        return _chance;
    }
}
