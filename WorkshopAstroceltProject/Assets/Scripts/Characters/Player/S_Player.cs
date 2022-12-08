using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class S_Player : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    
    private S_Global g_global;

    public S_PlayerAttributes p_sc_playerAttributes;

    [Header("Player Sprites")]
    public SpriteRenderer playerSprite;

    public Sprite idleSprite;
    public Sprite attackSprite;
    public Sprite blockSprite;
    public Sprite damagedSprite;

    //public bool p_sc_playerTurn;

    public bool isComplete;

    [Tooltip("Material to switch to during the flash.")]
    [SerializeField] private Material flashMaterial;

    [Tooltip("Duration of the flash.")]
    [SerializeField] private float duration;


    // The material that was in use, when the script started.
    private Material originalMaterial;

    // The currently running coroutine.
    private Coroutine flashRoutine;


    void Start()
    {
        // Get the SpriteRenderer to be used,
        // alternatively you could set it from the inspector.
        playerSprite = GetComponent<SpriteRenderer>();

        // Get the material that the SpriteRenderer uses, 
        // so we can switch back to it after the flash ended.
        originalMaterial = playerSprite.material;

        // Copy the flashMaterial material, this is needed, 
        // so it can be modified without any side effects.
        flashMaterial = new Material(flashMaterial);
    }

    /// <summary>
    /// Basic Start S_Global setup, grabbing playerAttributes; 
    /// </summary>

    /*  public void Update()
      {
          if (g_global.g_b_playerTurn == true && isComplete == false)
          {
              playerSprite.transform.DOShakePosition(1000f, new Vector3(0, 0.00001f, 1), 1, 0, false, false);
              isComplete = true;
          }
      }*/

    void Awake()
    {
        g_global = S_Global.Instance;
        p_sc_playerAttributes = this.GetComponent<S_PlayerAttributes>();
    }

    /////////////////////////////----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Player Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////----------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

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
                Flash(Color.blue);
                // Calculate and set health values
                int _newValue1 = p_sc_playerAttributes.GetPlayerHealthValue() - _newDamageValue;
                p_sc_playerAttributes.SetPlayerHealthValue(_newValue1);
                
                //trigger particle effects
                p_sc_playerAttributes.p_pe_blood.Play();

                //trigger a coroutine to change sprite and go back
                //StartCoroutine(ChangeDamageSprite());

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

                    //trigger particle effects
                    p_sc_playerAttributes.p_pe_blood.Play();
                    //Debug.Log("Player didn't have enough shields!");

                    //trigger a coroutine to change sprite and go back
                    //StartCoroutine(ChangeDamageSprite());
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

                //trigger particle effects
                p_sc_playerAttributes.p_pe_blood.Play();
                //Debug.Log("Player Attacked!");

                Flash(Color.white);

                //trigger a coroutine to change sprite and go back
                //StartCoroutine(ChangeDamageSprite());
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

                    //trigger particle effects
                    p_sc_playerAttributes.p_pe_blood.Play();
                    //Debug.Log("Player didn't have enough shields!");

                    //trigger a coroutine to change sprite and go back
                    //StartCoroutine(ChangeDamageSprite());
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
    /// Trigger function for when the player is attacked, sprite will flash white when takes damage
    /// Sprite flashes blue when takes damage with sheild
    public void Flash(Color color)
    {
        // If the flashRoutine is not null, then it is currently running.
        if (flashRoutine != null)
        {
            // In this case, we should stop it first.
            // Multiple FlashRoutines the same time would cause bugs.
            StopCoroutine(flashRoutine);
        }

        // Start the Coroutine, and store the reference for it.
        flashRoutine = StartCoroutine(FlashRoutine(color));
    }

    private IEnumerator FlashRoutine(Color color)
    {
        // Swap to the flashMaterial.
        playerSprite.material = flashMaterial;

        // Set the desired color for the flash.
        flashMaterial.color = color;

        // Pause the execution of this function for "duration" seconds.
        yield return new WaitForSeconds(duration);

        // After the pause, swap back to the original material.
        playerSprite.material = originalMaterial;

        // Set the flashRoutine to null, signaling that it's finished.
        flashRoutine = null;
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

        //trigger the shield particle effect
        p_sc_playerAttributes.p_pe_shield.Play();

        // Calculate and set shield values
        int _tempValue = p_sc_playerAttributes.GetPlayerShieldValue() + _shieldValue;
        p_sc_playerAttributes.SetPlayerShieldValue(_tempValue);

        // Update Player UI
        PlayerValuesLimitCheck();

        //trigger a coroutine to change back to og sprite
        //StartCoroutine(ChangeBlockSprite());
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
    /// Method to update the all health and shield elements of the UI
    /// - Josh
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

        // Set the new audio percentage value
        PlayerHealthAudioPercentage();
    }

    /// <summary>
    /// Trigger function to set the health elements in S_CharacterGraphics
    /// - Josh
    /// </summary>
    /// <param name="_healthValue"></param>
    private void SetPlayerHealthText(int _healthValue)
    {
        g_global.g_UIManager.sc_characterGraphics.UpdatePlayerHealthUI(_healthValue);
        g_global.g_UIManager.sc_characterGraphics.PlayerShieldingUIToggle();
    }

    /// <summary>
    /// Trigger function to set the shield elements in S_CharacterGraphics
    /// - Josh
    /// </summary>
    /// <param name="_healthValue"></param>
    private void SetPlayerShieldText(int _shieldValue)
    {
        g_global.g_UIManager.sc_characterGraphics.UpdatePlayerShieldUI(_shieldValue);
        g_global.g_UIManager.sc_characterGraphics.PlayerShieldingUIToggle();
    }

    /// On being attacked, set the audio percentage so the FMOD will conform to the new value
    /// - Josh
    /// </summary>
    private void PlayerHealthAudioPercentage()
    {
        // Set the random values
        float _randomInt1 = g_global.g_audioManager.GetRandomFloatNumber();
        float _randomInt2 = g_global.g_audioManager.GetRandomFloatNumber();

        // Add them to enemy health
        float _playerHealth = p_sc_playerAttributes.GetPlayerHealthValue() + _randomInt1;
        float _playerMaxHealth = p_sc_playerAttributes.GetPlayerMaxHealthValue() + _randomInt2;

        // Calculate and Set the Percentage
        float _temp = _playerHealth / _playerMaxHealth;

        g_global.g_audioManager.SetPlayerAudioPercentage(_temp * 100);
    }

    /////////////////////////////-------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Animation Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////-------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

}