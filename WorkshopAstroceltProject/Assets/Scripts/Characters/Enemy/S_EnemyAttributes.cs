using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyAttributes : MonoBehaviour
{
    //public S_EnemyTemplate enemyTemplate;

    private S_Global g_global;

    [Header("Frequency Rates")]
    public float e_f_attackRate;
    public float e_f_shieldRate;
    public float e_f_specialAbilityRate;

    [Header("Enemy Attributes")]
    public int e_i_health;
    public int e_i_healthMax;

    public int e_i_shield;
    public int e_i_shieldMax;

    public int e_i_enemyDamageValue;

    public float e_f_challengeRating;

    [Header("Typing")]
    public string e_str_enemyType;

    // Add more enemies to toggle on and off as needed
    [Header("Enemy Type Bools")]
    public bool e_b_enemyIsLumberjack;

    [Header("Status Effects")]
    public bool e_b_poisoned;
    public bool e_b_stunned;
    public bool e_b_bleeding;
    public bool e_b_empowered;
    public bool e_b_lucky;
    public bool e_b_restrained;
    public bool e_b_burned;
    public bool e_b_shocked;

    //It's attached enemy script
    public S_Enemy e_enemyScript;

    public void Awake()
    {
        g_global = S_Global.Instance; 

        //Inform Global
        InstanceVariables();
        e_enemyScript = gameObject.GetComponent<S_Enemy>();

        //Fill sheet 1 in global if enemy 1
        if (e_enemyScript.e_i_enemyCount == 1)
        {
            if (g_global.g_enemyAttributeSheet1 == null)
            {
                g_global.g_enemyAttributeSheet1 = this;
            }
            else
            {
                Debug.Log("Something Already filled up this Sheet! And wasn't supposed to!"); 
            }
        }

        //Fill sheet 2 in global if enemy 2
        if (e_enemyScript.e_i_enemyCount == 2)
        {
            if (g_global.g_enemyAttributeSheet2 == null)
            {
                g_global.g_enemyAttributeSheet2 = this;
            }
            else
            {
                Debug.Log("Something Already filled up this Sheet! And wasn't supposed to!");
            }
        }

        //Fill sheet 3 in global if enemy 3
        if (gameObject.GetComponent<S_Enemy>().e_i_enemyCount == 3)
        {
            if (g_global.g_enemyAttributeSheet3 == null)
            {
                g_global.g_enemyAttributeSheet3 = this;
            }
            else
            {
                Debug.Log("Something Already filled up this Sheet! And wasn't supposed to!");
            }
        }

        //Fill sheet 4 in global if enemy 4
        if (gameObject.GetComponent<S_Enemy>().e_i_enemyCount == 4)
        {
            if (g_global.g_enemyAttributeSheet4 == null)
            {
                g_global.g_enemyAttributeSheet4 = this;
            }
            else
            {
                Debug.Log("Something Already filled up this Sheet! And wasn't supposed to!");
            }
        }

        //Fill sheet 5 in global if enemy 5
        if (e_enemyScript.e_i_enemyCount == 5)
        {
            if (g_global.g_enemyAttributeSheet5 == null)
            {
                g_global.g_enemyAttributeSheet5 = this;
            }
            else
            {
                Debug.Log("Something Already filled up this Sheet! And wasn't supposed to!");
            }
        }
    }

    private void Start()
    {
        g_global.g_iconManager.EnemyIconNextTurn(e_enemyScript);

        if (e_enemyScript.e_i_enemyCount == 1)
        {
            g_global.g_enemyState.enemy1 = e_enemyScript;
        }
        if (e_enemyScript.e_i_enemyCount == 2)
        {
            g_global.g_enemyState.enemy2 = e_enemyScript;
        }
        if (e_enemyScript.e_i_enemyCount == 3)
        {
            g_global.g_enemyState.enemy3 = e_enemyScript;
        }
        if (e_enemyScript.e_i_enemyCount == 4)
        {
            g_global.g_enemyState.enemy4 = e_enemyScript;
        }
        if (e_enemyScript.e_i_enemyCount == 5)
        {
            g_global.g_enemyState.enemy5 = e_enemyScript;
        }
    }

    //Temporary
    public void InstanceVariables()
    {
        // PlayerConstants
        e_i_health = 100;
        e_i_healthMax = 100;

        e_i_shield = 100;
        e_i_shieldMax = 100;

        e_i_enemyDamageValue = 5;

        e_f_challengeRating = 1.0f;

        e_str_enemyType = "Lumberjack"; 

        //Status Effects
        e_b_bleeding = false;
        e_b_poisoned = false;
        e_b_stunned = false;
    }
    
}
