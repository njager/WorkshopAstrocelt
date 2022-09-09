using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_GameManager : MonoBehaviour
{
    public static S_GameManager Instance;

    public List<int> gm_ls_p_playerDeck;

    public int i_playerHealth = 35;

    public int i_healthMax = 35;

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

    public int GetBones()
    {
        return i_bones;
    }

    public void SetBones(int _bones)
    {
        i_bones = _bones;
    }

    public void AddCards(int _id)
    {
        gm_ls_p_playerDeck.Add(_id);
    }

    public int GetHealth()
    {
        return i_playerHealth;
    }

    public void SetHealth(int _heal)
    {
        i_playerHealth = _heal;
    }
}
