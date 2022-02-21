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
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI lineMultiplierText; 

    [Header("Player UI")]
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI playerShieldText;
    public Image playerHealthBar;

    [Header("Enemy Health Textboxes")]
    public TextMeshProUGUI enemy1HealthText;
    public TextMeshProUGUI enemy2HealthText;
    public TextMeshProUGUI enemy3HealthText;

    //Not present
    public TextMeshProUGUI enemy4HealthText;
    public TextMeshProUGUI enemy5HealthText;

    [Header("Enemy Shield Textboxes")]
    public TextMeshProUGUI enemy1ShieldText;
    public TextMeshProUGUI enemy2ShieldText;
    public TextMeshProUGUI enemy3ShieldText;

    //Not present
    public TextMeshProUGUI enemy4ShieldText;
    public TextMeshProUGUI enemy5ShieldText;

    [Header("Enemy Healthbars")]
    public Image enemy1HealthBar;
    public Image enemy2HealthBar;
    public Image enemy3HealthBar;

    //Not present
    public Image enemy4HealthBar;
    public Image enemy5HealthBar;

    void Awake()
    {
        g_global = S_Global.Instance; 
    }

    //Some of this should be in turn manager?, probably
    void Update()
    {
        SetElements();  
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

        playerShieldText.text = g_global.g_playerAttributeSheet.p_i_shield.ToString();

        //Update Shield Text
        if (g_global.g_enemyAttributeSheet1 != null)
        {
            enemy1ShieldText.text = g_global.g_enemyAttributeSheet1.e_i_shield.ToString();
        }
        if (g_global.g_enemyAttributeSheet2 != null)
        {
            enemy2ShieldText.text = g_global.g_enemyAttributeSheet2.e_i_shield.ToString();
        }
        if (g_global.g_enemyAttributeSheet3 != null)
        {
            enemy3ShieldText.text = g_global.g_enemyAttributeSheet3.e_i_shield.ToString();
        }
        if (g_global.g_enemyAttributeSheet4 != null)
        {
            enemy4ShieldText.text = g_global.g_enemyAttributeSheet4.e_i_shield.ToString();
        }
        if (g_global.g_enemyAttributeSheet5 != null)
        {
            enemy5ShieldText.text = g_global.g_enemyAttributeSheet5.e_i_shield.ToString();
        }

        //Update Enemy Health Bars
        if(g_global.g_enemyAttributeSheet1 != null) 
        {
            enemy1HealthText.text = g_global.g_enemyAttributeSheet1.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet1.e_i_healthMax.ToString();
            enemy1HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet1.e_i_health / (float)g_global.g_enemyAttributeSheet1.e_i_healthMax;
        }
        if (g_global.g_enemyAttributeSheet2 != null)
        {
            enemy2HealthText.text = g_global.g_enemyAttributeSheet2.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet2.e_i_healthMax.ToString();
            enemy2HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet2.e_i_health / (float)g_global.g_enemyAttributeSheet2.e_i_healthMax;
        }
        if (g_global.g_enemyAttributeSheet3 != null) 
        {
            enemy3HealthText.text = g_global.g_enemyAttributeSheet3.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet3.e_i_healthMax.ToString();
            enemy3HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet3.e_i_health / (float)g_global.g_enemyAttributeSheet3.e_i_healthMax;
        }
        if (g_global.g_enemyAttributeSheet4 != null)
        {
            enemy4HealthText.text = g_global.g_enemyAttributeSheet4.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet4.e_i_healthMax.ToString();
            enemy4HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet4.e_i_health / (float)g_global.g_enemyAttributeSheet4.e_i_healthMax;
        }
        if (g_global.g_enemyAttributeSheet5 != null)
        {
            enemy5HealthText.text = g_global.g_enemyAttributeSheet5.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet5.e_i_healthMax.ToString();
            enemy5HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet5.e_i_health / (float)g_global.g_enemyAttributeSheet5.e_i_healthMax;
        }

    }
}
