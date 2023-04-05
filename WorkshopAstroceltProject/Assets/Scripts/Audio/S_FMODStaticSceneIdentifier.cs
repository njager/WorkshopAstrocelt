using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public static class S_FMODStaticSceneIdentifier 
{
    [Header("Scene Types Bool")]
    [SerializeField] static bool b_combatScene;
    [SerializeField] static bool b_encounterScene;
    [SerializeField] static bool b_bossScene;
    [SerializeField] static bool b_titleScene;

    /// <summary>
    /// Public method to declare the bool to tell FMOD what parameter to use for the global background track
    /// This is the combat scene method
    /// - Josh
    /// </summary>
    public static void TriggerCombatSceneBool() 
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
    public static void TriggerEncounterSceneBool()
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
    public static void TriggerBossSceneBool()
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
    public static void TriggerTitleSceneBool()
    {
        b_combatScene = false;
        b_encounterScene = false;
        b_bossScene = false;
        b_titleScene = true;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the static bool value of S_FMODStaticSceneIdentifier.b_combatScene
    /// - Josh 
    /// </summary>
    /// <param name="_truthValue"></param>
    public static void SetCombatSceneBoolParameter(bool _truthValue)
    {
        b_combatScene = _truthValue;
    }

    /// <summary>
    /// Set the static bool value of S_FMODStaticSceneIdentifier.b_encounterScene
    /// - Josh 
    /// </summary>
    /// <param name="_truthValue"></param>
    public static void SetEncounterSceneBoolParameter(bool _truthValue)
    {
        b_encounterScene = _truthValue;
    }

    /// <summary>
    /// Set the static bool value of S_FMODStaticSceneIdentifier.b_bossScene
    /// - Josh 
    /// </summary>
    /// <param name="_truthValue"></param>
    public static void SetBossSceneBoolParameter(bool _truthValue)
    {
        b_bossScene = _truthValue;
    }

    /// <summary>
    /// Set the static bool value of S_FMODStaticSceneIdentifier.b_bossScene
    /// - Josh 
    /// </summary>
    /// <param name="_truthValue"></param>
    public static void SetTitleSceneBoolParameter(bool _truthValue)
    {
        b_titleScene = _truthValue;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Returns the gameobject of S_FMODStaticSceneIdentifier.b_combatScene
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_FMODStaticSceneIdentifier.b_combatScene
    /// </returns>
    public static bool GetCombatSceneParameterBool()
    {
        return b_combatScene;
    }

    /// <summary>
    /// Returns the gameobject of S_FMODStaticSceneIdentifier.b_encounterScene
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_FMODStaticSceneIdentifier.b_encounterScene
    /// </returns>
    public static bool GetEncounterSceneParameterBool()
    {
        return b_encounterScene;
    }

    /// <summary>
    /// Returns the gameobject of S_FMODStaticSceneIdentifier.b_bossScene
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_FMODStaticSceneIdentifier.b_bossScene
    /// </returns>
    public static bool GetBossSceneParameterBool()
    {
        return b_bossScene;
    }

    /// <summary>
    /// Returns the gameobject of S_FMODStaticSceneIdentifier.b_titleScene
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_FMODStaticSceneIdentifier.b_titleScene
    /// </returns>
    public static bool GetTitleSceneParameterBool()
    {
        return b_titleScene;
    }
}
