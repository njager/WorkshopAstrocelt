using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class S_HealthBarStatusEffects : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    
    [Header("Global sdcript Connections")]
    [SerializeField] S_Global g_global;

    [Header("Health Bar Type")]
    [SerializeField] bool chg_p_b_playerHealthBar;
    [SerializeField] bool chg_e_b_enemy1HealthBar;
    [SerializeField] bool chg_e_b_enemy2HealthBar;
    [SerializeField] bool chg_e_b_enemy3HealthBar;
    [SerializeField] bool chg_e_b_enemy4HealthBar;
    [SerializeField] bool chg_e_b_enemy5HealthBar;

    [Header("Health Bar Status Effects")]
    [SerializeField] GameObject chg_UI_acidicStatusEffect;
    [SerializeField] GameObject chg_UI_bleedingStatusEffect;
    [SerializeField] GameObject chg_UI_frailtyStatusEffect;
    [SerializeField] GameObject chg_UI_resistantStatusEffect;
    [SerializeField] GameObject chg_UI_stunnedStatusEffect;

    [Header("Position GameObjects")]
    [SerializeField] GameObject chg_statusEffectPosition1;
    [SerializeField] GameObject chg_statusEffectPosition2;
    [SerializeField] GameObject chg_statusEffectPosition3;
    [SerializeField] GameObject chg_statusEffectPosition4;
    [SerializeField] GameObject chg_statusEffectPosition5;
    [SerializeField] GameObject chg_statusEffectSpawn;

    [Header("Child Status Effects")]
    [SerializeField] GameObject chg_statusEffectPosition1Child;
    [SerializeField] GameObject chg_statusEffectPosition2Child;
    [SerializeField] GameObject chg_statusEffectPosition3Child;
    [SerializeField] GameObject chg_statusEffectPosition4Child;
    [SerializeField] GameObject chg_statusEffectPosition5Child;

    [Header("Position Identifer Strings")]
    [SerializeField] string chg_str_position1Identifier;
    [SerializeField] string chg_str_position2Identifier;
    [SerializeField] string chg_str_position3Identifier;
    [SerializeField] string chg_str_position4Identifier;
    [SerializeField] string chg_str_position5Identifier;

    [Header("Status Effect Tooltips")]
    [SerializeField] S_TooltipTemplate chg_tl_acidicStatusEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_bleedingStatusEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_frailtyStatusEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_resistantStatusEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_stunnedStatusEffectTooltip;

    [Header("Occupied Slot Count")]
    [SerializeField] int chg_i_slotsOccupied;

    [Header("Active Effects List")]
    [Tooltip("String is effect type, int is duration")]
    [SerializeField] List<(string, int, int)> chg_ls_activeEffectsList = new List<(string _effectType, int _effectStackCount, int _healthBarOwner)>();

    [Header("Status Effect List Indices")] // Default to -1 when not in list
    [SerializeField] int chg_i_acidEffectListIndex;
    [SerializeField] int chg_i_bleedEffectListIndex;
    [SerializeField] int chg_i_frailtyEffectListIndex;
    [SerializeField] int chg_i_resistantEffectListIndex;
    [SerializeField] int chg_i_stunEffectListIndex;

    [Header("Float Values")]
    [SerializeField] float chg_f_spawnMoveValue;
    [SerializeField] float chg_f_fadeDurationValue;
    [SerializeField] float chg_f_endMoveValue;

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    /////////////////////////////----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Public Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the position for a given Status Effect
    /// - Josh
    /// </summary>
    /// <param name="_effect"></param>
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

                // Add effect to the list, tupled with duration
                chg_ls_activeEffectsList.Add((chg_str_position1Identifier, GetEffectStackCount(chg_str_position1Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position2Identifier, GetEffectStackCount(chg_str_position2Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position3Identifier, GetEffectStackCount(chg_str_position3Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position4Identifier, GetEffectStackCount(chg_str_position4Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position1Identifier, GetEffectStackCount(chg_str_position1Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position2Identifier, GetEffectStackCount(chg_str_position2Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position3Identifier, GetEffectStackCount(chg_str_position3Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position4Identifier, GetEffectStackCount(chg_str_position4Identifier), GetHealthBarOwner()));
            }
        }
        else if (_effect.Equals("frail"))
        {
            if (chg_i_slotsOccupied == 0)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_frailtyStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);

                // Move Child
                chg_UI_frailtyStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_frailtyStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition1Child = chg_UI_frailtyStatusEffect;

                // Set identifier
                chg_str_position1Identifier = "frail";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position1Identifier, GetEffectStackCount(chg_str_position1Identifier), GetHealthBarOwner()));
            }
            else if (chg_i_slotsOccupied == 1)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_frailtyStatusEffect.transform.SetParent(chg_statusEffectPosition2.transform, true);

                // Move Child
                chg_UI_frailtyStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_frailtyStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition2Child = chg_UI_frailtyStatusEffect;

                // Set identifier
                chg_str_position2Identifier = "frail";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position2Identifier, GetEffectStackCount(chg_str_position2Identifier), GetHealthBarOwner()));
            }
            else if (chg_i_slotsOccupied == 2)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_frailtyStatusEffect.transform.SetParent(chg_statusEffectPosition3.transform, true);

                // Move Child
                chg_UI_frailtyStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_frailtyStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition3Child = chg_UI_frailtyStatusEffect;

                // Set identifier
                chg_str_position3Identifier = "frail";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position3Identifier, GetEffectStackCount(chg_str_position3Identifier), GetHealthBarOwner()));
            }
            else if (chg_i_slotsOccupied == 3)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_frailtyStatusEffect.transform.SetParent(chg_statusEffectPosition4.transform, true);

                // Move Child
                chg_UI_frailtyStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_frailtyStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition4Child = chg_UI_frailtyStatusEffect;

                // Set identifier
                chg_str_position4Identifier = "frail";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position4Identifier, GetEffectStackCount(chg_str_position4Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position1Identifier, GetEffectStackCount(chg_str_position1Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position2Identifier, GetEffectStackCount(chg_str_position2Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position3Identifier, GetEffectStackCount(chg_str_position3Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position4Identifier, GetEffectStackCount(chg_str_position4Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position1Identifier, GetEffectStackCount(chg_str_position1Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position2Identifier, GetEffectStackCount(chg_str_position2Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position3Identifier, GetEffectStackCount(chg_str_position3Identifier), GetHealthBarOwner()));
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
                chg_ls_activeEffectsList.Add((chg_str_position4Identifier, GetEffectStackCount(chg_str_position4Identifier), GetHealthBarOwner()));
            }
        }
    }

    /// <summary>
    /// End the given status effect visual,
    /// using int for clarity
    /// - Josh
    /// </summary>
    public void EndStatusEffect(string _effect)
    {
        int _positionNum = GetIndexFromEffect(_effect);
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

            // Set New parent
            _child.transform.SetParent(chg_statusEffectSpawn.transform);

            // Clear Child
            chg_statusEffectPosition1Child = null;

            // Remove effect from the list
            RemoveEffectFromList(chg_str_position1Identifier);

            // Reset Identifer
            chg_str_position1Identifier = "none";
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

            // Set New parent
            _child.transform.SetParent(chg_statusEffectSpawn.transform);

            // Clear Child
            chg_statusEffectPosition2Child = null;

            // Remove effect from the list
            RemoveEffectFromList(chg_str_position2Identifier);

            // Reset Identifer
            chg_str_position2Identifier = "none";
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

            // Set New parent
            _child.transform.SetParent(chg_statusEffectSpawn.transform);

            // Clear Child
            chg_statusEffectPosition3Child = null;

            // Remove effect from the list
            RemoveEffectFromList(chg_str_position3Identifier);

            // Reset Identifer
            chg_str_position3Identifier = "none";
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

            // Set New parent
            _child.transform.SetParent(chg_statusEffectSpawn.transform);

            // Clear Child
            chg_statusEffectPosition4Child = null;

            // Remove effect from the list
            RemoveEffectFromList(chg_str_position4Identifier);

            // Reset Identifer
            chg_str_position4Identifier = "none";
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - EndStatusEffect() - Given Effect either already is ended or doesn't exist!");
        }
    }

    /////////////////////////////-----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Private Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////-----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Helper function to sort the list according to duration
    /// - Josh
    /// </summary>
    private void SortStatusEffectList()
    {
        if(chg_ls_activeEffectsList.Count == 4)
        {
            // First item
            (string, int, int) _itemAtPosition1 = chg_ls_activeEffectsList[0];

            // Second item
            (string, int, int) _itemAtPosition2 = chg_ls_activeEffectsList[1];

            // Third item
            (string, int, int) _itemAtPosition3 = chg_ls_activeEffectsList[2];

            // Fourth item
            (string, int, int) _itemAtPosition4 = chg_ls_activeEffectsList[3];
        }
        else if (chg_ls_activeEffectsList.Count == 3)
        {
            // First item
            (string, int, int) _itemAtPosition1 = chg_ls_activeEffectsList[0];

            // Second item
            (string, int, int) _itemAtPosition2 = chg_ls_activeEffectsList[1];

            // Third item
            (string, int, int) _itemAtPosition3 = chg_ls_activeEffectsList[2];
        }
        else if (chg_ls_activeEffectsList.Count == 2)
        {
            // First item
            (string, int, int) _itemAtPosition1 = chg_ls_activeEffectsList[0];

            // Second item
            (string, int, int) _itemAtPosition2 = chg_ls_activeEffectsList[1];
        }
        else if (chg_ls_activeEffectsList.Count == 1)
        {
            // First item
            (string, int, int) _itemAtPosition1 = chg_ls_activeEffectsList[0];
        }
    }

    /// <summary>
    /// Helper function to help sort the list in terms of position, rather then ordering the list itself
    /// - Josh
    /// </summary>
    private void SwitchPositions(string _statusEffect1, string _statusEffect2)
    {
        
    }

    /// <summary>
    /// Helper method to move a status effect to a new position
    /// - Josh 
    /// </summary>
    /// <param name="_statusEffect"></param>
    /// <param name="_positionIndex"></param>
    private void MovePositions(string _statusEffect, int _positionIndex)
    {
        if (_statusEffect.Equals("acid"))
        {
            // Move Child
            chg_UI_acidicStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);
        }
        else if (_statusEffect.Equals("bleed"))
        {

        }
        else if (_statusEffect.Equals("frail"))
        {

        }
        else if (_statusEffect.Equals("resist"))
        {

        }
        else if (_statusEffect.Equals("stun"))
        {

        }
    }

    /// <summary>
    /// Helper function to seek and return the duration for a given effect 
    /// Retrieved from other scripts
    /// - Josh
    /// </summary>
    /// <param name="_effectType"></param>
    /// <returns></returns>
    private int GetEffectStackCount(string _effectType) 
    {
        if (_effectType.Equals("acid")) 
        {
            if(GetHealthBarOwner() == -1) // Player
            {
                return g_global.g_playerState.GetPlayerAcidEffectStackCount();
            }
            else if(GetHealthBarOwner() == 1) // Enemy 1
            {
                return g_global.g_enemyState.GetEnemyAcidEffectStackCount(1);
            }
            else if (GetHealthBarOwner() == 2) // Enemy 2
            {
                return g_global.g_enemyState.GetEnemyAcidEffectStackCount(2);
            }
            else if (GetHealthBarOwner() == 3) // Enemy 3
            {
                return g_global.g_enemyState.GetEnemyAcidEffectStackCount(3);
            }
            else if (GetHealthBarOwner() == 4) // Enemy 4
            {
                return g_global.g_enemyState.GetEnemyAcidEffectStackCount(4);
            }
            else if (GetHealthBarOwner() == 5) // Enemy 5
            {
                return g_global.g_enemyState.GetEnemyAcidEffectStackCount(5);
            }
            else // Return methods require all paths to return a value, even the failed behavior potential paths
            {
                Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - GetEffectDuration() - Acidic");
                return -1;
            }
        }
        else if (_effectType.Equals("bleed"))
        {
            if (GetHealthBarOwner() == -1) // Player
            {
                return g_global.g_playerState.GetPlayerBleedEffectStackCount();
            }
            else if (GetHealthBarOwner() == 1) // Enemy 1
            {
                return g_global.g_enemyState.GetEnemyBleedEffectStackCount(1);
            }
            else if (GetHealthBarOwner() == 2) // Enemy 2
            {
                return g_global.g_enemyState.GetEnemyBleedEffectStackCount(2);
            }
            else if (GetHealthBarOwner() == 3) // Enemy 3
            {
                return g_global.g_enemyState.GetEnemyBleedEffectStackCount(3);
            }
            else if (GetHealthBarOwner() == 4) // Enemy 4
            {
                return g_global.g_enemyState.GetEnemyBleedEffectStackCount(4);
            }
            else if (GetHealthBarOwner() == 5) // Enemy 5
            {
                return g_global.g_enemyState.GetEnemyBleedEffectStackCount(5);
            }
            else // Return methods require all paths to return a value, even the failed behavior potential paths
            {
                Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - GetEffectDuration() - Bleed");
                return -1;
            }
        }
        else if (_effectType.Equals("frail"))
        {
            if (GetHealthBarOwner() == -1) // Player
            {
                return g_global.g_playerState.GetPlayerFrailtyEffectStackCount();
            }
            else if (GetHealthBarOwner() == 1) // Enemy 1
            {
                return g_global.g_enemyState.GetEnemyFrailtyEffectStackCount(1);
            }
            else if (GetHealthBarOwner() == 2) // Enemy 2
            {
                return g_global.g_enemyState.GetEnemyFrailtyEffectStackCount(2);
            }
            else if (GetHealthBarOwner() == 3) // Enemy 3
            {
                return g_global.g_enemyState.GetEnemyFrailtyEffectStackCount(3);
            }
            else if (GetHealthBarOwner() == 4) // Enemy 4
            {
                return g_global.g_enemyState.GetEnemyFrailtyEffectStackCount(4);
            }
            else if (GetHealthBarOwner() == 5) // Enemy 5
            {
                return g_global.g_enemyState.GetEnemyFrailtyEffectStackCount(5);
            }
            else // Return methods require all paths to return a value, even the failed behavior potential paths
            {
                Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - GetEffectDuration() - Frailty");
                return -1;
            }
        }
        else if (_effectType.Equals("resist"))
        {
            if (GetHealthBarOwner() == -1) // Player
            {
                return g_global.g_playerState.GetPlayerResistantEffectStackCount();
            }
            else if (GetHealthBarOwner() == 1) // Enemy 1
            {
                return g_global.g_enemyState.GetEnemyResistantEffectStackCount(1);
            }
            else if (GetHealthBarOwner() == 2) // Enemy 2
            {
                return g_global.g_enemyState.GetEnemyResistantEffectStackCount(2);
            }
            else if (GetHealthBarOwner() == 3) // Enemy 3
            {
                return g_global.g_enemyState.GetEnemyResistantEffectStackCount(3);
            }
            else if (GetHealthBarOwner() == 4) // Enemy 4
            {
                return g_global.g_enemyState.GetEnemyResistantEffectStackCount(4);
            }
            else if (GetHealthBarOwner() == 5) // Enemy 5
            {
                return g_global.g_enemyState.GetEnemyResistantEffectStackCount(5);
            }
            else // Return methods require all paths to return a value, even the failed behavior potential paths
            {
                Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - GetEffectDuration() - Resist");
                return -1;
            }
        }
        else if (_effectType.Equals("stun"))
        {
            if (GetHealthBarOwner() == 1) // Enemy 1, player doesn't have stun
            {
                return g_global.g_enemyState.GetEnemyStunEffectStackCount(1);
            }
            else if (GetHealthBarOwner() == 2) // Enemy 2
            {
                return g_global.g_enemyState.GetEnemyStunEffectStackCount(2);
            }
            else if (GetHealthBarOwner() == 3) // Enemy 3
            {
                return g_global.g_enemyState.GetEnemyStunEffectStackCount(3);
            }
            else if (GetHealthBarOwner() == 4) // Enemy 4
            {
                return g_global.g_enemyState.GetEnemyStunEffectStackCount(4);
            }
            else if (GetHealthBarOwner() == 5) // Enemy 5
            {
                return g_global.g_enemyState.GetEnemyStunEffectStackCount(5);
            }
            else // Return methods require all paths to return a value, even the failed behavior potential paths
            {
                Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - GetEffectDuration() - Stun");
                return -1;
            }
        }
        else // Return methods require all paths to return a value, even the failed behavior potential paths
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - GetEffectDuration() - Top Layer");
            return -1;
        }
    }

    /// <summary>
    /// Helper function to let me know what health bar type this is
    /// Saves on if else structure spacing
    /// - Josh
    /// </summary>
    /// <returns>
    /// -1 for Player || 1 for Enemy 1 || 2 for Enemy 2 || 3 for Enemy 3 || 4 for Enemy 4 || 5 for Enemy 5
    /// </returns>
    private int GetHealthBarOwner() 
    {
        if(chg_p_b_playerHealthBar == true) 
        {
            return -1; // is Player
        }
        else if (chg_e_b_enemy1HealthBar == true) 
        {
            return 1; // is Enemy 1
        }
        else if (chg_e_b_enemy2HealthBar == true)
        {
            return 2; // is Enemy 2
        }
        else if (chg_e_b_enemy3HealthBar == true)
        {
            return 3; // is Enemy 3
        }
        else if (chg_e_b_enemy4HealthBar == true)
        {
            return 4; // is Enemy 4
        }
        else if (chg_e_b_enemy5HealthBar == true)
        {
            return 5; // is Enemy 5
        }
        else // Return methods require all paths to return a value, even the failed behavior potential paths
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - RetrieveHealthBarOwner()");
            return 0; 
        }
    }

    /// <summary>
    /// Helper function to remove a given effect from the list to keep down programming bloat
    ///  - Josh
    /// </summary>
    /// <param name="_statusEffect"></param>
    private void RemoveEffectFromList(string _statusEffect) 
    {
        int _index = -3; // Null condition
        int _counter = -1;

        // Find Index
        foreach((string, int, int) _item in chg_ls_activeEffectsList.ToList()) 
        {
            _counter += 1;
            if (_item.Item1.Equals(_statusEffect)) // Tuple list items can be accessed by Item1, Item2, Item3... ItemN 
            {
                _index = _counter;
            }
        }

        // Cleaner delete from direct access
        if(_index != -3) 
        {
            chg_ls_activeEffectsList.RemoveAt(_index);
        }
        else 
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - RemoveEffectFromList() - Effect Not Found Error");
        }
    }

    /// <summary>
    /// Helper function to give the index from a specified effect
    ///  - Josh
    /// </summary>
    /// <param name="_statusEffect"></param>
    private int GetIndexFromEffect(string _effect)
    {
        if (_effect.Equals("acid"))
        {
            return chg_i_acidEffectListIndex;
        }
        else if (_effect.Equals("bleed"))
        {
            return chg_i_bleedEffectListIndex;
        }
        else if (_effect.Equals("frail"))
        {
            return chg_i_frailtyEffectListIndex;
        }
        else if (_effect.Equals("resist"))
        {
            return chg_i_resistantEffectListIndex;
        }
        else if (_effect.Equals("stun"))
        {
            return chg_i_stunEffectListIndex;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - RemoveEffectFromList() - Effect Not Found Error");
            return -1;
        }
    }
}
