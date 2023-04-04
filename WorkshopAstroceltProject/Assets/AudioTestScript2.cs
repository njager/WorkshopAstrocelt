using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; // If you use the library instead you don't have to make calls to the static library instance

public class AudioTestScript2 : MonoBehaviour // Emulating S_AudioTrack
{
    private AudioTestScript1 g_global;

    [Header("Scene Music")]
    [SerializeField] public bool b_eventScene;

    [SerializeField] public bool b_combatScene;

    [SerializeField] public bool b_bossScene;

    [Header("Time Interval")]
    [SerializeField] public float f_intensityBreakpoint;

    private float vol = 100;

    public float f_timeInScene = 0;

    public int i_playerHealth;

    [Header("Audio Object")]
    public GameObject _sceneAudio;
    [SerializeField] StudioEventEmitter emitter1;
    [SerializeField] StudioEventEmitter emitter2;

    void Start()
    {
        g_global = AudioTestScript1.Instance;

        PlayMusic();
    }

    public void PlayMusic() 
    {
        // Fix Code method 1
        if (b_combatScene == true)
        {
            emitter1.Play();
            emitter2.Stop();
        }
        else if (b_eventScene == true)
        {
            emitter2.Play();
            emitter1.Stop();
        }
    }

    void Update()
    {
        ChangeVolume();

        f_timeInScene += Time.deltaTime;

        i_playerHealth = g_global.GetPlayerHealthValue();

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

    public void ChangeVolume()
    {
        //vol = g_global.g_pauseMenu.musicVolume;
        var emitter = _sceneAudio.GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("Volume", g_global.musicVolume);
        //emitter.SetParameter("SFX_Volume", g_global.g_pauseMenu.sfxVolume);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("SFX_Volume", g_global.sfxVolume);
        //Debug.Log(g_global.g_pauseMenu.sfxVolume);

        /*musicEvent = target.GetComponent<FMODUnity.StudioEventEmitter>();
        FMOD.Studio.ParameterInstance myParameter;
        myParameter = musicEvent.GetParameter(“War”);

        myParameter.getValue(out float);
        myParameter.setValue(float);*/

    }

    // Setters \\ 

    public void SetEventSceneBool(bool _truthValue)
    {
        b_eventScene = _truthValue;
    }

    public void SetCombatSceneBool(bool _truthValue) 
    {
        b_combatScene = _truthValue;
    }
}
