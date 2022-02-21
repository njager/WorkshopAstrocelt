using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq; 

public class S_ConstelationManager : MonoBehaviour
{
    private S_Global g_global;
    float f_timer = 1f;

    [Header("Constellation Sizes")]
    public int i_minSize;
    public int i_maxSize;

    [Header("Energy Colors")]
    public int i_redEnergy;
    public int i_yellowEnergy;
    public int i_blueEnergy;

    [Header("Energy Count")]
    public int i_energyCount;
    public bool energyWasCleared; 

    public bool enumerateTemp; 

    private void Awake()
    {
        g_global = S_Global.Instance;
        energyWasCleared = true;
    }

    /// <summary>
    /// This Function is the constellation finishing behavior that goes through the stars clicked on and retraces the path. 
    /// This then gets the total energy and assigns the proper energy color
    /// - Riley
    /// </summary>
    public IEnumerator RetraceConstelation(S_StarClass _node)
    {
        //wait so if a line deletes itself were safe
        yield return new WaitForSeconds(f_timer);
        energyWasCleared = false;

        //set up some function vars
        S_StarClass _curStar = _node.s_star.m_previous;
        if (_curStar.starType != "Null")
        {
            int _count = 0;
            bool _hasColor = false;
            string _color = "";

            //loop through 
            while (_curStar.starType != "Node")
            {
                if (_curStar.starType == "Ritual")
                {
                    if (_hasColor)
                    {
                        g_global.g_DrawingManager.ConstellationReset();
                        break;
                    }
                    else
                    {
                        //change the color bool to true and increment count
                        _hasColor = true;
                        _count++;
                        S_RitualStar _rStar = _curStar.gameObject.GetComponent<S_RitualStar>();

                        //compare in hierarchy to get the color
                        if (_rStar.s_redRitualStarGraphic.activeInHierarchy)
                        {
                            _color = "red";
                        }
                        else if (_rStar.s_yellowRitualStarGraphic.activeInHierarchy)
                        {
                            _color = "yellow";
                        }
                        else if (_rStar.s_blueRitualStarGraphic.activeInHierarchy)
                        {
                            _color = "blue";
                        }

                        _curStar = _curStar.s_star.m_previous;
                    }
                }
                else
                {
                    _count++;
                    _curStar = _curStar.s_star.m_previous;
                }
            }
            //delete the constellation if it has no ritual star or is too small
            if (!_hasColor) { g_global.g_DrawingManager.ConstellationReset(); }
            else if(_count < i_minSize) { g_global.g_DrawingManager.ConstellationReset(); }
            else if (_count > i_maxSize) { g_global.g_DrawingManager.ConstellationReset(); }
            else
            {
                //trigger the star sound here

                //assining the colored energy to the count
                if (_color == "red") { i_redEnergy = _count; }
                else if (_color == "yellow") { i_yellowEnergy = _count; }
                else if (_color == "blue") { i_blueEnergy = _count; }
                print(_count);

                //pass the _count to another function
                i_energyCount = _count;
            }
        }
    }

    public IEnumerator LineDeletion()
    {
        foreach (GameObject lineObject in g_global.g_lst_lineRendererList.ToList())
        {
            g_global.g_lst_lineRendererList.Remove(lineObject);
            Destroy(lineObject);
            //this is bugging out when turn changes
        }
        enumerateTemp = true; 
        yield return enumerateTemp = true; 
    }

    public void ClearEnergy()
    {
        i_energyCount = 0;
        g_global.g_DrawingManager.i_starSound = 0;
        energyWasCleared = true;
    }
}