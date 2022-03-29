using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyState : MonoBehaviour
{
    // Controls the state for the entierety of enemies 
    private S_Global g_global;

    // Five max potential enemes, left blank for enemies to self inform themselves to. 
    public S_Enemy enemy1;
    public S_Enemy enemy2;
    public S_Enemy enemy3;
    public S_Enemy enemy4;
    public S_Enemy enemy5;

    public string str_enemy1Type;
    public string str_enemy2Type;
    public string str_enemy3Type;
    public string str_enemy4Type;
    public string str_enemy5Type;

    [Header("Bool Check")]
    public bool e_b_enemy1Dead;
    public bool e_b_enemy2Dead;
    public bool e_b_enemy3Dead;
    public bool e_b_enemy4Dead;
    public bool e_b_enemy5Dead;

    //Check thse for their next turn actions 
    [Header("Enemy Shielding Bools")]
    public bool e_b_enemy1Shielding;
    public bool e_b_enemy2Shielding;
    public bool e_b_enemy3Shielding;
    public bool e_b_enemy4Shielding;
    public bool e_b_enemy5Shielding;

    [Header("Enemy Attacking Bools")]
    public bool e_b_enemy1Attacking;
    public bool e_b_enemy2Attacking;
    public bool e_b_enemy3Attacking;
    public bool e_b_enemy4Attacking;
    public bool e_b_enemy5Attacking;

    [Header("Enemy Ability Bools")]
    public bool e_b_enemy1SpecialAbility;
    public bool e_b_enemy2SpecialAbility;
    public bool e_b_enemy3SpecialAbility;
    public bool e_b_enemy4SpecialAbility;
    public bool e_b_enemy5SpecialAbility;


    void Awake()
    {
        g_global = S_Global.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        //If the enemy 1 healths or goes over in shields from abilities, or they die
        if(g_global.g_enemyAttributeSheet1 != null)
        {
            if (g_global.g_enemyAttributeSheet1.e_i_health > g_global.g_enemyAttributeSheet1.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet1.e_i_health = g_global.g_enemyAttributeSheet1.e_i_healthMax;
            }

            if (g_global.g_enemyAttributeSheet1.e_i_shield > g_global.g_enemyAttributeSheet1.e_i_shieldMax)
            {
                g_global.g_enemyAttributeSheet1.e_i_shield = g_global.g_enemyAttributeSheet1.e_i_shieldMax;
            }

            if(e_b_enemy1Dead != true)
            {
                if (g_global.g_enemyAttributeSheet1.e_i_health <= 0)
                {
                    enemy1.EnemyDied(str_enemy1Type);
                    e_b_enemy1Dead = true; 
                }
            }
            
        }
        
        // Same for enemy 2
        if(g_global.g_enemyAttributeSheet2 != null)
        {
            if (g_global.g_enemyAttributeSheet2.e_i_health > g_global.g_enemyAttributeSheet2.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet2.e_i_health = g_global.g_enemyAttributeSheet2.e_i_healthMax;
            }

            if (g_global.g_enemyAttributeSheet2.e_i_shield > g_global.g_enemyAttributeSheet2.e_i_shieldMax)
            {
                g_global.g_enemyAttributeSheet2.e_i_shield = g_global.g_enemyAttributeSheet2.e_i_shieldMax;
            }

            if (e_b_enemy2Dead != true)
            {
                if (g_global.g_enemyAttributeSheet2.e_i_health <= 0)
                {
                    enemy2.EnemyDied(str_enemy2Type);
                    e_b_enemy2Dead = true;
                }
            }
        }
        
        // Same for enemy 3
        if(g_global.g_enemyAttributeSheet3 != null)
        {
            if (g_global.g_enemyAttributeSheet3.e_i_health > g_global.g_enemyAttributeSheet3.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet3.e_i_health = g_global.g_enemyAttributeSheet3.e_i_healthMax;
            }

            if (g_global.g_enemyAttributeSheet3.e_i_shield > g_global.g_enemyAttributeSheet3.e_i_shieldMax)
            {
                g_global.g_enemyAttributeSheet3.e_i_shield = g_global.g_enemyAttributeSheet3.e_i_shieldMax;
            }

            if (e_b_enemy3Dead != true)
            {
                if (g_global.g_enemyAttributeSheet3.e_i_health <= 0)
                {
                    enemy3.EnemyDied(str_enemy3Type);
                    e_b_enemy3Dead = true; 
                }
            }
        }
        
        // Same for enemy 4
        if(g_global.g_enemyAttributeSheet4 != null)
        {
            if (g_global.g_enemyAttributeSheet4.e_i_health > g_global.g_enemyAttributeSheet4.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet4.e_i_health = g_global.g_enemyAttributeSheet4.e_i_healthMax;
            }

            if (g_global.g_enemyAttributeSheet4.e_i_shield > g_global.g_enemyAttributeSheet4.e_i_shieldMax)
            {
                g_global.g_enemyAttributeSheet4.e_i_shield = g_global.g_enemyAttributeSheet4.e_i_shieldMax;
            }

            if (e_b_enemy4Dead != true)
            {
                if (g_global.g_enemyAttributeSheet4.e_i_health <= 0)
                {
                    enemy4.EnemyDied(str_enemy4Type);
                    e_b_enemy4Dead = true;
                }
            }

            
        }

        // Same for enemy 5
        if(g_global.g_enemyAttributeSheet5 != null)
        {
            if (g_global.g_enemyAttributeSheet5.e_i_health > g_global.g_enemyAttributeSheet5.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet5.e_i_health = g_global.g_enemyAttributeSheet5.e_i_healthMax;
            }

            if (g_global.g_enemyAttributeSheet5.e_i_shield > g_global.g_enemyAttributeSheet5.e_i_shieldMax)
            {
                g_global.g_enemyAttributeSheet5.e_i_shield = g_global.g_enemyAttributeSheet5.e_i_shieldMax;
            }

            if(e_b_enemy5Dead != true)
            {
                if (g_global.g_enemyAttributeSheet5.e_i_health <= 0)
                {
                    enemy5.EnemyDied(str_enemy5Type);
                    e_b_enemy5Dead = true;
                }
            }
        }
    }

    /// <summary>
    /// This helper function switches whether the enemy is going to attack or defend
    /// Called in S_TurnManager
    /// -Josh
    /// </summary>
    public void EnemyAttackingOrShielding()
    {
        if (g_global.g_enemyAttributeSheet1 != null) // Check if enemy 1 is present
        {
            if (g_global.g_iconManager.e_b_enemy1IconCheck == "attack") //Enemy 1 Attack
            {
                e_b_enemy1Attacking = true;
                e_b_enemy1Shielding = false;
                e_b_enemy1SpecialAbility = false;
                enemy1.e_enemyAttributes.AttackDamageRoll(); 
            }
            else if (g_global.g_iconManager.e_b_enemy1IconCheck == "shield") // Enemy 1 Shields
            {
                e_b_enemy1Attacking = false;
                e_b_enemy1Shielding = true;
                e_b_enemy1SpecialAbility = false;
            }
            else if (g_global.g_iconManager.e_b_enemy1IconCheck == "ability") // Enemy 1 does their ability
            {
                e_b_enemy1Attacking = false;
                e_b_enemy1Shielding = false;
                e_b_enemy1SpecialAbility = true;
            }
        }

        if (g_global.g_enemyAttributeSheet2 != null) // Check if enemy 2 is present
        {
            if (g_global.g_iconManager.e_b_enemy2IconCheck == "attack") //Enemy 1 Attack
            {
                e_b_enemy2Attacking = true;
                e_b_enemy2Shielding = false;
                e_b_enemy2SpecialAbility = false;
                enemy2.e_enemyAttributes.AttackDamageRoll();
            }
            else if (g_global.g_iconManager.e_b_enemy2IconCheck == "shield") // Enemy 1 Shields
            {
                e_b_enemy2Attacking = false;
                e_b_enemy2Shielding = true;
                e_b_enemy2SpecialAbility = false;
            }
            else if (g_global.g_iconManager.e_b_enemy2IconCheck == "ability") // Enemy 1 does their ability
            {
                e_b_enemy2Attacking = false;
                e_b_enemy2Shielding = false;
                e_b_enemy2SpecialAbility = true;
            }
        }

        if (g_global.g_enemyAttributeSheet3 != null) // Check if enemy 3 is present
        {
            if (g_global.g_iconManager.e_b_enemy3IconCheck == "attack") //Enemy 1 Attack
            {
                e_b_enemy3Attacking = true;
                e_b_enemy3Shielding = false;
                e_b_enemy3SpecialAbility = false;
                enemy3.e_enemyAttributes.AttackDamageRoll();
            }
            else if (g_global.g_iconManager.e_b_enemy3IconCheck == "shield") // Enemy 1 Shields
            {
                e_b_enemy3Attacking = false;
                e_b_enemy3Shielding = true;
                e_b_enemy3SpecialAbility = false;
            }
            else if (g_global.g_iconManager.e_b_enemy3IconCheck == "ability") // Enemy 1 does their ability
            {
                e_b_enemy3Attacking = false;
                e_b_enemy3Shielding = false;
                e_b_enemy3SpecialAbility = true;
            }
        }

        if (g_global.g_enemyAttributeSheet4 != null) // Check if enemy 4 is present
        {
            if (g_global.g_iconManager.e_b_enemy4IconCheck == "attack") //Enemy 1 Attack
            {
                e_b_enemy4Attacking = true;
                e_b_enemy4Shielding = false;
                e_b_enemy4SpecialAbility = false;
                enemy4.e_enemyAttributes.AttackDamageRoll();
            }
            else if (g_global.g_iconManager.e_b_enemy4IconCheck == "shield") // Enemy 1 Shields
            {
                e_b_enemy4Attacking = false;
                e_b_enemy4Shielding = true;
                e_b_enemy4SpecialAbility = false;
            }
            else if (g_global.g_iconManager.e_b_enemy4IconCheck == "ability") // Enemy 1 does their ability
            {
                e_b_enemy4Attacking = false;
                e_b_enemy4Shielding = false;
                e_b_enemy4SpecialAbility = true;
            }
        }

        if (g_global.g_enemyAttributeSheet5 != null) // Check if enemy 5 is present
        {
            if (g_global.g_iconManager.e_b_enemy5IconCheck == "attack") //Enemy 1 Attack
            {
                e_b_enemy5Attacking = true;
                e_b_enemy5Shielding = false;
                e_b_enemy5SpecialAbility = false;
                enemy5.e_enemyAttributes.AttackDamageRoll();
            }
            else if (g_global.g_iconManager.e_b_enemy5IconCheck == "shield") // Enemy 1 Shields
            {
                e_b_enemy5Attacking = false;
                e_b_enemy5Shielding = true;
                e_b_enemy5SpecialAbility = false;
            }
            else if (g_global.g_iconManager.e_b_enemy5IconCheck == "ability") // Enemy 1 does their ability
            {
                e_b_enemy5Attacking = false;
                e_b_enemy5Shielding = false;
                e_b_enemy5SpecialAbility = true;
            }
        }
    }

}
