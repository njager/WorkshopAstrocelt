using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class S_MapGeneration : MonoBehaviour
{
    /// <summary>
    /// Temporary map script eventually this will be deleted
    /// - Josh
    /// </summary>

    //Private variables
    private S_Global g_global;

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

    [Header("PreviousMap")]
    public GameObject activeMap;
    public List<S_StarClass> activeMapList;

    [Header("Map that was Choosen")]
    public int mp_i_previousMapNum;

    [Header("Energy Star Prefab")]
    [SerializeField] GameObject s_energyStarPrefab;

    // Adding this dumb code for bug fixing purposes

    [Header("Map 1 Star List")]
    public List<S_StarClass> ls_s_map1Stars = new List<S_StarClass>();

    [Header("Map 2 Star List")]
    public List<S_StarClass> ls_s_map2Stars = new List<S_StarClass>();

    [Header("Map 3 Star List")]
    public List<S_StarClass> ls_s_map3Stars = new List<S_StarClass>();

    [Header("Map 4 Star List")]
    public List<S_StarClass> ls_s_map4Stars = new List<S_StarClass>();

    [Header("Map 5 Star List")]
    public List<S_StarClass> ls_s_map5Stars = new List<S_StarClass>();

    [Header("Map 6 Star List")]
    public List<S_StarClass> ls_s_map6Stars = new List<S_StarClass>();

    [Header("Map 7 Star List")]
    public List<S_StarClass> ls_s_map7Stars = new List<S_StarClass>();

    [Header("Map 8 Star List")]
    public List<S_StarClass> ls_s_map8Stars = new List<S_StarClass>();

    [Header("Map 9 Star List")]
    public List<S_StarClass> ls_s_map9Stars = new List<S_StarClass>();

    [Header("Map 10 Star List")]
    public List<S_StarClass> ls_s_map10Stars = new List<S_StarClass>();

    [Header("Map 11 Star List")]
    public List<S_StarClass> ls_s_map11Stars = new List<S_StarClass>();

    [Header("Map 12 Star List")]
    public List<S_StarClass> ls_s_map12Stars = new List<S_StarClass>();

    [Header("Map 13 Star List")]
    public List<S_StarClass> ls_s_map13Stars = new List<S_StarClass>();

    //Will grab chunks here
    private void Awake()
    {
        g_global = S_Global.Instance;

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

        // Create the map list
        GenerateMapLists();
    }


    /// <summary>
    /// Run the map generation list functions
    /// </summary>
    private void GenerateMapLists()
    {
        Map1GrabChildrenCreateList();
        Map2GrabChildrenCreateList();
        Map3GrabChildrenCreateList();
        Map4GrabChildrenCreateList();
        Map5GrabChildrenCreateList();
        Map6GrabChildrenCreateList();
        Map7GrabChildrenCreateList();
        Map8GrabChildrenCreateList();
        Map9GrabChildrenCreateList();
        Map10GrabChildrenCreateList();
        Map11GrabChildrenCreateList();
        Map12GrabChildrenCreateList();
        Map13GrabChildrenCreateList();
    }

    /// <summary>
    /// Use this to clean the previous tar, make sure it's drawable by the next turn
    /// Dumb code
    /// -Josh
    /// </summary>
    public void ResetStarsInPreviousMap()
    {
        if(mp_i_previousMapNum == 1)
        {
            foreach(S_StarClass _star in ls_s_map1Stars.ToList())
            {
                if (_star.starType.Equals("Energy"))
                {
                    S_EnergyStar _energyStar = _star.GetComponent<S_EnergyStar>();
                    _energyStar.SetClickableStarBool(true);
                    _energyStar.SetHasBeenClickedStarBool(false);
                }
                else if(_star.starType.Equals("Ritual"))
                {
                    S_RitualStar _ritualStar = _star.GetComponent<S_RitualStar>();
                    _ritualStar.SetClickableStarBool(true);
                    _ritualStar.SetHasBeenClickedStarBool(false);
                }
            }
        }
        else if(mp_i_previousMapNum == 2)
        {
            foreach (S_StarClass _star in ls_s_map2Stars.ToList())
            {
                if (_star.starType.Equals("Energy"))
                {
                    S_EnergyStar _energyStar = _star.GetComponent<S_EnergyStar>();
                    _energyStar.SetClickableStarBool(true);
                    _energyStar.SetHasBeenClickedStarBool(false);
                }
                else if (_star.starType.Equals("Ritual"))
                {
                    S_RitualStar _ritualStar = _star.GetComponent<S_RitualStar>();
                    _ritualStar.SetClickableStarBool(true);
                    _ritualStar.SetHasBeenClickedStarBool(false);
                }
            }
        }
        else if (mp_i_previousMapNum == 3)
        {
            foreach (S_StarClass _star in ls_s_map3Stars.ToList())
            {
                if (_star.starType.Equals("Energy"))
                {
                    S_EnergyStar _energyStar = _star.GetComponent<S_EnergyStar>();
                    _energyStar.SetClickableStarBool(true);
                    _energyStar.SetHasBeenClickedStarBool(false);
                }
                else if (_star.starType.Equals("Ritual"))
                {
                    S_RitualStar _ritualStar = _star.GetComponent<S_RitualStar>();
                    _ritualStar.SetClickableStarBool(true);
                    _ritualStar.SetHasBeenClickedStarBool(false);
                }
            }
        }
        else if (mp_i_previousMapNum == 4)
        {
            foreach (S_StarClass _star in ls_s_map4Stars.ToList())
            {
                if (_star.starType.Equals("Energy"))
                {
                    S_EnergyStar _energyStar = _star.GetComponent<S_EnergyStar>();
                    _energyStar.SetClickableStarBool(true);
                    _energyStar.SetHasBeenClickedStarBool(false);
                }
                else if (_star.starType.Equals("Ritual"))
                {
                    S_RitualStar _ritualStar = _star.GetComponent<S_RitualStar>();
                    _ritualStar.SetClickableStarBool(true);
                    _ritualStar.SetHasBeenClickedStarBool(false);
                }
            }
        }
        else if (mp_i_previousMapNum == 5)
        {
            foreach (S_StarClass _star in ls_s_map5Stars.ToList())
            {
                if (_star.starType.Equals("Energy"))
                {
                    S_EnergyStar _energyStar = _star.GetComponent<S_EnergyStar>();
                    _energyStar.SetClickableStarBool(true);
                    _energyStar.SetHasBeenClickedStarBool(false);
                }
                else if (_star.starType.Equals("Ritual"))
                {
                    S_RitualStar _ritualStar = _star.GetComponent<S_RitualStar>();
                    _ritualStar.SetClickableStarBool(true);
                    _ritualStar.SetHasBeenClickedStarBool(false);
                }
            }
        }
        else if (mp_i_previousMapNum == 6)
        {
            foreach (S_StarClass _star in ls_s_map6Stars.ToList())
            {
                if (_star.starType.Equals("Energy"))
                {
                    S_EnergyStar _energyStar = _star.GetComponent<S_EnergyStar>();
                    _energyStar.SetClickableStarBool(true);
                    _energyStar.SetHasBeenClickedStarBool(false);
                }
                else if (_star.starType.Equals("Ritual"))
                {
                    S_RitualStar _ritualStar = _star.GetComponent<S_RitualStar>();
                    _ritualStar.SetClickableStarBool(true);
                    _ritualStar.SetHasBeenClickedStarBool(false);
                }
            }
        }
        else if (mp_i_previousMapNum == 7)
        {
            foreach (S_StarClass _star in ls_s_map7Stars.ToList())
            {
                if (_star.starType.Equals("Energy"))
                {
                    S_EnergyStar _energyStar = _star.GetComponent<S_EnergyStar>();
                    _energyStar.SetClickableStarBool(true);
                    _energyStar.SetHasBeenClickedStarBool(false);
                }
                else if (_star.starType.Equals("Ritual"))
                {
                    S_RitualStar _ritualStar = _star.GetComponent<S_RitualStar>();
                    _ritualStar.SetClickableStarBool(true);
                    _ritualStar.SetHasBeenClickedStarBool(false);
                }
            }
        }
        else if (mp_i_previousMapNum == 8)
        {
            foreach (S_StarClass _star in ls_s_map8Stars.ToList())
            {
                if (_star.starType.Equals("Energy"))
                {
                    S_EnergyStar _energyStar = _star.GetComponent<S_EnergyStar>();
                    _energyStar.SetClickableStarBool(true);
                    _energyStar.SetHasBeenClickedStarBool(false);
                }
                else if (_star.starType.Equals("Ritual"))
                {
                    S_RitualStar _ritualStar = _star.GetComponent<S_RitualStar>();
                    _ritualStar.SetClickableStarBool(true);
                    _ritualStar.SetHasBeenClickedStarBool(false);
                }
            }
        }
        else if (mp_i_previousMapNum == 9)
        {
            foreach (S_StarClass _star in ls_s_map9Stars.ToList())
            {
                if (_star.starType.Equals("Energy"))
                {
                    S_EnergyStar _energyStar = _star.GetComponent<S_EnergyStar>();
                    _energyStar.SetClickableStarBool(true);
                    _energyStar.SetHasBeenClickedStarBool(false);
                }
                else if (_star.starType.Equals("Ritual"))
                {
                    S_RitualStar _ritualStar = _star.GetComponent<S_RitualStar>();
                    _ritualStar.SetClickableStarBool(true);
                    _ritualStar.SetHasBeenClickedStarBool(false);
                }
            }
        }
        else if (mp_i_previousMapNum == 10)
        {
            foreach (S_StarClass _star in ls_s_map10Stars.ToList())
            {
                if (_star.starType.Equals("Energy"))
                {
                    S_EnergyStar _energyStar = _star.GetComponent<S_EnergyStar>();
                    _energyStar.SetClickableStarBool(true);
                    _energyStar.SetHasBeenClickedStarBool(false);
                }
                else if (_star.starType.Equals("Ritual"))
                {
                    S_RitualStar _ritualStar = _star.GetComponent<S_RitualStar>();
                    _ritualStar.SetClickableStarBool(true);
                    _ritualStar.SetHasBeenClickedStarBool(false);
                }
            }
        }
        else if (mp_i_previousMapNum == 11)
        {
            foreach (S_StarClass _star in ls_s_map11Stars.ToList())
            {
                if (_star.starType.Equals("Energy"))
                {
                    S_EnergyStar _energyStar = _star.GetComponent<S_EnergyStar>();
                    _energyStar.SetClickableStarBool(true);
                    _energyStar.SetHasBeenClickedStarBool(false);
                }
                else if (_star.starType.Equals("Ritual"))
                {
                    S_RitualStar _ritualStar = _star.GetComponent<S_RitualStar>();
                    _ritualStar.SetClickableStarBool(true);
                    _ritualStar.SetHasBeenClickedStarBool(false);
                }
            }
        }
        else if (mp_i_previousMapNum == 12)
        {
            foreach (S_StarClass _star in ls_s_map12Stars.ToList())
            {
                if (_star.starType.Equals("Energy"))
                {
                    S_EnergyStar _energyStar = _star.GetComponent<S_EnergyStar>();
                    _energyStar.SetClickableStarBool(true);
                    _energyStar.SetHasBeenClickedStarBool(false);
                }
                else if (_star.starType.Equals("Ritual"))
                {
                    S_RitualStar _ritualStar = _star.GetComponent<S_RitualStar>();
                    _ritualStar.SetClickableStarBool(true);
                    _ritualStar.SetHasBeenClickedStarBool(false);
                }
            }
        }
        else if (mp_i_previousMapNum == 13)
        {
            foreach (S_StarClass _star in ls_s_map13Stars.ToList())
            {
                if (_star.starType.Equals("Energy"))
                {
                    S_EnergyStar _energyStar = _star.GetComponent<S_EnergyStar>();
                    _energyStar.SetClickableStarBool(true);
                    _energyStar.SetHasBeenClickedStarBool(false);
                }
                else if (_star.starType.Equals("Ritual"))
                {
                    S_RitualStar _ritualStar = _star.GetComponent<S_RitualStar>();
                    _ritualStar.SetClickableStarBool(true);
                    _ritualStar.SetHasBeenClickedStarBool(false);
                }
            }
        }
    }

    /// <summary>
    /// Hel[per function to replace upgraded node stars
    /// - Josh
    /// </summary>
    /// <param name="_mapNum"></param>
    private void ReplaceNodeStars(int _mapNum)
    {
        foreach(S_NodeStar _nodeStar in g_global.g_ls_nodeStarList.ToList())
        {
            Vector3 _currentPosition = _nodeStar.transform.position;
            GameObject _newStar = Instantiate(s_energyStarPrefab, _currentPosition, Quaternion.identity);
            S_StarClass _newStarScript = _newStar.GetComponent<S_StarClass>();
            GetMapList(_mapNum).Add(_newStarScript);
            Transform _parentTransform = GetTransformFromMapNumber(_mapNum);
            _newStar.transform.SetParent(_parentTransform);
            Destroy(_nodeStar.gameObject);
            g_global.g_ls_nodeStarList.Remove(_nodeStar);
        }
    }

    /// <summary>
    /// Chooses maps randomly, with no direct repeats
    /// Though yes it's dirty
    /// - Josh
    /// </summary>
    public void RandomMapSelector()
    {
        // Choose map int
        int _mapNumChosen = Random.Range(2, 14);
        
        // Toggle maps

        if(_mapNumChosen != mp_i_previousMapNum)
        {
            ResetStarsInPreviousMap();
            int _wasTooQuick = mp_i_previousMapNum;
            ReplaceNodeStars(_wasTooQuick);
            if (_mapNumChosen == 1) // Map 1
            {
                Debug.Log("Map 1 Chosen");
                Map1();
            }
            else if (_mapNumChosen == 2) // Map 2
            {
                Debug.Log("Map 2 Chosen");
                Map2();
            }
            else if (_mapNumChosen == 3) // Map 3
            {
                Debug.Log("Map 3 Chosen");
                Map3();
            }
            else if (_mapNumChosen == 4) // Map 4
            {
                Debug.Log("Map 4 Chosen");
                Map4();
            }
            else if (_mapNumChosen == 5) // Map 5
            {
                Debug.Log("Map 5 Chosen");
                Map5();
            }
            else if (_mapNumChosen == 6) // Map 6
            {
                Debug.Log("Map 6 Chosen");
                Map6();
            }
            else if (_mapNumChosen == 7) // Map 7
            {
                Debug.Log("Map 7 Chosen");
                Map7();
            }
            else if (_mapNumChosen == 8) // Map 8
            {
                Debug.Log("Map 8 Chosen");
                Map8();
            }
            else if (_mapNumChosen == 9) // Map 9
            {
                Debug.Log("Map 9 Chosen");
                Map9();
            }
            else if (_mapNumChosen == 10) // Map 10
            {
                Debug.Log("Map 10 Chosen");
                Map10();
            }
            else if (_mapNumChosen == 11) // Map 11
            {
                Debug.Log("Map 11 Chosen");
                Map11();
            }
            else if (_mapNumChosen == 12) // Map 12
            {
                Debug.Log("Map 12 Chosen");
                Map12();
            }
            else if (_mapNumChosen == 13) // Map 13
            {
                Debug.Log("Map 13 Chosen");
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
        activeMapList = ls_s_map1Stars;
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
        activeMapList = ls_s_map2Stars;
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
        activeMapList = ls_s_map3Stars;
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
        activeMapList = ls_s_map4Stars;
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
        activeMapList = ls_s_map5Stars;
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
        activeMapList = ls_s_map6Stars;
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
        activeMapList = ls_s_map7Stars;
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
        activeMapList = ls_s_map8Stars;
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
        activeMapList = ls_s_map9Stars;
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
        activeMapList = ls_s_map10Stars;
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
        activeMapList = ls_s_map11Stars;
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
        activeMapList = ls_s_map12Stars;
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
        activeMapList = ls_s_map13Stars;
    }


    /// <summary>
    /// Helper function to get parent function to reparent newly added stars
    /// - Josh
    /// </summary>
    /// <param name="_mapNum"></param>
    /// <returns></returns>
    public Transform GetTransformFromMapNumber(int _mapNum)
    {
        if (_mapNum == 1)
        {
            return map1.transform;
        }
        else if (_mapNum == 2)
        {
            return map2.transform;
        }
        else if (_mapNum == 3)
        {
            return map3.transform;
        }
        else if (_mapNum == 4)
        {
            return map4.transform;
        }
        else if (_mapNum == 5)
        {
            return map5.transform;
        }
        else if (_mapNum == 6)
        {
            return map6.transform;
        }
        else if (_mapNum == 7)
        {
            return map7.transform;
        }
        else if (_mapNum == 8)
        {
            return map8.transform;
        }
        else if (_mapNum == 9)
        {
            return map9.transform;
        }
        else if (_mapNum == 10)
        {
            return map10.transform;
        }
        else if (_mapNum == 11)
        {
            return map11.transform;
        }
        else if (_mapNum == 12)
        {
            return map12.transform;
        }
        else if (_mapNum == 13)
        {
            return map13.transform;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Helper function to get map list
    /// </summary>
    /// <param name="_mapNum"></param>
    /// <returns></returns>
    public List<S_StarClass> GetMapList(int _mapNum)
    {
        if (_mapNum == 1)
        {
            return ls_s_map1Stars;
        }
        else if (_mapNum == 2)
        {
            return ls_s_map2Stars;
        }
        else if (_mapNum == 3)
        {
            return ls_s_map3Stars;
        }
        else if (_mapNum == 4)
        {
            return ls_s_map4Stars;
        }
        else if (_mapNum == 5)
        {
            return ls_s_map5Stars;
        }
        else if (_mapNum == 6)
        {
            return ls_s_map6Stars;
        }
        else if (_mapNum == 7)
        {
            return ls_s_map7Stars;
        }
        else if (_mapNum == 8)
        {
            return ls_s_map8Stars;
        }
        else if (_mapNum == 9)
        {
            return ls_s_map9Stars;
        }
        else if (_mapNum == 10)
        {
            return ls_s_map10Stars;
        }
        else if (_mapNum == 11)
        {
            return ls_s_map11Stars;
        }
        else if (_mapNum == 12)
        {
            return ls_s_map12Stars;
        }
        else if (_mapNum == 13)
        {
            return ls_s_map13Stars;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Automatically grab the children, populate the list
    /// - Josh
    /// </summary>
    public void Map1GrabChildrenCreateList()
    {
        foreach(Transform _child in map1.transform)
        {
            if(!_child.tag.Equals("Meteor"))
            {
                ls_s_map1Stars.Add(_child.GetComponent<S_StarClass>());
            }
        }
    }

    /// <summary>
    /// Automatically grab the children, populate the list
    /// - Josh
    /// </summary>
    public void Map2GrabChildrenCreateList()
    {
        foreach (Transform _child in map2.transform)
        {
            if (!_child.tag.Equals("Meteor"))
            {
                ls_s_map2Stars.Add(_child.GetComponent<S_StarClass>());
            }
        }
    }

    /// <summary>
    /// Automatically grab the children, populate the list
    /// - Josh
    /// </summary>
    public void Map3GrabChildrenCreateList()
    {
        foreach (Transform _child in map3.transform)
        {
            if (!_child.tag.Equals("Meteor"))
            {
                ls_s_map3Stars.Add(_child.GetComponent<S_StarClass>());
            }
        }
    }

    /// <summary>
    /// Automatically grab the children, populate the list
    /// - Josh
    /// </summary>
    public void Map4GrabChildrenCreateList()
    {
        foreach (Transform _child in map4.transform)
        {
            if (!_child.tag.Equals("Meteor"))
            {
                ls_s_map4Stars.Add(_child.GetComponent<S_StarClass>());
            }
        }
    }

    /// <summary>
    /// Automatically grab the children, populate the list
    /// - Josh
    /// </summary>
    public void Map5GrabChildrenCreateList()
    {
        foreach (Transform _child in map5.transform)
        {
            if (!_child.tag.Equals("Meteor"))
            {
                ls_s_map5Stars.Add(_child.GetComponent<S_StarClass>());
            }
        }
    }

    /// <summary>
    /// Automatically grab the children, populate the list
    /// - Josh
    /// </summary>
    public void Map6GrabChildrenCreateList()
    {
        foreach (Transform _child in map6.transform)
        {
            if (!_child.tag.Equals("Meteor"))
            {
                ls_s_map6Stars.Add(_child.GetComponent<S_StarClass>());
            }
        }
    }

    /// <summary>
    /// Automatically grab the children, populate the list
    /// - Josh
    /// </summary>
    public void Map7GrabChildrenCreateList()
    {
        foreach (Transform _child in map7.transform)
        {
            if (!_child.tag.Equals("Meteor"))
            {
                ls_s_map7Stars.Add(_child.GetComponent<S_StarClass>());
            }
        }
    }

    /// <summary>
    /// Automatically grab the children, populate the list
    /// - Josh
    /// </summary>
    public void Map8GrabChildrenCreateList()
    {
        foreach (Transform _child in map8.transform)
        {
            if (!_child.tag.Equals("Meteor"))
            {
                ls_s_map8Stars.Add(_child.GetComponent<S_StarClass>());
            }
        }
    }

    /// <summary>
    /// Automatically grab the children, populate the list
    /// - Josh
    /// </summary>
    public void Map9GrabChildrenCreateList()
    {
        foreach (Transform _child in map9.transform)
        {
            if (!_child.tag.Equals("Meteor"))
            {
                ls_s_map9Stars.Add(_child.GetComponent<S_StarClass>());
            }
        }
    }

    /// <summary>
    /// Automatically grab the children, populate the list
    /// - Josh
    /// </summary>
    public void Map10GrabChildrenCreateList()
    {
        foreach (Transform _child in map10.transform)
        {
            if (!_child.tag.Equals("Meteor"))
            {
                ls_s_map10Stars.Add(_child.GetComponent<S_StarClass>());
            }
        }
    }

    /// <summary>
    /// Automatically grab the children, populate the list
    /// - Josh
    /// </summary>
    public void Map11GrabChildrenCreateList()
    {
        foreach (Transform _child in map11.transform)
        {
            if (!_child.tag.Equals("Meteor"))
            {
                ls_s_map11Stars.Add(_child.GetComponent<S_StarClass>());
            }
        }
    }

    /// <summary>
    /// Automatically grab the children, populate the list
    /// - Josh
    /// </summary>
    public void Map12GrabChildrenCreateList()
    {
        foreach (Transform _child in map12.transform)
        {
            if (!_child.tag.Equals("Meteor"))
            {
                ls_s_map12Stars.Add(_child.GetComponent<S_StarClass>());
            }
        }
    }

    /// <summary>
    /// Automatically grab the children, populate the list
    /// - Josh
    /// </summary>
    public void Map13GrabChildrenCreateList()
    {
        foreach (Transform _child in map13.transform)
        {
            if (!_child.tag.Equals("Meteor"))
            {
                ls_s_map13Stars.Add(_child.GetComponent<S_StarClass>());
            }
        }
    }
}
