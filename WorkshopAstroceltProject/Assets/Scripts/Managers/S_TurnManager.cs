using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TurnManager : MonoBehaviour
{
    private S_Global g_global;

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
            //Turn indicator changing
            //playerTurnBar.SetActive(false);
            //enemyTurnBar.SetActive(true);

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
        //Temporary map switching triggered by UIManager
        if(g_global.g_mapManager.map_b_map1Used != true)
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
        // Temp line removal 
        g_global.g_ConstellationManager.enumerateTemp = false; 
        StartCoroutine(g_global.g_ConstellationManager.LineDeletion());

        g_global.g_b_playerTurn = true;
        g_global.g_b_enemyTurn = false;
        g_global.g_DrawingManager.s_nodeStarInst.s_star.m_previous = g_global.g_nullStar;
        g_global.g_DrawingManager.s_nodeStarInst.s_star.m_next = g_global.g_nullStar;
        g_global.g_DrawingManager.v2_nodeStarLoc = g_global.g_DrawingManager.s_nodeStarInst.gameObject.transform.position; 
        //g_global.g_mapManager.NewMapGeneration();
        g_global.g_selectorManager.SelectorReset();

    }

    /// <summary>
    /// Change the state to the enemy turn
    /// - Riley & Josh
    /// </summary>
    public void EnemyStateChange()
    {
        g_global.g_b_playerTurn = false;
        g_global.g_b_enemyTurn = true;
    }

    public void EndTurn()
    {
        if (g_global.g_selectorManager.e_enemySelected != null)
        {
            if (g_global.g_b_enemyTurn == true)
            {
                Debug.Log("Not your turn!");
                return;
            }
            else
            {
                // Turn damage for Enemy 1
                if (g_global.g_enemyAttributeSheet1 != null)
                {
                    g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet1.e_i_enemyDamageValue);
                    //Debug.Log("Clicked!");
                    g_global.g_turnManager.EnemyStateChange();
                }
                // Turn damage for Enemy 2
                if (g_global.g_enemyAttributeSheet2 != null)
                {
                    g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet2.e_i_enemyDamageValue);
                    //Debug.Log("Clicked!");
                    g_global.g_turnManager.EnemyStateChange();
                }
                // Turn damage for Enemy 3
                if (g_global.g_enemyAttributeSheet3 != null)
                {
                    g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet3.e_i_enemyDamageValue);
                    //Debug.Log("Clicked!");
                    g_global.g_turnManager.EnemyStateChange();
                }
                // Turn damage for Enemy 4
                if (g_global.g_enemyAttributeSheet4 != null)
                {
                    g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet4.e_i_enemyDamageValue);
                    //Debug.Log("Clicked!");
                    g_global.g_turnManager.EnemyStateChange();
                }
                // Turn damage for Enemy 5
                if (g_global.g_enemyAttributeSheet5 != null)
                {
                    g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet5.e_i_enemyDamageValue);
                    //Debug.Log("Clicked!");
                    g_global.g_turnManager.EnemyStateChange();
                }
            }
        }
        else
        {
            Debug.Log("No enemy Selected!");
            return;
        }

    }

    public void EnemyAttackingOrShielding()
    {
        if(g_global.g_enemyAttributeSheet1 != null) // Check if enemy 1 is present
        {
            if (g_global.g_iconManager.e_b_enemy1Attacking == true) //Enemy 1 Attack
            {
                g_global.g_enemyState.e_b_enemy1Attacking = true;
                g_global.g_enemyState.e_b_enemy1Shielding = false;
            }
            else //Enemy 1 Shield
            {
                g_global.g_enemyState.e_b_enemy1Attacking = false;
                g_global.g_enemyState.e_b_enemy1Shielding = true;
                g_global.g_enemyAttributeSheet1.gameObject.GetComponent<S_Enemy>().EnemyShielded(10); // Temporary shield value gained, as told by designers 
            }
        }

        if (g_global.g_enemyAttributeSheet2 != null) // Check if enemy 2 is present
        {
            if (g_global.g_iconManager.e_b_enemy2Attacking == true) // Enemy 2 Attack
            {
                g_global.g_enemyState.e_b_enemy2Attacking = true;
                g_global.g_enemyState.e_b_enemy2Shielding = false;
            }
            else //Enemy 2 Shield
            {
                g_global.g_enemyState.e_b_enemy2Attacking = false;
                g_global.g_enemyState.e_b_enemy2Shielding = true;
                g_global.g_enemyAttributeSheet2.gameObject.GetComponent<S_Enemy>().EnemyShielded(10);
            }
        }

        if (g_global.g_enemyAttributeSheet3 != null) // Check if enemy 3 is present
        {
            if (g_global.g_iconManager.e_b_enemy3Attacking == true) // Enemy 3 Attack
            {
                g_global.g_enemyState.e_b_enemy3Attacking = true;
                g_global.g_enemyState.e_b_enemy3Shielding = false;
            }
            else // Enemy 3 Shield
            {
                g_global.g_enemyState.e_b_enemy3Attacking = false;
                g_global.g_enemyState.e_b_enemy3Shielding = true;
                g_global.g_enemyAttributeSheet3.gameObject.GetComponent<S_Enemy>().EnemyShielded(10);
            }
        }

        if (g_global.g_enemyAttributeSheet4 != null) // Check if enemy 4 is present
        {
            if (g_global.g_iconManager.e_b_enemy4Attacking == true) // Enemy 4 Attack
            {
                g_global.g_enemyState.e_b_enemy4Attacking = true;
                g_global.g_enemyState.e_b_enemy4Shielding = false;
            }
            else // Enemy 4 Shield
            {
                g_global.g_enemyState.e_b_enemy4Attacking = false;
                g_global.g_enemyState.e_b_enemy4Shielding = true;
                g_global.g_enemyAttributeSheet4.gameObject.GetComponent<S_Enemy>().EnemyShielded(10);
            }
        }

        if (g_global.g_enemyAttributeSheet5 != null) // Check if enemy 5 is present
        {
            if (g_global.g_iconManager.e_b_enemy5Attacking == true) // Enemy 5 Attack
            {
                g_global.g_enemyState.e_b_enemy5Attacking = true;
                g_global.g_enemyState.e_b_enemy5Shielding = false;
            }
            else // Enemy 5 Shield
            {
                g_global.g_enemyState.e_b_enemy5Attacking = false;
                g_global.g_enemyState.e_b_enemy5Shielding = true;
                g_global.g_enemyAttributeSheet5.gameObject.GetComponent<S_Enemy>().EnemyShielded(10);
            }
        }
    }
}
