using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class S_MapManager : MonoBehaviour
{
    /// <summary>
    /// Temporary map script eventually this will be deleted
    /// - Josh
    /// </summary>

    //Private variables
    private S_Global global;

    [Header("Map References")]
    public GameObject map1;
    public GameObject Sides;


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
            print("cluster:" + (i + 1));
            List<Transform> this_cluster = clusters[i];
            for (int j = 0; j < this_cluster.Count; j++)
            {
                print(this_cluster[j]);
            }
        }
    }


    public Vector3 RandomVector(int clusternum)
    {
        Vector3 temp = new Vector3(0, 0, 0);
        if (clusternum == 1)
        {
            temp = new Vector3(Random.Range(-12.0f, -6.0f), Random.Range(3.0f, 7.0f), 0);
        }
        else if (clusternum == 2)
        {
            temp = new Vector3(Random.Range(-12.0f, -6.0f), Random.Range(-1.0f, 3.0f), 0);
        }
        else if (clusternum == 3)
        {
            temp = new Vector3(Random.Range(-6.0f, 0.0f), Random.Range(3.0f, 7.0f), 0);
        }
        else if (clusternum == 4)
        {
            temp = new Vector3(Random.Range(-6.0f, 0.0f), Random.Range(-1.0f, 3.0f), 0);
        }
        else if (clusternum == 5)
        {
            temp = new Vector3(Random.Range(0.0f, 6.0f), Random.Range(3.0f, 7.0f), 0);
        }
        else if (clusternum == 6)
        {
            temp = new Vector3(Random.Range(0.0f, 6.0f), 0, Random.Range(-1.0f, 3.0f));
        }
        else if (clusternum == 7)
        {
            temp = new Vector3(Random.Range(6.0f, 12.0f), Random.Range(3.0f, 7.0f), 0);
        }
        else
        {
            temp = new Vector3(Random.Range(6.0f, 12.0f), Random.Range(-1.0f, 3.0f), 0);
        }
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

            if (count == 5)
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
        RunSpringRBConnect(springList, clusters);
        RemoveLockandGravConstraint(clusters);
        ConnectToRoof(springList, clusters);
        ConnectClusters(springList, clusters);
        StartCoroutine(WaitForGen(clusters));
        
        //cluster_checker(clusters);

    }


    public void RunSpringGen(List<List<Transform>> clusters)
    {
        for (int i = 0; i < 8; i++)
        {
            List<Transform> this_cluster = clusters[i];
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 8; k++)
                {
                    this_cluster[j].gameObject.AddComponent<SpringJoint2D>();
                    /*
                    if (j != k)
                    {
                        this_cluster[j].gameObject.AddComponent<SpringJoint2D>();
                        //Debug.Log("loop be loopin");
                    }
                    */
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

    public float RandDist() 
    {
        return Random.Range(2.3f, 6.2f);
    }
    public void RunSpringRBConnect(List<List<List<SpringJoint2D>>> springList, List<List<Transform>> clusters)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    float this_dist = RandDist();
                    springList[i][j][k].connectedBody = clusters[i][k].GetComponent<Rigidbody2D>();
                    springList[i][j][k].autoConfigureDistance = false;
                    springList[i][j][k].distance = this_dist;
                    springList[i][j][k].frequency = 2;
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
                clusters[i][j].GetComponent<Rigidbody2D>().gravityScale = .1f;

            }
        }
    }

    public void ConnectToRoof(List<List<List<SpringJoint2D>>> springList, List<List<Transform>> clusters)
    {
        List<Transform> sidesList = new List<Transform>();
        foreach (Transform side in Sides.GetComponent<Transform>())
        {
            sidesList.Add(side);
        }
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                float tempDist = 1000f;
                int nn = 0;
                for (int k = 0; k < 4; k++)
                {
                    float dist = Vector2.Distance(new Vector2(clusters[i][j].position.x, clusters[i][j].position.y), new Vector2(sidesList[k].position.x, sidesList[k].position.y));
                    if (dist < tempDist)
                    {
                        nn = k;
                        tempDist = dist;
                    }

                }
                springList[i][j][5].connectedBody = sidesList[nn].GetComponent<Rigidbody2D>();
                //clusters[i][j]
                //loop through sides and attach each star based on distance 
            }
        }
    }
    public void ConnectClusters(List<List<List<SpringJoint2D>>> springList, List<List<Transform>> clusters)
    {
        springList[0][0][6].connectedBody = clusters[1][0].GetComponent<Rigidbody2D>();
        springList[0][0][7].connectedBody = clusters[2][0].GetComponent<Rigidbody2D>();
        springList[1][0][6].connectedBody = clusters[3][0].GetComponent<Rigidbody2D>();
        springList[2][0][6].connectedBody = clusters[3][1].GetComponent<Rigidbody2D>();
        springList[2][0][7].connectedBody = clusters[4][0].GetComponent<Rigidbody2D>();
        springList[3][0][6].connectedBody = clusters[5][0].GetComponent<Rigidbody2D>();
        springList[4][0][6].connectedBody = clusters[5][1].GetComponent<Rigidbody2D>();
        springList[4][0][7].connectedBody = clusters[6][0].GetComponent<Rigidbody2D>();
        springList[5][0][6].connectedBody = clusters[7][0].GetComponent<Rigidbody2D>();
        springList[6][0][6].connectedBody = clusters[7][1].GetComponent<Rigidbody2D>();
    }

    IEnumerator WaitForGen(List<List<Transform>> clusters)
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(2);
        ReAddLockandGravConstraint(clusters);
    }

    public void ReAddLockandGravConstraint(List<List<Transform>> clusters)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Rigidbody2D rb = clusters[i][j].GetComponent<Rigidbody2D>();
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                clusters[i][j].GetComponent<Rigidbody2D>().gravityScale = 0f;

            }
        }
    }
}
