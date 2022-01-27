using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_NullStar : MonoBehaviour
{
    private S_Global g_global;
    
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
    private void Awake()
    {
        //change null to nullstar 
        g_global = S_Global.g_instance;
    }

}
