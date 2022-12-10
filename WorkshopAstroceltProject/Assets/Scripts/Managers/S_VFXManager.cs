using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_VFXManager : MonoBehaviour
{
    [Header("Global Track")]
    [SerializeField] S_Global g_global;

    [Header("Enemy Hurts Player")]
    [SerializeField] ParticleSystem pe_enemyAttacksPlayer;

    [Header("Player Hurts Enemy")]
    [SerializeField] ParticleSystem pe_playerAttacksEnemy;

    [Header("Player Shields")]
    [SerializeField] ParticleSystem pe_playerShields;

    [Header("Enemy Shields")]
    [SerializeField] ParticleSystem pe_enemyShields;

    [Header("Enemy Special - General")]
    [SerializeField] ParticleSystem pe_enemySpecialGeneral;

    [Header("Red Card Spawn")]
    [SerializeField] ParticleSystem pe_redCardSpawn;

    [Header("Blue Card Spawn")]
    [SerializeField] ParticleSystem pe_blueCardSpawn;

    [Header("Yellow Card spawn")]
    [SerializeField] ParticleSystem pe_yellowCardSpawn;

    [Header("White Card Spawn")]
    [SerializeField] ParticleSystem pe_whiteCardSpawn;

    [Header("Enemy Died")]
    [SerializeField] ParticleSystem pe_enemyDied;

    [Header("Reward Scene")]
    [SerializeField] ParticleSystem pe_rewardScene;

    [Header("Reward Chosen")]
    [SerializeField] ParticleSystem pe_rewardChosen;

    [Header("End Turn Clicked")]
    [SerializeField] ParticleSystem pe_endTurnClicked;

    [Header("Star Connected")]
    [SerializeField] ParticleSystem pe_starConnected;

    [Header("Constellation Completed")]
    [SerializeField] ParticleSystem pe_constellationCompleted;

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    /// <summary>
    /// Card spawn particle effect triggers
    /// - Josh
    /// </summary>
    /// <param name="_color"></param>
    public void TriggerParticleEffects(string _color)
    {
        if (_color == "blue")
        {
            pe_blueCardSpawn.Play();
        }
        else if (_color == "red")
        {
            pe_redCardSpawn.Play();
        }
        else if (_color == "yellow")
        {
            pe_yellowCardSpawn.Play();
        }
        else if (_color == "white")
        {
            pe_whiteCardSpawn.Play();
        }
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
        return pe_enemyAttacksPlayer;
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
        return pe_playerShields;
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
        return pe_enemyShields;
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
        return pe_enemySpecialGeneral;
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
        return pe_redCardSpawn;
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
        return pe_blueCardSpawn;
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
        return pe_yellowCardSpawn;
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
        return pe_whiteCardSpawn;
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
        return pe_enemyDied;
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
        return pe_rewardScene;
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
        return pe_rewardChosen;
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
        return pe_rewardChosen;
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
        return pe_starConnected;
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
        return pe_constellationCompleted;
    }
}
