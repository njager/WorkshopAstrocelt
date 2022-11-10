using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_VFXManager : MonoBehaviour
{
    [Header("Global Track")]
    [SerializeField] S_Global g_global;

    [Header("Enemy Hurts Player")]
    [SerializeField] ParticleSystem a_enemyAttacksPlayer;

    [Header("Player Hurts Enemy")]
    [SerializeField] ParticleSystem a_playerAttacksEnemy;

    [Header("Player Shields")]
    [SerializeField] ParticleSystem a_playerShields;

    [Header("Enemy Shields")]
    [SerializeField] ParticleSystem a_enemyShields;

    [Header("Enemy Special - General")]
    [SerializeField] ParticleSystem a_enemySpecialGeneral;

    [Header("Red Card Spawn")]
    [SerializeField] ParticleSystem a_redCardSpawn;

    [Header("Blue Card Spawn")]
    [SerializeField] ParticleSystem a_blueCardSpawn;

    [Header("Yellow Card spawn")]
    [SerializeField] ParticleSystem a_yellowCardSpawn;

    [Header("White Card Spawn")]
    [SerializeField] ParticleSystem a_whiteCardSpawn;

    [Header("Enemy Died")]
    [SerializeField] ParticleSystem a_enemyDied;

    [Header("Reward Scene")]
    [SerializeField] ParticleSystem a_rewardScene;

    [Header("Reward Chosen")]
    [SerializeField] ParticleSystem a_rewardChosen;

    [Header("End Turn Clicked")]
    [SerializeField] ParticleSystem a_endTurnClicked;

    [Header("Star Connected")]
    [SerializeField] ParticleSystem a_starConnected;

    [Header("Constellation Completed")]
    [SerializeField] ParticleSystem a_constellationCompleted;

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_enemyAttacksPlayer
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_enemyAttacksPlayer
    /// </returns>
    public ParticleSystem GetEnemyAttackedPlayerParticle()
    {
        return a_enemyAttacksPlayer;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_playerShields
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_playerShields
    /// </returns>
    public ParticleSystem PlayerShieldsParticle()
    {
        return a_playerShields;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_enemyShields
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_enemyShields
    /// </returns>
    public ParticleSystem EnemyShieldsParticle()
    {
        return a_enemyShields;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_enemySpecialGeneral
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_enemySpecialGeneral
    /// </returns>
    public ParticleSystem GeneralEnemySpecialParticle()
    {
        return a_enemySpecialGeneral;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_redCardSpawn
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_redCardSpawn
    /// </returns>
    public ParticleSystem RedCardSpawnParticle()
    {
        return a_redCardSpawn;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_blueCardSpawn
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_blueCardSpawn
    /// </returns>
    public ParticleSystem BlueCardSpawnParticle()
    {
        return a_blueCardSpawn;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_yellowCardSpawn
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_yellowCardSpawn
    /// </returns>
    public ParticleSystem YellowCardSpawnParticle()
    {
        return a_yellowCardSpawn;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_whiteCardSpawn
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_whiteCardSpawn
    /// </returns>
    public ParticleSystem WhiteCardSpawnParticle()
    {
        return a_whiteCardSpawn;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_enemyDied
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_enemyDied
    /// </returns>
    public ParticleSystem EnemyDied()
    {
        return a_enemyDied;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_rewardScene
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_rewardScene
    /// </returns>
    public ParticleSystem RewardScene()
    {
        return a_rewardScene;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_rewardChosen
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_rewardChosen
    /// </returns>
    public ParticleSystem RewardChosen()
    {
        return a_rewardChosen;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_endTurnClicked
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_endTurnClicked
    /// </returns>
    public ParticleSystem EndTurnClicked()
    {
        return a_rewardChosen;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_starConnected
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_starConnected
    /// </returns>
    public ParticleSystem StarConnected() 
    {
        return a_starConnected;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_constellationCompleted
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_constellationCompleted
    /// </returns>
    public ParticleSystem ConstellationCompleted() 
    {
        return a_constellationCompleted;
    }
}
