using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerState : MonoBehaviour
{
    private S_Global g_global;

    [Header("Status Effect Turn Counts")]
    public int p_i_bleedingTurnCount;
    public int p_i_stunnedTurnCount;
    public int p_i_poisonedTurnCount;

    [Header("Stats")]

    [Header("Status Effect States")]
    public bool p_b_inBleedingState;
    public bool p_b_inStunnedState;
    public bool p_b_inPoisonedState;

    void Start()
    {
        g_global = S_Global.g_instance;
    }

    void Update()
    {
        
    }

    public void BleedingStatusEffectForTurn()
    {
        if (p_i_bleedingTurnCount <= 1)
        {
            g_global.g_player.PlayerAttacked()
        }
    }

    public void StunnedStatusEffectForTurn()
    {

    }

    public void PoisonedStatusEffectForTurn()
    {

    }

}
