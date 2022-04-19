using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq; 

public class S_Altar : MonoBehaviour
{
    private S_Global g_global;

    [Header("Text Boxes")]
    public TextMeshProUGUI c_tx_cardName;
    public TextMeshProUGUI c_tx_cardBody;

    [Header("Borders")]
    public GameObject a_colorlessBorder;
    public GameObject a_redBorder;
    public GameObject a_blueBorder;
    public GameObject a_yellowBorder;

    [Header("Cardball Prefab")]
    public GameObject cardBallPrefab; 

    [Header("Cardball Positions")]
    public GameObject ballPosition1;
    public GameObject ballPosition2;
    public GameObject ballPosition3;
    public GameObject ballPosition4;
    public GameObject ballPosition5;

    [Header("Card Holder Reference")]
    public GameObject c_cardHolder; 

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

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


    /// <summary>
    /// Initial Star Funciton
    /// </summary>
    public void CardballFirstStart()
    {
        // Fill Position 5

        // Fill Position 4

        // Fill Position 3

        // Fill Position 2

        // Fill Position 1
    }

    /// <summary>
    /// Spawn at Position 5
    /// </summary>
    public void AddNewCardBall()
    {

    }

    /// <summary>
    /// First Remove the current cardball prefabs
    /// -Josh
    /// </summary>
    public void ClearCardballs()
    {
        foreach (S_Cardball _cardball in g_global.ls_cardBallPrefabs.ToList())
        {
            _cardball.gameObject.SetActive(false);
            g_global.ls_cardBallPrefabs.Remove(_cardball);
        }
    }
}
