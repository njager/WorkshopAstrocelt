using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class S_UITooltipDatabase : MonoBehaviour
{
    List<S_UITooltip> ls_activeTooltipList = new List<S_UITooltip>();

    public void FixedUpdate()
    {
        foreach(S_UITooltip _tooltip in ls_activeTooltipList.ToList()) 
        {
            _tooltip.UpdateDebugTooltipUI(_tooltip.GetTooltipHeaderText().text, _tooltip.GetTooltipBodyText().text);
        }
    }
}
