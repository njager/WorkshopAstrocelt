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
    [Tooltip("String is effect type, int is duration")]
    [SerializeField] List<(string, int)> chg_ls_activeEffectsList = new List<(string, int)>();

    [Header("Float Values")]
    [SerializeField] float chg_f_spawnMoveValue;
    [SerializeField] float chg_f_fadeDurationValue;
    [SerializeField] float chg_f_endMoveValue;

    /////////////////////////////----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Public Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

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
                chg_ls_activeEffectsList.Add("acid");
                
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
                chg_ls_activeEffectsList.Add(chg_str_position2Identifier);
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
                chg_ls_activeEffectsList.Add("bleed");
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

    /////////////////////////////-----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Private Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////-----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Helper function to sort the list according to duration
    /// - Josh
    /// </summary>
    private void SortList()
    {
        if(chg_ls_activeEffectsList.Count == 4)
        {
            GameObject slot1;
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

    /// <summary>
    /// Helper function to seek and return the duration for a given effect 
    /// Retrieved from other scripts
    /// - Josh
    /// </summary>
    /// <param name="_effectType"></param>
    /// <returns></returns>
    private int GetEffectDuration(string _effectType) 
    {
        if (_effectType.Equals("acid")) 
        {
            if(GetHealthBarOwner() == -1) // Player
            {
                return g_global.g_playerState.GetPlayerAcidicEffectDuration();
            }
            else if(GetHealthBarOwner() == 1) // Enemy 1
            {
                return g_global.g_enemyState.GetEnemyAcidicEffectDuration(1);
            }
            else if (GetHealthBarOwner() == 2) // Enemy 2
            {
                return g_global.g_enemyState.GetEnemyAcidicEffectDuration(2);
            }
            else if (GetHealthBarOwner() == 3) // Enemy 3
            {
                return g_global.g_enemyState.GetEnemyAcidicEffectDuration(3);
            }
            else if (GetHealthBarOwner() == 4) // Enemy 4
            {
                return g_global.g_enemyState.GetEnemyAcidicEffectDuration(4);
            }
            else if (GetHealthBarOwner() == 5) // Enemy 5
            {
                return g_global.g_enemyState.GetEnemyAcidicEffectDuration(5);
            }
            else // Return methods require all paths to return a value, even the failed behavior potential paths
            {
                Debug.Log("FAILED FUNCTION - S_HealthBarStatusEffects - GetEffectDuration() - Acidic");
                return -1;
            }
        }
        else if (_effectType.Equals("bleed"))
        {
            if (GetHealthBarOwner() == -1) // Player
            {
                return g_global.g_playerState.GetPlayerBleedEffectDuration();
            }
            else if (GetHealthBarOwner() == 1) // Enemy 1
            {
                return g_global.g_enemyState.GetEnemyBleedEffectDuration(1);
            }
            else if (GetHealthBarOwner() == 2) // Enemy 2
            {
                return g_global.g_enemyState.GetEnemyBleedEffectDuration(2);
            }
            else if (GetHealthBarOwner() == 3) // Enemy 3
            {
                return g_global.g_enemyState.GetEnemyBleedEffectDuration(3);
            }
            else if (GetHealthBarOwner() == 4) // Enemy 4
            {
                return g_global.g_enemyState.GetEnemyBleedEffectDuration(4);
            }
            else if (GetHealthBarOwner() == 5) // Enemy 5
            {
                return g_global.g_enemyState.GetEnemyBleedEffectDuration(5);
            }
            else // Return methods require all paths to return a value, even the failed behavior potential paths
            {
                Debug.Log("FAILED FUNCTION - S_HealthBarStatusEffects - GetEffectDuration() - Bleed");
                return -1;
            }
        }
        else if (_effectType.Equals("resist"))
        {
            if (GetHealthBarOwner() == -1) // Player
            {
                return g_global.g_playerState.GetPlayerResistantEffectDuration();
            }
            else if (GetHealthBarOwner() == 1) // Enemy 1
            {
                return g_global.g_enemyState.GetEnemyResistantEffectDuration(1);
            }
            else if (GetHealthBarOwner() == 2) // Enemy 2
            {
                return g_global.g_enemyState.GetEnemyResistantEffectDuration(2);
            }
            else if (GetHealthBarOwner() == 3) // Enemy 3
            {
                return g_global.g_enemyState.GetEnemyResistantEffectDuration(3);
            }
            else if (GetHealthBarOwner() == 4) // Enemy 4
            {
                return g_global.g_enemyState.GetEnemyResistantEffectDuration(4);
            }
            else if (GetHealthBarOwner() == 5) // Enemy 5
            {
                return g_global.g_enemyState.GetEnemyResistantEffectDuration(5);
            }
            else // Return methods require all paths to return a value, even the failed behavior potential paths
            {
                Debug.Log("FAILED FUNCTION - S_HealthBarStatusEffects - GetEffectDuration() - Resist");
                return -1;
            }
        }
        else if (_effectType.Equals("stun"))
        {
            if (GetHealthBarOwner() == 1) // Enemy 1, player doesn't have stun
            {
                return g_global.g_enemyState.GetEnemyStunnedEffectDuration(1);
            }
            else if (GetHealthBarOwner() == 2) // Enemy 2
            {
                return g_global.g_enemyState.GetEnemyStunnedEffectDuration(2);
            }
            else if (GetHealthBarOwner() == 3) // Enemy 3
            {
                return g_global.g_enemyState.GetEnemyStunnedEffectDuration(3);
            }
            else if (GetHealthBarOwner() == 4) // Enemy 4
            {
                return g_global.g_enemyState.GetEnemyStunnedEffectDuration(4);
            }
            else if (GetHealthBarOwner() == 5) // Enemy 5
            {
                return g_global.g_enemyState.GetEnemyStunnedEffectDuration(5);
            }
            else // Return methods require all paths to return a value, even the failed behavior potential paths
            {
                Debug.Log("FAILED FUNCTION - S_HealthBarStatusEffects - GetEffectDuration() - Stun");
                return -1;
            }
        }
        else // Return methods require all paths to return a value, even the failed behavior potential paths
        {
            Debug.Log("FAILED FUNCTION - S_HealthBarStatusEffects - GetEffectDuration() - Top Layer");
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
            Debug.Log("FAILED FUNCTION - S_HealthBarStatusEffects - RetrieveHealthBarOwner()");
            return 0; 
        }
    }
}
