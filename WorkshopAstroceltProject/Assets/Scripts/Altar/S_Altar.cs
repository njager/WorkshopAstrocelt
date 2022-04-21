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

    [Header("Variables for cardball moving")]
    public bool c_b_finishedMoving;

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

    public void CheckFirstCardBall()
    {

    }

    /// <summary>
    /// Triggers when a cardball is turned into a card
    /// </summary>
    /// <returns></returns>
    public void MoveCardballPrefabs()
    {
        if (cardballPosition4.transform.childCount == 0)
        {
            if (cardballPosition5.transform.childCount == 1)
            {

            }
            else
            {
                Debug.Log("CardBall 5 empty too!");
            }
        }
    }
}
