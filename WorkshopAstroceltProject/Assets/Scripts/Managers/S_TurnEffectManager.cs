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
        }
        else 
        {
            if (g_global.g_enemyState.enemy1 != null && g_global.g_enemyState.e_b_enemy1Dead == false)
            {
                g_global.g_enemyState.enemy1.SetToInactiveTurnScale();
            }
        }


        if (g_global.g_enemyState.CurrentEnemyTurnNumber() == 2) // Enemy 2 Turn Effects
        {
            // Highlight Circle Toggle
            g_global.g_enemyState.enemy2.EnemyHighlightToggle();

            // Scale importance
            g_global.g_enemyState.enemy2.SetToActiveTurnScale();
        }
        else
        {
            if (g_global.g_enemyState.enemy2 != null && g_global.g_enemyState.e_b_enemy2Dead == false)
            {
                g_global.g_enemyState.enemy2.SetToInactiveTurnScale();
            }
        }


        if (g_global.g_enemyState.CurrentEnemyTurnNumber() == 3) // Enemy 3 Turn Effects
        {
            // Highlight Circle Toggle
            g_global.g_enemyState.enemy3.EnemyHighlightToggle();

            // Scale importance
            g_global.g_enemyState.enemy3.SetToActiveTurnScale();
        }
        else
        {
            if (g_global.g_enemyState.enemy3 != null && g_global.g_enemyState.e_b_enemy3Dead == false)
            {
                g_global.g_enemyState.enemy3.SetToInactiveTurnScale();
            }
        }


        if (g_global.g_enemyState.CurrentEnemyTurnNumber() == 4) // Enemy 4 Turn Effects
        {
            // Highlight Circle Toggle
            g_global.g_enemyState.enemy4.EnemyHighlightToggle();

            // Scale importance
            g_global.g_enemyState.enemy4.SetToActiveTurnScale();
        }
        else
        {
            if (g_global.g_enemyState.enemy4 != null && g_global.g_enemyState.e_b_enemy4Dead == false)
            {
                g_global.g_enemyState.enemy4.SetToInactiveTurnScale();
            }
        }


        if (g_global.g_enemyState.CurrentEnemyTurnNumber() == 5) // Enemy 5 Turn Effects 
        {
            // Highlight Circle Toggle
            g_global.g_enemyState.enemy5.EnemyHighlightToggle();

            // Scale importance
            g_global.g_enemyState.enemy5.SetToActiveTurnScale();
        }
        else
        {
            if (g_global.g_enemyState.enemy5 != null && g_global.g_enemyState.e_b_enemy5Dead == false)
            {
                g_global.g_enemyState.enemy5.SetToInactiveTurnScale();
            }
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
            _enemy.EnemyHighlightToggle();
        }
    }
}
