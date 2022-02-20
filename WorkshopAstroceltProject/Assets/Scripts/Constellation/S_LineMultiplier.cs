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
    public float lowerBoundCalc;
    public float upperBoundCalc;

    // Start is called before the first frame update
    void Awake()
    {
        g_global = S_Global.Instance;
    }

    private float LineMultiplierGrabbing(List<GameObject> _lineList) // Helper function to give me a line tally to use in the calculator 
    {
        float _lineLengthTally = 0f;
        foreach (GameObject _lineRendererReference in _lineList.ToList())
        {
            S_ConstellationLine _lineScript = _lineRendererReference.GetComponent<S_ConstellationLine>();
            _lineLengthTally += _lineScript.f_lineWidth;
        }
        return _lineLengthTally;
    }

    public float LineMultiplierCalculator() // Where the line multiplier is calculated
    {
        // Initial Values
        float _lineAmount = LineMultiplierGrabbing(g_global.g_lst_lineRendererList);
        float _lineMultiplier = 1.0f;

        // Global Animation Curve values 
        AnimationCurve comparatorCurve = animationCurveForMultiplier;
        float _lowerBoundCurve = comparatorCurve[0].value;
        float _upperBoundCurve = comparatorCurve[1].value;

        float _lineValue = (_lineAmount - lowerBoundCalc) / upperBoundCalc; // Normalize the tally amount into a decimal values around 1.0 
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
}
