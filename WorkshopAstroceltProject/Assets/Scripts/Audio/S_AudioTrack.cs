using FMODUnity;
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

    [SerializeField] public bool b_mainMenuScene;

    [Header("Time Interval")]
    [SerializeField] public float f_intensityBreakpoint;

    private float vol = 100;

    public int i_currentScene = 0;

    public StudioEventEmitter emitter;



    public float f_timeInScene = 0;

    public GameObject _sceneAudio;

    public int i_playerHealth;

    void Start()
    {
        g_global = S_Global.Instance;
    }

    void Update()
    {

        //Debug.Log(g_global.g_pauseMenu.musicVolume);
        //changeVolume();

        f_timeInScene += Time.deltaTime;

        //i_playerHealth = g_global.g_playerAttributeSheet.GetPlayerHealthValue();

        if (b_eventScene)
        {    
            emitter.SetParameter("TimeInScene", f_timeInScene);

            i_currentScene= 0;
            
            emitter.SetParameter("CurrentScene", i_currentScene);
        }
        else if (b_combatScene)
        {            
            emitter.SetParameter("PlayerHealth", (float)i_playerHealth);

            emitter.SetParameter("TimeInScene", f_timeInScene);

            i_currentScene = 1;

            emitter.SetParameter("CurrentScene", i_currentScene);
        }
        else if (b_bossScene)
        {            
            emitter.SetParameter("PlayerHealth", (float)i_playerHealth);
            
            emitter.SetParameter("TimeInScene", f_timeInScene);

            i_currentScene = 2;

            emitter.SetParameter("CurrentScene", i_currentScene);
        }
        else if (b_mainMenuScene)
        {
            i_currentScene = 3;

            emitter.SetParameter("CurrentScene", i_currentScene);
        }
        else { Debug.Log("No scene music selected"); }
    }

    void changeVolume()
    {
        //vol = g_global.g_pauseMenu.musicVolume;
        var emitter = _sceneAudio.GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("Volume", g_global.g_pauseMenu.musicVolume);

        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SFX_Volume", g_global.g_pauseMenu.sfxVolume);
    }
}
