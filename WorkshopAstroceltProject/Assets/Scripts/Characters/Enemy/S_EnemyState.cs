using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyState : MonoBehaviour
{
    private S_Global g_global;

    void Awake()
    {
        g_global = S_Global.g_instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(g_global.g_enemyAttributeSheet == false)
        {

        }
    }
}
