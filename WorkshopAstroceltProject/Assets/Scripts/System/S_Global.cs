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
    public S_Enemy g_enemy;
    public S_MapGeneration g_mapManager;
    public S_DrawingManager g_DrawingManager;
    public S_ConstelationManager g_ConstellationManager;
    public S_UIManager g_UIManager;
    public S_VectorManager g_vectorManager;
    public S_SelectorManager g_selectorManager;
    public S_CardManager g_cardManager;
    public S_CardDatabase g_CardDatabase;

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
    public List<GameObject> g_lst_lineRendererList;
    public List<GameObject> lst_p_playerDeck;

    [Header("Arrays")]
    public string placeholder;

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

        //for now
        g_i_sceneIndex = 0;
    }

    void Start()
    {
        //This likely needs to be set in the scene prefab
        g_i_enemyCountMax = g_i_enemyCount;
        Debug.Log("Enemy Count Max: " + g_i_enemyCountMax.ToString());
    }
}
