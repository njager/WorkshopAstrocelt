using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class S_DrawingManager : MonoBehaviour
{
    //private vars
    private S_Global g_global;

    //index for the lines
    private int i_index;

    [Header("Add the ConstellationLine")]
    public GameObject l_constelationLine;

    [Header("Null and Node stars")]
    public S_StarClass s_nullStarInst;

    public bool b_lineDeletionCompletion;

    private void Awake()
    {
        g_global = S_Global.Instance;
        i_index = 0;
    }

    /// <summary>
    /// This is the func that spawns the line renderer for the star map
    /// It sets the start and end points of the line and then changes the previous star to be the most recently imputed
    /// sets the previous and next line in each script to be the line created
    /// - Riley and Josh
    /// </summary>
    /// <param name="_star1"></param>
    /// <param name="_star2"></param>
    /// <param name="_loc1"></param>
    /// <param name="_loc2"></param>
    public void SpawnLine(S_StarClass _star1, S_StarClass _star2, Vector2 _loc1, Vector2 _loc2)
    {
        //Debug.Log(_loc1.ToString() + "       " +  _loc2.ToString());

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
        _star1.s_star.m_nextLine = _lineScript;
        _star2.s_star.m_previousLine = _lineScript;

        //set the previous star and loc
        g_global.g_ConstellationManager.ChangePrevStarAndLoc(_star2, _loc2);

        // Find energy value
        int _energy = g_global.g_lineMultiplierManager.LineMultiplier(_star2.s_star.m_previousLine.gameObject);

        // Spawn popups 
        g_global.g_popupManager.CreatePopUpForStar(_star2, _energy, true);

        // Popups were spawned
        g_global.g_ConstellationManager.SetPopupStatusForCurrentLine(true);
    }

    /// <summary>
    /// This is the func that the line renderer calls when it collides
    /// use the line to go back to the previous star and set that as previousstar and previous loc
    /// destroy line at the end but dont call the constellation because the star was never added to the data structure
    /// - Riley
    /// </summary>
    public void GoBackOnce(GameObject _line)
    {
        //remove the deleted line from global
        g_global.g_ls_lineRendererList.Remove(_line);

        //set the cur previous star to have a nullstar as a previous
        g_global.g_ConstellationManager.s_previousStar.s_star.m_previous = s_nullStarInst;

        //get the data from the line and assign the previous star and loc
        S_ConstellationLine _lineScript = _line.GetComponent<S_ConstellationLine>();
        g_global.g_ConstellationManager.s_previousStar = _lineScript.s_previousStar;
        g_global.g_ConstellationManager.v2_prevLoc = _lineScript.m_lineRendererInst.GetPosition(1);

        //reset the data for the star
        g_global.g_ConstellationManager.s_previousStar.s_star.m_next = s_nullStarInst;
        g_global.g_ConstellationManager.s_previousStar.s_star.m_nextLine = null;
        Debug.Log("deleted a line and no star added to star list");

        S_StarClass _starClassScript = _lineScript.s_nextStar;

        // Remove any popups

        foreach (S_StarPopUp _popup in _starClassScript.ls_energyPopups.ToList()) 
        {
            _starClassScript.ls_energyPopups.Remove(_popup);
            _popup.DeletePopup();
        }

        //destroy the line
        Destroy(_line);

        //dont delete the star from the list just change to null
        //g_global.g_ConstellationManager.DeleteTopStarCurConstellation();
    }

    /// <summary>
    /// This Function resets the entire constellation chain 
    /// Clears line multiplier and energy while keeping the turn the same
    /// gets called from the undo button and after a constraint is triggered
    /// - Riley
    /// </summary>
    public void ConstellationReset(S_StarClass _Star)
    {
        //stop the player from clicking on stars while reseting
        g_global.g_ConstellationManager.SetStarLockOutBool(false);

        //reset the energy, multipliers, and the sound queues
        g_global.g_lineMultiplierManager.ClearLineList();
        g_global.g_energyManager.ClearStoredEnergy();
        
        //Debug.Log("Constellation Reset Triggered");

        S_StarClass _previousStar = _Star;

        while (_previousStar.starType != "Null")
        {
            if (_previousStar.starType == "Node")
            {
                _previousStar.gameObject.GetComponent<S_NodeStar>().NodeStarColor();
                _previousStar.gameObject.GetComponent<S_NodeStar>().SetNodeClicked(false);
            }
            else if(_previousStar.starType == "Ritual") 
            {
                Debug.Log("Here");
                //make the star clickable again
                _previousStar.gameObject.GetComponent<S_RitualStar>().b_hasBeenClicked = false;
            }
            else if (_previousStar.starType == "Energy")
            {
                Debug.Log("Here2");
                //make the star clickable again
                _previousStar.gameObject.GetComponent<S_EnergyStar>().b_hasBeenClicked = false;
            }

            //delete the popups
            foreach (S_StarPopUp _popup in _previousStar.ls_energyPopups.ToList())
            {
                _previousStar.ls_energyPopups.Remove(_popup);
                _popup.DeletePopup();
            }

            S_StarClass _temporalStar = _previousStar.s_star.m_previous;

            _previousStar.s_star.m_previous = s_nullStarInst;
            _previousStar.s_star.m_next = s_nullStarInst;

            //check if the line needs to be deleted
            //deletes the graphic not the star
            if (_previousStar.s_star.m_nextLine!=null)
            {
                Destroy(_previousStar.s_star.m_nextLine.gameObject.GetComponentInParent<S_ConstellationLine>().gameObject);
            }
            
            _previousStar.s_star.m_nextLine = null;
            _previousStar.s_star.m_previousLine = null;

            _previousStar = _temporalStar;
        }

        //call the constellation manager to clear the list
        g_global.g_ConstellationManager.DeleteWholeCurConstellation();

        //done drawing now, let the player start again
        g_global.g_ConstellationManager.SetStarLockOutBool(true);
    }

    /// <summary>
    /// This is a helper function that deletes the line 
    /// Gets triggered when the map changes
    /// - Riley
    /// </summary>
    public IEnumerator LineDeletion()
    {
        foreach (GameObject lineObject in g_global.g_ls_lineRendererList.ToList())
        {
            g_global.g_ls_lineRendererList.Remove(lineObject);
            Destroy(lineObject);
        }
        foreach (GameObject lineObject in g_global.g_ls_completedLineRendererList.ToList())
        {
            g_global.g_ls_lineRendererList.Remove(lineObject);
            Destroy(lineObject);
        }
        b_lineDeletionCompletion = true;
        yield return b_lineDeletionCompletion == true;
    }
}
