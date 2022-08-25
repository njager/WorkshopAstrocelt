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
    private float spawnTimer = 1f;

    [Header("Initial Turn Bools")]
    public bool b_playerInitialTurn = true;
    public bool b_enemyInitialTurn = false;

    [Header("Turn Skips")]
    public bool playerTurnSkipped;
    public bool enemy1TurnSkipped;
    public bool enemy2TurnSkipped;
    public bool enemy3TurnSkipped;
    public bool enemy4TurnSkipped;
    public bool enemy5TurnSkipped;

    [Header("Enemy Turn Timer Int")]
    public int e_i_timerChecks;

    /// <summary>
    /// Fetch the global script and assign the global states to the inital choice
    /// - Riley & Josh
    /// </summary>
    void Awake()
    {
        g_global = S_Global.Instance;
        g_global.g_b_playerTurn = b_playerInitialTurn;
        g_global.g_b_enemyTurn = b_enemyInitialTurn;

        // Make sure turn skips are false
        playerTurnSkipped = false;
        enemy1TurnSkipped = false;
        enemy2TurnSkipped = false;
        enemy3TurnSkipped = false;
        enemy4TurnSkipped = false;
        enemy5TurnSkipped = false;

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
        if(g_global.g_altar.b_spawningCardballs == false)
        {
            //set here to prevent queueing up end turns
            g_global.g_altar.b_spawningCardballs = true;

            if (g_global.g_b_enemyTurn == true)
            {
                Debug.Log("Not your turn!");
                return;
            }
            else
            {
                g_global.g_ConstellationManager.DeleteWholeCurConstellation();
                foreach (S_Enemy _enemy in g_global.e_ls_enemyList.ToList())
                {
                    _enemy.SetDelegate();
                }
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
    /// Just a way to make sure that there's a function to fit within the delegate.
    /// Sort of cheating the system
    ///  - Josh
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public void OverallEnemyTurn(int _enemyNum)
    {
        Debug.Log("OverallEnemyTurn triggered for test case!");
        g_global.g_turnManager.EnemyTurnAction(_enemyNum);
    }


    /// <summary>
    /// The turn timer deteremines execution between the enemies turns,
    /// Was testing to see if it should be stored as a delegate in the delegate list as it fits the mold
    /// </summary>
    /// <param name="_time"></param>
    /// <returns></returns>
    public IEnumerator TurnTimer(int _time)
    {
        yield return new WaitForSecondsRealtime(_time);
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

        foreach(S_Enemy _enemy in g_global.g_ls_activeEnemies.ToList())
        {
            e_i_timerChecks -= 1;
            EnemyPhaseEventTrigger(_enemy.e_i_enemyCount);

            StartCoroutine(TurnTimer(2));
        }
        
        Debug.Log("Made it past the event stack");


        int x = g_global.g_ls_activeEnemies.Count * 2;
        yield return new WaitForSeconds(x);

        // Enemy Phase End
        EnemyPhaseEnd();
    }

    /// <summary>
    /// Explicit function for the beginning of the Enemy Phase
    /// - Josh
    /// </summary>
    public void EnemyPhaseBegin()
    {
        // Update Active Enemies
        g_global.g_enemyState.UpdateActiveEnemies();

        e_i_timerChecks = g_global.g_ls_activeEnemies.Count;

        // Have each enemy set their state
        foreach(S_Enemy _activeEnemy in g_global.g_ls_activeEnemies.ToList())
        {
            _activeEnemy.SetTurnState();
            Debug.Log("Setting Turn State");
        }

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
    /// Explicit function for the end of the whole enemy phase
    /// - Josh
    /// </summary>
    public void EnemyPhaseEnd()
    {
        // Declare player's turn for debug
        DeclareCurrentTurn(0);

        // Load the next icon
        foreach (S_Enemy _enemy in g_global.e_ls_enemyList.ToList())
        {
            _enemy.ChangeIcon();
        }

        g_global.g_enemyState.EnemyStatusEffectDecrement();

        S_EventManager.ClearEnemyEvents();

        //Clear Popups
        StartCoroutine(g_global.g_popupManager.ClearAllPopups());

        //Check if the player turn starts
        PlayerTurnCheck();
    }

    private void PlayerTurnCheck()
    {
        if (g_global.g_b_playerTurn == false && playerTurnSkipped)
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
        Debug.Log("Tiriggerd");
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


    /// <summary>
    /// Function for enemy action within their turn phase to be triggered
    /// - Josh
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public bool EnemyTurnAction(int _enemyNum)
    {
        if(!g_global.g_enemyState.EnemySkipTurnCheck(_enemyNum))
        {
            // Declare Turn for UI
            DeclareCurrentTurn(_enemyNum);

            //Do your action
            if (g_global.g_turnManager.GetEnemyAction(_enemyNum) == 6) // Check shielding
            {
                g_global.g_turnManager.g_global.g_enemyState.GetEnemyScript(_enemyNum).EnemyShielded(g_global.g_turnManager.g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_str_enemyType, g_global.g_turnManager.g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_i_shieldMax);
            }
            else if (g_global.g_turnManager.GetEnemyAction(_enemyNum) == 7) // Check attacking
            {
                //play enemy animation
                g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_a_animator.Play("attack");

                g_global.g_player.PlayerAttacked(g_global.g_turnManager.g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_i_enemyDamageValue);

                //Then play sounds
                if (g_global.g_turnManager.g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_str_enemyType == "Beast")
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
                }
                else if (g_global.g_turnManager.g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_str_enemyType == "Magician")
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
                }
                else if (g_global.g_turnManager.g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_str_enemyType == "Brawler")
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
                }
            }
            else if (g_global.g_turnManager.GetEnemyAction(_enemyNum) == 8) // Check special ability
            {
                g_global.g_turnManager.g_global.g_enemyState.GetEnemyScript(_enemyNum).EnemySpecialAbility(g_global.g_turnManager.g_global.g_enemyState.GetEnemyDataSheet(_enemyNum).e_str_enemyType);
            }

            return true;
        }
        else
        {
            Debug.Log("Enemy " + _enemyNum + "'s turn is skipped!");
            return true;
        }
    }

    /// <summary>
    /// 6 for shield,
    /// 7 for attack,
    /// 8 for Special Ability
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public int GetEnemyAction(int _enemyNum)
    {
        if(_enemyNum == 1)
        {
            if (g_global.g_enemyState.e_b_enemy1Shielding)
            {
                return 6; 
            }
            else if (g_global.g_enemyState.e_b_enemy1Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy1SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else if(_enemyNum == 2)
        {
            if (g_global.g_enemyState.e_b_enemy2Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy2Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy2SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else if (_enemyNum == 3)
        {
            if (g_global.g_enemyState.e_b_enemy3Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy3Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy3SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else if (_enemyNum == 4)
        {
            if (g_global.g_enemyState.e_b_enemy4Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy4Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy4SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else if (_enemyNum == 5)
        {
            if (g_global.g_enemyState.e_b_enemy5Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy5Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy5SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else
        {
            Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
            return 0;
        }
    }

    /// <summary>
    /// If _characterIdentifier == 0, player's turn
    /// Else if _characterIdentifier == 1, 2, 3, 4, 5, it's that enemies turn
    /// For Debug Purposes
    /// - Josh
    /// </summary>
    /// <param name="_characterIdentifier"></param>
    public void DeclareCurrentTurn(int _characterIdentifier)
    {
        if(_characterIdentifier == 0) // Player's Turn
        {
            g_global.g_enemyState.e_b_enemy1Turn = false;
            g_global.g_enemyState.e_b_enemy2Turn = false;
            g_global.g_enemyState.e_b_enemy3Turn = false;
            g_global.g_enemyState.e_b_enemy4Turn = false;
            g_global.g_enemyState.e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 1) // Enemy 1's Turn
        {
            g_global.g_enemyState.e_b_enemy1Turn = true;
            g_global.g_enemyState.e_b_enemy2Turn = false;
            g_global.g_enemyState.e_b_enemy3Turn = false;
            g_global.g_enemyState.e_b_enemy4Turn = false;
            g_global.g_enemyState.e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 2) // Enemy 2's Turn
        {
            g_global.g_enemyState.e_b_enemy1Turn = false;
            g_global.g_enemyState.e_b_enemy2Turn = true;
            g_global.g_enemyState.e_b_enemy3Turn = false;
            g_global.g_enemyState.e_b_enemy4Turn = false;
            g_global.g_enemyState.e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 3) // Enemy 3's Turn
        {
            g_global.g_enemyState.e_b_enemy1Turn = false;
            g_global.g_enemyState.e_b_enemy2Turn = false;
            g_global.g_enemyState.e_b_enemy3Turn = true;
            g_global.g_enemyState.e_b_enemy4Turn = false;
            g_global.g_enemyState.e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 4) // Enemy 4's Turn
        {
            g_global.g_enemyState.e_b_enemy1Turn = false;
            g_global.g_enemyState.e_b_enemy2Turn = false;
            g_global.g_enemyState.e_b_enemy3Turn = false;
            g_global.g_enemyState.e_b_enemy4Turn = true;
            g_global.g_enemyState.e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 5) // Enemy 5's Turn
        {
            g_global.g_enemyState.e_b_enemy1Turn = false;
            g_global.g_enemyState.e_b_enemy2Turn = false;
            g_global.g_enemyState.e_b_enemy3Turn = false;
            g_global.g_enemyState.e_b_enemy4Turn = false;
            g_global.g_enemyState.e_b_enemy5Turn = true;
        }
    }


    public S_EventManager.EnemyTurnDelegate GetEnemyEventTrigger(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return S_EventManager.e_enemy1PhaseEvent;
        }
        else if (_enemyNum == 2)
        {
            return S_EventManager.e_enemy2PhaseEvent;
        }
        else if (_enemyNum == 3)
        {
            return S_EventManager.e_enemy3PhaseEvent;
        }
        else if (_enemyNum == 4)
        {
            return S_EventManager.e_enemy4PhaseEvent;
        }
        else if (_enemyNum == 5)
        {
            return S_EventManager.e_enemy5PhaseEvent;
        }
        else
        {
            return null; 
        }
    }

    /// <summary>
    /// Function used for trigger the stored coroutine in the delegates
    /// - Josh
    /// </summary>
    /// <param name="_enemyNum"></param>
    public void EnemyPhaseEventTrigger(int _enemyNum)
    {
        S_EventManager.EnemyTurnDelegate _enemyTurnDelegate = GetEnemyEventTrigger(_enemyNum);
        //S_EventManager.EnemyBroadcast(S_EventManager.Events._enemyTurnDelegate, _enemyNum);
        Debug.Log("Triggered for enemy " + _enemyNum + " - log!");
    }
}
