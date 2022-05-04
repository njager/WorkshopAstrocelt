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
    public bool p_b_stunned;
    public bool p_b_bleeding;
    public bool p_b_empowered;
    public bool p_b_lucky;
    public bool p_b_resistant;
    public bool p_b_burned;
    public bool p_b_shocked;

    [Header("Particle Effect")]
    public ParticleSystem p_pe_blood;

    [Header("Animatior")]
    public Animator p_a_animator;

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
        p_i_health = 35;
        p_i_healthMax = 35;

        p_i_shield = 0;
        p_i_shieldMax = 100;

        p_f_playerEnergyGenerationRate = 1.0f;

        //Status Effects
        p_b_bleeding = false;
        p_b_resistant = false;
        p_b_stunned = false;
    }
}
