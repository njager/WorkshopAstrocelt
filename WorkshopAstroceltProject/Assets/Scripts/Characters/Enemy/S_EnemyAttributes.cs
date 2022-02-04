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
        g_global.g_enemyAttributeSheet = this;
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
