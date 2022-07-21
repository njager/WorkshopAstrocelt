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
                StartCoroutine(EnemyStateChange());
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

        if (g_global.g_b_enemyTurn == true)
        {
            Debug.Log("Not your turn!");
            return;
        }
        else
        {
            g_global.g_ConstellationManager.DeleteWholeCurConstellation();
            StartCoroutine(EnemyStateChange()); //Then change the enemies state
        }
    }

    /// <summary>
    /// Change the state to the enemyturn. player turn starts after update triggers it
    /// Triggers the changing of the enemy ui icons
    /// - Riley & Josh
    /// </summary>
    public IEnumerator EnemyStateChange()
    {
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

        foreach (S_Enemy _enemy in g_global.e_ls_enemyList.ToList())
        {
            _enemy.IncreaseIntentIconAlpha();
        }

        // Check to see if dead in order to actvate their moves
        if (g_global.g_enemyState.e_b_enemy1Dead != true)
        {
            // Then trigger turn if present
            if (g_global.g_enemyAttributeSheet1 != null)
            {
                if (enemy1TurnSkipped == false)
                {
                    // Start the turn
                    g_global.g_enemyState.e_b_enemy1Turn = true;
                    g_global.g_enemyState.e_b_enemy2Turn = false;
                    g_global.g_enemyState.e_b_enemy3Turn = false;
                    g_global.g_enemyState.e_b_enemy4Turn = false;
                    g_global.g_enemyState.e_b_enemy5Turn = false;

                    //Can't stagger turn here


                    //Do your action
                    if (g_global.g_enemyState.e_b_enemy1Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet1.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet1.e_str_enemyType, g_global.g_enemyAttributeSheet1.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy1Attacking == true)
                    {
                        //play enemy animation
                        g_global.g_enemyAttributeSheet1.e_a_animator.Play("attack");

                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet1.e_i_enemyDamageValue);

                        //Then play sounds
                        if (g_global.g_enemyState.enemy1.e_str_enemyType == "Beast")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
                        }
                        else if (g_global.g_enemyState.enemy1.e_str_enemyType == "Magician")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
                        }
                        else if (g_global.g_enemyState.enemy1.e_str_enemyType == "Brawler")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
                        }
                    }
                    else if (g_global.g_enemyState.e_b_enemy1SpecialAbility == true)
                    {
                        g_global.g_enemyState.enemy1.EnemySpecialAbility(g_global.g_enemyAttributeSheet1.e_str_enemyType);
                    }
                }
                else
                {
                    Debug.Log("Enemy 1's turn is skipped!");
                }
            }
        }
        // Check to see if dead
        if (g_global.g_enemyState.e_b_enemy2Dead != true)
        {
            // Then trigger turn if present
            if (g_global.g_enemyAttributeSheet2 != null)
            {
                if (enemy2TurnSkipped == false)
                {
                    //Stagger the turn, as long as enemy 2 isn't first
                    if (g_global.g_enemyState.e_b_enemy1Dead != true)
                    {
                        yield return new WaitForSeconds(2);
                    }

                    // Start the turn
                    g_global.g_enemyState.e_b_enemy1Turn = false;
                    g_global.g_enemyState.e_b_enemy2Turn = true;
                    g_global.g_enemyState.e_b_enemy3Turn = false;
                    g_global.g_enemyState.e_b_enemy4Turn = false;
                    g_global.g_enemyState.e_b_enemy5Turn = false;

                    //Do your action
                    if (g_global.g_enemyState.e_b_enemy2Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet2.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet2.e_str_enemyType, g_global.g_enemyAttributeSheet2.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy2Attacking == true)
                    {
                        //play enemy animation
                        g_global.g_enemyAttributeSheet2.e_a_animator.Play("attack");

                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet2.e_i_enemyDamageValue);

                        //Then play sounds
                        if (g_global.g_enemyState.enemy2.e_str_enemyType == "Beast")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
                        }
                        else if (g_global.g_enemyState.enemy2.e_str_enemyType == "Magician")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
                        }
                        else if (g_global.g_enemyState.enemy2.e_str_enemyType == "Brawler")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
                        }
                        else if (g_global.g_enemyState.e_b_enemy2SpecialAbility == true)
                        {
                            g_global.g_enemyState.enemy2.EnemySpecialAbility(g_global.g_enemyAttributeSheet2.e_str_enemyType);
                        }
                    }
                    else
                    {
                        Debug.Log("Enemy 2's turn is skipped!");
                    }
                }
            }
        }
        // Check to see if dead
        if (g_global.g_enemyState.e_b_enemy3Dead != true)
        {
            // Then trigger turn if present
            if (g_global.g_enemyAttributeSheet3 != null)
            {
                if (enemy3TurnSkipped == false)
                {
                    //Stagger the turn, as long as enemy 3 isn't first
                    if (g_global.g_enemyState.e_b_enemy1Dead != true && g_global.g_enemyState.e_b_enemy2Dead != true)
                    {
                        yield return new WaitForSeconds(2);
                    }

                    // Start the turn
                    g_global.g_enemyState.e_b_enemy1Turn = false;
                    g_global.g_enemyState.e_b_enemy2Turn = false;
                    g_global.g_enemyState.e_b_enemy3Turn = true;
                    g_global.g_enemyState.e_b_enemy4Turn = false;
                    g_global.g_enemyState.e_b_enemy5Turn = false;

                    //Do your action
                    if (g_global.g_enemyState.e_b_enemy3Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet3.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet3.e_str_enemyType, g_global.g_enemyAttributeSheet3.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy3Attacking == true)
                    {
                        //play enemy animation
                        g_global.g_enemyAttributeSheet3.e_a_animator.Play("attack");

                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet3.e_i_enemyDamageValue);
                        //Then play sounds
                        if (g_global.g_enemyState.enemy3.e_str_enemyType == "Beast")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
                        }
                        else if (g_global.g_enemyState.enemy3.e_str_enemyType == "Magician")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
                        }
                        else if (g_global.g_enemyState.enemy3.e_str_enemyType == "Brawler")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
                        }
                    }
                    else if (g_global.g_enemyState.e_b_enemy3SpecialAbility == true)
                    {
                        g_global.g_enemyState.enemy1.EnemySpecialAbility(g_global.g_enemyAttributeSheet3.e_str_enemyType);
                    }
                }
                else
                {
                    Debug.Log("Enemy 3's turn is skipped!");
                }
            }
        }
        // Check to see if dead
        if (g_global.g_enemyState.e_b_enemy4Dead != true)
        {
            // Then trigger turn if present
            if (g_global.g_enemyAttributeSheet4 != null)
            {
                if (enemy4TurnSkipped == false)
                {
                    //Stagger the turn
                    yield return new WaitForSeconds(2);

                    // Start the turn
                    g_global.g_enemyState.e_b_enemy1Turn = false;
                    g_global.g_enemyState.e_b_enemy2Turn = false;
                    g_global.g_enemyState.e_b_enemy3Turn = false;
                    g_global.g_enemyState.e_b_enemy4Turn = true;
                    g_global.g_enemyState.e_b_enemy5Turn = false;

                    //Do your action
                    if (g_global.g_enemyState.e_b_enemy4Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet4.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet4.e_str_enemyType, g_global.g_enemyAttributeSheet4.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy4Attacking == true)
                    {
                        //play enemy animation
                        g_global.g_enemyAttributeSheet4.e_a_animator.Play("attack");

                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet4.e_i_enemyDamageValue);
                        //Then play sounds
                        if (g_global.g_enemyState.enemy4.e_str_enemyType == "Beast")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
                        }
                        else if (g_global.g_enemyState.enemy4.e_str_enemyType == "Magician")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
                        }
                        else if (g_global.g_enemyState.enemy1.e_str_enemyType == "Brawler")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
                        }
                    }
                    else if (g_global.g_enemyState.e_b_enemy1SpecialAbility == true)
                    {
                        g_global.g_enemyState.enemy4.EnemySpecialAbility(g_global.g_enemyAttributeSheet4.e_str_enemyType);
                    }
                }
                else
                {
                    Debug.Log("Enemy 4's turn is skipped!");
                }
            }
        }
        // Check to see if dead
        if (g_global.g_enemyState.e_b_enemy5Dead != true)
        {
            // Then trigger turn if present
            if (g_global.g_enemyAttributeSheet5 != null)
            {
                if (enemy5TurnSkipped == false)
                {
                    // Start the turn
                    g_global.g_enemyState.e_b_enemy1Turn = false;
                    g_global.g_enemyState.e_b_enemy2Turn = false;
                    g_global.g_enemyState.e_b_enemy3Turn = false;
                    g_global.g_enemyState.e_b_enemy4Turn = false;
                    g_global.g_enemyState.e_b_enemy5Turn = true;

                    //Stagger the turn
                    yield return new WaitForSeconds(2);

                    //Do your action
                    if (g_global.g_enemyState.e_b_enemy5Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet5.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet5.e_str_enemyType, g_global.g_enemyAttributeSheet5.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy5Attacking == true)
                    {
                        //play enemy animation
                        g_global.g_enemyAttributeSheet5.e_a_animator.Play("attack");

                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet5.e_i_enemyDamageValue);
                        //Then play sounds
                        if (g_global.g_enemyState.enemy5.e_str_enemyType == "Beast")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
                        }
                        else if (g_global.g_enemyState.enemy5.e_str_enemyType == "Magician")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
                        }
                        else if (g_global.g_enemyState.enemy5.e_str_enemyType == "Brawler")
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
                            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
                        }
                    }
                    else if (g_global.g_enemyState.e_b_enemy5SpecialAbility == true)
                    {
                        g_global.g_enemyState.enemy5.EnemySpecialAbility(g_global.g_enemyAttributeSheet5.e_str_enemyType);
                    }
                }
                else
                {
                    Debug.Log("Enemy 5's turn is skipped!");
                }
            }
        }

        //end all turn checks
        g_global.g_enemyState.e_b_enemy1Turn = false;
        g_global.g_enemyState.e_b_enemy2Turn = false;
        g_global.g_enemyState.e_b_enemy3Turn = false;
        g_global.g_enemyState.e_b_enemy4Turn = false;
        g_global.g_enemyState.e_b_enemy5Turn = false;

        

    }

    /// <summary>
    /// Change the state to the player turn. Gets called from update after EnemyState changes the turns
    /// trigger the map generation for the new player turn
    /// Reset the selector so the enemy has to be selected again
    /// - Riley & Josh
    /// </summary>
    public void PlayerStateChange()
    {
        //give the player a new hand
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

    public delegate IEnumerator EnemyTurnDelegate(int x);

    public EnemyTurnDelegate e_enemy1TurnDelegate; // Stays here or goes to S_EnemyState
    public EnemyTurnDelegate e_enemy2TurnDelegate;
    public EnemyTurnDelegate e_enemy3TurnDelegate;
    public EnemyTurnDelegate e_enemy4TurnDelegate;
    public EnemyTurnDelegate e_enemy5TurnDelegate;

    public List<EnemyTurnDelegate> g_ls_enemyPhase; // A List of Delegates for each enemy, unused for now, but can be called in list fashion 
    public List<S_Enemy> g_ls_activeEnemies; 
    private int enemyNumber; // Placeholder, enemy value

    private EnemyTurnDelegate myDelegate; // goes in enemy

    // Goes in enemy
    public void SetDelegate()
    {
        if (enemyNumber == 1)
        {
            g_global.g_turnManager.e_enemy1TurnDelegate = myDelegate;
        }
        else if (enemyNumber == 2)
        {
            g_global.g_turnManager.e_enemy2TurnDelegate = myDelegate;
        }
        else if (enemyNumber == 3)
        {
            g_global.g_turnManager.e_enemy3TurnDelegate = myDelegate;
        }
        else if (enemyNumber == 4)
        {
            g_global.g_turnManager.e_enemy4TurnDelegate = myDelegate;
        }
        else if (enemyNumber == 5)
        {
            g_global.g_turnManager.e_enemy5TurnDelegate = myDelegate;
        }
    }

    public void Start()
    {
        SetDelegate(); // IMPORTANT TO GO IN ENEMY
    }

    // Goes in Enemy
    public void SetTurnState()
    {
        if (g_global.g_turnManager.EnemyStateCheck(enemyNumber) == true)
        {
            myDelegate += g_global.g_turnManager.OverallEnemyTurn;
            myDelegate += g_global.g_turnManager.TurnTimer;
        }
        else
        {
            myDelegate = null;
        }
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

        foreach(EnemyTurnDelegate _enemyTurnDelegate in g_ls_enemyPhase)
        {
            if (e_enemy1TurnDelegate != null)
            {
                yield return StartCoroutine(e_enemy1TurnDelegate.Invoke(1));
            }
        }

        // Potentially Execute Enemy 1's Turn
        

        // Potentially Execute Enemy 2's Turn
        if (e_enemy2TurnDelegate != null)
        {
            yield return StartCoroutine(e_enemy2TurnDelegate.Invoke(2));
        }

        // Potentially Execute Enemy 3's Turn
        if (e_enemy3TurnDelegate != null)
        {
            yield return StartCoroutine(e_enemy3TurnDelegate.Invoke(3));
        }

        // Potentially Execute Enemy 4's Turn
        if (e_enemy4TurnDelegate != null)
        {
            yield return StartCoroutine(e_enemy4TurnDelegate.Invoke(4));
        }

        // Potentially Execute Enemy 5's Turnif(e_enemy1TurnDelegate != null)
        if (e_enemy5TurnDelegate != null)
        {
            yield return StartCoroutine(e_enemy5TurnDelegate.Invoke(5));
        }

        EnemyPhaseEnd();
    }

    public void EnemyPhaseBegin()
    {
        // Update Active Enemies
        UpdateActiveEnemies(); 

        // Have each enemy set their state
        foreach(S_Enemy _activeEnemy in g_ls_activeEnemies.ToList())
        {
           // _activeEnemy.SetTurnState();
        }
        //g_global.g_enemyState.enemy1.SetTurnState();
        //g_global.g_enemyState.enemy2.SetTurnState();
        //g_global.g_enemyState.enemy3.SetTurnState();
        //g_global.g_enemyState.enemy4.SetTurnState();
        //g_global.g_enemyState.enemy5.SetTurnState();

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

        //Switch turns
        g_global.g_b_playerTurn = false;
        g_global.g_b_enemyTurn = true;
    }

    public void EnemyTurnAction(int _enemyNum)
    {

    }

    public S_EnemyAttributes GetEnemyDataSheet(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return g_global.g_enemyAttributeSheet1;
        }
        else if (_enemyNum == 2)
        {
            return g_global.g_enemyAttributeSheet2;
        }
        else if (_enemyNum == 3)
        {
            return g_global.g_enemyAttributeSheet3;
        }
        else if (_enemyNum == 4)
        {
            return g_global.g_enemyAttributeSheet4;
        }
        else if (_enemyNum == 5)
        {
            return g_global.g_enemyAttributeSheet2;
        }
        else
        {
            return null; 
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


    public void UpdateActiveEnemies()
    {
        // Check Enemy 1
        if (g_global.g_enemyState.enemy1 != null)
        {
            if (g_global.g_enemyState.e_b_enemy1Dead == false)
            {
                g_ls_activeEnemies.Add(g_global.g_enemyState.enemy1);
            }
            else
            {
                g_ls_activeEnemies.Remove(g_global.g_enemyState.enemy1);
            }
        }
        else
        {
            g_ls_activeEnemies.Remove(g_global.g_enemyState.enemy1);
        }

        // Check Enemy 2
        if (g_global.g_enemyState.enemy2 != null)
        {
            if (g_global.g_enemyState.e_b_enemy2Dead == false)
            {
                g_ls_activeEnemies.Add(g_global.g_enemyState.enemy2);
            }
            else
            {
                g_ls_activeEnemies.Remove(g_global.g_enemyState.enemy2);
            }
        }
        else
        {
            g_ls_activeEnemies.Remove(g_global.g_enemyState.enemy2);
        }

        // Check Enemy 3
        if (g_global.g_enemyState.enemy3 != null)
        {
            if (g_global.g_enemyState.e_b_enemy3Dead == false)
            {
                g_ls_activeEnemies.Add(g_global.g_enemyState.enemy3);
            }
            else
            {
                g_ls_activeEnemies.Remove(g_global.g_enemyState.enemy3);
            }
        }
        else
        {
            g_ls_activeEnemies.Remove(g_global.g_enemyState.enemy3);
        }

        // Check Enemy 4
        if (g_global.g_enemyState.enemy4 != null)
        {
            if (g_global.g_enemyState.e_b_enemy4Dead == false)
            {
                g_ls_activeEnemies.Add(g_global.g_enemyState.enemy4);
            }
            else
            {
                g_ls_activeEnemies.Remove(g_global.g_enemyState.enemy4);
            }
        }
        else
        {
            g_ls_activeEnemies.Remove(g_global.g_enemyState.enemy4);
        }

        // Check Enemy 5
        if (g_global.g_enemyState.enemy5 != null)
        {
            if (g_global.g_enemyState.e_b_enemy5Dead == false)
            {
                g_ls_activeEnemies.Add(g_global.g_enemyState.enemy5);
            }
            else
            {
                g_ls_activeEnemies.Remove(g_global.g_enemyState.enemy5);
            }
        }
        else
        {
            g_ls_activeEnemies.Remove(g_global.g_enemyState.enemy5);
        }
    }

    // goes in S_EnemyState
    public bool EnemyStateCheck(int _enemyNum)
    {
        if(_enemyNum == 1)
        {
            if (g_global.g_enemyState.enemy1 != null)
            {
                if(g_global.g_enemyState.e_b_enemy1Dead == false)
                {
                    return true;
                }
                else
                {
                    return false; 
                }
            }
            else
            {
                return false; 
            }
        }
        else if(_enemyNum == 2)
        {
            if (g_global.g_enemyState.enemy2 != null)
            {
                if (g_global.g_enemyState.e_b_enemy2Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if(_enemyNum == 3)
        {
            if (g_global.g_enemyState.enemy3 != null)
            {
                if (g_global.g_enemyState.e_b_enemy3Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (_enemyNum == 4)
        {
            if (g_global.g_enemyState.enemy4 != null)
            {
                if (g_global.g_enemyState.e_b_enemy4Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (_enemyNum == 5)
        {
            if (g_global.g_enemyState.enemy5 != null)
            {
                if (g_global.g_enemyState.e_b_enemy5Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false; 
        }
    }

    public IEnumerator OverallEnemyTurn(int _enemyNum)
    {
        EnemyTurnAction(_enemyNum);
        yield return StartCoroutine(TurnTimer(2)); // - maybe?
    }

    public IEnumerator TurnTimer(int _time)
    {
        yield return new WaitForSecondsRealtime(_time);
    }
}
