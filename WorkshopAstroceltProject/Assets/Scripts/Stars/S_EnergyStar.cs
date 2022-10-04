using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnergyStar : MonoBehaviour
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
    public GameObject s_redEnergyStarGraphic;
    public GameObject s_blueEnergyStarGraphic;
    public GameObject s_yellowEnergyStarGraphic;

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

        if (_colorIntRand == 1) // System choose red
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
        if (s_b_redColor == true) // Set Red Graphic as main graphic, toggle it on and all others off
        {
            // Toggles Red
            s_redEnergyStarGraphic.SetActive(true);
            s_blueEnergyStarGraphic.SetActive(false);
            s_yellowEnergyStarGraphic.SetActive(false);

            // Toggle Collider for Red
            s_redStarCollider.enabled = true;
            s_blueStarCollider.enabled = false;
            s_yellowStarCollider.enabled = false;

            // Grab correct graphic
            s_starSprite = s_redEnergyStarGraphic.GetComponent<SpriteRenderer>();
        }
        else if (s_b_blueColor == true) // Set Blue Graphic as main graphic, toggle it on and all others off
        {
            // Toggles Blue
            s_redEnergyStarGraphic.SetActive(false);
            s_blueEnergyStarGraphic.SetActive(true);
            s_yellowEnergyStarGraphic.SetActive(false);

            // Toggle Collider for Blue
            s_redStarCollider.enabled = false;
            s_blueStarCollider.enabled = true;
            s_yellowStarCollider.enabled = false;

            // Grab correct graphic
            s_starSprite = s_blueEnergyStarGraphic.GetComponent<SpriteRenderer>();
        }
        else if (s_b_yellowColor == true) // Set Yellow Graphic as main graphic, toggle it on and all others off
        {
            // Toggles Yellow
            s_redEnergyStarGraphic.SetActive(false);
            s_blueEnergyStarGraphic.SetActive(false);
            s_yellowEnergyStarGraphic.SetActive(true);

            // Toggle Collider for Yellow
            s_redStarCollider.enabled = false;
            s_blueStarCollider.enabled = false;
            s_yellowStarCollider.enabled = true;

            // Grab correct graphic
            s_starSprite = s_yellowEnergyStarGraphic.GetComponent<SpriteRenderer>();
        }

        // Trigger helper function scale change, 3 times for more variation (small changes)
        ScaleChange();
        ScaleChange();
        ScaleChange();


        //Then grab that sprites color (should be same for whatever is active)
        s_c_starStartColor = s_starSprite.color;
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
    }

    /// <summary>
    /// Change the color to the start color when mouse leaves the star
    /// Doesn't have to be determined beforehand, unlike the hover color
    /// Derived at start
    /// - Josh
    /// </summary>
    private void OnMouseExit()
    {
        s_starSprite.color = s_c_starStartColor;
    }

    public void OnMouseDown()
    {
        //if the star clicking is locked out, dont let the player click it
        if(g_global.g_ConstellationManager.GetStarLockOutBool())
        {
            if (this.GetComponent<S_StarClass>().s_star.m_previousLine == null)
            {
                g_global.g_ConstellationManager.StarClicked(this.GetComponent<S_StarClass>(), transform.position);
            }
            else if (this.GetComponent<S_StarClass>().s_star.m_nextLine == null)
            {
                Debug.Log("Clicked on current star so go back once");
                //reset line multiplier
                g_global.g_lineMultiplierManager.f_totalLineLength -= this.GetComponent<S_StarClass>().s_star.m_previousLine.f_lineLength;

                //remove energy by subbing the line first and then seeing what you would get if you did it again
                int _energy = g_global.g_lineMultiplierManager.LineMultiplier(this.GetComponent<S_StarClass>().s_star.m_previousLine.gameObject);
                g_global.g_lineMultiplierManager.f_totalLineLength -= this.GetComponent<S_StarClass>().s_star.m_previousLine.f_lineLength; //delete again since the func adds


                if (s_b_redColor) { g_global.g_energyManager.i_redStorageEnergy -= _energy; }
                else if (s_b_blueColor) { g_global.g_energyManager.i_blueStorageEnergy -= _energy; }
                else if (s_b_yellowColor) { g_global.g_energyManager.i_yellowStorageEnergy -= _energy; }


                //remove popup
                for (int i=0; i<_energy; i++)
                {
                    g_global.g_ls_starPopup.RemoveAt(g_global.g_ls_starPopup.Count-1);
                    Destroy(g_global.g_popupManager.v3_vfxContainer.GetChild(g_global.g_popupManager.v3_vfxContainer.childCount - 1).gameObject);
                }
                g_global.g_ConstellationManager.ls_curConstellation.RemoveAt(g_global.g_ConstellationManager.ls_curConstellation.Count-1);

                g_global.g_DrawingManager.GoBackOnce(this.GetComponent<S_StarClass>().s_star.m_previousLine.gameObject);
            }
        }
        else
        {
            Debug.Log("Please finish play before drawing again.");
            return;
        }
    }
}
