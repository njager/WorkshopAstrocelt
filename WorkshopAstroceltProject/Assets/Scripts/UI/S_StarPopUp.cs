using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; 
using TMPro;
using CodeMonkey.Utils;
using DG.Tweening;
//using Unity.VectorGraphics;
//using Unity.VectorGraphics.Editor;

public class S_StarPopUp : MonoBehaviour
{
    private S_Global g_global;
    private bool b_deletionTimerFlag;
    private Material colorImage;

    [Header("Color Bools")]
    [SerializeField] bool b_redPopup;
    [SerializeField] bool b_bluePopup;
    [SerializeField] bool b_yellowPopup;

    [Header("Deletion Timer Attributes")]
    [SerializeField] float f_disappearTimer;
    [SerializeField] float f_destroyTimer = 1f;
    [SerializeField] float f_doFadeAlpha;
    [SerializeField] float f_doFadeDuration;

    [Header("Sit at Position Attributes")]
    public bool b_keepSitting; 

    [Header("Color Graphics")]
    public GameObject redColorGraphic;
    public GameObject blueColorGraphic;
    public GameObject yellowColorGraphic;

    [Header("Card Triggers")] // May not be needed
    public PolygonCollider2D redCollider;
    public PolygonCollider2D blueCollider;
    public PolygonCollider2D yellowCollider;


    /// <summary>
    /// Set up global, add to list, and deletion timer
    /// Toggle all the color graphics off to start
    /// - Josh
    /// </summary>
    void Awake()
    {
        g_global = S_Global.Instance;
        g_global.ls_starPopup.Add(this); 

        // Toggle Graphics to null position
        redColorGraphic.SetActive(false);
        blueColorGraphic.SetActive(false);
        yellowColorGraphic.SetActive(false);

        // Get timer ready for use
        b_deletionTimerFlag = false;

        // Get ready to hold
        b_keepSitting = false; 
    }

    /// <summary>
    /// This is a function used to get the popup to wait above the star
    /// Only Finishes once the constellation finishes
    /// </summary>
    /// <returns></returns>
    private IEnumerator SitAtPosition()
    {
        if(g_global.g_ConstellationManager.s_b_popupMove == true)
        {
            b_keepSitting = true;
            MoveToCard();
        }

        // Can add an else here to trigger idle animation
        yield return b_keepSitting == true; 
    }

    private void MoveToCard()
    {
        Vector3 _firstCardPosition = g_global.ls_p_playerHand[0].gameObject.transform.position;
        gameObject.transform.DOMove(_firstCardPosition, 1f);
        DeletePopup();
    }

    /// <summary>
    /// Adjust the popups position based off the line system, get them to place properly
    /// Trigger timer for down time 
    /// </summary>
    /// <param name="_positionCount"></param>
    public void SetPosition(int _positionCount, S_StarClass _star)
    {
        if(_positionCount == 1)
        {
            gameObject.transform.SetParent(_star.vectorPoint1.transform);
            StartCoroutine(SitAtPosition());
        }
        else if(_positionCount == 2)
        {
            gameObject.transform.SetParent(_star.vectorPoint2.transform);
            StartCoroutine(SitAtPosition());
        }
        else if(_positionCount == 3)
        {
            gameObject.transform.SetParent(_star.vectorPoint3.transform);
            StartCoroutine(SitAtPosition());
        }
    }

    /// <summary>
    /// Function for S_ConstellationLine use to toggle the graphic and then allow the star object to be set
    /// - Josh
    /// </summary>
    /// <param name="_color"></param>
    public void SetGraphic(string _color)
    {
        if(_color == "red")
        {
            // Toggle Graphics
            redColorGraphic.SetActive(true);
            blueColorGraphic.SetActive(false);
            yellowColorGraphic.SetActive(false);

            //Set Color Image
            colorImage = redColorGraphic.GetComponent<SpriteRenderer>().material; 
        }
        if(_color == "blue")
        {
            // Toggle Graphics
            redColorGraphic.SetActive(false);
            blueColorGraphic.SetActive(true);
            yellowColorGraphic.SetActive(false);

            //Set Color Image
            colorImage = blueColorGraphic.GetComponent<SpriteRenderer>().material;
        }
        if(_color == "yellow")
        {
            // Toggle Graphics
            redColorGraphic.SetActive(false);
            blueColorGraphic.SetActive(false);
            yellowColorGraphic.SetActive(true);

            //Set Color Image
            colorImage = yellowColorGraphic.GetComponent<SpriteRenderer>().material;
        }
    }

    public void DeletePopup()
    {
        StartCoroutine(DeletionTimer());
    }

    /// <summary>
    /// Help function for deletion
    /// - Josh
    /// </summary>
    /// <returns></returns>
    private IEnumerator DeletionTimer()
    {
        //A delay timer for the disappear animation
        f_disappearTimer -= Time.deltaTime;
        if (f_disappearTimer < 0)
        {
            colorImage.DOFade(f_doFadeAlpha, f_doFadeDuration);
            f_destroyTimer -= Time.deltaTime;
            if (f_destroyTimer < 0)
            {
                Destroy(gameObject);
            }
        }
        g_global.ls_starPopup.Remove(this);
        b_deletionTimerFlag = true;
        yield return b_deletionTimerFlag == true;
    }
}
