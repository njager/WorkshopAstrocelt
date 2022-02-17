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
    public bool e_b_enemy1Attacking;
    public bool e_b_enemy2Attacking;
    public bool e_b_enemy3Attacking;

    public void Awake()
    {
        g_global = S_Global.Instance; 
    }

    /// <summary>
    /// Based off the dice roll, change enemy icons or not
    /// </summary>
    /// <param name="_givenEnemyIcon"></param>
    public void EnemyActionNextTurn(GameObject _givenEnemyIcon)
    {
        int _chanceSelected = ShieldChance();
        if (_chanceSelected > 3) // Set To Damage Next Turn
        {
            _givenEnemyIcon.GetComponent<SpriteRenderer>().sprite = e_sp_enemyAttack;
            if (_givenEnemyIcon.CompareTag("Icon1") == true)
            {
                e_b_enemy1Attacking = true;
                return;
            }
            if (_givenEnemyIcon.CompareTag("Icon2") == true)
            {
                e_b_enemy2Attacking = true;
                return;
            }
            if (_givenEnemyIcon.CompareTag("Icon3") == true)
            {
                e_b_enemy3Attacking = true;
                return;
            }
        }
        else // Set To Shield
        {
            _givenEnemyIcon.GetComponent<SpriteRenderer>().sprite = e_sp_enemyShield;
            if (_givenEnemyIcon.CompareTag("Icon1") == true)
            {
                e_b_enemy1Attacking = false;
                return;
            }
            if (_givenEnemyIcon.CompareTag("Icon2") == true)
            {
                e_b_enemy2Attacking = false;
                return;
            }
            if (_givenEnemyIcon.CompareTag("Icon3") == true)
            {
                e_b_enemy3Attacking = false;
                return;
            }
        }
    }

    /// <summary>
    /// This is a dice roll to see if indicators will change
    /// </summary>
    /// <returns></returns>
    private int ShieldChance()
    {
        int _chance = Random.Range(1, 11);
        return _chance;
    }
}
