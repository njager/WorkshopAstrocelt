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
    [SerializeField] S_StarClass s_StarClass;


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
        sc_UIManager.GetDefaultBonusContainer().SetActive(true);
        sc_UIManager.GetBlueBonusContainer().SetActive(false);
        sc_UIManager.GetYellowBonusContainer().SetActive(false);
        sc_UIManager.GetRedBonusContainer().SetActive(false);



        sc_UIManager.GetBlueBonusIcon1().SetActive(false);
        sc_UIManager.GetBlueBonusIcon2().SetActive(false);
        sc_UIManager.GetBlueBonusIcon3().SetActive(false);


        sc_UIManager.GetYellowBonusIcon1().SetActive(false);
        sc_UIManager.GetYellowBonusIcon2().SetActive(false);
        sc_UIManager.GetYellowBonusIcon3().SetActive(false);


        sc_UIManager.GetRedBonusIcon1().SetActive(false);
        sc_UIManager.GetRedBonusIcon2().SetActive(false);
        sc_UIManager.GetRedBonusIcon3().SetActive(false);

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
    public void BonusTracker(string _starColor, int _bonusCounter)
    {
        //print(_starColor);
        if (_starColor.Equals("red"))
        {
            //print(_starColor);
            sc_UIManager.GetDefaultBonusContainer().SetActive(false);
            sc_UIManager.GetBlueBonusContainer().SetActive(false);
            sc_UIManager.GetYellowBonusContainer().SetActive(false);
            sc_UIManager.GetRedBonusContainer().SetActive(true);



            sc_UIManager.GetBlueBonusIcon1().SetActive(false);
            sc_UIManager.GetBlueBonusIcon2().SetActive(false);
            sc_UIManager.GetBlueBonusIcon3().SetActive(false);


            sc_UIManager.GetYellowBonusIcon1().SetActive(false);
            sc_UIManager.GetYellowBonusIcon2().SetActive(false);
            sc_UIManager.GetYellowBonusIcon3().SetActive(false);


            sc_UIManager.GetRedBonusIcon1().SetActive(true);
            _bonusCounter ++;
            if (_starColor.Equals("red") && _bonusCounter == 1)
            {
                print(_starColor + "2");
                print("bonus counter:" + _bonusCounter);
                sc_UIManager.GetRedBonusIcon2().SetActive(true);
            }
            
            else if (_starColor.Equals("red") && _bonusCounter == 2)
            {
                print(_starColor + "3");
                print("bonus counter:" + _bonusCounter);
                sc_UIManager.GetRedBonusIcon3().SetActive(true);
            }
            else {
                _bonusCounter = 0; 
                ResetBonusTracker(); 
            }
        }

        else if (_starColor.Equals("yellow"))
        {
            print(_starColor);
            sc_UIManager.GetDefaultBonusContainer().SetActive(false);
            sc_UIManager.GetBlueBonusContainer().SetActive(false);
            sc_UIManager.GetYellowBonusContainer().SetActive(true);
            sc_UIManager.GetRedBonusContainer().SetActive(false);



            sc_UIManager.GetBlueBonusIcon1().SetActive(false);
            sc_UIManager.GetBlueBonusIcon2().SetActive(false);
            sc_UIManager.GetBlueBonusIcon3().SetActive(false);


            
            sc_UIManager.GetRedBonusIcon1().SetActive(false);
            sc_UIManager.GetRedBonusIcon2().SetActive(false);
            sc_UIManager.GetRedBonusIcon3().SetActive(false);


            sc_UIManager.GetYellowBonusIcon1().SetActive(true);

            _bonusCounter++;
            if (_starColor.Equals("yellow") && _bonusCounter == 1)
            {
                print(_starColor + "2");
                print("bonus counter:" + _bonusCounter);
                sc_UIManager.GetYellowBonusIcon2().SetActive(true);
            }
           /* else 
            { 
                _bonusCounter = 0; 
                ResetBonusTracker(); 
            }*/
           else  if (_starColor.Equals("yellow") && _bonusCounter == 2)
            {
                print(_starColor + "3");
                print("bonus counter:" + _bonusCounter);
                sc_UIManager.GetYellowBonusIcon3().SetActive(true);
            }
            else 
            { 
                _bonusCounter = 0; 
                ResetBonusTracker(); 
            }
        }
        else if (_starColor.Equals("blue"))
        {
            print(_starColor);
            sc_UIManager.GetDefaultBonusContainer().SetActive(false);
            sc_UIManager.GetBlueBonusContainer().SetActive(true);
            sc_UIManager.GetYellowBonusContainer().SetActive(false);
            sc_UIManager.GetRedBonusContainer().SetActive(false);

            sc_UIManager.GetRedBonusIcon1().SetActive(false);
            sc_UIManager.GetRedBonusIcon2().SetActive(false);
            sc_UIManager.GetRedBonusIcon3().SetActive(false);

            sc_UIManager.GetYellowBonusIcon1().SetActive(false);
            sc_UIManager.GetYellowBonusIcon2().SetActive(false);
            sc_UIManager.GetYellowBonusIcon3().SetActive(false);


            sc_UIManager.GetBlueBonusIcon1().SetActive(true);
            _bonusCounter++;
            if (_starColor.Equals("blue") && _bonusCounter == 1)
            {
                print(_starColor + "2");
                print("bonus counter:" + _bonusCounter);
                sc_UIManager.GetBlueBonusIcon2().SetActive(true);
            }
           /* else 
            { 
                _bonusCounter = 0; 
                ResetBonusTracker(); 
            }*/
            else if (_starColor.Equals("blue") && _bonusCounter == 2)
            {
                print(_starColor + "3" );
                print("bonus counter:" + _bonusCounter);
                sc_UIManager.GetBlueBonusIcon3().SetActive(true);
            }
            else 
            { 
                _bonusCounter = 0; 
                ResetBonusTracker();
            }

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
            sc_UIManager.GetUISkull1Parent().SetActive(true);
            sc_UIManager.GetSkull1BaseAsset().SetActive(true);
            sc_UIManager.GetSkull1CrackedAsset().SetActive(false);

            sc_UIManager.GetSkull2Parent().SetActive(true);
            sc_UIManager.GetSkull2CrackedAsset().SetActive(false);
            sc_UIManager.GetSkull2BaseAsset().SetActive(true);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetSkull3Parent().SetActive(true);
            sc_UIManager.GetSkull3BaseAsset().SetActive(true);
            sc_UIManager.GetSkull3CrackedAsset().SetActive(false);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetBossSkullParent().SetActive(true);
            sc_UIManager.GetBossSkullBaseAsset().SetActive(true);
            sc_UIManager.GetBossSkullCrackedAsset().SetActive(false);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetEventEncounterParent().SetActive(true);
            sc_UIManager.GetEventEncounterBaseAsset().SetActive(true);
            sc_UIManager.GetEventEncounterFinishedAsset().SetActive(false);
            //encounterSprite_Selector.enabled = false;
        }

        if (_scene == "Scn_2ndEnemyEncounter")
        {
            sc_UIManager.GetUISkull1Parent().SetActive(true);
            sc_UIManager.GetSkull1BaseAsset().SetActive(false);
            sc_UIManager.GetSkull1CrackedAsset().SetActive(true);

            sc_UIManager.GetSkull2Parent().SetActive(true);
            sc_UIManager.GetSkull2CrackedAsset().SetActive(false);
            sc_UIManager.GetSkull2BaseAsset().SetActive(true);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetSkull3Parent().SetActive(true);
            sc_UIManager.GetSkull3BaseAsset().SetActive(true);
            sc_UIManager.GetSkull3CrackedAsset().SetActive(false);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetBossSkullParent().SetActive(true);
            sc_UIManager.GetBossSkullBaseAsset().SetActive(true);
            sc_UIManager.GetBossSkullCrackedAsset().SetActive(false);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetEventEncounterParent().SetActive(true);
            sc_UIManager.GetEventEncounterBaseAsset().SetActive(true);
            sc_UIManager.GetEventEncounterFinishedAsset().SetActive(false);
        }

        if (_scene == "Scn_3rdEnemyEncounter")
        {
            sc_UIManager.GetUISkull1Parent().SetActive(true);
            sc_UIManager.GetSkull1BaseAsset().SetActive(false);
            sc_UIManager.GetSkull1CrackedAsset().SetActive(true);

            sc_UIManager.GetSkull2Parent().SetActive(true);
            sc_UIManager.GetSkull2CrackedAsset().SetActive(true);
            sc_UIManager.GetSkull2BaseAsset().SetActive(false);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetSkull3Parent().SetActive(true);
            sc_UIManager.GetSkull3BaseAsset().SetActive(true);
            sc_UIManager.GetSkull3CrackedAsset().SetActive(false);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetBossSkullParent().SetActive(true);
            sc_UIManager.GetBossSkullBaseAsset().SetActive(true);
            sc_UIManager.GetBossSkullCrackedAsset().SetActive(false);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetEventEncounterParent().SetActive(true);
            sc_UIManager.GetEventEncounterBaseAsset().SetActive(true);
            sc_UIManager.GetEventEncounterFinishedAsset().SetActive(false);
        }

        if (_scene == "Scn_4thEnemyEncounter")
        {
            sc_UIManager.GetUISkull1Parent().SetActive(true);
            sc_UIManager.GetSkull1BaseAsset().SetActive(false);
            sc_UIManager.GetSkull1CrackedAsset().SetActive(true);

            sc_UIManager.GetSkull2Parent().SetActive(true);
            sc_UIManager.GetSkull2CrackedAsset().SetActive(true);
            sc_UIManager.GetSkull2BaseAsset().SetActive(false);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetSkull3Parent().SetActive(true);
            sc_UIManager.GetSkull3BaseAsset().SetActive(false);
            sc_UIManager.GetSkull3CrackedAsset().SetActive(true);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetBossSkullParent().SetActive(true);
            sc_UIManager.GetBossSkullBaseAsset().SetActive(true);
            sc_UIManager.GetBossSkullCrackedAsset().SetActive(false);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetEventEncounterParent().SetActive(true);
            sc_UIManager.GetEventEncounterBaseAsset().SetActive(true);
            sc_UIManager.GetEventEncounterFinishedAsset().SetActive(false);
        }

        if (_scene == "Event1-Bog" || _scene == "Event2-Mushrooms" || _scene == "Event3-Victory")
        {
            sc_UIManager.GetUISkull1Parent().SetActive(true);
            sc_UIManager.GetSkull1BaseAsset().SetActive(false);
            sc_UIManager.GetSkull1CrackedAsset().SetActive(true);

            sc_UIManager.GetSkull2Parent().SetActive(true);
            sc_UIManager.GetSkull2CrackedAsset().SetActive(true);
            sc_UIManager.GetSkull2BaseAsset().SetActive(false);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetSkull3Parent().SetActive(true);
            sc_UIManager.GetSkull3BaseAsset().SetActive(false);
            sc_UIManager.GetSkull3CrackedAsset().SetActive(true);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetBossSkullParent().SetActive(true);
            sc_UIManager.GetBossSkullBaseAsset().SetActive(false);
            sc_UIManager.GetBossSkullCrackedAsset().SetActive(true);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetEventEncounterParent().SetActive(true);
            sc_UIManager.GetEventEncounterBaseAsset().SetActive(true);
            sc_UIManager.GetEventEncounterFinishedAsset().SetActive(false);
        }
    }


  
}
