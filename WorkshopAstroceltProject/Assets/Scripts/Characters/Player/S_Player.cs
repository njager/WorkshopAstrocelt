using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Player : MonoBehaviour
{
    private S_Global g_global;

    public S_PlayerAttributes p_playerAttributes;

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
        if(p_playerAttributes.p_b_resistant == true)
        {
            int _newDamageValue = (int)_damageValue / 2;
            if (p_playerAttributes.p_i_shield <= 0)
            {
                p_playerAttributes.p_i_health -= _newDamageValue;
                p_playerAttributes.p_pe_blood.Play();

                //trigger a coroutine to change sprite and go back
                StartCoroutine(ChangeDamageSprite());

                //Debug.Log("Player Attacked!");
            }
            else
            {
                int _tempVal = _newDamageValue - p_playerAttributes.p_i_shield;
                //Debug.Log("Temp Val: " + _tempVal);
                if (_tempVal > 0)
                {
                    p_playerAttributes.p_i_shield -= _newDamageValue;
                    p_playerAttributes.p_i_health -= _tempVal;
                    p_playerAttributes.p_pe_blood.Play();
                    //Debug.Log("Player didn't have enough shields!");

                    //trigger a coroutine to change sprite and go back
                    StartCoroutine(ChangeDamageSprite());
                }
                else
                {
                    p_playerAttributes.p_i_shield -= _newDamageValue;
                    //Debug.Log("Player had shields!");
                }
            }
        }
        else
        {
            if (p_playerAttributes.p_i_shield <= 0)
            {
                p_playerAttributes.p_i_health -= _damageValue;
                p_playerAttributes.p_pe_blood.Play();
                //Debug.Log("Player Attacked!");

                //trigger a coroutine to change sprite and go back
                StartCoroutine(ChangeDamageSprite());
            }
            else
            {
                int _tempVal = _damageValue - p_playerAttributes.p_i_shield;
                //Debug.Log("Temp Val: " + _tempVal);
                if (_tempVal > 0)
                {
                    p_playerAttributes.p_i_shield -= _damageValue;
                    p_playerAttributes.p_i_health -= _tempVal;
                    p_playerAttributes.p_pe_blood.Play();
                    //Debug.Log("Player didn't have enough shields!");

                    //trigger a coroutine to change sprite and go back
                    StartCoroutine(ChangeDamageSprite());
                }
                else
                {
                    p_playerAttributes.p_i_shield -= _damageValue;
                    //Debug.Log("Player had shields!");
                }
            }
        }
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

        p_playerAttributes.p_i_shield += _shieldValue;

        g_global.g_UIManager.sc_characterGraphics.PlayerShieldingUIToggle();

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
        p_playerAttributes.p_i_health += _healedValue; 
    }




    public IEnumerator ChangeAttackSprite()
    {
        playerSprite.sprite = attackSprite;

        p_playerAttributes.p_a_AttackAnimator.Play("attack");


        Debug.Log("Player will wait for 2 seconds");

        yield return new WaitForSeconds(2);

        Debug.Log("Player will change to idle");

        playerSprite.sprite = idleSprite;
    }

    public IEnumerator ChangeBlockSprite()
    {
        playerSprite.sprite = blockSprite;

        yield return new WaitForSeconds(2);

        playerSprite.sprite = idleSprite;
    }

    public IEnumerator ChangeDamageSprite()
    {
        playerSprite.sprite = damagedSprite;

        p_playerAttributes.p_a_AttackAnimator.Play("Damaged");

        yield return new WaitForSeconds(2);

        playerSprite.sprite = idleSprite;
    }
}