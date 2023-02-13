using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CardStockpile : MonoBehaviour
{
    [Header("Card Stockpile Click Count")]
    public int crd_i_stockpileClickCount;

    [Header("Card Stockpile Positions")]
    public GameObject crd_stockpileTopPosition;

    [Header("Card Stockpile List")]
    public List<GameObject> ls_crd_stockpile = new List<GameObject>();

    /// <summary>
    /// When player clicks on the stockpile locator, swap between the stockpiled cards positions, bringing them to the forefront
    /// </summary>
    public void OnClick() 
    {

    }

    private void AddCardToStockpile() 
    {

    }

    private void RemoveCardFromStockpile() 
    {

    }
}
