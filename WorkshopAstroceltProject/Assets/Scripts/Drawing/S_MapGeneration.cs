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


    public void cluster_checker(List<List<Transform>> clusters)
    {
        for (int i = 0; i < 8; i++)
        {
            print("cluster:" + (i+1));
            List<Transform> this_cluster = clusters[i];
            for (int j = 0; j < this_cluster.Count; j++)
            {
                print(this_cluster[j]);
            }
        }
    }

    public Vector3 RandomVector(int clusternum) {
        float rand_x;
        float rand_y;
        if (clusternum == 1)
        {
            rand_x = Random.Range(-12, -6);
            rand_y = Random.Range(3, 7);
        }
        else if(clusternum == 2)
        {
            rand_x = Random.Range(-12, -6);
            rand_y = Random.Range(-1, 3);
        }
        else if (clusternum == 3)
        {
            rand_x = Random.Range(-6, 0);
            rand_y = Random.Range(3, 7);
        }
        else if (clusternum == 4)
        {
            rand_x = Random.Range(-6, 0);
            rand_y = Random.Range(-1, 3);
        }
        else if (clusternum == 5)
        {
            rand_x = Random.Range(0, 6);
            rand_y = Random.Range(3, 7);
        }
        else if (clusternum == 6)
        {
            rand_x = Random.Range(0, 6);
            rand_y = Random.Range(-1, 3);
        }
        else if (clusternum == 7)
        {
            rand_x = Random.Range(6, 12);
            rand_y = Random.Range(3, 7);
        }
        else
        {
            rand_x = Random.Range(6, 12);
            rand_y = Random.Range(-1, 3);
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
        //Debug.Log(map1.gameObject.transform.GetChildCount());

        foreach (Transform i in map1.GetComponentInChildren<Transform>())
        {
            i.transform.position = RandomVector(clusternum);
            temp.Add(i);

            if(count == 5)
            {
                count = 0;
                clusters.Add(temp);
                temp = new List<Transform>();
                clusternum++;
                //Debug.Log("thru 5");
            }
            count++;
            //Debug.Log(clusternum);
        }
        RunSpringGen(clusters);
        List<List<List<SpringJoint2D>>> springList = CreateSpringList(clusters);
        RunSpringRBConnect(springList,clusters);
        RemoveLockandGravConstraint(clusters);
        //cluster_checker(clusters);

    }


    public void RunSpringGen(List<List<Transform>> clusters)
    {
        for (int i = 0; i < 8; i++)
        {
            List<Transform> this_cluster = clusters[i];
            for (int j = 0; j < this_cluster.Count; j++)
            {
                for (int k = 0; k < this_cluster.Count; k++)
                {
                    if(j != k)
                    {
                        this_cluster[j].gameObject.AddComponent<SpringJoint2D>();
                        //Debug.Log("loop be loopin");
                    }
                }
            }
        }
        
    }

    public List<List<List<SpringJoint2D>>> CreateSpringList(List<List<Transform>> clusters)
    {
        List<List<List<SpringJoint2D>>> springList = new List<List<List<SpringJoint2D>>>();
        for (int i = 0; i < 8; i++)
        {
            List<List<SpringJoint2D>> this_cluster_springs = new List<List<SpringJoint2D>>();
            List<Transform> this_cluster = clusters[i];
            for (int j = 0; j < 5; j++)
            {
                List<SpringJoint2D> tempSprings = new List<SpringJoint2D>(this_cluster[j].GetComponents<SpringJoint2D>());
                //List<SpringJoint2D> tempSprings = 
                //this_cluster[j].GetComponents<SpringJoint2D>();
                /*
                foreach (SpringJoint2D spring in this_cluster[j])
                {
                    tempSprings.Add(spring);
                }
                */
                this_cluster_springs.Add(tempSprings);
            }
            springList.Add(this_cluster_springs);
        }
        return springList;
    }


    public void RunSpringRBConnect(List<List<List<SpringJoint2D>>> springList, List<List<Transform>> clusters)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 4; k++)
                {
                    springList[i][j][k].connectedBody = clusters[i][k].GetComponent<Rigidbody2D>();
                    springList[i][j][k].distance = 6;
                }
            }
        }

    }
    public void RemoveLockandGravConstraint(List<List<Transform>> clusters)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Rigidbody2D rb = clusters[i][j].GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.None;
                clusters[i][j].GetComponent<Rigidbody2D>().gravityScale = 1;

            }
        }
    }
}

