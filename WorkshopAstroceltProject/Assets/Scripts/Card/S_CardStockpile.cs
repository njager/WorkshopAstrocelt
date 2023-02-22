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
    [SerializeField] Transform crd_stockpileTopPosition;

    [Header("Card Stockpile List")]
    [SerializeField] List<(GameObject, int)> lst_crd_stockpile = new List<(GameObject, int)>();

    /// <summary>
    /// When player clicks on the stockpile locator, swap between the stockpiled cards positions, bringing them to the forefront
    /// - Josh
    /// </summary>
    public void OnClick() 
    {
        if(crd_i_stockpileTotalIndex <= 5) 
        {
            return;
        }
        else 
        {
            // Increment count for visual changes 
            crd_i_stockpileClickCount += 1;


        }
    }

    /// <summary>
    /// Determine the visual positions based off index
    /// - Josh
    /// </summary>
    public void SortCardPositions() 
    {
        foreach ((GameObject, int) _stockpileEntry in lst_crd_stockpile.ToList())
        {
            if(_stockpileEntry.Item2 == 0) 
            {
                _stockpileEntry.Item1.transform.position = crd_stockpileTopPosition.position;
            }
            else // Determine subsequent positions
            {
                float _indexBasedXValue = _stockpileEntry.Item2 * 1.1f;

                // Build dynamic position
                Vector3 _calculatedPositon = new Vector3(crd_stockpileTopPosition.position.x + _indexBasedXValue, crd_stockpileTopPosition.position.y, crd_stockpileTopPosition.position.z + _stockpileEntry.Item2);

                // Set position for card
                _stockpileEntry.Item1.transform.position = _calculatedPositon;
            }
        }
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

        // Now Sort Cards
        SortCardPositions();
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

        // Now Sort Cards
        SortCardPositions();
    }

    /// <summary>
    /// 
    /// - Josh
    /// </summary>
    public void OnPointerEnter() 
    {

    }

    /// <summary>
    /// Method to return the first index card to it's original position on Pointer Exit
    /// </summary>
    public void OnPointerExit() 
    {
        
    }

    // Add check to now to toggle stockpile bool when cards get added and positions 1-5 are filled
}
