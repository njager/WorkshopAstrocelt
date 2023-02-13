using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class S_CardStockpile : MonoBehaviour
{
    [Header("Card Stockpile Click Count")]
    [SerializeField] int crd_i_stockpileClickCount;

    [Header("Stockpile Total Index")]
    [SerializeField] int crd_i_stockpileTotalIndex;

    [Header("Card Stockpile Positions")]
    [SerializeField] GameObject crd_stockpileTopPosition;

    [Header("Card Stockpile List")]
    [SerializeField] List<(GameObject, int)> lst_crd_stockpile = new List<(GameObject, int)>();

    /// <summary>
    /// When player clicks on the stockpile locator, swap between the stockpiled cards positions, bringing them to the forefront
    /// </summary>
    public void OnClick() 
    {
        // Increment count for visual changes 
        crd_i_stockpileClickCount += 1;
    }

    public void AddCardToStockpile(GameObject _card) 
    {
        // Increment Index
        crd_i_stockpileTotalIndex += 1;

        // Add card from list
        lst_crd_stockpile.Add((_card, crd_i_stockpileTotalIndex));
    }

    public void RemoveCardFromStockpile(GameObject _card) 
    {
        // Increment Index
        crd_i_stockpileTotalIndex -= 1;

        // Find it's index through card

        // Add card from list
        lst_crd_stockpile.Remove(_card);
    }

    // Add boolean toggle in S_Card for if in stockpile or not

    // Add check to now to toggle stockpile bool when cards get added and positions 1-5 are filled
}
