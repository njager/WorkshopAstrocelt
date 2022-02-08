using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ConstelationManager : MonoBehaviour
{
    private S_Global g_global;
    float f_timer = 1;

    [Header("Energy Colors")]
    public int i_redEnergy;
    public int i_yellowEnergy;
    public int i_blueEnergy;

    private void Start()
    {
        g_global = S_Global.g_instance;
    }

    /// <summary>
    /// This Function is the constellation finishing behavior that goes through the stars clicked on and retraces the path. 
    /// This then gets the total energy and assigns the proper energy color
    /// - Riley
    /// </summary>
    public IEnumerator RetraceConstelation(S_StarClass _node)
    {
        yield return new WaitForSeconds(f_timer);

        //set up some function vars
        S_StarClass _curStar = _node.s_star.m_previous;
        if (_curStar.starType !="Null")
        {
            int _count = 0;
            bool _hasColor = false;
            string _color = "";


            while (_curStar.starType != "Node")
            {
                if (_curStar.starType == "Ritual")
                {
                    if (_hasColor)
                    {
                        //trigger a retrace
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
            if (!_hasColor) { g_global.g_DrawingManager.ConstellationReset(); }

            //assining the colored energy to the count
            if (_color == "red") { i_redEnergy = _count; }
            else if (_color == "yellow") { i_yellowEnergy = _count; }
            else if (_color == "blue") { i_blueEnergy = _count; }
            print(_count);
        }
    }
}