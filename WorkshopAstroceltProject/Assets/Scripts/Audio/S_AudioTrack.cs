using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AudioTrack : MonoBehaviour
{
    private S_Global g_global;

    [Header("Scene Music")]
    [SerializeField] public bool b_eventScene;

    [SerializeField] public bool b_combatScene;

    [SerializeField] public bool b_bossScene;

    [Header("Time Interval")]
    [SerializeField] public float f_intensityBreakpoint;

    public float f_timeInScene = 0;

    public GameObject _sceneAudio;

    public int i_playerHealth;

    void Start()
    {
        g_global = S_Global.Instance;
    }

    void Update()
    {
        f_timeInScene += Time.deltaTime;

        i_playerHealth = g_global.g_playerAttributeSheet.GetPlayerHealthValue();

        if (b_eventScene)
        {
            var emitter = _sceneAudio.GetComponent<FMODUnity.StudioEventEmitter>();
            
            emitter.SetParameter("TimeInScene", f_timeInScene);
            
            emitter.SetParameter("CurrentScene", 0);
        }
        else if (b_combatScene)
        {
            var emitter = _sceneAudio.GetComponent<FMODUnity.StudioEventEmitter>();
            
            emitter.SetParameter("PlayerHealth", (float)i_playerHealth);
                        
            emitter.SetParameter("TimeInScene", f_timeInScene);

            emitter.SetParameter("CurrentScene", 1);
        }
        else if (b_bossScene)
        {
            var emitter = _sceneAudio.GetComponent<FMODUnity.StudioEventEmitter>();
            
            emitter.SetParameter("PlayerHealth", (float)i_playerHealth);
            
            emitter.SetParameter("TimeInScene", f_timeInScene);

            emitter.SetParameter("CurrentScene", 2);
        }
        else { Debug.Log("No scene music selected"); }
    }
}
