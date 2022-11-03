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

    [Header("Timer Elements")]
    public float f_timerAmount;
    public bool tl_b_timerComplete;
    public bool tl_b_displayedTooltip;

    /// <summary>
    /// Interaction Mechanism will differ from SpriteRenderers and Images
    /// - Josh
    /// </summary>
    private void OnMouseEnter()
    {
        tl_b_mouseEntered = true;
        tl_b_timerComplete = false;
        tl_b_displayedTooltip = false;

        StartCoroutine(HoverTimer());
        StartCoroutine(DisplayTooltip());
    }

    public IEnumerator DisplayTooltip() 
    {
        if (tl_b_mouseEntered == true && tl_b_timerComplete == true)
        {
            Debug.Log("Triggered Mouse Hover");
            g_global.g_tooltipManager.SetupToolTipObject(tl_shieldExample, gameObject.transform);
            tl_b_displayedTooltip = true;
        }
        yield return new WaitUntil(() => tl_b_displayedTooltip == true);
    }

    /// <summary>
    /// Key thing to remember, we aren't deleting the object per will, but just reusing it all the time
    /// </summary>
    private void OnMouseExit()
    {
        g_global.g_tooltipManager.ResetTooltip();
        tl_b_timerComplete = false;
        tl_b_mouseEntered = false;
        f_timerAmount = 2f;
        tl_b_displayedTooltip = true;
        tl_b_displayedTooltip = false;
    }

    /// <summary>
    /// Help function for deletion
    /// - Josh
    /// </summary>
    /// <returns></returns>
   
    public IEnumerator HoverTimer()
    {
        Debug.Log("Mouse Hover for 2 seconds");
        
        if (f_timerAmount > 0)
        {
            f_timerAmount -= Time.deltaTime;
        }

        if(f_timerAmount < 0) 
        {
            tl_b_timerComplete = true;
        }

        yield return new WaitUntil(() => tl_b_timerComplete == true);
    }
}
