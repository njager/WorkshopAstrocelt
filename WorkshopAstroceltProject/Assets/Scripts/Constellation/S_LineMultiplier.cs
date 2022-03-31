using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class S_LineMultiplier : MonoBehaviour
{
    private S_Global g_global; 

    [Header("Animation Curve")]
    public AnimationCurve animationCurveForMultiplier;

    [Header("Designer Values")]
    public float lowerBoundForCalculation;
    public float upperBoundForCalculation;

    [Header("Line Lengths")]
    public List<float> lst_lineLengthList; // don't need a list of lines just values

    [Header("Debug Elements")]
    public float debugLineValue;

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

    public void ClearLineList()
    {
        foreach(float _lineLength in lst_lineLengthList.ToList())
        {
            lst_lineLengthList.Remove(_lineLength);
        }
    }

    /// <summary>
    /// 
    /// -Riley
    /// </summary>
    /// <param name="_line"></param>
    public void LineMultiplier(GameObject _line)
    {

    }
}
