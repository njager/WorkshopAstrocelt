using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class S_UIManager : MonoBehaviour
{
    protected S_Global g_global;

    [Header("Child Script References")] // Set in inspector
    public S_CharacterGraphics sc_characterGraphics;
    public S_ResourceGraphics sc_resourceGraphics;

    [Header("Player UI")]
    [SerializeField] TextMeshProUGUI p_tx_playerHealthText;
    [SerializeField] TextMeshProUGUI p_tx_playerShieldText;
    [SerializeField] Image p_UI_playerHealthBar;
    [SerializeField] TextMeshProUGUI p_playerHealthResourceBarText;
    public TextMeshProUGUI c_cardCount;

    [Header("Enemy Health Textboxes")]
    [SerializeField] TextMeshProUGUI e_tx_enemy1HealthText;
    [SerializeField] TextMeshProUGUI e_tx_enemy2HealthText;
    [SerializeField] TextMeshProUGUI e_tx_enemy3HealthText;
    [SerializeField] TextMeshProUGUI e_tx_enemy4HealthText;
    [SerializeField] TextMeshProUGUI e_tx_enemy5HealthText;

    [Header("Enemy Shield Textboxes")]
    [SerializeField] TextMeshProUGUI e_tx_enemy1ShieldText;
    [SerializeField] TextMeshProUGUI e_tx_enemy2ShieldText;
    [SerializeField] TextMeshProUGUI e_tx_enemy3ShieldText;
    [SerializeField] TextMeshProUGUI e_tx_enemy4ShieldText;
    [SerializeField] TextMeshProUGUI e_tx_enemy5ShieldText;

    [Header("Enemy Healthbars")]
    [SerializeField] Image e_UI_enemy1HealthBar;
    [SerializeField] Image e_UI_enemy2HealthBar;
    [SerializeField] Image e_UI_enemy3HealthBar;
    [SerializeField] Image e_UI_enemy4HealthBar;
    [SerializeField] Image e_UI_enemy5HealthBar;

    [Header("Enemy Selector")]
    [SerializeField] GameObject e_enemy1Selector;
    [SerializeField] GameObject e_enemy2Selector;
    [SerializeField] GameObject e_enemy3Selector;
    [SerializeField] GameObject e_enemy4Selector;
    [SerializeField] GameObject e_enemy5Selector;

    [Header("Win Lose Elements")]
    public GameObject winText;
    public GameObject loseText;
    public GameObject cn_resetCanvas;
    public GameObject cn_characterCanvas;

    //Will never be a white energy icon
    [Header("Energy Generation Elements")]
    public SpriteRenderer energyIconSprite;
    public Sprite redEnergyIcon;
    public Sprite blueEnergyIcon;
    public Sprite yellowEnergyIcon;
    public Sprite nullEnergyIcon; // Null is equivalent to white here, but don't want to make "white energy type" explicit. - Josh

    [Header("Line Multiplier")]
    public TextMeshProUGUI p_tx_lineMultiplierText;
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
    [SerializeField] GameObject p_playerShieldHeartIcon;
    [SerializeField] GameObject p_playerShieldIcon;
    [SerializeField] GameObject e_enemy1ShieldIcon;
    [SerializeField] GameObject e_enemy2ShieldIcon;
    [SerializeField] GameObject e_enemy3ShieldIcon;
    [SerializeField] GameObject e_enemy4ShieldIcon;
    [SerializeField] GameObject e_enemy5ShieldIcon;

    [Header("Player Status Effect References")]
    public GameObject p_playerHealthBar;

    [Header("Enemy Healthbar Refereneces")]
    public GameObject e_enemy1HealthBar;
    public GameObject e_enemy2HealthBar;
    public GameObject e_enemy3HealthBar;
    public GameObject e_enemy4HealthBar;
    public GameObject e_enemy5HealthBar;

    [Header("Debug Turnbar")]
    public GameObject debugTurnbar;
    public TextMeshProUGUI debugTurnbarText;

    [Header("Energy UI Text Elements")] // Keep en_
    public TextMeshProUGUI en_tx_redEnergyTrackerText;
    public TextMeshProUGUI en_tx_blueEnergyTrackerText;
    public TextMeshProUGUI en_tx_yellowEnergyTrackerText;

    [Header("Constellation Length Elements")]
    public TextMeshProUGUI co_tx_constellationTrackerText;

    [Header("Resource Graphics Encounter Tracker Asset Object References")]
    [SerializeField] GameObject rsg_UI_encounterSelector;
    [SerializeField] GameObject rsg_UI_skull1Parent;
    [SerializeField] GameObject rsg_UI_skull1BaseAsset;
    [SerializeField] GameObject rsg_UI_skull1CrackedAsset;
    [SerializeField] GameObject rsg_UI_skull2Parent;
    [SerializeField] GameObject rsg_UI_skull2BaseAsset;
    [SerializeField] GameObject rsg_UI_skull2CrackedAsset;
    [SerializeField] GameObject rsg_UI_skull3Parent;
    [SerializeField] GameObject rsg_UI_skull3BaseAsset;
    [SerializeField] GameObject rsg_UI_skull3CrackedAsset;
    [SerializeField] GameObject rsg_UI_bossSkullParent;
    [SerializeField] GameObject rsg_UI_bossSkullBaseAsset;
    [SerializeField] GameObject rsg_UI_bossSkullCrackedAsset;
    [SerializeField] GameObject rsg_UI_eventEncounterParent;
    [SerializeField] GameObject rsg_UI_eventEncounterBaseAsset;
    [SerializeField] GameObject rsg_UI_eventEncounterFinishedAsset;

    [Header("Resource Graphics Bonus Tracker Asset Object References")]
    [SerializeField] GameObject rsg_UI_defaultBonusContainer;
    [SerializeField] GameObject rsg_UI_redBonusContainer;
    [SerializeField] GameObject rsg_UI_blueBonusContainer;
    [SerializeField] GameObject rsg_UI_yellowBonusContainer;
    [SerializeField] GameObject rsg_UI_redBonusIcon1;
    [SerializeField] GameObject rsg_UI_redBonusIcon2;
    [SerializeField] GameObject rsg_UI_redBonusIcon3;
    [SerializeField] GameObject rsg_UI_blueBonusIcon1;
    [SerializeField] GameObject rsg_UI_blueBonusIcon2;
    [SerializeField] GameObject rsg_UI_blueBonusIcon3;
    [SerializeField] GameObject rsg_UI_yellowBonusIcon1;
    [SerializeField] GameObject rsg_UI_yellowBonusIcon2;
    [SerializeField] GameObject rsg_UI_yellowBonusIcon3;

    [Header("Resource Graphics Bonus Tier Tracker")]
    [SerializeField] public int rsg_UI_i_bonusTracker = 1;

    [Header("Player Card Selector Asset")]
    [SerializeField] GameObject p_playerCardSelector;

    [Header("Resource Graphics Scale Tracker")]
    [SerializeField] Vector3 rsg_OriginalScale;
    [SerializeField] Vector3 rsg_ScaleTo;
    
    void Awake()
    {
        g_global = S_Global.Instance;

        //Set all three to false to start
        winText.SetActive(false);
        loseText.SetActive(false);
        cn_resetCanvas.SetActive(false);

        // Turn off debug elements
        debugTurnbar.SetActive(false);
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
    /// Update the UI Elements
    /// In a seperate function to keep things clean
    /// - Josh
    /// </summary>
    public void SetElements()
    {
        //Update Enemy Health Bars
        if(g_global.g_enemyAttributeSheet1 != null) 
        {
            e_tx_enemy1ShieldText.text = g_global.g_enemyAttributeSheet1.GetEnemyShieldValue().ToString();
            e_tx_enemy1HealthText.text = g_global.g_enemyAttributeSheet1.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet1.e_i_healthMax.ToString();
            e_UI_enemy1HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet1.e_i_health / (float)g_global.g_enemyAttributeSheet1.e_i_healthMax;
        }
        if (g_global.g_enemyAttributeSheet2 != null)
        {
            e_tx_enemy2ShieldText.text = g_global.g_enemyAttributeSheet2.GetEnemyShieldValue().ToString();
            e_tx_enemy2HealthText.text = g_global.g_enemyAttributeSheet2.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet2.e_i_healthMax.ToString();
            e_UI_enemy2HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet2.e_i_health / (float)g_global.g_enemyAttributeSheet2.e_i_healthMax;
        }
        if (g_global.g_enemyAttributeSheet3 != null) 
        {
            e_tx_enemy3ShieldText.text = g_global.g_enemyAttributeSheet3.GetEnemyShieldValue().ToString();
            e_tx_enemy3HealthText.text = g_global.g_enemyAttributeSheet3.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet3.e_i_healthMax.ToString();
            e_UI_enemy3HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet3.e_i_health / (float)g_global.g_enemyAttributeSheet3.e_i_healthMax;
        }
        if (g_global.g_enemyAttributeSheet4 != null)
        {
            e_tx_enemy4ShieldText.text = g_global.g_enemyAttributeSheet4.GetEnemyShieldValue().ToString();
            e_tx_enemy4HealthText.text = g_global.g_enemyAttributeSheet4.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet4.e_i_healthMax.ToString();
            e_UI_enemy4HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet4.e_i_health / (float)g_global.g_enemyAttributeSheet4.e_i_healthMax;
        }
        if (g_global.g_enemyAttributeSheet5 != null)
        {
            e_tx_enemy5ShieldText.text = g_global.g_enemyAttributeSheet5.GetEnemyShieldValue().ToString();
            e_tx_enemy5HealthText.text = g_global.g_enemyAttributeSheet5.e_i_health.ToString() + " / " + g_global.g_enemyAttributeSheet5.e_i_healthMax.ToString();
            e_UI_enemy5HealthBar.fillAmount = (float)g_global.g_enemyAttributeSheet5.e_i_health / (float)g_global.g_enemyAttributeSheet5.e_i_healthMax;
        }

        if(debugTurnbar.activeInHierarchy == true) 
        {
            DebugTurnBarUpdate();
        }

        // Anurag's UI element
        //c_cardCount.text = g_global.g_ls_p_playerHand.Count.ToString();
    }

    /// <summary>
    /// Change the name on the turn bar
    /// - Josh
    /// </summary>
    public void DebugTurnBarUpdate()
    {
        if(g_global.g_enemyState.e_b_enemy1Turn == true) 
        {
            debugTurnbarText.text = "Current Character's Turn is: Enemy 1";
        }
        else if (g_global.g_enemyState.e_b_enemy2Turn == true)
        {
            debugTurnbarText.text = "Current Character's Turn is: Enemy 2";
        }
        else if (g_global.g_enemyState.e_b_enemy3Turn == true)
        {
            debugTurnbarText.text = "Current Character's Turn is: Enemy 3";
        }
        else if (g_global.g_enemyState.e_b_enemy4Turn == true)
        {
            debugTurnbarText.text = "Current Character's Turn is: Enemy 4";
        }
        else if (g_global.g_enemyState.e_b_enemy5Turn == true)
        {
            debugTurnbarText.text = "Current Character's Turn is: Enemy 5";
        }
        else 
        {
            debugTurnbarText.text = "Current Character's Turn is: Player";
        }
    }

    /////////////////////////////---------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Other Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the TextMeshProUGUI object of S_UIManager.en_tx_redText
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.en_tx_redEnergyTrackerText
    /// </returns>
    public TextMeshProUGUI GetRedEnergyTrackerText()
    {
        return en_tx_redEnergyTrackerText;
    }

    /// <summary>
    /// Return the TextMeshProUGUI object of S_UIManager.en_tx_blueText
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.en_tx_blueEnergyTrackerText
    /// </returns>
    public TextMeshProUGUI GetBlueEnergyTrackerText()
    {
        return en_tx_blueEnergyTrackerText;
    }

    /// <summary>
    /// Return the TextMeshProUGUI object of S_UIManager.en_tx_yellowText
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.en_tx_yellowEnergyTrackerText
    /// </returns>
    public TextMeshProUGUI GetYellowEnergyTrackerText()
    {
        return en_tx_yellowEnergyTrackerText;
    }


    ///<summary>
    ///Constellation length UI gettter
    /// -THOMAN
    ///</summary>
    public TextMeshProUGUI GetConstellationUI()
    {
        return co_tx_constellationTrackerText;
    }

    /////////////////////////////----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Player Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the text element of S_UIManager.p_tx_playerHealthText
    /// - Josh
    /// </summary>
    /// <param name="_healthValue"></param>
    /// <param name="_maxHealthValue"></param>
    public void SetPlayerHealthText(int _healthValue, int _maxHealthValue)
    {
        p_tx_playerHealthText.text = _healthValue.ToString() + " / " + _maxHealthValue.ToString();
    }

    /// <summary>
    /// Set the text element of S_UIManager.p_tx_playerShieldText
    /// - Josh
    /// </summary>
    /// <param name="_shieldValue"></param>
    public void SetPlayerShieldText(int _shieldValue)
    {
        p_tx_playerShieldText.text = _shieldValue.ToString();
    }

    /// <summary>
    /// Set the fillAmount of the S_UIManager.p_playerHealthBar
    /// - Josh
    /// </summary>
    /// <param name="_healthValue"></param>
    /// <param name="_maxHealthValue"></param>
    public void SetPlayerHealthBar(int _healthValue, int _maxHealthValue) 
    {
        p_playerHealthBar.fillAmount = (float)_healthValue / (float)_maxHealthValue;
    }

    /// <summary>
    /// Set the text element of the S_UIManager.p_playerHealthResourceBarText
    /// - Josh
    /// </summary>
    /// <param name="_healthValue"></param>
    /// <param name="_maxHealthValue"></param>
    public void SetPlayerResourceHealthText(int _healthValue, int _maxHealthValue)
    {
        p_playerHealthResourceBarText.text = _healthValue.ToString() + " / " + _maxHealthValue.ToString();
    }

    /////////////////////////////----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Player Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the TextMeshProUGUI object of S_UIManager.p_tx_playerShieldText
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.p_tx_playerShieldText 
    /// </returns>
    public TextMeshProUGUI GetPlayerShieldText()
    {
        return p_tx_playerShieldText;
    }

    /// <summary>
    /// Return the gameobject of S_UIManager.p_playerShieldIcon
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.p_playerShieldIcon
    /// </returns>
    public GameObject GetPlayerShieldIcon()
    {
        return p_playerShieldIcon;
    }

    /// <summary>
    /// Return the gameobject of S_UIManager.p_playerShieldOverlay
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.p_playerShieldOverlay
    /// </returns>
    public GameObject GetPlayerShieldOverlay()
    {
        return p_playerShieldOverlay;
    }

    /// <summary>
    /// Return the gameobject of S_UIManager.p_playerShieldArtIcon
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.p_playerShieldArtIcon
    /// </returns>
    public GameObject GetPlayerShieldHeartIcon()
    {
        return p_playerShieldHeartIcon;
    }

    /// <summary>
    /// Return the gameobject of S_UIManager.p_playerCardSelector
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.p_playerCardSelector
    /// </returns>
    public GameObject GetPlayerCardSelector()
    {
        return p_playerCardSelector;
    }

    /////////////////////////////---------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Enemy Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the text element of a given enemy's S_UIManager.e_tx_enemy{ }ShieldText
    /// - Josh
    /// </summary>
    /// <param name="_shieldValue"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyShieldText(int _shieldValue, int _enemyNum)
    {
        if(_enemyNum == 1) 
        {
            e_tx_enemy1ShieldText.text = _shieldValue.ToString();
        }
        else if (_enemyNum == 2)
        {
            e_tx_enemy2ShieldText.text = _shieldValue.ToString();
        }
        else if (_enemyNum == 3)
        {
            e_tx_enemy3ShieldText.text = _shieldValue.ToString();
        }
        else if (_enemyNum == 4)
        {
            e_tx_enemy4ShieldText.text = _shieldValue.ToString();
        }
        else if (_enemyNum == 5)
        {
            e_tx_enemy5ShieldText.text = _shieldValue.ToString();
        }
    }

    /// <summary>
    /// Set the text element of a given enemy's S_UIManager.e_tx_enemy{ }HealthText
    /// - Josh
    /// </summary>
    /// <param name="_healthValue"></param>
    /// <param name="_maxHealthValue"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyHealthText(int _healthValue, int _maxHealthValue, int _enemyNum) 
    {
        if (_enemyNum == 1)
        {
            e_tx_enemy1HealthText.text = _healthValue.ToString() + " / " + _maxHealthValue.ToString();
        }
        else if (_enemyNum == 2)
        {
            e_tx_enemy2HealthText.text = _healthValue.ToString() + " / " + _maxHealthValue.ToString();
        }
        else if (_enemyNum == 3)
        {
            e_tx_enemy3HealthText.text = _healthValue.ToString() + " / " + _maxHealthValue.ToString();
        }
        else if (_enemyNum == 4)
        {
            e_tx_enemy4HealthText.text = _healthValue.ToString() + " / " + _maxHealthValue.ToString();
        }
        else if (_enemyNum == 5)
        {
            e_tx_enemy5HealthText.text = _healthValue.ToString() + " / " + _maxHealthValue.ToString();
        }
    }

    /// <summary>
    /// Set the fillAmount of a given enemy's S_UIManager.e_tx_enemy{ }HealthBar
    /// - Josh
    /// </summary>
    /// <param name="_healthValue"></param>
    /// <param name="_maxHealthValue"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyHealthBar(int _healthValue, int _maxHealthValue, int _enemyNum) 
    {
        if (_enemyNum == 1)
        {
            e_UI_enemy1HealthBar.fillAmount = (float)_healthValue / (float)_maxHealthValue;
        }
        else if (_enemyNum == 2)
        {
            e_UI_enemy2HealthBar.fillAmount = (float)_healthValue / (float)_maxHealthValue;
        }
        else if (_enemyNum == 3)
        {
            e_UI_enemy3HealthBar.fillAmount = (float)_healthValue / (float)_maxHealthValue;
        }
        else if (_enemyNum == 4)
        {
            e_UI_enemy4HealthBar.fillAmount = (float)_healthValue / (float)_maxHealthValue;
        }
        else if (_enemyNum == 5)
        {
            e_UI_enemy5HealthBar.fillAmount = (float)_healthValue / (float)_maxHealthValue;
        }
    }

    /// Move this to S_CharacterGraphics - Josh

    /// <summary>
    /// Turn the enemy selector On
    /// -Riley 
    /// </summary>
    /// <param name="_enemyNum"></param>
    public void SetEnemySelectorOn(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_enemy1Selector.SetActive(true);
        }
        else if (_enemyNum == 2)
        {
            e_enemy2Selector.SetActive(true);
        }
        else if (_enemyNum == 3)
        {
            e_enemy3Selector.SetActive(true);
        }
        else if (_enemyNum == 4)
        {
            e_enemy4Selector.SetActive(true);
        }
        else if (_enemyNum == 5)
        {
            e_enemy5Selector.SetActive(true);
        }
    }

    /// <summary>
    /// Turn the Enemy Selector off
    /// -Riley 
    /// </summary>
    /// <param name="_enemyNum"></param>
    public void SetEnemySelectorOff(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_enemy1Selector.SetActive(false);
        }
        else if (_enemyNum == 2)
        {
            e_enemy2Selector.SetActive(false);
        }
        else if (_enemyNum == 3)
        {
            e_enemy3Selector.SetActive(false);
        }
        else if (_enemyNum == 4)
        {
            e_enemy4Selector.SetActive(false);
        }
        else if (_enemyNum == 5)
        {
            e_enemy5Selector.SetActive(false);
        }
    }

    /////////////////////////////---------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Enemy Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the gameobject for a requested enemy's shield icon from S_UIManager
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.e_enemy1ShieldIcon || S_UIManager.e_enemy2ShieldIcon || S_UIManager.e_enemy3ShieldIcon || S_UIManager.e_enemy4ShieldIcon || S_UIManager.e_enemy5ShieldIcon
    /// </returns>
    /// <param name="_enemyNum"></param>
    public GameObject GetEnemyShieldIcon(int _enemyNum)
    {
        if (_enemyNum == 1) 
        {
            return e_enemy1ShieldIcon;
        }
        else if (_enemyNum == 2)
        {
            return e_enemy2ShieldIcon;
        }
        else if (_enemyNum == 3)
        {
            return e_enemy3ShieldIcon;
        }
        else if (_enemyNum == 4)
        {
            return e_enemy4ShieldIcon;
        }
        else if (_enemyNum == 5)
        {
            return e_enemy5ShieldIcon;
        }
        else
        {
            Debug.Log("RETURNED NULL GAMEOBJECT - GetEnemyShieldIcon()");
            return null;
        }
    }

    /// <summary>
    /// Return the TextMeshProUGUI for a requested enemy's shield text from S_UIManager
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.e_tx_enemy1ShieldText || S_UIManager.e_tx_enemy2ShieldText || S_UIManager.e_tx_enemy3ShieldText || S_UIManager.e_tx_enemy4ShieldText || S_UIManager.e_tx_enemy5ShieldText
    /// </returns>
    /// <param name="_enemyNum"></param>
    public TextMeshProUGUI GetEnemyShieldText(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_tx_enemy1ShieldText;
        }
        else if (_enemyNum == 2)
        {
            return e_tx_enemy2ShieldText;
        }
        else if (_enemyNum == 3)
        {
            return e_tx_enemy3ShieldText;
        }
        else if (_enemyNum == 4)
        {
            return e_tx_enemy4ShieldText;
        }
        else if (_enemyNum == 5)
        {
            return e_tx_enemy5ShieldText;
        }
        else
        {
            Debug.Log("RETURNED NULL GAMEOBJECT - GetEnemyShieldText()");
            return null;
        }
    }

    /// <summary>
    /// Return the gameobject for a requested enemy's shield overlay from S_UIManager
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.e_enemy1ShieldOverlay || S_UIManager.e_enemy2ShieldOverlay || S_UIManager.e_enemy3ShieldOverlay || S_UIManager.e_enemy4ShieldOverlay || S_UIManager.e_enemy5ShieldOverlay
    /// </returns>
    /// <param name="_enemyNum"></param>
    public GameObject GetEnemyShieldOverlay(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_enemy1ShieldOverlay;
        }
        else if (_enemyNum == 2)
        {
            return e_enemy2ShieldOverlay;
        }
        else if (_enemyNum == 3)
        {
            return e_enemy3ShieldOverlay;
        }
        else if (_enemyNum == 4)
        {
            return e_enemy4ShieldOverlay;
        }
        else if (_enemyNum == 5)
        {
            return e_enemy5ShieldOverlay;
        }
        else
        {
            Debug.Log("RETURNED NULL GAMEOBJECT - GetEnemyShieldOverlay()");
            return null;
        }
    }

    /////////////////////////////----------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Resource Bar Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////----------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_encounterSelector
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_encounterSelector
    /// </returns>
    public GameObject GetUIEncounterSelector()
    {
        return rsg_UI_encounterSelector;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_skull1Parent
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_skull1Parent
    /// </returns>
    public GameObject GetUISkull1Parent()
    {
        return rsg_UI_skull1Parent;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_skull1BaseAsset
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_skull1BaseAsset
    /// </returns>
    public GameObject GetSkull1BaseAsset()
    {
        return rsg_UI_skull1BaseAsset;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_skull1CrackedAsset
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_skull1CrackedAsset
    /// </returns>
    public GameObject GetSkull1CrackedAsset()
    {
        return rsg_UI_skull1CrackedAsset;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_skull2Parent
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_skull2Parent
    /// </returns>
    public GameObject GetSkull2Parent()
    {
        return rsg_UI_skull2Parent;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_skull2BaseAsset
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_skull2BaseAsset
    /// </returns>
    public GameObject GetSkull2BaseAsset()
    {
        return rsg_UI_skull2BaseAsset;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_skull2CrackedAsset
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_skull2CrackedAsset
    /// </returns>
    public GameObject GetSkull2CrackedAsset()
    {
        return rsg_UI_skull2CrackedAsset;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_skull3Parent
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_skull3Parent
    /// </returns>
    public GameObject GetSkull3Parent()
    {
        return rsg_UI_skull3Parent;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_skull3BaseAsset
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_skull3BaseAsset
    /// </returns>
    public GameObject GetSkull3BaseAsset()
    {
        return rsg_UI_skull3BaseAsset;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_skull3CrackedAsset
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_skull3CrackedAsset
    /// </returns>
    public GameObject GetSkull3CrackedAsset()
    {
        return rsg_UI_skull3CrackedAsset;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_bossSkullParent
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_bossSkullParent
    /// </returns>
    public GameObject GetBossSkullParent()
    {
        return rsg_UI_bossSkullParent;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_bossSkullBaseAsset
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_bossSkullBaseAsset
    /// </returns>
    public GameObject GetBossSkullBaseAsset()
    {
        return rsg_UI_bossSkullBaseAsset;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_bossSkullCrackedAsset
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_bossSkullCrackedAsset
    /// </returns>
    public GameObject GetBossSkullCrackedAsset()
    {
        return rsg_UI_bossSkullCrackedAsset;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_eventEncounterParent
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_eventEncounterParent
    /// </returns>
    public GameObject GetEventEncounterParent() 
    {
        return rsg_UI_eventEncounterParent;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_eventEncounterBaseAsset
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_eventEncounterBaseAsset
    /// </returns>
    public GameObject GetEventEncounterBaseAsset() 
    {
        return rsg_UI_eventEncounterBaseAsset;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_eventEncounterFinishedAsset
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_eventEncounterFinishedAsset
    /// </returns>
    public GameObject GetEventEncounterFinishedAsset()
    {
        return rsg_UI_eventEncounterFinishedAsset;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_defaultBonusContainer
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_defaultBonusContainer
    /// </returns>
    public GameObject GetDefaultBonusContainer()
    {
        return rsg_UI_defaultBonusContainer;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_redBonusContainer
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_redBonusContainer
    /// </returns>
    public GameObject GetRedBonusContainer()
    {
        return rsg_UI_redBonusContainer;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_blueBonusContainer
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_blueBonusContainer
    /// </returns>
    public GameObject GetBlueBonusContainer()
    {
        return rsg_UI_blueBonusContainer;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_yellowBonusContainer
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_yellowBonusContainer
    /// </returns>
    public GameObject GetYellowBonusContainer()
    {
        return rsg_UI_yellowBonusContainer;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_redBonusIcon1
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_redBonusIcon1
    /// </returns>
    public GameObject GetRedBonusIcon1()
    {
        return rsg_UI_redBonusIcon1;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_redBonusIcon2
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_redBonusIcon2
    /// </returns>
    public GameObject GetRedBonusIcon2()
    {
        return rsg_UI_redBonusIcon2;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_redBonusIcon3
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_redBonusIcon3
    /// </returns>
    public GameObject GetRedBonusIcon3()
    {
        return rsg_UI_redBonusIcon3;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_blueBonusIcon1
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_blueBonusIcon1
    /// </returns>
    public GameObject GetBlueBonusIcon1()
    {
        return rsg_UI_blueBonusIcon1;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_blueBonusIcon2
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_blueBonusIcon2
    /// </returns>
    public GameObject GetBlueBonusIcon2()
    {
        return rsg_UI_blueBonusIcon2;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_blueBonusIcon3
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_blueBonusIcon3
    /// </returns>
    public GameObject GetBlueBonusIcon3()
    {
        return rsg_UI_blueBonusIcon3;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_yellowBonusIcon1
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_yellowBonusIcon1
    /// </returns>
    public GameObject GetYellowBonusIcon1()
    {
        return rsg_UI_yellowBonusIcon1;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_yellowBonusIcon2
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_yellowBonusIcon2
    /// </returns>
    public GameObject GetYellowBonusIcon2()
    {
        return rsg_UI_yellowBonusIcon2;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_UI_yellowBonusIcon3
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_UI_yellowBonusIcon3
    /// </returns>
    public GameObject GetYellowBonusIcon3()
    {
        return rsg_UI_yellowBonusIcon3;
    }

    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_OriginalScale;
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_OriginalScale;
    /// </returns>
    public Vector3 getOriginalScale()
    {
        
        return rsg_OriginalScale;
    }
    /// <summary>
    /// Returns the gameobject of S_UIManager.rsg_ScaleTo;
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIManager.rsg_ScaleTo;
    /// </returns>
    public Vector3 getScaleTo()
    {
        rsg_ScaleTo = new Vector3(1, 1, 1);
        return rsg_ScaleTo;
    }
}
