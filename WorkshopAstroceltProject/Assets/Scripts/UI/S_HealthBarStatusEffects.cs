using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [Header("Active Effects List")]
    [SerializeField] List<string> chg_ls_activeEffectsList = new List<string>();

    [Header("Float Values")]
    [SerializeField] float chg_f_spawnMoveValue;
    [SerializeField] float chg_f_fadeDurationValue;
    [SerializeField] float chg_f_endMoveValue;

    private void Awake()
    {
        g_global = S_Global.Instance;
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
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_acidicStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);

                // Move Child
                chg_UI_acidicStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_acidicStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition1Child = chg_UI_acidicStatusEffect;

                // Set identifier
                chg_str_position1Identifier = "acid";

                // Add effect to the list
                chg_ls_activeEffectsList.Add(chg_UI_acidicStatusEffect);
                
            }
            else if (chg_i_slotsOccupied == 1)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_acidicStatusEffect.transform.SetParent(chg_statusEffectPosition2.transform, true);

                // Move Child
                chg_UI_acidicStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_acidicStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition2Child = chg_UI_acidicStatusEffect;

                // Set identifier
                chg_str_position2Identifier = "acid";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("acid");
            }
            else if (chg_i_slotsOccupied == 2)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_acidicStatusEffect.transform.SetParent(chg_statusEffectPosition3.transform, true);

                // Move Child
                chg_UI_acidicStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_acidicStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition3Child = chg_UI_acidicStatusEffect;

                // Set identifier
                chg_str_position3Identifier = "acid";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("acid");
            }
            else if (chg_i_slotsOccupied == 3)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_acidicStatusEffect.transform.SetParent(chg_statusEffectPosition4.transform, true);

                // Move Child
                chg_UI_acidicStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_acidicStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition4Child = chg_UI_acidicStatusEffect;

                // Set identifier
                chg_str_position4Identifier = "acid";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("acid");
            }
        }
        else if (_effect.Equals("bleed"))
        {
            if (chg_i_slotsOccupied == 0)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_bleedingStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);

                // Move Child
                chg_UI_bleedingStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_bleedingStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition1Child = chg_UI_bleedingStatusEffect;

                // Set identifier
                chg_str_position1Identifier = "bleed";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("bleed");
            }
            else if (chg_i_slotsOccupied == 1)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_bleedingStatusEffect.transform.SetParent(chg_statusEffectPosition2.transform, true);

                // Move Child
                chg_UI_bleedingStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_bleedingStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition2Child = chg_UI_bleedingStatusEffect;

                // Set identifier
                chg_str_position2Identifier = "bleed";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("bleed");
            }
            else if (chg_i_slotsOccupied == 2)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_bleedingStatusEffect.transform.SetParent(chg_statusEffectPosition3.transform, true);

                // Move Child
                chg_UI_bleedingStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_bleedingStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition3Child = chg_UI_bleedingStatusEffect;

                // Set identifier
                chg_str_position3Identifier = "bleed";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("bleed");
            }
            else if (chg_i_slotsOccupied == 3)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_bleedingStatusEffect.transform.SetParent(chg_statusEffectPosition4.transform, true);

                // Move Child
                chg_UI_bleedingStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_bleedingStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition4Child = chg_UI_bleedingStatusEffect;

                // Set identifier
                chg_str_position4Identifier = "bleed";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("bleed";
            }
        }
        else if (_effect.Equals("resist"))
        {
            if (chg_i_slotsOccupied == 0)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_resistantStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);

                // Move Child
                chg_UI_resistantStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_resistantStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition1Child = chg_UI_resistantStatusEffect;

                // Set identifier
                chg_str_position1Identifier = "resist";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("resist");
            }
            else if (chg_i_slotsOccupied == 1)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_resistantStatusEffect.transform.SetParent(chg_statusEffectPosition2.transform, true);

                // Move Child
                chg_UI_resistantStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_resistantStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition2Child = chg_UI_resistantStatusEffect;

                // Set identifier
                chg_str_position2Identifier = "resist";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("resist");
            }
            else if (chg_i_slotsOccupied == 2)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_resistantStatusEffect.transform.SetParent(chg_statusEffectPosition3.transform, true);

                // Move Child
                chg_UI_resistantStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_resistantStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition3Child = chg_UI_resistantStatusEffect;

                // Set identifier
                chg_str_position3Identifier = "resist";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("resist");
            }
            else if (chg_i_slotsOccupied == 3)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_resistantStatusEffect.transform.SetParent(chg_statusEffectPosition4.transform, true);

                // Move Child
                chg_UI_resistantStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_resistantStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition4Child = chg_UI_resistantStatusEffect;

                // Set identifier
                chg_str_position4Identifier = "resist";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("resist");
            }
        }
        else if (_effect.Equals("stun"))
        {
            if (chg_i_slotsOccupied == 0)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_stunnedStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);

                // Move Child
                chg_UI_stunnedStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_stunnedStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition1Child = chg_UI_stunnedStatusEffect;

                // Set identifier
                chg_str_position1Identifier = "stun";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("stun");
            }
            else if (chg_i_slotsOccupied == 1)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_stunnedStatusEffect.transform.SetParent(chg_statusEffectPosition2.transform, true);

                // Move Child
                chg_UI_stunnedStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_stunnedStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition2Child = chg_UI_stunnedStatusEffect;

                // Set identifier
                chg_str_position2Identifier = "stun";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("stun");
            }
            else if (chg_i_slotsOccupied == 2)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_stunnedStatusEffect.transform.SetParent(chg_statusEffectPosition3.transform, true);

                // Move Child
                chg_UI_stunnedStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_stunnedStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition3Child = chg_UI_stunnedStatusEffect;

                // Set identifier
                chg_str_position3Identifier = "stun";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("stun");
            }
            else if (chg_i_slotsOccupied == 3)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_stunnedStatusEffect.transform.SetParent(chg_statusEffectPosition4.transform, true);

                // Move Child
                chg_UI_stunnedStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_stunnedStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition4Child = chg_UI_stunnedStatusEffect;

                // Set identifier
                chg_str_position4Identifier = "stun";

                // Add effect to the list
                chg_ls_activeEffectsList.Add("stun");
            }
        }
    }

    /// <summary>
    /// End the given status effect visual,
    /// using int for clarity
    /// - Josh
    /// </summary>
    public void EndStatusEffect(int _positionNum)
    {
        if (_positionNum == 1)
        {
            // Adjust slot count
            chg_i_slotsOccupied -= 1;

            // Grab Child
            GameObject _child = chg_statusEffectPosition1Child;

            // Move Child
            _child.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);

            // Fade Child
            _child.GetComponent<Image>().DOFade(0, chg_f_fadeDurationValue);

            // Reset Identifer
            chg_str_position1Identifier = "none";

            // Set New parent
            _child.transform.SetParent(chg_statusEffectSpawn.transform);

            // Clear Child
            chg_statusEffectPosition1Child = null;

            // Remove effect to the list
            //chg_ls_activeEffectsList.Remove();
        }
        else if (_positionNum == 2)
        {
            // Adjust slot count
            chg_i_slotsOccupied -= 1;

            // Grab Child
            GameObject _child = chg_statusEffectPosition2Child;

            // Move Child
            _child.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);

            // Fade Child
            _child.GetComponent<Image>().DOFade(0, chg_f_fadeDurationValue);

            // Reset Identifer
            chg_str_position2Identifier = "none";

            // Set New parent
            _child.transform.SetParent(chg_statusEffectSpawn.transform);

            // Clear Child
            chg_statusEffectPosition2Child = null;

            // Remove effect to the list
            //chg_ls_activeEffectsList.Remove(_child);
        }
        else if (_positionNum == 3)
        {
            // Adjust slot count
            chg_i_slotsOccupied -= 1;

            // Grab Child
            GameObject _child = chg_statusEffectPosition3Child;

            // Move Child
            _child.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);

            // Fade Child
            _child.GetComponent<Image>().DOFade(0, chg_f_fadeDurationValue);

            // Reset Identifer
            chg_str_position3Identifier = "none";

            // Set New parent
            _child.transform.SetParent(chg_statusEffectSpawn.transform);

            // Clear Child
            chg_statusEffectPosition3Child = null;

            // Remove effect to the list
            //chg_ls_activeEffectsList.Remove(_child);
        }
        else if (_positionNum == 4)
        {
            // Adjust slot count
            chg_i_slotsOccupied -= 1;

            // Grab Child
            GameObject _child = chg_statusEffectPosition4Child;

            // Move Child
            _child.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);

            // Fade Child
            _child.GetComponent<Image>().DOFade(0, chg_f_fadeDurationValue);

            // Reset Identifer
            chg_str_position4Identifier = "none";

            // Set New parent
            _child.transform.SetParent(chg_statusEffectSpawn.transform);

            // Clear Child
            chg_statusEffectPosition4Child = null;

            // Remove effect to the list
            //chg_ls_activeEffectsList.Remove(_child);
        }
    }

    /// <summary>
    /// Move the status effects after they've ended
    /// </summary>
    public void MovePositions()
    {

    }

    /// <summary>
    /// Helper function to sort the list according to duration
    /// - Josh
    /// </summary>
    public void SortList()
    {
        if(chg_ls_activeEffectsList.Count == 4)
        {
            //GameObject slot1 = chg_ls_activeEffectsList.Get
        }
        else if (chg_ls_activeEffectsList.Count == 3)
        {

        }
        else if (chg_ls_activeEffectsList.Count == 2)
        {

        }
        else if (chg_ls_activeEffectsList.Count == 1)
        {

        }
    }
}
