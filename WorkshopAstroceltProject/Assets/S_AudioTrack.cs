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

    public int i_intensity = 0;

    private bool b_changed = false;

    public GameObject _sceneAudio;

    void Awake()
    {
        if (b_eventScene)
        {
            var emitter = _sceneAudio.GetComponent<FMODUnity.StudioEventEmitter>();
            emitter.SetParameter("TimeInScene", i_intensity);
        }
        else if (b_combatScene)
        {
            i_intensity = 2;
            var emitter = _sceneAudio.GetComponent<FMODUnity.StudioEventEmitter>();
            emitter.SetParameter("TimeInScene", i_intensity);
        }
        else { Debug.Log("No scene music selected"); }
    }

    void Update()
    {
        f_timeInScene += Time.deltaTime;

        if(f_timeInScene >= f_intensityBreakpoint && b_eventScene && (!b_changed))
        {
            i_intensity = 1;

            b_changed = true;
        }
    }
}
