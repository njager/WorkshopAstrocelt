using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq; 

public class S_ConstelationManager : MonoBehaviour
{
    //global script
    private S_Global g_global;

    //the list of the current constellation
    public List<S_StarClass> ls_curConstellation;

    //this is the color for the cur constellation
    public string str_curColor = "";

    //bool to tell if you are making a constellation atm
    public bool b_makingConstellation;

    //bool for locking out drawing
    public bool b_starLockout;

    //previous star and previous loc
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


    public GameObject _starSoundPhase1;
    public GameObject _starSoundPhase2;

    public int i_starSound = 0;

    private void Awake()
    {
        //fetch global, get set previous as null, and start with star lockout
        g_global = S_Global.Instance;
        s_previousStar = s_nullStarInst;
        b_starLockout = true;
    }

    /// <summary>
    /// This func gets called from the lines themseleves after they get spawned. 
    /// Adds the star to the data structure and checks types and constraints
    /// -Riley
    /// </summary>
    /// <param name="_star"></param>
    public void AddStarToCurConstellation(S_StarClass _star)
    {
        //change the star sound here if the line is formed
        i_starSound++;

        //Victor's sound
        var emitter = _starSoundPhase1.GetComponent<FMODUnity.StudioEventEmitter>();
        emitter.SetParameter("Note Order", i_starSound);

        //add to data structure
        ls_curConstellation.Add(_star);

        //check the type of the star added
        if (_star.starType == "Ritual")
        {
            //go back once if it is another ritual star
            if (str_curColor != "") { g_global.g_DrawingManager.GoBackOnce(ls_curConstellation[ls_curConstellation.Count()-1].s_star.m_previousLine.gameObject); }

            //get the ritual star component
            S_RitualStar _rStar = _star.gameObject.GetComponent<S_RitualStar>();

            //compare in hierarchy to get the color
            if (_rStar.s_redRitualStarGraphic.activeInHierarchy)
            {
                str_curColor = "red";
            }
            else if (_rStar.s_yellowRitualStarGraphic.activeInHierarchy)
            {
                str_curColor = "yellow";
            }
            else if (_rStar.s_blueRitualStarGraphic.activeInHierarchy)
            {
                str_curColor = "blue";
            }
        }
        if (_star.starType == "Node")
        {
            if (b_makingConstellation)
            {
                //finsih making the constellation
                FinishConstellation(_star);
            }
            else
            {
                //now that the node is added, change the bool
                b_makingConstellation = true;
            }
        }
        //check if the lenght is greater than the max length, sub 1 for the two node stars
        else if (ls_curConstellation.Count() - 2 >= i_maxSize)
        {
            //delete the constellation with the top star
            g_global.g_DrawingManager.ConstellationReset(ls_curConstellation[ls_curConstellation.Count()-1]);
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
                //finsih making the constellation
                b_makingConstellation = false;

                FinishConstellation(_star);
            }
            else
            {
                //now that the node is added, change the bool
                b_makingConstellation = false;
            }
        }
    }

    /// <summary>
    /// This function gets called internally if a constraint gets triggered and the constellation needs resetting, 
    /// or after a constellation is finished and everything needs reset to normal.  
    /// </summary>
    public void DeleteWholeCurConstellation()
    {
        //clear the constellation
        ls_curConstellation.Clear();

        //set the bool
        b_makingConstellation = false;

        //reset the color
        str_curColor = "";

        //reset the prvious star
        s_previousStar = s_nullStarInst;
        v2_prevLoc = new Vector2(0,0);
}

    /// <summary>
    /// This Function deals with whenever the player clicks on a node star
    /// if the player hasnt started a constellation then change drawing bool and set previous loc
    /// if the player is making a constellation then finish it, and call the finishing behaviour
    /// - Riley
    /// </summary>
    public void NodeStarClicked(S_StarClass _starN, Vector2 _locN)
    {
        if (b_makingConstellation) //if you have started a constellation
        {
            //do some final thing with star sound
            _starSoundPhase1.SetActive(false);
            PlaySound();
            
            g_global.g_DrawingManager.SpawnLine(s_previousStar, _starN, v2_prevLoc, _locN);
        }
        else //if you have not started a constellation
        {
            //i_starSound = 0;

            //add to the list
            AddStarToCurConstellation(_starN);

            //set all of the previous star stuff as the node
            s_previousStar = _starN;
            v2_prevLoc = _locN;

            //set node star's previous as null
            _starN.s_star.m_previous = s_nullStarInst;
        }
    }

    /// <summary>
    /// This is the func for non node stars and checks conditions before passing along to the spawn line function 
    /// Added functionallity for clicking on a star before a node star
    /// - Riley
    /// </summary>
    public void StarClicked(S_StarClass _star, Vector2 _loc)
    {
        if (b_makingConstellation)
        {
            if (s_previousStar != s_nullStarInst)
            {
                g_global.g_DrawingManager.SpawnLine(s_previousStar, _star, v2_prevLoc, _loc);
            }
        }
    }


    /// <summary>
    /// This Function is the constellation finishing behavior that goes through the stars clicked on and retraces the path. 
    /// This then gets the total energy and assigns the proper energy color
    /// - Riley
    /// </summary>
    public void FinishConstellation(S_StarClass _node)
    {
        //reset the audio
        i_starSound = 0;

        //lock out stars while calculating
        b_starLockout = false;

        g_global.g_UIManager.p_f_lineMultiplierAmount = Mathf.Round(g_global.g_lineMultiplierManager.LineMultiplierCalculator() * 10f) / 10f;
        //g_global.g_UIManager.p_tx_lineMultiplierText.text = "Line Multiplier: " + g_global.g_UIManager.p_f_lineMultiplierAmount + "x";

        //set up the energy
        int _energy = ls_curConstellation.Count() - 2;

        //check constrainst
        if (str_curColor == "") { g_global.g_DrawingManager.ConstellationReset(ls_curConstellation[ls_curConstellation.Count()-1]); }
        else if (ls_curConstellation.Count()-2 < i_minSize) { g_global.g_DrawingManager.ConstellationReset(ls_curConstellation[ls_curConstellation.Count()-1]); }
        else
        {
            //trigger the star sound here

            //add the line multiplier
            //_energy = (int)Mathf.Round(_energy * g_global.g_UIManager.p_f_lineMultiplierAmount);

            //pass the _count to another function
            g_global.g_energyManager.SetEnergy(str_curColor, _energy);
        }

        b_starLockout = true;
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
}