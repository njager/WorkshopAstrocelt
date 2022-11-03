using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class S_NodeStar : MonoBehaviour 
{
    private S_Global g_global;
    private Color c_starStartColor;

    private SpriteRenderer s_starSprite;

    private bool b_nodeClicked = false;

    [Header("Star Colors")]
    public Color c_starHoverColor;
    public Color c_clickedColor;
    public GameObject s_starGraphic;

    [Header("Star Click Bool")]
    public bool is_clicked = false;

    [Header("Preemptive drawing vars")]
    public bool b_clickableStar = false;
    public S_StarClass s_thisStar;

    [Header("Test Object to Use")]
    public S_TooltipTemplate tl_nodeStarTemplate;

    [Header("Mouse Enter Check")]
    public bool tl_b_mouseEntered;
    public bool tl_b_justUsed;
    public float timer = 0.03f;
    public bool timerWait = false;

    /// <summary>
    /// Fetch the global script and assign the class based off of the tag for this gameobject
    /// set the starSprite = to the SpriteRenderer
    /// then assign the startColor to the starSprite 
    /// Do in start to properly fetch global
    /// - Riley & Josh
    /// </summary>
    private void Awake()
    {
        //change null to nullstar 
        g_global = S_Global.Instance;

        //assign after the star class gets assigned 
        s_starSprite = s_starGraphic.GetComponent<SpriteRenderer>();

        c_starStartColor = s_starSprite.color;
    }

    public IEnumerator TimerCheck() 
    {
        if(timer > 0) 
        {
            timer -= Time.deltaTime;
        }

        if(timer < 0) 
        {
            timerWait = true;
        }

        if (timerWait)
        {
            tl_b_justUsed = false;
            yield return null;
        }
    }

    private void OnMouseEnter()
    {
        //Tooltip
        tl_b_mouseEntered = true;
        if(timerWait == true) 
        {
            timer = 0.03f;
        }

        //change the color to the hover color when moused over
        s_starSprite.color = c_starHoverColor;

        if (g_global.g_ConstellationManager.GetStarLockOutBool() && g_global.g_ConstellationManager.b_nodeStarChosen)
        {
            if (this.GetComponent<S_StarClass>().s_star.m_previousLine == null && g_global.g_ConstellationManager.GetMakingConstellation())
            {
                g_global.g_ConstellationManager.NodeStarClicked(this.GetComponent<S_StarClass>(), transform.position);
            }
        }
    }

    private void OnMouseOver()
    {
        if (tl_b_mouseEntered == true && tl_b_justUsed == false)
        {
            //Debug.Log("Triggered Mouse Hover");
            g_global.g_tooltipManager.SetupToolTipObject(tl_nodeStarTemplate, gameObject.transform);
        }
    }

    private void OnMouseExit()
    {
        // Tooltip
        g_global.g_tooltipManager.ResetTooltip();
        tl_b_mouseEntered = false;
        tl_b_justUsed = true;
        StartCoroutine(TimerCheck());

        if (GetNodeClicked())
        {
            s_starSprite.color = c_clickedColor;
        }
        else
        {
            //change the color to the start color when mouse leaves
            s_starSprite.color = c_starStartColor;
        }

        if (g_global.g_ConstellationManager.GetMakingConstellation() && g_global.g_ConstellationManager.b_nodeStarChosen)
        {
            if (is_clicked == false && this.GetComponent<S_StarClass>().s_star.m_previousLine != null && (g_global.g_ConstellationManager.ls_curConstellation.Count - 1) < 7)
            {
                if (this.GetComponent<S_StarClass>().s_star.m_nextLine == null)
                {
                    g_global.g_DrawingManager.GoBackOnce(this.GetComponent<S_StarClass>().s_star.m_previousLine.gameObject);
                }
            }

        }
    }

    /// <summary>
    /// Sets the color of the star to be a highlighted color
    /// </summary>
    public void NodeClickedColor()
    {
        s_starSprite.color = c_clickedColor;
    }

    /// <summary>
    /// Set the star to its origional color
    /// </summary>
    public void NodeStarColor()
    {
        s_starSprite.color = c_starStartColor;
    }

    /// <summary>
    /// This is the func that will trigger the drawing. 
    /// Check to make sure the star doesnt have all its lines 
    /// then call the drawingmanager that it is the node star and has been clicked
    /// </summary>
    public void OnMouseDown()
    {
        //trigger this if it is the first click
        if(g_global.g_ConstellationManager.GetStarLockOutBool() == true && !g_global.g_ConstellationManager.GetMakingConstellation())
        {
            Debug.Log("this would be wierd");
            g_global.g_ConstellationManager.NodeStarClicked(this.GetComponent<S_StarClass>(), transform.position);
        }
        else if (g_global.g_ConstellationManager.GetMakingConstellation() && g_global.g_ConstellationManager.ls_curConstellation.Count <= 1)
        {
            g_global.g_DrawingManager.ConstellationReset(g_global.g_ConstellationManager.ls_curConstellation[g_global.g_ConstellationManager.ls_curConstellation.Count-1]);
        }
        else if (g_global.g_ConstellationManager.GetMakingConstellation())
        {

            Debug.Log("We here?");
            is_clicked = false;

            g_global.g_ConstellationManager.AddStarToCurConstellation(s_thisStar);

            s_thisStar.s_star.m_previousLine.ResetEndPos(transform.position);

        }
        else
        {
            Debug.Log("Please finish play before drawing again.");
            return;
        }
    }

    //Getters\\

    public bool GetNodeClicked()
    {
        return b_nodeClicked;
    }

    //Setters\\

    public void SetNodeClicked(bool _bool)
    {
        b_nodeClicked = _bool;
    }

    public void ConfirmClickable(S_StarClass _star)
    {
        b_clickableStar = true;
        s_thisStar = _star;
    }
}
