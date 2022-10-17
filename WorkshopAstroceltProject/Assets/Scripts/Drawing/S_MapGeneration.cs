using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MapGeneration : MonoBehaviour
{
    /// <summary>
    /// Temporary map script eventually this will be deleted
    /// - Josh
    /// </summary>

    //Private variables
    private S_Global global;

    [Header("Map References")]
    public GameObject map1;
    public GameObject map2;
    public GameObject map3;
    public GameObject map4;
    public GameObject map5;
    public GameObject map6;
    public GameObject map7;
    public GameObject map8;
    public GameObject map9;
    public GameObject map10;
    public GameObject map11;
    public GameObject map12;
    public GameObject map13;

    public GameObject activeMap;

    [Header("Map that was Choosen")]
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
        map9.SetActive(false);
        map10.SetActive(false);
        map11.SetActive(false);
        map12.SetActive(false);
        map13.SetActive(false);

        RandomMapSelector();
    }

    /// <summary>
    /// Chooses maps randomly, with no direct repeats
    /// Though yes it's dirty
    /// - Josh
    /// </summary>
    public void RandomMapSelector()
    {
        // Choose map int
        int _mapNumChosen = Random.Range(1, 14);
        
        // Toggle maps

        // Map 1

        if(_mapNumChosen != mp_i_previousMapNum)
        {
            if (_mapNumChosen == 1) // Map 1
            {
                //Debug.Log("Map 1 Chosen");
                Map1();
            }
            else if (_mapNumChosen == 2) // Map 2
            {
                //Debug.Log("Map 3 Chosen");
                Map2();
            }
            else if (_mapNumChosen == 3) // Map 3
            {
                //Debug.Log("Map 4 Chosen");
                Map3();
            }
            else if (_mapNumChosen == 4) // Map 4
            {
                //Debug.Log("Map 5 Chosen");
                Map4();
            }
            else if (_mapNumChosen == 5) // Map 5
            {
                //Debug.Log("Map 6 Chosen");
                Map5();
            }
            else if (_mapNumChosen == 6) // Map 6
            {
                //Debug.Log("Map 7 Chosen");
                Map6();
            }
            else if (_mapNumChosen == 7) // Map 7
            {
                //Debug.Log("Map 1 Chosen");
                Map7();
            }
            else if (_mapNumChosen == 8) // Map 8
            {
                //Debug.Log("Map 1 Chosen");
                Map8();
            }
            else if (_mapNumChosen == 9) // Map 9
            {
                //Debug.Log("Map 1 Chosen");
                Map9();
            }
            else if (_mapNumChosen == 10) // Map 10
            {
                //Debug.Log("Map 1 Chosen");
                Map10();
            }
            else if (_mapNumChosen == 11) // Map 11
            {
                //Debug.Log("Map 1 Chosen");
                Map11();
            }
            else if (_mapNumChosen == 12) // Map 12
            {
                //Debug.Log("Map 1 Chosen");
                Map12();
            }
            else if (_mapNumChosen == 13) // Map 13
            {
                //Debug.Log("Map 1 Chosen");
                Map13();
            }
        }
        else
        {
            RandomMapSelector();
        }
    }

    // Designer Map 1
    public void Map1()
    {
        //Toggle maps
        map1.SetActive(true);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
        map9.SetActive(false);
        map10.SetActive(false);
        map11.SetActive(false);
        map12.SetActive(false);
        map13.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 1;

        activeMap = map1;
    }

    // Designer Map 2
    public void Map2()
    {
        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(true);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
        map9.SetActive(false);
        map10.SetActive(false);
        map11.SetActive(false);
        map12.SetActive(false);
        map13.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 2;

        activeMap = map2;
    }

    // Designer Map 3
    public void Map3()
    {
        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(true);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
        map9.SetActive(false);
        map10.SetActive(false);
        map11.SetActive(false);
        map12.SetActive(false);
        map13.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 3;

        activeMap = map3;
    }

    // Designer Map 4
    public void Map4()
    {
        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(true);
        map5.SetActive(false);
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
        map9.SetActive(false);
        map10.SetActive(false);
        map11.SetActive(false);
        map12.SetActive(false);
        map13.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 4;

        activeMap = map4;
    }

    // Designer Map 5
    public void Map5()
    {
        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(true);
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
        map9.SetActive(false);
        map10.SetActive(false);
        map11.SetActive(false);
        map12.SetActive(false);
        map13.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 5;

        activeMap = map5;
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
        map9.SetActive(false);
        map10.SetActive(false);
        map11.SetActive(false);
        map12.SetActive(false);
        map13.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 6;

        activeMap = map6;
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
        map9.SetActive(false);
        map10.SetActive(false);
        map11.SetActive(false);
        map12.SetActive(false);
        map13.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 7;

        activeMap = map7;
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
        map9.SetActive(false);
        map10.SetActive(false);
        map11.SetActive(false);
        map12.SetActive(false);
        map13.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 8;

        activeMap = map8;
    }

    // Designer Map 9
    public void Map9()
    {
        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
        map9.SetActive(true);
        map10.SetActive(false);
        map11.SetActive(false);
        map12.SetActive(false);
        map13.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 9;

        activeMap = map9;
    }

    // Designer Map 10
    public void Map10()
    {
        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
        map9.SetActive(false);
        map10.SetActive(true);
        map11.SetActive(false);
        map12.SetActive(false);
        map13.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 10;

        activeMap = map10;
    }

    // Designer Map 11
    public void Map11()
    {
        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
        map9.SetActive(false);
        map10.SetActive(false);
        map11.SetActive(true);
        map12.SetActive(false);
        map13.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 11;

        activeMap = map11;
    }

    // Designer Map 12
    public void Map12()
    {
        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
        map9.SetActive(false);
        map10.SetActive(false);
        map11.SetActive(false);
        map12.SetActive(true);
        map13.SetActive(false);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 12;

        activeMap = map12;
    }

    // Designer Map 13
    public void Map13()
    {
        //Toggle maps
        map1.SetActive(false);
        map2.SetActive(false);
        map3.SetActive(false);
        map4.SetActive(false);
        map5.SetActive(false);
        map6.SetActive(false);
        map7.SetActive(false);
        map8.SetActive(false);
        map9.SetActive(false);
        map10.SetActive(false);
        map11.SetActive(false);
        map12.SetActive(false);
        map13.SetActive(true);

        // Set previous map for non-repeating
        mp_i_previousMapNum = 13;

        activeMap = map13;
    }
}
