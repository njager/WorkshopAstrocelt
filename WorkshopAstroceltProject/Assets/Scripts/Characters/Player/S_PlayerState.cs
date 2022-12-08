using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class S_PlayerState : MonoBehaviour
{
    private S_Global g_global;

    //Multiple Status Effects could be active at once
    [Header("PlayerStatus Effect Turn Counts")]
    [SerializeField] int p_i_acidicStackCount;
    [SerializeField] int p_i_bleedingStackCount;
    [SerializeField] int p_i_frailtyStackCount;
    [SerializeField] int p_i_resistantStackCount;

    [Header("Status Effect States")]
    [SerializeField] bool p_b_inAcidicState;
    [SerializeField] bool p_b_inBleedingState;
    [SerializeField] bool p_b_inFrailState;
    [SerializeField] bool p_b_inResistantState;

    [Header("Audio Prefabs")]
    [SerializeField] GameObject p_playerWinMusic;
    [SerializeField] GameObject p_playerLoseMusic;

    [Header("Turns passed for Status effects")]
    [SerializeField] int p_i_playerResistantStackRemainder;
    [SerializeField] int p_i_playerFrailtyStackRemainder;

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    private void Update()
    {
        PlayerWinOrLose(); // Update isn't evil, we want some things to be instantanous - Josh

        // It's become evil -J
    }

    /// <summary>
    /// Check to see if the player will win or lose based off the given conditions
    /// - Josh
    /// </summary>
    public void PlayerWinOrLose() 
    {
        // Player lose condition, health has been depleated
        if (g_global.g_playerAttributeSheet.GetPlayerHealthValue() <= 0)
        {
            PlayerLoses();
        }

        // Player win condition, no more enemies
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
        if (p_i_acidicStackCount <= 0)
        {
             = false;
            g_global.g_UIManager.ToggleBleedPlayerUI(false);
        }
        // Check for state
        if (p_i_bleedingStackCount <= 0)
        {
            p_b_inBleedingState = false;
            g_global.g_UIManager.ToggleBleedPlayerUI(false);
        }
        if (p_i_frailtyStackCount <= 0)
        {
            g_global.g_turnManager.p_b_playerTurnSkipped = false;
            p_b_inStunnedState = false;
            g_global.g_UIManager.ToggleStunPlayerUI(false);
            p_i_turnsPassedForStun = 0;
        }
        if (p_i_resistantStackCount <= 0)
        {
            g_global.g_playerAttributeSheet.p_b_resistant = false;
            p_b_inResistantState = false;
            g_global.g_UIManager.ToggleResistantPlayerUI(false);
            p_i_turnsPassedForResistant = 0;
        }
        
        // Trigger remaining effects
        if (p_b_inBleedingState == true)
        {
            p_i_bleedingStackCount -= 1;
            BleedEffectPerTurn(p_f_currentDamageRateForBleed);
            g_global.g_UIManager.ToggleBleedPlayerUI(true);
        }
        if (p_b_inStunnedState == true)
        {
            g_global.g_turnManager.p_b_playerTurnSkipped = true;
            p_i_stunnedStackCount -= 1;
            p_i_turnsPassedForStun += 1;
            g_global.g_UIManager.ToggleStunPlayerUI(true);
        }
        if (p_b_inResistantState == true)
        {
            g_global.g_playerAttributeSheet.p_b_resistant = true;
            p_i_resistantStackCount -= 1;
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
            p_i_bleedingStackCount = _turnCount;
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
            p_i_stunnedStackCount = _turnCount;
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
            p_i_resistantStackCount = _turnCount;
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
        int _bleedingCalc = Mathf.RoundToInt(g_global.g_playerAttributeSheet.GetPlayerHealthValue() * _damageRate); 
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
        if (!g_global.g_sceneManager.b_finalScene)
        {
            //pass on the player health
            g_global.g_gameManager.i_playerHealth = g_global.g_playerAttributeSheet.GetPlayerHealthValue();
            Debug.Log("Player health " + g_global.g_gameManager.i_playerHealth);

            //go to the new scene
            g_global.g_sceneManager.ChangeScene();
        }
        else
        {
            //Player won so trigger win text and reset canvas
            g_global.g_UIManager.cn_characterCanvas.SetActive(false);
            g_global.g_UIManager.cn_resetCanvas.SetActive(true);
            g_global.g_UIManager.winText.SetActive(true);

            
            Debug.Log("Did this hit?");
            Debug.Log(g_global.g_gameManager.i_playerHealth);

            //Play win sound
            PlaySoundWin();
            //playerWinMusic.SetActive(false);

            // Pause The game
            //Time.timeScale = 0f;
        }
    }

    /////////////////////////////-----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Private Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////-----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private void PlaySoundWin()
    {
        p_playerWinMusic.SetActive(true);
    }

    private void PlaySoundLose()
    {
        p_playerLoseMusic.SetActive(true);
    }

    /////////////////////////////------------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Player Status Effect Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////------------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the int value of S_PlayerState.
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    public void SetPlayerAcidicEffectStackCount(int _stackCount)
    {
        p_i_acidicStackCount = _stackCount;
    }

    /// <summary>
    /// Set the int value of S_PlayerState.
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    public void SetPlayerBleedEffectStackCount(int _stackCount)
    {
        p_i_bleedingStackCount = _stackCount;
    }

    /// <summary>
    /// Set the int value of S_PlayerState.
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    public void SetPlayerFrailtyEffectStackCount(int _stackCount)
    {
        p_i_frailtyStackCount = _stackCount;
    }

    /// <summary>
    /// Set the int value of S_PlayerState.
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    public void SetPlayerResistantEffectStackCount(int _stackCount)
    {
        p_i_resistantStackCount = _stackCount;
    }

    /// <summary>
    /// Set the bool state of S_PlayerState.p_b_inAcidicState
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    public void SetPlayerAcidicEffectState(bool _state)
    {
        p_b_inAcidicState = _state;
    }

    /// <summary>
    /// Set the bool state of S_PlayerState.p_b_inBleedingState
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    public void SetPlayerBleedEffectState(bool _state)
    {
        p_b_inBleedingState = _state;
    }

    /// <summary>
    /// Set the bool state of S_PlayerState.p_b_inFrailState
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    public void SetPlayerFrailtytEffectState(bool _state)
    {
        p_b_inFrailState = _state;
    }

    /// <summary>
    /// Set the bool state of S_PlayerState.p_b_inResistantState
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    public void SetPlayerResistantEffectState(bool _state)
    {
        p_b_inResistantState = _state;
    }

    /////////////////////////////------------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Player Status Effect Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////------------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the int value of S_PlayerState.p_i_acidicStackCount
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerState.p_i_acidicStackCount
    /// </returns>
    public int GetPlayerAcidicEffectStackCount()
    {
        return p_i_acidicStackCount;
    }

    /// <summary>
    /// Return the int value of S_PlayerState.p_i_bleedingStackCount
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerState.p_i_bleedingStackCount
    /// </returns>
    public int GetPlayerBleedEffectStackCount()
    {
        return p_i_bleedingStackCount;
    }

    /// <summary>
    /// Return the int value of S_PlayerState.p_i_frailtyStackCount
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerState.p_i_frailtyStackCount
    /// </returns>
    public int GetPlayerFrailtyEffectStackCount()
    {
        return p_i_frailtyStackCount;
    }

    /// <summary>
    /// Return the int value of S_PlayerState.p_i_resistantStackCount
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerState.p_i_resistantStackCount
    /// </returns>
    public int GetPlayerResistantEffectStackCount()
    {
        return p_i_resistantStackCount;
    }

    /// <summary>
    /// Return the bool state of S_PlayerState.p_b_inAcidicState
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerState.p_b_inAcidicState
    /// </returns>
    public bool GetPlayerAcidicEffectState()
    {
        return p_b_inAcidicState;
    }

    /// <summary>
    /// Return the bool state of S_PlayerState.p_b_inBleedingState
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerState.p_b_inBleedingState
    /// </returns>
    public bool GetPlayerBleedEffectState()
    {
        return p_b_inBleedingState;
    }

    /// <summary>
    /// Return the bool state of S_PlayerState.p_b_inFrailState
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerState.p_b_inFrailState
    /// </returns>
    public bool GetPlayerFrailtyEffectState()
    {
        return p_b_inFrailState;
    }

    /// <summary>
    /// Return the bool state of S_PlayerState.p_b_inResistantState
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerState.p_b_inResistantState
    /// </returns>
    public bool GetPlayerResistantEffectState()
    {
        return p_b_inResistantState;
    }
}
