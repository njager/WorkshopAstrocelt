using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class S_TurnEffectManager : MonoBehaviour // Enemy Turn Highlighting Script
{
    private S_Global g_global;

    // Start is called before the first frame update
    void Awake()
    {
        g_global = S_Global.Instance;
    }

    /// <summary>
    /// Major trigger function for helper functions in this script for the current enemy turn
    /// - Josh
    /// </summary>
    public void EnemyTurnEffects() 
    {
        if (g_global.g_enemyState.CurrentEnemyTurnNumber() == 1) // Enemy 1 Turn Effects
        {
            // Highlight Circle Toggle
            g_global.g_enemyState.enemy1.EnemyHighlightToggle();

            // Scale importance
            g_global.g_enemyState.enemy1.SetToActiveTurnScale();

            // Scale down all other enemies
            if(g_global.g_enemyState.enemy2 != null && g_global.g_enemyState.e_b_enemy2Dead == false) 
            {
                g_global.g_enemyState.enemy2.SetToInactiveTurnScale();
            }
            if (g_global.g_enemyState.enemy3 != null && g_global.g_enemyState.e_b_enemy3Dead == false)
            {
                g_global.g_enemyState.enemy3.SetToInactiveTurnScale();
            }
            if (g_global.g_enemyState.enemy4 != null && g_global.g_enemyState.e_b_enemy4Dead == false)
            {
                g_global.g_enemyState.enemy4.SetToInactiveTurnScale();
            }
            if (g_global.g_enemyState.enemy5 != null && g_global.g_enemyState.e_b_enemy5Dead == false)
            {
                g_global.g_enemyState.enemy5.SetToInactiveTurnScale();
            }
        }
        else if (g_global.g_enemyState.CurrentEnemyTurnNumber() == 2) // Enemy 2 Turn Effects
        {
            
        }
        else if (g_global.g_enemyState.CurrentEnemyTurnNumber() == 3) // Enemy 3 Turn Effects
        {
            
        }
        else if (g_global.g_enemyState.CurrentEnemyTurnNumber() == 4) // Enemy 4 Turn Effects
        {
            
        }
        else if (g_global.g_enemyState.CurrentEnemyTurnNumber() == 5) // Enemy 5 Turn Effects 
        {
           
        }
        else 
        {
            int _debugNumber = g_global.g_enemyState.CurrentEnemyTurnNumber();
            Debug.Log("CurrentEnemyTurnNumber likely returned zero: " + _debugNumber);
            Debug.Log("If not then, check this script rather then S_EnemyState");
        }

    }

    /// <summary>
    /// Undo the enemy scale changes for the player turn
    /// - Josh
    /// </summary>
    public void SetDefaultScaleForEnemies()
    {
        // Setting default sizes
        foreach(S_Enemy _enemy in g_global.e_ls_enemyList.ToList()) 
        {
            _enemy.SetToPlayerTurnScale();
        }
    }
}
