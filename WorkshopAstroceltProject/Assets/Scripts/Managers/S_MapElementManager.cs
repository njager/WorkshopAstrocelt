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
    [SerializeField] List<(List<(Transform, int mp_i_masterListObjectID)>, int mp_i_mapMasterListIndex)> mp_ls_masterMapList = new List<(List<(Transform, int)>, int)>();

    [Header("Current Map Index")]
    [SerializeField] int mp_i_currentMapID;

    [Header("Previous Map Index")]
    [SerializeField] int mp_i_previousMapID;


    [Header("Energy Star Prefab")]
    [SerializeField] GameObject s_energyStarPrefab; // Keeping for abilites that would add a star

    // Throw out empty objects in the generation system that allow us to have a list of valid locations to add stars to? - Thoughts for post integretation

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    private void Start()
    {
        mp_activeMap = g_global.g_newMapManager.activeMap;
        GenerateDynamicMapList();
    }


    /// <summary>
    /// Run the map generation list function to dynamically make maps
    /// - Josh
    /// </summary>
    private void GenerateDynamicMapList() // Do this every round with turn manager (place after Thoman figures out his logic calls)
    {

    }

    /// <summary>
    /// Helper function to get parent function to reparent newly added stars
    /// - Josh
    /// </summary>
    /// <param name="_objectIndex"></param>
    /// <returns></returns>
    public Transform GetTransformFromObjectID(int _objectIndex)
    {
        Transform _transformToReturn = null;
        foreach((List<Transform>, int))
        foreach ((Transform, int) _currentMapInstance in mp_ls_masterMapList.ToList())
        {
            if(_currentMapInstance.Item2 == _objectIndex) 
            {
                _transformToReturn = _currentMapInstance.Item1;
            }
        }

        return _transformToReturn;
    }

    /// <summary>
    /// Helper function to get map list
    /// - Josh 
    /// </summary>
    /// <param name="_objectIndex"></param>
    /// <returns></returns>
    public List<S_StarClass> GetMapListObjectID(int _objectIndex)
    {
        return null;
    }

    public void AddStarToMapPreRun() 
    {

    }

    public void AddStarToMapPostRun() // Pops a star into existence at a viable spot
    {

    }

    public void RemoveStarFromMapPreRun() 
    {

    }
}
