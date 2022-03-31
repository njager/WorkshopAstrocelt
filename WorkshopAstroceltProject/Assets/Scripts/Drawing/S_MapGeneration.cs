using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MapGeneration : MonoBehaviour
{
    //Private variables
    private S_Global global;

    [Header("Nodestar Reference")]
    public S_NodeStar nodeStar; 

    [Header("Temporary grid")]
    public GameObject blackBar1;
    public GameObject blackBar2;
    public GameObject blackBar3;
    public GameObject blackBar4;
    public GameObject blackBar5;
    public GameObject blackBar6;

    [Header("Map References")]
    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    public GameObject map4;
    public GameObject map5;
    public GameObject map6;
    public GameObject map7;
    public GameObject map8;

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
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);

        RandomMapSelector();
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
    
    public void RandomMapSelector()
    {

    }

    // Designer Map 1
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
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
    }

    // Designer Map 2
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
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
    }

    // Designer Map 3
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
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
    }

    // Designer Map 4
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
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
    }

    // Designer Map 5
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
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
    }

    // Designer Map 6
    public void Map6()
    {
        //Move nodestar
        Vector3 newNodeStarPosition = new Vector3(-1.21f, 4.87f, 0f);
        nodeStar.gameObject.transform.position = newNodeStarPosition;

        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(true);
        map7.SetActive(false);
        map8.SetActive(false);
    }

    // Designer Map 7
    public void Map7()
    {
        //Move nodestar
        Vector3 newNodeStarPosition = new Vector3(-1.21f, 4.87f, 0f);
        nodeStar.gameObject.transform.position = newNodeStarPosition;

        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(false);
        map7.SetActive(true);
        map8.SetActive(false);
    }

    // Designer Map 8
    public void Map8()
    {
        //Move nodestar
        Vector3 newNodeStarPosition = new Vector3(-1.21f, 4.87f, 0f);
        nodeStar.gameObject.transform.position = newNodeStarPosition;

        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(true);
    }
}
