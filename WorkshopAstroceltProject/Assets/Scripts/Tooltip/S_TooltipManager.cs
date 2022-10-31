using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TooltipManager : MonoBehaviour
{
    [Header("Tooltip Prefab")]
    [SerializeField] GameObject iconPrefab;

    /// <summary>
    /// Create a new tool tip and set it up from template
    /// - Josh
    /// </summary>
    /// <param name="_templateToBuildFrom"></param>
    /// <param name="_parentTransform"></param>
    public void SpawnToolTip(S_TooltipTemplate _templateToBuildFrom, Transform _parentTransform)
    {
        // Grab setup information from template
        string _headerText = _templateToBuildFrom.GetTooltipTemplateHeaderText();
        string _bodyText = _templateToBuildFrom.GetTooltipTemplateBodyText();

        // Create new _tooltip
        S_Tooltip _tooltip = new S_Tooltip(_headerText, _bodyText);

        // Set new parent in hierarchy
        _tooltip.transform.SetParent(_parentTransform, false);

        // Set new positon
        _tooltip.transform.position = _parentTransform.position;
    }

    /// <summary>
    /// Helper function for setting up icons from relevant dictionary
    /// - Josh
    /// </summary>
    private void SetUpIcons() 
    {

    }
}
