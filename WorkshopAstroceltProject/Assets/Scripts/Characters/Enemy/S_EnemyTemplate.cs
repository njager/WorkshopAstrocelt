using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyTemplate : ScriptableObject 
{
    // Not used

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
}
