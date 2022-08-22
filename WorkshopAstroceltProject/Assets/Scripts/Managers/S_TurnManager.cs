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


    [Header("Enemy Delegate Objects")]
    public S_EventManager.EnemyTurnDelegate e_enemy1TurnDelegate; 
    public S_EventManager.EnemyTurnDelegate e_enemy2TurnDelegate;
    public S_EventManager.EnemyTurnDelegate e_enemy3TurnDelegate;
    public S_EventManager.EnemyTurnDelegate e_enemy4TurnDelegate;
    public S_EventManager.EnemyTurnDelegate e_enemy5TurnDelegate;

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

        g_global.g_enemyState.EnemyAttackingOrShielding();
    }

    /// <summary>
    /// This update is used to simulate some time after the turn change. If the player's turn gets skipped, immediately trigger the end turn
    /// Being used as the IEnumerator loop for the player
    /// - Josh
    /// </summary>
    void Update()
    {
        if (g_global.g_b_playerTurn == false && playerTurnSkipped) // Skip player's turn it it is th
        {
            //Simulating the enemy turn behavior "waiting" before changing back
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0)
            {
                //decrement the player's status effect
                g_global.g_playerState.PlayerStatusEffectDecrement();

                Debug.Log("Player Turn Skipped");
                //StartCoroutine(EnemyPhase());
                spawnTimer = 1f;
            }
        }
        else if (g_global.g_b_playerTurn == false)
        {
            //Simulating the enemy turn behavior "waiting" before changing back
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0)
            {
                //decrement the player's status effect
                g_global.g_playerState.PlayerStatusEffectDecrement();

                PlayerStateChange();
                spawnTimer = 1f;
            }
        }
    }

    /// <summary>
    /// This the function that gets triggered when the end turn button is pressed. 
    /// It is the start of the chain and leads into enemystate change
    /// -Josh and Riley
    /// </summary>
    public void EndTurn()
    {
        Debug.Log("pressed");
        if(g_global.g_altar.b_spawningCardballs == false)
        {
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
    /// Change the state to the player turn. Gets called from update after EnemyState changes the turns
    /// trigger the map generation for the new player turn
    /// Reset the selector so the enemy has to be selected again
    /// - Riley & Josh
    /// </summary>
    public void PlayerStateChange()
    {
        //give the player a new hand (remove all old cards)
        g_global.g_cardManager.NewHand();

        // Spawn cardball prefabs
        StartCoroutine(g_global.g_altar.SpawnCardballPrefabs());

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
        g_global.g_turnManager.EnemyTurnAction(_enemyNum, g_global.g_enemyState.GetEnemyScript(_enemyNum));
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

        //Clear card prefabs + Popups
        StartCoroutine(g_global.g_altar.ClearCardballPrefabs());
        StartCoroutine(g_global.g_popupManager.ClearAllPopups());

        //change all the things that need to be changed for the enemies turn
        g_global.g_energyManager.ClearEnergy();
        g_global.g_enemyState.EnemyAttackingOrShielding();
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


        // Temporary debug
        int _invocationCount1 = e_enemy1TurnDelegate.GetInvocationList().GetLength(0);
        Debug.Log("Delegate amount in Enemy 1 Turn Delegate: " + _invocationCount1);

        int _invocationCount2 = e_enemy2TurnDelegate.GetInvocationList().GetLength(0);
        Debug.Log("Delegate amount in Enemy 2 Turn Delegate: " + _invocationCount2);

        int _invocationCount3 = e_enemy3TurnDelegate.GetInvocationList().GetLength(0);
        Debug.Log("Delegate amount in Enemy 3 Turn Delegate: " + _invocationCount3);

        int _invocationCount4 = e_enemy4TurnDelegate.GetInvocationList().GetLength(0);
        Debug.Log("Delegate amount in Enemy 4 Turn Delegate: " + _invocationCount4);

        int _invocationCount5 = e_enemy5TurnDelegate.GetInvocationList().GetLength(0);
        Debug.Log("Delegate amount in Enemy 5 Turn Delegate: " + _invocationCount5);

        // Load the next icon
        foreach (S_Enemy _enemy in g_global.e_ls_enemyList.ToList())
        {
            _enemy.ChangeIcon();
        }

        g_global.g_enemyState.EnemyStatusEffectDecrement();

        S_EventManager.ClearEnemyEvents();

        //Switch turns
        g_global.g_b_playerTurn = false;
        g_global.g_b_enemyTurn = true;
    }

    public void EnemyTurnAction(int _enemyNum, S_Enemy _enemyScript)
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
                g_global.g_enemyAttributeSheet1.e_a_animator.Play("attack");

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
        }
        else
        {
            Debug.Log("Enemy " + _enemyNum + "'s turn is skipped!");
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

    /// <summary>
    /// Function used for trigger the stored coroutine in the delegates
    /// - Josh
    /// </summary>
    /// <param name="_enemyNum"></param>
    public void EnemyPhaseEventTrigger(int _enemyNum)
    {
        if(_enemyNum == 1)
        {
            S_EventManager.BroadcastForEnemy1();
            Debug.Log("Triggered for enemy 1 - log!");
        }
        else if(_enemyNum == 2)
        {
            S_EventManager.BroadcastForEnemy2();
            Debug.Log("Triggered for enemy 2 - log!");
        }
        else if (_enemyNum == 3)
        {
            S_EventManager.BroadcastForEnemy3();
            Debug.Log("Triggered for enemy 3 - log!");
        }
        else if (_enemyNum == 4)
        {
            S_EventManager.BroadcastForEnemy4();
            Debug.Log("Triggered for enemy 4 - log!");
        }
        else if (_enemyNum == 5)
        {
            S_EventManager.BroadcastForEnemy5();
            Debug.Log("Triggered for enemy 5 - log!");
        }
        else
        {
            Debug.Log("Invalid value for method EnemyPhaseEventTrigger");
        }
    }
}
