using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ConsecutiveColorTrackerManager : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    private S_Global g_global;

    [Header("Bonus Energy Tracker Variables")]
    [SerializeField] string en_cl_str_currentColorType;
    [SerializeField] int en_cl_i_colorTierTracker;

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    ///////////////////////////// Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    public void ColorTrack(string _energyType) 
    {
        if(_energyType).Equals()
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the string content of S_ConsecutiveColorTrackerManager.en_cl_str_currentColorType
    /// - Josh 
    /// </summary>
    /// <param name="_energyValue"></param>
    public void SetCurrentEnergyColor(string _energyType)
    {
        en_cl_str_currentColorType = _energyType;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Get the string content of S_ConsecutiveColorTrackerManager.en_cl_str_currentColorType
    /// </summary>
    /// <returns>
    /// S_ConsecutiveColorTrackerManager.en_cl_str_currentColorType
    /// </returns>
    public string GetCurrentEnergyColor()
    {
        return en_cl_str_currentColorType;
    }



}
