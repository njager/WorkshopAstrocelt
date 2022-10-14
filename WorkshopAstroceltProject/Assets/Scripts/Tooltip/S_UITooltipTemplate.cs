using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tooltip", menuName = "Tooltip")]
public class S_UITooltipTemplate : ScriptableObject
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    
    [Header("Header Text:")]
    [SerializeField] string HeaderText;

    [Header("Body Text:")]
    [SerializeField] string BodyText;

    [Header("Image (false) or SpriteRenderer Object (true):")]
    [SerializeField] bool CanvasState;

    [Header("Icon Entries")]
    [SerializeField] List<(Sprite, string)> tlp_ls_tx_a_iconEntriesList = new List<(Sprite, string)>();

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the text string of S_UIToolTemplate.HeaderText
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIToolTemplate.HeaderText
    /// </returns>
    public string GetTooltipHeaderBodyText()
    {
        return BodyText;
    }

    /// <summary>
    /// Return the text string of S_UIToolTemplate.BodyText
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIToolTemplate.BodyText
    /// </returns>
    public string GetTooltipTemplateBodyText()
    {
        return BodyText;
    }

    /// <summary>
    /// Return the canvas state of S_UIToolTemplate.CanvasState
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UIToolTemplate.CanvasState
    /// </returns
    public bool GetTooltipTemplateCanvasState()
    {
        return CanvasState;
    }
}
