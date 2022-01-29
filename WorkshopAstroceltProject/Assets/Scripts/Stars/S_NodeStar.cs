using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class S_NodeStar : MonoBehaviour 
{
    private S_Global g_global;
    private Color c_starStartColor;

    private SpriteRenderer s_starSprite;

    [Header("Star Colors")]
    public Color c_starHoverColor;
    public GameObject s_starGraphic;


    [Header("Class Templates")]
    public S_Star s_starTemplate;


    /// <summary>
    /// Fetch the global script and assign the class based off of the tag for this gameobject
    /// set the starSprite = to the SpriteRenderer
    /// then assign the startColor to the starSprite 
    /// - Riley & Josh
    /// </summary>
    private void Start()
    {
        //change null to nullstar 
        g_global = S_Global.g_instance;

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

    /// <summary>
    /// This is the func that will trigger the drawing. 
    /// Check to make sure the star doesnt have all its lines 
    /// then call the drawingmanager that it is the node star and has been clicked
    /// </summary>
    public void OnMouseDown()
    {
        print("Here Node");
        //doesnt like this call
        g_global.g_DrawingManager.NodeStarClicked(this.GetComponent<S_StarClass>(), transform.position);
    }
}
