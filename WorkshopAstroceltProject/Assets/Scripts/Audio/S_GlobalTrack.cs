using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class S_GlobalTrack : MonoBehaviour
{
    [Header("Game Manager")]
    [SerializeField] S_GameManager g_gameManager;

    [Header("Global Audio Track Object")]
    public StudioEventEmitter globalTrackEmitter;

    private void Start()
    {
        g_gameManager = S_GameManager.Instance;

        globalTrackEmitter.Play();
    }

    private void Update()
    {
        ChangeVolume();

        S_FMODStaticSceneIdentifier.SetTimeInSceneFloat(S_FMODStaticSceneIdentifier.GetTimeInSceneFloat() + Time.deltaTime);

        // Update FMOD track in here
        if (S_FMODStaticSceneIdentifier.GetCombatSceneParameterBool() == true && (S_FMODStaticSceneIdentifier.GetTitleSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetEncounterSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetBossSceneParameterBool() == false))
        {
            globalTrackEmitter.SetParameter("CurrentScene", 1);
            globalTrackEmitter.SetParameter("TimeInScene", S_FMODStaticSceneIdentifier.GetTimeInSceneFloat());
            globalTrackEmitter.SetParameter("PlayerHealth", (float)g_gameManager.i_playerHealth);

            if (S_FMODStaticSceneIdentifier.GetStopAndPlayBool() == true)
            {
                S_FMODStaticSceneIdentifier.SetStopAndPlayParameter(false);
                globalTrackEmitter.Stop();
                globalTrackEmitter.Play();
                Debug.Log("We stopped and played");
            }
        }

        if (S_FMODStaticSceneIdentifier.GetEncounterSceneParameterBool() == true && (S_FMODStaticSceneIdentifier.GetTitleSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetCombatSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetBossSceneParameterBool() == false))
        {
            globalTrackEmitter.SetParameter("CurrentScene", 0);
            globalTrackEmitter.SetParameter("TimeInScene", S_FMODStaticSceneIdentifier.GetTimeInSceneFloat());
            globalTrackEmitter.SetParameter("PlayerHealth", (float)g_gameManager.i_playerHealth);

            if (S_FMODStaticSceneIdentifier.GetStopAndPlayBool() == true)
            {
                S_FMODStaticSceneIdentifier.SetStopAndPlayParameter(false);
                globalTrackEmitter.Stop();
                globalTrackEmitter.Play();
                Debug.Log("We stopped and played");
            }
        }

        if (S_FMODStaticSceneIdentifier.GetBossSceneParameterBool() == true && (S_FMODStaticSceneIdentifier.GetTitleSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetEncounterSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetCombatSceneParameterBool() == false))
        {
            globalTrackEmitter.SetParameter("CurrentScene", 2);
            globalTrackEmitter.SetParameter("TimeInScene", S_FMODStaticSceneIdentifier.GetTimeInSceneFloat());
            globalTrackEmitter.SetParameter("PlayerHealth", (float)g_gameManager.i_playerHealth);

            if (S_FMODStaticSceneIdentifier.GetStopAndPlayBool() == true)
            {
                S_FMODStaticSceneIdentifier.SetStopAndPlayParameter(false);
                globalTrackEmitter.Stop();
                globalTrackEmitter.Play();
                Debug.Log("We stopped and played");
            }
        }

        if (S_FMODStaticSceneIdentifier.GetTitleSceneParameterBool() == true && (S_FMODStaticSceneIdentifier.GetCombatSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetEncounterSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetBossSceneParameterBool() == false))
        {
            globalTrackEmitter.SetParameter("CurrentScene", 3);

            if (S_FMODStaticSceneIdentifier.GetStopAndPlayBool() == true)
            {
                S_FMODStaticSceneIdentifier.SetStopAndPlayParameter(false);
                globalTrackEmitter.Stop();
                globalTrackEmitter.Play();
                Debug.Log("We stopped and played");
            }
        }
    }

    /// <summary>
    /// Change music volume to pause menu values
    /// - Josh
    /// </summary>
    public void ChangeVolume()
    {
        globalTrackEmitter.SetParameter("Volume", S_FMODStaticSceneIdentifier.GetMusicVolumeFloat());
    }
}