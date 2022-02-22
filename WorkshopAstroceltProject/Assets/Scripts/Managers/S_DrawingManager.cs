using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DrawingManager : MonoBehaviour
{
    //private vars
    private S_Global g_global;
    private bool b_drawing;

    public S_StarClass s_previousStar;
    public Vector2 v2_prevLoc;
    public int i_index;
    public Vector2 v2_nodeStarLoc;

    public GameObject _starSoundPhase1;
    public GameObject _starSoundPhase2;

    public int i_starSound = 0;

    [Header("Add the ConstellationLine")]
    public GameObject l_constelationLine;

    [Header("Null and Node stars")]
    public S_StarClass s_nullStarInst;
    public S_StarClass s_nodeStarInst;
    
    private void Awake()
    {
        g_global = S_Global.Instance;
        s_previousStar = s_nullStarInst;
        i_index = 0;
        v2_nodeStarLoc = s_nodeStarInst.gameObject.transform.position;
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
            //do some final thing with star sound
            b_drawing = false;
            _starSoundPhase1.SetActive(false);
            PlaySound();

            SpawnLine(s_previousStar, _starN, v2_prevLoc, _loc);
        }
        else 
        {
            i_starSound = 0;
            b_drawing = true;
            s_previousStar = _starN;
            v2_prevLoc = _loc;
            _starN.s_star.m_previous = s_nullStarInst;
        }
    }


    /// <summary>
    /// Added by Victor to play FMOD sounds
    /// </summary>
    public void PlaySound()
    {
        _starSoundPhase2.SetActive(true);
        var emitter = _starSoundPhase2.GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("Note Order", i_starSound);
    }

    /// <summary>
    /// This is the func for non node stars and checks conditions before passing along to the spawn line function 
    /// Added functionallity for clicking on a star before a node star
    /// - Riley
    /// </summary>
    public void StarClicked(S_StarClass _star, Vector2 _loc)
    {
        if (b_drawing)
        {
            if (s_previousStar != s_nullStarInst)
            {
                SpawnLine(s_previousStar, _star, v2_prevLoc, _loc);
            }
        }
        else
        {
            
            if (true)
            {
                // Audio: the sounds will be played once the object is enabled. When first click on a normal star, enable this object to play the first click sound that plays the first note and first note only.
                _starSoundPhase1.SetActive(true);
                
                b_drawing = true;
                SpawnLine(s_nodeStarInst, _star, v2_nodeStarLoc, _loc);
                s_nodeStarInst.s_star.m_previous = s_nullStarInst;
            }
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
        //change the star sound here if the line is formed
        i_starSound++;

        //Victor's sound
        var emitter = _starSoundPhase1.GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("Note Order", i_starSound);

        //Instiate the linePrefab and grab it's objects
        GameObject _newLineObject = Instantiate(l_constelationLine, s_nullStarInst.transform);
        S_ConstellationLine _lineScript = _newLineObject.GetComponent<S_ConstellationLine>();
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
        
        //decrement the star sound
        i_starSound--;

        //set the cur previous star to have a nullstar as a previous
        s_previousStar.s_star.m_previous = s_nullStarInst;

        //get the data from the line and assign the previous star and loc
        S_ConstellationLine _lineScript = _line.GetComponent<S_ConstellationLine>();
        s_previousStar = _lineScript.s_previousStar;
        v2_prevLoc = _lineScript.m_lineRendererInst.GetPosition(1);

        //reset the data for the star
        s_previousStar.s_star.m_next = s_nullStarInst;
        s_previousStar.s_star.m_nextLine = null;
        Debug.Log("deleted a line and now cur previousStar is", s_previousStar);

        //destroy the line
        g_global.g_lineMultiplierManager.lst_tempList.Remove(_line);
        Destroy(_line);

        //if you go back once and drawing is false then it was a node star
        if (!b_drawing) { b_drawing = true; }
    }

    /// <summary>
    /// This Function resets the entire constellation chain
    /// - Riley
    /// </summary>
    public void ConstellationReset()
    {
        g_global.g_lineMultiplierManager.ClearLineList();
        g_global.g_ConstellationManager.ClearEnergy();
        Debug.Log("Constellation Reset Triggered");
        g_global.g_ConstellationManager.energyWasCleared = true;
        i_starSound = 0;
        while (s_previousStar.starType != "Null")
        {
            S_StarClass _temporalStar = s_previousStar.s_star.m_previous;

            s_previousStar.s_star.m_previous = s_nullStarInst;
            s_previousStar.s_star.m_next = s_nullStarInst;

            //check if the line needs to be deleted
            //deletes the graphic not the star
            if (s_previousStar.s_star.m_nextLine!=null)
            {
                Destroy(s_previousStar.s_star.m_nextLine.gameObject.GetComponentInParent<S_ConstellationLine>().gameObject);
            }
            
            s_previousStar.s_star.m_nextLine = null;
            s_previousStar.s_star.m_previousLine = null;

            s_previousStar = _temporalStar;
        }

        //done drawing now
        b_drawing = false;
    }
}
