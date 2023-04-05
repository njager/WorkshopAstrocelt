using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMODUnityResonance;
using FMOD;

public class S_FMODStaticSceneIdentifier : MonoBehaviour 
{
    [Header("Scene Types Bool")]
    [SerializeField] static bool b_titleScene;
    [SerializeField] static bool b_combatScene;
    [SerializeField] static bool b_encounterScene;
    [SerializeField] static bool b_bossScene;

    [Header("Global Audio Track Object")]
    public StudioEventEmitter emitter;

    private void Start()
    {
        emitter.Play();
    }

    private void Update()
    {
        // Update FMOD track in here
        if (b_combatScene == true && (b_titleScene == false && b_encounterScene == false && b_bossScene == false)) 
        {
            emitter.SetParameter("CurrentScene", 1);
        }
        else 
        {
            return;
        }

        if (b_encounterScene == true && (b_titleScene == false && b_combatScene == false && b_bossScene == false))
        {
            emitter.SetParameter("CurrentScene", 0);
        }
        else 
        {
            return;
        }

        if (b_bossScene == true && (b_titleScene == false && b_encounterScene == false && b_combatScene == false))
        {
            emitter.SetParameter("CurrentScene", 2);
        }
        else
        {
            return;
        }

        if (b_titleScene == true && (b_combatScene == false && b_encounterScene == false && b_bossScene == false))
        {
            emitter.SetParameter("CurrentScene", 3);
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// Public method to declare the bool to tell FMOD what parameter to use for the global background track
    /// This is the combat scene method
    /// - Josh
    /// </summary>
    public void TriggerCombatSceneBool() 
    {
        b_combatScene = true;
        b_encounterScene = false;
        b_bossScene = false;
        b_titleScene = false;
    }

    /// <summary>
    /// Public method to declare the bool to tell FMOD what parameter to use for the global background track
    /// This is the encounter scene method
    /// - Josh
    /// </summary>
    public void TriggerEncounterSceneBool()
    {
        b_combatScene = false;
        b_encounterScene = true;
        b_bossScene = false;
        b_titleScene = false;
    }

    /// <summary>
    /// Public method to declare the bool to tell FMOD what parameter to use for the global background track
    /// This is the boss scene method
    /// - Josh
    /// </summary>
    public void TriggerBossSceneBool()
    {
        b_combatScene = false;
        b_encounterScene = false;
        b_bossScene = true;
        b_titleScene = false;
    }

    /// <summary>
    /// Public method to declare the bool to tell FMOD what parameter to use for the global background track
    /// This is the title scene method
    /// - Josh
    /// </summary>
    public void TriggerTitleSceneBool()
    {
        b_combatScene = false;
        b_encounterScene = false;
        b_bossScene = false;
        b_titleScene = true;
    }
}
