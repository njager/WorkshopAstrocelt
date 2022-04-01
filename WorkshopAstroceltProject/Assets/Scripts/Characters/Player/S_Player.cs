using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Player : MonoBehaviour
{
    private S_Global g_global;

    public S_PlayerAttributes p_playerAttributes;
    [SerializeField] GameObject a_audioPlayer;

    /// <summary>
    /// Basic Start S_Global setup, grabbing playerAttributes; 
    /// </summary>
    void Awake()
    {
        g_global = S_Global.Instance;

        p_playerAttributes = g_global.g_playerAttributeSheet;

        a_audioPlayer = GameObject.Find("/Audio/Sound Effects/Shield/Vanilla");
    }


    /// <summary>
    /// Trigger function for when the player is attacked, first whittles shields, 
    /// and still hits health if there's any remainder
    /// else it hits health directly
    /// </summary>
    /// <param name="_damageValue"></param>
    public void PlayerAttacked(int _damageValue)
    {
        if(p_playerAttributes.p_b_resistant == true)
        {
            int _newDamageValue = (int)_damageValue / 2;
            if (p_playerAttributes.p_i_shield <= 0)
            {
                p_playerAttributes.p_i_health -= _newDamageValue;
                Debug.Log("Player Attacked!");
            }
            else
            {
                int _tempVal = _newDamageValue - p_playerAttributes.p_i_shield;
                Debug.Log("Temp Val: " + _tempVal);
                if (_tempVal > 0)
                {
                    p_playerAttributes.p_i_shield -= _newDamageValue;
                    p_playerAttributes.p_i_health -= _tempVal;
                    Debug.Log("Player didn't have enough shields!");
                }
                else
                {
                    p_playerAttributes.p_i_shield -= _newDamageValue;
                    Debug.Log("Player had shields!");
                }
            }
        }
        else
        {
            if (p_playerAttributes.p_i_shield <= 0)
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
}