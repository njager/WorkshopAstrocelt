using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BackgroundManager : MonoBehaviour
{
    //global script
    private S_Global g_global;

    [Header("Environment Assets")]
    public Sprite a_backgroundNight;
    public Sprite a_backgroundDay;
    public Sprite a_hillsNight;
    public Sprite a_hillsDay;

    [Header("Environment References")]
    public SpriteRenderer a_backgroundImage;
    public SpriteRenderer a_hillsImage;

    void Awake()
    {
        g_global = S_Global.Instance;
    }

    /// <summary>
    /// Background helper function to change the environment assets
    /// Enter 0 for Night, 1 for Day
    /// - Josh
    /// </summary>
    /// <param name="_environmentValue"></param>
    public void ChangeBackground(int _environmentValue)
    {
        if (_environmentValue == 0) // Change to Night
        {
            // Change sprites
            a_backgroundImage.sprite = a_backgroundNight; // Eventually make these DOTweens
            a_hillsImage.sprite = a_hillsNight;
        }
        else if (_environmentValue == 1) // Change to Day
        {
            // Change sprites
            a_backgroundImage.sprite = a_backgroundDay;
            a_hillsImage.sprite = a_hillsDay;

            // Toggle maps
            g_global.g_mapManager.map1.SetActive(false);
            g_global.g_mapManager.map2.SetActive(false);
            g_global.g_mapManager.map3.SetActive(false);
            g_global.g_mapManager.map4.SetActive(false);
            g_global.g_mapManager.map5.SetActive(false);
            g_global.g_mapManager.map6.SetActive(false);
            g_global.g_mapManager.map7.SetActive(false);
            g_global.g_mapManager.map8.SetActive(false);
            g_global.g_mapManager.map9.SetActive(false);
            g_global.g_mapManager.map10.SetActive(false);
            g_global.g_mapManager.map11.SetActive(false);
            g_global.g_mapManager.map12.SetActive(false);
            g_global.g_mapManager.map13.SetActive(false);
        }
    }

    /// <summary>
    /// Turn off maps
    /// </summary>
    public void TurnOffMaps() 
    {
        // Toggle maps
        g_global.g_mapManager.map1.SetActive(false);
        g_global.g_mapManager.map2.SetActive(false);
        g_global.g_mapManager.map3.SetActive(false);
        g_global.g_mapManager.map4.SetActive(false);
        g_global.g_mapManager.map5.SetActive(false);
        g_global.g_mapManager.map6.SetActive(false);
        g_global.g_mapManager.map7.SetActive(false);
        g_global.g_mapManager.map8.SetActive(false);
        g_global.g_mapManager.map9.SetActive(false);
        g_global.g_mapManager.map10.SetActive(false);
        g_global.g_mapManager.map11.SetActive(false);
        g_global.g_mapManager.map12.SetActive(false);
        g_global.g_mapManager.map13.SetActive(false);
    }
}
