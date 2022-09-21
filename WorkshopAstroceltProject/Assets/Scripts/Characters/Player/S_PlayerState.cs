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

    [Header("Audio Prefabs")]
    public GameObject p_playerWinMusic;
    public GameObject p_playerLoseMusic;

    [Header("Turns passed for Status effects")]
    public int p_i_turnsPassedForStun;
    public int p_i_turnsPassedForResistant;

    [Header("Status Effect Stores")]
    public float p_f_currentDamageRateForBleed;

    [Header("Final Scene Bool")]
    public bool b_finalScene = false;

    void Awake()
    {
        g_global = S_Global.Instance;
    }

    void Update()
    {
        

        

        

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
    /// Check the maximums and minimum values that can be represented and limit them
    /// </summary>
    public void PlayerValuesLimitCheck() 
    {
        // If player went above max shields, limit to max shields
        if (g_global.g_playerAttributeSheet.GetPlayerHealthValue() > g_global.g_playerAttributeSheet.GetPlayerMaxHealthValue())
        {
            g_global.g_playerAttributeSheet.SetPlayerHealthValue(g_global.g_playerAttributeSheet.GetPlayerMaxHealthValue());
        }

        // If player went above max shields, limit to max shields
        if (g_global.g_playerAttributeSheet.GetPlayerShieldValue() > g_global.g_playerAttributeSheet.GetPlayerMaxShieldValue())
        {
            g_global.g_playerAttributeSheet.SetPlayerShieldValue(g_global.g_playerAttributeSheet.GetPlayerMaxShieldValue());
        }

        // If shield value goes below 0, set back to 0
        if (g_global.g_playerAttributeSheet.GetPlayerShieldValue() < 0)
        {
            g_global.g_playerAttributeSheet.SetPlayerShieldValue(0);
        }

        // If health value goes below 0, set back to 0
        if (g_global.g_playerAttributeSheet.GetPlayerHealthValue() < 0)
        {
            g_global.g_playerAttributeSheet.SetPlayerHealthValue(0);
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
            g_global.g_turnManager.p_b_playerTurnSkipped = false;
            p_b_inStunnedState = false;
            g_global.g_UIManager.ToggleStunPlayerUI(false);
            p_i_turnsPassedForStun = 0;
        }
        if (p_i_resistantTurnCount <= 0)
        {
            g_global.g_playerAttributeSheet.p_b_resistant = false;
            p_b_inResistantState = false;
            g_global.g_UIManager.ToggleResistantPlayerUI(false);
            p_i_turnsPassedForResistant = 0;
        }
        
        // Trigger remaining effects
        if (p_b_inBleedingState == true)
        {
            p_i_bleedingTurnCount -= 1;
            BleedEffectPerTurn(p_f_currentDamageRateForBleed);
            g_global.g_UIManager.ToggleBleedPlayerUI(true);
        }
        if (p_b_inStunnedState == true)
        {
            g_global.g_turnManager.p_b_playerTurnSkipped = true;
            p_i_stunnedTurnCount -= 1;
            p_i_turnsPassedForStun += 1;
            g_global.g_UIManager.ToggleStunPlayerUI(true);
        }
        if (p_b_inResistantState == true)
        {
            g_global.g_playerAttributeSheet.p_b_resistant = true;
            p_i_resistantTurnCount -= 1;
            p_i_turnsPassedForResistant += 1;
            g_global.g_UIManager.ToggleResistantPlayerUI(true); 
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
        if (p_b_inBleedingState == false)
        {
            g_global.g_UIManager.ToggleBleedPlayerUI(true);
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
            g_global.g_turnManager.p_b_playerTurnSkipped = true;
            p_i_turnsPassedForStun += 1;
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
            p_i_turnsPassedForResistant += 1;
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
        g_global.g_UIManager.cn_resetCanvas.SetActive(true);
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
        g_global.g_UIManager.cn_characterCanvas.SetActive(false);
        g_global.g_UIManager.cn_resetCanvas.SetActive(true);
        g_global.g_UIManager.winText.SetActive(true);

        g_global.g_gameManager.i_playerHealth = g_global.g_playerAttributeSheet.p_i_health;
        Debug.Log("Did this hit?");
        Debug.Log(g_global.g_gameManager.i_playerHealth);

        //Play win sound
        PlaySoundWin();
        //playerWinMusic.SetActive(false);

        if (!b_finalScene)
        {
            //go to the new scene
            g_global.g_sceneManager.ChangeScene();
        }

        // Pause The game
        //Time.timeScale = 0f;
    }

    private void PlaySoundWin()
    {
        p_playerWinMusic.SetActive(true);
    }

    private void PlaySoundLose()
    {
        p_playerLoseMusic.SetActive(true);
    }

}
