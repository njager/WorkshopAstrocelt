using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using DG.Tweening;

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
    [SerializeField] List<S_TooltipIcon> tlp_ls_a_artIconEntryList;
    //[SerializeField] InspectorBasedDictionarySpriteString iconEntryDictionary;

    [Header("Layout Element")]
    [SerializeField] LayoutElement tlp_layoutElement;

    [Header("Character Wrap Limit")]
    [SerializeField] int tlp_characterWrapLimit;

    [Header("Rect Transform")]
    [SerializeField] RectTransform tlp_rectTransform;

    [Header("Tween Delay")]
    [SerializeField] Tween tlp_an_delay; 

    [Header("Backup List Method")]
    public List<Sprite> tlp_ls_a_spriteList;

    /////////////////////////////-------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Constructor \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////-------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private void Awake()
    {
        tlp_an_delay.SetAutoKill(false);
    }

    /// <summary>
    /// Constructor used to set the behavior of the tool tip based on if it exists in Canvas or Sprite based mode
    /// Base overload
    /// - Josh
    /// </summary>
    /// <param name="_headerText"></param>
    /// <param name="_bodyText"></param>
    public void TooltipSetup(string _headerText, string _bodyText) 
    {
        // Set Global
        g_global = S_Global.Instance;

        // Update the Text elements
        UpdateDebugTooltipUI(_headerText, _bodyText);
    }

    /// <summary>
    /// Setup function used to set the behavior of the tool tip based on if it exists in Canvas or Sprite based mode
    /// Icon overload
    /// - Josh
    /// </summary>
    /// <param name="_headerText"></param>
    /// <param name="_bodyText"></param>
    /// <param name="_iconIdentifier"></param>
    public void TooltipSetup(string _headerText, string _bodyText, string _iconIdentifier)
    {
        // Set Global
        g_global = S_Global.Instance;

        // Update the Text elements
        UpdateDebugTooltipUI(_headerText, _bodyText);
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private void Update()
    {
        Vector2 _mousePosition = Input.mousePosition;

        float _pivotX = _mousePosition.x / Screen.width;
        float _pivotY = _mousePosition.y / Screen.height;

        tlp_rectTransform.pivot = new Vector2(_pivotX, _pivotY);
        transform.position = _mousePosition;
    }

    /// <summary>
    /// Custom Update
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

        if (CheckHeaderTextLength() == false && CheckBodyTextLength() == false)
        {
            tlp_layoutElement.enabled = false;
        }
        else
        {
            tlp_layoutElement.enabled = true;
        }

        gameObject.SetActive(true);
    }

    public void AddIconEntry() 
    {

    }

    public void RemoveIconEntry() 
    {

    }

    /// <summary>
    /// Reset the tooltip when it's no longer applicable
    ///  - Josh
    /// </summary>
    public void ResetToolTip()
    {
        gameObject.SetActive(false);
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Helpers \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Check the character length for header text to determine if content size should be restricted
    ///  - Josh
    /// </summary>
    private bool CheckHeaderTextLength()
    {
        if(tlp_tx_headerText.text.Length < tlp_characterWrapLimit)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Check the character length for header text to determine if content size should be restricted
    ///  - Josh
    /// </summary>
    private bool CheckBodyTextLength()
    {
        if (tlp_tx_bodyText.text.Length < tlp_characterWrapLimit)
        {
            return false;
        }
        else
        {
            return true;
        }
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
        tlp_tx_bodyText.text = _bodyText;
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
