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
    public GameObject s_neutralRitualStarGraphic;
    public GameObject s_redRitualStarGraphic;
    public GameObject s_blueRitualStarGraphic;
    public GameObject s_yellowRitualStarGraphic;


    [Header("Class Template")]
    public S_Star s_starTemplate;

    /// <summary>
    /// Fetch the global script and assign the class based off of the tag for this gameobject
    /// set the starSprite = to the SpriteRenderer
    /// then assign the startColor to the starSprite  
    /// Do in start to properly fetch global
    /// - Riley & Josh
    /// </summary>

    private void Start()
    {
        //change null to nullstar 
        g_global = S_Global.g_instance;

        //assign after the star class gets assigned 

        // Need to change for ritual star after we determine how ritual stars know they should be distnguished - Josj
        s_starSprite = s_neutralRitualStarGraphic.GetComponent<SpriteRenderer>();
        // will be neutral star graphic for now since that's the one on by default. 

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
        if (this.GetComponent<S_StarClass>().s_star.m_previousLine == null)
        {
            print("Here");
            //doesnt like this call
            g_global.g_DrawingManager.StarClicked(this.GetComponent<S_StarClass>(), transform.position);
        }
    }
}
