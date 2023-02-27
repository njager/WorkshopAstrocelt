using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;


public class S_ResourceGraphics : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    [Header("Script Connections")]
    [SerializeField] S_Global g_global;
    [SerializeField] S_UIManager sc_UIManager;
    [SerializeField] S_StarClass s_StarClass;

    [SerializeField] Vector3 rsg_v3_tweenFrom = new Vector3 (1.5f,1.5f,1.5f);


    private void Awake()
    {
        g_global = S_Global.Instance;
        
    }

    public void Start()
    {
        ResetBonusTracker();
        ChangeProgressionBar(SceneManager.GetActiveScene().name);
    }

    private void Update()
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
        //print(_bonusCounter);
        if (_starColor.Equals("red"))
        {
            //turn off the other containers and turn on the red one
            sc_UIManager.GetDefaultBonusContainer().GetComponent<Image>().DOFade(0f, .5f);
            sc_UIManager.GetDefaultBonusContainer().SetActive(false);
            sc_UIManager.GetBlueBonusContainer().SetActive(false);
            sc_UIManager.GetYellowBonusContainer().SetActive(false);
            sc_UIManager.GetRedBonusContainer().SetActive(true);
            sc_UIManager.GetRedBonusContainer().GetComponent<Image>().DOFade(100f, .5f);

            //turn off the other individual icons
            sc_UIManager.GetBlueBonusIcon1().SetActive(false);
            sc_UIManager.GetBlueBonusIcon2().SetActive(false);
            sc_UIManager.GetBlueBonusIcon3().SetActive(false);

            sc_UIManager.GetYellowBonusIcon1().SetActive(false);
            sc_UIManager.GetYellowBonusIcon2().SetActive(false);
            sc_UIManager.GetYellowBonusIcon3().SetActive(false);

            //turn off the initial Icon
            sc_UIManager.GetRedBonusIcon1().SetActive(true);
            sc_UIManager.GetRedBonusIcon1().transform.DOPunchScale(rsg_v3_tweenFrom, 0.5f, 3, 1f);
            //Turn on or off additional icons
            if (_bonusCounter.Equals(2))
            {
                sc_UIManager.GetRedBonusIcon2().SetActive(true);
                //sc_UIManager.GetRedBonusIcon2().transform.DOScale(sc_UIManager.getScaleTo(), 0.5f);
                sc_UIManager.GetRedBonusIcon2().transform.DOPunchScale(rsg_v3_tweenFrom, 0.5f, 3, 1f);
                sc_UIManager.GetRedBonusIcon3().SetActive(false);
                
            }
            else if (_bonusCounter.Equals(3))
            {
                sc_UIManager.GetRedBonusIcon2().SetActive(true);
                sc_UIManager.GetRedBonusIcon3().SetActive(true);
                sc_UIManager.GetRedBonusIcon2().transform.DOPunchScale(rsg_v3_tweenFrom, 0.5f, 3, 1f);
                sc_UIManager.GetRedBonusIcon3().transform.DOPunchScale(rsg_v3_tweenFrom, 0.5f, 3, 1f);
               // sc_UIManager.GetRedBonusIcon3().transform.DOScale(sc_UIManager.getScaleTo(), 0.5f);
            }
            else
            {
                sc_UIManager.GetRedBonusIcon2().SetActive(false);
                sc_UIManager.GetRedBonusIcon3().SetActive(false);
            }
        }
        else if (_starColor.Equals("yellow"))
        {
            //turn off the other containers and turn on the yellow one
            sc_UIManager.GetDefaultBonusContainer().GetComponent<Image>().DOFade(0f, .5f);
            sc_UIManager.GetDefaultBonusContainer().SetActive(false);
            sc_UIManager.GetBlueBonusContainer().SetActive(false);
            sc_UIManager.GetYellowBonusContainer().SetActive(true);
            sc_UIManager.GetYellowBonusContainer().GetComponent<Image>().DOFade(100f, .5f);
            sc_UIManager.GetRedBonusContainer().SetActive(false);

            //turn off the other individual icons
            sc_UIManager.GetBlueBonusIcon1().SetActive(false);
            sc_UIManager.GetBlueBonusIcon2().SetActive(false);
            sc_UIManager.GetBlueBonusIcon3().SetActive(false);

            sc_UIManager.GetRedBonusIcon1().SetActive(false);
            sc_UIManager.GetRedBonusIcon2().SetActive(false);
            sc_UIManager.GetRedBonusIcon3().SetActive(false);

            //turn off the other initial icon
            sc_UIManager.GetYellowBonusIcon1().SetActive(true);
            //sc_UIManager.GetYellowBonusIcon1().transform.DOScale(sc_UIManager.getScaleTo(), 0.5f);
            sc_UIManager.GetYellowBonusIcon1().transform.DOPunchScale(rsg_v3_tweenFrom, 0.5f, 3, 1f);

            //Turn on or off additional icons
            if (_bonusCounter.Equals(2))
            {
                sc_UIManager.GetYellowBonusIcon2().SetActive(true);
                //sc_UIManager.GetYellowBonusIcon2().transform.DOScale(sc_UIManager.getScaleTo(), 0.5f);
                sc_UIManager.GetYellowBonusIcon2().transform.DOPunchScale(rsg_v3_tweenFrom, 0.5f, 3, 1f);
                sc_UIManager.GetYellowBonusIcon3().SetActive(false);
            }
            else if (_bonusCounter.Equals(3))
            {
                sc_UIManager.GetYellowBonusIcon2().SetActive(true);
                //sc_UIManager.GetYellowBonusIcon3().transform.DOScale(sc_UIManager.getScaleTo(), 0.5f);
                sc_UIManager.GetYellowBonusIcon2().transform.DOPunchScale(rsg_v3_tweenFrom, 0.5f, 3, 1f);
                sc_UIManager.GetYellowBonusIcon3().transform.DOPunchScale(rsg_v3_tweenFrom, 0.5f, 3, 1f);
                sc_UIManager.GetYellowBonusIcon3().SetActive(true);
            }
            else
            {
                sc_UIManager.GetYellowBonusIcon2().SetActive(false);
                sc_UIManager.GetYellowBonusIcon3().SetActive(false);
            }
        }
        else if (_starColor.Equals("blue"))
        {
            //turn off the other containers and turn on the blue one
            sc_UIManager.GetDefaultBonusContainer().GetComponent<Image>().DOFade(0f, 1.5f);
            sc_UIManager.GetDefaultBonusContainer().SetActive(false);
            sc_UIManager.GetBlueBonusContainer().SetActive(true);
            sc_UIManager.GetBlueBonusContainer().GetComponent<Image>().DOFade(100f, 1.5f);
            sc_UIManager.GetYellowBonusContainer().SetActive(false);
            sc_UIManager.GetRedBonusContainer().SetActive(false);

            //turn off the other individual icons
            sc_UIManager.GetRedBonusIcon1().SetActive(false);
            sc_UIManager.GetRedBonusIcon2().SetActive(false);
            sc_UIManager.GetRedBonusIcon3().SetActive(false);

            sc_UIManager.GetYellowBonusIcon1().SetActive(false);
            sc_UIManager.GetYellowBonusIcon2().SetActive(false);
            sc_UIManager.GetYellowBonusIcon3().SetActive(false);

            //turn off the other initial icon
            sc_UIManager.GetBlueBonusIcon1().SetActive(true);
            sc_UIManager.GetBlueBonusIcon1().transform.DOPunchScale(rsg_v3_tweenFrom, 0.5f, 3, 1f);
            //sc_UIManager.GetBlueBonusIcon1().transform.DOScale(sc_UIManager.getScaleTo(), 1.5f);


            //Turn on or off additional icons
            if (_bonusCounter.Equals(2))
            {
                sc_UIManager.GetBlueBonusIcon2().SetActive(true);
                //sc_UIManager.GetBlueBonusIcon2().transform.DOScale(sc_UIManager.getScaleTo(), 1.5f);
                sc_UIManager.GetBlueBonusIcon2().transform.DOPunchScale(rsg_v3_tweenFrom, 0.5f, 3, 1f);
                sc_UIManager.GetBlueBonusIcon3().SetActive(false);
            }
            else if (_bonusCounter.Equals(3))
            {
                sc_UIManager.GetBlueBonusIcon2().SetActive(true);
                sc_UIManager.GetBlueBonusIcon3().SetActive(true);
                //sc_UIManager.GetBlueBonusIcon3().transform.DOScale(sc_UIManager.getScaleTo(), 1.5f);
                sc_UIManager.GetBlueBonusIcon2().transform.DOPunchScale(rsg_v3_tweenFrom, 0.5f, 3, 1f);
                sc_UIManager.GetBlueBonusIcon3().transform.DOPunchScale(rsg_v3_tweenFrom, 0.5f, 3, 1f);
            }
            else
            {
                sc_UIManager.GetBlueBonusIcon2().SetActive(false);
                sc_UIManager.GetBlueBonusIcon3().SetActive(false);
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
            sc_UIManager.GetUIEncounterSelector().SetActive(true);

            sc_UIManager.GetSkull2Parent().SetActive(true);
            sc_UIManager.GetSkull2CrackedAsset().SetActive(false);
            sc_UIManager.GetSkull2BaseAsset().SetActive(true);
            

            sc_UIManager.GetSkull3Parent().SetActive(true);
            sc_UIManager.GetSkull3BaseAsset().SetActive(true);
            sc_UIManager.GetSkull3CrackedAsset().SetActive(false);
            //sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetBossSkullParent().SetActive(true);
            sc_UIManager.GetBossSkullBaseAsset().SetActive(true);
            //sc_UIManager.GetBossSkullCrackedAsset().SetActive(false);
            //sc_UIManager.GetUIEncounterSelector().SetActive(false);

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
            sc_UIManager.GetUIEncounterSelector().SetActive(true);
            //sc_UIManager.GetUIEncounterSelector().transform.position = sc_UIManager.GetSkull2Parent().transform.position;
            sc_UIManager.GetUIEncounterSelector().transform.DOMove(sc_UIManager.GetSkull2Parent().transform.position, 1.5f, true);

            sc_UIManager.GetSkull3Parent().SetActive(true);
            sc_UIManager.GetSkull3BaseAsset().SetActive(true);
            sc_UIManager.GetSkull3CrackedAsset().SetActive(false);
            //sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetBossSkullParent().SetActive(true);
            sc_UIManager.GetBossSkullBaseAsset().SetActive(true);
            //sc_UIManager.GetBossSkullCrackedAsset().SetActive(false);
            //sc_UIManager.GetUIEncounterSelector().SetActive(false);

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
            //sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetSkull3Parent().SetActive(true);
            sc_UIManager.GetSkull3BaseAsset().SetActive(true);
            sc_UIManager.GetSkull3CrackedAsset().SetActive(false);
            sc_UIManager.GetUIEncounterSelector().SetActive(true);
            //sc_UIManager.GetUIEncounterSelector().transform.position = sc_UIManager.GetSkull3Parent().transform.position;
            sc_UIManager.GetUIEncounterSelector().transform.DOMove(sc_UIManager.GetSkull3Parent().transform.position, 0.5f, true);


            sc_UIManager.GetBossSkullParent().SetActive(true);
            sc_UIManager.GetBossSkullBaseAsset().SetActive(true);
            //sc_UIManager.GetBossSkullCrackedAsset().SetActive(false);
            //sc_UIManager.GetUIEncounterSelector().SetActive(false);

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
            //sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetSkull3Parent().SetActive(true);
            sc_UIManager.GetSkull3BaseAsset().SetActive(false);
            sc_UIManager.GetSkull3CrackedAsset().SetActive(true);
            //sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetBossSkullParent().SetActive(true);
            sc_UIManager.GetBossSkullBaseAsset().SetActive(true);
            //sc_UIManager.GetBossSkullCrackedAsset().SetActive(false);
            sc_UIManager.GetUIEncounterSelector().SetActive(true);
            //sc_UIManager.GetUIEncounterSelector().transform.position = sc_UIManager.GetBossSkullParent().transform.position;
            sc_UIManager.GetUIEncounterSelector().transform.DOMove(sc_UIManager.GetBossSkullParent().transform.position, 0.5f, true);

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
            sc_UIManager.GetBossSkullBaseAsset().SetActive(true);
            //sc_UIManager.GetBossSkullCrackedAsset().SetActive(true);
            sc_UIManager.GetUIEncounterSelector().SetActive(false);

            sc_UIManager.GetEventEncounterParent().SetActive(true);
            sc_UIManager.GetEventEncounterBaseAsset().SetActive(true);
            sc_UIManager.GetEventEncounterFinishedAsset().SetActive(false);
        }
    }


  
}
