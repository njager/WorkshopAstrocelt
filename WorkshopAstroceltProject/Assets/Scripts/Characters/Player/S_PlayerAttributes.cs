using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerAttributes : MonoBehaviour
{
    private S_Global g_global; 

    [Header("Player Attributes")]
    [SerializeField] int p_i_health;
    [SerializeField] int p_i_maxHealth; 

    [SerializeField] int p_i_shield;
    [SerializeField] int p_i_maxShield;

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

    [Header("Particle Effect")]
    public ParticleSystem p_pe_blood;
    public ParticleSystem p_pe_shield;

    [Header("Animatiors")]
    public Animator p_a_AttackAnimator;
    public Animator p_a_DamagedAnimator;

    void Start()
    {
        g_global = S_Global.Instance;

        S_GameManager _gameManager = S_GameManager.Instance;

        // load some sort of array to global and this script
        g_global.g_playerAttributeSheet = this;

        SetPlayerHealthValue(_gameManager.i_playerHealth);
        p_i_maxHealth = _gameManager.i_healthMax;
        p_i_shield = _gameManager.i_shield;
        p_i_maxShield = _gameManager.i_shieldMax;
        p_f_playerEnergyGenerationRate = _gameManager.f_playerEnergyGenerationRate;

        g_global.g_player.PlayerValuesLimitCheck();
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the int value from S_PlayerAttributes.p_i_shield
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerAttributes.p_i_shield 
    /// </returns>
    public int GetPlayerShieldValue()
    {
        return p_i_shield;
    }

    /// <summary>
    /// Return the int value from S_PlayerAttributes.p_i_maxShield
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerAttributes.p_i_maxShield
    /// </returns>
    public int GetPlayerMaxShieldValue()
    {
        return p_i_maxShield;
    }

    /// <summary>
    /// Return the int value from S_PlayerAttributes.p_i_health
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerAttributes.p_i_health
    /// </returns>
    public int GetPlayerHealthValue()
    {
        return p_i_health;
    }

    /// <summary>
    /// Return the int value from S_PlayerAttributes.p_i_maxHealth
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PlayerAttributes.p_i_maxHealth
    /// </returns>
    public int GetPlayerMaxHealthValue()
    {
        return p_i_maxHealth;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the int value of S_PlayerAttributes.p_i_shield
    /// - Josh
    /// </summary>
    /// <param name="_shieldValue"></param>
    public void SetPlayerShieldValue(int _shieldValue)
    {
        p_i_shield = _shieldValue;
    }

    /// <summary>
    /// Set the int value of S_PlayerAttributes.p_i_health
    /// - Josh
    /// </summary>
    /// <param name="_healthValue"></param>
    public void SetPlayerHealthValue(int _healthValue)
    {
        p_i_health = _healthValue;
    }
}
