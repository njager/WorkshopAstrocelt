using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    
    [Header("Given Position")]
    [SerializeField] Vector3 v3_givenPosition;
    private bool b_deletionTimerFlag;

    [Header("Modfiable DOTween Attributes")]
    [SerializeField] Vector4 v4_doTweenShakeValues; //Vibration, stregth, duration, randomness
    [SerializeField] Vector3 v3_doTweenScale;

    [Header("Color Attributes")]
    [SerializeField] Color cl_redColor;
    [SerializeField] Color cl_blueColor;
    [SerializeField] Color cl_yellowColor;
    [SerializeField] float f_colorDuration;
    [SerializeField] float f_doFadeAlpha;
    [SerializeField] float f_doFadeDuration;

    /// <summary>
    /// Set global, tje textmeshcomonent, and the timer
    /// </summary>
    void Awake()
    {
        g_global = S_Global.Instance;
        tx_baseTextMesh = transform.GetComponent<TextMeshPro>();
        b_deletionTimerFlag = false;
    }

    /// <summary>
    /// Use IEnumerator as an update loop to make use of a minitimer
    /// Should be low impact since it'll be deleted in a couple seconds
    /// - Josh
    /// </summary>
    private IEnumerator DeletionTimer()
    {
        //A delay timer for the disappear animation
        f_disappearTimer -= Time.deltaTime;
        if (f_disappearTimer < 0)
        {
            tx_baseTextMesh.DOFade(f_doFadeAlpha, f_doFadeDuration);
            f_destroyTimer -= Time.deltaTime;
            if (f_destroyTimer < 0)
            {
                Destroy(gameObject);
            }
        }
        b_deletionTimerFlag = true;
        yield return b_deletionTimerFlag == true; 
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
        gameObject.transform.DOShakePosition(v4_doTweenShakeValues.x, v4_doTweenShakeValues.y, (int)v4_doTweenShakeValues.z, v4_doTweenShakeValues.w); //3rd value will be casted to int
        gameObject.transform.DOScale(new Vector3(v3_doTweenScale.x, v3_doTweenScale.y, v3_doTweenScale.z), f_colorDuration);

        //Flash the color then reset
        tx_baseTextMesh.DOColor(cl_tx_textColor, f_colorDuration);

        yield return new WaitForSeconds(0.25f);

        gameObject.transform.DOScale(new Vector3(1, 1, 0), .2f);

        //check what color to return it to after flashing white
        if (b_useRed) // Change to yellow color
        {
            tx_baseTextMesh.DOColor(cl_redColor, f_colorDuration); 
        }
        else if (b_useBlue) // Change to blue color
        {
            tx_baseTextMesh.DOColor(cl_blueColor, f_colorDuration); 
        }
        else if (b_useYellow) // Change to yellow color
        {
            tx_baseTextMesh.DOColor(cl_yellowColor, f_colorDuration); 
        }

        yield return new WaitForSeconds(1f); // Note Can actually yield return more than once

        //Move to given position
        gameObject.transform.DOMove(v3_givenPosition, 1.5f);
        StartCoroutine(DeletionTimer()); // Deletion Timer start here
    }
}
