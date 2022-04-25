using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class S_LineMultiplier : MonoBehaviour
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
    /// This is added here so I can see the average line length
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(lst_lineLengthList.Count > 0)
            {
                debugLineValue = LineMultiplierGrabbing(lst_lineLengthList);
            }
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            debugLineValue = 0f;
        }
    }

    private float LineMultiplierGrabbing(List<float> _lineList) // Helper function to give me a line tally to use in the calculator 
    {
        float _lineLengthTally = 0f;
        foreach (float _lineRendererLength in _lineList.ToList())
        {
            _lineLengthTally += _lineRendererLength;
        }
        return _lineLengthTally;
    }

    public float LineMultiplierCalculator() // Where the line multiplier is calculated
    {
        // Initial Values
        float _lineAmount = LineMultiplierGrabbing(lst_lineLengthList);
        float _lineMultiplier = 1.0f; // Default value to return

        // Global Animation Curve values 
        AnimationCurve comparatorCurve = animationCurveForMultiplier;
        float _lowerBoundCurve = comparatorCurve[0].value;
        float _upperBoundCurve = comparatorCurve[1].value;

        float _lineValue = (_lineAmount - lowerBoundForCalculation) / upperBoundForCalculation; // Normalize the tally amount into a decimal values around 1.0 
        //Debug.Log(_lineValue); 

        // Compare the normalized value to the curve values 
        if (_lineValue >= _lowerBoundCurve)
        {
            if (_lineValue <= _upperBoundCurve)
            {
                _lineMultiplier = comparatorCurve.Evaluate(_lineValue);
                //Debug.Log(lineMultiplier);
                return _lineMultiplier;
            }
            else
            {
                _lineMultiplier = comparatorCurve.Evaluate(_lineValue);
                //Debug.Log(lineMultiplier);
                return _lineMultiplier;
            }
        }
        else // If it fails the conditions, it returns a 1.0 mutliplier 
        {
            //Debug.Log(lineMultiplier);
            return _lineMultiplier = comparatorCurve.Evaluate(_lineValue);
        }
    }

    /// <summary>
    /// Updated for new line multiplier function, clears line list, and resets total tally for line tier system
    /// - Josh
    /// </summary>
    public void ClearLineList()
    {
        foreach(GameObject _line in g_global.g_ls_lineRendererList.ToList())
        {
            g_global.g_ls_lineRendererList.Remove(_line);
            Destroy(_line);
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

        Debug.Log("Line with this index: " + _line.GetComponent<S_ConstellationLine>().i_index + " provides this length: " + length);

        if(f_totalLineLength > f_largeLength) { print("Large Line Bonus"); return 3; }
        else if (f_totalLineLength > f_mediumLength) { print("med Line Bonus"); return 2; }
        else { print("No Line Bonus"); return 1; }
    }
}
