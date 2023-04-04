using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioTestScript1 : MonoBehaviour // Emulating GameManager Behaviour
{
    public static AudioTestScript1 Instance;

    public List<int> gm_ls_p_playerDeck;

    public int i_playerHealth;

    public int i_healthMax;

    public int i_shield = 0;
    public int i_shieldMax = 100;

    public float f_playerEnergyGenerationRate = 1.0f;

    public int i_bones = 0;

    //Status Effects
    public bool b_bleeding = false;
    public bool b_resistant = false;
    public bool b_stunned = false;

    // Required elements
    public int musicVolume;
    public int sfxVolume;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("We deleted ourself cuz old copy");
            Destroy(this.gameObject);
            return;
        }
        Debug.Log("We initialized");

        //if the player restarts the game give them max health
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            i_playerHealth = i_healthMax;
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public int GetPlayerHealthValue() 
    {
        return i_playerHealth;
    }

    public void SwitchScenes() // Method 2
    {
        SceneManager.LoadScene("Assets/Scenes/MusicChangeBugFix2.unity");
    }
}
