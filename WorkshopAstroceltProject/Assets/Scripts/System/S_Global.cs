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
    public static S_Global g_instance;

    [Header("Script References")]
    public S_TurnManager g_turnManager;
    public S_Player g_player;
    public S_Enemy g_enemy;
    public S_MapGeneration g_mapManager;
    public S_DrawingManager g_DrawingManager;
    public S_ConstelationManager g_ConstelationManager;
    public S_UIManager g_UIManager;
    public S_VectorManager g_vectorManager;

    [Header("Character States")]
    public bool g_b_playerTurn;
    public bool g_b_enemyTurn;

    [Header("Null States")]
    public S_StarClass g_nullStar;

    [Header("Player Control")]
    public int SceneIndex;

    public S_PlayerAttributes g_playerAttributeSheet; 

    void Awake()
    {
        g_instance = this;
    }
}
