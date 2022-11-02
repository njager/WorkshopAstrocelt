using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tooltip", menuName = "Tooltip")]
public class S_TooltipTemplate : ScriptableObject
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    [Header("Header Text:")]
    [SerializeField] string HeaderText;

    [Header("Body Text:")]
    [SerializeField] string BodyText;

    [Header("Icon Entries Sprite List")]
    [SerializeField] List<Sprite> iconEntryArtList = new List<Sprite>();

    [Header("Icon Entry Text List")]
    [SerializeField] List<string> iconEntryTextList = new List<string>();

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
    public string GetTooltipTemplateHeaderText()
    {
        return HeaderText;
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
}
