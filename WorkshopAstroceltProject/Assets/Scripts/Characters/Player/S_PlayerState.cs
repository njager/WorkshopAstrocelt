using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class S_PlayerState : MonoBehaviour
{
    private S_Global g_global;

    //Multiple Status Effects could be active at once
    [Header("Status Effect Turn Counts")]
    public int p_i_bleedingTurnCount;
    public int p_i_stunnedTurnCount;
    public int p_i_resistantTurnCount;

    [Header("Status Effect Values")]
    public float bleedingDamageRate;
    public int stunnedDamageValue;

    [Header("Status Effect States")]
    public bool p_b_inBleedingState;
    public bool p_b_inStunnedState;
    public bool p_b_inResistantState;

    [Header("Audio Prefab")]
    public GameObject playerWinMusic;
    public GameObject playerLoseMusic;

    void Awake()
    {
        g_global = S_Global.Instance;
    }

    void Update()
    {
        // Check for health and shield limits here
        if(g_global.g_playerAttributeSheet.p_i_health > g_global.g_playerAttributeSheet.p_i_healthMax)
        {
            g_global.g_playerAttributeSheet.p_i_health = g_global.g_playerAttributeSheet.p_i_healthMax;
        }

        if (g_global.g_playerAttributeSheet.p_i_shield > g_global.g_playerAttributeSheet.p_i_shieldMax)
        {
            g_global.g_playerAttributeSheet.p_i_shield = g_global.g_playerAttributeSheet.p_i_shieldMax;
        }

        if (g_global.g_playerAttributeSheet.p_i_shield <= 0)
        {
            g_global.g_playerAttributeSheet.p_i_shield = 0;
        }

        // If player lost
        if (g_global.g_playerAttributeSheet.p_i_health <= 0)
        {
            PlayerLoses();
        }

        //If player won
        if (g_global.g_i_enemyCount <= 0)
        {
            PlayerWins();
        }
    }

    public void PlayerStatusEffects()
    {
        PlayerResistantEffect(); 

    }

    private void PlayerBleedingStatusEffect(float _damageRate)
    {
        int _bleedingDamageForTurn = BleedingEffectCalculator(_damageRate);
        if (p_i_bleedingTurnCount <= 1)
        {
            g_global.g_player.PlayerAttacked(_bleedingDamageForTurn);
        }
        else
        {
            Debug.Log("Effect not active!");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_stunnedDamageValue"></param>
    private void PlayerStunnedStatusEffect(int _stunnedDamageValue)
    {
        if (p_i_stunnedTurnCount <= 1)
        {
            g_global.g_player.PlayerAttacked(_stunnedDamageValue);
        }
        else
        {
            Debug.Log("Effect not active!");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void PlayerResistantEffect()
    {
        if (p_i_resistantTurnCount <=1)
        {
            //g_global.g_player
        }
        else
        {

        }
    }

    /// <summary>
    /// Helper function of a helper function
    /// </summary>
    /// <param name="_damageRate"></param>
    /// <returns></returns>
    private int BleedingEffectCalculator(float _damageRate)
    {
        int _bleedingCalc = Mathf.RoundToInt(g_global.g_playerAttributeSheet.p_i_health * _damageRate); 
        return _bleedingCalc;
    }

    /// <summary>
    /// Player Loses Scene
    /// - Josh
    /// </summary>
    public void PlayerLoses()
    {
        //Player lost so trigger lose text and reset canvas
        g_global.g_UIManager.greyboxCanvas.SetActive(false);
        g_global.g_UIManager.resetCanvas.SetActive(true);
        g_global.g_UIManager.loseText.SetActive(true);

        //Play lose sound
        PlaySoundLose();
        //playerLoseMusic.SetActive(false);

        // Pause The game
        //Time.timeScale = 0f;
    }

    /// <summary>
    /// Player Wins Scene
    /// - Josh
    /// </summary>
    public void PlayerWins()
    {
        //Player won so trigger win text and reset canvas
        g_global.g_UIManager.greyboxCanvas.SetActive(false);
        g_global.g_UIManager.resetCanvas.SetActive(true);
        g_global.g_UIManager.winText.SetActive(true);

        //Play win sound
        PlaySoundWin();
        //playerWinMusic.SetActive(false);

        // Pause The game
        //Time.timeScale = 0f;
    }

    private void PlaySoundWin()
    {
        playerWinMusic.SetActive(true);
    }

    private void PlaySoundLose()
    {
        playerLoseMusic.SetActive(true);
    }

}
