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
    public bool e_b_empowered;
    public bool e_b_lucky;
    public bool e_b_restrained;
    public bool e_b_burned;
    public bool e_b_shocked;

    void Awake()
    {
        g_global = S_Global.Instance; 

        if(g_global.g_i_sceneIndex == 0)
        {
            FirstSceneVariables();
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
        // PlayerConstants
        p_i_health = 100;
        p_i_healthMax = 100;

        p_i_shield = 0;
        p_i_shieldMax = 10;

        p_f_playerEnergyGenerationRate = 1.0f;

        //Status Effects
        p_b_bleeding = false;
        p_b_poisoned = false;
        p_b_stunned = false;
    }
}
