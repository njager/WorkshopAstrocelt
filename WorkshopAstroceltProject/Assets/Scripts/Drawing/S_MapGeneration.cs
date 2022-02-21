using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MapGeneration : MonoBehaviour
{
    //Private variables
    private S_Global global;

    public S_NodeStar nodeStar; 

    [Header("Temporary grid")]
    public GameObject blackBar1;
    public GameObject blackBar2;
    public GameObject blackBar3;
    public GameObject blackBar4;
    public GameObject blackBar5;
    public GameObject blackBar6;

    [Header("Temporary Booleans")]
    public bool map_b_map1Used;
    public bool map_b_map2Used;
    public bool map_b_map3Used;
    public bool map_b_map4Used;
    public bool map_b_map5Used;

    [Header("Map References")]
    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    public GameObject map4;
    public GameObject map5;

    //Thinking of adding mp_ as a designator for maps
    //Will grab chunks here
    private void Awake()
    {
        global = S_Global.Instance;

        //Temporary calls for current map structure
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        Map1(); 
    }

    private void Start()
    {
        //Temporary Grid, shouldn't be needed for chunks
        blackBar1.SetActive(false);
        blackBar2.SetActive(false);
        blackBar3.SetActive(false);
        blackBar4.SetActive(false);
        blackBar5.SetActive(false);
        blackBar6.SetActive(false);
    }

    /// <summary>
    /// Not to be used yet, milestone 2
    /// - Josh
    /// </summary>
    public void NewMapGeneration()
    {
        
    }

    ////Temporary Map Toggling and Placements\\\\

    //Designer Map 1
    public void Map1()
    {
        //Move nodestar
        Vector3 newNodeStarPosition = new Vector3(-0.39f, 0.07f, 0f);
        nodeStar.gameObject.transform.position = newNodeStarPosition;

        //Toggle maps
        map1.SetActive(true);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);

        //Toggle Booleans
        map_b_map1Used = true;
        map_b_map2Used = false;
        map_b_map3Used = true;
        map_b_map4Used = true;
        map_b_map5Used = true;
    }

    //Designer Map 2
    public void Map2()
    {
        //Move nodestar
        Vector3 newNodeStarPosition = new Vector3(0.02f, 1.888f, 0f);
        nodeStar.gameObject.transform.position = newNodeStarPosition;

        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(true);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);

        //Toggle Booleans
        map_b_map1Used = true;
        map_b_map2Used = true;
        map_b_map3Used = false;
        map_b_map4Used = true;
        map_b_map5Used = true;
    }

    //Designer Map 3
    public void Map3()
    {
        //Move nodestar
        Vector3 newNodeStarPosition = new Vector3(-1.88f, 4.07f, 0f);
        nodeStar.gameObject.transform.position = newNodeStarPosition;

        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(true);
        map4.SetActive(false);
        map5.SetActive(false);

        //Toggle Booleans
        map_b_map1Used = true;
        map_b_map2Used = true;
        map_b_map3Used = true;
        map_b_map4Used = false;
        map_b_map5Used = true;
    }

    //Designer Map 4
    public void Map4()
    {
        //Move nodestar
        Vector3 newNodeStarPosition = new Vector3(0.17f, 5.4f, 0f);
        nodeStar.gameObject.transform.position = newNodeStarPosition;

        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(true);
        map5.SetActive(false);

        //Toggle Booleans
        map_b_map1Used = true;
        map_b_map2Used = true;
        map_b_map3Used = true;
        map_b_map4Used = true;
        map_b_map5Used = false;
    }

    //Designer Map 5
    public void Map5()
    {
        //Move nodestar
        Vector3 newNodeStarPosition = new Vector3(-1.21f, 4.87f, 0f);
        nodeStar.gameObject.transform.position = newNodeStarPosition;

        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(true);

        //Toggle Booleans
        map_b_map1Used = false; //Restart at Map 1
        map_b_map2Used = true;
        map_b_map3Used = true;
        map_b_map4Used = true;
        map_b_map5Used = true;
    }
}
