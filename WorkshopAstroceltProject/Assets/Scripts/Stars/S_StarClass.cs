using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_StarClass : MonoBehaviour
{
    [Header("The Star Template")]
    public string starType;

    [Header("Class Templates")]
    public S_Star s_star;

    [Header("Displacement Points")]
    public GameObject vectorPoint1;
    public GameObject vectorPoint2;
    public GameObject vectorPoint3;

    [Header("Counter Variable")]
    public int positionCount;

    // These are used to check where to spawn based off the energy tier system 
    [Header("Position States")]
    public bool s_b_point1Used;
    public bool s_b_point2Used;
    public bool s_b_point3Used; 
}
