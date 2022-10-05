using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        //Status Effects
    public bool b_bleeding = false;
    public bool b_resistant = false;
    public bool b_stunned = false;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
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
    /// Get the health from the player
    /// </summary>
    /// <returns></returns>
    public int GetHealth()
    {
        return i_playerHealth;
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
}
