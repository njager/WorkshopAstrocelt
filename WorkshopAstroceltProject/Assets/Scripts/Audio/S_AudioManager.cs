using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AudioManager : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    private S_Global g_global;

    [Header("Combat Scene?")]
    public bool b_combatScene;

    [Header("the time in game")]
    public float f_timeInScene = 0;

    [Header("Random Number for Integer")]
    public float f_randomFloatValue;

    [Header("Player Health")]
    [SerializeField] float p_f_playerHealth;

    [Header("Player Health Max")]
    [SerializeField] float p_f_playerMaxHealth;

    [Header("Boss Health")]
    [SerializeField] float e_f_bossHealth;

    [Header("Boss Health Max")]
    [SerializeField] float e_f_bossMaxHealth;

    [Header("Enemies Health Values")]
    [SerializeField] float e_f_enemy1Health;
    [SerializeField] float e_f_enemy2Health;
    [SerializeField] float e_f_enemy3Health;
    [SerializeField] float e_f_enemy4Health;
    [SerializeField] float e_f_enemy5Health;

    [Header("Enemies Max Health Values")]
    [SerializeField] float e_f_enemy1MaxHealth;
    [SerializeField] float e_f_enemy2MaxHealth;
    [SerializeField] float e_f_enemy3MaxHealth;
    [SerializeField] float e_f_enemy4MaxHealth;
    [SerializeField] float e_f_enemy5MaxHealth;

    [Header("Player Percentage Values")]
    public float e_f_playerAudioPercentage;
        
    [Header("Enemy Percentage Values")]
    public float e_f_enemy1AudioPercentage;
    public float e_f_enemy2AudioPercentage;
    public float e_f_enemy3AudioPercentage;
    public float e_f_enemy4AudioPercentage;
    public float e_f_enemy5AudioPercentage;

    [Header("Boss Percentage Values")]
    public float e_f_bossAudioPercentage;

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    private void Start()
    {
        CalculateAudioPercentages(); 
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

    /// <summary>
    /// Calculate the audio percentage for Victor to use based off enemy values
    /// </summary>
    public void CalculateAudioPercentages()
    {
        /// Calculate Boss Audio Percentage \\\
        
        // Set the random values
        float _randomInt1 = GetRandomFloatNumber();
        float _randomInt2 = GetRandomFloatNumber();

        // Add them to enemy health
        e_f_bossHealth = g_global.g_enemyState.e_bossEnemy.GetComponent<S_EnemyAttributes>().GetEnemyHealthValue() + _randomInt1;
        e_f_bossMaxHealth = g_global.g_enemyState.e_bossEnemy.GetComponent<S_EnemyAttributes>().GetEnemyMaxHealthValue() + _randomInt2;

        // Calculate and Set the Percentage
        float _temp1 = e_f_bossHealth / e_f_bossMaxHealth;
        e_f_bossAudioPercentage = _temp1 * 100;


        ////// Calculate Enemy Audio Values \\\\\\

        //// Enemy 1 \\\\

        // Set the random values
        float _randomInt3 = GetRandomFloatNumber();
        float _randomInt4 = GetRandomFloatNumber();

        // Add them to enemy health
        e_f_enemy1Health = g_global.g_enemyAttributeSheet1.GetEnemyHealthValue() + _randomInt3;
        e_f_enemy1MaxHealth = g_global.g_enemyAttributeSheet1.GetEnemyMaxHealthValue() + _randomInt4;

        // Calculate and Set the Percentage
        float _temp2 = e_f_enemy1Health / e_f_enemy1MaxHealth;
        e_f_enemy1AudioPercentage = _temp2 * 100;

        //// Enemy 2 \\\\

        // Set the random values
        float _randomInt5 = GetRandomFloatNumber();
        float _randomInt6 = GetRandomFloatNumber();

        // Add them to enemy health
        e_f_enemy2Health = g_global.g_enemyAttributeSheet2.GetEnemyHealthValue() + _randomInt5;
        e_f_enemy2MaxHealth = g_global.g_enemyAttributeSheet2.GetEnemyMaxHealthValue() + _randomInt6;

        // Calculate and Set the Percentage
        float _temp3 = e_f_enemy2Health / e_f_enemy2MaxHealth;
        e_f_enemy2AudioPercentage = _temp3 * 100;

        //// Enemy 3 \\\\

        // Set the random values
        float _randomInt7 = GetRandomFloatNumber();
        float _randomInt8 = GetRandomFloatNumber();

        // Add them to enemy health
        e_f_enemy3Health = g_global.g_enemyAttributeSheet3.GetEnemyHealthValue() + _randomInt7;
        e_f_enemy3MaxHealth = g_global.g_enemyAttributeSheet3.GetEnemyMaxHealthValue() + _randomInt8;

        // Calculate and Set the Percentage
        float _temp4 = e_f_enemy3Health / e_f_enemy3MaxHealth;
        e_f_enemy3AudioPercentage = _temp4 * 100;

        //// Enemy 4 \\\\

        // Set the random values
        float _randomInt9 = GetRandomFloatNumber();
        float _randomInt10 = GetRandomFloatNumber();

        // Add them to enemy health
        e_f_enemy4Health = g_global.g_enemyAttributeSheet4.GetEnemyHealthValue() + _randomInt9;
        e_f_enemy4MaxHealth = g_global.g_enemyAttributeSheet4.GetEnemyMaxHealthValue() + _randomInt10;

        // Calculate and Set the Percentage
        float _temp5 = e_f_enemy4Health / e_f_enemy4MaxHealth;
        e_f_enemy4AudioPercentage = _temp5 * 100;

        //// Enemy 5 \\\\

        // Set the random values
        float _randomInt11 = GetRandomFloatNumber();
        float _randomInt12 = GetRandomFloatNumber();

        // Add them to enemy health
        e_f_enemy5Health = g_global.g_enemyAttributeSheet5.GetEnemyHealthValue() + _randomInt11;
        e_f_enemy5MaxHealth = g_global.g_enemyAttributeSheet5.GetEnemyMaxHealthValue() + _randomInt12;

        // Calculate and Set the Percentage
        float _temp6 = e_f_enemy5Health / e_f_enemy5MaxHealth;
        e_f_enemy5AudioPercentage = _temp6 * 100;
    }
}
