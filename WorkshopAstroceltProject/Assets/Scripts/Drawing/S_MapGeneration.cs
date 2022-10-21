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
  

    public GameObject activeMap;

    [Header("Map that was Choosen")]
    public int mp_i_previousMapNum;

    //Will grab chunks here
    private void Awake()
    {
        global = S_Global.Instance;

        //Temporary calls for current map structure
        map1.SetActive(true);
        activeMap = map1;
        RandomMapSelector();
    }

    public Vector3 RandomVector() {
        bool check = true;
        Vector3 goodvec = new Vector3(0,0,0); 
        while (check)
        {
            float rand_x = Random.Range(-12, 12);
            float rand_y = Random.Range(-3, 6);
            Vector3 temp = new Vector3(rand_x, rand_y, 0);
            goodvec = temp;
            check = pos_checker(temp);
        }
        return goodvec;
    }


    public bool pos_checker(Vector3 potential_vector)
    {
        bool check_bool = true;
        foreach (Transform g in map1.GetComponentsInChildren<Transform>())
        {
            if (Mathf.Abs(g.transform.position.x - potential_vector.x) <= .7)
            {
                check_bool = false;
            }
            if (Mathf.Abs(g.transform.position.y - potential_vector.y) <= .7)
            {
                check_bool = false;
            }

        }
        return check_bool;
        
    }

    /// <summary>
    /// Chooses maps randomly, with no direct repeats
    /// Though yes it's dirty
    /// - Josh
    /// </summary>
    /// 
    public void RandomMapSelector()
    {
        foreach (Transform g in map1.GetComponentsInChildren<Transform>())
        {
            g.transform.position = RandomVector();
        }
        RunSpringGen();
    }



    public void RunSpringGen()
    {
        foreach (Transform g in map1.GetComponentsInChildren<Transform>())
        {
            //remove spring componentS
        }
    }
}
