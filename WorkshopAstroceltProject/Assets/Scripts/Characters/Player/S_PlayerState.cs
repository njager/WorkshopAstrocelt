using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerState : MonoBehaviour
{
    private S_Global g_global;

    public int p_i_bleedingTurnCount;
    public int p_i_stunnedTurnCount;
    public int p_i_poisonedTurnCount;

    public bool p_b_inBleedingState;
    public bool p_b_inStunnedState;
    public bool p_b_inPoisonedState;

    void Start()
    {
        g_global = S_Global.g_instance;
    }

    public void BleedingStatusEffectForTurn()
    {
       
    }

    public void StunnedStatusEffectForTurn()
    {

    }

    public void PoisonedStatusEffectForTurn()
    {

    }

}
