using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class S_ResourceGraphics : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    [Header("Script Connections")]
    [SerializeField] S_Global g_global;
    [SerializeField] S_UIManager sc_UIManager;

    [Header("Sprite References")]
    public SpriteRenderer defaultBonus;
    public SpriteRenderer blueBonusBar;
    public SpriteRenderer yellowBonusBar;
    public SpriteRenderer redBonusBar;
    public SpriteRenderer blueBonusIcon1;
    public SpriteRenderer blueBonusIcon2;
    public SpriteRenderer blueBonusIcon3;
    public SpriteRenderer yellowBonusIcon1;
    public SpriteRenderer yellowBonusIcon2;
    public SpriteRenderer yellowBonusIcon3;
    public SpriteRenderer redBonusIcon1;
    public SpriteRenderer redBonusIcon2;
    public SpriteRenderer redBonusIcon3;

    public int bonusTracker = 1;

    private void Awake()
    {
        g_global = S_Global.Instance;
        
    }

    public void Start()
    {
        resetBonusTracker();
    }

    void Update()
    {
        EnergyTrackingUIUpdate(); // Temporary, eventually make S_EnergyManager update it on changing of the energy amounts
        UpdateResourceBarGraphics();
        ConstellationTracker();
    }

    public void resetBonusTracker()
    {
        defaultBonus.enabled = true;
        blueBonusBar.enabled = false;
        yellowBonusBar.enabled = false;
        redBonusBar.enabled = false;

        blueBonusIcon1.enabled = false;
        blueBonusIcon2.enabled = false;
        blueBonusIcon3.enabled = false;

        yellowBonusIcon1.enabled = false;
        yellowBonusIcon2.enabled = false;
        yellowBonusIcon3.enabled = false;

        redBonusIcon1.enabled = false;
        redBonusIcon2.enabled = false;
        redBonusIcon3.enabled = false;
    }

    /////////////////////////////------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Resource Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// EnergyTrackingUI update function
    /// Update the individual elements with new values as energy is generated, clear on turn end
    /// - Thoman and Josh
    /// </summary>
    public void EnergyTrackingUIUpdate()
    {
        // Update red energy
        g_global.g_UIManager.GetRedEnergyTrackerText().text = "" + g_global.g_energyManager.GetRedEnergyInt();
        // Update blue energy
        g_global.g_UIManager.GetBlueEnergyTrackerText().text = ""  + g_global.g_energyManager.GetBlueEnergyInt();
        //Update yellow energy
        g_global.g_UIManager.GetYellowEnergyTrackerText().text = ""  + g_global.g_energyManager.GetYellowEnergyInt();
    }

    public void UpdateResourceBarGraphics() 
    {
        // Set resource bar text
        sc_UIManager.SetPlayerResourceHealthText(g_global.g_playerAttributeSheet.GetPlayerHealthValue(), g_global.g_playerAttributeSheet.GetPlayerMaxHealthValue());
    }

    /// <summary>
    /// Constellation Tracker UI function 
    /// -THOMAN
    /// </summary>
    public void ConstellationTracker()
    {
        int current = g_global.g_ConstellationManager.ls_curConstellation.Count();
        if (current <= 0)
        {
            g_global.g_UIManager.GetConstellationUI().text = "" + 0 + "/7";           
        }
        else
        {
            g_global.g_UIManager.GetConstellationUI().text = "" + (current - 1) + "/7";
        }
        
    }

    public void BonusTracker(S_StarClass _star)
    {
       if (_star.colorType == "red")
        {
            defaultBonus.enabled = false;
            blueBonusBar.enabled = false;
            yellowBonusBar.enabled = false;
            redBonusBar.enabled = true;

            blueBonusIcon1.enabled = false;
            blueBonusIcon2.enabled = false;
            blueBonusIcon3.enabled = false;

            yellowBonusIcon1.enabled = false;
            yellowBonusIcon2.enabled = false;
            yellowBonusIcon3.enabled = false;

            redBonusIcon1.enabled = true;
            bonusTracker++;
            if (_star.colorType == "red" && bonusTracker == 2)
            {
                redBonusIcon2.enabled = true;
            }
            else { bonusTracker = 1; resetBonusTracker(); }
            if (_star.colorType == "red" && bonusTracker == 3)
            {
                redBonusIcon3.enabled = true;
            }
            else { bonusTracker = 1; resetBonusTracker(); }
        }

        if (_star.colorType == "yellow")
        {
            defaultBonus.enabled = false;
            blueBonusBar.enabled = false;
            yellowBonusBar.enabled = true;
            redBonusBar.enabled = false;

            blueBonusIcon1.enabled = false;
            blueBonusIcon2.enabled = false;
            blueBonusIcon3.enabled = false;

            yellowBonusIcon1.enabled = true;
            bonusTracker++;
            

            redBonusIcon1.enabled = false;
            redBonusIcon2.enabled = false;
            redBonusIcon3.enabled = false;
            if(_star.colorType == "yellow" && bonusTracker == 2)
            {
                yellowBonusIcon2.enabled = true;
            }
            else { bonusTracker = 1; resetBonusTracker(); }
            if (_star.colorType == "yellow" && bonusTracker == 3)
            {
                yellowBonusIcon3.enabled = true;
            }
            else { bonusTracker = 1; resetBonusTracker(); }
        }
        if (_star.colorType == "blue")
        {
            defaultBonus.enabled = false;
            blueBonusBar.enabled = true;
            yellowBonusBar.enabled = false;
            redBonusBar.enabled = false;

            blueBonusIcon1.enabled = true;
            blueBonusIcon2.enabled = false;
            blueBonusIcon3.enabled = false;
            bonusTracker++;

            yellowBonusIcon1.enabled = false;
            yellowBonusIcon2.enabled = false;
            yellowBonusIcon3.enabled = false;

            redBonusIcon1.enabled = false;
            redBonusIcon2.enabled = false;
            redBonusIcon3.enabled = false;

            if (_star.colorType == "blue" && bonusTracker == 2)
            {
                blueBonusIcon2.enabled = true;
            }
            else { bonusTracker = 1; resetBonusTracker(); }
            if (_star.colorType == "blue" && bonusTracker == 3)
            {
                blueBonusIcon3.enabled = true;
            }
            else { bonusTracker = 1; resetBonusTracker(); }

        }
    }
}
