using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class S_HealthBarStatusEffects : MonoBehaviour
{
    private S_Global g_global;

    [Header("Health Bar Status Effects")]
    [SerializeField] GameObject chg_UI_acidicStatusEffect;
    [SerializeField] GameObject chg_UI_bleedingStatusEffect;
    [SerializeField] GameObject chg_UI_resistantStatusEffect;
    [SerializeField] GameObject chg_UI_stunnedStatusEffect;

    [Header("Position GameObjects")]
    [SerializeField] GameObject chg_statusEffectPosition1;
    [SerializeField] GameObject chg_statusEffectPosition2;
    [SerializeField] GameObject chg_statusEffectPosition3;
    [SerializeField] GameObject chg_statusEffectPosition4;
    [SerializeField] GameObject chg_statusEffectSpawn;

    [Header("Child Status Effects")]
    [SerializeField] GameObject chg_statusEffectPosition1Child;
    [SerializeField] GameObject chg_statusEffectPosition2Child;
    [SerializeField] GameObject chg_statusEffectPosition3Child;
    [SerializeField] GameObject chg_statusEffectPosition4Child;

    [Header("Position Identifer Strings")]
    [SerializeField] string chg_str_position1Identifier;
    [SerializeField] string chg_str_position2Identifier;
    [SerializeField] string chg_str_position3Identifier;
    [SerializeField] string chg_str_position4Identifier;

    [Header("Status Effect Tooltips")]
    [SerializeField] S_TooltipTemplate chg_tl_acidicStatusEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_bleedingStatusEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_resistantStatusEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_stunnedStatusEffectTooltip;

    [Header("Occupied Slot Count")]
    [SerializeField] int chg_i_slotsOccupied;

    [Header("Float Values")]
    [SerializeField] float chg_f_spawnMoveValue;
    [SerializeField] float chg_f_endMoveValue;

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    public void CheckPositions()
    {
        if (chg_str_position1Identifier.Equals("none"))
        {
            if (!chg_str_position2Identifier.Equals("none"))
            {

            }
            else if (!chg_str_position3Identifier.Equals("none"))
            {

            }
            else if (!chg_str_position4Identifier.Equals("none"))
            {

            }
        }
    }

    public void MovePositions()
    {

    }


    /// <summary>
    /// End the given status effect visual,
    /// using int for clarity
    /// - Josh
    /// </summary>
    public void EndStatusEffect(int _positionNum)
    {
        if(_positionNum == 1)
        {
            chg_statusEffectPosition1Child.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);
        }
        else if(_positionNum == 2)
        {
            chg_statusEffectPosition2Child.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);
        }
        else if (_positionNum == 3)
        {
            chg_statusEffectPosition3Child.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);
        }
        else if (_positionNum == 4)
        {
            chg_statusEffectPosition4Child.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);
        }
    }

    /// <summary>
    /// Set the position for a given Status Effect
    /// </summary>
    /// <param name="_image"></param>
    public void AddStatusEffect(string _effect)
    {
        if (_effect.Equals("acid"))
        {
            if (chg_i_slotsOccupied == 0)
            {
                chg_UI_acidicStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);
                chg_statusEffectPosition1Child = chg_UI_acidicStatusEffect;
                chg_str_position1Identifier = "acid";
            }
            else if (chg_i_slotsOccupied == 1)
            {
                chg_UI_acidicStatusEffect.transform.SetParent(chg_statusEffectPosition2.transform, true);
                chg_statusEffectPosition2Child = chg_UI_acidicStatusEffect;
                chg_str_position2Identifier = "acid";
            }
            else if (chg_i_slotsOccupied == 2)
            {
                chg_UI_acidicStatusEffect.transform.SetParent(chg_statusEffectPosition3.transform, true);
                chg_statusEffectPosition3Child = chg_UI_acidicStatusEffect;
                chg_str_position3Identifier = "acid";
            }
            else if (chg_i_slotsOccupied == 3)
            {
                chg_UI_acidicStatusEffect.transform.SetParent(chg_statusEffectPosition4.transform, true);
                chg_statusEffectPosition4Child = chg_UI_acidicStatusEffect;
                chg_str_position4Identifier = "acid";
            }
        }
        else if (_effect.Equals("bleed"))
        {
            if (chg_i_slotsOccupied == 0)
            {
                chg_UI_bleedingStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);
                chg_statusEffectPosition1Child = chg_UI_bleedingStatusEffect;
                chg_str_position1Identifier = "bleed";
            }
            else if (chg_i_slotsOccupied == 1)
            {
                chg_UI_bleedingStatusEffect.transform.SetParent(chg_statusEffectPosition2.transform, true);
                chg_statusEffectPosition2Child = chg_UI_bleedingStatusEffect;
                chg_str_position2Identifier = "bleed";
            }
            else if (chg_i_slotsOccupied == 2)
            {
                chg_UI_bleedingStatusEffect.transform.SetParent(chg_statusEffectPosition3.transform, true);
                chg_statusEffectPosition3Child = chg_UI_bleedingStatusEffect;
                chg_str_position3Identifier = "bleed";
            }
            else if (chg_i_slotsOccupied == 3)
            {
                chg_UI_bleedingStatusEffect.transform.SetParent(chg_statusEffectPosition4.transform, true);
                chg_statusEffectPosition4Child = chg_UI_bleedingStatusEffect;
                chg_str_position4Identifier = "bleed";
            }
        }
        else if (_effect.Equals("resist"))
        {
            if (chg_i_slotsOccupied == 0)
            {
                chg_UI_resistantStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);
                chg_statusEffectPosition1Child = chg_UI_resistantStatusEffect;
                chg_str_position1Identifier = "resist";
            }
            else if (chg_i_slotsOccupied == 1)
            {
                chg_UI_resistantStatusEffect.transform.SetParent(chg_statusEffectPosition2.transform, true);
                chg_statusEffectPosition2Child = chg_UI_resistantStatusEffect;
                chg_str_position2Identifier = "resist";
            }
            else if (chg_i_slotsOccupied == 2)
            {
                chg_UI_resistantStatusEffect.transform.SetParent(chg_statusEffectPosition3.transform, true);
                chg_statusEffectPosition3Child = chg_UI_resistantStatusEffect;
                chg_str_position3Identifier = "resist";
            }
            else if (chg_i_slotsOccupied == 3)
            {
                chg_UI_resistantStatusEffect.transform.SetParent(chg_statusEffectPosition4.transform, true);
                chg_statusEffectPosition4Child = chg_UI_resistantStatusEffect;
                chg_str_position4Identifier = "resist";
            }
        }
        else if (_effect.Equals("stun"))
        {
            if (chg_i_slotsOccupied == 0)
            {
                chg_UI_stunnedStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);
                chg_statusEffectPosition1Child = chg_UI_stunnedStatusEffect;
                chg_str_position1Identifier = "stun";
            }
            else if (chg_i_slotsOccupied == 1)
            {
                chg_UI_stunnedStatusEffect.transform.SetParent(chg_statusEffectPosition2.transform, true);
                chg_statusEffectPosition2Child = chg_UI_stunnedStatusEffect;
                chg_str_position2Identifier = "stun";
            }
            else if (chg_i_slotsOccupied == 2)
            {
                chg_UI_stunnedStatusEffect.transform.SetParent(chg_statusEffectPosition3.transform, true);
                chg_statusEffectPosition3Child = chg_UI_stunnedStatusEffect;
                chg_str_position3Identifier = "stun";
            }
            else if (chg_i_slotsOccupied == 3)
            {
                chg_UI_stunnedStatusEffect.transform.SetParent(chg_statusEffectPosition4.transform, true);
                chg_statusEffectPosition4Child = chg_UI_stunnedStatusEffect;
                chg_str_position4Identifier = "stun";
            }
        }

    }
}
