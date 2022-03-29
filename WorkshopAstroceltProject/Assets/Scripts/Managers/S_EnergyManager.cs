using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnergyManager : MonoBehaviour
{
    private S_Global g_global;

    [Header("Energy Colors")]
    public string str_energyColor;
    public float i_energyCount;

    public int i_redEnergy;
    public int i_yellowEnergy;
    public int i_blueEnergy;

    private void Awake()
    {
        g_global = S_Global.Instance;
        i_energyCount = 0;
    }

    /// <summary>
    /// This function gets called in constellation manager to set the energy
    /// </summary>
    /// <param name="_color"></param>
    /// <param name="_energy"></param>
    public void SetEnergy(string _color, int _energy)
    {
        if (_color == "red")
        {
            i_redEnergy += _energy;
        }
        else if (_color == "yellow")
        {
            i_yellowEnergy += _energy;
        }
        else if (_color == "blue")
        {
            i_blueEnergy += _energy;
        }
    }

    /// <summary>
    /// This Function gets rid of the stored energy in the constellation manager
    /// Gets cleared from turnManager and drawingManager
    /// - Riley
    /// </summary>
    public void ClearEnergy()
    {
        str_energyColor = "";
        i_energyCount = 0;

        g_global.g_ConstellationManager.i_starSound = 0;
        g_global.g_lineMultiplierManager.ClearLineList();
        g_global.g_ConstellationManager.b_starLockout = true;
    }

    /// <summary>
    /// Change the energy amount after the player uses a card
    /// gets called from the card script
    /// -Riley
    /// </summary>
    /// <param name="_energy"></param>
    /// <param name="_color"></param>
    public bool useEnergy(int _energy, string _color)
    {
        //make sure the colors match before using energy
        //remove the card if it actually gets played
        if (_color == "red" && i_redEnergy - _energy >= 0) 
        {
            i_redEnergy -= _energy;
            g_global.g_cardManager.RemoveCard();
            return true;
        }
        else if (_color == "yellow" && i_yellowEnergy - _energy >= 0)
        {
            i_yellowEnergy -= _energy;
            g_global.g_cardManager.RemoveCard();
            return true;
        }
        else if (_color == "blue" && i_blueEnergy - _energy >= 0)
        {
            i_blueEnergy -= _energy;
            g_global.g_cardManager.RemoveCard();
            return true;
        }
        else if(_color == "white" && i_blueEnergy + i_redEnergy + i_yellowEnergy - _energy >=0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
