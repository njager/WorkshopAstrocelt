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
    public TextMeshProUGUI p_tx_energyText;
    
    [Header("Player UI")]
    public TextMeshProUGUI p_tx_playerHealthText;
    public TextMeshProUGUI p_tx_playerShieldText;
    public Image p_playerHealthBar;

    [Header("Enemy Health Textboxes")]
    public TextMeshProUGUI e_tx_enemy1HealthText;
    public TextMeshProUGUI e_tx_enemy2HealthText;
    public TextMeshProUGUI e_tx_enemy3HealthText;

    //Not present
    public TextMeshProUGUI e_tx_enemy4HealthText;
    public TextMeshProUGUI e_tx_enemy5HealthText;

    [Header("Enemy Shield Textboxes")]
    public TextMeshProUGUI e_tx_enemy1ShieldText;
    public TextMeshProUGUI e_tx_enemy2ShieldText;
    public TextMeshProUGUI e_tx_enemy3ShieldText;

    //Not present
    public TextMeshProUGUI e_tx_enemy4ShieldText;
    public TextMeshProUGUI e_tx_enemy5ShieldText;

    [Header("Enemy Healthbars")]
    public Image e_enemy1HealthBar;
    public Image e_enemy2HealthBar;
    public Image e_enemy3HealthBar;

    //Not present
    public Image e_enemy4HealthBar;
    public Image e_enemy5HealthBar;

    [Header("Win Lose Elements")]
    public GameObject winText;
    public GameObject loseText;
    public GameObject resetCanvas;
    public GameObject greyboxCanvas;

    //Will never be a white energy icon
    [Header("Energy Generation Elements")]
    public SpriteRenderer energyIconSprite;
    public Sprite redEnergyIcon;
    public Sprite blueEnergyIcon;
    public Sprite yellowEnergyIcon;
    public Sprite nullEnergyIcon; // Null is equivalent to white here, but don't want to make "white energy type" explicit. - Josh

    [Header("Line Multiplier")]
    public TextMeshProUGUI p_tx_lineMultiplierText;
    public float p_f_lineMultiplierAmount;

    void Awake()
    {
        g_global = S_Global.Instance;

        //Set all three to false to start
        winText.SetActive(false);
        loseText.SetActive(false);
        resetCanvas.SetActive(false);
    }

    //Some of this should be in turn manager?, probably
    void Update()
    {
        SetElements();  
    }

    /// <summary>
    /// Explicitly change the icons according provided energy type
    /// Use null to represent white, and white/null is present when there is no active energy for the player i.e drawing or enemy turn
    /// -Josh
    /// </summary>
    /// <param name="_colorType"></param>
    public void ChangeEnergyIcon(string _colorType)
    {
        if (_colorType.ToLower() == "red")
        {
            energyIconSprite.sprite = redEnergyIcon; // Change to Red Energy Icon
        }
        if (_colorType.ToLower() == "blue")
        {
            energyIconSprite.sprite = blueEnergyIcon; // Change to Blue Energy Icon
        }
        if (_colorType.ToLower() == "yellow")
        {
            energyIconSprite.sprite = yellowEnergyIcon; // Change to Yellow Energy Icon
        }
        if (_colorType.ToLower() == "null")
        {
            energyIconSprite.sprite = nullEnergyIcon; // Change to Null Energy Icon
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
        p_tx_playerHealthText.text = g_global.g_playerAttributeSheet.p_i_health.ToString() + " / " + g_global.g_playerAttributeSheet.p_i_healthMax.ToString();

        p_tx_energyText.text = "Current Energy: " + g_global.g_ConstellationManager.i_energyCount.ToString();

        //Health and Shield Bar
        p_playerHealthBar.fillAmount = (float)g_global.g_playerAttributeSheet.p_i_health / (float)g_global.g_playerAttributeSheet.p_i_healthMax;
        p_tx_playerShieldText.text = g_global.g_playerAttributeSheet.p_i_shield.ToString();


        //Update Enemy Health Bars
        if(g_global.g_enemyAttributeSheet1 != null) 
        {
            e_tx_enemy1ShieldText.text = g_global.g_enemyAttributeSheet1.e_i_shield.ToString();
            e_tx_enemy1HealthText.text = g_global.g_enemyAttributeSheet1.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet1.e_i_healthMax.ToString();
            e_enemy1HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet1.e_i_health / (float)g_global.g_enemyAttributeSheet1.e_i_healthMax;
        }
        if (g_global.g_enemyAttributeSheet2 != null)
        {
            e_tx_enemy2ShieldText.text = g_global.g_enemyAttributeSheet2.e_i_shield.ToString();
            e_tx_enemy2HealthText.text = g_global.g_enemyAttributeSheet2.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet2.e_i_healthMax.ToString();
            e_enemy2HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet2.e_i_health / (float)g_global.g_enemyAttributeSheet2.e_i_healthMax;
        }
        if (g_global.g_enemyAttributeSheet3 != null) 
        {
            e_tx_enemy3ShieldText.text = g_global.g_enemyAttributeSheet3.e_i_shield.ToString();
            e_tx_enemy3HealthText.text = g_global.g_enemyAttributeSheet3.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet3.e_i_healthMax.ToString();
            e_enemy3HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet3.e_i_health / (float)g_global.g_enemyAttributeSheet3.e_i_healthMax;
        }
        if (g_global.g_enemyAttributeSheet4 != null)
        {
            e_tx_enemy4ShieldText.text = g_global.g_enemyAttributeSheet4.e_i_shield.ToString();
            e_tx_enemy4HealthText.text = g_global.g_enemyAttributeSheet4.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet4.e_i_healthMax.ToString();
            e_enemy4HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet4.e_i_health / (float)g_global.g_enemyAttributeSheet4.e_i_healthMax;
        }
        if (g_global.g_enemyAttributeSheet5 != null)
        {
            e_tx_enemy5ShieldText.text = g_global.g_enemyAttributeSheet5.e_i_shield.ToString();
            e_tx_enemy5HealthText.text = g_global.g_enemyAttributeSheet5.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet5.e_i_healthMax.ToString();
            e_enemy5HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet5.e_i_health / (float)g_global.g_enemyAttributeSheet5.e_i_healthMax;
        }
    }
}
