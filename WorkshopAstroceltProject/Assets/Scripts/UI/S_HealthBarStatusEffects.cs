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
    [SerializeField] GameObject chg_UI_acidStatusEffect;
    [SerializeField] GameObject chg_UI_bleedStatusEffect;
    [SerializeField] GameObject chg_UI_frailtyStatusEffect;
    [SerializeField] GameObject chg_UI_resistantStatusEffect;
    [SerializeField] GameObject chg_UI_stunStatusEffect;
    [SerializeField] GameObject chg_UI_enemySpecialEffect;
 
    [Header("Position GameObjects")]
    [SerializeField] GameObject chg_statusEffectPosition1;
    [SerializeField] GameObject chg_statusEffectPosition2;
    [SerializeField] GameObject chg_statusEffectPosition3;
    [SerializeField] GameObject chg_statusEffectPosition4;
    [SerializeField] GameObject chg_statusEffectPosition5;
    [SerializeField] GameObject chg_statusEffectPosition6;
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
    [SerializeField] string chg_str_position6Identifier;

    [Header("Status Effect Tooltips")]
    [SerializeField] S_TooltipTemplate chg_tl_acidStatusEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_bleedStatusEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_frailtyStatusEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_resistantStatusEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_stunStatusEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_specialAttackBodachSpecialEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_specialAttackBananachEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_specialAttackClurichanEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_specialAttackPucaEffectTooltip;
    [SerializeField] S_TooltipTemplate chg_tl_specialAttackTroopfaeEffectTooltip;

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
    [SerializeField] int chg_p_i_enemySpecialEffectIndex;

    [Header("Special Attack Status Effect Image Assets")]
    [SerializeField] Sprite chg_UI_bananachSpecialAttackEffectImage;
    [SerializeField] Sprite chg_UI_bodachSpecialAttackEffectImage;
    [SerializeField] Sprite chg_UI_clurichaunSpecialAttackEffectImage;
    [SerializeField] Sprite chg_UI_pucaSpecialAttackEffectImage;
    [SerializeField] Sprite chg_UI_troopFaeSpecialAttackEffectImage;

    [Header("Float Values")]
    [SerializeField] float chg_f_spawnMoveValue;
    [SerializeField] float chg_f_fadeDurationValue;
    [SerializeField] float chg_f_endMoveValue;

    // Add a func to switch the asset depending on the enemy who triggered the special effect

    // Rework how stack counts inform data values

    // Finish movement for status effects

    private void Awake()
    {
        g_global = S_Global.Instance;

        ThreeElementTuple.tupleList = chg_ls_activeEffectsList;
    }

   /* private void Update()
    {
        if (g_global.g_enemyState.e_b_enemy1Dead)
        {
            healthbar1.setactive(false);
        }
    }*/

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
            if (chg_i_slotsOccupied == 0) // Means first effect
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_acidStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);

                // Move Child
                chg_UI_acidStatusEffect.transform.DOMove(chg_statusEffectPosition1.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_acidStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition1Child = chg_UI_acidStatusEffect;

                // Set Index
                SetEffectIndex(0, "acid");

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
                chg_UI_acidStatusEffect.transform.SetParent(chg_statusEffectPosition2.transform, true);

                // Move Child
                chg_UI_acidStatusEffect.transform.DOMove(chg_statusEffectPosition2.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_acidStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition2Child = chg_UI_acidStatusEffect;

                // Set Index
                SetEffectIndex(1, "acid");

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
                chg_UI_acidStatusEffect.transform.SetParent(chg_statusEffectPosition3.transform, true);

                // Move Child
                chg_UI_acidStatusEffect.transform.DOMove(chg_statusEffectPosition3.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_acidStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition3Child = chg_UI_acidStatusEffect;

                // Set Index
                SetEffectIndex(2, "acid");

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
                chg_UI_acidStatusEffect.transform.SetParent(chg_statusEffectPosition4.transform, true);

                // Move Child
                chg_UI_acidStatusEffect.transform.DOMove(chg_statusEffectPosition4.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_acidStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition4Child = chg_UI_acidStatusEffect;

                // Set Index
                SetEffectIndex(3, "acid");

                // Set identifier
                chg_str_position4Identifier = "acid";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position4Identifier, GetEffectStackCount(chg_str_position4Identifier), GetHealthBarOwner()));
            }
            else if (chg_i_slotsOccupied == 4)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_acidStatusEffect.transform.SetParent(chg_statusEffectPosition5.transform, true);

                // Move Child
                chg_UI_acidStatusEffect.transform.DOMove(chg_statusEffectPosition5.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_acidStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition5Child = chg_UI_acidStatusEffect;

                // Set Index
                SetEffectIndex(4, "acid");

                // Set identifier
                chg_str_position5Identifier = "acid";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position5Identifier, GetEffectStackCount(chg_str_position5Identifier), GetHealthBarOwner()));
            }
        }
        else if (_effect.Equals("bleed"))
        {
            if (chg_i_slotsOccupied == 0) // Means first effect
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_bleedStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);

                // Move Child
                chg_UI_bleedStatusEffect.transform.DOMove(chg_statusEffectPosition1.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_bleedStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition1Child = chg_UI_bleedStatusEffect;

                // Set Index
                SetEffectIndex(0, "bleed");

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
                chg_UI_bleedStatusEffect.transform.SetParent(chg_statusEffectPosition2.transform, true);

                // Move Child
                chg_UI_bleedStatusEffect.transform.DOMove(chg_statusEffectPosition2.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_bleedStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition2Child = chg_UI_bleedStatusEffect;

                // Set Index
                SetEffectIndex(1, "bleed");

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
                chg_UI_bleedStatusEffect.transform.SetParent(chg_statusEffectPosition3.transform, true);

                // Move Child
                chg_UI_bleedStatusEffect.transform.DOMove(chg_statusEffectPosition3.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_bleedStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition3Child = chg_UI_bleedStatusEffect;

                // Set Index
                SetEffectIndex(2, "bleed");

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
                chg_UI_bleedStatusEffect.transform.SetParent(chg_statusEffectPosition4.transform, true);

                // Move Child
                chg_UI_bleedStatusEffect.transform.DOMove(chg_statusEffectPosition4.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_bleedStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition4Child = chg_UI_bleedStatusEffect;

                // Set Index
                SetEffectIndex(3, "bleed");

                // Set identifier
                chg_str_position4Identifier = "bleed";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position4Identifier, GetEffectStackCount(chg_str_position4Identifier), GetHealthBarOwner()));
            }
            else if (chg_i_slotsOccupied == 4)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_bleedStatusEffect.transform.SetParent(chg_statusEffectPosition5.transform, true);

                // Move Child
                chg_UI_bleedStatusEffect.transform.DOMove(chg_statusEffectPosition5.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_bleedStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition5Child = chg_UI_bleedStatusEffect;

                // Set Index
                SetEffectIndex(4, "bleed");

                // Set identifier
                chg_str_position5Identifier = "bleed";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position5Identifier, GetEffectStackCount(chg_str_position5Identifier), GetHealthBarOwner()));
            }
        }
        else if (_effect.Equals("frail"))
        {
            if (chg_i_slotsOccupied == 0) // Means first effect
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_frailtyStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);

                // Move Child
                chg_UI_frailtyStatusEffect.transform.DOMove(chg_statusEffectPosition1.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_frailtyStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition1Child = chg_UI_frailtyStatusEffect;

                // Set Index
                SetEffectIndex(0, "frail");

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
                chg_UI_frailtyStatusEffect.transform.DOMove(chg_statusEffectPosition2.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_frailtyStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition2Child = chg_UI_frailtyStatusEffect;

                // Set Index
                SetEffectIndex(1, "frail");

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
                chg_UI_frailtyStatusEffect.transform.DOMove(chg_statusEffectPosition3.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_frailtyStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition3Child = chg_UI_frailtyStatusEffect;

                // Set Index
                SetEffectIndex(2, "frail");

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
                chg_UI_frailtyStatusEffect.transform.DOMove(chg_statusEffectPosition4.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_frailtyStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition4Child = chg_UI_frailtyStatusEffect;

                // Set Index
                SetEffectIndex(3, "frail");

                // Set identifier
                chg_str_position4Identifier = "frail";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position4Identifier, GetEffectStackCount(chg_str_position4Identifier), GetHealthBarOwner()));
            }
            else if (chg_i_slotsOccupied == 4)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_frailtyStatusEffect.transform.SetParent(chg_statusEffectPosition5.transform, true);

                // Move Child
                chg_UI_frailtyStatusEffect.transform.DOMove(chg_statusEffectPosition5.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_frailtyStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition5Child = chg_UI_frailtyStatusEffect;

                // Set Index
                SetEffectIndex(4, "frail");

                // Set identifier
                chg_str_position5Identifier = "frail";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position5Identifier, GetEffectStackCount(chg_str_position5Identifier), GetHealthBarOwner()));
            }
        }
        else if (_effect.Equals("resist"))
        {
            if (chg_i_slotsOccupied == 0) // Means first effect
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_resistantStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);

                // Move Child
                chg_UI_resistantStatusEffect.transform.DOMove(chg_statusEffectPosition1.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_resistantStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition1Child = chg_UI_resistantStatusEffect;

                // Set Index
                SetEffectIndex(0, "resist");

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
                chg_UI_resistantStatusEffect.transform.DOMove(chg_statusEffectPosition2.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_resistantStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition2Child = chg_UI_resistantStatusEffect;

                // Set Index
                SetEffectIndex(1, "resist");

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
                chg_UI_resistantStatusEffect.transform.DOMove(chg_statusEffectPosition3.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_resistantStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition3Child = chg_UI_resistantStatusEffect;

                // Set Index
                SetEffectIndex(2, "resist");

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
                chg_UI_resistantStatusEffect.transform.DOMove(chg_statusEffectPosition4.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_resistantStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition4Child = chg_UI_resistantStatusEffect;

                // Set Index
                SetEffectIndex(3, "resist");

                // Set identifier
                chg_str_position4Identifier = "resist";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position4Identifier, GetEffectStackCount(chg_str_position4Identifier), GetHealthBarOwner()));
            }
            else if (chg_i_slotsOccupied == 4)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_resistantStatusEffect.transform.SetParent(chg_statusEffectPosition5.transform, true);

                // Move Child
                chg_UI_resistantStatusEffect.transform.DOMove(chg_statusEffectPosition5.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_resistantStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition5Child = chg_UI_resistantStatusEffect;

                // Set Index
                SetEffectIndex(4, "resist");

                // Set identifier
                chg_str_position5Identifier = "resist";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position5Identifier, GetEffectStackCount(chg_str_position5Identifier), GetHealthBarOwner()));
            }
        }
        else if (_effect.Equals("stun"))
        {
            if (chg_i_slotsOccupied == 0) // Means first effect
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_stunStatusEffect.transform.SetParent(chg_statusEffectPosition1.transform, true);

                // Move Child
                chg_UI_stunStatusEffect.transform.DOMove(chg_statusEffectPosition1.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_stunStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition1Child = chg_UI_stunStatusEffect;

                // Set Index
                SetEffectIndex(0, "stun");

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
                chg_UI_stunStatusEffect.transform.SetParent(chg_statusEffectPosition2.transform, true);

                // Move Child
                chg_UI_stunStatusEffect.transform.DOMove(chg_statusEffectPosition2.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_stunStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition2Child = chg_UI_stunStatusEffect;

                // Set Index
                SetEffectIndex(1, "stun");

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
                chg_UI_stunStatusEffect.transform.SetParent(chg_statusEffectPosition3.transform, true);

                // Move Child
                chg_UI_stunStatusEffect.transform.DOMove(chg_statusEffectPosition3.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_stunStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition3Child = chg_UI_stunStatusEffect;

                // Set Index
                SetEffectIndex(2, "stun");

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
                chg_UI_stunStatusEffect.transform.SetParent(chg_statusEffectPosition4.transform, true);

                // Move Child
                chg_UI_stunStatusEffect.transform.DOMove(chg_statusEffectPosition4.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_stunStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition4Child = chg_UI_stunStatusEffect;

                // Set Index
                SetEffectIndex(3, "stun");

                // Set identifier
                chg_str_position4Identifier = "stun";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position4Identifier, GetEffectStackCount(chg_str_position4Identifier), GetHealthBarOwner()));
            }
            else if (chg_i_slotsOccupied == 4)
            {
                // Adjust slot count
                chg_i_slotsOccupied += 1;

                // Set new parent
                chg_UI_stunStatusEffect.transform.SetParent(chg_statusEffectPosition5.transform, true);

                // Move Child
                chg_UI_stunStatusEffect.transform.DOMove(chg_statusEffectPosition5.transform.position, chg_f_spawnMoveValue);

                // Fade in Child
                chg_UI_stunStatusEffect.GetComponent<Image>().DOFade(255, chg_f_fadeDurationValue);

                // Set child
                chg_statusEffectPosition5Child = chg_UI_stunStatusEffect;

                // Set Index
                SetEffectIndex(4, "stun");

                // Set identifier
                chg_str_position5Identifier = "stun";

                // Add effect to the list
                chg_ls_activeEffectsList.Add((chg_str_position5Identifier, GetEffectStackCount(chg_str_position5Identifier), GetHealthBarOwner()));
            }
        }

        //SortStatusEffectList();
    }

    /// <summary>
    /// End the given status effect visual,
    /// using int for clarity
    /// - Josh
    /// </summary>
    public void EndStatusEffect(string _effect)
    {
        int _positionNum = GetIndexFromEffect(_effect);
        if (_positionNum == 0 && EffectStateActive(_effect, GetHealthBarOwner()) == true)
        {
            // Adjust slot count
            chg_i_slotsOccupied -= 1;

            // Grab Child
            GameObject _effectObject = GetEffectObjectFromEffect(_effect);

            // Move Child
            _effectObject.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);

            // Fade Child
            _effectObject.GetComponent<Image>().DOFade(0, chg_f_fadeDurationValue);

            // Set New parent
            _effectObject.transform.SetParent(chg_statusEffectSpawn.transform);

            // Clear List Index
            ResetIndexFromIndex(0);

            // Clear Child
            chg_statusEffectPosition1Child = null;

            // Remove effect from the list
            RemoveEffectFromList(chg_str_position1Identifier);

            // Reset Identifer
            chg_str_position1Identifier = "none";
        }
        else if (_positionNum == 1 && EffectStateActive(_effect, GetHealthBarOwner()) == true)
        {
            // Adjust slot count
            chg_i_slotsOccupied -= 1;

            // Grab Child
            GameObject _effectObject = GetEffectObjectFromEffect(_effect);

            // Move Child
            _effectObject.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);

            // Fade Child
            _effectObject.GetComponent<Image>().DOFade(0, chg_f_fadeDurationValue);

            // Set New parent
            _effectObject.transform.SetParent(chg_statusEffectSpawn.transform);

            // Clear Child
            chg_statusEffectPosition2Child = null;

            // Clear List Index
            ResetIndexFromIndex(1);

            // Remove effect from the list
            RemoveEffectFromList(chg_str_position2Identifier);

            // Reset Identifer
            chg_str_position2Identifier = "none";
        }
        else if (_positionNum == 2 && EffectStateActive(_effect, GetHealthBarOwner()) == true)
        {
            // Adjust slot count
            chg_i_slotsOccupied -= 1;

            // Grab Child
            GameObject _effectObject = GetEffectObjectFromEffect(_effect);

            // Move Child
            _effectObject.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);

            // Fade Child
            _effectObject.GetComponent<Image>().DOFade(0, chg_f_fadeDurationValue);

            // Set New parent
            _effectObject.transform.SetParent(chg_statusEffectSpawn.transform);

            // Clear List Index
            ResetIndexFromIndex(2);

            // Clear Child
            chg_statusEffectPosition3Child = null;

            // Remove effect from the list
            RemoveEffectFromList(chg_str_position3Identifier);

            // Reset Identifer
            chg_str_position3Identifier = "none";
        }
        else if (_positionNum == 3 && EffectStateActive(_effect, GetHealthBarOwner()) == true)
        {
            // Adjust slot count
            chg_i_slotsOccupied -= 1;

            // Grab Child
            GameObject _effectObject = GetEffectObjectFromEffect(_effect);

            // Move Child
            _effectObject.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);

            // Fade Child
            _effectObject.GetComponent<Image>().DOFade(0, chg_f_fadeDurationValue);

            // Set New parent
            _effectObject.transform.SetParent(chg_statusEffectSpawn.transform);

            // Clear List Index
            ResetIndexFromIndex(3);

            // Clear Child
            chg_statusEffectPosition4Child = null;

            // Remove effect from the list
            RemoveEffectFromList(chg_str_position4Identifier);

            // Reset Identifer
            chg_str_position5Identifier = "none";
        }
        else if (_positionNum == 4 && EffectStateActive(_effect, GetHealthBarOwner()) == true)
        {
            // Adjust slot count
            chg_i_slotsOccupied -= 1;

            // Grab Child
            GameObject _effectObject = GetEffectObjectFromEffect(_effect);

            // Move Child
            _effectObject.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);

            // Fade Child
            _effectObject.GetComponent<Image>().DOFade(0, chg_f_fadeDurationValue);

            // Set New parent
            _effectObject.transform.SetParent(chg_statusEffectSpawn.transform);

            // Clear List Index
            ResetIndexFromIndex(4);

            // Clear Child
            chg_statusEffectPosition5Child = null;

            // Remove effect from the list
            RemoveEffectFromList(chg_str_position5Identifier);

            // Reset Identifer
            chg_str_position5Identifier = "none";
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
    private void SortStatusEffectList() // Put in turn manager
    {
        chg_ls_activeEffectsList.OrderByDescending(x => x.Item2);
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
            chg_UI_acidStatusEffect.transform.DOMove(chg_statusEffectSpawn.transform.position, chg_f_endMoveValue);
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
        else if(_statusEffect.Equals("special"))
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

    /// <summary>
    /// Helper 
    /// </summary>
    /// <param name="_index"></param>
    private void ResetIndexFromIndex(int _index)
    {
        if(_index == 1)
        {
            if(chg_i_acidEffectListIndex == 1) // Index was acid
            {
                chg_i_acidEffectListIndex = -1; // Reset Acid
            }
            else if(chg_i_bleedEffectListIndex == 1) // Index was bleed
            {
                chg_i_bleedEffectListIndex = -1; // Reset Bleed
            }
            else if (chg_i_frailtyEffectListIndex == 1) // Index was frail
            {
                chg_i_frailtyEffectListIndex = -1; // Reset Frailty
            }
            else if (chg_i_resistantEffectListIndex == 1) // Index was resist
            {
                chg_i_resistantEffectListIndex = -1; // Reset Resistant
            }
            else if (chg_i_stunEffectListIndex == 1) // Index was stun
            {
                chg_i_stunEffectListIndex = -1; // Reset Stun
            }
        }
        else if (_index == 2)
        {
            if (chg_i_acidEffectListIndex == 2) // Index was acid
            {
                chg_i_acidEffectListIndex = -1; // Reset Acid
            }
            else if (chg_i_bleedEffectListIndex == 2) // Index was bleed
            {
                chg_i_bleedEffectListIndex = -1; // Reset Bleed
            }
            else if (chg_i_frailtyEffectListIndex == 2) // Index was frail
            {
                chg_i_frailtyEffectListIndex = -1; // Reset Frailty
            }
            else if (chg_i_resistantEffectListIndex == 2) // Index was resist
            {
                chg_i_resistantEffectListIndex = -1; // Reset Resistant
            }
            else if (chg_i_stunEffectListIndex == 2) // Index was stun
            {
                chg_i_stunEffectListIndex = -1; // Reset Stun
            }
        }
        else if (_index == 3)
        {
            if (chg_i_acidEffectListIndex == 3) // Index was acid
            {
                chg_i_acidEffectListIndex = -1; // Reset Acid
            }
            else if (chg_i_bleedEffectListIndex == 3) // Index was bleed
            {
                chg_i_bleedEffectListIndex = -1; // Reset Bleed
            }
            else if (chg_i_frailtyEffectListIndex == 3) // Index was frail
            {
                chg_i_frailtyEffectListIndex = -1; // Reset Frailty
            }
            else if (chg_i_resistantEffectListIndex == 3) // Index was resist
            {
                chg_i_resistantEffectListIndex = -1; // Reset Resistant
            }
            else if (chg_i_stunEffectListIndex == 3) // Index was stun
            {
                chg_i_stunEffectListIndex = -1; // Reset Stun
            }
        }
        else if (_index == 4)
        {
            if (chg_i_acidEffectListIndex == 4) // Index was acid
            {
                chg_i_acidEffectListIndex = -1; // Reset Acid
            }
            else if (chg_i_bleedEffectListIndex == 4) // Index was bleed
            {
                chg_i_bleedEffectListIndex = -1; // Reset Bleed
            }
            else if (chg_i_frailtyEffectListIndex == 4) // Index was frail
            {
                chg_i_frailtyEffectListIndex = -1; // Reset Frailty
            }
            else if (chg_i_resistantEffectListIndex == 4) // Index was resist
            {
                chg_i_resistantEffectListIndex = -1; // Reset Resistant
            }
            else if (chg_i_stunEffectListIndex == 4) // Index was stun
            {
                chg_i_stunEffectListIndex = -1; // Reset Stun
            }
        }
        else if (_index == 5)
        {
            if (chg_i_acidEffectListIndex == 5) // Index was acid
            {
                chg_i_acidEffectListIndex = -1; // Reset Acid
            }
            else if (chg_i_bleedEffectListIndex == 5) // Index was bleed
            {
                chg_i_bleedEffectListIndex = -1; // Reset Bleed
            }
            else if (chg_i_frailtyEffectListIndex == 5) // Index was frail
            {
                chg_i_frailtyEffectListIndex = -1; // Reset Frailty
            }
            else if (chg_i_resistantEffectListIndex == 5) // Index was resist
            {
                chg_i_resistantEffectListIndex = -1; // Reset Resistant
            }
            else if (chg_i_stunEffectListIndex == 5) // Index was stun
            {
                chg_i_stunEffectListIndex = -1; // Reset Stun
            }
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - ResetIndexFromIndex() - Index Not Found Error");
        }
    }

    /// <summary>
    /// Helper to set the effect index
    /// </summary>
    /// <param name="_index"></param>
    private void SetEffectIndex(int _index, string _effect)
    {
        if (_effect.Equals("acid"))
        {
            chg_i_acidEffectListIndex = _index;
        }
        else if (_effect.Equals("bleed"))
        {
            chg_i_bleedEffectListIndex = _index;
        }
        else if (_effect.Equals("frail"))
        {
            chg_i_frailtyEffectListIndex = _index;
        }
        else if (_effect.Equals("resist"))
        {
            chg_i_resistantEffectListIndex = _index;
        }
        else if (_effect.Equals("stun"))
        {
            chg_i_stunEffectListIndex = _index;
        }
        else if (_effect.Equals("special"))
        {
            chg_p_i_enemySpecialEffectIndex = _index;
        }
    }

    /// <summary>
    /// Helper function to determine if an effect is an active state or not for a specific health bar owner
    /// - Josh
    /// </summary>
    /// <param name="_effect"></param>
    /// <param name="_healthBarOwner"></param>
    private bool EffectStateActive(string _effect, int _healthBarOwner) 
    {
        if (_effect.Equals("acid"))
        {
            if (_healthBarOwner == -1) // Player
            {
                if (g_global.g_playerState.GetPlayerAcidEffectState() == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 1) // Enemy 1
            {
                if (g_global.g_enemyState.GetEnemyAcidEffectState(1) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 2) // Enemy 2
            {
                if (g_global.g_enemyState.GetEnemyAcidEffectState(2) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 3) // Enemy 3
            {
                if (g_global.g_enemyState.GetEnemyAcidEffectState(3) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 4) // Enemy 4
            {
                if (g_global.g_enemyState.GetEnemyAcidEffectState(4) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 5) // Enemy 5
            {
                if (g_global.g_enemyState.GetEnemyAcidEffectState(5) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else
            {
                Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - EffectStateActive() - Owner Not Found Error");
                return false;
            }
        }
        else if (_effect.Equals("bleed"))
        {
            if (_healthBarOwner == -1) // Player
            {
                if (g_global.g_playerState.GetPlayerBleedEffectState() == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 1) // Enemy 1
            {
                if (g_global.g_enemyState.GetEnemyBleedEffectState(1) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 2) // Enemy 2
            {
                if (g_global.g_enemyState.GetEnemyBleedEffectState(2) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 3) // Enemy 3
            {
                if (g_global.g_enemyState.GetEnemyBleedEffectState(3) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 4) // Enemy 4
            {
                if (g_global.g_enemyState.GetEnemyBleedEffectState(4) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 5) // Enemy 5
            {
                if (g_global.g_enemyState.GetEnemyBleedEffectState(5) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else
            {
                Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - EffectStateActive() - Owner Not Found Error");
                return false;
            }
        }
        else if (_effect.Equals("frail"))
        {
            if (_healthBarOwner == -1) // Player
            {
                if (g_global.g_playerState.GetPlayerFrailtyEffectState() == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 1) // Enemy 1
            {
                if (g_global.g_enemyState.GetEnemyFrailtyEffectState(1) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 2) // Enemy 2
            {
                if (g_global.g_enemyState.GetEnemyFrailtyEffectState(2) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 3) // Enemy 3
            {
                if (g_global.g_enemyState.GetEnemyFrailtyEffectState(3) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 4) // Enemy 4
            {
                if (g_global.g_enemyState.GetEnemyFrailtyEffectState(4) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 5) // Enemy 5
            {
                if (g_global.g_enemyState.GetEnemyFrailtyEffectState(5) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else
            {
                Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - EffectStateActive() - Owner Not Found Error");
                return false;
            }
        }
        else if (_effect.Equals("resist"))
        {
            if (_healthBarOwner == -1) // Player
            {
                if (g_global.g_playerState.GetPlayerResistantEffectState() == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 1) // Enemy 1
            {
                if (g_global.g_enemyState.GetEnemyResistantEffectState(1) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 2) // Enemy 2
            {
                if (g_global.g_enemyState.GetEnemyResistantEffectState(2) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 3) // Enemy 3
            {
                if (g_global.g_enemyState.GetEnemyResistantEffectState(3) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 4) // Enemy 4
            {
                if (g_global.g_enemyState.GetEnemyResistantEffectState(4) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 5) // Enemy 5
            {
                if (g_global.g_enemyState.GetEnemyResistantEffectState(5) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else
            {
                Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - EffectStateActive() - Owner Not Found Error");
                return false;
            }
        }
        else if (_effect.Equals("stun"))
        {
            if (_healthBarOwner == 1) // Enemy 1, player doesn't have stun
            {
                if (g_global.g_enemyState.GetEnemyStunEffectState(1) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 2) // Enemy 2
            {
                if (g_global.g_enemyState.GetEnemyStunEffectState(2) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 3) // Enemy 3
            {
                if (g_global.g_enemyState.GetEnemyStunEffectState(3) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 4) // Enemy 4
            {
                if (g_global.g_enemyState.GetEnemyStunEffectState(4) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else if (_healthBarOwner == 5) // Enemy 5
            {
                if (g_global.g_enemyState.GetEnemyStunEffectState(5) == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else
            {
                Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - EffectStateActive() - Owner Not Found Error");
                return false;
            }
        }
        else if (_effect.Equals("special"))
        {
            if (_healthBarOwner == -1) // Player
            {
                if (g_global.g_playerState.GetPlayerSpecialAttackEffectState() == true)
                {
                    return true; // Effect is active
                }
                else
                {
                    return false; // Effect isn't active
                }
            }
            else // Enemies won't be attacked by other enemies, or so I'm led to believe
            {
                Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - EffectStateActive() - Owner Not Found Error");
                return false;
            }
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - EffectStateActive() - Effect Not Found Error");
            return false;
        }
    }

    /// <summary>
    /// Special Attack Owner Declare Helper function
    /// int = 1, Bananach
    /// int = 2, Bodach
    /// int = 3, Clurichaun
    /// int = 4, Puca
    /// int = 5, Troop Fae
    /// - Josh
    /// </summary>
    private void SpecialAttackOwner(int _owner)
    {
        if (_owner == 1) //Bananach
        {
            chg_UI_enemySpecialEffect.GetComponent<Image>().sprite = chg_UI_bananachSpecialAttackEffectImage;
        }
        else if (_owner == 2) // Bodach
        {
            chg_UI_enemySpecialEffect.GetComponent<Image>().sprite = chg_UI_bodachSpecialAttackEffectImage;
        }
        else if (_owner == 3) // Clurichaun
        {
            chg_UI_enemySpecialEffect.GetComponent<Image>().sprite = chg_UI_clurichaunSpecialAttackEffectImage;
        }
        else if (_owner == 4) // Puca
        {
            chg_UI_enemySpecialEffect.GetComponent<Image>().sprite = chg_UI_pucaSpecialAttackEffectImage;
        }
        else if (_owner == 5) // Troop Fae
        {
            chg_UI_enemySpecialEffect.GetComponent<Image>().sprite = chg_UI_troopFaeSpecialAttackEffectImage;
        }
    }

    /// <summary>
    /// Helper function to give child from effect
    /// Get around race conditions
    /// - Josh
    /// </summary>
    /// <param name="_effect"></param>
    private GameObject GetEffectObjectFromEffect(string _effect)
    {
        if (_effect.Equals("acid")) 
        {
            return chg_UI_acidStatusEffect;
        }
        else if (_effect.Equals("bleed"))
        {
            return chg_UI_bleedStatusEffect;
        }
        else if (_effect.Equals("frail"))
        {
            return chg_UI_frailtyStatusEffect;
        }
        else if (_effect.Equals("resist"))
        {
            return chg_UI_resistantStatusEffect;
        }
        else if (_effect.Equals("stun"))
        {
            return chg_UI_stunStatusEffect;
        }
        else if (_effect.Equals("special"))
        {
            return chg_UI_enemySpecialEffect;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_HealthBarStatusEffects - GetEffectObjectFromEffect() - Effect Not Found Error");
            return null;
        }
    }
}
