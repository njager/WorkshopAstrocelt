using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AudioManager : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    private S_Global g_global;

    [Header("Combat Scene")]
    public bool b_combatScene;

    [Header("Time Elapsed")]
    public float f_timeInScene = 0;

    [Header("Random Number for Integer")]
    [SerializeField] float f_randomFloatValue;

    [Header("Player Percentage Values")]
    public float p_f_playerAudioPercentage;
        
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

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    
    /// <summary>
    /// Set the float percentage of the S_AudioManager.p_f_playerAudioPercentage
    /// - Josh
    /// </summary>
    /// <param name="_percentage"></param>
    public void SetPlayerAudioPercentage(float _percentage)
    {
        p_f_playerAudioPercentage = _percentage;
    }

    /// <summary>
    /// Set the float percentage of the S_AudioManager.e_f_enemy1AudioPercentage
    /// - Josh
    /// </summary>
    /// <param name="_percentage"></param>
    public void SetEnemy1AudioPercentage(float _percentage)
    {
        e_f_enemy1AudioPercentage = _percentage;
    }

    /// <summary>
    /// Set the float percentage of the S_AudioManager.e_f_enemy2AudioPercentage
    /// - Josh
    /// </summary>
    /// <param name="_percentage"></param>
    public void SetEnemy2AudioPercentage(float _percentage)
    {
        e_f_enemy2AudioPercentage = _percentage;
    }

    /// <summary>
    /// Set the float percentage of the S_AudioManager.e_f_enemy3AudioPercentage
    /// - Josh
    /// </summary>
    /// <param name="_percentage"></param>
    public void SetEnemy3AudioPercentage(float _percentage)
    {
        e_f_enemy3AudioPercentage = _percentage;
    }

    /// <summary>
    /// Set the float percentage of the S_AudioManager.e_f_enemy4AudioPercentage
    /// - Josh
    /// </summary>
    /// <param name="_percentage"></param>
    public void SetEnemy4AudioPercentage(float _percentage)
    {
        e_f_enemy4AudioPercentage = _percentage;
    }

    /// <summary>
    /// Set the float percentage of the S_AudioManager.e_f_enemy5AudioPercentage
    /// - Josh
    /// </summary>
    /// <param name="_percentage"></param>
    public void SetEnemy5AudioPercentage(float _percentage)
    {
        e_f_enemy5AudioPercentage = _percentage;
    }

    /// <summary>
    /// Set the float percentage of the S_AudioManager.e_f_bossAudioPercentage
    /// - Josh
    /// </summary>
    /// <param name="_percentage"></param>
    public void SetBossAudioPercentage(float _percentage)
    {
        e_f_bossAudioPercentage = _percentage;
    }
}
