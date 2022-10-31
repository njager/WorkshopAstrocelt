using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class S_TooltipDatabase : MonoBehaviour
{
    List<S_Tooltip> ls_activeTooltipList = new List<S_Tooltip>();

    public void FixedUpdate()
    {
        foreach(S_Tooltip _tooltip in ls_activeTooltipList.ToList()) 
        {
            _tooltip.UpdateDebugTooltipUI(_tooltip.GetTooltipHeaderText().text, _tooltip.GetTooltipBodyText().text);
        }
    }
}
