using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ResourceGraphics : MonoBehaviour
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

    void Update()
    {
        EnergyTrackingUIUpdate(); // Temporary, eventually make S_EnergyManager update it on changing of the energy amounts
        UpdateResourceBarGraphics();
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
}
