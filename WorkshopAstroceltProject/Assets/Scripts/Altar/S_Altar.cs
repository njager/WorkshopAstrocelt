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

    [Header("Card Spawned Flag")]
    public bool c_b_cardSpawned;

    [Header("DOTween Attributes")]
    public float f_moveSpeed;

    private void Awake()
    {
        g_global = S_Global.Instance;

        // Set Altar Text for no cardballs
        c_tx_cardName.text = "";
        c_tx_cardBody.text = "";

        // Turn off all borders
        a_redBorder.SetActive(false);
        a_blueBorder.SetActive(false);
        a_yellowBorder.SetActive(false);
        a_colorlessBorder.SetActive(false);
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

        //set all the borders to false
        a_blueBorder.SetActive(false);
        a_redBorder.SetActive(false);
        a_yellowBorder.SetActive(false);
        a_colorlessBorder.SetActive(false);

        //set the border color to match the cards
        if (_cardballScript.c_b_redCardball) { a_redBorder.SetActive(true); }
        else if (_cardballScript.c_b_blueCardball) { a_blueBorder.SetActive(true); }
        else if (_cardballScript.c_b_redCardball) { a_yellowBorder.SetActive(true); }
        else if(_cardballScript.c_b_colorlessCardball) { a_colorlessBorder.SetActive(true); }
        else { Debug.Log("_cardballScript was null!"); }
    }

    /// <summary>
    /// Initial Start Funciton
    /// Fill with 5 cardballs
    /// May be fully temporary
    /// - Josh
    /// </summary>
    public IEnumerator SpawnCardballPrefabs()
    {
        // Spawn cardball 1
        yield return new WaitForSeconds(1);
        AddNewCardBall(cardballPosition5, g_global.g_ls_p_playerHand[0]);
        MoveCardballPrefabs();

        // Spawn cardball 2
        yield return new WaitForSeconds(1 + f_moveSpeed);
        AddNewCardBall(cardballPosition5, g_global.g_ls_p_playerHand[1]);
        MoveCardballPrefabs();

        // Spawn cardball 3
        yield return new WaitForSeconds(1 + f_moveSpeed + 0.1f);
        AddNewCardBall(cardballPosition5, g_global.g_ls_p_playerHand[2]);
        MoveCardballPrefabs();

        // Spawn cardball 4
        yield return new WaitForSeconds(1 + f_moveSpeed + 0.2f);
        AddNewCardBall(cardballPosition5, g_global.g_ls_p_playerHand[3]);
        MoveCardballPrefabs();

        yield return new WaitForSeconds(1 + f_moveSpeed + 0.3f);
        AddNewCardBall(cardballPosition5, g_global.g_ls_p_playerHand[4]);
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
    public IEnumerator ClearCardballPrefabs()
    {
        foreach (S_Cardball _cardball in g_global.g_ls_cardBallPrefabs.ToList())
        {
            yield return new WaitForSeconds(0.5f);
            g_global.g_ls_cardBallPrefabs.Remove(_cardball);
            Destroy(_cardball.gameObject);
        }
    }

    /// <summary>
    /// Check if the first card can be played and converted into a card
    /// </summary>
    public void CheckFirstCardball()
    {
        //check if the card can be played by referencing the useEnergy function
        if(g_global.g_energyManager.useEnergy(cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().c_i_cardEnergyCost, cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().c_cardData.ColorString))
        {
            cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().CardballToCard();
            ChangeCard(cardballPosition1.transform.GetChild(0).gameObject);
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
        if (cardballPosition2.transform.transform.childCount == 1)
        {
            //Debug.Log("Cardball Position 2 Full");
            // Move the cardball from 2 to 1
            cardballPosition2.transform.GetChild(0).DOMove(cardballPosition1.transform.position, f_moveSpeed);
            cardballPosition2.transform.GetChild(0).SetParent(cardballPosition1.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/cardball-move");
            //Debug.Log("Cardballs moving from 2 to 1");
        }
        if (cardballPosition3.transform.transform.childCount == 1)
        {
            // Move the cardball from 3 to 2
            cardballPosition3.transform.GetChild(0).DOMove(cardballPosition2.transform.position, f_moveSpeed);
            cardballPosition3.transform.GetChild(0).SetParent(cardballPosition2.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/cardball-move");
            //Debug.Log("Cardballs moving from 3 to 2");
        }
        if (cardballPosition4.transform.transform.childCount == 1)
        {
            // Move the cardball from 4 to 3
            cardballPosition4.transform.GetChild(0).DOMove(cardballPosition3.transform.position, f_moveSpeed);
            cardballPosition4.transform.GetChild(0).SetParent(cardballPosition3.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/cardball-move");
            //Debug.Log("Cardballs moving from 4 to 3");
        }
        if (cardballPosition5.transform.transform.childCount == 1)
        {
            // Move the cardball from 5 to 4
            cardballPosition5.transform.GetChild(0).DOMove(cardballPosition4.transform.position, f_moveSpeed);
            cardballPosition5.transform.GetChild(0).SetParent(cardballPosition4.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/cardball-move");
            //Debug.Log("Cardballs moving from 5 to 4");
        }
    }

    /// <summary>
    /// Can't delete itself and trigger proper moving
    /// </summary>
    /// <returns></returns>
    public IEnumerator WaitForCardballDeletionToMove(GameObject _cardball)
    {
        yield return new WaitForSeconds(1);
        Destroy(_cardball);
        MoveCardballPrefabs();
    }
}
