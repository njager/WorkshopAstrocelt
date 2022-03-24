using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RitualStar : MonoBehaviour
{
    private S_Global g_global;
    private Color c_starStartColor;
    private SpriteRenderer s_starSprite;

    [Header("Star Colors")]
    public Color c_starHoverColor;
    //public GameObject s_neutralRitualStarGraphic; Non-existent
    public GameObject s_redRitualStarGraphic;
    public GameObject s_blueRitualStarGraphic;
    public GameObject s_yellowRitualStarGraphic;

    [Header("Color Booleans")]
    public bool s_b_redColor;
    public bool s_b_blueColor;
    public bool s_b_yellowColor;

    /// <summary>
    /// Grab global for the ritual star if needed
    /// Randomly choose between red, blue, and yellow ritual star graphics. 
    /// </summary>
    private void Awake()
    {
        g_global = S_Global.Instance;

        //Determine random color in awake first, to be used for hover effects in start
    }

    /// <summary>
    /// Set the starSprite = to the SpriteRenderer
    /// Then assign the startColor to the starSprite  
    /// - Riley & Josh
    /// </summary>
    private void Start()
    {
        s_starSprite = s_redRitualStarGraphic.GetComponent<SpriteRenderer>();

        c_starStartColor = s_starSprite.color;
    }

    private void OnMouseEnter()
    {
        //change the color to the hover color when moused over
        s_starSprite.color = c_starHoverColor;
    }

    private void OnMouseExit()
    {
        //change the color to the start color when mouse leaves
        s_starSprite.color = c_starStartColor;
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
            Debug.Log("Please finish play before drawing again.");
            return;
        }
    }
}
