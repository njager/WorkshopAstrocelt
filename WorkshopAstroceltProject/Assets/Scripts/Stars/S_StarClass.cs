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

    [Header("Position Data for Parent Transforms")]
    [SerializeField] Vector3 s_v3_parentPosition1;
    [SerializeField] Vector3 s_v3_parentPosition2;
    [SerializeField] Vector3 s_v3_parentPosition3;

    [Header("Constellation Position Counter(?)")]
    public int positionCount;

    // These are used to check where to spawn based off the energy tier system 
    [Header("Position States (not in use)")]
    public bool s_b_point1Used;
    public bool s_b_point2Used;
    public bool s_b_point3Used;

    [Header("Temp Star Status")]
    public bool s_b_temporaryVisualBool;

    [Header("Popup Parent Transform Point List")]
    public List<Transform> tr_ls_popupParentTransforms = new List<Transform>();
    public List<S_StarPopUp> ls_energyPopups = new List<S_StarPopUp>();

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Methods \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    private void Awake()
    {
        SetPopup1ParentTransform(GetPopup1ParentTransform().position);
        SetPopup2ParentTransform(GetPopup2ParentTransform().position);
        SetPopup3ParentTransform(GetPopup3ParentTransform().position);
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    
    public void SetAllPopupTransforms()
    {
        SetPopup1ParentTransform(GetPopup1ParentTransform().position);
        SetPopup2ParentTransform(GetPopup2ParentTransform().position);
        SetPopup3ParentTransform(GetPopup3ParentTransform().position);
    }

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

    /// <summary>
    /// Set the position data for S_StarClass.s_v3_parentPosition1
    /// - Josh
    /// </summary>
    /// <returns></returns>
    /// <param name="_status"></param>
    public void SetPopup1ParentTransform(Vector3 _givenPosition)
    {
        s_v3_parentPosition1 = _givenPosition;
    }

    /// <summary>
    /// Set the position data for S_StarClass.s_v3_parentPosition2
    /// - Josh
    /// </summary>
    /// <returns></returns>
    /// <param name="_status"></param>
    public void SetPopup2ParentTransform(Vector3 _givenPosition)
    {
        s_v3_parentPosition2 = _givenPosition;
    }

    /// <summary>
    /// Set the position data for S_StarClass.s_v3_parentPosition3
    /// - Josh
    /// </summary>
    /// <returns></returns>
    /// <param name="_status"></param>
    public void SetPopup3ParentTransform(Vector3 _givenPosition)
    {
        s_v3_parentPosition3 = _givenPosition;
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
    /// Return the the first popup parent transform from S_StarClass.vectorPoint1.transform;
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_StarClass.vectorPoint1.transform
    /// </returns>
    public Transform GetPopup1ParentTransform()
    {
        return vectorPoint1.transform;
    }

    /// <summary>
    /// Return the the second popup parent transform from S_StarClass.vectorPoint2.transform;
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_StarClass.vectorPoint2.transform
    /// </returns>
    public Transform GetPopup2ParentTransform()
    {
        return vectorPoint2.transform;
    }

    /// <summary>
    /// Return the the third popup parent transform from S_StarClass.vectorPoint3.transform;
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_StarClass.vectorPoint3.transform
    /// </returns>
    public Transform GetPopup3ParentTransform()
    {
        return vectorPoint3.transform;
    }

    /// <summary>
    /// Return the the first popup parent position from S_StarClass.s_v3_parentPosition1
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_StarClass.s_v3_parentPosition1
    /// </returns>
    public Vector3 GetPopup1ParentPosition()
    {
        return s_v3_parentPosition1;
    }

    /// <summary>
    /// Return the the second popup parent position from S_StarClass.s_v3_parentPosition2
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_StarClass.s_v3_parentPosition2
    /// </returns>
    public Vector3 GetPopup2ParentPosition()
    {
        return s_v3_parentPosition2;
    }

    /// <summary>
    /// Return the the third popup parent position from S_StarClass.s_v3_parentPosition3
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_StarClass.s_v3_parentPosition3
    /// </returns>
    public Vector3 GetPopup3ParentPosition()
    {
        return s_v3_parentPosition3;
    }
}
