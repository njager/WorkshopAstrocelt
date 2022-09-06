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

    void Start()
    {
        g_global = S_Global.Instance;

        S_GameManager _gameManager = S_GameManager.Instance;

        // load some sort of array to global and this script
        g_global.g_playerAttributeSheet = this;

        p_i_health = _gameManager.i_playerHealth;
        p_i_healthMax = _gameManager.i_healthMax;
        p_i_shield = _gameManager.i_shield;
        p_i_shieldMax = _gameManager.i_shieldMax;
        p_f_playerEnergyGenerationRate = _gameManager.f_playerEnergyGenerationRate;
        p_b_bleeding = _gameManager.b_bleeding;
        p_b_resistant = _gameManager.b_resistant;
        p_b_stunned = _gameManager.b_stunned;
    }

}
