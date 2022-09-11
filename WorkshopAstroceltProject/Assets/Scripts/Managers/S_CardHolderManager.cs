using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CardHolderManager : MonoBehaviour
{
    // Left to right which doesn't follow this order for spawning

    [Header("Card Positions")]
    public GameObject c_cardPosition1;
    public GameObject c_cardPosition2;
    public GameObject c_cardPosition3;
    public GameObject c_cardPosition4;
    public GameObject c_cardPosition5;

    [Header("Next Position Index")]
    public int c_i_positionToSpawnAtNextIndex;

    private void Update()
    {
        SetCardPositionInt(NextCardPosition()); // Move to where card's spawn
    }

    public int NextCardPosition() 
    {
        if(c_cardPosition1.transform.childCount == 0 && c_cardPosition2.transform.childCount == 0 && c_cardPosition3.transform.childCount == 0 && c_cardPosition4.transform.childCount == 0 && c_cardPosition5.transform.childCount == 0) 
        {
            return 3; // Start at card position 3 
        }
        else if (c_cardPosition1.transform.childCount == 0 && c_cardPosition2.transform.childCount == 0 && c_cardPosition3.transform.childCount == 1 && c_cardPosition4.transform.childCount == 0 && c_cardPosition5.transform.childCount == 0) 
        {
            return 4; // Then spawn to the right
        }
        else if (c_cardPosition1.transform.childCount == 0 && c_cardPosition2.transform.childCount == 0 && c_cardPosition3.transform.childCount == 1 && c_cardPosition4.transform.childCount == 1 && c_cardPosition5.transform.childCount == 0)
        {
            return 2; // Then spawn to the left
        }
        else if (c_cardPosition1.transform.childCount == 0 && c_cardPosition2.transform.childCount == 1 && c_cardPosition3.transform.childCount == 1 && c_cardPosition4.transform.childCount == 1 && c_cardPosition5.transform.childCount == 0)
        {
            return 5; // Then spawn to the right, again
        }
        else if (c_cardPosition1.transform.childCount == 0 && c_cardPosition2.transform.childCount == 1 && c_cardPosition3.transform.childCount == 1 && c_cardPosition4.transform.childCount == 1 && c_cardPosition5.transform.childCount == 1)
        {
            return 5; // Then spawn to the left, again
        }
        else // no more positions 
        {
            Debug.Log("UNEXPECTED RETURN IN S_CARDHOLDER!");
            return -1;
        }
    }

    // Setters \\

    /// <summary>
    /// Set the int value of S_CardHolderManager.c_i_positionToSpawnAtNextIndex;
    /// - Josh 
    /// </summary>
    /// <param name="_cardPositionNum"></param>
    public void SetCardPositionInt(int _cardPositionNum) 
    {
        c_i_positionToSpawnAtNextIndex = _cardPositionNum;
    }

    // Getters \\

    /// <summary>
    /// Return the int value of S_CardHolderManager.c_i_positionToSpawnAtNextIndex;
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_CardHolderManager.c_i_positionToSpawnAtNextIndex;
    /// </returns>
    public int GetCardPositionInt() 
    {
        return c_i_positionToSpawnAtNextIndex;
    }
}
