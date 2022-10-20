using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_StarClass : MonoBehaviour
{
    /////////////////////////////-------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    
    [Header("The Star Template")]
    public string starType;
    public string colorType; 

    [Header("Class Templates")]
    public S_Star s_star;

    [Header("Displacement Points")]
    public GameObject vectorPoint1;
    public GameObject vectorPoint2;
    public GameObject vectorPoint3;

    [Header("Constellation Position Counter(?)")]
    public int positionCount;

    // These are used to check where to spawn based off the energy tier system 
    [Header("Position States")]
    public bool s_b_point1Used;
    public bool s_b_point2Used;
    public bool s_b_point3Used;

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the the first popup parent transform from S_StarClass
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_StarClass.vectorPoint1
    /// </returns>
    public Transform GetPopup1ParentTransform()
    {
        return vectorPoint1.transform;
    }

    /// <summary>
    /// Return the the second popup parent transform from S_StarClass
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_StarClass.vectorPoint2
    /// </returns>
    public Transform GetPopup2ParentTrasnform()
    {
        return vectorPoint2.transform;
    }

    /// <summary>
    /// Return the the third popup parent transform from S_StarClass
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_StarClass.vectorPoint3
    /// </returns>
    public Transform GetPopup3ParentTransform()
    {
        return vectorPoint3.transform;
    }
}
