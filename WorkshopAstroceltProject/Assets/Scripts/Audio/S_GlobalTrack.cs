using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class S_GlobalTrack : MonoBehaviour
{
    [Header("Global Audio Track Object")]
    public StudioEventEmitter globalTrackEmitter;

    private void Start()
    {
        globalTrackEmitter.Play();

        S_FMODStaticSceneIdentifier.TriggerTitleSceneBool();
    }

    private void Update()
    {
        // Update FMOD track in here
        if (S_FMODStaticSceneIdentifier.GetCombatSceneParameterBool() == true && (S_FMODStaticSceneIdentifier.GetTitleSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetEncounterSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetBossSceneParameterBool() == false))
        {
            globalTrackEmitter.SetParameter("CurrentScene", 1);

            if (S_FMODStaticSceneIdentifier.GetStopAndPlayBool() == true)
            {
                S_FMODStaticSceneIdentifier.SetStopAndPlayParameter(false);
                globalTrackEmitter.Stop();
                globalTrackEmitter.Play();
            }
        }

        if (S_FMODStaticSceneIdentifier.GetEncounterSceneParameterBool() == true && (S_FMODStaticSceneIdentifier.GetTitleSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetCombatSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetBossSceneParameterBool() == false))
        {
            globalTrackEmitter.SetParameter("CurrentScene", 0);

            if (S_FMODStaticSceneIdentifier.GetStopAndPlayBool() == true)
            {
                S_FMODStaticSceneIdentifier.SetStopAndPlayParameter(false);
                globalTrackEmitter.Stop();
                globalTrackEmitter.Play();
            }
        }

        if (S_FMODStaticSceneIdentifier.GetBossSceneParameterBool() == true && (S_FMODStaticSceneIdentifier.GetTitleSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetEncounterSceneParameterBool() == false && S_FMODStaticSceneIdentifier.GetCombatSceneParameterBool() == false))
        {
            globalTrackEmitter.SetParameter("CurrentScene", 2);

            if (S_FMODStaticSceneIdentifier.GetStopAndPlayBool() == true)
            {
                S_FMODStaticSceneIdentifier.SetStopAndPlayParameter(false);
                globalTrackEmitter.Stop();
                globalTrackEmitter.Play();
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
            }
        }
    }
}
