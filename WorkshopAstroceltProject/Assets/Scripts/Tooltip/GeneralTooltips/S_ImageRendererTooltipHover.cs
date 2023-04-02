using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_ImageRendererTooltipHover : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    [Header("Global Script Connection")]
    [SerializeField] S_Global g_global;

    [Header("Tooltip Template")]
    [SerializeField] S_TooltipTemplate tl_tooltipTemplate;

    [Header("Mouse Enter Check")]
    [SerializeField] bool tl_b_mouseEntered;

    [Header("Timer Elements")]
    [SerializeField] float tl_f_timeToWaste;
    [SerializeField] bool tl_b_timerComplete;
    [SerializeField] bool tl_b_displayedTooltip;
    [SerializeField] int tl_i_timerCompleteCheck;

    [Header("Timer Value For Reappearing")]
    [SerializeField] float tl_f_timerValue;

    [SerializeField] Image tl_imageComp;

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Check and see if the tooltip has been used, lock it out for a period of time
    /// Perhaps change to an IEnumerator down the line
    /// - Josh
    /// </summary>
    private void Update()
    {
        if (gameObject.GetComponent<Image>() != null)
        {
            if (gameObject.GetComponent<Image>().color.a != 0)
            {
                if (tl_b_mouseEntered == true && tl_b_displayedTooltip == false)
                {
                    if (tl_f_timeToWaste > 0)
                    {
                        tl_f_timeToWaste -= Time.deltaTime;
                    }
                }

                if (tl_f_timeToWaste < 0 && tl_i_timerCompleteCheck == 0)
                {
                    tl_b_timerComplete = true;
                    tl_i_timerCompleteCheck += 1;
                    if (tl_b_displayedTooltip == false)
                    {
                        DisplayTooltip();
                    }
                }
            }
        }
    }

    /// <summary>
    /// When mouse enters object, prime it for tooltip
    /// - Josh
    /// </summary>
    public void OnPointerEnter()
    {
        Debug.Log("TooltipEnter");
        tl_b_mouseEntered = true;
        tl_b_timerComplete = false;
        tl_b_displayedTooltip = false;
        tl_i_timerCompleteCheck = 0;
    }


    /// <summary>
    /// Function to actually trigger tooltip
    /// - Josh
    /// </summary>
    private void DisplayTooltip()
    {
        if (tl_b_mouseEntered == true && tl_b_timerComplete == true)
        {
            Debug.Log("Triggered Mouse Hover");
            g_global.g_tooltipManager.SetupToolTipObject(tl_tooltipTemplate, gameObject.transform);
            tl_b_displayedTooltip = true;
        }
    }

    /// <summary>
    /// Set tooltip to not automaticallly appear, turn it off
    /// - Josh
    /// </summary>
    /// <summary>
    /// Key thing to remember, we aren't deleting the object per will, but just reusing it all the time
    /// </summary>
    public void OnPointerExit()
    {
        g_global.g_tooltipManager.ResetTooltip();
        tl_b_timerComplete = false;
        tl_b_mouseEntered = false;
        tl_f_timeToWaste = tl_f_timerValue;
        tl_b_displayedTooltip = true;
        tl_b_displayedTooltip = false;
        tl_i_timerCompleteCheck = 0;
    }
}
