using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class S_MapElementManager : MonoBehaviour
{
    //Private variables
    private S_Global g_global;

    [Header("Map Object")]
    [SerializeField] GameObject mp_activeMap;

    [Header("Master Map List")]
    [SerializeField] List<(List<GameObject>, int mp_i_masterListID)> mp_ls_masterMapList = new List<(List<GameObject>, int)>();

    [Header("Current Map Index")]
    [SerializeField] int mp_i_currentMapID;

    [Header("Previous Map Index")]
    [SerializeField] int mp_i_previousMapID;

    [Header("Energy Star Prefab")]
    [SerializeField] GameObject s_energyStarPrefab;


    [Header("Map 1 Star List")]
    public List<S_StarClass> ls_s_map1Stars = new List<S_StarClass>();

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    private void Start()
    {
        // Create the map list
        GenerateDynamicMapList();
    }


    /// <summary>
    /// Run the map generation list function to dynamically make maps
    /// - Josh
    /// </summary>
    private void GenerateDynamicMapList()
    {

    }

    /// <summary>
    /// Helper function to get parent function to reparent newly added stars
    /// - Josh
    /// </summary>
    /// <param name="_mapNum"></param>
    /// <returns></returns>
    public Transform GetTransformFromMapID(int _mapIndex)
    {
        return null;
    }

    /// <summary>
    /// Helper function to get map list
    /// </summary>
    /// <param name="_mapNum"></param>
    /// <returns></returns>
    public List<S_StarClass> GetMapListFromID(int _mapIndex)
    {
        return null;
    }
}
