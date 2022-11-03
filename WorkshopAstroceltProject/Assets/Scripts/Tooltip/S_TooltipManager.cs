using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TooltipManager : MonoBehaviour
{
    [Header("Tooltip Object")]
    [SerializeField] GameObject tl_tooltipObject;
    [SerializeField] S_Tooltip tl_tooltipScript;

    [Header("Tooltip Icon Prefab")]
    [SerializeField] GameObject iconPrefab;

    private void Awake()
    {
        tl_tooltipObject.SetActive(false);
    }

    /// <summary>
    /// Modify the existing tool tip
    /// - Josh
    /// </summary>
    /// <param name="_templateToBuildFrom"></param>
    /// <param name="_parentTransform"></param>
    public void SetupToolTipObject(S_TooltipTemplate _templateToBuildFrom, Transform _parentTransform)
    {
        // Grab setup information from template
        string _headerText = _templateToBuildFrom.GetTooltipTemplateHeaderText();
        string _bodyText = _templateToBuildFrom.GetTooltipTemplateBodyText();

        // Call the setup function
        tl_tooltipScript.TooltipSetup(_headerText, _bodyText);

        // Move the tooltip object
        //tl_tooltipObject.transform.SetParent(_parentTransform, false);
    }

    /// <summary>
    /// Reset the tooltip when it's finished it's work
    /// - Josh
    /// </summary>
    public void ResetTooltip() 
    {
        tl_tooltipScript.ResetToolTip();
    }

    /// <summary>
    /// Helper function for setting up icons from relevant dictionary
    /// - Josh
    /// </summary>
    private void SetUpIcons()
    {

    }
}
