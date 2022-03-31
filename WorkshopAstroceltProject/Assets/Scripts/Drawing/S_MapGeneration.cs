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

    [Header("Random Choosing")]
    public int mp_i_previousMapNum;

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
    

    /// <summary>
    /// Chooses maps randomly, with no direct repeats
    /// Though yes it's dirty
    /// - Josh
    /// </summary>
    public void RandomMapSelector()
    {
        // Choose map int
        int _mapNumChosen = Random.Range(1, 9);
        
        // Toggle maps

        // Map 1
        if(_mapNumChosen == 1)
        {
            if (mp_i_previousMapNum == 1)
            {
                // If it was a previous map, choose a new one
                int _mapNumChosen2 = Random.Range(1, 8);
                if(_mapNumChosen2 == 1) // Map 2
                {
                    Debug.Log("Map 2 Chosen");
                    Map2();
                }
                else if (_mapNumChosen2 == 2) // Map 3
                {
                    Debug.Log("Map 3 Chosen");
                    Map3();
                }
                else if (_mapNumChosen2 == 3) // Map 4
                {
                    Debug.Log("Map 4 Chosen");
                    Map4();
                }
                else if (_mapNumChosen2 == 4) // Map 5
                {
                    Debug.Log("Map 5 Chosen");
                    Map5();
                }
                else if (_mapNumChosen2 == 5) // Map 6
                {
                    Debug.Log("Map 6 Chosen");
                    Map6();
                }
                else if (_mapNumChosen2 == 6) // Map 7
                {
                    Debug.Log("Map 7 Chosen");
                    Map7();
                }
                else if (_mapNumChosen2 == 7) // Map 8
                {
                    Debug.Log("Map 8 Chosen");
                    Map8();
                }
            }
            else
            {
                Debug.Log("Map 1 Chosen");
                Map1();
            }
        }
        
        // Map 2
        if (_mapNumChosen == 2)
        {
            if (mp_i_previousMapNum == 2)
            {
                // If it was a previous map, choose a new one
                int _mapNumChosen2 = Random.Range(1, 8);
                if (_mapNumChosen2 == 1) // Map 1
                {
                    Debug.Log("Map 1 Chosen");
                    Map1();
                }
                else if (_mapNumChosen2 == 2) // Map 3
                {
                    Debug.Log("Map 3 Chosen");
                    Map3();
                }
                else if (_mapNumChosen2 == 3) // Map 4
                {
                    Debug.Log("Map 4 Chosen");
                    Map4();
                }
                else if (_mapNumChosen2 == 4) // Map 5
                {
                    Debug.Log("Map 5 Chosen");
                    Map5();
                }
                else if (_mapNumChosen2 == 5) // Map 6
                {
                    Debug.Log("Map 6 Chosen");
                    Map6();
                }
                else if (_mapNumChosen2 == 6) // Map 7
                {
                    Debug.Log("Map 7 Chosen");
                    Map7();
                }
                else if (_mapNumChosen2 == 7) // Map 8
                {
                    Debug.Log("Map 8 Chosen");
                    Map8();
                }
            }
            else
            {
                Debug.Log("Map 2 Chosen");
                Map2();
            }
        }
        
        // Map 3
        if (_mapNumChosen == 3) 
        {
            if (mp_i_previousMapNum == 3)
            {
                // If it was a previous map, choose a new one
                int _mapNumChosen2 = Random.Range(1, 8);
                if (_mapNumChosen2 == 1) // Map 2
                {
                    Debug.Log("Map 2 Chosen");
                    Map2();
                }
                else if (_mapNumChosen2 == 2) // Map 1
                {
                    Debug.Log("Map 1 Chosen");
                    Map1();
                }
                else if (_mapNumChosen2 == 3) // Map 4
                {
                    Debug.Log("Map 4 Chosen");
                    Map4();
                }
                else if (_mapNumChosen2 == 4) // Map 5
                {
                    Debug.Log("Map 5 Chosen");
                    Map5();
                }
                else if (_mapNumChosen2 == 5) // Map 6
                {
                    Debug.Log("Map 6 Chosen");
                    Map6();
                }
                else if (_mapNumChosen2 == 6) // Map 7
                {
                    Debug.Log("Map 7 Chosen");
                    Map7();
                }
                else if (_mapNumChosen2 == 7) // Map 8
                {
                    Debug.Log("Map 8 Chosen");
                    Map8();
                }
            }
            else
            {
                Debug.Log("Map 3 Chosen");
                Map3();
            }
        }

        // Map 4
        if (_mapNumChosen == 4)
        {
            if (mp_i_previousMapNum == 4)
            {
                // If it was a previous map, choose a new one
                int _mapNumChosen2 = Random.Range(1, 8);
                if (_mapNumChosen2 == 1) // Map 2
                {
                    Debug.Log("Map 2 Chosen");
                    Map2();
                }
                else if (_mapNumChosen2 == 2) // Map 3
                {
                    Debug.Log("Map 3 Chosen");
                    Map3();
                }
                else if (_mapNumChosen2 == 3) // Map 1
                {
                    Debug.Log("Map 1 Chosen");
                    Map1();
                }
                else if (_mapNumChosen2 == 4) // Map 5
                {
                    Debug.Log("Map 5 Chosen");
                    Map5();
                }
                else if (_mapNumChosen2 == 5) // Map 6
                {
                    Debug.Log("Map 6 Chosen");
                    Map6();
                }
                else if (_mapNumChosen2 == 6) // Map 7
                {
                    Debug.Log("Map 7 Chosen");
                    Map7();
                }
                else if (_mapNumChosen2 == 7) // Map 8
                {
                    Debug.Log("Map 8 Chosen");
                    Map8();
                }
            }
            else
            {
                Debug.Log("Map 4 Chosen");
                Map4();
            }
        }

        // Map 5
        if (_mapNumChosen == 5)
        {
            if (mp_i_previousMapNum == 5)
            {
                // If it was a previous map, choose a new one
                int _mapNumChosen2 = Random.Range(1, 8);
                if (_mapNumChosen2 == 1) // Map 2
                {
                    Debug.Log("Map 2 Chosen");
                    Map2();
                }
                else if (_mapNumChosen2 == 2) // Map 3
                {
                    Debug.Log("Map 3 Chosen");
                    Map3();
                }
                else if (_mapNumChosen2 == 3) // Map 4
                {
                    Debug.Log("Map 4 Chosen");
                    Map4();
                }
                else if (_mapNumChosen2 == 4) // Map 1
                {
                    Debug.Log("Map 1 Chosen");
                    Map1();
                }
                else if (_mapNumChosen2 == 5) // Map 6
                {
                    Debug.Log("Map 6 Chosen");
                    Map6();
                }
                else if (_mapNumChosen2 == 6) // Map 7
                {
                    Debug.Log("Map 7 Chosen");
                    Map7();
                }
                else if (_mapNumChosen2 == 7) // Map 8
                {
                    Debug.Log("Map 8 Chosen");
                    Map8();
                }
            }
            else
            {
                Debug.Log("Map 5 Chosen");
                Map5();
            }
        }

        // Map 6
        if (_mapNumChosen == 6)
        {
            if (mp_i_previousMapNum == 6)
            {
                // If it was a previous map, choose a new one
                int _mapNumChosen2 = Random.Range(1, 8);
                if (_mapNumChosen2 == 1) // Map 2
                {
                    Debug.Log("Map 2 Chosen");
                    Map2();
                }
                else if (_mapNumChosen2 == 2) // Map 3
                {
                    Debug.Log("Map 3 Chosen");
                    Map3();
                }
                else if (_mapNumChosen2 == 3) // Map 4
                {
                    Debug.Log("Map 4 Chosen");
                    Map4();
                }
                else if (_mapNumChosen2 == 4) // Map 5
                {
                    Debug.Log("Map 5 Chosen");
                    Map5();
                }
                else if (_mapNumChosen2 == 5) // Map 1
                {
                    Debug.Log("Map 1 Chosen");
                    Map1();
                }
                else if (_mapNumChosen2 == 6) // Map 7
                {
                    Debug.Log("Map 7 Chosen");
                    Map7();
                }
                else if (_mapNumChosen2 == 7) // Map 8
                {
                    Debug.Log("Map 8 Chosen");
                    Map8();
                }
            }
            else
            {
                Debug.Log("Map 6 Chosen");
                Map6();
            }
        }

        // Map 7
        if (_mapNumChosen == 7)
        {
            if (mp_i_previousMapNum == 7)
            {
                // If it was a previous map, choose a new one
                int _mapNumChosen2 = Random.Range(1, 8);
                if (_mapNumChosen2 == 1) // Map 2
                {
                    Debug.Log("Map 2 Chosen");
                    Map2();
                }
                else if (_mapNumChosen2 == 2) // Map 3
                {
                    Debug.Log("Map 3 Chosen");
                    Map3();
                }
                else if (_mapNumChosen2 == 3) // Map 4
                {
                    Debug.Log("Map 4 Chosen");
                    Map4();
                }
                else if (_mapNumChosen2 == 4) // Map 5
                {
                    Debug.Log("Map 5 Chosen");
                    Map5();
                }
                else if (_mapNumChosen2 == 5) // Map 6
                {
                    Debug.Log("Map 6 Chosen");
                    Map6();
                }
                else if (_mapNumChosen2 == 6) // Map 1
                {
                    Debug.Log("Map 1 Chosen");
                    Map1();
                }
                else if (_mapNumChosen2 == 7) // Map 8
                {
                    Debug.Log("Map 8 Chosen");
                    Map8();
                }
            }
            else
            {
                Debug.Log("Map 7 Chosen");
                Map7();
            }
        }

        // Map 8
        if (_mapNumChosen == 8)
        {
            if (mp_i_previousMapNum == 8)
            {
                // If it was a previous map, choose a new one
                int _mapNumChosen2 = Random.Range(1, 8);
                if (_mapNumChosen2 == 1) // Map 2
                {
                    Debug.Log("Map 2 Chosen");
                    Map2();
                }
                else if (_mapNumChosen2 == 2) // Map 3
                {
                    Debug.Log("Map 3 Chosen");
                    Map3();
                }
                else if (_mapNumChosen2 == 3) // Map 4
                {
                    Debug.Log("Map 4 Chosen");
                    Map4();
                }
                else if (_mapNumChosen2 == 4) // Map 5
                {
                    Debug.Log("Map 5 Chosen");
                    Map5();
                }
                else if (_mapNumChosen2 == 5) // Map 6
                {
                    Debug.Log("Map 6 Chosen");
                    Map6();
                }
                else if (_mapNumChosen2 == 6) // Map 7
                {
                    Debug.Log("Map 7 Chosen");
                    Map7();
                }
                else if (_mapNumChosen2 == 7) // Map 1
                {
                    Debug.Log("Map 1 Chosen");
                    Map1();
                }
            }
            else
            {
                Debug.Log("Map 8 Chosen");
                Map8();
            }
        }
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

        // Set previous map for non-repeating
        mp_i_previousMapNum = 1;
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

        // Set previous map for non-repeating
        mp_i_previousMapNum = 2;
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

        // Set previous map for non-repeating
        mp_i_previousMapNum = 3;
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

        // Set previous map for non-repeating
        mp_i_previousMapNum = 4;
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

        // Set previous map for non-repeating
        mp_i_previousMapNum = 5;
    }

    // Designer Map 6
    public void Map6()
    {
        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(true);
        map7.SetActive(false);
        map8.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 6;
    }

    // Designer Map 7
    public void Map7()
    {
        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(false);
        map7.SetActive(true);
        map8.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 7;
    }

    // Designer Map 8
    public void Map8()
    {
        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(true);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 8;
    }
}
