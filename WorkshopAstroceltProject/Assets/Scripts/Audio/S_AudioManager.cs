using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AudioManager : MonoBehaviour
{
    private S_Global g_global;

    [Header("Combat Scene?")]
    public bool b_combatScene;

    [Header("the time in game")]
    public float f_timeInScene = 0;

    [Header("Random Number for Integer")]
    public float f_randomFloatValue;

    [Header("Boss Health")]
    public float e_f_enemyHealth;

    [Header("Boss Health Max")]
    public float e_f_enemyMaxHealth;

    private void Awake()
    {
        g_global = S_Global.Instance;

        // Set the random values
        float _randomInt1 = GetRandomFloatNumber();
        float _randomInt2 = GetRandomFloatNumber();

        // Add them to enemy health
        e_f_enemyHealth = g_global.g_enemyState.e_bossEnemy.GetComponent<S_EnemyAttributes>().GetEnemyHealthValue() + _randomInt1;
        e_f_enemyMaxHealth = g_global.g_enemyState.e_bossEnemy.GetComponent<S_EnemyAttributes>().GetEnemyMaxHealthValue() + _randomInt2;
    }

    private void Update()
    {
        f_timeInScene += Time.deltaTime;
    }


    /// <summary>
    /// Helper to set the random float value to a randomly pulled valued
    /// - Josh
    /// </summary>
    private void SetRandomFloatNumber()
    {
        f_randomFloatValue = Random.Range(0.01f, 0.9f); 
    }

    /// <summary>
    /// Helper to change what the random value is
    /// - Josh
    /// </summary>
    private void ResetRandomValue()
    {
        SetRandomFloatNumber();
    }

    /// <summary>
    /// Get the random float value to add in to boss health values
    /// - Josh
    /// </summary>
    /// <returns>
    /// Returns S_AudioManager.e_f_enemyMaxHealth
    /// </returns>
    public float GetRandomFloatNumber()
    {
        ResetRandomValue();
        return f_randomFloatValue;
    }
}
