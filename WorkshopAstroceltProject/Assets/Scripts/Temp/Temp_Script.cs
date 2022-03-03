using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_Script : MonoBehaviour
{
    public GameObject spawnObject;


    void Start()
    {
        for(int i=0; i<5; i++)
        {
            GameObject playerCard = Instantiate(spawnObject, new Vector3(0, 0, 0), Quaternion.identity);
            playerCard.transform.SetParent(this.gameObject.transform, false);
        }
    }

    
}
