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
    private bool b_spawnTimerFlag;
    [SerializeField] SpriteRenderer colorImage;

    [Header("Color Bools")]
    [SerializeField] bool b_redPopup;
    [SerializeField] bool b_bluePopup;
    [SerializeField] bool b_yellowPopup;

    [Header("Deletion Timer Attributes")]
    [SerializeField] float f_disappearTimer;
    [SerializeField] float f_destroyTimer;
    [SerializeField] float f_doFadeAlpha;
    [SerializeField] float f_doFadeDuration;

    [Header("Spawn Fade Timer")]
    [SerializeField] float f_spawnTimer;
    [SerializeField] float f_doFadeAlphaSpawn;
    [SerializeField] float f_doFadeDurationSpawn;

    [Header("Sit at Position Attributes")]
    public bool b_keepSitting; 

    [Header("Color Graphics")]
    public GameObject redColorGraphic;
    public GameObject blueColorGraphic;
    public GameObject yellowColorGraphic;

    [Header("Card movement speed")] 
    public float f_moveSpeed;

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

        // Get timers ready for use
        b_deletionTimerFlag = false;
        b_spawnTimerFlag = false; 
    }

    /// <summary>
    /// A coroutine for triggering a fade in effect
    /// - Josh
    /// </summary>
    public IEnumerator SpawnFadeTimer()
    {
        f_spawnTimer -= Time.deltaTime;
        colorImage.DOFade(f_doFadeAlphaSpawn, f_doFadeDurationSpawn);
        gameObject.transform.DOShakePosition(2f, 0.1f, 6, 10f);
        
        gameObject.transform.DOScale(new Vector3(0.4f, 0.4f, 0), 0.2f);

        yield return new WaitForSeconds(0.25f);

        gameObject.transform.DOScale(new Vector3(0.3f, 0.3f, 0), 0.2f);
        if (f_spawnTimer < 0)
        {
            b_spawnTimerFlag = true;
        }
        yield return b_spawnTimerFlag == true; 
    }

 
    /// <summary>
    /// Move the popup to the altar
    /// </summary>
    public void MoveToAltar()
    {
        Vector3 _firstCardPosition = g_global.g_popupManager.altarTargetPosition.transform.position;
        gameObject.transform.DORotate(new Vector3(0f, 0f, 0f), 1f);
        gameObject.transform.DOMove(_firstCardPosition, f_moveSpeed);
        gameObject.transform.DORotate(new Vector3(0f, 0f, 180f), 1.5f);
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
            //Debug.Log("First popup!");
            gameObject.transform.position = _star.vectorPoint1.transform.position;
        }
        else if(_positionCount == 2)
        {
            //Debug.Log("Second popup!");
            gameObject.transform.position = _star.vectorPoint2.transform.position;
        }
        else if(_positionCount == 3)
        {
            //Debug.Log("Third popup!");
            gameObject.transform.position = _star.vectorPoint3.transform.position;
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
            colorImage = redColorGraphic.GetComponent<SpriteRenderer>();

            StartCoroutine(SpawnFadeTimer());
        }
        if(_color == "blue")
        {
            // Toggle Graphics
            redColorGraphic.SetActive(false);
            blueColorGraphic.SetActive(true);
            yellowColorGraphic.SetActive(false);

            //Set Color Image
            colorImage = blueColorGraphic.GetComponent<SpriteRenderer>();

            StartCoroutine(SpawnFadeTimer());
        }
        if(_color == "yellow")
        {
            // Toggle Graphics
            redColorGraphic.SetActive(false);
            blueColorGraphic.SetActive(false);
            yellowColorGraphic.SetActive(true);

            //Set Color Image
            colorImage = yellowColorGraphic.GetComponent<SpriteRenderer>();

            StartCoroutine(SpawnFadeTimer());
        }
    }

    public void ClearPopup()
    {
        StartCoroutine(DeletionTimer());
    }

    public void DeletePopup()
    {
        g_global.ls_starPopup.Remove(this);
        Destroy(gameObject);
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
        g_global.ls_starPopup.Remove(this);
        if (f_disappearTimer < 0)
        {
            colorImage.DOFade(f_doFadeAlpha, f_doFadeDuration);
            f_destroyTimer -= Time.deltaTime;
            if (f_destroyTimer < 0)
            {
                Destroy(gameObject);
            }
        }
        b_deletionTimerFlag = true;
        yield return b_deletionTimerFlag == true;
    }
}
