using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CharacterGraphics : MonoBehaviour
{
    private S_Global g_global;
    private S_UIManager sc_uimanager;

    private void Awake()
    {
        g_global = S_Global.Instance;    
    }

    /// <summary>
    /// Toggle the shield elements for the enemy in the overall enemy UI based on their current shield value
    /// Aka if the enemy has shields
    /// -Josh
    /// </summary>
    public void EnemyShieldingUI() 
    {
        
        // Toggle Shields for enemy 1
        if (g_global.g_enemyAttributeSheet1 != null)
        {
            if (g_global.g_enemyState.e_b_enemy1Dead != true)
            {
                if (g_global.g_enemyAttributeSheet1.e_i_shield <= 0)
                {
                    sc_uimanager.e_tx_enemy1ShieldText.gameObject.SetActive(false);
                    sc_uimanager.e_enemy1ShieldIcon.SetActive(false);
                    sc_uimanager.e_enemy1ShieldOverlay.SetActive(false);
                }
                else
                {
                    sc_uimanager.e_tx_enemy1ShieldText.gameObject.SetActive(true);
                    sc_uimanager.e_enemy1ShieldIcon.SetActive(true);
                    sc_uimanager.e_enemy1ShieldOverlay.SetActive(true);
                }
            }
        }
        // Toggle Shields for enemy 2
        if (g_global.g_enemyAttributeSheet2 != null)
        {
            if (g_global.g_enemyState.e_b_enemy2Dead != true)
            {
                if (g_global.g_enemyAttributeSheet2.e_i_shield <= 0)
                {
                    sc_uimanager.e_tx_enemy2ShieldText.gameObject.SetActive(false);
                    sc_uimanager.e_enemy2ShieldIcon.SetActive(false);
                    sc_uimanager.e_enemy2ShieldOverlay.SetActive(false);
                }
                else
                {
                    sc_uimanager.e_tx_enemy2ShieldText.gameObject.SetActive(true);
                    sc_uimanager.e_enemy2ShieldIcon.SetActive(true);
                    sc_uimanager.e_enemy2ShieldOverlay.SetActive(true);
                }
            }
        }
        // Toggle Shields for enemy 3
        if (g_global.g_enemyAttributeSheet3 != null)
        {
            if (g_global.g_enemyState.e_b_enemy3Dead != true)
            {
                if (g_global.g_enemyAttributeSheet3.e_i_shield <= 0)
                {
                    sc_uimanager.e_tx_enemy3ShieldText.gameObject.SetActive(false);
                    sc_uimanager.e_enemy3ShieldIcon.SetActive(false);
                    sc_uimanager.e_enemy3ShieldOverlay.SetActive(false);
                }
                else
                {
                    sc_uimanager.e_tx_enemy3ShieldText.gameObject.SetActive(true);
                    sc_uimanager.e_enemy3ShieldIcon.SetActive(true);
                    sc_uimanager.e_enemy3ShieldOverlay.SetActive(true);
                }
            }
        }
        // Toggle Shields for enemy 4
        if (g_global.g_enemyAttributeSheet4 != null)
        {
            if (g_global.g_enemyState.e_b_enemy4Dead != true)
            {
                if (g_global.g_enemyAttributeSheet4.e_i_shield <= 0)
                {
                    sc_uimanager.e_tx_enemy4ShieldText.gameObject.SetActive(false);
                    sc_uimanager.e_enemy4ShieldIcon.SetActive(false);
                    sc_uimanager.e_enemy4ShieldOverlay.SetActive(false);
                }
                else
                {
                    sc_uimanager.e_tx_enemy4ShieldText.gameObject.SetActive(true);
                    sc_uimanager.e_enemy4ShieldIcon.SetActive(true);
                    sc_uimanager.e_enemy4ShieldOverlay.SetActive(true);
                }
            }
        }
        // Toggle Shields for enemy 5
        if (g_global.g_enemyAttributeSheet5 != null)
        {
            if (g_global.g_enemyState.e_b_enemy5Dead != true)
            {
                if (g_global.g_enemyAttributeSheet5.e_i_shield <= 0)
                {
                    sc_uimanager.e_tx_enemy5ShieldText.gameObject.SetActive(false);
                    sc_uimanager.e_enemy5ShieldIcon.SetActive(false);
                    sc_uimanager.e_enemy5ShieldOverlay.SetActive(false);
                }
                else
                {
                    sc_uimanager.e_tx_enemy5ShieldText.gameObject.SetActive(true);
                    sc_uimanager.e_enemy5ShieldIcon.SetActive(true);
                    sc_uimanager.e_enemy5ShieldOverlay.SetActive(true);
                }
            }
        }
    }

    public void PlayerShieldingUI() 
    {
        //Toggle Shields for player
        if (g_global.g_playerAttributeSheet.p_i_shield <= 0) //If no shields don't turn on shield UI
        {
            sc_uimanager.p_tx_playerShieldText.gameObject.SetActive(false);
            sc_uimanager.p_playerShieldIcon.SetActive(false);
            sc_uimanager.p_playerShieldOverlay.SetActive(false);
        }
        else
        {
            sc_uimanager.p_tx_playerShieldText.gameObject.SetActive(true);
            sc_uimanager.p_playerShieldIcon.SetActive(true);
            sc_uimanager.p_playerShieldOverlay.SetActive(true);
        }
    }


    /// <summary>
    /// Set the health text of a given enemy
    /// - Josh
    /// </summary>
    /// <param name="_enemyNum"></param>
    public void UpdateHealthBar(int _enemyNum) 
    {

    }

    public void UpdateShieldBar(int _enemyNum) 
    {

    }
}
