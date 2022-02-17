using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_Script : MonoBehaviour
{
    public GameObject spawnObject;


    void Start()
    {
        GameObject playerCard = Instantiate(spawnObject, new Vector3(0, 0, 0), Quaternion.identity);
        playerCard.transform.SetParent(this.gameObject.transform, false);
        GameObject playerCard2 = Instantiate(spawnObject, new Vector3(0, 0, 0), Quaternion.identity);
        playerCard2.transform.SetParent(this.gameObject.transform, false);
        GameObject playerCard3 = Instantiate(spawnObject, new Vector3(0, 0, 0), Quaternion.identity);
        playerCard3.transform.SetParent(this.gameObject.transform, false);
    }

    
}
