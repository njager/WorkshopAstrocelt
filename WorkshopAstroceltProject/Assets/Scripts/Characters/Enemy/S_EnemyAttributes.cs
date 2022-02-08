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

    public float e_f_challengeRating;

    // Set this to identify which enemy
    public string e_str_enemyType;

    // Add more enemies to toggle on and off as needed
    [Header("Enemy Type Bools")]
    public bool e_b_enemyIsLumberjack;

    [Header("Status Effects")]
    public bool e_b_poisoned;
    public bool e_b_stunned;
    public bool e_b_bleeding;

    void Start()
    {
        g_global = S_Global.g_instance;

        //Inform Global
        InstanceVariables();

        //Fill sheet 1 in global if enemy 1
        if (gameObject.GetComponent<S_Enemy>().e_i_enemyCount == 1)
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

        //Fill sheet 1 in global if enemy 1
        if (gameObject.GetComponent<S_Enemy>().e_i_enemyCount == 2)
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

        //Fill sheet 1 in global if enemy 1
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

        //Fill sheet 1 in global if enemy 1
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

        //Fill sheet 1 in global if enemy 1
        if (gameObject.GetComponent<S_Enemy>().e_i_enemyCount == 5)
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
    //Temporary
    public void InstanceVariables()
    {
        // PlayerConstants
        e_i_health = 100;
        e_i_healthMax = 100;

        e_i_shield = 100;
        e_i_shieldMax = 100;

        e_f_challengeRating = 1.0f;

        //Status Effects
        e_b_bleeding = false;
        e_b_poisoned = false;
        e_b_stunned = false;
    }
    
}
