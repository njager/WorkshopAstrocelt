using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class S_ResourceGraphics : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    [Header("Script Connections")]
    [SerializeField] S_Global g_global;
    [SerializeField] S_UIManager sc_UIManager;

    

    private void Awake()
    {
        g_global = S_Global.Instance;
        
    }

    public void Start()
    {
        ResetBonusTracker();
    }

    void Update()
    {
        EnergyTrackingUIUpdate(); // Temporary, eventually make S_EnergyManager update it on changing of the energy amounts
        UpdateResourceBarGraphics();
        ConstellationTracker();
    }

    public void ResetBonusTracker()
    {
        rsg_UI_defaultBonusContainer.enabled = true;
        rsg_UI_blueBonusContainer.enabled = false;
        rsg_UI_yellowBonusContainer.enabled = false;
        rsg_UI_redBonusContainer.enabled = false;

        rsg_UI_blueBonusIcon1.enabled = false;
        rsg_UI_blueBonusIcon2.enabled = false;
        rsg_UI_blueBonusIcon3.enabled = false;

        rsg_UI_yellowBonusIcon1.enabled = false;
        rsg_UI_yellowBonusIcon2.enabled = false;
        rsg_UI_yellowBonusIcon3.enabled = false;

        rsg_UI_redBonusIcon1.enabled = false;
        rsg_UI_redBonusIcon2.enabled = false;
        rsg_UI_redBonusIcon3.enabled = false;
    }

    /////////////////////////////------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Resource Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// EnergyTrackingUI update function
    /// Update the individual elements with new values as energy is generated, clear on turn end
    /// - Thoman and Josh
    /// </summary>
    public void EnergyTrackingUIUpdate()
    {
        // Update red energy
        g_global.g_UIManager.GetRedEnergyTrackerText().text = "" + g_global.g_energyManager.GetRedEnergyInt();
        // Update blue energy
        g_global.g_UIManager.GetBlueEnergyTrackerText().text = ""  + g_global.g_energyManager.GetBlueEnergyInt();
        //Update yellow energy
        g_global.g_UIManager.GetYellowEnergyTrackerText().text = ""  + g_global.g_energyManager.GetYellowEnergyInt();
    }

    public void UpdateResourceBarGraphics() 
    {
        // Set resource bar text
        sc_UIManager.SetPlayerResourceHealthText(g_global.g_playerAttributeSheet.GetPlayerHealthValue(), g_global.g_playerAttributeSheet.GetPlayerMaxHealthValue());
    }

    /// <summary>
    /// Constellation Tracker UI function 
    /// -THOMAN
    /// </summary>
    public void ConstellationTracker()
    {
        int current = g_global.g_ConstellationManager.ls_curConstellation.Count();
        if (current <= 0)
        {
            g_global.g_UIManager.GetConstellationUI().text = "" + 0 + "/7";           
        }
        else
        {
            g_global.g_UIManager.GetConstellationUI().text = "" + (current - 1) + "/7";
        }
        
    }

    /// <summary>
    /// Change and update the bonus energy tiers
    /// - Josh and Goat
    /// </summary>
    /// <param name="_star"></param>
    public void BonusTracker(S_StarClass _star)
    {
       if (_star.colorType == "red")
        {
            rsg_UI_defaultBonusContainer.enabled = false;
            rsg_UI_blueBonusContainer.enabled = false;
            rsg_UI_yellowBonusContainer.enabled = false;
            rsg_UI_redBonusContainer.enabled = true;

            rsg_UI_blueBonusIcon1.enabled = false;
            rsg_UI_blueBonusIcon2.enabled = false;
            rsg_UI_blueBonusIcon3.enabled = false;

            rsg_UI_yellowBonusIcon1.enabled = false;
            rsg_UI_yellowBonusIcon2.enabled = false;
            rsg_UI_yellowBonusIcon3.enabled = false;

            rsg_UI_redBonusIcon1.enabled = true;
            rsg_UI_i_bonusTracker++;
            if (_star.colorType == "red" && rsg_UI_i_bonusTracker == 2)
            {
                rsg_UI_redBonusIcon2.enabled = true;
            }
            else { rsg_UI_i_bonusTracker = 1; ResetBonusTracker(); }
            if (_star.colorType == "red" && rsg_UI_i_bonusTracker == 3)
            {
                rsg_UI_redBonusIcon3.enabled = true;
            }
            else { rsg_UI_i_bonusTracker = 1; ResetBonusTracker(); }
        }

        if (_star.colorType == "yellow")
        {
            rsg_UI_defaultBonusContainer.enabled = false;
            rsg_UI_blueBonusContainer.enabled = false;
            rsg_UI_yellowBonusContainer.enabled = true;
            rsg_UI_redBonusContainer.enabled = false;

            rsg_UI_blueBonusIcon1.enabled = false;
            rsg_UI_blueBonusIcon2.enabled = false;
            rsg_UI_blueBonusIcon3.enabled = false;

            rsg_UI_yellowBonusIcon1.enabled = true;
            rsg_UI_i_bonusTracker++;
            

            rsg_UI_redBonusIcon1.enabled = false;
            rsg_UI_redBonusIcon2.enabled = false;
            rsg_UI_redBonusIcon3.enabled = false;
            if(_star.colorType == "yellow" && rsg_UI_i_bonusTracker == 2)
            {
                rsg_UI_yellowBonusIcon2.enabled = true;
            }
            else { rsg_UI_i_bonusTracker = 1; ResetBonusTracker(); }
            if (_star.colorType == "yellow" && rsg_UI_i_bonusTracker == 3)
            {
                rsg_UI_yellowBonusIcon3.enabled = true;
            }
            else { rsg_UI_i_bonusTracker = 1; ResetBonusTracker(); }
        }
        if (_star.colorType == "blue")
        {
            rsg_UI_defaultBonusContainer.enabled = false;
            rsg_UI_blueBonusContainer.enabled = true;
            rsg_UI_yellowBonusContainer.enabled = false;
            rsg_UI_redBonusContainer.enabled = false;

            rsg_UI_blueBonusIcon1.enabled = true;
            rsg_UI_blueBonusIcon2.enabled = false;
            rsg_UI_blueBonusIcon3.enabled = false;
            rsg_UI_i_bonusTracker++;

            rsg_UI_yellowBonusIcon1.enabled = false;
            rsg_UI_yellowBonusIcon2.enabled = false;
            rsg_UI_yellowBonusIcon3.enabled = false;

            rsg_UI_redBonusIcon1.enabled = false;
            rsg_UI_redBonusIcon2.enabled = false;
            rsg_UI_redBonusIcon3.enabled = false;

            if (_star.colorType == "blue" && rsg_UI_i_bonusTracker == 2)
            {
                rsg_UI_blueBonusIcon2.enabled = true;
            }
            else { rsg_UI_i_bonusTracker = 1; ResetBonusTracker(); }
            if (_star.colorType == "blue" && rsg_UI_i_bonusTracker == 3)
            {
                rsg_UI_blueBonusIcon3.enabled = true;
            }
            else { rsg_UI_i_bonusTracker = 1; ResetBonusTracker(); }

        }
    }


    /// <summary>
    /// Change the encounter selector
    /// Turn off and on skulls
    /// - Goat and Josh
    /// </summary>
    /// <param name="_scene"></param>
    public void ChangeProgressionBar(string _scene)
    {
        if (_scene == "Scn_1stEnemyEncounter")
        {
            GetUISkull1Parent().SetActive(false);

            Skull2.enabled = true;
            Skull2_Crack.enabled = false;
            GetUIEncounterSelector().SetActive(false);

            Skull3.enabled = true;
            Skull3_Crack.enabled = false;
            GetUIEncounterSelector().SetActive(false);

            SkullBoss.enabled = true;
            GetUIEncounterSelector().SetActive(false);

            encounterSprite.enabled = true;
            encounterSprite_Selector.enabled = false;
        }

        if (_scene == "Scn_2ndEnemyEncounter")
        {
            Skull1_Crack.enabled = true;
            Skull1.enabled = false;
            GetUIEncounterSelector().SetActive(false);

            Skull2.enabled = true;
            Skull2_Crack.enabled = false;
            GetUIEncounterSelector().SetActive(false);

            Skull3.enabled = true;
            Skull3_Crack.enabled = false;
            GetUIEncounterSelector().SetActive(false);

            SkullBoss.enabled = true;
            GetUIEncounterSelector().SetActive(false);

            encounterSprite.enabled = true;
            encounterSprite_Selector.enabled = false;
        }

        if (_scene == "Scn_3rdEnemyEncounter")
        {
            Skull1_Crack.enabled = true;
            Skull1.enabled = false;
            Skull1_Selector.enabled = false;

            Skull2.enabled = false;
            Skull2_Crack.enabled = true;
            Skull2_Selector.enabled = false;

            Skull3.enabled = true;
            Skull3_Crack.enabled = false;
            Skull3_Selector.enabled = false;

            SkullBoss.enabled = true;
            SkullBoss_Selector.enabled = true;

            encounterSprite.enabled = true;
            encounterSprite_Selector.enabled = false;
        }

        if (_scene == "Scn_4thEnemyEncounter")
        {
            Skull1_Crack.enabled = true;
            Skull1.enabled = false;
            Skull1_Selector.enabled = false;

            Skull2.enabled = false;
            Skull2_Crack.enabled = true;
            Skull2_Selector.enabled = false;

            Skull3_Crack.enabled = true;
            Skull3.enabled = false;
            Skull3_Selector.enabled = false;

            SkullBoss.enabled = true;
            SkullBoss_Selector.enabled = true;

            encounterSprite.enabled = true;
            encounterSprite_Selector.enabled = false;
        }

        if (_scene == "Event1-Bog" || _scene == "Event2-Mushrooms" || _scene == "Event3-Victory")
        {
            Skull1_Crack.enabled = true;
            Skull1.enabled = false;
            Skull1_Selector.enabled = false;

            Skull2.enabled = false;
            Skull2_Crack.enabled = true;
            Skull2_Selector.enabled = false;

            Skull3_Crack.enabled = true;
            Skull3.enabled = false;
            Skull3_Selector.enabled = false;

            SkullBoss.enabled = false;
            SkullBoss_Selector.enabled = false;

            encounterSprite.enabled = true;
            encounterSprite_Selector.enabled = true;
        }
    }


    /*rsg_UI_encounterSelector; GetUIEncounterSelector()
rsg_UI_skull1Parent; GetUISkull1Parent()
rsg_UI_skull1BaseAsset; GetSkull1BaseAsset()
rsg_UI_skull1CrackedAsset; GetSkull1CrackedAsset()
rsg_UI_skull2Parent; GetSkull2CrackedAsset()
rsg_UI_skull2BaseAsset; GetSkull2BaseAsset()
rsg_UI_skull2CrackedAsset; GetSkull2CrackedAsset()
rsg_UI_skull3Parent; GetSkull3Parent()
rsg_UI_skull3BaseAsset; GetSkull3BaseAsset()
rsg_UI_skull3CrackedAsset; GetSkull3CrackedAsset()
rsg_UI_bossSkullParent; GetBossSkullParent()
rsg_UI_bossSkullBaseAsset; GetBossSkullBaseAsset()
rsg_UI_bossSkullCrackedAsset; GetBossSkullCrackedAsset()
rsg_UI_eventEncounterBaseAsset; GetEventEncounterBaseAsset()
rsg_UI_eventEncounterFinishedAsset; GetEventEncounterFinishedAsset();*/
}
