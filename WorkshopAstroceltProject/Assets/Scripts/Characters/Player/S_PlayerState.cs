using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class S_PlayerState : MonoBehaviour
{
    private S_Global g_global;

    //Multiple Status Effects could be active at once
    [Header("Status Effect Turn Counts")]
    public int p_i_bleedingTurnCount;
    public int p_i_stunnedTurnCount;
    public int p_i_resistantTurnCount;

    [Header("Status Effect Values")]
    public float bleedingDamageRate;
    public int stunnedDamageValue;

    [Header("Status Effect States")]
    public bool p_b_inBleedingState;
    public bool p_b_inStunnedState;
    public bool p_b_inResistantState;

    [Header("Audio Prefab")]
    public GameObject playerWinMusic;
    public GameObject playerLoseMusic;

    [Header("Status Effect Stores")]
    public float p_f_currentDamageRateForBleed;

    void Awake()
    {
        g_global = S_Global.Instance;
    }

    void Update()
    {
        // Check for health and shield limits here
        if(g_global.g_playerAttributeSheet.p_i_health > g_global.g_playerAttributeSheet.p_i_healthMax)
        {
            g_global.g_playerAttributeSheet.p_i_health = g_global.g_playerAttributeSheet.p_i_healthMax;
        }

        if (g_global.g_playerAttributeSheet.p_i_shield > g_global.g_playerAttributeSheet.p_i_shieldMax)
        {
            g_global.g_playerAttributeSheet.p_i_shield = g_global.g_playerAttributeSheet.p_i_shieldMax;
        }

        if (g_global.g_playerAttributeSheet.p_i_shield <= 0)
        {
            g_global.g_playerAttributeSheet.p_i_shield = 0;
        }

        // If player lost
        if (g_global.g_playerAttributeSheet.p_i_health <= 0)
        {
            PlayerLoses();
        }

        //If player won
        if (g_global.g_i_enemyCount <= 0)
        {
            PlayerWins();
        }
    }


    /// <summary>
    /// Decrement the turn count for effects
    /// Add status effects as needed, call this in turn manager
    /// </summary>
    public void PlayerStatusEffectForTurn()
    {
        // Check for state
        if(p_i_bleedingTurnCount <= 0)
        {
            p_b_inBleedingState = false; 
        }
        if (p_i_stunnedTurnCount <= 0)
        {
            p_b_inStunnedState = false;
        }
        if (p_i_resistantTurnCount <= 0)
        {
            p_b_inResistantState = false; 
        }
        
        // Trigger remaining effects
        if (p_b_inBleedingState)
        {
            p_i_bleedingTurnCount -= 1;
            BleedEffectPerTurn(p_f_currentDamageRateForBleed); 
        }
        if (p_b_inStunnedState)
        {
            p_i_stunnedTurnCount -= 1;
        }
        if (p_b_inResistantState)
        {
            p_i_resistantTurnCount -= 1; 
        }
    }

    /// <summary>
    /// Function to trigger for Player Bleed
    /// - Josh
    /// </summary>
    /// <param name="_damageRate"></param>
    /// <param name="_turnCount"></param>
    public void PlayerBleedingStatusEffect(float _damageRate, int _turnCount)
    {
        int _bleedingDamageForTurn = BleedingEffectCalculator(_damageRate);
        if (p_b_inBleedingState == false)
        {
            g_global.g_player.PlayerAttacked(_bleedingDamageForTurn);
            p_i_bleedingTurnCount = _turnCount;
            p_f_currentDamageRateForBleed = _damageRate;
            p_b_inBleedingState = true;
        }
        else
        {
            Debug.Log("Effect already active!");
        }
    }

    /// <summary>
    /// Function to trigger for Player Stun
    /// - Josh
    /// </summary>
    /// <param name="_turnCount"></param>
    public void PlayerStunnedStatusEffect(int _turnCount)
    {
        if (p_b_inStunnedState == false)
        {
            p_i_stunnedTurnCount = _turnCount;
            p_b_inStunnedState = true; 
        }
        else
        {
            Debug.Log("Effect already active!");
        }
    }

    /// <summary>
    /// Function to trigger for Player Resistance
    /// - Josh
    /// </summary>
    /// <param name="_turnCount"></param>
    public void PlayerResistantEffect(int _turnCount)
    {
        if (p_b_inResistantState == false)
        {
            p_i_resistantTurnCount = _turnCount;
            p_b_inResistantState = true; 
        }
        else
        {
            Debug.Log("Effect already active!");
        }
    }

    /// <summary>
    /// Helper function of a helper function, used to calculate percentage of health
    /// - Josh
    /// </summary>
    /// <param name="_damageRate"></param>
    /// <returns></returns>
    private int BleedingEffectCalculator(float _damageRate)
    {
        int _bleedingCalc = Mathf.RoundToInt(g_global.g_playerAttributeSheet.p_i_health * _damageRate); 
        return _bleedingCalc;
    }

    /// <summary>
    /// Helper to trigger bleed after intial function
    /// - Josh
    /// </summary>
    /// <param name="_damageRate"></param>
    private void BleedEffectPerTurn(float _damageRate)
    {
        int _bleedingDamageForTurn = BleedingEffectCalculator(_damageRate);
        g_global.g_player.PlayerAttacked(_bleedingDamageForTurn);
    }

    /// <summary>
    /// Player Loses Scene
    /// - Josh
    /// </summary>
    public void PlayerLoses()
    {
        //Player lost so trigger lose text and reset canvas
        g_global.g_UIManager.greyboxCanvas.SetActive(false);
        g_global.g_UIManager.resetCanvas.SetActive(true);
        g_global.g_UIManager.loseText.SetActive(true);

        //Play lose sound
        PlaySoundLose();
        //playerLoseMusic.SetActive(false);

        // Pause The game
        //Time.timeScale = 0f;
    }

    /// <summary>
    /// Player Wins Scene
    /// - Josh
    /// </summary>
    public void PlayerWins()
    {
        //Player won so trigger win text and reset canvas
        g_global.g_UIManager.greyboxCanvas.SetActive(false);
        g_global.g_UIManager.resetCanvas.SetActive(true);
        g_global.g_UIManager.winText.SetActive(true);

        //Play win sound
        PlaySoundWin();
        //playerWinMusic.SetActive(false);

        // Pause The game
        //Time.timeScale = 0f;
    }

    private void PlaySoundWin()
    {
        playerWinMusic.SetActive(true);
    }

    private void PlaySoundLose()
    {
        playerLoseMusic.SetActive(true);
    }

}
