using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameManager : MonoBehaviour
{
    public static S_GameManager Instance;

    public List<int> gm_ls_p_playerDeck;

    public int i_playerHealth;

    public int i_healthMax;

    public int i_shield = 0;
    public int i_shieldMax = 100;

    public float f_playerEnergyGenerationRate = 1.0f;

    public int i_bones = 0;

    [Header("Volume variables saved between scenes")]
    public float f_masterVolume;

    public float f_sfxVolume;

    [Header("Status Effects")]
    public bool b_bleeding = false;
    public bool b_resistant = false;
    public bool b_stunned = false;

    [Header("Boss Health Value")]
    public int e_i_bossHealth;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("We deleted ourself cuz old copy");
            Destroy(this.gameObject);
            return;
        }
        Debug.Log("We initialized");

        //if the player restarts the game give them max health
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            i_playerHealth = i_healthMax;
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);


        S_FMODStaticSceneIdentifier.SetMusicVolumeFloat(f_masterVolume);
    }

    //Getters and Setters//

    /// <summary>
    /// Get the number of bones
    /// </summary>
    /// <returns></returns>
    public int GetBones()
    {
        return i_bones;
    }

    /// <summary>
    /// Set the # of bones = to the param
    /// </summary>
    /// <param name="_bones"></param>
    public void SetBones(int _bones)
    {
        i_bones = _bones;
    }

    /// <summary>
    /// Add a card to the deck based on the id
    /// </summary>
    /// <param name="_id"></param>
    public void AddCards(int _id)
    {
        gm_ls_p_playerDeck.Add(_id);
    }

    /// <summary>
    /// Get the health for the player
    /// </summary>
    /// <returns></returns>
    public int GetHealth()
    {
        return i_playerHealth;
    }

    /// <summary>
    /// Get the health from the boss
    /// </summary>
    /// <returns></returns>
    public int GetBossHealth()
    {
        return e_i_bossHealth;
    }

    /// <summary>
    /// Set health = to the pased param. limits if greater than max health
    /// </summary>
    /// <param name="_heal"></param>
    public void SetHealth(int _heal)
    {
        i_playerHealth = _heal;

        if(i_playerHealth > i_healthMax)
        {
            i_playerHealth = i_healthMax;
        }
    }

    public void SetPlayerHealthState(int _value)
    {
        i_playerHealth = _value;
    }

    public void SetBossHealthState(int _value)
    {
        e_i_bossHealth = _value;
    }
}
