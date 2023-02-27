using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using DG.Tweening;

public class S_Altar : MonoBehaviour
{
    private S_Global g_global;

    [Header("Number of Active Card Balls")]
    public int i_cardBallNum = 3;

    [Header("Text Boxes")]
    public TextMeshProUGUI c_tx_cardName;
    public TextMeshProUGUI c_tx_cardBody;

    [Header("Borders")]
    public GameObject a_colorlessBorder;
    public GameObject a_redBorder;
    public GameObject a_blueBorder;
    public GameObject a_yellowBorder;

    [Header("Upper Text Boxes")]
    public TextMeshProUGUI c_tx_upperCardName;

    [Header("Upper Borders")]
    public GameObject a_upperColorlessBorder;
    public GameObject a_upperRedBorder;
    public GameObject a_upperBlueBorder;
    public GameObject a_upperYellowBorder;

    [Header("Cardball Prefab")]
    public GameObject c_cardballPrefab; 

    [Header("Cardball Positions")]
    public GameObject cardballPosition1;
    public GameObject cardballPosition2;
    public GameObject cardballPosition3;
    public GameObject cardballSpawnPosition;

    [Header("Upper Altar Positions")]
    public GameObject upperCardballPosition1;
    public GameObject upperCardballPosition2;
    public GameObject upperCardballPosition3;

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

    [Header("CardBalls in Hand List")]
    public List<S_CardTemplate> ls_cardBallHand;

    [Header("Active CardBalls")]
    public List<S_Cardball> ls_activeCardBalls;

