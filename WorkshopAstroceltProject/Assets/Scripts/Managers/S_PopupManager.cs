using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;
using DG.Tweening;

public class S_PopupManager : MonoBehaviour
{
    //private variables
    private S_Global global;
    public TextMeshPro textMesh;
    public float disappearTimer;
    public float destroyTimer = 1f;
    public Color textColor;
    public float DISAPPEAR_TIMER_MAX = 3f;
    public int sortingOrder;
    [SerializeField] Vector3 enemyHealthPos;
    [SerializeField] Vector3 playerHealthPos;
    public bool isRed;
    public bool isGreen;
    public bool isBlue;
    public bool sendToPlayer;

    //public variables
    public GameObject pfPopupStatic;
    public GameObject pfPopup;
    private BoxCollider box;

    //get the transform component of the text
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        gameObject.AddComponent<BoxCollider>();
        box = gameObject.GetComponent<BoxCollider>();
    }

    //setup the popup
    private void Start()
    {
        pfPopupStatic = pfPopup;
        global = S_Global.Instance;
        DOTween.Init();
        enemyHealthPos = new Vector3(14, -0.35f, 0);
        playerHealthPos = new Vector3(-14, 2.35f, 0);
    }


    //make the output amount into the text for the popup

    void Update()
    {
        //delay disappear for popup
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            textMesh.DOFade(0f, 1f);
            destroyTimer -= Time.deltaTime;
            if (destroyTimer < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    //wait then move popup to enemy health bar, with other punchy effects
    IEnumerator MovePopup()
    {
        //punch the position for shake and scale
        gameObject.transform.DOShakePosition(1f, 0.3f, 10, 10f);
        gameObject.transform.DOScale(new Vector3(1.5f, 1.5f, 0), 0.2f);

        //flash color then reset
        textMesh.DOColor(UtilsClass.GetColorFromString("FFFFFF"), 0.2f);

        yield return new WaitForSeconds(0.25f);

        gameObject.transform.DOScale(new Vector3(1, 1, 0), .2f);

        //check what color to return it to after flashing white
        if (isGreen)
        {
            textMesh.DOColor(UtilsClass.GetColorFromString("5ECC71"), 0.2f);
        }
        if (isRed)
        {
            textMesh.DOColor(UtilsClass.GetColorFromString("DD6666"), 0.2f);
        }
        if (isBlue)
        {
            textMesh.DOColor(UtilsClass.GetColorFromString("7598D1"), 0.2f);
        }

        yield return new WaitForSeconds(1);

        //move to enemy if if red and move to player if green or blue
        if (!sendToPlayer)
        {
            gameObject.transform.DOMove(enemyHealthPos, 2f);
        }
        else if (sendToPlayer)
        {
            gameObject.transform.DOMove(playerHealthPos, 2f);
        }
    }

    //if the popup enters the screen, move it
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Popup entered the screen!");
        StartCoroutine("MovePopup");
        box.enabled = false;
    }
}
