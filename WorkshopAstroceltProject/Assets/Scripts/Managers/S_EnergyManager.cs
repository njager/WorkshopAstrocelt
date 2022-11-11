using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnergyManager : MonoBehaviour
{
    private S_Global g_global;

    [Header("Energy Colors")]
    public string str_energyColor;
    public float i_energyCount;

    [SerializeField] int i_redEnergy;
    [SerializeField] int i_yellowEnergy;
    [SerializeField] int i_blueEnergy;

    public int i_redStorageEnergy;
    public int i_yellowStorageEnergy;
    public int i_blueStorageEnergy;



    private void Awake()
    {
        g_global = S_Global.Instance;
        i_energyCount = 0;
    }

    /// <summary>
    /// This function gets called in constellation manager
    /// Stores the energy to wait for the constellation to be finished
    /// </summary>
    /// <param name="_color"></param>
    /// <param name="_energy"></param>
    public void StoreEnergy(string _color, int _energy)
    {
        //Debug.Log("Energy Stored");
        if (_color == "red")
        {
            i_redStorageEnergy += _energy;
        }
        else if (_color == "yellow")
        {
            i_yellowStorageEnergy += _energy;
        }
        else if (_color == "blue")
        {
            i_blueStorageEnergy += _energy;
        }
    }


    /// <summary>
    /// Set all the stored energy to 0
    /// -Riley
    /// </summary>
    public void ClearStoredEnergy()
    {
        //Debug.Log("Stored Energy Cleared");
        i_redStorageEnergy = 0;
        i_yellowStorageEnergy = 0;
        i_blueStorageEnergy = 0;
    }

    /// <summary>
    /// Transfer all the stored energy into real energy and then clear all the stored energy
    /// -Riley
    /// </summary>
    public void TransferStoredEnergy()
    {
        //Debug.Log("Stored energy transfered");
        i_redEnergy += i_redStorageEnergy;
        i_yellowEnergy += i_yellowStorageEnergy;
        i_blueEnergy += i_blueStorageEnergy;

        ClearStoredEnergy();
    }

    /// <summary>
    /// This Function resets all the energy in the scene
    /// Gets cleared from turnManager and drawingManager
    /// - Riley
    /// </summary>
    public void ClearEnergy()
    {
        //Debug.Log("Energy Cleared!");
        str_energyColor = "";
        i_energyCount = 0;

        i_redEnergy = 0;
        i_yellowEnergy = 0;
        i_blueEnergy = 0;

        g_global.g_ConstellationManager.i_starSound = 0;
    }

    /// <summary>
    /// Change the energy amount after the player uses a card
    /// gets called from the card script
    /// -Riley
    /// </summary>
    /// <param name="_energy"></param>
    /// <param name="_color"></param>
    public bool UseEnergy(int _energy, string _color)
    {
        //make sure the colors match before using energy
        //remove the card if it actually gets played
        //Debug.Log("Energy for card of " + _color + ": " + _energy.ToString());
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

                    if (i_redEnergy == _max2) { i_redEnergy = 0; }
                    else if (i_yellowEnergy == _max2) { i_yellowEnergy = 0; }
                    else if (i_blueEnergy == _max2) { i_blueEnergy = 0; }

                    if(i_redEnergy == 0 && i_yellowEnergy == 0) { i_blueEnergy -= _energy; }
                    else if (i_redEnergy == 0 && i_blueEnergy == 0) { i_yellowEnergy -= _energy; }
                    else if (i_blueEnergy == 0 && i_yellowEnergy == 0) { i_redEnergy -= _energy; }
                }
            }

            //the card is playable and the energy has already been used
            return true;
        }
        else
        {
            //card isnt playable
            return false;
        }
    }

    /// <summary>
    /// Give a 1.5 times bonus to the stored energy of a given color
    /// Gets called in finishconstellation in constellation manager
    /// -Riley
    /// </summary>
    /// <param name="_color"></param>
    public void RitualBonusEnergy(string _color)
    {
        
        if (_color == "red")
        {
            //Debug.Log("Bonus " + _color + " energy : old energy = " + i_redStorageEnergy);
            i_redStorageEnergy = (int)(i_redStorageEnergy * 1.5);
        }
        if (_color == "blue")
        {
            //Debug.Log("Bonus " + _color + " energy : old energy = " + i_blueStorageEnergy);
            i_blueStorageEnergy = (int)(i_blueStorageEnergy * 1.5);
        }
        if (_color == "yellow")
        {
            //Debug.Log("Bonus " + _color + " energy : old energy = " + i_yellowStorageEnergy);
            i_yellowStorageEnergy = (int)(i_yellowStorageEnergy * 1.5);
        }
    }

    /// <summary>
    /// Method to check energy without using it
    /// - Josh
    /// </summary>
    /// <param name="_energy"></param>
    /// <param name="_color"></param>
    /// <returns></returns>
    public bool CheckEnergy(int _energy, string _color)

    {
        //Debug.Log("Energy Check for card of " + _color + ": " + _energy.ToString());
        //make sure the colors match before using energy
        //remove the card if it actually gets played
        if (_color == "red" && i_redEnergy - _energy >= 0)
        {
            return true;
        }
        else if (_color == "yellow" && i_yellowEnergy - _energy >= 0)
        {
            return true;
        }
        else if (_color == "blue" && i_blueEnergy - _energy >= 0)
        {
            return true;
        }
        else if (_color == "white" && i_blueEnergy + i_redEnergy + i_yellowEnergy - _energy >= 0)
        {
            return true;
        }
        else
        {
            //card isnt playable
            return false;
        }
    }


    /////////////////////////////--------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the int value of S_EnergyManager.i_redEnergy; 
    /// - Josh
    /// </summary>
    /// <param name="_energyCount"></param>
    public void SetRedEnergyInt(int _energyCount)
    {
        i_redEnergy = _energyCount;
    }

    /// <summary>
    /// Set the int value of S_EnergyManager.i_blueEnergy
    /// - Josh
    /// </summary>
    /// <param name="_energyCoun"></param>
    public void SetBlueEnergyInt(int _energyCount)
    {
        i_blueEnergy = _energyCount;
    }

    /// <summary>
    /// Set the int value of S_EnergyManager.i_yellowEnergy
    /// - Josh
    /// </summary>
    /// <param name="_energyCoun"></param>
    public void SetYellowEnergyInt(int _energyCount)
    {
        i_yellowEnergy = _energyCount;
    }


    /////////////////////////////--------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the int value of S_EnergyManager.i_redEnergy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnergyManager.i_redEnergy
    /// </returns>
    public int GetRedEnergyInt()
    {
        return i_redEnergy;
    }

    /// <summary>
    /// Return the int value of S_EnergyManager.i_blueEnergy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnergyManager.i_blueEnergy
    /// </returns>
    public int GetBlueEnergyInt()
    {
        return i_blueEnergy;
    }

    /// <summary>
    /// Return the int value of S_EnergyManager.i_yellowEnergy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnergyManager.i_yellowEnergy
    /// </returns>
    public int GetYellowEnergyInt()
    {
        return i_yellowEnergy;
    }
}
