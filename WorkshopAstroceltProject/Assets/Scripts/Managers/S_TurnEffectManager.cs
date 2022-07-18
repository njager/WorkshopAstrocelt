using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            g_global.g_UIManager.EnemyHighlightToggle(g_global.g_enemyAttributeSheet1);
        }
        else if (g_global.g_enemyState.CurrentEnemyTurnNumber() == 1) // Enemy 2 Turn Effects
        {
            // Highlight Circle Toggle
            g_global.g_UIManager.EnemyHighlightToggle(g_global.g_enemyAttributeSheet2);
        }
        else if (g_global.g_enemyState.CurrentEnemyTurnNumber() == 1) // Enemy 3 Turn Effects
        {
            // Highlight Circle Toggle
            g_global.g_UIManager.EnemyHighlightToggle(g_global.g_enemyAttributeSheet3);
        }
        else if (g_global.g_enemyState.CurrentEnemyTurnNumber() == 1) // Enemy 4 Turn Effects
        {
            // Highlight Circle Toggle
            g_global.g_UIManager.EnemyHighlightToggle(g_global.g_enemyAttributeSheet4);
        }
        else if (g_global.g_enemyState.CurrentEnemyTurnNumber() == 1) // Enemy 5 Turn Effects 
        {
            // Highlight Circle Toggle
            g_global.g_UIManager.EnemyHighlightToggle(g_global.g_enemyAttributeSheet5);
        }
        else 
        {
            int _debugNumber = g_global.g_enemyState.CurrentEnemyTurnNumber();
            Debug.Log("CurrentEnemyTurnNumber likely returned zero: " + _debugNumber);
            Debug.Log("If not then, check this script rather then S_EnemyState");
        }

    }
}
