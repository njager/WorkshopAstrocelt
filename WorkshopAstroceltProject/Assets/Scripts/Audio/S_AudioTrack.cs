using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AudioTrack : MonoBehaviour
{
    [Header("Scene Music")]
    [SerializeField] public bool b_eventScene;

    [SerializeField] public bool b_combatScene;

    [Header("Time Interval")]
    [SerializeField] public float f_intensityBreakpoint;

    public float f_timeInScene = 0;

    public GameObject _sceneAudio;

    void Awake()
    {
        if (b_eventScene)
        {
            var emitter = _sceneAudio.GetComponent<FMODUnity.StudioEventEmitter>();
            emitter.SetParameter("TimeInScene", f_timeInScene);
        }
        else if (b_combatScene)
        {
            var emitter = _sceneAudio.GetComponent<FMODUnity.StudioEventEmitter>();
            emitter.SetParameter("TimeInScene", f_timeInScene);
        }
        else { Debug.Log("No scene music selected"); }
    }

    void Update()
    {
        f_timeInScene += Time.deltaTime;
    }
}
