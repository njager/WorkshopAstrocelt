using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DrawingManager : MonoBehaviour
{
    private S_Global g_global;

    private void Awake()
    {
        g_global = S_Global.g_instance;
    }

    /// <summary>
    /// This is the script that spawns the line renderer for the star map
    /// It does not check if the stars alread have lines attached to them, but 
    /// the line renderer will tell this script in a different function if there is collision or not
    /// - Riley
    /// </summary>
    public void SpawnLine(Vector2 _loc1, Vector2 _loc2)
    {
        //spawn a line renderer and place it at the two locations
    }

    //public S_Star 
}
