using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DrawingManager : MonoBehaviour
{
    private S_Global g_global;

    public GameObject l_constelationLine;

    public int i_index;

    public S_StarClass s_previousStar;
    public S_StarClass s_nullStarInst;
    public Vector2 v2_prevLoc;
    public bool b_drawing;

    private void Start()
    {
        g_global = S_Global.g_instance;
        s_previousStar = s_nullStarInst;
        i_index = 0;
    }

    /// <summary>
    /// This Function deals with whenever the player clicks on a node star
    /// if the player hasnt started a constellation then change drawing bool and set previous loc
    /// if the player is making a constellation then finish it, and call the finishing behaviour
    /// - Riley
    /// </summary>
    public void NodeStarClicked(S_StarClass _starN, Vector2 _loc)
    {
        if (b_drawing) 
        { 
            b_drawing = false;
            SpawnLine(s_previousStar, _starN, v2_prevLoc, _loc);
            s_previousStar = s_nullStarInst;
            g_global.g_ConstelationManager.RetraceConstelation(_starN);
        }
        else 
        { 
            b_drawing = true;
            s_previousStar = _starN;
            v2_prevLoc = _loc;
        }
    }

    /// <summary>
    /// This is the func for non node stars and checks conditions before passing along to the spawn line function 
    /// - Riley
    /// </summary>
    public void StarClicked(S_StarClass _star, Vector2 _loc)
    {
        if (s_previousStar != s_nullStarInst)
        {
            SpawnLine(s_previousStar, _star, v2_prevLoc, _loc);
        }
    }

    /// <summary>
    /// This is the func that spawns the line renderer for the star map
    /// It sets the start and end points of the line and then changes the previous star to be the most recently imputed
    /// sets the previous and next line in each script to be the line created
    /// - Riley and Josh
    /// </summary>
    public void SpawnLine(S_StarClass _star1, S_StarClass _star2, Vector2 _loc1, Vector2 _loc2)
    {
        //Instiate the linePrefab and grab it's objects
        GameObject _newLineObject = Instantiate(l_constelationLine);
        LineTempScript _lineScript = _newLineObject.GetComponent<LineTempScript>();
        LineRenderer _newLine = _lineScript.m_childLineRendererObject.GetComponent<LineRenderer>();

        //Set Stars in lineScript before changing location otherwise colision will happen before these are set
        _lineScript.s_previousStar = _star1;
        _lineScript.s_nextStar = _star2;

        //give each star their previous and next before the line is made to avoid overwriting the collision trigger
        _star1.s_star.m_next = _star2;
        _star2.s_star.m_previous = _star1;

        // Set line positions and width
        _newLine.SetPosition(0, _loc2);
        _newLine.SetPosition(1, _loc1);
        _newLine.startWidth = _lineScript.f_lineWidth;
        _newLine.endWidth = _lineScript.f_lineWidth;

        // Run set up script
        _lineScript.SetUp(_star1);

        //give the line an index and incranment by 1
        _lineScript.i_index = i_index;
        i_index++;

        //set the vars for the stars so that they have the line theyre attached to
        _star1.s_star.m_nextLine = _newLine;
        _star2.s_star.m_previousLine = _newLine;

        //set the previous star and loc
        s_previousStar = _star2;
        v2_prevLoc = _loc2;
    }

    /// <summary>
    /// This is the func that the line renderer calls when it collides
    /// use the line to go back to the previous star and set that as previousstar and previous loc
    /// destroy line at the end
    /// - Riley
    /// </summary>
    public void GoBackOnce(GameObject _line)
    {
        //get the data from the line and assign the previous star and loc
        LineTempScript _lineScript = _line.GetComponent<LineTempScript>();
        s_previousStar = _lineScript.s_previousStar;
        v2_prevLoc = _lineScript.m_lineRendererInst.GetPosition(1);

        //reset the data for the star
        s_previousStar.s_star.m_next = null;
        s_previousStar.s_star.m_nextLine = null;
        print(s_previousStar);

        //destroy the line
        Destroy(_line);
    }

    /// <summary>
    /// This Function resets the entire constellation chain
    /// - Riley
    /// </summary>
    public void ConstellationReset()
    {
        print("first");
        while (s_previousStar.starType != "Null")
        {
            S_StarClass _temporalStar = s_previousStar.s_star.m_previous;

            s_previousStar.s_star.m_previous = s_nullStarInst;
            s_previousStar.s_star.m_next = s_nullStarInst;

            //check if the line needs to be deleted
            if (s_previousStar.s_star.m_nextLine!=null)
            {
                Destroy(s_previousStar.s_star.m_nextLine);
            }
            
            s_previousStar.s_star.m_nextLine = null;
            s_previousStar.s_star.m_previousLine = null;

            //s_previousStar.s_star.

            s_previousStar = _temporalStar;
        }
    }
}
