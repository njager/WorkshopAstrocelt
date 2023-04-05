using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class S_FMODStaticSceneIdentifier : MonoBehaviour 
{
    [Header("Scene Types Bool")]
    private static bool b_combatScene;
    private static bool b_encounterScene;
    private static bool b_bossScene;
    private static bool b_titleScene;

    [Header("Update Loop Blocker")]
    private static bool b_stopAndPlay;

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

        // For update loop
        b_stopAndPlay = true;
        Debug.Log("Bools Changed to: " + b_combatScene + ", " + b_encounterScene + ", " + b_bossScene + ", " + b_titleScene);
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

        // For update loop
        b_stopAndPlay = true;
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

        // For update loop
        b_stopAndPlay = true;
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

        // For update loop
        b_stopAndPlay = true;
        Debug.Log("Bools Changed to: " + b_combatScene + ", " + b_encounterScene + ", " + b_bossScene + ", " + b_titleScene);
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

    /// <summary>
    /// Set the static bool value of S_FMODStaticSceneIdentifier.b_stopAndPlay
    /// - Josh 
    /// </summary>
    /// <param name="_truthValue"></param>
    public static void SetStopAndPlayParameter(bool _truthValue)
    {
        b_stopAndPlay = _truthValue;
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

    /// <summary>
    /// Returns the gameobject of S_FMODStaticSceneIdentifier.b_stopAndPlay
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_FMODStaticSceneIdentifier.b_stopAndPlay
    /// </returns>
    public static bool GetStopAndPlayBool()
    {
        return b_stopAndPlay;
    }
}
