using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class S_TooltipIcon : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    
    [Header("Tooltip Icon Attributes")]
    [SerializeField] SpriteRenderer tlp_sp_artIconRenderer; 
    [SerializeField] TextMeshProUGUI tlp_tx_flavorText;

    /////////////////////////////-------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Constructor \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////-------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Constructor used to setup the created icon entry
    /// Base overload
    /// - Josh
    /// </summary>
    /// <param name="_iconArt"></param>
    /// <param name="_flavorText"></param>
    public S_TooltipIcon(Sprite _iconArt, string _flavorText) 
    {
        // Set Icon Art
        SetIconArtAsset(_iconArt);

        // Set bodyText
        SetIconFlavorText(_flavorText);
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    
    /// <summary>
    /// Update the icon values based on if anything else changes
    /// - Josh
    /// </summary>
    public void UpdateIconUI() 
    {

    }
    
    /// <summary>
    /// Method to Delete the Icon
    /// - Josh
    /// </summary>
    public void DeleteIconEntry() 
    {
        Destroy(this);
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the flavor text of S_UITooltipIcon.tlp_tx_flavorText
    /// - Josh
    /// </summary>
    /// <returns></returns>
    /// <param name="_flavorText"></param>
    public void SetIconFlavorText(string _flavorText)
    {
        tlp_tx_flavorText.text = _flavorText;
    }

    /// <summary>
    /// Set the sprite asset of S_UITooltipIcon.tlp_sp_artIconRenderer.sprite
    /// - Josh
    /// </summary>
    /// <returns></returns>
    /// <param name="_spriteAsset"></param>
    public void SetIconArtAsset(Sprite _spriteAsset)
    {
        tlp_sp_artIconRenderer.sprite = _spriteAsset;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Get the text object of S_UITooltipIcon.tlp_tx_flavorText
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UITooltipIcon.tlp_tx_flavorText
    /// </returns>
    public TextMeshProUGUI GetIconFlavorText()
    {
        return tlp_tx_flavorText;
    }

    /// <summary>
    /// Get the sprite asset of S_UITooltipIcon.tlp_sp_artIconRenderer.sprite
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UITooltipIcon.tlp_sp_artIconRenderer.sprite
    /// </returns>
    public Sprite GetIconArtAsset()
    {
        return tlp_sp_artIconRenderer.sprite;
    }
}
