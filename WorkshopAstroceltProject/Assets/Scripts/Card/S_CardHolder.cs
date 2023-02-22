using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CardHolder : MonoBehaviour
{
    // Left to right which doesn't follow this order for spawning

    [Header("Card Positions")]
    [SerializeField] GameObject crd_cardPosition1;
    [SerializeField] GameObject crd_cardPosition2;
    [SerializeField] GameObject crd_cardPosition3;
    [SerializeField] GameObject crd_cardPosition4;
    [SerializeField] GameObject crd_cardPosition5;

    [Header("Card's Filled Bool Check")]
    [SerializeField] bool crd_b_cardPosition1Occupied;
    [SerializeField] bool crd_b_cardPosition2Occupied;
    [SerializeField] bool crd_b_cardPosition3Occupied;
    [SerializeField] bool crd_b_cardPosition4Occupied;
    [SerializeField] bool crd_b_cardPosition5Occupied;

    [Header("Next Position Index")]
    [SerializeField] int crd_i_nextPositionIndex;

    [Header("Card Stockpile Script")]
    [SerializeField] S_CardStockpile crd_stockpileScript;

    public int NextCardPosition() 
    {
        if(crd_cardPosition1.transform.childCount == 0 && crd_cardPosition2.transform.childCount == 0 && crd_cardPosition3.transform.childCount == 0 && crd_cardPosition4.transform.childCount == 0 && crd_cardPosition5.transform.childCount == 0) 
        {
            return 3; // Start at card position 3 
        }
        else if (crd_cardPosition1.transform.childCount == 0 && crd_cardPosition2.transform.childCount == 0 && crd_cardPosition3.transform.childCount == 1 && crd_cardPosition4.transform.childCount == 0 && crd_cardPosition5.transform.childCount == 0) 
        {
            return 4; // Then spawn to the right
        }
        else if (crd_cardPosition1.transform.childCount == 0 && crd_cardPosition2.transform.childCount == 0 && crd_cardPosition3.transform.childCount == 1 && crd_cardPosition4.transform.childCount == 1 && crd_cardPosition5.transform.childCount == 0)
        {
            return 2; // Then spawn to the left
        }
        else if (crd_cardPosition1.transform.childCount == 0 && crd_cardPosition2.transform.childCount == 1 && crd_cardPosition3.transform.childCount == 1 && crd_cardPosition4.transform.childCount == 1 && crd_cardPosition5.transform.childCount == 0)
        {
            return 5; // Then spawn to the right, again
        }
        else if (crd_cardPosition1.transform.childCount == 0 && crd_cardPosition2.transform.childCount == 1 && crd_cardPosition3.transform.childCount == 1 && crd_cardPosition4.transform.childCount == 1 && crd_cardPosition5.transform.childCount == 1)
        {
            return 5; // Then spawn to the left, again
        }
        else // no more positions 
        {
            Debug.Log("UNEXPECTED RETURN IN S_CARDHOLDER!");
            return -1;
        }
    }

    /////////////////////////////--------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the int value of S_CardHolderManager.c_i_positionToSpawnAtNextIndex;
    /// - Josh 
    /// </summary>
    /// <param name="_cardPositionNum"></param>
    public void SetCardPositionInt(int _cardPositionNum) 
    {
        crd_i_nextPositionIndex = _cardPositionNum;
    }

    /////////////////////////////--------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the int value of S_CardHolderManager.c_i_positionToSpawnAtNextIndex;
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_CardHolderManager.c_i_positionToSpawnAtNextIndex;
    /// </returns>
    public int GetCardPositionInt() 
    {
        return crd_i_nextPositionIndex;
    }

    /// <summary>
    /// Return the transform of a given card position's index/int
    /// - Josh
    /// </summary>
    /// <param name="_givenCardPositionNum"></param>
    /// <returns>
    /// S_CardHolderManager.c_cardPosition1.transform || S_CardHolderManager.c_cardPosition2.transform || S_CardHolderManager.c_cardPosition3.transform || S_CardHolderManager.c_cardPosition4.transform || S_CardHolderManager.c_cardPosition5.transform
    /// </returns>
    public Transform GetCardPositionTransform(int _givenCardPositionNum) 
    {
        if(_givenCardPositionNum == 1) // If given an int of 1, return c_cardPosition1.transform;
        {
            return crd_cardPosition1.transform;
        }
        else if (_givenCardPositionNum == 2) // If given an int of 2, return c_cardPosition2.transform;
        {
            return crd_cardPosition2.transform;
        }
        else if (_givenCardPositionNum == 3) // If given an int of 3, return c_cardPosition3.transform;
        {
            return crd_cardPosition3.transform;
        }
        else if (_givenCardPositionNum == 4) // If given an int of 4, return c_cardPosition4.transform;
        {
            return crd_cardPosition4.transform;
        }
        else if (_givenCardPositionNum == 5) // If given an int of 5, return c_cardPosition5.transform;
        {
            return crd_cardPosition5.transform;
        }
        else
        {
            Debug.Log("UNEXPECTED RETURN IN S_CARDHOLDER!");
            return null;
        }
    }
}
