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

    [Header("Status Effect States")]
    public bool p_b_inBleedingState;
    public bool p_b_inStunnedState;
    public bool p_b_inResistantState;

    [Header("Audio Prefab")]
    public GameObject playerWinMusic;
    public GameObject playerLoseMusic;

    [Header("Status Effect Stores")]
    public int p_i_currentDamageRateForBleed;

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
    public void PlayerStatusEffectDecrement()
    {
        // Check for state
        if(p_i_bleedingTurnCount <= 0)
        {
            p_b_inBleedingState = false;
            g_global.g_UIManager.ToggleBleedPlayerUI(false);
        }
        if (p_i_stunnedTurnCount <= 0)
        {
            g_global.g_turnManager.playerTurnSkipped = false;
            p_b_inStunnedState = false;
            g_global.g_UIManager.ToggleStunPlayerUI(false);
        }
        if (p_i_resistantTurnCount <= 0)
        {
            g_global.g_playerAttributeSheet.p_b_resistant = false;
            p_b_inResistantState = false;
            g_global.g_UIManager.ToggleResistantPlayerUI(false);
        }
        
        // Trigger remaining effects
        if (p_b_inBleedingState == true)
        {
            p_i_bleedingTurnCount -= 1;
            g_global.g_player.PlayerAttacked(p_i_currentDamageRateForBleed);
            g_global.g_UIManager.ToggleBleedPlayerUI(true);
        }
        if (p_b_inStunnedState == true)
        {
            g_global.g_turnManager.playerTurnSkipped = true;
            p_i_stunnedTurnCount -= 1;
            g_global.g_UIManager.ToggleStunPlayerUI(true);
        }
        if (p_b_inResistantState == true)
        {
            g_global.g_playerAttributeSheet.p_b_resistant = true;
            p_i_resistantTurnCount -= 1;
            g_global.g_UIManager.ToggleResistantPlayerUI(true); 
        }
    }

    /// <summary>
    /// Function to trigger for Player Bleed
    /// - Josh
    /// </summary>
    /// <param name="_damageRate"></param>
    /// <param name="_turnCount"></param>
    public void PlayerBleedingStatusEffect(int _damageValue, int _turnCount)
    {
        if (p_b_inBleedingState == false)
        {
            //g_global.g_player.PlayerAttacked(_damageValue);
            g_global.g_UIManager.ToggleBleedPlayerUI(true);
            p_i_bleedingTurnCount = _turnCount;
            p_i_currentDamageRateForBleed = _damageValue;
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
            g_global.g_turnManager.playerTurnSkipped = true;
            g_global.g_UIManager.ToggleStunPlayerUI(true);
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
            g_global.g_playerAttributeSheet.p_b_resistant = true;
            g_global.g_UIManager.ToggleResistantPlayerUI(true);
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

        //go to the new scene
        g_global.g_sceneManager.RewardScene();

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