    [Header("CardBall completed List")]
    public List<S_Cardball> ls_cardBallStorage;

    

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
        AddActiveCardBalls(i_cardBallNum);
    }

    /// <summary>
    /// First part of the logic chain for card balls
    /// adds the first cardballs to the active list
    /// calls spawn cardball prefabs
    /// -Riley Halloran
    /// </summary>
    public void AddActiveCardBalls(int _numOfCards)
    {
        for (int i = 0; i < _numOfCards; i++)
        {
            ls_cardBallHand.Add(g_global.g_cardManager.GetCardFromDeck());
        }

        StartCoroutine(SpawnVisualCardballPrefabs(_numOfCards));
    }

    /// <summary>
    /// spawns the card balls
    /// 
    /// - Josh
    /// </summary>
    public IEnumerator SpawnVisualCardballPrefabs(int _numCards)
    {
        c_i_movementInt = 0;

        //set the constellation manager bools until the card balls finish spawning
        StartCoroutine(g_global.g_ConstellationManager.CardballSpawnCheck());

        for (int i = 0; i < _numCards; i++)
        {
            yield return new WaitForSeconds(1);
            AddNewCardBall(cardballSpawnPosition, ls_cardBallHand[i]);


            if (g_global.g_vfxManager.GetCamPos() == false)
            {
                StartCoroutine(MoveCardballPrefabs());
            }
        }

        //do this outside the loop so all cardballs are in the active list
        if (g_global.g_vfxManager.GetCamPos())
        {
            StartCoroutine(SlideUpperCardBalls());
        }

        SetCardballsSpawnedBool(true);

        ls_cardBallHand.Clear();

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
        //SetCardballsSpawnedBool(false);
        Debug.Log(_cardTemplate);

        // Instantiate Cardball
        GameObject crd_cardball = Instantiate(c_cardballPrefab, Vector3.zero, Quaternion.identity);
        crd_cardball.transform.SetParent(_cardballPosition.transform, false);

        Debug.Log(crd_cardball.transform.parent);
        
        // Grab card ball script
        S_Cardball _cardballScript = crd_cardball.GetComponent<S_Cardball>();

        // Check and see if Magician's ability is active
        if(g_global.g_enemyState.GetMagicianAbilityBool() == true) 
        {
            _cardballScript.AdjustEnergyCost(true, g_global.g_enemyState.GetMagicianAbilityValue());
        }

        // Setup cardball (this is where it'd be loaded with it's scriptable object
        _cardballScript.c_cardData = _cardTemplate;
        _cardballScript.CardballSetup();

        ls_activeCardBalls.Add(_cardballScript);
    }

    /// <summary>
    /// This func draws another card from the deck and then creates a card ball and adds it to the game
    /// </summary>
    public void DealAnotherCard()
    {
        //get the card from deck and add to the hand equal to difference
        for(int i = ls_activeCardBalls.Count(); i < 3 ; i++)
        {
            ls_cardBallHand.Add(g_global.g_cardManager.GetCardFromDeck());
        }

        print("Card ball count " + ls_cardBallHand.Count());

        //spawn the cardballs equal to the amount in hand
        StartCoroutine(SpawnVisualCardballPrefabs(ls_cardBallHand.Count()));
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
        foreach (S_Cardball _cardball in ls_activeCardBalls)
        {
            //wait and then remove the cardball from the list and delete it from the game
            yield return new WaitForSeconds(0.25f);
            StartCoroutine(_cardball.DeleteAllCardballs());
        }

        //clear the card balls from the list
        ls_activeCardBalls.Clear();

        //Trigger if the bool is passed
        if (_newCardBalls == true)
        {
            yield return null; //euivalent but slightly faster for optimization for one second

            //give the player cards to load

            c_i_movementInt = 0;
            c_b_movementBool = false;

            AddActiveCardBalls(i_cardBallNum); 
        }
    }

    /// <summary>
    /// Called from the vfx manager when the down button gets hit
    /// create a card from the first cardball
    /// </summary>
    public void CreateCardFromList()
    {
        if (ls_cardBallStorage.Count() > 0)
        {
            var _firstCardBall = ls_cardBallStorage[0];
            ls_cardBallStorage.RemoveAt(0);

            _firstCardBall.CardballToCard();
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
            //set the top cardball to have larger scale
            _cardBall.transform.DOScale(new Vector3(.8f, .8f, 0), f_cardballMoveSpeed);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/UISFX/cardball-move");
            //CheckFirstCardball();
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
        if (cardballSpawnPosition.transform.childCount == 1)
        {
            // Move the cardball from Spawn to 3
            GameObject _cardBall = cardballSpawnPosition.transform.GetChild(0).gameObject;

            _cardBall.GetComponent<S_Cardball>().RevealCardBallDetails();

            _cardBall.transform.DOMove(cardballPosition3.transform.position, f_cardballMoveSpeed);
            _cardBall.transform.SetParent(cardballPosition3.transform);
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
            //deal another card
            DealAnotherCard();

            //move the card balls before the card is played
            yield return StartCoroutine(MoveCardballPrefabs());

            //Debug.Log("Gonna wait for card play");
            yield return new S_WaitForCardPlay();

            yield return null;

            //Debug.Log("Do I reach here");
            Destroy(_cardball);

            if (GetCardballDelaySpawnBool() == true || b_lastCard == true)
            {
                //g_global.g_ConstellationManager.SetStarLockOutBool(true);
                Debug.Log("Attempting to delay spawn of second card after a first");
                yield return StartCoroutine(WaitForCardballMovementToPlay());
            }
            else
            {
                g_global.g_ConstellationManager.SetStarLockOutBool(true);
                //g_global.g_energyManager.ClearEnergy();
                //Debug.Log("MoveCardballPrefabs() Called");
            }
        }
    }

    /// <summary>
    /// This is the function that gets called after the player finishes the constellation
    /// Needs to manage the data structures for the card balls and enforces them for the visuals
    /// -Riley Halloran
    /// </summary>
    public void CheckCardBallData()
    {
        bool _loopBool = true;

        while (_loopBool)
        {
            if (ls_activeCardBalls.Count > 0)
            {


                var _fst_cardBall = ls_activeCardBalls[0];


                //check the first card Ball and user energy
                if (g_global.g_energyManager.UseEnergy(_fst_cardBall.c_i_cardEnergyCost, _fst_cardBall.c_cardData.ColorString))
                {
                    ls_cardBallStorage.Add(_fst_cardBall);

                    ls_activeCardBalls.RemoveAt(0);

                    _fst_cardBall.transform.SetParent(nullObject.transform);

                    _fst_cardBall.gameObject.SetActive(false);
                }
                else
                {
                    _loopBool = false;
                }
            }
            else
            {
                _loopBool = false;
            }
        }

        DealAnotherCard();
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

        // Set second cardball playable status to default false
        SetCardballDelaySpawnBool(false);

        yield return new WaitForSeconds(1.5f);
        // Then try to play card
    }


    /// <summary>
    /// Function that moves all the cardballs to the upper side of the map
    /// -Riley
    /// </summary>
    public void MoveCardBallsUp()
    {
        for(int i=0; i < ls_activeCardBalls.Count(); i++) 
        { 
            if(i==0)
            {
                ls_activeCardBalls[i].transform.SetParent(upperCardballPosition1.transform, false);
            }
            else if (i == 1)
            {
                ls_activeCardBalls[i].transform.SetParent(upperCardballPosition2.transform, false);
            }
            else if (i == 2)
            {
                ls_activeCardBalls[i].transform.SetParent(upperCardballPosition3.transform, false);
            }
        }
    }

    /// <summary>
    /// Moves all the upper card balls to the left
    /// </summary>
    /// <returns></returns>
    public IEnumerator SlideUpperCardBalls()
    {
        for (int i = 0; i < ls_activeCardBalls.Count(); i++)
        {
            Debug.Log("Were sliding");

            S_Cardball _cardBall = ls_activeCardBalls[i];

            //set up any cardballs that need it
            if(_cardBall.c_cardName == "")
            {
                Debug.Log("Do we hit here");
                _cardBall.CardballSetup();
            }

            if (i == 0)
            {
                _cardBall.transform.SetParent(upperCardballPosition1.transform, false);

                yield return new WaitForSeconds(0.1f);
            }
            else if (i == 1)
            {
                _cardBall.transform.SetParent(upperCardballPosition2.transform, false);

                yield return new WaitForSeconds(0.1f);
            }
            else if (i == 2)
            {
                _cardBall.transform.SetParent(upperCardballPosition3.transform, false);

                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    /// <summary>
    /// Function that moves all the cardballs to the upper side of the map
    /// -Riley
    /// </summary>
    public void MoveCardBallsDown()
    {
        for (int i = 0; i < ls_activeCardBalls.Count(); i++)
        {
            if (i == 0)
            {
                ls_activeCardBalls[i].transform.SetParent(cardballPosition1.transform, false);
            }
            else if (i == 1)
            {
                ls_activeCardBalls[i].transform.SetParent(cardballPosition2.transform, false);
            }
            else if (i == 2)
            {
                ls_activeCardBalls[i].transform.SetParent(cardballPosition3.transform, false);
            }
        }
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
}
