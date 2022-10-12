using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TooltipManager : MonoBehaviour
{
    [Header("Tooltip Prefab")]
    [SerializeField] GameObject tooltipPrefab;

    public void SpawnToolTip(S_UITooltipTemplate _templateToBuildFrom, Transform _parentTransform)
    {
        // Create blank tooltip
        GameObject _tooltip = Instantiate(tooltipPrefab, Vector3.zero, Quaternion.identity);

        // Set new position
        _tooltip.transform.SetParent(_parentTransform, false);

        // Grab the tooltip script
        S_UITooltip _tooltipScript = _tooltip.GetComponent<S_UITooltip>();
    }

    public void AddIcons() 
    {

    }
}
