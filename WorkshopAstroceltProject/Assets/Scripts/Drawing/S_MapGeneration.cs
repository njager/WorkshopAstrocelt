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

    //Think of adding map_ as a designator
    //Will grab chunks here
    private void Awake()
    {
        global = S_Global.Instance;
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        Map1(); 
    }

    private void Start()
    {
        blackBar1.SetActive(false);
        blackBar2.SetActive(false);
        blackBar3.SetActive(false);
        blackBar4.SetActive(false);
        blackBar5.SetActive(false);
    }

    /// <summary>
    /// Not to be used yet, milestone 2
    /// </summary>
    public void NewMapGeneration()
    {
        
    }

    ////Temporary\\\\

    //Designer Map 1
    public void Map1()
    {
        Vector3 newNodeStarPosition = new Vector3(-1.27f, 0.04f, 0f);
        nodeStar.gameObject.transform.position = newNodeStarPosition;

        map1.SetActive(true);
        map2.SetActive(false);
        map3.SetActive(false);

        //Toggle Booleans
        map_b_map1Used = true;
        map_b_map2Used = false;
        map_b_map3Used = true;
    }

    //Designer Map 2
    public void Map2()
    {
        Vector3 newNodeStarPosition = new Vector3(0.02f, 1.888f, 0f);
        nodeStar.gameObject.transform.position = newNodeStarPosition;

        map1.SetActive(false);
        map2.SetActive(true);
        map3.SetActive(false);

        //Toggle Booleans
        map_b_map1Used = true;
        map_b_map2Used = true;
        map_b_map3Used = false;
    }

    //Designer Map 3
    public void Map3()
    {
        Vector3 newNodeStarPosition = new Vector3(-1.88f, 4.07f, 0f);
        nodeStar.gameObject.transform.position = newNodeStarPosition;

        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(true);

        //Toggle Booleans
        map_b_map1Used = false;
        map_b_map2Used = true;
        map_b_map3Used = true;
    }

    //Designer Map 4
    public void Map4()
    {
        Vector3 newNodeStarPosition = new Vector3(0.17f, 5.4f, 0f);
        nodeStar.gameObject.transform.position = newNodeStarPosition;

        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(true);

        //Toggle Booleans
        map_b_map1Used = false;
        map_b_map2Used = true;
        map_b_map3Used = true;
    }

    //Designer Map 5
    public void Map5()
    {
        Vector3 newNodeStarPosition = new Vector3(-1.21f, 4.87f, 0f);
        nodeStar.gameObject.transform.position = newNodeStarPosition;

        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(true);

        //Toggle Booleans
        map_b_map1Used = false;
        map_b_map2Used = true;
        map_b_map3Used = true;
    }
}
