using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class S_LineMultiplierManager : MonoBehaviour
{
    private S_Global g_global;

    [Header("Line Multiplier Breakpoint Values")]
    public float f_mediumLength;
    public float f_largeLength;

    [Header("Animation Curve")]
    public AnimationCurve animationCurveForMultiplier;

    [Header("Designer Values")]
    public float lowerBoundForCalculation;
    public float upperBoundForCalculation;

    [Header("Line Lengths")]
    public List<float> lst_lineLengthList; // don't need a list of lines just values

    [Header("Debug Elements")]
    public float debugLineValue;

    public float f_totalLineLength;

    // Start is called before the first frame update
    void Awake()
    {
        g_global = S_Global.Instance;
    }


    /// <summary>
    /// Clears the list of lines. Used when changing the map
    /// </summary>
    public void ClearLineList()
    {
        foreach (GameObject _line in g_global.g_ls_lineRendererList.ToList())
        {
            g_global.g_ls_lineRendererList.Remove(_line);
            Destroy(_line);
        }
        f_totalLineLength = 0;
    }


    /// <summary>
    /// Updated for new line multiplier function, clears line list, and resets total tally for line tier system
    /// - Josh
    /// </summary>
    public void ChangeLineLists()
    {
        //only run if there are lines in the list
        if(g_global.g_ls_lineRendererList.Count() > 0)
        {
            //loop through all the lines in the line list
            foreach (GameObject _line in g_global.g_ls_lineRendererList.ToList())
            {
                S_ConstellationLine _lineScript = _line.GetComponent<S_ConstellationLine>();
                _lineScript.TriggerLineTransfer();
            }
        }
        f_totalLineLength = 0;
    }

    /// <summary>
    /// Seems to compute one line at a time and add them to a tally outside the function - Josh
    /// Made by -Riley
    /// </summary>
    /// <param name="_line"></param>
    public int LineMultiplier(GameObject _line)
    {
        //get the magnitude of the line
        var length = _line.GetComponent<S_ConstellationLine>().f_lineLength;

        //add to total line length
        f_totalLineLength += length;

        //Debug.Log("Line with this index: " + _line.GetComponent<S_ConstellationLine>().i_index + " provides this length: " + length);

        if(f_totalLineLength > f_largeLength) { return 3; }
        else if (f_totalLineLength > f_mediumLength) { return 2; }
        else { return 1; }
    }
}
