using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class S_UIManager : MonoBehaviour
{
    private S_Global g_global;

    // Anything under here is just to help flesh out the greybox
    [Header("Initial GreyBox UI")]
    public GameObject enemyTurnBar;
    public GameObject playerTurnBar;

    public Image playerHealthBar;

    public TextMeshProUGUI playerHealthText;

    public int tempUIInitial;
    public int tempUIMax;

    private float spawnTimer = 5f;

    private void Awake()
    {
        g_global = S_Global.g_instance; 
    }

    void Start()
    {
        tempUIInitial = 60;
        tempUIMax = 100; 
    }

    void Update()
    {
        SetElements();  

        if (g_global.g_b_playerTurn == true)
        {
            //Turn indicator changing
            playerTurnBar.SetActive(true);
            enemyTurnBar.SetActive(false); 
        }

        if (g_global.g_b_playerTurn == false)
        {
            //Turn indicator changing
            playerTurnBar.SetActive(false);
            enemyTurnBar.SetActive(true);

            //Simulating the enemy turn behavior "waiting" before changing back
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0)
            {
                g_global.g_turnManager.PlayerStateChange();
                spawnTimer = 5f;
            }
        }
    }

    /// <summary>
    /// Update the UI Elements
    /// In a seperate function to keep things clean
    /// - Josh
    /// </summary>
    public void SetElements()
    {
        // Text
        playerHealthText.text = tempUIInitial.ToString() + "/" + tempUIMax.ToString();

        //Health Bar
        playerHealthBar.fillAmount = tempUIInitial/ tempUIMax;
    }

    //Temporary Button placeholder for triggering the state machine
    public void EndTurn()
    {
        tempUIInitial-= 5; // Simultating enemy attack
        g_global.g_turnManager.EnemyStateChange();
    }
}
