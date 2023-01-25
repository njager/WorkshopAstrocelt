using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CharacterGraphics : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    [Header("Script Connections")]
    [SerializeField] S_Global g_global;
    [SerializeField] S_UIManager sc_UIManager;

    private void Awake()
    {
        g_global = S_Global.Instance;    
    }

    private void Start()
    {
        sc_UIManager.GetPlayerCardSelector().SetActive(false);
        EnemyShieldingUIToggle();
    }

    /////////////////////////////----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Player Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the health text values and health bar fill amounts for the player
    /// - Josh
    /// </summary>
    /// <param name="_healthValue"></param>
    public void UpdatePlayerHealthUI(int _healthValue)
    {
        // Set health text
        sc_UIManager.SetPlayerHealthText(_healthValue, g_global.g_playerAttributeSheet.GetPlayerMaxHealthValue());

        // Set health bar fill
        sc_UIManager.SetPlayerHealthBar(_healthValue, g_global.g_playerAttributeSheet.GetPlayerMaxHealthValue());
    }

    /// <summary>
    /// Set the shield text values and shield bar fill amounts for the player
    /// - Josh
    /// </summary>
    /// <param name="_shieldValue"></param>
    public void UpdatePlayerShieldUI(int _shieldValue)
    {
        sc_UIManager.SetPlayerShieldText(_shieldValue);
    }

    /// <summary>
    /// If the player has doesn't have shields, turn those elements off
    /// Otherwise if they have shields, turn them on
    /// - Josh
    /// </summary>
    public void PlayerShieldingUIToggle()
    {
        //Toggle Shields for player
        if (g_global.g_playerAttributeSheet.GetPlayerShieldValue() <= 0) // If no shields don't turn on shield UI
        {
            sc_UIManager.GetPlayerShieldText().gameObject.SetActive(false);
            sc_UIManager.GetPlayerShieldIcon().SetActive(false);
            sc_UIManager.GetPlayerShieldHeartIcon().SetActive(false);
            sc_UIManager.GetPlayerShieldOverlay().SetActive(false);
        }
        else // Turn it on
        {
            sc_UIManager.GetPlayerShieldText().gameObject.SetActive(true);
            sc_UIManager.GetPlayerShieldIcon().SetActive(true);
            sc_UIManager.GetPlayerShieldHeartIcon().SetActive(true);
            sc_UIManager.GetPlayerShieldOverlay().SetActive(true);
        }
    }

    /// <summary>
    /// Function to shake and then move the healthbars out of the screen
    /// </summary>
    /// <param name="_enemyIndex"></param>
    public void DropHealthBar(int _enemyIndex)
    {

    }

    /////////////////////////////---------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Enemy Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the health text of a given enemy
    /// - Josh
    /// </summary>
    /// <param name="_enemyNum"></param>
    public void UpdateEnemyHealthUI(int _enemyNum)
    {
        // Set health text
        sc_UIManager.SetEnemyHealthText(g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).GetEnemyHealthValue(), g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).GetEnemyMaxHealthValue(), _enemyNum);

        // Set health bar fill
        sc_UIManager.SetEnemyHealthBar(g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).GetEnemyHealthValue(), g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).GetEnemyMaxHealthValue(), _enemyNum);
    }

    public void UpdateEnemyShieldUI(int _enemyNum)
    {
        sc_UIManager.SetEnemyShieldText(g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).GetEnemyShieldValue(), _enemyNum);
    }


    /// <summary>
    /// Toggle the shield elements for the enemy in the overall enemy UI based on their current shield value
    /// Aka if the enemy has shields, turn them on, otherwise turn them off
    /// -Josh
    /// </summary>
    public void EnemyShieldingUIToggle()
    {
        // Toggle Shields for enemy 1
        if (g_global.g_enemyState.GetEnemyActiveState(1) == true) 
        {
            if (g_global.g_enemyState.GetEnemyDataSheet(1).GetEnemyShieldValue() <= 0)
            {
                // Turn it off
                sc_UIManager.GetEnemyShieldText(1).gameObject.SetActive(false);
                sc_UIManager.GetEnemyShieldIcon(1).SetActive(false);
                sc_UIManager.GetEnemyShieldOverlay(1).SetActive(false);
            }
            else
            {
                // Turn it on
                sc_UIManager.GetEnemyShieldText(1).gameObject.SetActive(true);
                sc_UIManager.GetEnemyShieldIcon(1).SetActive(true);
                sc_UIManager.GetEnemyShieldOverlay(1).SetActive(true);

                // Now refresh the setting of shields to make sure values update properly
                UpdateEnemyShieldUI(1);
            }
        }

        // Toggle Shields for enemy 2
        if (g_global.g_enemyState.GetEnemyActiveState(2) == true)
        {
            if (g_global.g_enemyState.GetEnemyDataSheet(2).GetEnemyShieldValue() <= 0)
            {
                // Turn it off
                sc_UIManager.GetEnemyShieldText(2).gameObject.SetActive(false);
                sc_UIManager.GetEnemyShieldIcon(2).SetActive(false);
                sc_UIManager.GetEnemyShieldOverlay(2).SetActive(false);
            }
            else
            {
                // Turn it on
                sc_UIManager.GetEnemyShieldText(2).gameObject.SetActive(true);
                sc_UIManager.GetEnemyShieldIcon(2).SetActive(true);
                sc_UIManager.GetEnemyShieldOverlay(2).SetActive(true);

                // Now refresh the setting of shields to make sure values update properly
                UpdateEnemyShieldUI(2);
            }
        }
        // Toggle Shields for enemy 3
        if (g_global.g_enemyState.GetEnemyActiveState(3) == true)
        {
            if (g_global.g_enemyState.GetEnemyDataSheet(3).GetEnemyShieldValue() <= 0)
            {
                // Turn it off
                sc_UIManager.GetEnemyShieldText(3).gameObject.SetActive(false);
                sc_UIManager.GetEnemyShieldIcon(3).SetActive(false);
                sc_UIManager.GetEnemyShieldOverlay(3).SetActive(false);
            }
            else
            {
                // Turn it on
                sc_UIManager.GetEnemyShieldText(3).gameObject.SetActive(true);
                sc_UIManager.GetEnemyShieldIcon(3).SetActive(true);
                sc_UIManager.GetEnemyShieldOverlay(3).SetActive(true);

                // Now refresh the setting of shields to make sure values update properly
                UpdateEnemyShieldUI(3);
            }
        }

        // Toggle Shields for enemy 4
        if (g_global.g_enemyState.GetEnemyActiveState(4) == true)
        {
            if (g_global.g_enemyState.GetEnemyDataSheet(4).GetEnemyShieldValue() <= 0)
            {
                // Turn it off
                sc_UIManager.GetEnemyShieldText(4).gameObject.SetActive(false);
                sc_UIManager.GetEnemyShieldIcon(4).SetActive(false);
                sc_UIManager.GetEnemyShieldOverlay(4).SetActive(false);
            }
            else
            {
                // Turn it on
                sc_UIManager.GetEnemyShieldText(4).gameObject.SetActive(true);
                sc_UIManager.GetEnemyShieldIcon(4).SetActive(true);
                sc_UIManager.GetEnemyShieldOverlay(4).SetActive(true);

                // Now refresh the setting of shields to make sure values update properly
                UpdateEnemyShieldUI(4);
            }
        }

        // Toggle Shields for enemy 5
        if (g_global.g_enemyState.GetEnemyActiveState(5) == true)
        {
            if (g_global.g_enemyState.GetEnemyDataSheet(5).GetEnemyShieldValue() <= 0)
            {
                // Turn it off
                sc_UIManager.GetEnemyShieldText(5).gameObject.SetActive(false);
                sc_UIManager.GetEnemyShieldIcon(5).SetActive(false);
                sc_UIManager.GetEnemyShieldOverlay(5).SetActive(false);
            }
            else
            {
                // Turn it on
                sc_UIManager.GetEnemyShieldText(5).gameObject.SetActive(true);
                sc_UIManager.GetEnemyShieldIcon(5).SetActive(true);
                sc_UIManager.GetEnemyShieldOverlay(5).SetActive(true);

                // Now refresh the setting of shields to make sure values update properly
                UpdateEnemyShieldUI(5);
            }
        }
    }

    public void TogglePlayerSelectorUI(bool _boolean)
    {
        sc_UIManager.GetPlayerCardSelector().SetActive(_boolean);
    }

    /// <summary>
    /// Toggle the Player Acid UI element
    /// True for _state is on, false is off
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    public void ToggleAcidPlayerUI(bool _state) // True for on, false for off
    {
        if (_state == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-poison"); // Change Sound Effect

            sc_UIManager.GetPlayerHealthBarObject().GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("acid");

        }
        else if (_state == false)
        {
            sc_UIManager.GetPlayerHealthBarObject().GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("acid");
        }
    }

    /// <summary>
    /// Toggle the Player Bleed UI element
    /// True for _state is on, false is off
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    public void ToggleBleedPlayerUI(bool _state) // True for on, false for off
    {
        if (_state == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-bleed");
            sc_UIManager.GetPlayerHealthBarObject().GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("bleed");

        }
        else if (_state == false)
        {
            sc_UIManager.GetPlayerHealthBarObject().GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("bleed");
        }
    }

    /// <summary>
    /// Toggle the Player Frail UI element
    /// True for _state is on, false is off
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    public void ToggleFrailtyPlayerUI(bool _state)
    {
        if (_state == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/attack-magic");
            sc_UIManager.GetPlayerHealthBarObject().GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("frail");
        }
        else if (_state == false)
        {
            sc_UIManager.GetPlayerHealthBarObject().GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("frail");
        }
    }

    /// <summary>
    /// Toggle the Player Resistant UI element
    /// True for _state is on, false is off
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    public void ToggleResistantPlayerUI(bool _state)
    {
        if (_state == true)
        { 
           FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-resist");
           sc_UIManager.GetPlayerHealthBarObject().GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("resist");
        }
        else if (_state == false)
        {
            sc_UIManager.GetPlayerHealthBarObject().GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("resist");
        }
    }

    /// <summary>
    /// Toggle the Acidic UI element for a given enemy
    /// True is on, false is off
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    /// /// <param name="_enemyCount"></param>
    public void ToggleAcidEnemyUI(bool _state, int _enemyCount) 
    {
        if (_enemyCount == 1) 
        {
            if(g_global.g_enemyState.GetEnemyActiveState(1) == true) 
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-poison");
                    sc_UIManager.GetEnemyHealthBarObject(1).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("acid");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(1).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("acid");
                }
            }
        }
        else if (_enemyCount == 2)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(2) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-poison");
                    sc_UIManager.GetEnemyHealthBarObject(2).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("acid");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(2).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("acid");
                }
            }
        }
        else if (_enemyCount == 3)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(3) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-poison");
                    sc_UIManager.GetEnemyHealthBarObject(3).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("acid");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(3).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("acid");
                }
            }
        }
        else if (_enemyCount == 4)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(4) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-poison");
                    sc_UIManager.GetEnemyHealthBarObject(4).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("acid");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(4).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("acid");
                }
            }
        }
        else if (_enemyCount == 5)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(5) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-poison");
                    sc_UIManager.GetEnemyHealthBarObject(5).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("acid");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(5).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("acid");
                }
            }
        }
    }

    /// <summary>
    /// Toggle the Bleed UI element for a given enemy
    /// True is on, false is off
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    /// /// <param name="_enemyCount"></param>
    public void ToggleBleedEnemyUI(bool _state, int _enemyCount)
    {
        if (_enemyCount == 1)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(1) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-bleed");
                    sc_UIManager.GetEnemyHealthBarObject(1).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("bleed");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(1).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("bleed");
                }
            }
        }
        else if (_enemyCount == 2)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(2) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-bleed");
                    sc_UIManager.GetEnemyHealthBarObject(2).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("bleed");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(2).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("bleed");
                }
            }
        }
        else if (_enemyCount == 3)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(3) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-bleed");
                    sc_UIManager.GetEnemyHealthBarObject(3).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("bleed");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(3).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("bleed");
                }
            }
        }
        else if (_enemyCount == 4)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(4) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-bleed");
                    sc_UIManager.GetEnemyHealthBarObject(4).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("bleed");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(4).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("bleed");
                }
            }
        }
        else if (_enemyCount == 5)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(5) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-bleed");
                    sc_UIManager.GetEnemyHealthBarObject(5).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("bleed");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(5).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("bleed");
                }
            }
        }
    }

    /// <summary>
    /// Toggle the Frality UI element for a given enemy
    /// True is on, false is off
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    /// /// <param name="_enemyCount"></param>
    public void ToggleFrailtyEnemyUI(bool _state, int _enemyCount)
    {
        if (_enemyCount == 1)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(1) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/attack-magic");
                    sc_UIManager.GetEnemyHealthBarObject(1).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("frail");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(1).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("frail");
                }
            }
        }
        else if (_enemyCount == 2)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(2) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/attack-magic");
                    sc_UIManager.GetEnemyHealthBarObject(2).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("frail");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(2).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("frail");
                }
            }
        }
        else if (_enemyCount == 3)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(3) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/attack-magic");
                    sc_UIManager.GetEnemyHealthBarObject(3).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("frail");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(3).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("frail");
                }
            }
        }
        else if (_enemyCount == 4)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(4) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/attack-magic");
                    sc_UIManager.GetEnemyHealthBarObject(4).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("frail");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(4).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("frail");
                }
            }
        }
        else if (_enemyCount == 5)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(5) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/attack-magic");
                    sc_UIManager.GetEnemyHealthBarObject(5).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("frail");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(5).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("frail");
                }
            }
        }
    }

    /// <summary>
    /// Toggle the Resistant UI element for a given enemy (_enemycount)
    /// True is on, false is off
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    /// <param name="_enemyCount"></param>
    public void ToggleResistantEnemyUI(bool _state, int _enemyCount)
    {
        if (_enemyCount == 1)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(1) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-resist");
                    sc_UIManager.GetEnemyHealthBarObject(1).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("resist");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(1).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("resist");
                }
            }
        }
        else if (_enemyCount == 2)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(2) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-resist");
                    sc_UIManager.GetEnemyHealthBarObject(2).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("resist");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(1).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("resist");
                }
            }
        }
        else if (_enemyCount == 3)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(3) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-resist");
                    sc_UIManager.GetEnemyHealthBarObject(3).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("resist");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(3).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("resist");
                }
            }
        }
        else if (_enemyCount == 4)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(4) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-resist");
                    sc_UIManager.GetEnemyHealthBarObject(4).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("resist");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(4).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("resist");
                }
            }
        }
        else if (_enemyCount == 5)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(5) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-resist");
                    sc_UIManager.GetEnemyHealthBarObject(5).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("resist");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(5).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("resist");
                }
            }
        }
    }

    /// <summary>
    /// Toggle the Stun UI element for a given enemy (_enemycount)
    /// True is on, false is off
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    /// <param name="_enemyCount"></param>
    public void ToggleStunEnemyUI (bool _state, int _enemyCount)
    {
        if (_enemyCount == 1)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(1) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-stun");
                    sc_UIManager.GetEnemyHealthBarObject(1).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("stun");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(1).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("stun");
                }
            }
        }
        else if (_enemyCount == 2)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(2) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-stun");
                    sc_UIManager.GetEnemyHealthBarObject(2).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("stun");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(2).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("stun");
                }
            }
        }
        else if (_enemyCount == 3)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(3) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-stun");
                    sc_UIManager.GetEnemyHealthBarObject(3).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("stun");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(3).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("stun");
                }
            }
        }
        else if (_enemyCount == 4)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(4) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-stun");
                    sc_UIManager.GetEnemyHealthBarObject(4).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("stun");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(4).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("stun");
                }
            }
        }
        else if (_enemyCount == 5)
        {
            if (g_global.g_enemyState.GetEnemyActiveState(5) == true)
            {
                if (_state == true)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/stat-stun");
                    sc_UIManager.GetEnemyHealthBarObject(5).GetComponent<S_HealthBarStatusEffects>().AddStatusEffect("stun");
                }
                else if (_state == false)
                {
                    sc_UIManager.GetEnemyHealthBarObject(5).GetComponent<S_HealthBarStatusEffects>().EndStatusEffect("stun");
                }
            }
        }
    }
}
