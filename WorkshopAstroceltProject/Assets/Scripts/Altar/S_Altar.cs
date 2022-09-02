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
    public GameObject cardballSpawnPosition;

    [Header("Card Holder Reference (In Engine)")]
    public GameObject c_cardHolder;

    [Header("Card Spawned Flag")]
    public bool c_b_cardSpawned;

    [Header("DOTween Attributes")]
    public float f_cardballMoveSpeed;

    [Header("Spawning Cardballs")]
    public bool b_spawningCardballs = true; //Used to not let the player press end turn before cardballs begin spawning

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

    /// <summary>
    /// Need to stagger from Awake since it relies on other awake calls to be already set up to start.
    /// Don't want to start too early and get null reference conditions.
    /// Could focribly change script execution of awake calls like done for S_Global though. 
    /// - Josh
    /// </summary>
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
        AddNewCardBall(cardballSpawnPosition, g_global.g_ls_p_playerHand[0]);
        MoveCardballPrefabs();

        // Spawn cardball 2
        yield return new WaitForSeconds(1 + f_cardballMoveSpeed);
        AddNewCardBall(cardballSpawnPosition, g_global.g_ls_p_playerHand[1]);
        MoveCardballPrefabs();

        // Spawn cardball 3
        yield return new WaitForSeconds(1 + f_cardballMoveSpeed + 0.15f);
        AddNewCardBall(cardballSpawnPosition, g_global.g_ls_p_playerHand[2]);
        MoveCardballPrefabs();

        // Spawn cardball 4
        yield return new WaitForSeconds(1 + f_cardballMoveSpeed + 0.25f);
        AddNewCardBall(cardballSpawnPosition, g_global.g_ls_p_playerHand[3]);
        MoveCardballPrefabs();

        yield return new WaitForSeconds(1 + f_cardballMoveSpeed + 0.35f);
        AddNewCardBall(cardballSpawnPosition, g_global.g_ls_p_playerHand[4]);
        MoveCardballPrefabs();

        // Perhaps Tween a fade as they spawn in? Sound on spawn? Things to tweak - Josh

        b_spawningCardballs = false;
    }

    /// <summary>
    /// CardBall Setup and Spawning for when new Cardballs are needed for the altar. 
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
    /// First Remove the current cardball prefabs from the field
    /// gets called from the turn loop when the player is getting updated
    /// pass in true inorder to trigger dealing the cards
    /// -Josh
    /// </summary>
    /// <param name="_newCardBalls"></param>
    /// <returns></returns>
    public IEnumerator ClearCardballPrefabs(bool _newCardBalls)
    {
        Debug.Log(" Debug - Triggered 2");
        foreach (S_Cardball _cardball in g_global.g_ls_cardBallPrefabs.ToList())
        {
            //wait and then remove the cardball from the list and delete it from the game
            yield return new WaitForSeconds(0.5f);
            g_global.g_ls_cardBallPrefabs.Remove(_cardball);
            _cardball.DeleteCardball();
        }

        //clear the player hand since none of these cards were played
        g_global.g_cardManager.ClearPlayerHand();

        //Trigger if the bool is passed
        if (_newCardBalls)
        {
            yield return null; //euivalent but slightly faster for optimization for one second

            //give the player cards to load
            g_global.g_cardManager.DealCards(g_global.g_cardManager.p_i_drawPerTurn);

            StartCoroutine(SpawnCardballPrefabs());
        }
    }

    /// <summary>
    /// Check if the first card can be played and converted into a card based off the current constellation energy that the player has generated.
    /// The trigger mechanism for Cardball to cards.
    /// - Josh
    /// </summary>
    public IEnumerator CheckFirstCardball()
    {
        //check if the card can be played by referencing the useEnergy function
        if(g_global.g_energyManager.useEnergy(cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().c_i_cardEnergyCost, cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().c_cardData.ColorString))
        {
            //turn the cardball into a card and move over the rest of the cardballs
            StartCoroutine(cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().CardballToCard());
            ChangeCard(cardballPosition1.transform.GetChild(0).gameObject);
        }
        yield return null;
    }

    /// <summary>
    /// Move the cardballs to seek up the position chain, should be using the state when called which should prevent problems.
    /// Could be an optimization problem down the line. Perhaps we should detach visuals from this based off MVC advice from Will, and fill from 1-5 otherwise.
    /// Also triggers when a cardball is turned into a card, used to move cardballs up the chain as they get used.
    /// - Josh
    /// </summary>
    /// <returns></returns>
    public void MoveCardballPrefabs()
    {
        if (cardballPosition2.transform.childCount == 1)
        {
            //Debug.Log("Cardball Position 2 Full");
            // Move the cardball from 2 to 1
            cardballPosition2.transform.GetChild(0).DOMove(cardballPosition1.transform.position, f_cardballMoveSpeed);
            cardballPosition2.transform.GetChild(0).SetParent(cardballPosition1.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/cardball-move");
            //Debug.Log("Cardballs moving from 2 to 1");
        }
        if (cardballPosition3.transform.childCount == 1)
        {
            // Move the cardball from 3 to 2
            cardballPosition3.transform.GetChild(0).DOMove(cardballPosition2.transform.position, f_cardballMoveSpeed);
            cardballPosition3.transform.GetChild(0).SetParent(cardballPosition2.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/cardball-move");
            //Debug.Log("Cardballs moving from 3 to 2");
        }
        if (cardballPosition4.transform.childCount == 1)
        {
            // Move the cardball from 4 to 3
            cardballPosition4.transform.GetChild(0).DOMove(cardballPosition3.transform.position, f_cardballMoveSpeed);
            cardballPosition4.transform.GetChild(0).SetParent(cardballPosition3.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/cardball-move");
            //Debug.Log("Cardballs moving from 4 to 3");
        }
        if (cardballPosition5.transform.childCount == 1)
        {
            // Move the cardball from 5 to 4
            cardballPosition5.transform.GetChild(0).DOMove(cardballPosition4.transform.position, f_cardballMoveSpeed);
            cardballPosition5.transform.GetChild(0).SetParent(cardballPosition4.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/cardball-move");
            //Debug.Log("Cardballs moving from 5 to 4");
        }
        if (cardballSpawnPosition.transform.childCount == 1)
        {
            // Move the cardball from Spawn to 5
            cardballSpawnPosition.transform.GetChild(0).DOMove(cardballPosition5.transform.position, f_cardballMoveSpeed);
            cardballSpawnPosition.transform.GetChild(0).SetParent(cardballPosition5.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/cardball-move");
            Debug.Log("Cardballs moving from 5 to 4");
        }
        else
        {
            Debug.Log("DEBUG: No more cardballs to spawn!");
        }

        // May not be necessary, check later, part of race condition debugging between turns. 
        g_global.g_enemyState.UpdateActiveEnemies();
    }

    /// <summary>
    /// Used so the cardball can't delete itself too early and and so we can trigger proper moving of the cardballs
    /// - Josh
    /// </summary>
    /// <returns></returns>
    public IEnumerator WaitForCardballDeletionToMove(GameObject _cardball)
    {
        yield return new WaitForSeconds(1);
        Destroy(_cardball);
        MoveCardballPrefabs();
    }
}
