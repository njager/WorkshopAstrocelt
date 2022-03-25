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
    public bool b_redEnergy = false;
    public bool b_blueEnergy = false;
    public bool b_yellowEnergy = false;

    [Header("Shielding UI Elements")]
    [SerializeField] GameObject p_playerShieldOverlay;
    [SerializeField] GameObject e_enemy1ShieldOverlay;
    [SerializeField] GameObject e_enemy2ShieldOverlay;
    [SerializeField] GameObject e_enemy3ShieldOverlay;
    [SerializeField] GameObject e_enemy4ShieldOverlay;
    [SerializeField] GameObject e_enemy5ShieldOverlay;
    [SerializeField] GameObject p_playerShieldIcon;
    [SerializeField] GameObject e_enemy1ShieldIcon;
    [SerializeField] GameObject e_enemy2ShieldIcon;
    [SerializeField] GameObject e_enemy3ShieldIcon;
    [SerializeField] GameObject e_enemy4ShieldIcon;
    [SerializeField] GameObject e_enemy5ShieldIcon;
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
        ShieldingUI(); //Temporary
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
            b_redEnergy = true;
            b_blueEnergy = false;
            b_yellowEnergy = false;
        }
        if (_colorType.ToLower() == "blue")
        {
            energyIconSprite.sprite = blueEnergyIcon; // Change to Blue Energy Icon
            b_redEnergy = false;
            b_blueEnergy = true;
            b_yellowEnergy = false;
        }
        if (_colorType.ToLower() == "yellow")
        {
            energyIconSprite.sprite = yellowEnergyIcon; // Change to Yellow Energy Icon
            b_redEnergy = false;
            b_blueEnergy = false;
            b_yellowEnergy = true;
        }
        if (_colorType.ToLower() == "null")
        {
            energyIconSprite.sprite = nullEnergyIcon; // Change to Null Energy Icon
            b_redEnergy = false;
            b_blueEnergy = false;
            b_yellowEnergy = false;
        }

    }

    /// <summary>
    /// Toggle the shield elements in the UI based on if they are active or not
    /// Will be updated alongside all other UI disintegration calls
    /// Jager's request
    /// -Josh
    /// </summary>
    public void ShieldingUI()
    {
        //Toggle Shields for player
        if (g_global.g_playerAttributeSheet.p_i_shield <= 0) //If no shields don't turn on shield UI
        {
            p_tx_playerShieldText.gameObject.SetActive(false);
            p_playerShieldIcon.SetActive(false);
            p_playerShieldOverlay.SetActive(false);
        }
        else
        {
            p_tx_playerShieldText.gameObject.SetActive(true);
            p_playerShieldIcon.SetActive(true);
            p_playerShieldOverlay.SetActive(true);
        }
        // Toggle Shields for enemy 1
        if(g_global.g_enemyAttributeSheet1 != null)
        {
            if (g_global.g_enemyState.e_b_enemy1Dead != true)
            {
                if(g_global.g_enemyAttributeSheet1.e_i_shield <= 0)
                {
                    e_tx_enemy1ShieldText.gameObject.SetActive(false);
                    e_enemy1ShieldIcon.SetActive(false);
                    e_enemy1ShieldOverlay.SetActive(false);
                }
                else
                {
                    e_tx_enemy1ShieldText.gameObject.SetActive(true);
                    e_enemy1ShieldIcon.SetActive(true);
                    e_enemy1ShieldOverlay.SetActive(true);
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
                    e_tx_enemy2ShieldText.gameObject.SetActive(false);
                    e_enemy2ShieldIcon.SetActive(false);
                    e_enemy2ShieldOverlay.SetActive(false);
                }
                else
                {
                    e_tx_enemy2ShieldText.gameObject.SetActive(true);
                    e_enemy2ShieldIcon.SetActive(true);
                    e_enemy2ShieldOverlay.SetActive(true);
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
                    e_tx_enemy3ShieldText.gameObject.SetActive(false);
                    e_enemy3ShieldIcon.SetActive(false);
                    e_enemy3ShieldOverlay.SetActive(false);
                }
                else
                {
                    e_tx_enemy3ShieldText.gameObject.SetActive(true);
                    e_enemy3ShieldIcon.SetActive(true);
                    e_enemy3ShieldOverlay.SetActive(true);
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
                    e_tx_enemy4ShieldText.gameObject.SetActive(false);
                    e_enemy4ShieldIcon.SetActive(false);
                    e_enemy4ShieldOverlay.SetActive(false);
                }
                else
                {
                    e_tx_enemy4ShieldText.gameObject.SetActive(true);
                    e_enemy4ShieldIcon.SetActive(true);
                    e_enemy4ShieldOverlay.SetActive(true);
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
                    e_tx_enemy5ShieldText.gameObject.SetActive(false);
                    e_enemy5ShieldIcon.SetActive(false);
                    e_enemy5ShieldOverlay.SetActive(false);
                }
                else
                {
                    e_tx_enemy5ShieldText.gameObject.SetActive(true);
                    e_enemy4ShieldIcon.SetActive(true);
                    e_enemy5ShieldOverlay.SetActive(true);
                }
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
        p_tx_playerHealthText.text = g_global.g_playerAttributeSheet.p_i_health.ToString() + " / " + g_global.g_playerAttributeSheet.p_i_healthMax.ToString();

        //p_tx_energyText.text = "Current Energy: " + g_global.g_energyManager.i_energyCount.ToString();

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
