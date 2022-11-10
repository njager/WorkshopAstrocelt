using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class S_RitualStar : MonoBehaviour
{
    private S_Global g_global;
    private Color s_c_starStartColor;
    private SpriteRenderer s_starSprite;

    [Header("Star Class")]
    public S_StarClass s_starClass;

    [Header("Star Colors")]
    public Color s_c_redStarHoverColor;
    public Color s_c_blueStarHoverColor;
    public Color s_c_yellowStarHoverColor;

    [Header("Star Graphics")]
    public GameObject s_redRitualStarGraphic;
    public GameObject s_blueRitualStarGraphic;
    public GameObject s_yellowRitualStarGraphic;

    [Header("Color Booleans")]
    public bool s_b_redColor;
    public bool s_b_blueColor;
    public bool s_b_yellowColor;

    [Header("Star Collisons")]
    public PolygonCollider2D s_redStarCollider;
    public PolygonCollider2D s_blueStarCollider;
    public PolygonCollider2D s_yellowStarCollider;

    [Header("Star Scale Values")]
    [SerializeField] float f_lowerScaleBound;
    [SerializeField] float f_upperScaleBound;

    [Header("Star Click Bool")]
    public bool b_hasBeenClicked = false;

    //some private vars for the predictive drawing
    private bool b_clickableStar = false;
    private S_StarClass s_thisStar;

    [Header("Tooltip Template to Use")]
    public S_TooltipTemplate tl_toolTipTemplate;

    [Header("Mouse Enter Check")]
    public bool tl_b_mouseEntered;

    [Header("Timer Elements")]
    public float f_timerAmount;
    public bool tl_b_timerComplete;
    public bool tl_b_displayedTooltip;
    public int timerCompleteCheck;

    /// <summary>
    /// Grab global for the ritual star
    /// Randomly choose between red, blue, and yellow ritual star graphics. 
    /// -Josh
    /// </summary>
    private void Awake()
    {
        g_global = S_Global.Instance;

        //Determine random color in awake first, to be used for hover effects in start
        int _colorIntRand = Random.Range(1, 4);
        
        if(_colorIntRand == 1) // System choose red
        {
            // Adjust accordingly
            s_b_redColor = true;
            s_b_blueColor = false;
            s_b_yellowColor = false;
            s_starClass.colorType = "red";
        }

        else if (_colorIntRand == 2) // System choose blue
        {
            // Adjust accordingly
            s_b_redColor = false;
            s_b_blueColor = true;
            s_b_yellowColor = false;
            s_starClass.colorType = "blue";
        }

        else if (_colorIntRand == 3) // System choose yellow
        {
            // Adjust accordingly
            s_b_redColor = false;
            s_b_blueColor = false;
            s_b_yellowColor = true;
            s_starClass.colorType = "yellow";
        }
        else
        {
            Debug.Log("Ritual Star error!");
        }
    }

    /// <summary>
    /// Set the starSprite = to the active SpriteRenderer based off bool
    /// Then assign the startColor to the starSprite
    /// Toggle colliders for the active graphic
    /// Also change scale of the star in a small percentage
    /// - Riley & Josh
    /// </summary>
    private void Start()
    {
        if(s_b_redColor == true) // Set Red Graphic as main graphic, toggle it on and all others off
        {
            // Toggles Red
            s_redRitualStarGraphic.SetActive(true);
            s_blueRitualStarGraphic.SetActive(false);
            s_yellowRitualStarGraphic.SetActive(false);

            // Toggle Collider for Red
            s_redStarCollider.enabled = true;
            s_blueStarCollider.enabled = false;
            s_yellowStarCollider.enabled = false; 

            // Grab correct graphic
            s_starSprite = s_redRitualStarGraphic.GetComponent<SpriteRenderer>();
        }
        else if (s_b_blueColor == true) // Set Blue Graphic as main graphic, toggle it on and all others off
        {
            // Toggles Blue
            s_redRitualStarGraphic.SetActive(false);
            s_blueRitualStarGraphic.SetActive(true);
            s_yellowRitualStarGraphic.SetActive(false);

            // Toggle Collider for Blue
            s_redStarCollider.enabled = false;
            s_blueStarCollider.enabled = true;
            s_yellowStarCollider.enabled = false;

            // Grab correct graphic
            s_starSprite = s_blueRitualStarGraphic.GetComponent<SpriteRenderer>();
        }
        else if (s_b_yellowColor == true) // Set Yellow Graphic as main graphic, toggle it on and all others off
        {
            // Toggles Yellow
            s_redRitualStarGraphic.SetActive(false);
            s_blueRitualStarGraphic.SetActive(false);
            s_yellowRitualStarGraphic.SetActive(true);

            // Toggle Collider for Yellow
            s_redStarCollider.enabled = false;
            s_blueStarCollider.enabled = false;
            s_yellowStarCollider.enabled = true;

            // Grab correct graphic
            s_starSprite = s_yellowRitualStarGraphic.GetComponent<SpriteRenderer>();
        }

        // Trigger helper function scale change, 3 times for more variation (small changes)
        ScaleChange();
        ScaleChange();
        ScaleChange();
       
        
        //Then grab that sprites color (should be same for whatever is active)
        s_c_starStartColor = s_starSprite.color;
    }

    private void Update()
    {
        if (tl_b_mouseEntered == true && tl_b_displayedTooltip == false)
        {
            if (f_timerAmount > 0)
            {
                f_timerAmount -= Time.deltaTime;
            }
        }

        if (f_timerAmount < 0 && timerCompleteCheck == 0)
        {
            tl_b_timerComplete = true;
            timerCompleteCheck += 1;
            if (tl_b_displayedTooltip == false)
            {
                DisplayTooltip();
            }
        }
    }

    /// <summary>
    /// HelperFunction to change scale of the stars
    /// </summary>
    private void ScaleChange()
    {
        // Set random float values for vector bulding 
        float _xScaleVector = Random.Range(f_lowerScaleBound, f_upperScaleBound); 
        float _yScaleVector = Random.Range(f_lowerScaleBound, f_upperScaleBound);

        // Build new Scale
        Vector3 _tempScale = new Vector3(_xScaleVector, _yScaleVector, 0);

        // Toss a coin
        int _scaleChance = Random.Range(0, 2); 
        if (_scaleChance == 0) // Add new scale, heads
        {
            transform.localScale += _tempScale;
        }
        if (_scaleChance == 1) // Subtract new scale, tails
        {
            transform.localScale -= _tempScale;
        }
    }

    /// <summary>
    /// Change the color to the hover color when moused over according to color when moused over
    /// - Josh
    /// </summary>
    private void OnMouseEnter()
    {
        //Tooltip
        tl_b_mouseEntered = true;
        tl_b_timerComplete = false;
        tl_b_displayedTooltip = false;
        timerCompleteCheck = 0;

        if (s_b_redColor == true) // If Red
        {
            s_starSprite.color = s_c_redStarHoverColor;
        }
        else if (s_b_blueColor == true) // If Blue
        {
            s_starSprite.color = s_c_blueStarHoverColor;
        }
        else if (s_b_yellowColor == true) // If Yellow
        {
            s_starSprite.color = s_c_yellowStarHoverColor;
        }
        if (g_global.g_ConstellationManager.GetStarLockOutBool())
        {
            if (this.GetComponent<S_StarClass>().s_star.m_previousLine == null && (g_global.g_ConstellationManager.ls_curConstellation.Count() - 1) < 7)
            {
                g_global.g_ConstellationManager.StarClicked(this.GetComponent<S_StarClass>(), transform.position);
            }
        }
    }

    public void DisplayTooltip()
    {
        if (tl_b_mouseEntered == true && tl_b_timerComplete == true)
        {
            Debug.Log("Triggered Mouse Hover");
            g_global.g_tooltipManager.SetupToolTipObject(tl_toolTipTemplate, gameObject.transform);
            tl_b_displayedTooltip = true;
        }
    }

    /// <summary>
    /// Change the color to the start color when mouse leaves the star
    /// Doesn't have to be determined beforehand, unlike the hover color
    /// Derived at start
    /// - Josh
    /// </summary>
    private void OnMouseExit()
    {
        // Tooltip
        g_global.g_tooltipManager.ResetTooltip();
        tl_b_mouseEntered = false;
        tl_b_timerComplete = false;
        tl_b_mouseEntered = false;
        f_timerAmount = 2f;
        tl_b_displayedTooltip = true;
        tl_b_displayedTooltip = false;
        timerCompleteCheck = 0;

        s_starSprite.color = s_c_starStartColor;
        if (g_global.g_ConstellationManager.GetMakingConstellation() && g_global.g_ConstellationManager.b_nodeStarChosen)
        {
            if (b_hasBeenClicked == false && (g_global.g_ConstellationManager.ls_curConstellation.Count() - 1) < 7 && this.GetComponent<S_StarClass>().s_star.m_previousLine != null)
            {
                if (this.GetComponent<S_StarClass>().s_star.m_nextLine == null)
                {
                    g_global.g_DrawingManager.GoBackOnce(this.GetComponent<S_StarClass>().s_star.m_previousLine.gameObject);
                }
            }

        }
    }

    public void OnMouseDown()
    {
        //make a reference to the s_starclass
        S_StarClass _starClassScript = gameObject.GetComponent<S_StarClass>();

        //if the star clicking is locked out, dont let the player click it
        if (!g_global.g_ConstellationManager.b_nodeStarChosen)
        {
            g_global.g_ConstellationManager.CreateNodeStar(this.gameObject);
        }
        else if (g_global.g_ConstellationManager.GetStarLockOutBool() && b_clickableStar)
        {
            if (_starClassScript.s_star.m_previousLine != null && !b_hasBeenClicked && _starClassScript.s_star.m_nextLine == null)
            {
                // Set b_hasBeenClickedBool
                b_hasBeenClicked = true;
                Debug.Log("S_Ritual - clicked logic chain");

                // Set star permanent status
                _starClassScript.SetTemporaryVisualBool(false);

                // Actually add the star to the constellation list
                g_global.g_ConstellationManager.AddStarToCurConstellation(s_thisStar);

                // Change popup color
                g_global.g_popupManager.ConfirmTemporaryPopup();

                // Set the proper end position for graphic
                s_thisStar.s_star.m_previousLine.ResetEndPos(transform.position);
            }
            else if (_starClassScript.s_star.m_previousLine != null && b_hasBeenClicked && _starClassScript.s_star.m_nextLine == null)
            {
                Debug.Log("Clicked twice on current star so go back once");

                s_starClass.s_star.i_energy = 0;

                //remove energy by subbing the line first and then seeing what you would get if you did it again
                g_global.g_consecutiveColorTrackerManager.GoBackForColorTracker(s_starClass.s_star.s_previousColor, s_starClass.s_star.i_previousBonus);


                // Determine energy storage bin
                if (s_b_redColor)
                {
                    g_global.g_energyManager.StoreEnergy("red", -s_starClass.s_star.i_energy);
                }
                else if (s_b_blueColor)
                {
                    g_global.g_energyManager.StoreEnergy("blue", -s_starClass.s_star.i_energy);
                }
                else if (s_b_yellowColor)
                {
                    g_global.g_energyManager.StoreEnergy("yellow", -s_starClass.s_star.i_energy);
                }

                // Reset has been clicked
                b_hasBeenClicked = false;

                // Reset star temp status (just in case)
                _starClassScript.SetTemporaryVisualBool(true);

                // Update managers
                g_global.g_ConstellationManager.ls_curConstellation.RemoveAt(g_global.g_ConstellationManager.ls_curConstellation.Count - 1);

                g_global.g_DrawingManager.GoBackOnce(_starClassScript.s_star.m_previousLine.gameObject);
            }
        }
        else
        {
            Debug.Log("Please finish play before drawing again.");
            return;
        }
    }


    /// <summary>
    /// Confirm the test line is going to be built
    /// - Riley
    /// </summary>
    /// <param name="_star"></param>
    public void ConfirmClickable(S_StarClass _star)
    {
        b_clickableStar = true;
        s_thisStar = _star;
    }
}
