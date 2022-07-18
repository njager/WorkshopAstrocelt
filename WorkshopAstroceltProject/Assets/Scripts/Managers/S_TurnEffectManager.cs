using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TurnEffectManager : MonoBehaviour // Enemy Turn Highlighting Script
{
    private S_Global g_global;

    // Start is called before the first frame update
    void Start()
    {
        g_global = S_Global.Instance;
    }

    /// <summary>
    /// Trigger function for helper functions in this script for enemy 1
    /// - Josh
    /// </summary>
    public void Enemy1TurnEffects() 
    {
        g_global.g_UIManager.EnemyHighlightToggle(g_global.g_enemyAttributeSheet1);
    }

    /// <summary>
    /// Trigger function for helper functions in this script for enemy 2
    /// - Josh
    /// </summary>
    public void Enemy2TurnEffects()
    {
        g_global.g_UIManager.EnemyHighlightToggle(g_global.g_enemyAttributeSheet2);
    }

    /// <summary>
    /// Trigger function for helper functions in this script for enemy 3
    /// - Josh
    /// </summary>
    public void Enemy3TurnEffects()
    {
        g_global.g_UIManager.EnemyHighlightToggle(g_global.g_enemyAttributeSheet3);
    }

    /// <summary>
    /// Trigger function for helper functions in this script for enemy 4
    /// - Josh
    /// </summary>
    public void Enemy4TurnEffects()
    {
        g_global.g_UIManager.EnemyHighlightToggle(g_global.g_enemyAttributeSheet4);
    }

    /// <summary>
    /// Trigger function for helper functions in this script for enemy 5
    /// - Josh
    /// </summary>
    public void Enemy5TurnEffects()
    {
        g_global.g_UIManager.EnemyHighlightToggle(g_global.g_enemyAttributeSheet5);
    }
}
