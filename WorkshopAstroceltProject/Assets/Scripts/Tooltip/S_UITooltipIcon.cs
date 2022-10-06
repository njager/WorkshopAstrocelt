using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class S_UITooltipIcon : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    
    [Header("Tooltip Icon Attributes")]
    [SerializeField] Sprite tlp_a_artIconAsset;
    [SerializeField] SpriteRenderer tlp_sp_artIconRenderer; 
    [SerializeField] TextMeshProUGUI tlp_tx_flavorText;

    /////////////////////////////-------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Constructor \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////-------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private S_UITooltipIcon() 
    {

    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    
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
}
