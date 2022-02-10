using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TurnManager : MonoBehaviour
{
    private S_Global g_global;

    public bool b_playerInitialTurn = true;
    public bool b_enemyInitialTurn = false;

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
}
