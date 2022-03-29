using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Player : MonoBehaviour
{
    private S_Global g_global;

    [SerializeField] S_PlayerAttributes p_playerAttributes;
    [SerializeField] GameObject a_audioPlayer;

    /// <summary>
    /// Basic Start S_Global setup, grabbing playerAttributes; 
    /// </summary>
    void Awake()
    {
        g_global = S_Global.Instance;

        p_playerAttributes = g_global.g_playerAttributeSheet; 
    }


    /// <summary>
    /// Trigger function for when the player is attacked, first whittles shields, 
    /// and still hits health if there's any remainder
    /// else it hits health directly
    /// </summary>
    /// <param name="_damageValue"></param>
    public void PlayerAttacked(int _damageValue)
    {
        if(p_playerAttributes.p_i_shield <= 0)
        {
            p_playerAttributes.p_i_health -= _damageValue;
            Debug.Log("Player Attacked!");
        }
        else
        {
            int _tempVal = _damageValue - p_playerAttributes.p_i_shield;
            Debug.Log("Temp Val: " + _tempVal);
            if (_tempVal > 0)
            {
                p_playerAttributes.p_i_shield -= _damageValue;
                p_playerAttributes.p_i_health -= _tempVal; 
                Debug.Log("Player didn't have enough shields!");
            }
            else
            {
                p_playerAttributes.p_i_shield -= _damageValue;
                Debug.Log("Player had shields!");
            }
        }
        
    }

    /// <summary>
    /// Player shielding function for when they gain shields from play
    /// </summary>
    /// <param name="_shieldValue"></param>
    public void PlayerShielded(int _shieldValue)
    {
        //play sound effect
        a_audioPlayer.SetActive(true);

        p_playerAttributes.p_i_shield += _shieldValue; 
    }

    /// <summary>
    /// Trigger function for when the player is healed
    /// </summary>
    /// <param name="_healedValue"></param>
    public void PlayerHealed(int _healedValue)
    {
        p_playerAttributes.p_i_health += _healedValue; 
    }


    /// <summary>
    /// Status Effect Trigger function for when the player is bleeding
    /// </summary>
    /// <param name="_statusEffect"></param>
    /// <param name="bleedingRate"></param>
    /// <param name="_turnCount"></param>
    public void PlayerBleeding(bool _statusEffect, float bleedingRate, int _turnCount)
    {
        if(_statusEffect == p_playerAttributes.p_b_bleeding)
        {
            _statusEffect = p_playerAttributes.p_b_bleeding;
            if (_statusEffect == false)
            {
                // These effects need to be fleshed out first
            }
            else
            {
                Debug.Log("Status Already Active!");
                return;
            }
        }
        else
        {
            Debug.Log("Wrong Status Effect!");
            return; 
        }
    }

    /// <summary>
    /// Status Effect Trigger function for when the player is stunned
    /// </summary>
    /// <param name="_statusEffect"></param>
    /// <param name="_stunVal"></param>
    /// <param name="_turnCount"></param>
    public void PlayerStunned(bool _statusEffect, int _stunVal, int _turnCount)
    {
        if (_statusEffect == p_playerAttributes.p_b_stunned)
        {
            _statusEffect = p_playerAttributes.p_b_stunned;
            if (_statusEffect == false)
            {
                // These effects need to be fleshed out first
            }
            else
            {
                Debug.Log("Status Already Active!");
                return;
            }
        }
        else
        {
            Debug.Log("Wrong Status Effect!");
            return;
        }
    }

    /// <summary>
    /// Status Effect Trigger function for when the player is poisoned
    /// </summary>
    /// <param name="_statusEffect"></param>
    /// <param name="_poisonVal"></param>
    /// <param name="_turnCount"></param>
    public void PlayerPoisoned(bool _statusEffect,int _poisonVal, int _turnCount)
    {
        if (_statusEffect == p_playerAttributes.p_b_stunned)
        {
            _statusEffect = p_playerAttributes.p_b_stunned;
            if (_statusEffect == false)
            {
                // These effects need to be fleshed out first
            }
            else
            {
                Debug.Log("Status Already Active!");
                return; 
            }
        }
        else
        {
            Debug.Log("Wrong Status Effect!");
            return; 
        }
    }
}