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
        float rand_x = Random.Range(-12, 12);
        float rand_y = Random.Range(-3, 6);
        Vector3 temp = new Vector3(rand_x, rand_y, 0);
        return temp;
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
        foreach (Transform i in map1.GetComponentsInChildren<Transform>())
        {
            foreach (Transform j in map1.GetComponentsInChildren<Transform>())
            {
                if(i != j)
                {
                    i.gameObject.AddComponent<SpringJoint2D>();
                }
            }
        }
        /*
        foreach (Transform i in map1.GetComponentsInChildren<Transform>())
        {
            Component[] springs;
            springs = i.gameObject.GetComponents(typeof(SpringJoint2D));
            //Debug.Log(springs);

            
            foreach (Rigidbody2D j in map1.GetComponentsInChildren<Rigidbody2D>())
            {
                foreach (SpringJoint2D k in springs)
                {
                    k.connectedBody = j;
                }
            }
            
         }
        */
    }

}

