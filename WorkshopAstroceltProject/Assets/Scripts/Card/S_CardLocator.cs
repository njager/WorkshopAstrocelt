using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CardLocator : MonoBehaviour
{
    [Header("Corresponding Card Position Object")]
    [SerializeField] GameObject crd_cardPosition;

    [Header("Card Position Object Base Position")]
    [SerializeField] Transform crd_basePosition;

    [Header("Card Position Object Top Position")]
    [SerializeField] Transform crd_topPosition;

    [Header("Card Position Index")] // May be unnecessary but just in case, possible debug use - Josh
    [SerializeField] int crd_i_cardPositionIndex;

    /// <summary>
    /// Method to return the first index card to top position on Pointer Enter
    /// - Josh
    /// </summary>
    public void OnPointerEnter()
    {
        // Move card stockpile stack up
        crd_cardPosition.transform.position = crd_topPosition.position;
    }

    /// <summary>
    /// Method to return the first index card to it's original position on Pointer Exit
    /// - Josh
    /// </summary>
    public void OnPointerExit()
    {
        // Move card stockpile stack back
        crd_cardPosition.transform.position = crd_basePosition.position;
    }
}
