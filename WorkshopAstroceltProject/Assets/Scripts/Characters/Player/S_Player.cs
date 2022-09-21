using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Player : MonoBehaviour
{
    private S_Global g_global;

    public S_PlayerAttributes p_sc_playerAttributes;

    [Header("Player Sprites")]
    public SpriteRenderer playerSprite;

    public Sprite idleSprite;
    public Sprite attackSprite;
    public Sprite blockSprite;
    public Sprite damagedSprite;

    /// <summary>
    /// Basic Start S_Global setup, grabbing playerAttributes; 
    /// </summary>
    void Awake()
    {
        g_global = S_Global.Instance;
    }

    private void Start()
    {
        p_sc_playerAttributes = g_global.g_playerAttributeSheet;
    }


    /// <summary>
    /// Trigger function for when the player is attacked, first whittles shields, 
    /// and still hits health if there's any remainder
    /// else it hits health directly
    /// </summary>
    /// <param name="_damageValue"></param>
    public void PlayerAttacked(int _damageValue)
    {
        if(p_sc_playerAttributes.p_b_resistant == true)
        {
            int _newDamageValue = (int)_damageValue / 2;
            if (p_sc_playerAttributes.GetPlayerShieldValue() <= 0)
            {
                // Calculate and set health values
                int _newValue1 = p_sc_playerAttributes.GetPlayerHealthValue() - _newDamageValue;
                p_sc_playerAttributes.SetPlayerHealthValue(_newValue1);
                
                p_sc_playerAttributes.p_pe_blood.Play();

                //trigger a coroutine to change sprite and go back
                StartCoroutine(ChangeDamageSprite());

                //Debug.Log("Player Attacked!");
            }
            else
            {
                int _tempValue = _newDamageValue - p_sc_playerAttributes.GetPlayerShieldValue();
                //Debug.Log("Temp Val: " + _tempVal);
                if (_tempValue > 0)
                {
                    // Calculate and set shield values
                    int _newValue2 = p_sc_playerAttributes.GetPlayerShieldValue() - _newDamageValue;
                    p_sc_playerAttributes.SetPlayerShieldValue(_newValue2);

                    // Calculate and set health values
                    int _newValue3 = p_sc_playerAttributes.GetPlayerShieldValue() - _tempValue;
                    p_sc_playerAttributes.SetPlayerHealthValue(_newValue3);

                    p_sc_playerAttributes.p_pe_blood.Play();
                    //Debug.Log("Player didn't have enough shields!");

                    //trigger a coroutine to change sprite and go back
                    StartCoroutine(ChangeDamageSprite());
                }
                else
                {
                    int _newValue4 = p_sc_playerAttributes.GetPlayerShieldValue() - _newDamageValue;
                    p_sc_playerAttributes.SetPlayerShieldValue(_newValue4);
                    //Debug.Log("Player had shields!");
                }
            }
        }
        else
        {
            if (p_sc_playerAttributes.GetPlayerShieldValue() <= 0)
            {
                // Calculate and set health values
                int _newValue5 = p_sc_playerAttributes.GetPlayerHealthValue() - _damageValue;
                p_sc_playerAttributes.SetPlayerHealthValue(_newValue5);

                p_sc_playerAttributes.p_pe_blood.Play();
                //Debug.Log("Player Attacked!");

                //trigger a coroutine to change sprite and go back
                StartCoroutine(ChangeDamageSprite());
            }
            else
            {
                int _tempValue2 = _damageValue - p_sc_playerAttributes.GetPlayerShieldValue();
                //Debug.Log("Temp Val: " + _tempVal);
                if (_tempValue2 > 0)
                {
                    // Calculate and set shield values
                    int _newValue6 = p_sc_playerAttributes.GetPlayerShieldValue() - _damageValue;
                    p_sc_playerAttributes.SetPlayerShieldValue(_newValue6);

                    // Calculate and set health values
                    int _newValue7 = p_sc_playerAttributes.GetPlayerShieldValue() - _tempValue2;
                    p_sc_playerAttributes.SetPlayerHealthValue(_newValue7);

                    p_sc_playerAttributes.p_pe_blood.Play();
                    //Debug.Log("Player didn't have enough shields!");

                    //trigger a coroutine to change sprite and go back
                    StartCoroutine(ChangeDamageSprite());
                }
                else
                {
                    int _newValue8 = p_sc_playerAttributes.GetPlayerShieldValue() - _damageValue;
                    p_sc_playerAttributes.SetPlayerShieldValue(_newValue8);
                    //Debug.Log("Player had shields!");
                }
            }
        }

        // Update Player UI
        PlayerValuesLimitCheck();
    }

    /// <summary>
    /// Player shielding function for when they gain shields from cards
    /// False for physical, True for magic
    /// - Josh
    /// </summary>
    /// <param name="_shieldValue"></param>
    public void PlayerShielded(int _shieldValue, bool _soundEffectState)
    {
        //Debug.Log("DEBUG: Player Shields: " + _shieldValue);

        if (_soundEffectState == false) // False = physcial
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/shield-physical");
        }
        else if(_soundEffectState == true) // True = magic
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/CardSFX/shield-magic");
        }

        // Calculate and set shield values
        int _tempValue = p_sc_playerAttributes.GetPlayerShieldValue() + _shieldValue;
        p_sc_playerAttributes.SetPlayerShieldValue(_tempValue);

        // Update Player UI
        PlayerValuesLimitCheck();

        //trigger a coroutine to change back to og sprite
        StartCoroutine(ChangeBlockSprite());
    }

    /// <summary>
    /// Trigger function for when the player is healed
    /// May never be used, who knows
    /// - Josh
    /// </summary>
    /// <param name="_healedValue"></param>
    public void PlayerHealed(int _healedValue)
    {
        int _tempValue = p_sc_playerAttributes.GetPlayerHealthValue() + _healedValue;
        p_sc_playerAttributes.SetPlayerHealthValue(_tempValue);
    }

    /// <summary>
    /// Check the maximums and minimum values that can be represented and set them back to their limit
    /// Then once having set the values, trigger UI reset
    /// - Josh
    /// </summary>
    public void PlayerValuesLimitCheck()
    {
        // If player went above max shields, limit to max shields
        if (g_global.g_playerAttributeSheet.GetPlayerHealthValue() > g_global.g_playerAttributeSheet.GetPlayerMaxHealthValue())
        {
            // Set value
            g_global.g_playerAttributeSheet.SetPlayerHealthValue(g_global.g_playerAttributeSheet.GetPlayerMaxHealthValue());
        }

        // If player went above max shields, limit to max shields
        if (g_global.g_playerAttributeSheet.GetPlayerShieldValue() > g_global.g_playerAttributeSheet.GetPlayerMaxShieldValue())
        {
            // Set value
            g_global.g_playerAttributeSheet.SetPlayerShieldValue(g_global.g_playerAttributeSheet.GetPlayerMaxShieldValue());
        }

        // If shield value goes below 0, set back to 0
        if (g_global.g_playerAttributeSheet.GetPlayerShieldValue() < 0)
        {
            // Set value
            g_global.g_playerAttributeSheet.SetPlayerShieldValue(0);
        }

        // If health value goes below 0, set back to 0
        if (g_global.g_playerAttributeSheet.GetPlayerHealthValue() < 0)
        {
            // Set value
            g_global.g_playerAttributeSheet.SetPlayerHealthValue(0);
        }

        // Make this my blank check for UI
        UpdatePlayerHealthUI();
    }

    /// <summary>
    /// Method to update the health UI of the enemy
    /// </summary>
    private void UpdatePlayerHealthUI()
    {
        if (p_sc_playerAttributes.GetPlayerShieldValue() > 0)
        {
            SetPlayerShieldText(p_sc_playerAttributes.GetPlayerShieldValue());
        }
        else
        {
            SetPlayerHealthText(p_sc_playerAttributes.GetPlayerHealthValue());
        }
    }

    private void SetPlayerHealthText(int _healthValue)
    {
        g_global.g_UIManager.sc_characterGraphics.UpdatePlayerHealthUI(_healthValue);
        g_global.g_UIManager.sc_characterGraphics.PlayerShieldingUIToggle();
    }


    private void SetPlayerShieldText(int _shieldValue)
    {
        g_global.g_UIManager.sc_characterGraphics.UpdatePlayerShieldBar(_shieldValue);
        g_global.g_UIManager.sc_characterGraphics.PlayerShieldingUIToggle();
    }

    /////////////////////////////-------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Animation Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////-------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Change player sprite to attack sprite
    ///  - "Riley"
    /// </summary>
    /// <returns></returns>
    public IEnumerator ChangeAttackSprite()
    {
        playerSprite.sprite = attackSprite;

        Debug.Log("Player will animate");

        p_sc_playerAttributes.p_a_AttackAnimator.Play("attack");

        Debug.Log("Player will wait for 2 seconds");

        yield return new WaitForSeconds(2);

        Debug.Log("Player will change to idle");

        playerSprite.sprite = idleSprite;
    }

    /// <summary>
    /// Change player sprite to block sprite
    ///  - "Riley"
    /// </summary>
    /// <returns></returns>
    public IEnumerator ChangeBlockSprite()
    {
        playerSprite.sprite = blockSprite;

        yield return new WaitForSeconds(2);

        playerSprite.sprite = idleSprite;
    }

    /// <summary>
    /// Change player sprite to damaged sprite
    ///  - "Riley"
    /// </summary>
    /// <returns></returns>
    public IEnumerator ChangeDamageSprite()
    {
        playerSprite.sprite = damagedSprite;

        p_sc_playerAttributes.p_a_AttackAnimator.Play("Damaged");

        yield return new WaitForSeconds(2);

        playerSprite.sprite = idleSprite;
    }
}