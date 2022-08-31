using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;

public class S_TurnManager : MonoBehaviour
{
    private S_Global g_global;

    [Header("Initial Turn Bools")]
    public bool p_b_playerInitialTurn = true;
    public bool e_b_enemyInitialTurn = false;

    [Header("Turn Skips")]
    public bool p_b_playerTurnSkipped;
    public bool e_b_enemy1TurnSkipped;
    public bool e_b_enemy2TurnSkipped;
    public bool e_b_enemy3TurnSkipped;
    public bool e_b_enemy4TurnSkipped;
    public bool e_b_enemy5TurnSkipped;

    [Header("Coroutine Bool Check")]
    public bool e_b_enemyIsActive;

    /// <summary>
    /// Fetch the global script and assign the global states to the inital choice
    /// - Riley & Josh
    /// </summary>
    void Awake()
    {
        g_global = S_Global.Instance;
        g_global.g_b_playerTurn = p_b_playerInitialTurn;
        g_global.g_b_enemyTurn = e_b_enemyInitialTurn;

        // Make sure turn skips are false
        p_b_playerTurnSkipped = false;
        e_b_enemy1TurnSkipped = false;
        e_b_enemy2TurnSkipped = false;
        e_b_enemy3TurnSkipped = false;
        e_b_enemy4TurnSkipped = false;
        e_b_enemy5TurnSkipped = false;

        g_global.g_enemyState.EnemyActionCheck();
    }

    /// <summary>
    /// This the function that gets triggered when the end turn button is pressed. 
    /// It is the start of the chain and leads into enemystate change
    /// -Josh and Riley
    /// </summary>
    public void EndTurn()
    {
        //Debug.Log("pressed");
        if (g_global.g_altar.Get_b_spawningCardballs() == false)
        {
            //set here to prevent queueing up end turns
            g_global.g_altar.Set_b_spawningCardballs(true);

            if (g_global.g_b_enemyTurn == true)
            {
                Debug.Log("Not your turn!");
                return;
            }
            else
            {
                g_global.g_ConstellationManager.DeleteWholeCurConstellation();
                StartCoroutine(EnemyPhase()); //Then change the enemies state
            }
        }
        else
        {
            Debug.Log("pressed when spawning cardballs");
            return;
        }
    }

    /// <summary>
    /// Remove shielding as it's supposed to at end of turn
    /// </summary>
    private void RemoveEnemyShielding()
    {
        //Reset Enemy
        if (g_global.g_enemyAttributeSheet1 != null) // Strip Enemy 1 of Shielding
        {
            g_global.g_enemyAttributeSheet1.e_i_shield = 0;
        }

        if (g_global.g_enemyAttributeSheet2 != null) // Strip Enemy 2 of Shielding
        {
            g_global.g_enemyAttributeSheet2.e_i_shield = 0;
        }

        if (g_global.g_enemyAttributeSheet3 != null) // Strip Enemy 3 of Shielding
        {
            g_global.g_enemyAttributeSheet3.e_i_shield = 0;
        }

        if (g_global.g_enemyAttributeSheet4 != null) // Strip Enemy 4 of Shielding
        {
            g_global.g_enemyAttributeSheet4.e_i_shield = 0;
        }

        if (g_global.g_enemyAttributeSheet5 != null) // Strip Enemy 5 of Shielding
        {
            g_global.g_enemyAttributeSheet5.e_i_shield = 0;
        }
    }

    /// <summary>
    /// Explicit function for the beginning of the Enemy Phase
    /// - Josh
    /// </summary>
    public void EnemyPhaseBegin()
    {
        // Update Active Enemies
        g_global.g_enemyState.UpdateActiveEnemies();

        // Line removal
        g_global.g_DrawingManager.b_lineDeletionCompletion = false;
        StartCoroutine(g_global.g_DrawingManager.LineDeletion());

        // Toggle day
        g_global.g_backgroundManager.ChangeBackground(1);

        //change all the things that need to be changed for the enemies turn
        g_global.g_energyManager.ClearEnergy();
        g_global.g_enemyState.EnemyActionCheck();
        RemoveEnemyShielding(); //Remove all enemy shields first before applying new ones


        // Brighten alpha for intent icons 
        foreach (S_Enemy _enemy in g_global.e_ls_enemyList.ToList())
        {
            _enemy.IncreaseIntentIconAlpha();
        }
    }

    /// <summary>
    /// New enemy phase execution loop
    /// - Josh
    /// </summary>
    /// <returns></returns>
    public IEnumerator EnemyPhase()
    {
        //Switch turns
        g_global.g_b_playerTurn = false;
        g_global.g_b_enemyTurn = true;

        // Enemy Phase Begin
        EnemyPhaseBegin();

        foreach (S_Enemy _enemy in g_global.g_ls_activeEnemies.ToList())
        {
            e_b_enemyIsActive = false;
            StartCoroutine(_enemy.EnemyTurnAction(_enemy.e_i_enemyCount));

            yield return e_b_enemyIsActive = true;
            //Debug.Log("Triggered for enemy " + _enemy.e_i_enemyCount + " - log!");
        }

        //Debug.Log("Made it past the event stack");

        // Enemy Phase End
        EnemyPhaseEnd();
    }

    /// <summary>
    /// Explicit function for the end of the whole enemy phase
    /// - Josh
    /// </summary>
    public void EnemyPhaseEnd()
    {
        // Declare player's turn for debug
        g_global.g_enemyState.DeclareCurrentTurn(0);

        // Load the next icon
        foreach (S_Enemy _enemy in g_global.e_ls_enemyList.ToList())
        {
            _enemy.ChangeIcon();
        }

        g_global.g_enemyState.EnemyStatusEffectDecrement();

        //Clear Popups
        StartCoroutine(g_global.g_popupManager.ClearAllPopups());

        //Check if the player turn starts
        PlayerTurnCheck();
    }

    private void PlayerTurnCheck()
    {
        if (g_global.g_b_playerTurn == false && p_b_playerTurnSkipped)
        {
            //decrement the player's status effect
            g_global.g_playerState.PlayerStatusEffectDecrement();

            Debug.Log("Player Turn Skipped");
            StartCoroutine(EnemyPhase());
        }
        else if (g_global.g_b_playerTurn == false)
        {
            //decrement the player's status effect
            g_global.g_playerState.PlayerStatusEffectDecrement();

            PlayerStateChange();
        }
    }

    /// <summary>
    /// Change the state to the player turn. 
    /// trigger the map generation for the new player turn
    /// Reset the selector so the enemy has to be selected again
    /// - Riley & Josh
    /// </summary>
    public void PlayerStateChange()
    {
        //Debug.Log("Triggerd");
        //clear the card balls and deal a new hand
        StartCoroutine(g_global.g_altar.ClearCardballPrefabs(true));

        //Turn to night
        g_global.g_backgroundManager.ChangeBackground(0);

        //Reset player
        g_global.g_playerAttributeSheet.p_i_shield = 0;

        //Map Switching
        g_global.g_mapManager.RandomMapSelector();

        //switch turns
        g_global.g_b_playerTurn = true;
        g_global.g_b_enemyTurn = false;
    }
}