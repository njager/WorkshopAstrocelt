using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyState : MonoBehaviour
{
    // Controls the state for the entierety of enemies 
    private S_Global g_global;

    [Header("Enemy References")]
    public S_Enemy enemy1;
    public S_Enemy enemy2;
    public S_Enemy enemy3;
    public S_Enemy enemy4;
    public S_Enemy enemy5;

    [Header("Enemy Types")]
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

    [Header("Status Effect Turn Count For Enemy 1")]
    public int e_i_bleedingTurnCountEnemy1;
    public int e_i_stunnedTurnCountEnemy1;
    public int e_i_resistantTurnCountEnemy1;

    [Header("Status Effect Turn Count For Enemy 2")]
    public int e_i_bleedingTurnCountEnemy2;
    public int e_i_stunnedTurnCountEnemy2;
    public int e_i_resistantTurnCountEnemy2;

    [Header("Status Effect Turn Count For Enemy 3")]
    public int e_i_bleedingTurnCountEnemy3;
    public int e_i_stunnedTurnCountEnemy3;
    public int e_i_resistantTurnCountEnemy3;

    [Header("Status Effect Turn Count For Enemy 4")]
    public int e_i_bleedingTurnCountEnemy4;
    public int e_i_stunnedTurnCountEnemy4;
    public int e_i_resistantTurnCountEnemy4;

    [Header("Status Effect Turn Count For Enemy 5")]
    public int e_i_bleedingTurnCountEnemy5;
    public int e_i_stunnedTurnCountEnemy5;
    public int e_i_resistantTurnCountEnemy5;

    [Header("Status Effect States For Enemy 1")]
    public bool e_b_inBleedingStateEnemy1;
    public bool e_b_inStunnedStateEnemy1;
    public bool e_b_inResistantStateEnemy1;

    [Header("Status Effect States For Enemy 2")]
    public bool e_b_inBleedingStateEnemy2;
    public bool e_b_inStunnedStateEnemy2;
    public bool e_b_inResistantStateEnemy2;

    [Header("Status Effect States For Enemy 3")]
    public bool e_b_inBleedingStateEnemy3;
    public bool e_b_inStunnedStateEnemy3;
    public bool e_b_inResistantStateEnemy3;

    [Header("Status Effect States For Enemy 4")]
    public bool e_b_inBleedingStateEnemy4;
    public bool e_b_inStunnedStateEnemy4;
    public bool e_b_inResistantStateEnemy4;

    [Header("Status Effect States For Enemy 5")]
    public bool e_b_inBleedingStateEnemy5;
    public bool e_b_inStunnedStateEnemy5;
    public bool e_b_inResistantStateEnemy5;

    [Header("Status Effect Stores")]
    public float e_f_currentDamageRateForBleedEnemy1;
    public float e_f_currentDamageRateForBleedEnemy2;
    public float e_f_currentDamageRateForBleedEnemy3;
    public float e_f_currentDamageRateForBleedEnemy4; 
    public float e_f_currentDamageRateForBleedEnemy5;


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
    /// Decrement the turn count for effects
    /// Add status effects as needed, call this in turn manager at the beginning of enemy turn
    /// </summary>
    public void EnemyStatusEffectDecrement()
    {
        Enemy1StatusChecks();
        Enemy2StatusChecks();
        Enemy3StatusChecks();
        Enemy4StatusChecks();
        Enemy5StatusChecks();
    }

    /// <summary>
    /// Function for initial trigger for Enemy Bleeds
    /// - Josh
    /// </summary>
    /// <param name="_damageRate"></param>
    /// <param name="_turnCount"></param>
    public void EnemyBleedingStatusEffect(float _damageRate, int _turnCount, int _enemyNum)
    {
        int _bleedingDamage = BleedingEffectCalculator(_damageRate);
        
        // If the Enemy was Enemy 1
        if(_enemyNum == 1)
        {
            if (e_b_inBleedingStateEnemy1 == false)
            {
                enemy1.EnemyAttacked(str_enemy1Type, _bleedingDamage);
                e_i_bleedingTurnCountEnemy1 = _turnCount;
                e_f_currentDamageRateForBleedEnemy1 = _damageRate;
                e_b_inBleedingStateEnemy1 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        // If the Enemy was Enemy 2
        if (_enemyNum == 2)
        {
            if (e_b_inBleedingStateEnemy2 == false)
            {
                enemy2.EnemyAttacked(str_enemy2Type, _bleedingDamage);
                e_i_bleedingTurnCountEnemy2 = _turnCount;
                e_f_currentDamageRateForBleedEnemy2 = _damageRate;
                e_b_inBleedingStateEnemy2 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        // If the Enemy was Enemy 3
        if (_enemyNum == 3)
        {
            if (e_b_inBleedingStateEnemy3 == false)
            {
                enemy3.EnemyAttacked(str_enemy3Type, _bleedingDamage);
                e_i_bleedingTurnCountEnemy3 = _turnCount;
                e_f_currentDamageRateForBleedEnemy3 = _damageRate;
                e_b_inBleedingStateEnemy1 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        // If the Enemy was Enemy 4
        if (_enemyNum == 4)
        {
            if (e_b_inBleedingStateEnemy4 == false)
            {
                enemy1.EnemyAttacked(str_enemy4Type, _bleedingDamage);
                e_i_bleedingTurnCountEnemy4 = _turnCount;
                e_f_currentDamageRateForBleedEnemy4 = _damageRate;
                e_b_inBleedingStateEnemy4 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        // If the Enemy was Enemy 5
        if (_enemyNum == 5)
        {
            if (e_b_inBleedingStateEnemy5 == false)
            {
                enemy5.EnemyAttacked(str_enemy5Type, _bleedingDamage);
                e_i_bleedingTurnCountEnemy5 = _turnCount;
                e_f_currentDamageRateForBleedEnemy5 = _damageRate;
                e_b_inBleedingStateEnemy5 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }
    }

    /// <summary>
    /// Function for initial trigger for Enemy Stuns
    /// - Josh
    /// </summary>
    /// <param name="_turnCount"></param>
    public void EnemyStunnedStatusEffect(int _turnCount, int _enemyNum)
    {
        //If enemy was enemy 1
        if(_enemyNum == 1)
        {
            if (e_b_inStunnedStateEnemy1 == false)
            {
                e_i_stunnedTurnCountEnemy1 = _turnCount;
                e_b_inStunnedStateEnemy1 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        //If enemy was enemy 2
        if (_enemyNum == 2)
        {
            if (e_b_inStunnedStateEnemy2 == false)
            {
                e_i_stunnedTurnCountEnemy2 = _turnCount;
                e_b_inStunnedStateEnemy2 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        //If enemy was enemy 3
        if (_enemyNum == 3)
        {
            if (e_b_inStunnedStateEnemy3 == false)
            {
                e_i_stunnedTurnCountEnemy3 = _turnCount;
                e_b_inStunnedStateEnemy3 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        //If enemy was enemy 4
        if (_enemyNum == 4)
        {
            if (e_b_inStunnedStateEnemy4 == false)
            {
                e_i_stunnedTurnCountEnemy4 = _turnCount;
                e_b_inStunnedStateEnemy4 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        //If enemy was enemy 5
        if (_enemyNum == 5)
        {
            if (e_b_inStunnedStateEnemy5 == false)
            {
                e_i_stunnedTurnCountEnemy5 = _turnCount;
                e_b_inStunnedStateEnemy5 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }
    }

    /// <summary>
    /// Function for initial trigger for Enemy Resistances
    /// - Josh
    /// </summary>
    /// <param name="_turnCount"></param>
    public void EnemyResistantEffect(int _turnCount, int _enemyNum)
    {
        // If Enemy was Enemy 1
        if(_enemyNum == 1)
        {
            if (e_b_inResistantStateEnemy1 == false)
            {
                e_i_resistantTurnCountEnemy1 = _turnCount;
                e_b_inResistantStateEnemy1 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        // If Enemy was Enemy 2
        if (_enemyNum == 2)
        {
            if (e_b_inResistantStateEnemy2 == false)
            {
                e_i_resistantTurnCountEnemy2 = _turnCount;
                e_b_inResistantStateEnemy2 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        // If Enemy was Enemy 3
        if (_enemyNum == 3)
        {
            if (e_b_inResistantStateEnemy3 == false)
            {
                e_i_resistantTurnCountEnemy3 = _turnCount;
                e_b_inResistantStateEnemy3 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        // If Enemy was Enemy 4
        if (_enemyNum == 4)
        {
            if (e_b_inResistantStateEnemy4 == false)
            {
                e_i_resistantTurnCountEnemy4 = _turnCount;
                e_b_inResistantStateEnemy4 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        // If Enemy was Enemy 5
        if (_enemyNum == 5)
        {
            if (e_b_inResistantStateEnemy5 == false)
            {
                e_i_resistantTurnCountEnemy5 = _turnCount;
                e_b_inResistantStateEnemy5 = true;
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }
    }

    /// <summary>
    /// Helper function of a helper function, used to calculate percentage of health
    /// - Josh
    /// </summary>
    /// <param name="_damageRate"></param>
    /// <returns></returns>
    private int BleedingEffectCalculator(float _damageRate)
    {
        int _bleedingCalc = Mathf.RoundToInt(g_global.g_playerAttributeSheet.p_i_health * _damageRate);
        return _bleedingCalc;
    }

    /// <summary>
    /// Helper to trigger bleed after intial function
    /// - Josh
    /// </summary>
    /// <param name="_damageRate"></param>
    private void BleedEffectPerTurn(float _damageRate)
    {
        int _bleedingDamageForTurn = BleedingEffectCalculator(_damageRate);
        g_global.g_player.PlayerAttacked(_bleedingDamageForTurn);
    }

    /// <summary>
    /// Helper function for legibility
    /// Controller for Enemy 1 Status Effects
    /// - Josh
    /// </summary>
    private void Enemy1StatusChecks()
    {
        // Check for state For Enemy 1
        if (e_i_bleedingTurnCountEnemy1 <= 0)
        {
            e_b_inBleedingStateEnemy1 = false;
        }
        if (e_i_stunnedTurnCountEnemy1 <= 0)
        {
            e_b_inStunnedStateEnemy1 = false;
        }
        if (e_i_resistantTurnCountEnemy1 <= 0)
        {
            e_b_inResistantStateEnemy1 = false;
        }
        // Trigger remaining effects
        if (e_b_inBleedingStateEnemy1)
        {
            e_i_bleedingTurnCountEnemy1 -= 1;
            BleedEffectPerTurn(e_f_currentDamageRateForBleedEnemy1);
        }
        if (e_b_inStunnedStateEnemy1)
        {
            e_i_stunnedTurnCountEnemy1 -= 1;
        }
        if (e_b_inResistantStateEnemy1)
        {
            e_i_resistantTurnCountEnemy1 -= 1;
        }
    }

    /// <summary>
    /// Helper function for legibility
    /// Controller for Enemy 2 Status Effects
    /// - Josh
    /// </summary>
    private void Enemy2StatusChecks()
    {
        // Check for state For Enemy 2
        if (e_i_bleedingTurnCountEnemy2 <= 0)
        {
            e_b_inBleedingStateEnemy2 = false;
        }
        if (e_i_stunnedTurnCountEnemy2 <= 0)
        {
            e_b_inStunnedStateEnemy2 = false;
        }
        if (e_i_resistantTurnCountEnemy2 <= 0)
        {
            e_b_inResistantStateEnemy2 = false;
        }

        // Trigger remaining effects
        if (e_b_inBleedingStateEnemy2)
        {
            e_i_bleedingTurnCountEnemy2 -= 1;
            BleedEffectPerTurn(e_f_currentDamageRateForBleedEnemy2);
        }
        if (e_b_inStunnedStateEnemy2)
        {
            e_i_stunnedTurnCountEnemy2 -= 1;
        }
        if (e_b_inResistantStateEnemy2)
        {
            e_i_resistantTurnCountEnemy2 -= 1;
        }
    }

    /// <summary>
    /// Helper function for legibility
    /// Controller for Enemy 3 Status Effects
    /// - Josh
    /// </summary>
    private void Enemy3StatusChecks()
    {
        // Check for state For Enemy 3
        if (e_i_bleedingTurnCountEnemy3 <= 0)
        {
            e_b_inBleedingStateEnemy3 = false;
        }
        if (e_i_stunnedTurnCountEnemy3 <= 0)
        {
            e_b_inStunnedStateEnemy3 = false;
        }
        if (e_i_resistantTurnCountEnemy3 <= 0)
        {
            e_b_inResistantStateEnemy3 = false;
        }

        // Trigger remaining effects
        if (e_b_inBleedingStateEnemy3)
        {
            e_i_bleedingTurnCountEnemy3 -= 1;
            BleedEffectPerTurn(e_f_currentDamageRateForBleedEnemy3);
        }
        if (e_b_inStunnedStateEnemy3)
        {
            e_i_stunnedTurnCountEnemy3 -= 1;
        }
        if (e_b_inResistantStateEnemy3)
        {
            e_i_resistantTurnCountEnemy3 -= 1;
        }
    }

    /// <summary>
    /// Helper function for legibility
    /// Controller for Enemy 4 Status Effects
    /// - Josh
    /// </summary>
    private void Enemy4StatusChecks()
    {
        // Check for state For Enemy 4
        if (e_i_bleedingTurnCountEnemy4 <= 0)
        {
            e_b_inBleedingStateEnemy4 = false;
        }
        if (e_i_stunnedTurnCountEnemy4 <= 0)
        {
            e_b_inStunnedStateEnemy4 = false;
        }
        if (e_i_resistantTurnCountEnemy4 <= 0)
        {
            e_b_inResistantStateEnemy4 = false;
        }

        // Trigger remaining effects
        if (e_b_inBleedingStateEnemy4)
        {
            e_i_bleedingTurnCountEnemy4 -= 1;
            BleedEffectPerTurn(e_f_currentDamageRateForBleedEnemy4);
        }
        if (e_b_inStunnedStateEnemy4)
        {
            e_i_stunnedTurnCountEnemy4 -= 1;
        }
        if (e_b_inResistantStateEnemy4)
        {
            e_i_resistantTurnCountEnemy4 -= 1;
        }
    }

    /// <summary>
    /// Helper function for legibility
    /// Controller for Enemy 5 Status Effects
    /// - Josh
    /// </summary>
    private void Enemy5StatusChecks()
    {
        // Check for state For Enemy 5
        if (e_i_bleedingTurnCountEnemy5 <= 0)
        {
            e_b_inBleedingStateEnemy5 = false;
        }
        if (e_i_stunnedTurnCountEnemy5 <= 0)
        {
            e_b_inStunnedStateEnemy5 = false;
        }
        if (e_i_resistantTurnCountEnemy5 <= 0)
        {
            e_b_inResistantStateEnemy5 = false;
        }

        // Trigger remaining effects
        if (e_b_inBleedingStateEnemy5)
        {
            e_i_bleedingTurnCountEnemy5 -= 1;
            BleedEffectPerTurn(e_f_currentDamageRateForBleedEnemy5);
        }
        if (e_b_inStunnedStateEnemy5)
        {
            e_i_stunnedTurnCountEnemy5 -= 1;
        }
        if (e_b_inResistantStateEnemy5)
        {
            e_i_resistantTurnCountEnemy5 -= 1;
        }
    }

    // This doesn't have enemy 4 or enemy 5 added to it yet, add to Icon manager, rename icon manager to intent manager
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
