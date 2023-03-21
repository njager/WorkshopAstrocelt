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
    [SerializeField] bool chg_p_b_inAcidicState;
    [SerializeField] bool chg_p_b_inBleedingState;
    [SerializeField] bool chg_p_b_inFrailState;
    [SerializeField] bool chg_p_b_inResistantState;
    [SerializeField] bool chg_p_b_inSpecialAttackState;

    [Header("Special Attack States")]
    [SerializeField] bool chg_p_b_attackedByClurichaun;
    [SerializeField] bool chg_p_b_attackedByPuca;
    [SerializeField] bool chg_p_b_attackedByBodach;
    [SerializeField] bool chg_p_b_attackedByBananach;
    [SerializeField] bool chg_p_b_attackedByTroopFae;

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
        // Update remaining applicable effects
        if (GetPlayerBleedEffectState() == true)
        {
            SetPlayerBleedEffectStackCount(BleedEffectPerTurn(p_i_bleedingStackCount));
        }
        if (GetPlayerFrailtyEffectState() == true) 
        {
            SetPlayerFrailtyEffectStackCount(0);
            // Check Stack Remainder
            UpdatePlayerFrailtyStackRemainder();
        }
        if (GetPlayerResistantEffectState() == true)
        {
            SetPlayerResistantEffectStackCount(0);
            // Check Stack Remainder
            UpdatePlayerResistantStackRemainder();
        }

        // Check if acid state is over
        if (GetPlayerAcidEffectState() == true)
        {
            SetPlayerAcidEffectState(false);
            SetPlayerAcidEffectStackCount(0);
            g_global.g_UIManager.sc_characterGraphics.ToggleAcidPlayerUI(false);
        }

        // Check if bleed state is over
        if (GetPlayerBleedEffectStackCount() <= 0)
        {
            SetPlayerBleedEffectState(false);
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedPlayerUI(false);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedPlayerUI(true);
        }

        // Check if frailty state is over
        if (GetPlayerFrailtyEffectStackCount() <= 0)
        {
            SetPlayerFrailtyEffectState(false);
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyPlayerUI(false);
        }
        else 
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyPlayerUI(true);
        }

        // Check if resistant state is over
        if (GetPlayerResistantEffectStackCount() <= 0)
        {
            SetPlayerBleedEffectState(false);
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantPlayerUI(false);
        }
        else 
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantPlayerUI(true);
        }
    }

    /// <summary>
    /// Function to trigger for Player Acid Status Effect
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    public void PlayerAcidStatusEffect(int _stackCount) /// fafan
    {
        if (GetPlayerAcidEffectState() == false)
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleAcidPlayerUI(true);
            SetPlayerAcidEffectStackCount(_stackCount);
            SetPlayerAcidEffectState(true);
        }

        if (g_global.g_playerAttributeSheet.GetPlayerShieldValue() >= 1)
        {
            int _doubleStack = _stackCount * 2;
            g_global.g_player.PlayerAttacked(_doubleStack);
        }
        else
        {
            g_global.g_player.PlayerAttacked(_stackCount);
        }
    }

    /// <summary>
    /// Function to trigger for Player Bleed Status Effect
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    public void PlayerBleedingStatusEffect(int _stackCount)
    {
        if (GetPlayerBleedEffectState() == false)
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedPlayerUI(true);
            SetPlayerBleedEffectStackCount(_stackCount);
            SetPlayerBleedEffectState(true);
        }
        else
        {
            Debug.Log("Player Bleed Effect already active!");
            SetPlayerBleedEffectStackCount(GetPlayerBleedEffectStackCount() + _stackCount);
        }
    }

    /// <summary>
    /// Function to trigger for Player Frailty Status Effect
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    public void PlayerFrailtyStatusEffect(int _stackCount)
    {
        if (GetPlayerResistantEffectStackCount() == 0)
        {
            int _combinedTotal = GetPlayerFrailtyEffectStackCount() + _stackCount;
            int _remainder = _stackCount - GetPlayerFrailtyEffectStackCount();
            if (_combinedTotal <= 5)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyPlayerUI(true);
                SetPlayerFrailtyEffectState(true);
                SetPlayerFrailtyEffectStackCount(_combinedTotal);
            }
            else
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyPlayerUI(true);
                SetPlayerFrailtyEffectState(true);
                SetPlayerFrailtyEffectStackRemainder(_remainder + GetPlayerFrailtyEffectStackRemainder());
                SetPlayerFrailtyEffectStackCount(5);
            }
        }
        else
        {
            int _totalResistant = GetPlayerResistantEffectStackCount() + GetPlayerResistantEffectStackRemainder() + _stackCount;
            int _totalFrality = GetPlayerFrailtyEffectStackCount() + GetPlayerFrailtyEffectStackRemainder();

            int _option1 = _totalResistant - _totalFrality; // Higher Resistant
            int _option2 = _totalFrality - _totalResistant; // Higher Frality

            if (_option1 > _option2)
            {
                // Set up Resistant
                if (_option1 <= 5)
                {
                    SetPlayerResistantEffectStackCount(_option1);
                }
                else
                {
                    int _remainder = _option1 - 5;
                    SetPlayerResistantEffectStackCount(5);
                    SetPlayerResistantEffectStackRemainder(_remainder + GetPlayerResistantEffectStackRemainder());
                }
                SetPlayerResistantEffectState(true);
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantPlayerUI(true);

                // Turn off Frailty 
                SetPlayerFrailtyEffectStackCount(0);
                SetPlayerFrailtyEffectStackRemainder(0);
                SetPlayerFrailtyEffectState(false);
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyPlayerUI(false);
            }
            else if (_option1 == _option2)
            {
                // Turn off Resistant 
                SetPlayerResistantEffectStackCount(0);
                SetPlayerResistantEffectStackRemainder(0);
                SetPlayerResistantEffectState(false);
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantPlayerUI(false);

                // Turn off Frailty 
                SetPlayerFrailtyEffectStackCount(0);
                SetPlayerFrailtyEffectStackRemainder(0);
                SetPlayerFrailtyEffectState(false);
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyPlayerUI(false);
            }
            else
            {
                // Set up Frality
                if (_option2 <= 5)
                {
                    SetPlayerFrailtyEffectStackCount(_option2);
                }
                else
                {
                    int _remainder = _option2 - 5;
                    SetPlayerFrailtyEffectStackCount(5);
                    SetPlayerFrailtyEffectStackRemainder(_remainder + GetPlayerFrailtyEffectStackRemainder());
                }
                SetPlayerFrailtyEffectState(true);
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyPlayerUI(true);

                // Turn off Resistant 
                SetPlayerResistantEffectStackCount(0);
                SetPlayerResistantEffectStackRemainder(0);
                SetPlayerResistantEffectState(false);
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantPlayerUI(false);
            }
        }
    }

    /// <summary>
    /// Function to trigger for Player Resistant Status Effect
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    public void PlayerResistantEffect(int _stackCount)
    {
        if (GetPlayerFrailtyEffectStackCount() == 0)
        {
            int _combinedTotal = GetPlayerResistantEffectStackCount() + _stackCount;
            int _remainder = _stackCount - GetPlayerResistantEffectStackCount();
            if (_combinedTotal <= 5)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantPlayerUI(true);
                SetPlayerResistantEffectState(true);
                SetPlayerResistantEffectStackCount(_combinedTotal);
            }
            else
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantPlayerUI(true);
                SetPlayerResistantEffectState(true);
                SetPlayerResistantEffectStackRemainder(_remainder + GetPlayerResistantEffectStackRemainder());
                SetPlayerResistantEffectStackCount(5);
            }
        }
        else
        {
            int _totalResistant = GetPlayerResistantEffectStackCount() + GetPlayerResistantEffectStackRemainder() + _stackCount;
            int _totalFrality = GetPlayerFrailtyEffectStackCount() + GetPlayerFrailtyEffectStackRemainder();

            int _option1 = _totalResistant - _totalFrality; // Higher Resistant
            int _option2 = _totalFrality - _totalResistant; // Higher Frality

            if (_option1 > _option2)
            {
                // Set up Resistant
                if (_option1 <= 5)
                {
                    SetPlayerResistantEffectStackCount(_option1);
                }
                else
                {
                    int _remainder = _option1 - 5;
                    SetPlayerResistantEffectStackCount(5);
                    SetPlayerResistantEffectStackRemainder(_remainder + GetPlayerResistantEffectStackRemainder());
                }
                SetPlayerResistantEffectState(true);
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantPlayerUI(true);

                // Turn off Frailty 
                SetPlayerFrailtyEffectStackCount(0);
                SetPlayerFrailtyEffectStackRemainder(0);
                SetPlayerFrailtyEffectState(false);
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyPlayerUI(false);
            }
            else if (_option1 == _option2)
            {
                // Turn off Resistant 
                SetPlayerResistantEffectStackCount(0);
                SetPlayerResistantEffectStackRemainder(0);
                SetPlayerResistantEffectState(false);
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantPlayerUI(false);

                // Turn off Frailty 
                SetPlayerFrailtyEffectStackCount(0);
                SetPlayerFrailtyEffectStackRemainder(0);
                SetPlayerFrailtyEffectState(false);
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyPlayerUI(false);
            }
            else
            {
                // Set up Frality
                if (_option2 <= 5)
                {
                    SetPlayerFrailtyEffectStackCount(_option2);
                }
                else
                {
                    int _remainder = _option2 - 5;
                    SetPlayerFrailtyEffectStackCount(5);
                    SetPlayerFrailtyEffectStackRemainder(_remainder + GetPlayerFrailtyEffectStackRemainder());
                }
                SetPlayerFrailtyEffectState(true);
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyPlayerUI(true);

                // Turn off Resistant 
                SetPlayerResistantEffectStackCount(0);
                SetPlayerResistantEffectStackRemainder(0);
                SetPlayerResistantEffectState(false);
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantPlayerUI(false);
            }
        }
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
            //Debug.Log("Player health " + g_global.g_gameManager.i_playerHealth);

            //go to the new scene
            if (g_global.g_sceneManager.b_toEventScene)
            {
                g_global.g_sceneManager.ToEventScene();
            }
            else
            {
                g_global.g_sceneManager.DisplayRewards();
            }
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

    /// <summary>
    /// Helper function of a helper function, used to calculate new bleed damage effect
    /// - Josh
    /// </summary>
    /// <param name="_currentDamage"></param>
    /// <returns>
    /// _bleedingCalc (int)
    /// </returns>
    private int BleedEffectCalculator(int _currentDamage)
    {
        float _seperateCalc = _currentDamage * 0.5f;
        int _bleedingCalc = Mathf.FloorToInt(_seperateCalc);
        return _bleedingCalc;
    }

    /// <summary>
    /// Helper to trigger bleed after intial function
    /// - Josh
    /// </summary>
    /// <param name="_currentDamage"></param>
    private int BleedEffectPerTurn(int _currentDamage)
    {
        int _bleedingDamageForTurn = BleedEffectCalculator(_currentDamage);
        g_global.g_player.PlayerAttacked(_bleedingDamageForTurn);
        return _bleedingDamageForTurn;
    }

    /// <summary>
    /// Helper function for updating the frailty stack remainder
    /// - Josh
    /// </summary>
    private void UpdatePlayerFrailtyStackRemainder()
    {
        if (GetPlayerFrailtyEffectStackCount() == 0 && GetPlayerFrailtyEffectStackRemainder() >= 1)
        {
            if (GetPlayerFrailtyEffectStackRemainder() <= 5)
            {
                SetPlayerFrailtyEffectStackCount(GetPlayerFrailtyEffectStackRemainder());
                SetPlayerFrailtyEffectStackRemainder(0);
            }
            else
            {
                int _remainder = GetPlayerFrailtyEffectStackRemainder() - 5;
                SetPlayerFrailtyEffectStackCount(5);
                SetPlayerFrailtyEffectStackRemainder(_remainder);
            }
        }
    }

    /// <summary>
    /// Helper function for updating the resistant stack remainder
    /// - Josh
    /// </summary>
    private void UpdatePlayerResistantStackRemainder()
    {
        if (GetPlayerResistantEffectStackCount() == 0 && GetPlayerResistantEffectStackRemainder() >= 1)
        {
            if (GetPlayerResistantEffectStackRemainder() <= 5)
            {
                SetPlayerResistantEffectStackCount(GetPlayerResistantEffectStackRemainder());
                SetPlayerResistantEffectStackRemainder(0);
            }
            else
            {
                int _remainder = GetPlayerFrailtyEffectStackRemainder() - 5;
                SetPlayerResistantEffectStackCount(5);
                SetPlayerResistantEffectStackRemainder(_remainder);
            }
        }
    }

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
    /// Set the int value of S_PlayerState.p_i_acidicStackCount
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    public void SetPlayerAcidEffectStackCount(int _stackCount)
    {
        p_i_acidicStackCount = _stackCount;
    }

    /// <summary>
    /// Set the int value of S_PlayerState.p_i_bleedingStackCount
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    public void SetPlayerBleedEffectStackCount(int _stackCount)
    {
        p_i_bleedingStackCount = _stackCount;
    }

    /// <summary>
    /// Set the int value of S_PlayerState.p_i_frailtyStackCount
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    public void SetPlayerFrailtyEffectStackCount(int _stackCount)
    {
        p_i_frailtyStackCount = _stackCount;
    }

    /// <summary>
    /// Set the int value of S_PlayerState.p_i_resistantStackCount
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
    public void SetPlayerAcidEffectState(bool _state)
    {
        chg_p_b_inAcidicState = _state;
    }

    /// <summary>
    /// Set the bool state of S_PlayerState.p_b_inBleedingState
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    public void SetPlayerBleedEffectState(bool _state)
    {
        chg_p_b_inBleedingState = _state;
    }

    /// <summary>
    /// Set the bool state of S_PlayerState.p_b_inFrailState
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    public void SetPlayerFrailtyEffectState(bool _state)
    {
        chg_p_b_inFrailState = _state;
    }

    /// <summary>
    /// Set the bool state of S_PlayerState.p_b_inResistantState
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    public void SetPlayerResistantEffectState(bool _state)
    {
        chg_p_b_inResistantState = _state;
    }

    /// <summary>
    /// Set the int value of S_PlayerState.p_i_playerFrailtyStackRemainder
    /// - Josh
    /// </summary>
    /// <param name="_stackRemainder"></param>
    public void SetPlayerFrailtyEffectStackRemainder(int _stackRemainder)
    {
        p_i_playerFrailtyStackRemainder = _stackRemainder;
    }

    /// <summary>
    /// Set the int value of S_PlayerState.p_i_playerResistantStackRemainder
    /// - Josh
    /// </summary>
    /// <param name="_stackRemainder"></param>
    public void SetPlayerResistantEffectStackRemainder(int _stackRemainder)
    {
        p_i_playerResistantStackRemainder = _stackRemainder;
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
    public int GetPlayerAcidEffectStackCount()
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
    public bool GetPlayerAcidEffectState()
    {
        return chg_p_b_inAcidicState;
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
        return chg_p_b_inBleedingState;
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
        return chg_p_b_inFrailState;
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
        return chg_p_b_inResistantState;
    }

    /// <summary>
    /// Return the bool state of S_PlayerState.chg_p_b_inSpecialAttackState
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerState.chg_p_b_inSpecialAttackState
    /// </returns>
    public bool GetPlayerSpecialAttackEffectState()
    {
        return chg_p_b_inSpecialAttackState;
    }

    /// <summary>
    /// Return the int value of S_PlayerState.p_i_playerFrailtyStackRemainder
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerState.p_i_playerFrailtyStackRemainder
    /// </returns>
    public int GetPlayerFrailtyEffectStackRemainder()
    {
        return p_i_playerFrailtyStackRemainder;
    }

    /// <summary>
    /// Return the int value of S_PlayerState.p_i_playerResistantStackRemainder
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerState.p_i_playerResistantStackRemainder
    /// </returns>
    public int GetPlayerResistantEffectStackRemainder()
    {
        return p_i_playerResistantStackRemainder;
    }
}
