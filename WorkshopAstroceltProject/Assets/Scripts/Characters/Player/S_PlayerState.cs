using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerState : MonoBehaviour
{
    private S_Global g_global;

    //Multiple Status Effects could be active at once
    [Header("Status Effect Turn Counts")]
    public int p_i_bleedingTurnCount;
    public int p_i_stunnedTurnCount;
    public int p_i_poisonedTurnCount;

    [Header("Status Effect Values")]
    public float bleedingDamageRate;
    public int stunnedDamageValue;

    [Header("Status Effect States")]
    public bool p_b_inBleedingState;
    public bool p_b_inStunnedState;
    public bool p_b_inPoisonedState;

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

    public void BleedingStatusEffectForTurn(float _damageRate)
    {
        int _bleedingDamageForTurn = BleedingEffectCalculator(_damageRate);
        if (p_i_bleedingTurnCount <= 1)
        {
            g_global.g_player.PlayerAttacked(_bleedingDamageForTurn);
        }
        else
        {
            Debug.Log("Effect not active!");
            // Maybe return a bool here for a turn manager check?

            //Was this riley? 
        }
    }

    public void StunnedStatusEffectForTurn(int _stunnedDamageValue)
    {
        if (p_i_stunnedTurnCount <= 1)
        {
            g_global.g_player.PlayerAttacked(_stunnedDamageValue);
        }
        else
        {
            Debug.Log("Effect not active!");
            // Maybe return a bool here for a turn manager check?
        }
    }

    public void PoisonedStatusEffectForTurn(int _poisonedDamageValue)
    {
        if (p_i_stunnedTurnCount <= 1)
        {
            g_global.g_player.PlayerAttacked(_poisonedDamageValue);
        }
        else
        {
            Debug.Log("Effect not active!");
            // Maybe return a bool here for a turn manager check?
        }
    }

    public int BleedingEffectCalculator(float _damageRate)
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

        // Pause The game
        Time.timeScale = 0f;
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

        // Pause The game
        Time.timeScale = 0f;
    }

}
