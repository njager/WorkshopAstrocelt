using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RitualStar : MonoBehaviour
{
    private S_Global g_global;
    private Color s_c_starStartColor;
    private SpriteRenderer s_starSprite;

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

    /// <summary>
    /// Grab global for the ritual star
    /// Randomly choose between red, blue, and yellow ritual star graphics. 
    /// -Josh
    /// </summary>
    private void Awake()
    {
        g_global = S_Global.Instance;

        //Determine random color in awake first, to be used for hover effects in start
        int _colorIntRand = Random.Range(1, 3);
        
        if(_colorIntRand == 1) // System choose red
        {
            // Adjust accordingly
            s_b_redColor = true;
            s_b_blueColor = false;
            s_b_yellowColor = false; 
        }

        else if (_colorIntRand == 2) // System choose blue
        {
            // Adjust accordingly
            s_b_redColor = false;
            s_b_blueColor = true;
            s_b_yellowColor = false;
        }

        else if (_colorIntRand == 3) // System choose yellow
        {
            // Adjust accordingly
            s_b_redColor = false;
            s_b_blueColor = false;
            s_b_yellowColor = true;
        }
        else
        {
            Debug.Log("Ritual Star error!");
        }
    }

    /// <summary>
    /// Set the starSprite = to the SpriteRenderer
    /// Then assign the startColor to the starSprite  
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
            
            // Grab correct graphic
            s_starSprite = s_redRitualStarGraphic.GetComponent<SpriteRenderer>();
        }
        else if (s_b_blueColor == true) // Set Blue Graphic as main graphic, toggle it on and all others off
        {
            // Toggles Blue
            s_redRitualStarGraphic.SetActive(false);
            s_blueRitualStarGraphic.SetActive(true);
            s_yellowRitualStarGraphic.SetActive(false);

            // Grab correct graphic
            s_starSprite = s_blueRitualStarGraphic.GetComponent<SpriteRenderer>();
        }
        else if (s_b_yellowColor == true) // Set Yellow Graphic as main graphic, toggle it on and all others off
        {
            // Toggles Yellow
            s_redRitualStarGraphic.SetActive(false);
            s_blueRitualStarGraphic.SetActive(false);
            s_yellowRitualStarGraphic.SetActive(true);

            // Grab correct graphic
            s_starSprite = s_yellowRitualStarGraphic.GetComponent<SpriteRenderer>();
        }

        //Then grab that sprites color (should be same for whatever is active)
        s_c_starStartColor = s_starSprite.color;
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

        if (g_global.g_ConstellationManager.b_starLockout == true)
        {
            if (this.GetComponent<S_StarClass>().s_star.m_previousLine == null)
            {
                g_global.g_ConstellationManager.StarClicked(this.GetComponent<S_StarClass>(), transform.position);
            }
        }
        else
        {
            Debug.Log("Please play your cards before drawing again.");
            return;
        }
    }
}
