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
    void Start()
    {
        g_global = S_Global.g_instance;
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
        g_global.g_b_playerTurn = true;
        g_global.g_b_enemyTurn = false;
        g_global.g_mapManager.NewMapGeneration();
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
