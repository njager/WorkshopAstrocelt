using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using DG.Tweening;

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
    public GameObject c_cardballPrefab; 

    [Header("Cardball Positions")]
    public GameObject cardballPosition1;
    public GameObject cardballPosition2;
    public GameObject cardballPosition3;
    public GameObject cardballPosition4;
    public GameObject cardballPosition5;

    [Header("Card Holder Reference")]
    public GameObject c_cardHolder;

    [Header("DOTween Attributes")]
    public float f_moveSpeed;

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    private void Start()
    {
        StartCoroutine(SpawnCardballPrefabs());
    }

    /// <summary>
    /// This method gets called when the first card in the altar changes
    /// It changes all the text on the altar and the color borders
    /// - Riley and Josh
    /// </summary>
    /// <param name="_card"></param>
    public void ChangeCard(GameObject _cardball)
    {
        //change the text boxes
        S_Cardball _cardballScript = _cardball.GetComponent<S_Cardball>();
        c_tx_cardName.text = _cardballScript.c_cardName;
        c_tx_cardBody.text = _cardballScript.c_cardBody;

        //set the border color to match the cards
        if (_cardballScript.c_b_redCardball)
        {
            // Red card
            a_redBorder.SetActive(true);

            // Rest are false
            a_blueBorder.SetActive(false);
            a_yellowBorder.SetActive(false);
            a_colorlessBorder.SetActive(false);
        }
        else if (_cardballScript.c_b_blueCardball)
        {
            // Blue card
            a_blueBorder.SetActive(true);

            // Rest are false
            a_redBorder.SetActive(false);
            a_yellowBorder.SetActive(false);
            a_colorlessBorder.SetActive(false);
        }
        else if (_cardballScript.c_b_redCardball)
        {
            // Yellow card
            a_yellowBorder.SetActive(true);

            // Rest are false
            a_redBorder.SetActive(false);
            a_blueBorder.SetActive(false);
            a_colorlessBorder.SetActive(false);
        }
        else if(_cardballScript.c_b_colorlessCardball)
        {
            // White card
            a_colorlessBorder.SetActive(true);

            // rest are false
            a_redBorder.SetActive(false);
            a_blueBorder.SetActive(false);
            a_yellowBorder.SetActive(false);
        }
        else
        {
            Debug.Log("_cardballScript was null!");
        }
    }

    /// <summary>
    /// Initial Start Funciton
    /// Fill with 5 cardballs
    /// May be fully temporary
    /// - Josh
    /// </summary>
    public IEnumerator SpawnCardballPrefabs()
    {
        yield return new WaitForSeconds(1);
    }

    /// <summary>
    /// CardBall Setup and Spawning
    /// - Josh
    /// </summary>
    public void AddNewCardBall(GameObject _cardballPosition, S_CardTemplate _cardTemplate)
    {
        // Instantiate Cardball
        GameObject c_cardball = Instantiate(c_cardballPrefab, Vector3.zero, Quaternion.identity);
        c_cardball.transform.SetParent(_cardballPosition.transform, false);
        
        // Grab card ball script
        S_Cardball _cardballScript = c_cardball.GetComponent<S_Cardball>();

        // Setup cardball (this is where it'd be loaded with it's scriptable object
        _cardballScript.c_cardData = _cardTemplate;
        _cardballScript.CardballSetup();
    }

    /// <summary>
    /// First Remove the current cardball prefabs
    /// -Josh
    /// </summary>
    public void ClearCardballPrefabs()
    {
        foreach (S_Cardball _cardball in g_global.ls_cardBallPrefabs.ToList())
        {
            _cardball.gameObject.SetActive(false);
            g_global.ls_cardBallPrefabs.Remove(_cardball);
        }
    }

    public void CheckFirstCardball()
    {
        if(g_global.g_energyManager.useEnergy(cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().c_i_cardEnergyCost, cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().c_cardData.ColorString))
        {
            cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().CardballToCard();
        }
        else
        {
            Debug.Log("Not enough energy!");
        }
    }

    /// <summary>
    /// Triggers when a cardball is turned into a card
    /// </summary>
    /// <returns></returns>
    public void MoveCardballPrefabs()
    {
        if (cardballPosition1.transform.childCount == 0) // Start chain at position 1
        {
            Debug.Log("Cardball Position 1 Empty");
            if (cardballPosition2.transform.transform.childCount == 1)
            {
                Debug.Log("Cardball Position 2 Full");
                // Move the cardball from 2 to 1
                cardballPosition2.transform.GetChild(0).DOMove(cardballPosition1.transform.position, f_moveSpeed);
                cardballPosition2.transform.GetChild(0).SetParent(cardballPosition1.transform);
                Debug.Log("Cardballs moving from 2 to 1");
            }
            if (cardballPosition3.transform.transform.childCount == 1)
            {
                // Move the cardball from 3 to 2
                cardballPosition3.transform.GetChild(0).DOMove(cardballPosition2.transform.position, f_moveSpeed);
                cardballPosition3.transform.GetChild(0).SetParent(cardballPosition2.transform);
                Debug.Log("Cardballs moving from 3 to 2");
            }
            if(cardballPosition4.transform.transform.childCount == 1)
            {
                // Move the cardball from 4 to 3
                cardballPosition4.transform.GetChild(0).DOMove(cardballPosition3.transform.position, f_moveSpeed);
                cardballPosition4.transform.GetChild(0).SetParent(cardballPosition3.transform);
                Debug.Log("Cardballs moving from 4 to 3");
            }
            if (cardballPosition5.transform.transform.childCount == 1)
            {
                // Move the cardball from 5 to 4
                cardballPosition5.transform.GetChild(0).DOMove(cardballPosition4.transform.position, f_moveSpeed);
                cardballPosition5.transform.GetChild(0).SetParent(cardballPosition4.transform);
                Debug.Log("Cardballs moving from 5 to 4");
            }
        }
        else
        {
            Debug.Log("Cardball Position 1 Full");
        }
    }
}
