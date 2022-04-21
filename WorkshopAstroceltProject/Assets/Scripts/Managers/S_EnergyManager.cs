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

        //call the altar
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
            return true;
        }
        else if (_color == "yellow" && i_yellowEnergy - _energy >= 0)
        {
            i_yellowEnergy -= _energy;
            return true;
        }
        else if (_color == "blue" && i_blueEnergy - _energy >= 0)
        {
            i_blueEnergy -= _energy;
            return true;
        }
        else if(_color == "white" && i_blueEnergy + i_redEnergy + i_yellowEnergy - _energy >=0)
        {
            int _max = Mathf.Max(i_redEnergy, i_blueEnergy, i_yellowEnergy);

            if(_energy-_max <= 0)
            {
                if(i_redEnergy == _max) { i_redEnergy -= _energy; }
                else if (i_yellowEnergy == _max) { i_yellowEnergy -= _energy; }
                else if (i_blueEnergy == _max) { i_blueEnergy -= _energy; }
            }
            else 
            {
                _energy -= _max;
                int _max2 = 0;

                if (i_redEnergy == _max) { i_redEnergy = 0; _max2 = Mathf.Max(i_blueEnergy, i_yellowEnergy); }
                else if (i_yellowEnergy == _max) { i_yellowEnergy = 0; _max2 = Mathf.Max(i_blueEnergy, i_redEnergy); }
                else if (i_blueEnergy == _max) { i_blueEnergy = 0; _max2 = Mathf.Max(i_redEnergy, i_yellowEnergy); }

                if(_energy-_max2 <= 0)
                {
                    if(i_redEnergy == _max2) { i_redEnergy -= _energy; }
                    else if (i_yellowEnergy == _max2) { i_yellowEnergy -= _energy; }
                    else if (i_blueEnergy == _max2) { i_blueEnergy -= _energy; }
                }
                else
                {
                    _energy -= _max2;
                    int _max3 = 0;

                    if (i_redEnergy == _max2) { i_redEnergy = 0; }
                    else if (i_yellowEnergy == _max2) { i_yellowEnergy = 0; }
                    else if (i_blueEnergy == _max2) { i_blueEnergy = 0; }

                    if(i_redEnergy == 0 && i_yellowEnergy == 0) { i_blueEnergy -= _energy; }
                    else if (i_redEnergy == 0 && i_blueEnergy == 0) { i_yellowEnergy -= _energy; }
                    else if (i_blueEnergy == 0 && i_yellowEnergy == 0) { i_redEnergy -= _energy; }
                }
            }

            return true;
        }
        else
        {
            //card isnt playable
            return false;
        }
    }

    public void RitualBonusEnergy(string _color)
    {
        
        if (_color == "red")
        {
            Debug.Log("Bonus " + _color + " energy : old energy = " + i_redEnergy);
            i_redEnergy = (int)(i_redEnergy * 1.5);
        }
        if (_color == "blue")
        {
            Debug.Log("Bonus " + _color + " energy : old energy = " +i_blueEnergy);
            i_blueEnergy = (int)(i_blueEnergy * 1.5);
        }
        if (_color == "yellow")
        {
            Debug.Log("Bonus " + _color + " energy : old energy = " + i_yellowEnergy);
            i_yellowEnergy = (int)(i_yellowEnergy * 1.5);
        }
    }
}
