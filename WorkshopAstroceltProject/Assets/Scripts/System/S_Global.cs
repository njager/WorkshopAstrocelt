using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine.UI;
using TMPro;


public class S_Global : MonoBehaviour
{
    [Header("Static instance for Singleton usage of S_Global")]
    public static S_Global Instance;

    [Header("Script References")]
    public S_TurnManager g_turnManager;
    public S_Player g_player;
    public S_MapGeneration g_mapManager;
    public S_DrawingManager g_DrawingManager;
    public S_ConstelationManager g_ConstellationManager;
    public S_UIManager g_UIManager;
    public S_IntentManager g_iconManager; 
    public S_CardManager g_cardManager;
    public S_CardDatabase g_CardDatabase;
    public S_LineMultiplierManager g_lineMultiplierManager;
    public S_EnergyManager g_energyManager;
    public S_PopupManager g_popupManager;
    public S_Altar g_altar;
    public S_SceneManager g_sceneManager;
    public S_BackgroundManager g_backgroundManager;
    public S_TurnEffectManager g_turnEffectManager;

    [Header("Character States")]
    public bool g_b_playerTurn;
    public bool g_b_enemyTurn;

    [Header("Null States")]
    public S_StarClass g_nullStar;

    [Header("Character Control")]
    public int g_i_sceneIndex;

    [Header("State Machine Object References")]
    public S_PlayerAttributes g_playerAttributeSheet;
    public S_PlayerState g_playerState;
    public S_EnemyState g_enemyState;

    [Header("All Potential Enemy Sheets")]
    public S_EnemyAttributes g_enemyAttributeSheet1;
    public S_EnemyAttributes g_enemyAttributeSheet2;
    public S_EnemyAttributes g_enemyAttributeSheet3;
    public S_EnemyAttributes g_enemyAttributeSheet4;
    public S_EnemyAttributes g_enemyAttributeSheet5;

    [Header("Win Lose Variables")]
    public bool g_b_playerWon;
    public bool g_b_playerLost;

    [Header("Enemy Counts")]
    public int g_i_enemyCount;
    //This variable in paricular will probably be set by a database - scene database idea hit me when thinking about this
    public int g_i_enemyCountMax;

    [Header("Lists")]
    public List<S_Enemy> e_ls_enemyList;
    public List<GameObject> g_ls_lineRendererList;
    public List<GameObject> g_ls_completedLineRendererList;
    public List<int> g_ls_p_playerDeck;
    public List<int> g_ls_p_playerGrave;
    public List<S_CardTemplate> g_ls_p_playerHand;
    public List<S_StarPopUp> g_ls_starPopup;
    public List<S_Cardball> g_ls_cardBallPrefabs;

    [Header("Enemy Positions")]
    public GameObject g_e_enemyPosition1;
    public GameObject g_e_enemyPosition2;
    public GameObject g_e_enemyPosition3;

    [Header("Card Dragging")]
    public bool g_c_b_firstCard = true;

    [Header("Required Audio Object For Now")]
    public GameObject g_a_audioPlayer;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        //May be needed for gamemanager later
        g_i_sceneIndex = 0;
    }

    void Start()
    {
        Time.timeScale = 1f;
        //This likely needs to be set in the scene prefab
        g_i_enemyCountMax = g_i_enemyCount;
        //Debug.Log("Enemy Count Max: " + g_i_enemyCountMax.ToString());

        //start the combat music loop
        g_a_audioPlayer.SetActive(true);
    }

    /// <summary>
    /// Cheat buttons, nothing else should really be in update here. 
    /// Add as needed
    /// - Josh
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            g_enemyState.e_b_enemy1Dead = true;
            g_enemyState.enemy1.EnemyDied("Lumberjack");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            g_enemyState.e_b_enemy2Dead = true;
            g_enemyState.enemy2.EnemyDied("Lumberjack");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            g_enemyState.e_b_enemy3Dead = true;
            g_enemyState.enemy3.EnemyDied("Lumberjack");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            g_playerAttributeSheet.p_i_health = 0;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (g_UIManager.debugTurnbar.activeInHierarchy == false)
            {
                g_UIManager.debugTurnbar.SetActive(true);
            }
            else 
            {
                g_UIManager.debugTurnbar.SetActive(false);
            }
        }
    }
}
