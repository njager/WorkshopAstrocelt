using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MapGeneration : MonoBehaviour
{
    //Private variables
    private S_Global global;

    [Header("Temporary Booleans")]
    public bool map_b_map1Used;
    public bool map_b_map2Used;
    public bool map_b_map3Used;

    [Header("Map References")]
    public GameObject map1;
    public GameObject map2;
    public GameObject map3; 

    //Think of adding map_ as a designator
    //Will grab chunks here
    private void Awake()
    {
        global = S_Global.Instance; 
    }

    public void NewMapGeneration()
    {
        
    }



    ////Temporary\\\\

    //Designer Map1
    public void Map1()
    {
        //Toggle Booleans
        map_b_map1Used = true;
        map_b_map2Used = false;
        map_b_map3Used = false;
    }

    //Designer Map2
    public void Map2()
    {
        //Toggle Booleans
        map_b_map1Used = false;
        map_b_map2Used = true;
        map_b_map3Used = false;
    }

    //Designer Map3
    public void Map3()
    {
        //Toggle Booleans
        map_b_map1Used = false;
        map_b_map2Used = false;
        map_b_map3Used = true;
    }
}
