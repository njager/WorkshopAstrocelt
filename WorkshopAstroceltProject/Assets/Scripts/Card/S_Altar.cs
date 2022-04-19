using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_Altar : MonoBehaviour
{
    [Header("Text Boxes")]
    public TextMeshProUGUI c_tx_cardName;
    public TextMeshProUGUI c_tx_cardBody;

    [Header("Borders")]
    public GameObject a_colorlessBorder;
    public GameObject a_redBorder;
    public GameObject a_blueBorder;
    public GameObject a_yellowBorder;


    /// <summary>
    /// THis method gets called when the first card in the altar changes
    /// It changes all the text and the border
    /// </summary>
    /// <param name="_card"></param>
    public void ChangeCard(S_Card _card)
    {
        //change the text boxes
        c_tx_cardName.text = _card.c_str_headerText;
        c_tx_cardBody.text = _card.c_str_bodyText;

        //set the border color to match the cards
        if (_card.c_b_blueColorType)
        {
            a_colorlessBorder.SetActive(false);
            a_redBorder.SetActive(false);
            a_blueBorder.SetActive(true);
            a_yellowBorder.SetActive(false);
        }
        else if (_card.c_b_redColorType)
        {
            a_colorlessBorder.SetActive(false);
            a_redBorder.SetActive(true);
            a_blueBorder.SetActive(false);
            a_yellowBorder.SetActive(false);
        }
        else if (_card.c_b_yellowColorType)
        {
            a_colorlessBorder.SetActive(false);
            a_redBorder.SetActive(false);
            a_blueBorder.SetActive(false);
            a_yellowBorder.SetActive(true);
        }
        else 
        {
            a_colorlessBorder.SetActive(true);
            a_redBorder.SetActive(false);
            a_blueBorder.SetActive(false);
            a_yellowBorder.SetActive(false);
        }
    }
}
