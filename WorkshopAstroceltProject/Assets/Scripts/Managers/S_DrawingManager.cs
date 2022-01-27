using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DrawingManager : MonoBehaviour
{
    private S_Global g_global;

    public S_StarClass s_previousStar;
    public bool b_drawing;

    private void Awake()
    {
        g_global = S_Global.g_instance;
    }

    /// <summary>
    /// This is the script that spawns the line renderer for the star map
    /// This is the func that will check the node star to make sure it is valid to start a new constellation
    /// changes the b_drawing variable when it is clicked
    /// - Riley
    /// </summary>
    public void NodeStarClicked(S_StarClass _starN)
    {

    }

    /// <summary>
    /// This is the func that will check the star to make sure it doesnt already have a line 
    /// - Riley
    /// </summary>
    public void StarClicked(S_StarClass _star)
    {
        //check if the clicked star has a 
        //if(s_previousStar is NodeStar) {dont check shit just gooo}
        //else { check for a line attached to the the previous }
        //at the end spawn the line if it is valid
        SpawnLine(s_previousStar, _star);
    }

    /// <summary>
    /// This is the func that spawns the line renderer for the star map
    /// It does not check if the stars alread have lines attached to them, but 
    /// the line renderer will tell this script in a different function if there is collision or not
    /// assign the stars to know if it has a linerender attached to it and puts them in the line renderer as well
    /// - Riley
    /// </summary>
    public void SpawnLine(S_StarClass _star1, S_StarClass _star2)
    {
        //spawn a line renderer and place it at the two locations
        //take the star object and put it in star1 star2
        //take star1 and star2 and put it in the line renderer
    }

    /// <summary>
    /// This is the func that the line renderer calls when it collides. if it passes true then it is placed and stays put,
    /// 
    /// if false then the line deletes itself and the function 
    /// - Riley
    /// </summary>
    public void IsValid(bool _line)
    {

    }

    /// <summary>
    /// This Function resets the entire constellation chain
    /// - Riley
    /// </summary>
    public void ConstellationReset()
    {
        //retrace the constellation from the node star
    }
}
