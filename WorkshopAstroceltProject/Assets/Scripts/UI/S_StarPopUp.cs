using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 
using TMPro;
using CodeMonkey.Utils;
using DG.Tweening;
using Unity.VectorGraphics;
using Unity.VectorGraphics.Editor;

public class S_StarPopUp : MonoBehaviour
{
    private S_Global g_global;
    private bool b_deletionTimerFlag;
    private SVGImage colorImage;

    [Header("Color Bools")]
    [SerializeField] bool b_redPopup;
    [SerializeField] bool b_bluePopup;
    [SerializeField] bool b_yellowPopup;

    [Header("Deletion Timer Attributes")]
    [SerializeField] float f_disappearTimer;
    [SerializeField] float f_destroyTimer = 1f;
    [SerializeField] float f_doFadeAlpha;
    [SerializeField] float f_doFadeDuration;

    [Header("Color Graphics")]
    public GameObject redColorGraphic;
    public GameObject blueColorGraphic;
    public GameObject yellowColorGraphic;

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

    public void SetGraphic(string _color)
    {
        if(_color == "red")
        {

        }
        if(_color == "blue")
        {

        }
        if(_color == "yellow")
        {

        }
    }

    public void DeletePopup()
    {
        StartCoroutine(DeletionTimer());
    }

}
