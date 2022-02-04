using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerAttributes : MonoBehaviour
{
    private S_Global g_global; 

    [Header("Player Attributes")]
    public int p_i_health;
    public int p_i_healthMax; 

    public int p_i_shield;
    public int p_i_shieldMax;

    public float p_f_playerEnergyGenerationRate;

    //Modify with new structure as needed
    [Header("Relics Slotted")]
    public bool p_b_playerHasRelicSlotted;

    //Modify with new structure as needed
    [Header("Upgrades")]
    public bool p_b_playerHasUpgrades;

    //Modify with new structure as needed
    [Header("Constellation Effects")]
    public bool p_b_playerHasConstellationEffects;

    [Header("Status Effects")]
    public bool p_b_poisoned;
    public bool p_b_stunned;
    public bool p_b_bleeding;
 
    void Start()
    {
        p_b_bleeding = false;
        p_b_poisoned = false;
        p_b_stunned = false;

        g_global = S_Global.g_instance; 

        if(g_global.g_i_sceneIndex == 0)
        {
            g_global.g_playerAttributeSheet = this; 
        }
        else
        {
            // load some sort of array to global and this script
            g_global.g_playerAttributeSheet = this; 
        }
    }

    public void FirstSceneVariables()
    {

    }
}
