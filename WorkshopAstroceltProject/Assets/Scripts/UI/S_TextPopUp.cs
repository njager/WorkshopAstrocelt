using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;
using DG.Tweening;

public class S_TextPopUp : MonoBehaviour
{
    //Global
    private S_Global g_global;  

    [Header("Attributes for PopUp")]
    [SerializeField] TextMeshPro tx_baseTextMesh;
    [SerializeField] float f_disappearTimer;
    [SerializeField] float f_destroyTimer = 1f;
    [SerializeField] Color cl_tx_textColor;

    [Header("Color Bools")]
    [SerializeField] bool b_useRed;
    [SerializeField] bool b_useYellow;
    [SerializeField] bool b_useBlue;

    [Header("Given Position:")]
    private Vector3 v3_givenPosition;

    [Header("Modfiable DOTween Attributes")]
    [SerializeField] Vector4 v4_doTweenShakeValues; //Vibration, stregth, duration, randomness
    [SerializeField] Vector3 v3_doTweenScale;

    [Header("Color Attributes")]
    [SerializeField] Color cl_redColor;
    [SerializeField] Color cl_blueColor;
    [SerializeField] Color cl_yellowColor;

    //What to do upon instantiation
    void Awake()
    {
        g_global = S_Global.Instance;
        tx_baseTextMesh = transform.GetComponent<TextMeshPro>();
    }

    /// <summary>
    /// Use Update to make use of a minitimer
    /// Should be low impact since it'll be deleted in a couple seconds
    /// - Josh
    /// </summary>
    void Update()
    {
        //A delay timer for the disappear animation
        f_disappearTimer -= Time.deltaTime;
        if (f_disappearTimer < 0)
        {
            tx_baseTextMesh.DOFade(0f, 1f);
            f_destroyTimer -= Time.deltaTime;
            if (f_destroyTimer < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// Set the given position
    /// </summary>
    /// <param name="_givenPosition"></param>
    public void SetGivenPosition(Vector3 _givenPosition)
    {
        v3_givenPosition = _givenPosition;
    }


    /// <summary>
    /// Move the popup object to location and finish it's set up
    /// - Josh
    /// </summary>
    /// <returns></returns>
    public IEnumerator MovePopUp()
    {
        //"Punch" the position for shake and scale (hardcoded, need to change)
        gameObject.transform.DOShakePosition(1f, 0.3f, 10, 10f);
        gameObject.transform.DOScale(new Vector3(1.5f, 1.5f, 0), 0.2f);

        //Flash the color then reset
        tx_baseTextMesh.DOColor(UtilsClass.GetColorFromString("FFFFFF"), 0.2f);

        yield return new WaitForSeconds(0.25f);

        gameObject.transform.DOScale(new Vector3(1, 1, 0), .2f);

        //check what color to return it to after flashing white
        if (b_useRed)
        {
            tx_baseTextMesh.DOColor(UtilsClass.GetColorFromString("5ECC71"), 0.2f); // Note Change to a yellow color later
        }
        else if (b_useBlue)
        {
            tx_baseTextMesh.DOColor(UtilsClass.GetColorFromString("DD6666"), 0.2f); // Note Change to a blue color later
        }
        else if (b_useYellow)
        {
            tx_baseTextMesh.DOColor(UtilsClass.GetColorFromString("7598D1"), 0.2f); // Note Change to red color later
        }

        yield return new WaitForSeconds(1); // Note Can actually yield return more than once

        //Move to given position
        gameObject.transform.DOMove(v3_givenPosition, 1.5f);
    }
}
