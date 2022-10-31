using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class S_Tooltip : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private S_Global g_global; 

    [Header("Identifying String")]
    [SerializeField] string tlp_str_identifier; // Set to Image or SpriteRenderer

    [Header("Text Asset Fields")]
    [SerializeField] TextMeshProUGUI tlp_tx_headerText;
    [SerializeField] TextMeshProUGUI tlp_tx_bodyText;

    [Header("Art Icon Template")]
    [SerializeField, HideInInspector] List<S_TooltipIcon> tlp_ls_a_artIconEntryList;
    [SerializeField] InspectorBasedDictionarySpriteString iconEntryDictionary;

    [Header("Backup List Method")]
    public List<Sprite> tlp_ls_a_spriteList;

    /////////////////////////////-------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Constructor \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////-------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Constructor used to set the behavior of the tool tip based on if it exists in Canvas or Sprite based mode
    /// Base overload
    /// - Josh
    /// </summary>
    /// <param name="_identifier"></param>
    /// <param name="_headerText"></param>
    /// <param name="_bodyText"></param>
    public void TooltipSetup(string _identifier, string _headerText, string _bodyText) 
    {
        // Set Global
        g_global = S_Global.Instance;

        // Set Identifer
        SetIdentifyingTooltipString(_identifier);

        // Set Canvas Dimensions
        UpdateCanvasBehavior();

        // Update the Text elements
        UpdateDebugTooltipUI(_headerText, _bodyText);
    }

    /// <summary>
    /// Constructor used to set the behavior of the tool tip based on if it exists in Canvas or Sprite based mode
    /// Icon overload
    /// - Josh
    /// </summary>
    /// <param name="_identifier"></param>
    /// <param name="_headerText"></param>
    /// <param name="_bodyText"></param>
    /// <param name="_iconIdentifier"></param>
    public void TooltipSetup(string _identifier, string _headerText, string _bodyText, string _iconIdentifier)
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
    /// Set the identifying string of S_UITooltip.tp_str_identifier
    /// - Josh
    /// </summary>
    /// <returns></returns>
    /// <param name="_identifier"></param>
    public void SetIdentifyingTooltipString(string _identifier)
    {
        tlp_str_identifier = _identifier;
    }

    /// <summary>
    /// Set the header text of S_UITooltip.tp_tx_headerText
    /// - Josh
    /// </summary>
    /// <returns></returns>
    /// <param name="_headerText"></param>
    public void SetTooltipHeaderText(string _headerText)
    {
        tlp_tx_headerText.text = _headerText;
    }

    /// <summary>
    /// Set the body text of S_UITooltip.tp_tx_bodyText
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
    /// Set the identifying string of S_UITooltip.tlp_str_identifier
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_DebugTooltip.tlp_str_identifier
    /// </returns>
    public string GetIdentifyingTooltipString()
    {
        return tlp_str_identifier;
    }

    /// <summary>
    /// Set the header text of S_UITooltip.tp_tx_headerText
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UITooltip.tp_tx_headerText
    /// </returns>
    public TextMeshProUGUI GetTooltipHeaderText()
    {
        return tlp_tx_headerText;
    }

    /// <summary>
    /// Set the header text of S_UITooltip.tp_tx_bodyText
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_UITooltip.tp_tx_bodyText
    /// </returns>
    public TextMeshProUGUI GetTooltipBodyText()
    {
        return tlp_tx_bodyText;
    }
}
