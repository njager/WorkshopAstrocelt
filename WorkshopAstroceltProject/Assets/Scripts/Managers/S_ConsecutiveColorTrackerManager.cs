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
    [SerializeField] int en_cl_i_colorTierTracker = 0;

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    ///////////////////////////// Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    /// <summary>
    /// Check if the clicked on star is a given color, if it is, increase the tier, but only to 3
    /// - Josh
    /// </summary>
    /// <param name="_energyType"></param>
    public void ColorTrackerCheck(string _energyType) 
    {
        Debug.Log("We have conecutive energy trigger: " + _energyType + " | " + GetCurrentEnergyColor());
        if (_energyType.Equals(GetCurrentEnergyColor()))
        {
            if(GetColorTierTracker() < 3) 
            {
                SetColorTierTrackerInt(GetColorTierTracker() + 1);
            }
        }
        else 
        {
            SetColorTierTrackerInt(1);
            SetCurrentEnergyColor(_energyType);
        }
    }

    /// <summary>
    /// Remove and go back to the previous energy value
    /// -Riley
    /// </summary>
    /// <param name="_energyType"></param>
    public void GoBackForColorTracker(string _energyType, int _bonusVal)
    {
        SetCurrentEnergyColor(_energyType);
        SetColorTierTrackerInt(_bonusVal);
    }

    /// <summary>
    /// Set to 0 and clear the string
    /// gets called after a constellation is finished
    /// </summary>
    /// <param name="_energyType"></param>
    public void ResetColorTracker()
    {
        SetCurrentEnergyColor("");
        SetColorTierTrackerInt(0);
        
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

    /// <summary>
    /// Set the int value of S_ConsecutiveColorTrackerManager.en_cl_i_colorTierTracker
    /// - Josh 
    /// </summary>
    /// <param name="_currentTier"></param>
    public void SetColorTierTrackerInt(int _currentTier)
    {
        en_cl_i_colorTierTracker = _currentTier;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Get the int value of S_ConsecutiveColorTrackerManager.en_cl_str_currentColorType
    /// </summary>
    /// <returns>
    /// S_ConsecutiveColorTrackerManager.en_cl_str_currentColorType
    /// </returns>
    public string GetCurrentEnergyColor()
    {
        return en_cl_str_currentColorType;
    }

    /// <summary>
    /// Get the int value of S_ConsecutiveColorTrackerManager.en_cl_i_colorTierTracker
    /// </summary>
    /// <returns>
    /// S_ConsecutiveColorTrackerManager.en_cl_i_colorTierTracker
    /// </returns>
    public int GetColorTierTracker()
    {
        return en_cl_i_colorTierTracker;
    }

}
