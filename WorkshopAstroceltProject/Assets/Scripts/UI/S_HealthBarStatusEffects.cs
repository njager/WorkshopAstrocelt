using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class S_HealthBarStatusEffects : MonoBehaviour
{
    private S_Global g_global;

    [Header("Health Bar Status Effects")]
    [SerializeField] Image chg_UI_statusEffectPosition1;
    [SerializeField] Image chg_UI_statusEffectPosition2;
    [SerializeField] Image chg_UI_statusEffectPosition3;
    [SerializeField] Image chg_UI_statusEffectPosition4;

    [Header("Position Gameobjects")]
    [SerializeField] GameObject chg_statusEffectPosition1;
    [SerializeField] GameObject chg_statusEffectPosition2;
    [SerializeField] GameObject chg_statusEffectPosition3;
    [SerializeField] GameObject chg_statusEffectPosition4;

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
    public void EndEffect(int _positionNum)
    {
        if(_positionNum == 1)
        {

        }
    }
}
