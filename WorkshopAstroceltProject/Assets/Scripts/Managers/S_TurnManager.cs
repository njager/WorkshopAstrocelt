using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using FMODUnity; 
using FMOD.Studio; 

public class S_TurnManager : MonoBehaviour
{
    private S_Global g_global;

    public GameObject attackSound;
    public bool e_b_enemyDidAttack;

    public bool b_playerInitialTurn = true;
    public bool b_enemyInitialTurn = false;

    private float spawnTimer = 5f;

    [Header("Turn Skips")]
    public bool playerTurnSkipped;
    public bool enemy1TurnSkipped;
    public bool enemy2TurnSkipped;
    public bool enemy3TurnSkipped;
    public bool enemy4TurnSkipped;
    public bool enemy5TurnSkipped;

    [Header("Environment Assets")]
    public Sprite a_backgroundNight;
    public Sprite a_backgroundDay;
    public Sprite a_hillsNight;
    public Sprite a_hillsDay;

    [Header("Environment References")]
    public SpriteRenderer a_backgroundImage;
    public SpriteRenderer a_hillsImage;


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
                EnemyStateChange();
                spawnTimer = 5f;
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
                spawnTimer = 5f;
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
            EnemyStateChange(); //Then change the enemies state
        }
    }

    /// <summary>
    /// Change the state to the enemyturn. player turn starts after update triggers it
    /// Triggers the changing of the enemy ui icons
    /// - Riley & Josh
    /// </summary>
    public void EnemyStateChange()
    {
        // Toggle day
        ChangeBackground(1);

        //change all the things that need to be changed for the enemies turn
        e_b_enemyDidAttack = false;
        g_global.g_energyManager.ClearEnergy();
        g_global.g_enemyState.EnemyAttackingOrShielding();
        RemoveShielding(); //Remove all shields first

        foreach (S_Enemy _enemy in g_global.e_l_enemyList.ToList())
        {
            _enemy.IncreaseIntentAlpha();
        }

        // Check to see if dead in order to actvate their moves
        if (g_global.g_enemyState.e_b_enemy1Dead != true)
        {
            // Then trigger turn if present
            if (g_global.g_enemyAttributeSheet1 != null)
            {
                if (enemy1TurnSkipped == false)
                {
                    if (g_global.g_enemyState.e_b_enemy1Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet1.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet1.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy1Attacking == true)
                    {
                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet1.e_i_enemyDamageValue);
                        e_b_enemyDidAttack = true;
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
                    if (g_global.g_enemyState.e_b_enemy2Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet2.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet2.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy2Attacking == true)
                    {
                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet2.e_i_enemyDamageValue);
                        e_b_enemyDidAttack = true;
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
        // Check to see if dead
        if (g_global.g_enemyState.e_b_enemy3Dead != true)
        {
            // Then trigger turn if present
            if (g_global.g_enemyAttributeSheet3 != null)
            {
                if (enemy3TurnSkipped == false)
                {
                    if (g_global.g_enemyState.e_b_enemy3Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet3.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet3.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy3Attacking == true)
                    {
                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet3.e_i_enemyDamageValue);
                        e_b_enemyDidAttack = true;
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
                    if (g_global.g_enemyState.e_b_enemy4Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet4.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet4.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy4Attacking == true)
                    {
                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet4.e_i_enemyDamageValue);
                        e_b_enemyDidAttack = true;
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
                    if (g_global.g_enemyState.e_b_enemy5Shielding == true)
                    {
                        g_global.g_enemyAttributeSheet5.e_enemy.EnemyShielded(g_global.g_enemyAttributeSheet4.e_i_shieldMax);
                    }
                    else if (g_global.g_enemyState.e_b_enemy5Attacking == true)
                    {
                        g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet5.e_i_enemyDamageValue);
                        e_b_enemyDidAttack = true;
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

        // Load the next icon
        foreach (S_Enemy _enemy in g_global.e_l_enemyList.ToList())
        {
            _enemy.ChangeIcon();
        }

        //Play sound
        if (e_b_enemyDidAttack == true)
        {
            PlayAttackSound();
        }

        g_global.g_enemyState.EnemyStatusEffectDecrement();

        //Switch turns
        g_global.g_b_playerTurn = false;
        g_global.g_b_enemyTurn = true;
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

        //Turn to night
        ChangeBackground(0);

        //Map Switching
        g_global.g_mapManager.RandomMapSelector();

        // Temp line removal 
        g_global.g_DrawingManager.b_lineDeletionCompletion = false; 
        StartCoroutine(g_global.g_DrawingManager.LineDeletion());

        //clear data for the stars when the map changes (prolly should be a function) doesnt work
        //g_global.g_DrawingManager.s_nodeStarInst.s_star.m_previous = g_global.g_nullStar;
        //g_global.g_DrawingManager.s_nodeStarInst.s_star.m_next = g_global.g_nullStar;
        
        //change the selector
        g_global.g_selectorManager.SelectorReset();

        //stop the audio
        attackSound.SetActive(false);

        //switch turns
        g_global.g_b_playerTurn = true;
        g_global.g_b_enemyTurn = false;
    }

    public void PlayAttackSound()
    {
        attackSound.SetActive(true);
    }

    /// <summary>
    /// Remove shielding as it's supposed to at end of turn
    /// </summary>
    private void RemoveShielding()
    {
        //Reset player
        g_global.g_playerAttributeSheet.p_i_shield = 0;

        //Reset Enemy
        if(g_global.g_enemyAttributeSheet1 != null) // Strip Enemy 1 of Shielding
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
    /// Background helper function to change the environment assets
    /// Enter 0 for Night, 1 for Day
    /// - Josh
    /// </summary>
    /// <param name="_environmentValue"></param>
    private void ChangeBackground(int _environmentValue)
    {
        if (_environmentValue == 0) // Change to Night
        {
            // Change sprites
            a_backgroundImage.sprite = a_backgroundNight;
            a_hillsImage.sprite = a_hillsNight;
        }
        else if(_environmentValue == 1) // Change to Day
        {
            // Change sprites
            a_backgroundImage.sprite = a_backgroundDay;
            a_hillsImage.sprite = a_hillsDay;

            // Toggle maps
            g_global.g_mapManager.map1.SetActive(false);
            g_global.g_mapManager.map2.SetActive(false);
            g_global.g_mapManager.map3.SetActive(false);
            g_global.g_mapManager.map4.SetActive(false);
            g_global.g_mapManager.map5.SetActive(false);
            g_global.g_mapManager.map6.SetActive(false);
            g_global.g_mapManager.map7.SetActive(false);
            g_global.g_mapManager.map8.SetActive(false);
        }
    }
}
