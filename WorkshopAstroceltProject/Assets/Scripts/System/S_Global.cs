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
    public static S_Global Instance;

    [Header("Script References")]
    public S_TurnManager g_turnManager;
    public S_Player g_player;
    public S_MapGeneration g_mapManager;
    public S_DrawingManager g_DrawingManager;
    public S_ConstelationManager g_ConstellationManager;
    public S_UIManager g_UIManager;
    public S_SelectorManager g_selectorManager;
    public S_IconManager g_iconManager; 
    public S_CardManager g_cardManager;
    public S_CardDatabase g_CardDatabase;
    public S_LineMultiplier g_lineMultiplierManager;
    public S_EnergyManager g_energyManager;
    public S_PopupManager g_popupManager;

    [Header("Character States")]
    public bool g_b_playerTurn;
    public bool g_b_enemyTurn;

    [Header("Null States")]
    public S_StarClass g_nullStar;

    [Header("Character Control")]
    public int g_i_sceneIndex;

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
    public List<S_Enemy> e_l_enemyList;
    public List<GameObject> g_ls_lineRendererList;
    public List<int> lst_p_playerDeck;
    public List<int> lst_p_playerGrave;
    public List<GameObject> ls_p_playerHand;
    public List<S_StarPopUp> ls_starPopups;

    [Header("Arrays")]
    public string placeholder;

    [Header("Card IDs")]
    public int c_i_cardIDNum;

    [Header("Enemy Positions")]
    public GameObject g_e_enemyPosition1;
    public GameObject g_e_enemyPosition2;
    public GameObject g_e_enemyPosition3;

    [Header("Card Dragging")]
    public GameObject g_objectBeingDragged;
    public bool b_firstCard = true;

    [Header("Audio")]
    public GameObject a_audioPlayer;

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
        a_audioPlayer.SetActive(true);
    }

    //Adding cheat buttons
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
    }
}
