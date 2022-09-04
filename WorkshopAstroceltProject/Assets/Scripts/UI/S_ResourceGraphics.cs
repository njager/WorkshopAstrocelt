using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ResourceGraphics : S_UIManager
{
    // g_global is inhereited from S_UIManager, as is Monobehavior

    void Update()
    {
        EnergyTrackingUIUpdate(); // Temporary, eventually make S_EnergyManager update it on changing of the energy amounts
    }

    /// <summary>
    /// EnergyTrackingUI update function
    /// Update the individual elements with new values as energy is generated, clear on turn end
    /// - Thoman and Josh
    /// </summary>
    public void EnergyTrackingUIUpdate()
    {
        // Update red energy
        GetRedEnergyTrackerText().text = "" + g_global.g_energyManager.GetRedEnergyInt();
        // Update blue energy
        GetBlueEnergyTrackerText().text = "" + g_global.g_energyManager.GetBlueEnergyInt();
        //Update yellow energy
        GetYellowEnergyTrackerText().text = "" + g_global.g_energyManager.GetYellowEnergyInt();
    }
}
