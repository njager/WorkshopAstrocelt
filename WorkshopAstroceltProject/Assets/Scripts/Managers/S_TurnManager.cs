using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 
using FMOD.Studio; 

public class S_TurnManager : MonoBehaviour
{
    private S_Global g_global;

    public GameObject attackSound;
    public bool e_b_enemyDidAttack;

    public bool b_playerInitialTurn = true;
    public bool b_enemyInitialTurn = false;

    private float spawnTimer = 5f;

    /// <summary>
    /// Fetch the global script and assign the global states to the inital choice
    /// - Riley & Josh
    /// </summary>
    void Awake()
    {
        g_global = S_Global.Instance;
        g_global.g_b_playerTurn = b_playerInitialTurn;
        g_global.g_b_enemyTurn = b_enemyInitialTurn;
    }

    void Update()
    {
        if (g_global.g_b_playerTurn == false)
        {
            //Simulating the enemy turn behavior "waiting" before changing back
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0)
            {
                g_global.g_turnManager.PlayerStateChange();
                spawnTimer = 5f;
            }
        }
    }

    /// <summary>
    /// Change the state to the player turn 
    /// trigger the map generation for the new player turn
    /// Reset the selector so the enemy has to be selected again
    /// - Riley & Josh
    /// </summary>
    public void PlayerStateChange()
    {
        //give the player a new hand
        g_global.g_cardManager.NewHand();

        //Temporary map switching triggered by UIManager
        if (g_global.g_mapManager.map_b_map1Used != true)
        {
            g_global.g_mapManager.Map1(); 
        }
        else if(g_global.g_mapManager.map_b_map2Used != true)
        {
            g_global.g_mapManager.Map2();
        }
        else if (g_global.g_mapManager.map_b_map3Used != true)
        {
            g_global.g_mapManager.Map3();
        }
        else if (g_global.g_mapManager.map_b_map4Used != true)
        {
            g_global.g_mapManager.Map4();
        }
        else if (g_global.g_mapManager.map_b_map5Used != true)
        {
            g_global.g_mapManager.Map5();
        }

        // Temp line removal 
        g_global.g_DrawingManager.b_lineDeletionCompletion = false; 
        StartCoroutine(g_global.g_DrawingManager.LineDeletion());

        //clear data for the stars when the map changes (prolly should be a function) "YES IT SHOULD, tell me what needs to be added to clean this up and its purpose -Riley"
        //g_global.g_DrawingManager.s_nodeStarInst.s_star.m_previous = g_global.g_nullStar;
        //g_global.g_DrawingManager.s_nodeStarInst.s_star.m_next = g_global.g_nullStar;
        
        //change the selector
        g_global.g_selectorManager.SelectorReset();

        //stop the audio
        attackSound.SetActive(false);

        //switch turns
        g_global.g_b_playerTurn = true;
        g_global.g_b_enemyTurn = false;
    }

    /// <summary>
    /// Change the state to the enemy turn 
    /// Triggers the changing of the enemy ui icons
    /// - Riley & Josh
    /// </summary>
    public void EnemyStateChange()
    {
        //Switch turns
        g_global.g_b_playerTurn = false;
        g_global.g_b_enemyTurn = true;

        //Then load the next icon
        foreach(S_Enemy _enemy in g_global.e_l_enemyList)
        {
            _enemy.ChangeIcon();
        }
    }

    /// <summary>
    /// This the function that gets triggered when the end turn button is pressed 
    /// -Josh
    /// </summary>
    public void EndTurn()
    {
        if (g_global.g_b_enemyTurn == true)
        {
            Debug.Log("Not your turn!");
            return;
        }
        else
        {
            e_b_enemyDidAttack = false;
            g_global.g_energyManager.ClearEnergy();
            g_global.g_enemyState.EnemyAttackingOrShielding();
            

            if (g_global.g_enemyState.e_b_enemy1Dead != true)
            {
                // Turn damage for Enemy or Shield
                if (g_global.g_enemyAttributeSheet1 != null)
                {
                    if (g_global.g_enemyState.e_b_enemy1Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet1.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet1.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy1Attacking == true)
                    {
                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet1.e_i_enemyDamageValue);
                        e_b_enemyDidAttack = true;
                    }
                    else if(g_global.g_enemyState.e_b_enemy1SpecialAbility == true)
                    {
                        g_global.g_enemyState.enemy1.EnemySpecialAbility(g_global.g_enemyAttributeSheet1.e_str_enemyType);
                    }
                }
            }
            if (g_global.g_enemyState.e_b_enemy2Dead != true)
            {
                // Turn damage for Enemy or Shield
                if (g_global.g_enemyAttributeSheet2 != null)
                {
                    if (g_global.g_enemyState.e_b_enemy2Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet2.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet2.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy2Attacking == true)
                    {
                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet2.e_i_enemyDamageValue);
                        e_b_enemyDidAttack = true;
                    }
                    else if (g_global.g_enemyState.e_b_enemy2SpecialAbility == true)
                    {
                        g_global.g_enemyState.enemy2.EnemySpecialAbility(g_global.g_enemyAttributeSheet2.e_str_enemyType);
                    }
                }
            }
            if (g_global.g_enemyState.e_b_enemy3Dead != true)
            {
                // Turn damage for Enemy or Shield
                if (g_global.g_enemyAttributeSheet3 != null)
                {
                    if (g_global.g_enemyState.e_b_enemy3Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet3.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet3.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy3Attacking == true)
                    {
                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet3.e_i_enemyDamageValue);
                        e_b_enemyDidAttack = true;
                    }
                    else if (g_global.g_enemyState.e_b_enemy3SpecialAbility == true)
                    {
                        g_global.g_enemyState.enemy1.EnemySpecialAbility(g_global.g_enemyAttributeSheet3.e_str_enemyType);
                    }
                }
            }
            if (g_global.g_enemyState.e_b_enemy4Dead != true)
            {
                // Turn damage for Enemy 4
                if (g_global.g_enemyAttributeSheet4 != null)
                {
                    if (g_global.g_enemyState.e_b_enemy4Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet4.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet4.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy4Attacking == true)
                    {
                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet4.e_i_enemyDamageValue);
                        e_b_enemyDidAttack = true;
                    }
                    else if (g_global.g_enemyState.e_b_enemy1SpecialAbility == true)
                    {
                        g_global.g_enemyState.enemy4.EnemySpecialAbility(g_global.g_enemyAttributeSheet4.e_str_enemyType);
                    }
                }
            }
            if (g_global.g_enemyState.e_b_enemy5Dead != true)
            {
                // Turn damage for Enemy 5
                if (g_global.g_enemyAttributeSheet5 != null)
                {
                    if (g_global.g_enemyState.e_b_enemy5Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet5.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet4.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy5Attacking == true)
                    {
                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet5.e_i_enemyDamageValue);
                        e_b_enemyDidAttack = true;
                    }
                    else if (g_global.g_enemyState.e_b_enemy5SpecialAbility == true)
                    {
                        g_global.g_enemyState.enemy5.EnemySpecialAbility(g_global.g_enemyAttributeSheet5.e_str_enemyType);
                    }
                }
            }

            RemoveShielding(); //Remove all shields first
            EnemyStateChange();

            //Play sound
            if(e_b_enemyDidAttack == true)
            {
                PlayAttackSound();
            }
        }
    }

    public void PlayAttackSound()
    {
        attackSound.SetActive(true);
    }

    /// <summary>
    /// Remove shielding as it's supposed to at end of turn
    /// </summary>
    private void RemoveShielding()
    {
        //Reset player
        g_global.g_playerAttributeSheet.p_i_shield = 0;

        //Reset Enemy
        if(g_global.g_enemyAttributeSheet1 != null) // Strip Enemy 1 of Shielding
        {
            g_global.g_enemyAttributeSheet1.e_i_shield = 0;
        }

        if (g_global.g_enemyAttributeSheet2 != null) // Strip Enemy 2 of Shielding
        {
            g_global.g_enemyAttributeSheet2.e_i_shield = 0;
        }

        if (g_global.g_enemyAttributeSheet3 != null) // Strip Enemy 3 of Shielding
        {
            g_global.g_enemyAttributeSheet3.e_i_shield = 0;
        }

        if (g_global.g_enemyAttributeSheet4 != null) // Strip Enemy 4 of Shielding
        {
            g_global.g_enemyAttributeSheet4.e_i_shield = 0;
        }

        if (g_global.g_enemyAttributeSheet5 != null) // Strip Enemy 5 of Shielding
        {
            g_global.g_enemyAttributeSheet5.e_i_shield = 0;
        }
    }
}
