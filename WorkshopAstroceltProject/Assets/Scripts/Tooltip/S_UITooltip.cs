using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class S_UITooltip : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private S_Global g_global; 

    [Header("Identifying String")]
    [SerializeField] string tlp_str_identifier; // Set to Canvas or Sprite

    [Header("Parent Canvas")]
    [SerializeField] Canvas cn_parentCanvas;

    [Header("Text Asset Fields")]
    [SerializeField] Canvas tlp_cn_textCanvas;
    [SerializeField] TextMeshProUGUI tlp_tx_headerText;
    [SerializeField] TextMeshProUGUI tlp_tx_bodyText;

    [Header("Art Icon Template")]
    [SerializeField] SpriteRenderer tlp_sp_spriteRendererElement;
    [SerializeField] List<S_CardTemplate> iconEntryList;

    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Constructors \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Constructor used to set the behavior of the tool tip based on if it exists in Canvas or Sprite based mode
    /// Base overload
    /// - Josh
    /// </summary>
    /// <param name="_identifier"></param>
    public S_UITooltip(string _identifier, string _headerText, string _bodyText) 
    {
        // Set Global
        g_global = S_Global.Instance;

        // Set Identifer
        SetIdentifyingTooltipString(_identifier);

        // Update the Text elements
        UpdateDebugTooltipUI(_headerText, _bodyText);
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Overload 1 with Updating of all text elements
    /// - Josh
    /// </summary>
    /// <param name="_headerText"></param>
    /// <param name="_bodyText"></param>
    public void UpdateDebugTooltipUI(string _headerText, string _bodyText) 
    {
        // Set Header Text
        SetTooltipHeaderText(_headerText);

        // Set Body Text
        SetTooltipBodyText(_bodyText);
    }

    /// <summary>
    /// Overload 2 to update just one element
    /// Set 2nd variable to true for the header text element, false for the body text element
    /// - Josh
    /// </summary>
    /// <param name="_text"></param>
    /// <param name="_whichBody"></param>
    public void UpdateDebugTooltipUI(string _text, bool _whichBody)
    {
        if(_whichBody == true) // If True set Header Text
        {
            SetTooltipHeaderText(_text);
        }
        else // If False set Body Text
        {
            SetTooltipBodyText(_text);
        }
    }

    public void AddIconEntry() 
    {

    }

    public void RemoveIconEntry() 
    {

    }

    /// <summary>
    /// Delete the tooltip when it's no longer applicable
    ///  - Josh
    /// </summary>
    public void DeleteToolTip() 
    {
        Destroy(this);
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the identifying string of S_DebugTooltip.tp_str_identifier
    /// - Josh
    /// </summary>
    /// <returns></returns>
    /// <param name="_identifier"></param>
    public void SetIdentifyingTooltipString(string _identifier)
    {
        tlp_str_identifier = _identifier;
    }

    /// <summary>
    /// Set the identifying string of S_DebugTooltip.tp_tx_headerText
    /// - Josh
    /// </summary>
    /// <returns></returns>
    /// <param name="_headerText"></param>
    public void SetTooltipHeaderText(string _headerText)
    {
        tlp_tx_headerText.text = _headerText;
    }

    /// <summary>
    /// Set the identifying string of S_DebugTooltip.tp_tx_bodyText
    /// - Josh
    /// </summary>
    /// <returns></returns>
    /// <param name="_bodyText"></param>
    public void SetTooltipBodyText(string _bodyText)
    {
        tlp_tx_headerText.text = _bodyText;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the identifying string of S_DebugTooltip.tlp_str_identifier
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_DebugTooltip.tlp_str_identifier
    /// </returns>
    public string GetIdentifyingTooltipString()
    {
        return tlp_str_identifier;
    }
}
