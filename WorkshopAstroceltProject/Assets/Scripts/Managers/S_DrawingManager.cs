using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DrawingManager : MonoBehaviour
{
    private S_Global g_global;

    public LineRenderer l_constelationLine;


    public S_StarClass s_previousStar;
    public Vector2 v2_prevLoc;
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
    public void NodeStarClicked(S_StarClass _starN, Vector2 _loc)
    {
        if (b_drawing) 
        { 
            b_drawing = false;
            SpawnLine(s_previousStar, _starN, v2_prevLoc, _loc);
        }
        else 
        { 
            b_drawing = true;
            s_previousStar = _starN;
            v2_prevLoc = _loc;
        }
        print("did it");
    }

    /// <summary>
    /// This is the func for non node stars and checks conditions before passing along to the spawn line function 
    /// - Riley
    /// </summary>
    public void StarClicked(S_StarClass _star, Vector2 _loc)
    {
        if (s_previousStar != null)
        {
            SpawnLine(s_previousStar, _star, v2_prevLoc, _loc);
        }
    }

    /// <summary>
    /// This is the func that spawns the line renderer for the star map
    /// It sets the start and end points of the line and then changes the previous star to be the most recently imputed
    /// sets the previous and next line in each script to be the line created
    /// - Riley
    /// </summary>
    public void SpawnLine(S_StarClass _star1, S_StarClass _star2, Vector2 _loc1, Vector2 _loc2)
    {
        LineRenderer _newline = Instantiate(l_constelationLine);

        _newline.SetPosition(0, _loc1);
        _newline.SetPosition(1, _loc2);

        _star1.s_star.m_nextLine = _newline;
        _star2.s_star.m_previousLine = _newline;

        _star1.s_star.m_next = _star2;
        _star2.s_star.m_previous = _star1;

        s_previousStar = _star2;
        v2_prevLoc = _loc2;
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
