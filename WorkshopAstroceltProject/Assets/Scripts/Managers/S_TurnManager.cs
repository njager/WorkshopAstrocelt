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

    [Header("Coroutine Bool Check")]
    public bool e_b_enemyIsActive;

    [Header("Camera Reference")]
    public Camera cam;



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
        g_global.g_enemyState.SetEnemySkipTurnState(false, 1);
        g_global.g_enemyState.SetEnemySkipTurnState(false, 2);
        g_global.g_enemyState.SetEnemySkipTurnState(false, 3);
        g_global.g_enemyState.SetEnemySkipTurnState(false, 4);
        g_global.g_enemyState.SetEnemySkipTurnState(false, 5);

        g_global.g_enemyState.EnemyActionCheck();
    }

    /// <summary>
    /// This the function that gets triggered when the end turn button is pressed. 
    /// It is the start of the chain and leads into enemystate change
    /// -Josh and Riley
    /// </summary>
    public void EndTurn()
    {
        if (g_global.g_b_enemyTurn == true)
        {
            Debug.Log("Not your turn!");
            return;
        }
        else
        {
            //Debug.Log("pressed");
            if (g_global.g_altar.GetCardballsSpawnedBool() == true && g_global.g_ConstellationManager.GetStarLockOutBool() == true)
            {
                //set here to prevent queueing up end turns
                //g_global.g_altar.Set_b_spawningCardballs(true);

                //delete first so that making constellation gets set to false
                g_global.g_ConstellationManager.DeleteWholeCurConstellation();

                //Turn off making constellation bool so no funky errors
                g_global.g_ConstellationManager.SetMakingConstellation(false);

                g_global.g_altar.SetCardballsSpawnedBool(false);

                //lock out the player from drawing
                g_global.g_ConstellationManager.SetStarLockOutBool(false);


                //clear the energy
                g_global.g_energyManager.ClearEnergy();

                StartCoroutine(EnemyPhase()); //Then change the enemies state
            }
            else
            {
                Debug.Log("pressed when spawning cardballs");
                return;
            }
        }
    }

    /// <summary>
    /// Strip the enemies of their shielding at the end of the turn
    /// - Josh
    /// </summary>
    private void RemoveEnemyShielding()
    {
        foreach (S_Enemy _enemy in g_global.g_ls_activeEnemies.ToList()) 
        {
            _enemy.e_sc_enemyAttributes.SetEnemyShield(0);
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
        g_global.g_backgroundManager.ChangeBackground(0);

        //change all the things that need to be changed for the enemies turn
        //g_global.g_energyManager.ClearEnergy();
        g_global.g_enemyState.EnemyActionCheck();
        RemoveEnemyShielding(); //Remove all enemy shields first before applying new ones


        // Brighten alpha for intent icons 
        foreach (S_Enemy _enemy in g_global.g_ls_activeEnemies.ToList())
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
        foreach (S_Enemy _enemy in g_global.g_ls_activeEnemies.ToList())
        {
            _enemy.ChangeIcon();
        }

        g_global.g_UIManager.sc_characterGraphics.EnemyShieldingUIToggle();

        // Enemy State stuff
        g_global.g_enemyState.EnemyStatusEffectDecrement();

        g_global.g_enemyState.ResetMagicianAbility();

        //Clear Popups
        StartCoroutine(g_global.g_popupManager.ClearAllPopups());

        //Check if the player turn starts
        PlayerTurnCheck();
    }

    private void PlayerTurnCheck()
    {
        if (g_global.g_b_playerTurn == false)
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
        //g_global.g_player.playerSprite.transform.DOShakePosition(1f, new Vector3(0, 5, 5), 10, 0f, true, false);
        //Debug.Log("Triggerd");
        //clear the card balls and deal a new hand
        StartCoroutine(g_global.g_altar.ClearCardballPrefabs(true));
        
        //Turn to night
        g_global.g_backgroundManager.ChangeBackground(0);

        //Reset player
        g_global.g_playerAttributeSheet.SetPlayerShieldValue(0);

        g_global.g_UIManager.sc_characterGraphics.PlayerShieldingUIToggle();

        //Map Switching
        g_global.g_mapManager.RandomMapSelector();

        //reset the node star chosen when the player passes the turn
        g_global.g_ConstellationManager.b_nodeStarChosen = false;

        //switch turns
        g_global.g_b_playerTurn = true;
        g_global.g_b_enemyTurn = false;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the bool value of S_TurnManager.e_b_enemyIsActive;
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_TurnManager.e_b_enemyIsActive
    /// </returns>
    public bool GetEnemyActiveBool()
    {
        return e_b_enemyIsActive;
    }
}
