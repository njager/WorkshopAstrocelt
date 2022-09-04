using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ResourceGraphics : S_UIManager
{
    // g_global is inhereited from S_UIManager

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// EnergyTrackingUI update function
    /// Update the individual elements with new values as energy is generated, clear on turn end
    /// - Thoman and Josh
    /// </summary>
    public void EnergyTrackingUIUpdate()
    {
        // Update red energy
        en_tx_redText.text = "" + g_global.g_energyManager.i_redEnergy;
        // Update blue energy
        en_tx_redText.text = "" + g_global.g_energyManager.i_blueEnergy;
        //Update yellow energy
        en_tx_redText.text = "" + g_global.g_energyManager.i_yellowEnergy;
    }
}
