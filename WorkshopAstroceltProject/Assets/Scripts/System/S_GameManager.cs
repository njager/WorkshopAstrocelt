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

    public SpriteRenderer Skull1;
    public SpriteRenderer Skull1_Crack;
    public SpriteRenderer Skull1_Selector;

    public SpriteRenderer Skull2;
    public SpriteRenderer Skull2_Crack;
    public SpriteRenderer Skull2_Selector;

    public SpriteRenderer SkullBoss;
    //public SpriteRenderer SkullBoss_Crack;
    public SpriteRenderer SkullBoss_Selector;

    public SpriteRenderer encounterSprite;
    public SpriteRenderer encounterSprite_Selector;

    public Scene scene;

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

    public void Start()
    {
        scene = SceneManager.GetActiveScene();
        //Debug.Log("Active Scene is '" + scene.name + "'."); */
    }

    public void Update()
    {
       if (scene.name == "Scn_1stEnemyEncounter")
        {
            Skull1_Crack.enabled = false;

            Skull2.enabled = true;
            Skull2_Crack.enabled = false;
            Skull2_Selector.enabled = false;

            SkullBoss.enabled = true;
            SkullBoss_Selector.enabled = false;

            encounterSprite.enabled = true;
            encounterSprite_Selector.enabled = false;
        }

        if (scene.name == "Scn_2ndEnemyEncounter")
        {
            Skull1_Crack.enabled = true;
            Skull1.enabled = false;
            Skull1_Selector.enabled = false;

            Skull2.enabled = true;
            Skull2_Crack.enabled = false;
            Skull2_Selector.enabled = true;

            SkullBoss.enabled = true;
            SkullBoss_Selector.enabled = false;

            encounterSprite.enabled = false;
            encounterSprite.enabled = false;
        }

        if (scene.name == "Scn_4thEnemyEncounter")
        {
            Skull1_Crack.enabled = true;
            Skull1.enabled = false;
            Skull1_Selector.enabled = false;

            Skull2.enabled = false;
            Skull2_Crack.enabled = true;
            Skull2_Selector.enabled = false;

            SkullBoss.enabled = true;
            SkullBoss_Selector.enabled = true;

            encounterSprite.enabled = false;
            encounterSprite.enabled = false;
        }

        if (scene.name == "Scn_4thEnemyEncounter")
        {
            Skull1_Crack.enabled = true;
            Skull1.enabled = false;
            Skull1_Selector.enabled = false;

            Skull2.enabled = false;
            Skull2_Crack.enabled = true;
            Skull2_Selector.enabled = false;

            SkullBoss.enabled = true;
            SkullBoss_Selector.enabled = true;

            encounterSprite.enabled = false;
            encounterSprite.enabled = false;
        }

        if (scene.name == "Event1-Bog" || scene.name == "Event2-Mushrooms" || scene.name == "Event3-Victory")
        {
            Skull1_Crack.enabled = true;
            Skull1.enabled = false;
            Skull1_Selector.enabled = false;

            Skull2.enabled = false;
            Skull2_Crack.enabled = true;
            Skull2_Selector.enabled = false;

            SkullBoss.enabled = false;
            SkullBoss_Selector.enabled = false;

            encounterSprite.enabled = true;
            encounterSprite.enabled = true;
        }


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
