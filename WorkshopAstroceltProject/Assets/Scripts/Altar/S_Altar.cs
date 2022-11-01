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

    [Header("Spawning Cardballs Bool")]
    public bool b_cardballsSpawned;

    [Header("Movement Counter")]
    public int c_i_movementInt;
    public bool c_b_movementBool;

    [Header("Delayed Card Checking Bool")]
    public bool b_cardballDelay;
    public bool b_lastCard;

    [Header("Active Card bool")]
    public bool cd_b_cardIsActive;

    [Header("Null Object")]
    [SerializeField] GameObject nullObject;

    [Header("Tooltip Template")]
    [SerializeField] S_TooltipTemplate tl_altarTooltipTemplate;

    [Header("Mouse Enter Check")]
    public bool tl_b_mouseEntered;

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
        StartCoroutine(SpawnCardballPrefabs(5));
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
    }

    /// <summary>
    /// Initial Start Funciton
    /// Fill with 5 cardballs
    /// May be fully temporary
    /// - Josh
    /// </summary>
    public IEnumerator SpawnCardballPrefabs(int _numCards)
    {
        c_i_movementInt = 0;


        //set the constellation manager bools until the card balls finish spawning
        StartCoroutine(g_global.g_ConstellationManager.CardballSpawnCheck());

        for (int i = 0; i < _numCards; i++)
        {
            yield return new WaitForSeconds(1);
            AddNewCardBall(cardballSpawnPosition, g_global.g_ls_p_playerHand[i]);
            StartCoroutine(MoveCardballPrefabs());
        }

        // Perhaps Tween a fade as they spawn in? Sound on spawn? Things to tweak - Josh

        yield return new S_WaitForCardballMovement();

        // Wait for move cardballs, and then unlock drawing
        //yield return new WaitForSeconds(1 + f_cardballMoveSpeed);
        SetCardballsSpawnedBool(true);
    }

    /// <summary>
    /// CardBall Setup and Spawning for when new Cardballs are needed for the altar. 
    /// - Josh
    /// </summary>
    public void AddNewCardBall(GameObject _cardballPosition, S_CardTemplate _cardTemplate)
    {
        Debug.Log(_cardTemplate);

        // Instantiate Cardball
        GameObject c_cardball = Instantiate(c_cardballPrefab, Vector3.zero, Quaternion.identity);
        c_cardball.transform.SetParent(_cardballPosition.transform, false);

        Debug.Log(c_cardball.transform.parent);
        
        // Grab card ball script
        S_Cardball _cardballScript = c_cardball.GetComponent<S_Cardball>();

        // Setup cardball (this is where it'd be loaded with it's scriptable object
        _cardballScript.c_cardData = _cardTemplate;
        _cardballScript.CardballSetup();
    }

    /// <summary>
    /// This func draws another card from the deck and then creates a card ball and adds it to the game
    /// </summary>
    public void DealAnotherCard()
    {
        //deal the card
        g_global.g_cardManager.DealCards(1);

        //spawn the cardballs and move them
        AddNewCardBall(cardballSpawnPosition, g_global.g_ls_p_playerHand[g_global.g_ls_p_playerHand.Count-1]);
        //StartCoroutine(MoveCardballPrefabs());
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
        //Prevent the player from making any constellations
        g_global.g_ConstellationManager.c_cardballsSpawned = false;

        //Debug.Log(" Debug - Triggered 2");
        b_lastCard = false; 
        SetCardBeingActiveBool(false);
        foreach (S_Cardball _cardball in g_global.g_ls_cardBallPrefabs.ToList())
        {
            //wait and then remove the cardball from the list and delete it from the game
            yield return new WaitForSeconds(0.25f);
            StartCoroutine(_cardball.DeleteAllCardballs());
        }

        //clear the player hand since none of these cards were played
        g_global.g_cardManager.ClearPlayerHand();

        //Trigger if the bool is passed
        if (_newCardBalls == true)
        {
            yield return null; //euivalent but slightly faster for optimization for one second

            //give the player cards to load
            g_global.g_cardManager.DealCards(g_global.g_cardManager.p_i_drawPerTurn);

            c_i_movementInt = 0;
            c_b_movementBool = false;

            StartCoroutine(SpawnCardballPrefabs(5));
        }
    }

    /// <summary>
    /// Check if the first card can be played and converted into a card based off the current constellation energy that the player has generated.
    /// The trigger mechanism for Cardball to cards.
    /// - Josh
    /// </summary>
    public void CheckFirstCardball()
    {
        //Debug.Log("We made it here for the star bool check");
        //yield return new S_WaitForEnergyTextDecrement();
        if(cardballPosition1.transform.childCount > 0)
        {
            if (g_global.g_energyManager.CheckEnergy(cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().c_i_cardEnergyCost, cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().c_cardData.ColorString))
            {
                //Debug.Log("Made Card");

                // Lock Spawning
                SetCardBeingActiveBool(false);

                // Possibly tier up the next card
                if (g_global.g_ls_p_playerHand.Count == 1)
                {
                    b_lastCard = true;
                    SetCardballDelaySpawnBool(false);
                }
                else
                {
                    GameObject _tempObject = GetChildOfSecondAltarPosition();

                    if (_tempObject.Equals(nullObject))
                    {
                        SetCardballDelaySpawnBool(CheckSecondCardball());
                        b_lastCard = false;
                    }
                }

                g_global.g_energyManager.UseEnergy(cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().c_i_cardEnergyCost, cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().c_cardData.ColorString);

                g_global.g_popupManager.TriggerParticleEffects(cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().c_cardData.ColorString);

                //turn the cardball into a card and move over the rest of the cardballs
                cardballPosition1.transform.GetChild(0).gameObject.GetComponent<S_Cardball>().CardballToCard();

                //ChangeCard(cardballPosition1.transform.GetChild(0).gameObject);
            }
            else
            {
                //clear energy and reset the bool
                g_global.g_energyManager.ClearEnergy();

                g_global.g_ConstellationManager.SetStarLockOutBool(true);
            }
        }
        else
        {
            // Nothing
        }
    }

    /// <summary>
    /// Use this to get the status of viability for playing the next card
    /// - Josh
    /// </summary>
    /// <returns>
    /// </returns>
    public bool CheckSecondCardball()
    {
        if (cardballPosition2.transform.childCount > 0) 
        {
            if (g_global.g_energyManager.CheckEnergy(cardballPosition2.transform.GetChild(0).GetComponent<S_Cardball>().c_i_cardEnergyCost, cardballPosition2.transform.GetChild(0).GetComponent<S_Cardball>().c_cardData.ColorString))
            {
                //Debug.Log("Second cardball was valid");
                return true;
            }
            else
            {
                //Debug.Log("Where do you lead me");
                //g_global.g_ConstellationManager.SetStarLockOutBool(true);
                return false;
            }
        }
        else 
        {
            return false;
        }
    }

    /// <summary>
    /// Move the cardballs to seek up the position chain, should be using the state when called which should prevent problems.
    /// Could be an optimization problem down the line. Perhaps we should detach visuals from this based off MVC advice from Will, and fill from 1-5 otherwise.
    /// Also triggers when a cardball is turned into a card, used to move cardballs up the chain as they get used.
    /// - Josh
    /// </summary>
    /// <returns></returns>
    public IEnumerator MoveCardballPrefabs()
    {
        yield return null;
        c_i_movementInt += 1;
        if (cardballPosition2.transform.childCount == 1)
        {
            //Debug.Log("Cardball Position 2 Full");
            // Move the cardball from 2 to 1
            GameObject _cardBall = cardballPosition2.transform.GetChild(0).gameObject;

            _cardBall.transform.DOMove(cardballPosition1.transform.position, f_cardballMoveSpeed);
            _cardBall.transform.SetParent(cardballPosition1.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/UISFX/cardball-move");
            //Debug.Log("Cardballs moving from 2 to 1");
        }
        if (cardballPosition3.transform.childCount == 1)
        {
            // Move the cardball from 3 to 2
            GameObject _cardBall = cardballPosition3.transform.GetChild(0).gameObject;

            _cardBall.transform.DOMove(cardballPosition2.transform.position, f_cardballMoveSpeed);
            _cardBall.transform.SetParent(cardballPosition2.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/UISFX/cardball-move");
            //Debug.Log("Cardballs moving from 3 to 2");
        }
        if (cardballPosition4.transform.childCount == 1)
        {
            // Move the cardball from 4 to 3
            GameObject _cardBall = cardballPosition4.transform.GetChild(0).gameObject;

            _cardBall.GetComponent<S_Cardball>().RevealCardBallDetails();

            _cardBall.transform.DOMove(cardballPosition3.transform.position, f_cardballMoveSpeed);
            _cardBall.transform.SetParent(cardballPosition3.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/UISFX/cardball-move");
            //Debug.Log("Cardballs moving from 4 to 3");
        }
        if (cardballPosition5.transform.childCount == 1)
        {
            // Move the cardball from 5 to 4
            GameObject _cardBall = cardballPosition5.transform.GetChild(0).gameObject;

            _cardBall.transform.DOMove(cardballPosition4.transform.position, f_cardballMoveSpeed);
            _cardBall.transform.SetParent(cardballPosition4.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/UISFX/cardball-move");
            //Debug.Log("Cardballs moving from 5 to 4");
        }
        if (cardballSpawnPosition.transform.childCount == 1)
        {
            // Move the cardball from Spawn to 5
            GameObject _cardBall = cardballSpawnPosition.transform.GetChild(0).gameObject;

            _cardBall.transform.DOMove(cardballPosition5.transform.position, f_cardballMoveSpeed);
            _cardBall.transform.SetParent(cardballPosition5.transform);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/UISFX/cardball-move");
            //Debug.Log("Cardballs moving from 5 to 4");
        }
        else
        {
            //Debug.Log("DEBUG: No more cardballs to spawn!");
        }

        if (c_i_movementInt == 5)
        {
            c_b_movementBool = true;
        }

        // May not be necessary, check later, part of race condition debugging between turns. 
        g_global.g_enemyState.UpdateActiveEnemies();

        foreach (S_Enemy _enemy in g_global.g_ls_activeEnemies.ToList()) 
        {
            _enemy.UpdateEnemyHealthUI();
        }
    }

    /// <summary>
    /// Used so the cardball can't delete itself too early and and so we can trigger proper moving of the cardballs
    /// - Josh
    /// </summary>
    /// <returns></returns>
    public IEnumerator WaitForCardPlayToMoveAndDelete(GameObject _cardball, bool _activeCard)
    {
        // Hide, but don't delete just yet
        _cardball.GetComponent<S_Cardball>().c_redGraphic.SetActive(false);
        _cardball.GetComponent<S_Cardball>().c_blueGraphic.SetActive(false);
        _cardball.GetComponent<S_Cardball>().c_yellowGraphic.SetActive(false);
        _cardball.GetComponent<S_Cardball>().c_whiteGraphic.SetActive(false);
        _cardball.GetComponent<S_Cardball>().c_cardballText.gameObject.SetActive(false);

        if (_activeCard == true) 
        {
            yield return null;
            Destroy(_cardball);
        }
        else if (_activeCard == false)
        {
            //Debug.Log("Gonna wait for card play");
            yield return new S_WaitForCardPlay();

            yield return null;

            //Debug.Log("Do I reach here");
            Destroy(_cardball);

            if (GetCardballDelaySpawnBool() == true || b_lastCard == true)
            {
                g_global.g_ConstellationManager.SetStarLockOutBool(true);
                //Debug.Log("Attempting to delay spawn of second card after a first");
                yield return StartCoroutine(WaitForCardballMovementToPlay());
            }
            else
            {
                //g_global.g_ConstellationManager.SetStarLockOutBool(true);
                g_global.g_energyManager.ClearEnergy();
                //Debug.Log("MoveCardballPrefabs() Called");
                yield return StartCoroutine(MoveCardballPrefabs());
            }
        }
    }



    /// <summary>
    /// Used so the cardball can't delete itself too early and and so we can trigger proper moving of the cardballs
    /// - Josh
    /// </summary>
    /// <returns></returns>
    public IEnumerator MoveAndDeleteAllCardBalls(GameObject _cardball, bool _activeCard)
    {
        // Hide, but don't delete just yet
        _cardball.GetComponent<S_Cardball>().c_redGraphic.SetActive(false);
        _cardball.GetComponent<S_Cardball>().c_blueGraphic.SetActive(false);
        _cardball.GetComponent<S_Cardball>().c_yellowGraphic.SetActive(false);
        _cardball.GetComponent<S_Cardball>().c_whiteGraphic.SetActive(false);
        _cardball.GetComponent<S_Cardball>().c_cardballText.gameObject.SetActive(false);

        if (_activeCard == true)
        {
            yield return null;
            Destroy(_cardball);
        }
        else if (_activeCard == false)
        {
            yield return null;

            Debug.Log("Do I reach here");
            Destroy(_cardball);

            if (GetCardballDelaySpawnBool() == true || b_lastCard == true)
            {
                g_global.g_ConstellationManager.SetStarLockOutBool(true);
                Debug.Log("Attempting to delay spawn of second card after a first");
                yield return StartCoroutine(WaitForCardballMovementToPlay());
            }
            else
            {
                g_global.g_ConstellationManager.SetStarLockOutBool(true);
                Debug.Log("MoveCardballPrefabs() Called");
                yield return StartCoroutine(MoveCardballPrefabs());
            }
        }
    }

    /// <summary>
    /// Used so the spawning of a card moves cardballs appropiately first
    /// - Josh
    /// </summary>
    /// <returns></returns>
    public IEnumerator WaitForCardballMovementToPlay()
    {
        //Debug.Log("Waiting to make a card");

        c_i_movementInt -= 1;
        yield return StartCoroutine(MoveCardballPrefabs());

        // Set second cardball playable status to default false
        SetCardballDelaySpawnBool(false);

        yield return new WaitForSeconds(1.5f);
        // Then try to play card
        CheckFirstCardball();
    }

    /// <summary>
    /// Used to toggle tooltip when mouse enters
    /// - Josh
    /// </summary>
    public void OnHoverEnter()
    {
        tl_b_mouseEntered = true;
    }

    public void OnHoverStay() 
    {
        if (tl_b_mouseEntered == true)
        {
            Debug.Log("Triggered Mouse Hover");
            g_global.g_tooltipManager.SetupToolTipObject(tl_altarTooltipTemplate, gameObject.transform);
        }
    }

    /// <summary>
    /// Used to toggle tooltip when mouse exits
    /// - Josh
    /// </summary>
    public void OnHoverExit()
    {
        g_global.g_tooltipManager.ResetTooltip();
        tl_b_mouseEntered = false;
    }

    /////////////////////////////--------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the bool value of S_Altar.b_cardballsSpawned
    /// - Josh 
    /// </summary>
    /// <param name="_truthValue"></param>
    public void SetCardballsSpawnedBool(bool _truthValue)
    {
        b_cardballsSpawned = _truthValue;
    }

    /// <summary>
    /// Set the bool value of S_Altar.c_b_spawnCardAfterMovement
    /// - Josh 
    /// </summary>
    /// <param name="_truthValue"></param>
    public void SetCardballDelaySpawnBool(bool _truthValue)
    {
        b_cardballDelay = _truthValue;
    }

    /// <summary>
    /// Set the bool value of S_Altar.cd_b_cardIsActive
    /// - Josh 
    /// </summary>
    /// <param name="_truthValue"></param>
    public void SetCardBeingActiveBool(bool _truthValue)
    {
        //Debug.Log("Card activity has been changed to..." + _truthValue.ToString());
        cd_b_cardIsActive = _truthValue;
    }

    /////////////////////////////--------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the bool value of S_Altar.b_cardballsSpawned
    /// - Josh 
    /// </summary>
    /// <returns>
    /// S_Altar.b_cardballsSpawned
    /// </returns>
    public bool GetCardballsSpawnedBool()
    {
        return b_cardballsSpawned;
    }

    /// <summary>
    /// Return the bool value of S_Altar.b_cardballDelay
    /// </summary>
    /// <returns>
    /// S_Altar.cardballDelay
    /// </returns>
    public bool GetCardballDelaySpawnBool()
    {
        return b_cardballDelay;
    }

    /// <summary>
    /// Return the bool value of S_Altar.cd_b_cardIsActive
    /// </summary>
    /// <returns>
    /// S_Altar.cd_b_cardIsActive
    /// </returns>
    public bool GetCardBeingActiveBool()
    {
        return cd_b_cardIsActive;
    }

    /// <summary>
    /// Return the bool value of S_Altar.c_b_movementBool
    /// - Josh 
    /// </summary>
    /// <returns>
    /// S_Altar.c_b_movementBool
    /// </returns>
    public bool GetCardballMovementBool()
    {
        return c_b_movementBool;
    }

    /// <summary>
    /// Return the child object of S_Altar.cardballPosition1
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_Altar.cardballPosition1.transform.GetChild(0) || nullObject
    /// </returns>
    public GameObject GetChildOfFirstAltarPosition() 
    {
        if (cardballPosition1.transform.childCount > 0)
        {
            return nullObject;
        }
        else
        {
            return cardballPosition1.transform.GetChild(0).gameObject;
        }
    }

    /// <summary>
    /// Return the child object of S_Altar.cardballPosition2
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_Altar.cardballPosition2.transform.GetChild(0) || nullObject
    /// </returns>
    public GameObject GetChildOfSecondAltarPosition()
    {
        if (cardballPosition2.transform.childCount > 0)
        {
            return nullObject;
        }
        else
        {
            return cardballPosition2.transform.GetChild(0).gameObject;
        }
    }

    /// <summary>
    /// Return the child object of S_Altar.cardballPosition3
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_Altar.cardballPosition3.transform.GetChild(0) || nullObject
    /// </returns>
    public GameObject GetChildOfThirdAltarPosition()
    {
        if (cardballPosition3.transform.childCount > 0)
        {
            return nullObject;
        }
        else
        {
            return cardballPosition3.transform.GetChild(0).gameObject;
        }
    }

    /// <summary>
    /// Return the child object of S_Altar.cardballPosition4
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_Altar.cardballPosition4.transform.GetChild(0) || nullObject
    /// </returns>
    public GameObject GetChildOfFourthAltarPosition()
    {
        if (cardballPosition4.transform.childCount > 0)
        {
            return nullObject;
        }
        else
        {
            return cardballPosition4.transform.GetChild(0).gameObject;
        }
    }

    /// <summary>
    /// Return the child object of S_Altar.cardballPosition5
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_Altar.cardballPosition5.transform.GetChild(0) || nullObject
    /// </returns>
    public GameObject GetChildOfFifthAltarPosition()
    {
        if (cardballPosition5.transform.childCount > 0)
        {
            return nullObject;
        }
        else
        {
            return cardballPosition5.transform.GetChild(0).gameObject;
        }
    }
}
