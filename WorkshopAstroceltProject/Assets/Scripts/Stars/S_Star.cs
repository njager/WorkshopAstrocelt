using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Star : MonoBehaviour
{
    private S_Global g_global;
    private Color c_starStartColor;

    private SpriteRenderer s_starSprite;

    [Header("Star Colors")]
    public Color c_starHoverColor;
    public GameObject s_starGraphic;
    

    [Header("Class Templates")]
    public S_NodeStar s_nodeStarTemplate;
    public S_EnergyStar s_energyStarTemplate;
    public S_ElementStar s_elementStarTemplate;


    /// <summary>
    /// Fetch the global script and assign the class based off of the tag for this gameobject
    /// set the starSprite = to the SpriteRenderer
    /// then assign the startColor to the starSprite 
    /// - Riley & Josh
    /// </summary>
    private void Awake()
    {
        //change null to nullstar 
        g_global = S_Global.g_instance;

        if (gameObject.tag == "NodeStar")
        {
            s_nodeStarTemplate = g_global.g_StarClassManager.g_nodeStarTemplate;
            s_elementStarTemplate = null;
            s_energyStarTemplate = null;
        }
        else if (gameObject.tag == "ElementStar") 
        {
            s_nodeStarTemplate = null;
            s_elementStarTemplate = g_global.g_StarClassManager.g_elementStarTemplate;
            s_energyStarTemplate = null;
        }
        else if (gameObject.tag == "EnergyStar")
        {
            s_nodeStarTemplate = null;
            s_elementStarTemplate = null;
            s_energyStarTemplate = g_global.g_StarClassManager.g_energyStarTemplate;
        }

        //assign after the star class gets assigned 

        s_starSprite = s_starGraphic.GetComponent<SpriteRenderer>();

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
}
