using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CardStockpile : MonoBehaviour
{
    [Header("Card Stockpile Click Count")]
    public int crd_i_stockpileClickCount;

    [Header("Card Stockpile Positions")]
    public GameObject crd_stockpileTopPosition;

    /// <summary>
    /// When player clicks on the stockpile locator, swap between the stockpiled cards positions, bringing them to the forefront
    /// </summary>
    public void OnClick() 
    {

    }
}
