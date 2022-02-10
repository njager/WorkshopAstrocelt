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
        if(g_global.g_playerAttributeSheet.p_i_health < g_global.g_playerAttributeSheet.p_i_healthMax)
        {
            g_global.g_playerAttributeSheet.p_i_health = g_global.g_playerAttributeSheet.p_i_healthMax;
        }

        if (g_global.g_playerAttributeSheet.p_i_shield < g_global.g_playerAttributeSheet.p_i_shieldMax)
        {
            g_global.g_playerAttributeSheet.p_i_shield = g_global.g_playerAttributeSheet.p_i_shieldMax;
        }

        // If player lost
        if (g_global.g_playerAttributeSheet.p_i_health <= 0)
        {
            Lose();
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

    public void Lose()
    {
        // If player loses, trigger behavior
    }

}
