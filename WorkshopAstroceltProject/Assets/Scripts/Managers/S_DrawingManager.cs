using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DrawingManager : MonoBehaviour
{
    private S_Global g_global;

    public LineRenderer l_constelationLine;

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
            //this is the call to the finishing behaviour
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
    /// - Riley
    /// </summary>
    public void SpawnLine(S_StarClass _star1, S_StarClass _star2, Vector2 _loc1, Vector2 _loc2)
    {
        //make the line and set position for the end point and the previous and next star in script
        LineRenderer _newline = Instantiate(l_constelationLine);
        _newline.GetComponent<S_ConstellationLine>().lr_itSelf = _newline;
        //_newline.gameObject.transform.LookAt(_loc1);
        _newline.GetComponent<S_ConstellationLine>().SetUp();
        _newline.SetPosition(0, _loc2);
        _newline.SetPosition(1, _loc1);

        _newline.GetComponent<S_ConstellationLine>().s_previousStar = _star1;
        _newline.GetComponent<S_ConstellationLine>().s_nextStar = _star2;
        
        _newline.GetComponent<S_ConstellationLine>().i_index = i_index;
        
        i_index++;

        //set the vars for the stars so that they have the line theyre attached to, and the previous and next star
        _star1.s_star.m_nextLine = _newline;
        _star2.s_star.m_previousLine = _newline;

        _star1.s_star.m_next = _star2;
        _star2.s_star.m_previous = _star1;

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
    public void GoBackOnce(LineRenderer _line)
    {
        s_previousStar = _line.GetComponent<S_ConstellationLine>().s_previousStar;
        v2_prevLoc = _line.GetPosition(0);
        Destroy(_line.gameObject);
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
