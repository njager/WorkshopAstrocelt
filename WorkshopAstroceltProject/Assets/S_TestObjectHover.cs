using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TestObjectHover : MonoBehaviour
{
    private S_Global g_global;

    [Header("Test Object to Use")]
    public S_TooltipTemplate tl_shieldExample;

    [Header("Mouse Enter Check")]
    public bool tl_b_mouseEntered;

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    /// <summary>
    /// Interaction Mechanism will differ from SpriteRenderers and Images
    /// - Josh
    /// </summary>
    private void OnMouseEnter()
    {
        tl_b_mouseEntered = true;
    }

    private void OnMouseOver()
    {
        if(tl_b_mouseEntered == true) 
        {
            //Debug.Log("Triggered Mouse Hover");
            g_global.g_tooltipManager.SetupToolTipObject(tl_shieldExample, gameObject.transform);
        }
    }

    /// <summary>
    /// Key thing to remember, we aren't deleting the object per will, but just reusing it all the time
    /// </summary>
    private void OnMouseExit()
    {
        g_global.g_tooltipManager.ResetTooltip();
        tl_b_mouseEntered = false;
    }
}
