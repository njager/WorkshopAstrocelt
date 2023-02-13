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
    /// - Josh
    /// </summary>
    public void OnClick() 
    {
        // Increment count for visual changes 
        crd_i_stockpileClickCount += 1;
    }

    /// <summary>
    /// Method to Add a Card to the Stockpile
    /// - Josh
    /// </summary>
    /// <param name="_card"></param>
    public void AddCardToStockpile(GameObject _card) 
    {
        // Increment Total Index
        crd_i_stockpileTotalIndex += 1;

        // Add card from list
        lst_crd_stockpile.Add((_card, crd_i_stockpileTotalIndex));

        // Set Card's Stockpile Status in Card
        _card.GetComponent<S_Card>().SetCardStockpileStatusBool(true);

        // Set Card's Stockpile Index in Card
        _card.GetComponent<S_Card>().SetCardStockpileListIndex(crd_i_stockpileTotalIndex);
    }

    /// <summary>
    /// Method to remove a Card from the stockpile
    /// - Josh
    /// </summary>
    /// <param name="_card"></param>
    public void RemoveCardFromStockpile(GameObject _card) 
    {
        // Decrement Total Index
        crd_i_stockpileTotalIndex -= 1;

        // Find it's index through card
        int _cardIndex = _card.GetComponent<S_Card>().GetCardStockpileListIndex(); 

        // Add card from list
        lst_crd_stockpile.Remove((_card, _cardIndex));

        // Set Card's Stockpile Status in Card
        _card.GetComponent<S_Card>().SetCardStockpileStatusBool(false);

        // Set Card's Stockpile Index in Card
        _card.GetComponent<S_Card>().SetCardStockpileListIndex(0);
    }
    

    // Add boolean toggle in S_Card for if in stockpile or not

    // Add check to now to toggle stockpile bool when cards get added and positions 1-5 are filled
}
