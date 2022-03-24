using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnergyManager : MonoBehaviour
{
    private S_Global g_global;

    [Header("Energy Colors")]
    public string str_energyColor;
    public float i_energyCount;



    private void Awake()
    {
        g_global = S_Global.Instance;
        i_energyCount = 0;
    }

    public void SetEnergy(string _color, int _energy)
    {
        str_energyColor = _color;
        i_energyCount = _energy + 10;

        g_global.g_UIManager.ChangeEnergyIcon(str_energyColor);
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

        g_global.g_DrawingManager.i_starSound = 0;
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
    public bool useEnergy(float _energy, string _color)
    {
        //make sure the colors match before using energy
        if (_color == str_energyColor || _color == "white") 
        { 
            i_energyCount -= _energy;
            return true;
        }
        else
        {
            return false;
            Debug.Log("Wrong color Bitch");
        }
    }
}
