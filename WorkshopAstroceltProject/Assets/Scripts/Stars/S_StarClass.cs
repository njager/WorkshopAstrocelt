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
}
