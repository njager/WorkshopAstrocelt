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

    [Header("Enemy Turn Actions")]
    public string e_str_enemy1Action;
    public string e_str_enemy2Action;
    public string e_str_enemy3Action;
    public string e_str_enemy4Action;
    public string e_str_enemy5Action;

    [Header("Enemy Types")]
    public string str_enemy1Type;
    public string str_enemy2Type;
    public string str_enemy3Type;
    public string str_enemy4Type;
    public string str_enemy5Type;

    [Header("Bool Living Status Check")]
    public bool e_b_enemy1Dead;
    public bool e_b_enemy2Dead;
    public bool e_b_enemy3Dead;
    public bool e_b_enemy4Dead;
    public bool e_b_enemy5Dead;

    [Header("Current Enemys' Turn Check")]
    public bool e_b_enemy1Turn;
    public bool e_b_enemy2Turn;
    public bool e_b_enemy3Turn;
    public bool e_b_enemy4Turn;
    public bool e_b_enemy5Turn;

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

    [Header("Turn Passed for Stun")]
    public int e_i_enemy1StunTurnsPassed;
    public int e_i_enemy2StunTurnsPassed;
    public int e_i_enemy3StunTurnsPassed;
    public int e_i_enemy4StunTurnsPassed;
    public int e_i_enemy5StunTurnsPassed;

    [Header("Turn Passed for Resistant")]
    public int e_i_enemy1ResistantTurnsPassed;
    public int e_i_enemy2ResistantTurnsPassed;
    public int e_i_enemy3ResistantTurnsPassed;
    public int e_i_enemy4ResistantTurnsPassed;
    public int e_i_enemy5ResistantTurnsPassed;

    [Header("Active (true) or Inactive (false) Bool Check for Enemies")]
    public bool e_b_enemy1IsActive;
    public bool e_b_enemy2IsActive;
    public bool e_b_enemy3IsActive;
    public bool e_b_enemy4IsActive;
    public bool e_b_enemy5IsActive;

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
                    // Turn off status effects
                    e_b_inBleedingStateEnemy1 = false;
                    e_b_inStunnedStateEnemy1 = false;
                    e_b_inResistantStateEnemy1 = false;

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
                    // Turn off status effects
                    e_b_inBleedingStateEnemy2 = false;
                    e_b_inStunnedStateEnemy2 = false;
                    e_b_inResistantStateEnemy2 = false;

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
                    // Turn off status effects
                    e_b_inBleedingStateEnemy3 = false;
                    e_b_inStunnedStateEnemy3 = false;
                    e_b_inResistantStateEnemy3 = false;

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
                    // Turn off status effects
                    e_b_inBleedingStateEnemy4 = false;
                    e_b_inStunnedStateEnemy4 = false;
                    e_b_inResistantStateEnemy4 = false;

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
                    // Turn off status effects
                    e_b_inBleedingStateEnemy5 = false;
                    e_b_inStunnedStateEnemy5 = false;
                    e_b_inResistantStateEnemy5 = false;

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
        if (g_global.g_enemyAttributeSheet1 != null) { Enemy1StatusChecks(); }
        if (g_global.g_enemyAttributeSheet2 != null) { Enemy2StatusChecks(); }
        if (g_global.g_enemyAttributeSheet3 != null) { Enemy3StatusChecks(); }
        //Enemy4StatusChecks();
        //Enemy5StatusChecks();
    }


    /// <summary>
    /// Function for initial trigger for Enemy Bleeds
    /// - Josh
    /// </summary>
    /// <param name="_damageValue"></param>
    /// <param name="_turnCount"></param>
    /// /// <param name="_enemyNum"></param>
    public void EnemyBleedingStatusEffect(float _damageRate, int _turnCount, int _enemyNum)
    {
        // If the Enemy was Enemy 1
        if(_enemyNum == 1)
        {
            if (e_b_inBleedingStateEnemy1 == false)
            {
                g_global.g_UIManager.ToggleBleedEnemyUI(true, 1);
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
                g_global.g_UIManager.ToggleBleedEnemyUI(true, 2);
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
                g_global.g_UIManager.ToggleBleedEnemyUI(true, 3);
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
                g_global.g_UIManager.ToggleBleedEnemyUI(true, 4);
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
                g_global.g_UIManager.ToggleBleedEnemyUI(true, 5);
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
    /// <param name="_enemyNum"></param>
    public void EnemyStunnedStatusEffect(int _turnCount, int _enemyNum)
    {
        //If enemy was enemy 1
        if(_enemyNum == 1)
        {
            if (e_b_inStunnedStateEnemy1 == false)
            {
                g_global.g_turnManager.e_b_enemy1TurnSkipped = true;
                e_i_enemy1StunTurnsPassed += 1;
                g_global.g_UIManager.ToggleStunEnemyUI(true, 1);
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
                g_global.g_turnManager.e_b_enemy2TurnSkipped = true;
                e_i_enemy1StunTurnsPassed += 1;
                g_global.g_UIManager.ToggleStunEnemyUI(true, 2);
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
                g_global.g_turnManager.e_b_enemy3TurnSkipped = true;
                e_i_enemy1StunTurnsPassed += 1;
                g_global.g_UIManager.ToggleStunEnemyUI(true, 3);
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
                g_global.g_turnManager.e_b_enemy4TurnSkipped = true;
                e_i_enemy1StunTurnsPassed += 1;
                g_global.g_UIManager.ToggleStunEnemyUI(true, 4);
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
                g_global.g_turnManager.e_b_enemy5TurnSkipped = true;
                e_i_enemy1StunTurnsPassed += 1;
                g_global.g_UIManager.ToggleStunEnemyUI(true, 5);
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
    /// <param name="_enemyNum"></param>
    public void EnemyResistantEffect(int _turnCount, int _enemyNum)
    {
        print(_enemyNum);

        // If Enemy was Enemy 1
        if(_enemyNum == 1)
        {
            if (e_b_inResistantStateEnemy1 == false)
            {
                e_i_enemy1ResistantTurnsPassed += 1;
                g_global.g_UIManager.ToggleResistantEnemyUI(true, 1);
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
                e_i_enemy2ResistantTurnsPassed += 1;
                g_global.g_UIManager.ToggleResistantEnemyUI(true, 2);
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
                e_i_enemy3ResistantTurnsPassed += 1;
                g_global.g_UIManager.ToggleResistantEnemyUI(true, 3);
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
                e_i_enemy4ResistantTurnsPassed += 1;
                g_global.g_UIManager.ToggleResistantEnemyUI(true, 4);
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
                e_i_enemy5ResistantTurnsPassed += 1;
                g_global.g_UIManager.ToggleResistantEnemyUI(true, 5);
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
            g_global.g_UIManager.ToggleBleedEnemyUI(false, 1);
        }
        if (e_i_stunnedTurnCountEnemy1 <= 0)
        {
            e_b_inStunnedStateEnemy1 = false;
            g_global.g_UIManager.ToggleStunEnemyUI(false, 1);
            e_i_enemy1StunTurnsPassed = 0;
        }
        if (e_i_resistantTurnCountEnemy1 <= 0)
        {
            e_b_inResistantStateEnemy1 = false;
            g_global.g_UIManager.ToggleResistantEnemyUI(false, 1);
            e_i_enemy1ResistantTurnsPassed = 0;
        }
        // Trigger remaining effects
        if (e_b_inBleedingStateEnemy1)
        {
            e_i_bleedingTurnCountEnemy1 -= 1;
            BleedEffectPerTurn(e_f_currentDamageRateForBleedEnemy1);
            g_global.g_UIManager.ToggleBleedEnemyUI(true, 1);
        }
        if (e_b_inStunnedStateEnemy1)
        {
            e_i_stunnedTurnCountEnemy1 -= 1;
            g_global.g_UIManager.ToggleStunEnemyUI(true, 1);
            e_i_enemy1StunTurnsPassed +=1;
        }
        if (e_b_inResistantStateEnemy1)
        {
            e_i_resistantTurnCountEnemy1 -= 1;
            g_global.g_UIManager.ToggleResistantEnemyUI(true, 1);
            e_i_enemy1ResistantTurnsPassed += 1;
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
            g_global.g_UIManager.ToggleBleedEnemyUI(false, 2);
        }
        if (e_i_stunnedTurnCountEnemy2 <= 0)
        {
            e_b_inStunnedStateEnemy2 = false;
            g_global.g_UIManager.ToggleStunEnemyUI(false, 2);
            e_i_enemy2StunTurnsPassed = 0;
        }
        if (e_i_resistantTurnCountEnemy2 <= 0)
        {
            e_b_inResistantStateEnemy2 = false;
            g_global.g_UIManager.ToggleResistantEnemyUI(false, 2);
            e_i_enemy2ResistantTurnsPassed = 0;
        }

        // Trigger remaining effects
        if (e_b_inBleedingStateEnemy2)
        {
            e_i_bleedingTurnCountEnemy2 -= 1;
            BleedEffectPerTurn(e_f_currentDamageRateForBleedEnemy2);
            g_global.g_UIManager.ToggleBleedEnemyUI(true, 2);
        }
        if (e_b_inStunnedStateEnemy2)
        {
            e_i_stunnedTurnCountEnemy2 -= 1;
            g_global.g_UIManager.ToggleStunEnemyUI(true, 2);
            e_i_enemy2StunTurnsPassed += 1;
        }
        if (e_b_inResistantStateEnemy2)
        {
            e_i_resistantTurnCountEnemy2 -= 1;
            g_global.g_UIManager.ToggleResistantEnemyUI(true, 2);
            e_i_enemy2ResistantTurnsPassed += 1;
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
            g_global.g_UIManager.ToggleBleedEnemyUI(false, 3);
        }
        if (e_i_stunnedTurnCountEnemy3 <= 0)
        {
            e_b_inStunnedStateEnemy3 = false;
            g_global.g_UIManager.ToggleStunEnemyUI(false, 3);
            e_i_enemy3StunTurnsPassed = 0;
        }
        if (e_i_resistantTurnCountEnemy3 <= 0)
        {
            e_b_inResistantStateEnemy3 = false;
            g_global.g_UIManager.ToggleResistantEnemyUI(false, 3);
            e_i_enemy3ResistantTurnsPassed = 0;
        }

        // Trigger remaining effects
        if (e_b_inBleedingStateEnemy3)
        {
            e_i_bleedingTurnCountEnemy3 -= 1;
            BleedEffectPerTurn(e_f_currentDamageRateForBleedEnemy3);
            g_global.g_UIManager.ToggleBleedEnemyUI(true, 2);
        }
        if (e_b_inStunnedStateEnemy3)
        {
            e_i_stunnedTurnCountEnemy3 -= 1;
            g_global.g_UIManager.ToggleStunEnemyUI(true, 3);
            e_i_enemy3StunTurnsPassed += 1;
        }
        if (e_b_inResistantStateEnemy3)
        {
            e_i_resistantTurnCountEnemy3 -= 1;
            g_global.g_UIManager.ToggleResistantEnemyUI(true, 3);
            e_i_enemy3ResistantTurnsPassed += 1;
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
            g_global.g_UIManager.ToggleBleedEnemyUI(false, 4);
        }
        if (e_i_stunnedTurnCountEnemy4 <= 0)
        {
            e_b_inStunnedStateEnemy4 = false;
            g_global.g_UIManager.ToggleStunEnemyUI(false, 4);
            e_i_enemy1StunTurnsPassed = 0;
        }
        if (e_i_resistantTurnCountEnemy4 <= 0)
        {
            e_b_inResistantStateEnemy4 = false;
            g_global.g_UIManager.ToggleResistantEnemyUI(false, 4);
            e_i_enemy4ResistantTurnsPassed = 0;
        }

        // Trigger remaining effects
        if (e_b_inBleedingStateEnemy4)
        {
            e_i_bleedingTurnCountEnemy4 -= 1;
            BleedEffectPerTurn(e_f_currentDamageRateForBleedEnemy4);
            g_global.g_UIManager.ToggleBleedEnemyUI(true, 4);
        }
        if (e_b_inStunnedStateEnemy4)
        {
            e_i_stunnedTurnCountEnemy4 -= 1;
            g_global.g_UIManager.ToggleStunEnemyUI(true, 4);
            e_i_enemy4StunTurnsPassed += 1;
        }
        if (e_b_inResistantStateEnemy4)
        {
            e_i_resistantTurnCountEnemy4 -= 1;
            g_global.g_UIManager.ToggleResistantEnemyUI(true, 4);
            e_i_enemy4ResistantTurnsPassed += 1;
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
            g_global.g_UIManager.ToggleBleedEnemyUI(false, 5);
        }
        if (e_i_stunnedTurnCountEnemy5 <= 0)
        {
            e_b_inStunnedStateEnemy5 = false;
            g_global.g_UIManager.ToggleStunEnemyUI(false, 5);
            e_i_enemy5StunTurnsPassed = 0;
        }
        if (e_i_resistantTurnCountEnemy5 <= 0)
        {
            e_b_inResistantStateEnemy5 = false;
            g_global.g_UIManager.ToggleResistantEnemyUI(false, 5);
            e_i_enemy5ResistantTurnsPassed = 0;
        }

        // Trigger remaining effects
        if (e_b_inBleedingStateEnemy5)
        {
            e_i_bleedingTurnCountEnemy5 -= 1;
            BleedEffectPerTurn(e_f_currentDamageRateForBleedEnemy5);
            g_global.g_UIManager.ToggleBleedEnemyUI(true, 5);
        }
        if (e_b_inStunnedStateEnemy5)
        {
            e_i_stunnedTurnCountEnemy5 -= 1;
            g_global.g_UIManager.ToggleStunEnemyUI(true, 5);
            e_i_enemy5StunTurnsPassed += 1;
        }
        if (e_b_inResistantStateEnemy5)
        {
            e_i_resistantTurnCountEnemy5 -= 1;
            g_global.g_UIManager.ToggleResistantEnemyUI(true, 5);
            e_i_enemy5ResistantTurnsPassed += 1;
        }
    }

    /// <summary>
    /// This helper function switches whether the enemy is going to attack or defend
    /// Called in S_TurnManager
    /// -Josh
    /// </summary>
    public void EnemyActionCheck() // Rename to EnemyActionCheck() ?
    {
        if (g_global.g_enemyAttributeSheet1 != null) // Check if enemy 1 is present
        {
            if (g_global.g_iconManager.ls_e_statusStrings[0] == "attack") //Enemy 1 Attack
            {
                e_b_enemy1Attacking = true;
                e_b_enemy1Shielding = false;
                e_b_enemy1SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[0] == "shield") // Enemy 1 Shields
            {
                e_b_enemy1Attacking = false;
                e_b_enemy1Shielding = true;
                e_b_enemy1SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[0] == "ability") // Enemy 1 does their ability
            {
                e_b_enemy1Attacking = false;
                e_b_enemy1Shielding = false;
                e_b_enemy1SpecialAbility = true;
            }
        }

        if (g_global.g_enemyAttributeSheet2 != null) // Check if enemy 2 is present
        {
            if (g_global.g_iconManager.ls_e_statusStrings[1] == "attack") //Enemy 1 Attack
            {
                e_b_enemy2Attacking = true;
                e_b_enemy2Shielding = false;
                e_b_enemy2SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[1] == "shield") // Enemy 1 Shields
            {
                e_b_enemy2Attacking = false;
                e_b_enemy2Shielding = true;
                e_b_enemy2SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[1] == "ability") // Enemy 1 does their ability
            {
                e_b_enemy2Attacking = false;
                e_b_enemy2Shielding = false;
                e_b_enemy2SpecialAbility = true;
            }
        }

        if (g_global.g_enemyAttributeSheet3 != null) // Check if enemy 3 is present
        {
            if (g_global.g_iconManager.ls_e_statusStrings[2] == "attack") //Enemy 1 Attack
            {
                e_b_enemy3Attacking = true;
                e_b_enemy3Shielding = false;
                e_b_enemy3SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[2] == "shield") // Enemy 1 Shields
            {
                e_b_enemy3Attacking = false;
                e_b_enemy3Shielding = true;
                e_b_enemy3SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[2] == "ability") // Enemy 1 does their ability
            {
                e_b_enemy3Attacking = false;
                e_b_enemy3Shielding = false;
                e_b_enemy3SpecialAbility = true;
            }
        }

        if (g_global.g_enemyAttributeSheet4 != null) // Check if enemy 4 is present
        {
            if (g_global.g_iconManager.ls_e_statusStrings[3] == "attack") //Enemy 1 Attack
            {
                e_b_enemy4Attacking = true;
                e_b_enemy4Shielding = false;
                e_b_enemy4SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[3] == "shield") // Enemy 1 Shields
            {
                e_b_enemy4Attacking = false;
                e_b_enemy4Shielding = true;
                e_b_enemy4SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[3] == "ability") // Enemy 1 does their ability
            {
                e_b_enemy4Attacking = false;
                e_b_enemy4Shielding = false;
                e_b_enemy4SpecialAbility = true;
            }
        }

        if (g_global.g_enemyAttributeSheet5 != null) // Check if enemy 5 is present
        {
            if (g_global.g_iconManager.ls_e_statusStrings[4] == "attack") //Enemy 1 Attack
            {
                e_b_enemy5Attacking = true;
                e_b_enemy5Shielding = false;
                e_b_enemy5SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[4] == "shield") // Enemy 1 Shields
            {
                e_b_enemy5Attacking = false;
                e_b_enemy5Shielding = true;
                e_b_enemy5SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[4] == "ability") // Enemy 1 does their ability
            {
                e_b_enemy5Attacking = false;
                e_b_enemy5Shielding = false;
                e_b_enemy5SpecialAbility = true;
            }
        }
    }


   /// <summary>
   /// Useful to see what enemy's turn should be active
   /// - Josh
   /// </summary>
   /// <returns></returns>
    public int CurrentEnemyTurnNumber()
    {
        if (e_b_enemy1Turn == true)
        {
            return 1;
        }
        else if (e_b_enemy2Turn == true)
        {
            return 2;
        }
        else if (e_b_enemy3Turn == true)
        {
            return 3;
        }
        else if (e_b_enemy4Turn == true)
        {
            return 4;
        }
        else if (e_b_enemy5Turn == true)
        {
            return 5;
        }
        else 
        {
            return 0; 
        }
    }


    /// <summary>
    /// Let the delegate list know which enemies should be considered in play or not
    /// - Josh
    /// </summary>
    public void UpdateActiveEnemies()
    {
        // Check Enemy 1
        if (g_global.g_enemyState.enemy1 != null)
        {
            if (g_global.g_enemyState.e_b_enemy1Dead == false)
            {
                g_global.g_enemyState.e_b_enemy1IsActive = true; 
            }
            else
            {
                g_global.g_enemyState.e_b_enemy1IsActive = false;
            }
        }
        else
        {
            g_global.g_enemyState.e_b_enemy1IsActive = false;
        }

        // Check Enemy 2
        if (g_global.g_enemyState.enemy2 != null)
        {
            if (g_global.g_enemyState.e_b_enemy2Dead == false)
            {
                g_global.g_enemyState.e_b_enemy2IsActive = true;
            }
            else
            {
                g_global.g_enemyState.e_b_enemy2IsActive = false;
            }
        }
        else
        {
            g_global.g_enemyState.e_b_enemy3IsActive = false;
        }

        // Check Enemy 3
        if (g_global.g_enemyState.enemy3 != null)
        {
            if (g_global.g_enemyState.e_b_enemy3Dead == false)
            {
                g_global.g_enemyState.e_b_enemy3IsActive = true;
            }
            else
            {
                g_global.g_enemyState.e_b_enemy3IsActive = false;
            }
        }
        else
        {
            g_global.g_enemyState.e_b_enemy3IsActive = false;
        }

        // Check Enemy 4
        if (g_global.g_enemyState.enemy4 != null)
        {
            if (g_global.g_enemyState.e_b_enemy4Dead == false)
            {
                g_global.g_enemyState.e_b_enemy4IsActive = true;
            }
            else
            {
                g_global.g_enemyState.e_b_enemy4IsActive = false;
            }
        }
        else
        {
            g_global.g_enemyState.e_b_enemy4IsActive = false;
        }

        // Check Enemy 5
        if (g_global.g_enemyState.enemy5 != null)
        {
            if (g_global.g_enemyState.e_b_enemy5Dead == false)
            {
                g_global.g_enemyState.e_b_enemy5IsActive = true;
            }
            else
            {
                g_global.g_enemyState.e_b_enemy5IsActive = false;
            }
        }
        else
        {
            g_global.g_enemyState.e_b_enemy5IsActive = false;
        }
    }

    /// <summary>
    /// Return the current state of the given enemy based off enemy number
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public bool EnemyStateCheck(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            if (g_global.g_enemyState.enemy1 != null)
            {
                if (g_global.g_enemyState.e_b_enemy1Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (_enemyNum == 2)
        {
            if (g_global.g_enemyState.enemy2 != null)
            {
                if (g_global.g_enemyState.e_b_enemy2Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (_enemyNum == 3)
        {
            if (g_global.g_enemyState.enemy3 != null)
            {
                if (g_global.g_enemyState.e_b_enemy3Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (_enemyNum == 4)
        {
            if (g_global.g_enemyState.enemy4 != null)
            {
                if (g_global.g_enemyState.e_b_enemy4Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (_enemyNum == 5)
        {
            if (g_global.g_enemyState.enemy5 != null)
            {
                if (g_global.g_enemyState.e_b_enemy5Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    ///  Check to see if the enemy's turn should be skipped for a given enemy based off number
    ///  - Josh
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public bool EnemySkipTurnCheck(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return g_global.g_turnManager.e_b_enemy1TurnSkipped;
        }
        else if (_enemyNum == 2)
        {
            return g_global.g_turnManager.e_b_enemy2TurnSkipped;
        }
        else if (_enemyNum == 3)
        {
            return g_global.g_turnManager.e_b_enemy3TurnSkipped;
        }
        else if (_enemyNum == 4)
        {
            return g_global.g_turnManager.e_b_enemy4TurnSkipped;
        }
        else if (_enemyNum == 5)
        {
            return g_global.g_turnManager.e_b_enemy5TurnSkipped;
        }
        else
        {
            Debug.Log("RETURNED NULL FALSE");
            return false;
        }
    }

    /// <summary>
    /// Return the state of the bool for if an enemy is active or not
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public bool GetEnemyActiveState(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_b_enemy1IsActive;
        }
        else if (_enemyNum == 2)
        {
            return e_b_enemy2IsActive;
        }
        else if (_enemyNum == 3)
        {
            return e_b_enemy3IsActive;
        }
        else if (_enemyNum == 4)
        {
            return e_b_enemy4IsActive;
        }
        else if (_enemyNum == 5)
        {
            return e_b_enemy5IsActive;
        }
        else
        {
            Debug.Log("RETURNED NULL FALSE");
            return false;
        }
    }

    /// <summary>
    /// Return the data sheet for a given enemy help
    /// - Josh
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public S_EnemyAttributes GetEnemyDataSheet(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return g_global.g_enemyAttributeSheet1;
        }
        else if (_enemyNum == 2)
        {
            return g_global.g_enemyAttributeSheet2;
        }
        else if (_enemyNum == 3)
        {
            return g_global.g_enemyAttributeSheet3;
        }
        else if (_enemyNum == 4)
        {
            return g_global.g_enemyAttributeSheet4;
        }
        else if (_enemyNum == 5)
        {
            return g_global.g_enemyAttributeSheet2;
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// Return the enemy script based off the given number
    /// - Josh
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public S_Enemy GetEnemyScript(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return g_global.g_enemyState.enemy1;
        }
        if (_enemyNum == 2)
        {
            return g_global.g_enemyState.enemy2;
        }
        if (_enemyNum == 3)
        {
            return g_global.g_enemyState.enemy3;
        }
        if (_enemyNum == 4)
        {
            return g_global.g_enemyState.enemy4;
        }
        if (_enemyNum == 5)
        {
            return g_global.g_enemyState.enemy5;
        }
        else
        {
            Debug.Log("DEBUG: Returned null enemy script!");
            return null;
        }
    }

    /// <summary>
    /// 6 for shield,
    /// 7 for attack,
    /// 8 for Special Ability
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public int GetEnemyAction(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            if (g_global.g_enemyState.e_b_enemy1Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy1Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy1SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else if (_enemyNum == 2)
        {
            if (g_global.g_enemyState.e_b_enemy2Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy2Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy2SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else if (_enemyNum == 3)
        {
            if (g_global.g_enemyState.e_b_enemy3Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy3Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy3SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else if (_enemyNum == 4)
        {
            if (g_global.g_enemyState.e_b_enemy4Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy4Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy4SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else if (_enemyNum == 5)
        {
            if (g_global.g_enemyState.e_b_enemy5Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy5Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy5SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else
        {
            Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
            return 0;
        }
    }

    /// <summary>
    /// If _characterIdentifier == 0, player's turn
    /// Else if _characterIdentifier == 1, 2, 3, 4, 5, it's that enemies turn
    /// For Debug Purposes
    /// - Josh
    /// </summary>
    /// <param name="_characterIdentifier"></param>
    public void DeclareCurrentTurn(int _characterIdentifier)
    {
        if (_characterIdentifier == 0) // Player's Turn
        {
            g_global.g_enemyState.e_b_enemy1Turn = false;
            g_global.g_enemyState.e_b_enemy2Turn = false;
            g_global.g_enemyState.e_b_enemy3Turn = false;
            g_global.g_enemyState.e_b_enemy4Turn = false;
            g_global.g_enemyState.e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 1) // Enemy 1's Turn
        {
            g_global.g_enemyState.e_b_enemy1Turn = true;
            g_global.g_enemyState.e_b_enemy2Turn = false;
            g_global.g_enemyState.e_b_enemy3Turn = false;
            g_global.g_enemyState.e_b_enemy4Turn = false;
            g_global.g_enemyState.e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 2) // Enemy 2's Turn
        {
            g_global.g_enemyState.e_b_enemy1Turn = false;
            g_global.g_enemyState.e_b_enemy2Turn = true;
            g_global.g_enemyState.e_b_enemy3Turn = false;
            g_global.g_enemyState.e_b_enemy4Turn = false;
            g_global.g_enemyState.e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 3) // Enemy 3's Turn
        {
            g_global.g_enemyState.e_b_enemy1Turn = false;
            g_global.g_enemyState.e_b_enemy2Turn = false;
            g_global.g_enemyState.e_b_enemy3Turn = true;
            g_global.g_enemyState.e_b_enemy4Turn = false;
            g_global.g_enemyState.e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 4) // Enemy 4's Turn
        {
            g_global.g_enemyState.e_b_enemy1Turn = false;
            g_global.g_enemyState.e_b_enemy2Turn = false;
            g_global.g_enemyState.e_b_enemy3Turn = false;
            g_global.g_enemyState.e_b_enemy4Turn = true;
            g_global.g_enemyState.e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 5) // Enemy 5's Turn
        {
            g_global.g_enemyState.e_b_enemy1Turn = false;
            g_global.g_enemyState.e_b_enemy2Turn = false;
            g_global.g_enemyState.e_b_enemy3Turn = false;
            g_global.g_enemyState.e_b_enemy4Turn = false;
            g_global.g_enemyState.e_b_enemy5Turn = true;
        }
    }
}
