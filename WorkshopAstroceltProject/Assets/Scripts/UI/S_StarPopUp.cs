using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
using TMPro;
using CodeMonkey.Utils;
using DG.Tweening;

public class S_StarPopUp : MonoBehaviour
{
    private S_Global g_global;
    private bool b_deletionTimerFlag;

    [Header("Color Bools")]
    [SerializeField] bool b_useRed;
    [SerializeField] bool b_useYellow;
    [SerializeField] bool b_useBlue;

    [Header("Deletion Timer Attributes")]
    [SerializeField] float f_disappearTimer;
    [SerializeField] float f_destroyTimer = 1f;
    [SerializeField] float f_doFadeAlpha;
    [SerializeField] float f_doFadeDuration;

    /// <summary>
    /// Set up global, add to list, and deletion timer
    /// </summary>
    void Awake()
    {
        g_global = S_Global.Instance;
        g_global.ls_starPopup.Add(this); 
        b_deletionTimerFlag = false;
    }

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

}
