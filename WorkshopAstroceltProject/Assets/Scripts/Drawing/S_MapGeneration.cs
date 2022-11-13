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

    public Vector3 RandomVector(int clusternum) {
        float rand_x;
        float rand_y;
        if (clusternum == 1)
        {
            rand_x = Random.Range(-12, -6);
            rand_y = Random.Range(4, 8);
        }
        else if(clusternum == 2)
        {
            rand_x = Random.Range(-12, -6);
            rand_y = Random.Range(0, 4);
        }
        else if (clusternum == 3)
        {
            rand_x = Random.Range(-6, 0);
            rand_y = Random.Range(4, 8);
        }
        else if (clusternum == 4)
        {
            rand_x = Random.Range(-6, 0);
            rand_y = Random.Range(0, 4);
        }
        else if (clusternum == 5)
        {
            rand_x = Random.Range(0, 6);
            rand_y = Random.Range(4, 8);
        }
        else if (clusternum == 6)
        {
            rand_x = Random.Range(0, 6);
            rand_y = Random.Range(0, 4);
        }
        else if (clusternum == 7)
        {
            rand_x = Random.Range(6, 12);
            rand_y = Random.Range(4, 8);
        }
        else
        {
            rand_x = Random.Range(6, 12);
            rand_y = Random.Range(0, 4);
        }



        
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
        List<List<Transform>> clusters = new List<List<Transform>>();
        List<Transform> temp = new List<Transform>();
        

        int count = 1;
        int clusternum = 1;

        foreach (Transform i in map1.GetComponentInChildren<Transform>())
        {
            i.transform.position = RandomVector(clusternum);
            temp.Add(i);

            if(count >= 5)
            {
                count = 0;
                clusters.Add(temp);
                temp.Clear();
                clusternum++;
            }
            count++;
        }
        //RunSpringGen();

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
        
    }

}

