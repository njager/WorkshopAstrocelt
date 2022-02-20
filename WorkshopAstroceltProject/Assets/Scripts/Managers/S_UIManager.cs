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

    //public int tempUIInitial;
    //public int tempUIMax;

    void Awake()
    {
        g_global = S_Global.Instance; 
        //tempUIInitial = 60;
        //tempUIMax = 100; 
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
    }
}
