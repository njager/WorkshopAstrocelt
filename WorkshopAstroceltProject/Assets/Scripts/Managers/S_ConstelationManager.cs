using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq; 

public class S_ConstelationManager : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    // Private variables
    private S_Global g_global;
    private bool b_makingConstellation;

    [Header("Current Constellation Values")]
    public List<S_StarClass> ls_curConstellation;
    public string str_curColor = "";
    [SerializeField] bool b_curStarSpawnedPopupsAlready;

    [Header("Star Lockout Bool")]
    public bool b_starLockout = false;

    [Header("Previos star and location")]
    public S_StarClass s_previousStar;
    public Vector2 v2_prevLoc;

    [Header("Timer")]
    public float f_timer = 1f;

    [Header("Null star")]
    public S_StarClass s_nullStarInst;

    [Header("Constellation Sizes")]
    public int i_minSize;
    public int i_maxSize;

    [Header("Energy Count")]
    public int i_energyCount;

    [Header("Constellation Finished Bool for Popup")]
    public bool s_b_popupMove;

    [Header("Node Star Prefab")]
    public GameObject s_nodeStarPrefab;

    [Header("Sound Phases")]
    public GameObject _starSoundPhase1;
    public GameObject _starSoundPhase2;

    [Header("Cardball Limiting Bool tied to Spawning")]
    public bool c_cardballsSpawned;

    [Header("Star Sound Index")]
    public int i_starSound = 0;

    [Header("Bool for Nodestar Placement")]
    public bool b_nodeStarChosen = false;

    private void Awake()
    {
        //fetch global, get set previous as null, and start with star lockout
        g_global = S_Global.Instance;
        s_previousStar = s_nullStarInst;

        // Get popups to not move at first
        s_b_popupMove = false; 
    }

    /// <summary>
    /// Make the adding to the constellation list wait for a couple of frames to make sure the line doesnt delete itself
    /// Gets called from the line script, and passes the star to use if the line still exists
    /// -Riley
    /// </summary>
    /// <param name="_star"></param>
    /// <returns></returns>
    public IEnumerator LineWait(S_StarClass _star)
    {
        //Debug.Log("does this work");

        //wait for checking stars
        yield return new WaitForEndOfFrame();

        if (!_star.s_star.m_previousLine) { Debug.Log("line is gone so no star added"); yield return null; }
        else 
        {
            if (_star.starType == "Energy")
            {
                _star.gameObject.GetComponent<S_EnergyStar>().ConfirmClickable(_star);
            }
            else if (_star.starType == "Ritual")
            {
                _star.gameObject.GetComponent<S_RitualStar>().ConfirmClickable(_star);
            }
            else if (_star.starType == "Node")
            {
                _star.gameObject.GetComponent<S_NodeStar>().ConfirmClickable(_star);
            }
            else
            {
                Debug.Log("not a valid star type");
            }
        }
    }

    /// <summary>
    /// This func gets called from the stars themseleves after the line gets spawned.
    /// Happens when the star gets clicked
    /// Adds the star to the data structure and checks types and constraints
    /// -Riley
    /// </summary>
    /// <param name="_star"></param>
    public void AddStarToCurConstellation(S_StarClass _star)
    {
        //g_global.g_resourceGraphic.BonusTracker(_star);

        //change the star sound here if the line is formed
        i_starSound++;

        //Victor's sound
        var emitter = _starSoundPhase1.GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("Note Order", i_starSound);

        //add to data structure
        ls_curConstellation.Add(_star);

        if (_star.starType == "Node")
        {
            S_NodeStar _node = _star.gameObject.GetComponent<S_NodeStar>();

            if (b_makingConstellation)
            {
                //finsih making the constellation

                _node.SetNodeClicked(false);
                FinishConstellation(_star);
            }
            else
            {
                //now that the node is added, change the bool
                b_makingConstellation = true;
                _node.NodeClickedColor();
                _node.SetNodeClicked(true);
            }
        }
        //check if the length is greater than the max length, sub 1 for the two node stars
        else if (ls_curConstellation.Count() - 2 >= i_maxSize)
        {
            Debug.Log("Constellation Length is greater than " + i_maxSize);
            //delete the constellation with the top star
            g_global.g_DrawingManager.ConstellationReset(ls_curConstellation[ls_curConstellation.Count()-1]);
        }
        //check the star type
        else if (_star.starType == "Ritual")
        {
            //set the currentconsecutive energy
            g_global.g_consecutiveColorTrackerManager.ColorTrackerCheck(_star.colorType);

            //get the ritual star component
            S_RitualStar _rStar = _star.gameObject.GetComponent<S_RitualStar>();

            //compare in hierarchy to get the color
            if (_rStar.s_b_redColor) { g_global.g_energyManager.StoreEnergy("red", _star.s_star.i_energy); }
            else if (_rStar.s_yellowRitualStarGraphic.activeInHierarchy)
            { g_global.g_energyManager.StoreEnergy("yellow", _star.s_star.i_energy); }
            else if (_rStar.s_b_blueColor) { g_global.g_energyManager.StoreEnergy("blue", _star.s_star.i_energy); }
        }
        else
        {
            //set the currentconsecutive energy
            g_global.g_consecutiveColorTrackerManager.ColorTrackerCheck(_star.colorType);

            //get the energy star component
            S_EnergyStar _eStar = _star.gameObject.GetComponent<S_EnergyStar>();

            //get the color
            if (_eStar.s_b_redColor) { g_global.g_energyManager.StoreEnergy("red", _star.s_star.i_energy); }
            else if (_eStar.s_b_yellowColor) { g_global.g_energyManager.StoreEnergy("yellow", _star.s_star.i_energy); }
            else if (_eStar.s_b_blueColor) { g_global.g_energyManager.StoreEnergy("blue", _star.s_star.i_energy); }
        }

        //Spawn popups as needed
        if(b_curStarSpawnedPopupsAlready == false)
        {
            g_global.g_popupManager.CreatePopUpForStar(_star, _star.s_star.i_energy, _star.GetTemporaryVisualBool());
        }
    }

    /// <summary>
    /// This function deletes the most recent star.
    /// It gets called from no where atm
    /// -Riley
    /// </summary>
    public void DeleteTopStarCurConstellation()
    {
        //decrement the star sound
        i_starSound--;

        S_StarClass _star = ls_curConstellation[ls_curConstellation.Count()-1];

        ls_curConstellation.RemoveAt(ls_curConstellation.Count()-1);

        if (_star.starType == "Ritual")
        {
            str_curColor = "";
        }
        if (_star.starType == "Node")
        {
            if (b_makingConstellation)
            {
                //removed the node star so reset
                b_makingConstellation = false;
            }
        }

        //Make sure popups don't move
        s_b_popupMove = false;
    }

    /// <summary>
    /// This function gets called internally if a constraint gets triggered and the constellation needs resetting, 
    /// or after a constellation is finished and everything needs reset to normal.  
    /// -Riley
    /// </summary>
    public void DeleteWholeCurConstellation()
    {
        //reset the star sound
        i_starSound = 0;
        _starSoundPhase1.SetActive(false);

        //clear the constellation
        ls_curConstellation.Clear();

        //set the bool
        b_makingConstellation = false;

        //reset the color
        str_curColor = "";

        //reset the prvious star
        ChangePrevStarAndLoc(s_nullStarInst, new Vector2(0, 0));

        // Delete popup - depriciated
        //StartCoroutine(g_global.g_popupManager.ClearAllPopups());
    }

    public IEnumerator CardballSpawnCheck()
    {
        yield return new S_WaitForCardballSpawn();
        c_cardballsSpawned = true;
        SetStarLockOutBool(true);
    }

    /// <summary>
    /// This Function deals with whenever the player clicks on a node star
    /// if the player hasnt started a constellation then change drawing bool and set previous loc
    /// if the player is making a constellation then finish it, and call the finishing behaviour
    /// - Riley
    /// </summary>
    public void NodeStarClicked(S_StarClass _starN, Vector2 _locN)
    {
        if (c_cardballsSpawned == true)
        {
            if (b_makingConstellation) //if you have started a constellation
            {
                g_global.g_DrawingManager.SpawnLine(s_previousStar, _starN, v2_prevLoc, _locN);
            }
            else //if you have not started a constellation
            {
                //reset the node star previous and next lines
                _starN.s_star.m_nextLine = null;
                _starN.s_star.m_previousLine = null;

                //set the sound to active and reset the star sound
                _starSoundPhase1.SetActive(true);
                i_starSound = 0;

                g_global.g_lineMultiplierManager.ChangeLineLists();

                //add to the list
                AddStarToCurConstellation(_starN);

                //set all of the previous star stuff as the node
                ChangePrevStarAndLoc(_starN, _locN);

                //set node star's previous as null
                _starN.s_star.m_previous = s_nullStarInst;
            }
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// This is the func for non node stars and checks conditions before passing along to the spawn line function 
    /// Added functionallity for clicking on a star before a node star
    /// - Riley & Josh
    /// </summary>
    public void StarClicked(S_StarClass _star, Vector2 _loc)
    {
        if (b_makingConstellation)
        {
            if (s_previousStar != s_nullStarInst)
            {
                //Create the temp line
                g_global.g_DrawingManager.SpawnLine(s_previousStar, _star, v2_prevLoc, _loc);
            }
        }
        //print(_star.colorType);
    }


    /// <summary>
    /// This Function is the constellation finishing behavior that goes through the stars clicked on and retraces the path. 
    /// This then gets the total energy and assigns the proper energy color
    /// - Riley
    /// </summary>
    public void FinishConstellation(S_StarClass _node)
    {
        //lock out stars while calculating
        SetStarLockOutBool(false);

        //set up the energy
        int _energy = ls_curConstellation.Count() - 2;

        //check constrainst
        if (ls_curConstellation.Count()-2 < i_minSize) 
        {
            Debug.Log("Reset Constellation cuz constellation size is smaller than " + i_minSize);
            g_global.g_DrawingManager.ConstellationReset(ls_curConstellation[ls_curConstellation.Count()-1]); 
        }
        else
        {
            //do some final thing with star sound
            _starSoundPhase1.SetActive(false);
            PlaySound();

            //bools to trigger
            int _red = 0;
            int _blue = 0;
            int _yellow = 0;

            //trigger the star sound here

            //pass the _count to another function
            foreach (S_StarClass _star in ls_curConstellation.ToList())
            {

                //check the star type
                if (_star.starType == "Ritual")
                {
                    //add the line multiplier
                    _energy = g_global.g_lineMultiplierManager.LineMultiplier(_star.s_star.m_previousLine, _star.colorType);

                    //get the ritual star component
                    S_RitualStar _rStar = _star.gameObject.GetComponent<S_RitualStar>();

                    //compare in hierarchy to get the color
                    if (_rStar.s_b_redColor)
                    {
                        _red += 1;
                    }
                    else if (_rStar.s_yellowRitualStarGraphic.activeInHierarchy)
                    { 
                        _yellow += 1;
                    }
                    else if (_rStar.s_b_blueColor)
                    {
                        _blue += 1;
                    }
                }
            }
            for(int i = 0; i < _red; i++)
            {
                g_global.g_energyManager.RitualBonusEnergy("red");
            }

            for (int i = 0; i < _blue; i++)
            {
                g_global.g_energyManager.RitualBonusEnergy("blue");
            }

            for (int i = 0; i < _yellow; i++)
            {
                g_global.g_energyManager.RitualBonusEnergy("yellow");
            }

            //Print total line lenght, then reset to 0

            b_makingConstellation = false;
            Debug.Log("Making constellations NOT");

            ls_curConstellation.Clear();

            //transfer the energy
            g_global.g_energyManager.TransferStoredEnergy();

            //print out the energy at the end for debuggin purposes
            Debug.Log("Red Energy: " + g_global.g_energyManager.GetRedEnergyInt() + "  Yellow Energy: " + g_global.g_energyManager.GetYellowEnergyInt() + "  Blue Energy: " + g_global.g_energyManager.GetBlueEnergyInt());

            // Popups now move to card
            StartCoroutine(g_global.g_popupManager.TriggerPopupMove());
            
            /*foreach (S_StarClass _star in ls_curConstellation.ToList()) 
            {
                foreach (S_StarPopUp _popup in _star.ls_energyPopups.ToList())
                {
                    _star.ls_energyPopups.Remove(_popup);
                    _popup.DeletePopup();
                }
            }
            */

            

            //call the altar
            g_global.g_altar.CheckFirstCardball();
        }
    }


    /// <summary>
    /// Create a new node star where the selected star was
    /// - Riley
    /// </summary>
    /// <param name="_oldStar"></param>
    public void CreateNodeStar(GameObject _oldStar)
    {
        GameObject _newNodeStar = Instantiate(s_nodeStarPrefab, g_global.g_mapManager.activeMap.transform);
        _newNodeStar.transform.position = _oldStar.transform.position;
        Destroy(_oldStar); //this will remove it from the map 
        b_nodeStarChosen = true;
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

    public void ChangePrevStarAndLoc(S_StarClass _star, Vector2 _loc)
    {
        s_previousStar = _star;
        v2_prevLoc = _loc;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the bool value of S_ConstelationManager.b_starLockout
    /// - Josh
    /// </summary>
    /// <param name="_boolState"></param>
    public void SetStarLockOutBool(bool _boolState)
    {
        //Debug.Log("Star lockout bool is..." + _boolState.ToString());
        b_starLockout = _boolState;
    }

    /// <summary>
    /// Set the bool value of S_ConstelationManager.b_curStarSpawnedPopupsAlready
    /// - Josh
    /// </summary>
    /// <param name="_boolState"></param>
    public void SetPopupStatusForCurrentLine(bool _boolState)
    {
        b_curStarSpawnedPopupsAlready = _boolState;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Get the bool state of S_ConstelationManager.b_starLockout
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_ConstelationManager.b_starLockout
    /// </returns>
    public bool GetStarLockOutBool() 
    {
        return b_starLockout;
    }

    /// <summary>
    /// Gets the bool for making a constellation
    /// - Riley
    /// </summary>
    /// <returns>
    /// S_ConstelationManager.b_makingConstellation
    /// </returns>
    public bool GetMakingConstellation()
    {
        return b_makingConstellation;
    }

    // <summary>
    /// Get the bool state of S_ConstelationManager.b_curStarSpawnedPopupsAlready
    /// </summary>
    /// <returns>
    /// S_ConstelationManager.b_curStarSpawnedPopupsAlready
    /// </returns>
    public bool GetPopupStatusForCurrentLine()
    {
        return b_curStarSpawnedPopupsAlready;
    }
}