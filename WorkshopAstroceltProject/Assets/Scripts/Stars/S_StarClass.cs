using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_StarClass : MonoBehaviour
{
    /////////////////////////////--------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
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

    [Header("Temp Star Status")]
    public bool s_b_temporaryVisualBool;

    [Header("Popup Parent Transform Point List")]
    public List<Transform> tr_ls_popupParentTransforms = new List<Transform>();

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the bool value of S_StarClass.s_b_temporaryVisualBool
    /// False - not temporary visual, true - temporary visual
    /// - Josh
    /// </summary>
    /// <returns></returns>
    /// <param name="_status"></param>
    public void SetTemporaryVisualBool(bool _status)
    {
        s_b_temporaryVisualBool = _status;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the bool value of S_StarClass.s_b_temporaryVisualBool
    /// False - not temporary visual, true - temporary visual
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_StarClass.s_b_temporaryVisualBool
    /// </returns>
    public bool GetTemporaryVisualBool()
    {
        return s_b_temporaryVisualBool;
    }

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
    public Transform GetPopup2ParentTransform()
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
