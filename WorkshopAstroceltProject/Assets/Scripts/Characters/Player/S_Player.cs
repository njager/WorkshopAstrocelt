using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Player : MonoBehaviour
{
    private S_Global g_global;

    private S_PlayerAttributes p_playerAttributes; 

    /// <summary>
    /// Basic Start S_Global setup, grabbing playerAttributes; 
    /// </summary>

    void Start()
    {
        g_global = S_Global.g_instance;

        //p_playerAttributes = g_global.g_p_playerAttributeSheet; 
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
            Debug.Log("Player Health Attacked!");
        }
        else
        {
            int _tempVal = p_playerAttributes.p_i_shield - _damageValue; 
            if (_tempVal < 0)
            {
                p_playerAttributes.p_i_shield -= _damageValue;
                if(p_playerAttributes.p_i_shield < 0)
                {
                    p_playerAttributes.p_i_shield = 0;
                }
                PlayerAttacked(Mathf.Abs(_tempVal)); 
                Debug.Log("Player didn't have enough shields!");
            }
            else
            {
                p_playerAttributes.p_i_shield -= _damageValue;
                Debug.Log("Player had shields!");
            }
        }
        
    }

    public void PlayerShielded(int _shieldValue)
    {
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

    public void PlayerStunned(bool _statusEffect, int _stunVal, int _turnCount)
    {
        if (_statusEffect == p_playerAttributes.p_b_stunned)
        {
            _statusEffect = p_playerAttributes.p_b_stunned;
            if (_statusEffect == false)
            {

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

    public void PlayerPoisoned(bool _statusEffect,int _poisonVal, int _turnCount)
    {
        if (_statusEffect == p_playerAttributes.p_b_stunned)
        {
            _statusEffect = p_playerAttributes.p_b_stunned;
            if (_statusEffect == false)
            {

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