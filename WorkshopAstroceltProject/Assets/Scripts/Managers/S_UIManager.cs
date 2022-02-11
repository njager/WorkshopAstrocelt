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

    void Awake()
    {
        g_global = S_Global.Instance; 
        tempUIInitial = 60;
        tempUIMax = 100; 
    }

    //Some of this should be in turn manager?
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
        playerHealthText.text = g_global.g_playerAttributeSheet.p_i_health.ToString() + " / " + g_global.g_playerAttributeSheet.p_i_healthMax.ToString();

        //Health Bar
        playerHealthBar.fillAmount = (float)g_global.g_playerAttributeSheet.p_i_health / (float)g_global.g_playerAttributeSheet.p_i_healthMax;
    }

    public void EndTurn()
    {
        if (g_global.g_selectorManager.e_enemySelected != null)
        {
            if (g_global.g_b_enemyTurn == true)
            {
                Debug.Log("Not your turn!");
                return;
            }
            else
            {
                // Turn damage for Enemy 1
                if (g_global.g_enemyAttributeSheet1 != null)
                {
                    g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet1.e_i_enemyDamageValue);
                    //Debug.Log("Clicked!");
                    g_global.g_turnManager.EnemyStateChange();
                }
                // Turn damage for Enemy 2
                if (g_global.g_enemyAttributeSheet2 != null)
                {
                    g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet2.e_i_enemyDamageValue);
                    //Debug.Log("Clicked!");
                    g_global.g_turnManager.EnemyStateChange();
                }
                // Turn damage for Enemy 3
                if (g_global.g_enemyAttributeSheet3 != null)
                {
                    g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet3.e_i_enemyDamageValue);
                    //Debug.Log("Clicked!");
                    g_global.g_turnManager.EnemyStateChange();
                }
                // Turn damage for Enemy 4
                if (g_global.g_enemyAttributeSheet4 != null)
                {
                    g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet4.e_i_enemyDamageValue);
                    //Debug.Log("Clicked!");
                    g_global.g_turnManager.EnemyStateChange();
                }
                // Turn damage for Enemy 5
                if (g_global.g_enemyAttributeSheet5 != null)
                {
                    g_global.g_player.PlayerAttacked(g_global.g_enemyAttributeSheet5.e_i_enemyDamageValue);
                    //Debug.Log("Clicked!");
                    g_global.g_turnManager.EnemyStateChange();
                }


            }
        }
        else
        {
            Debug.Log("No enemy Selected!");
            return; 
        }
        
    }
}
