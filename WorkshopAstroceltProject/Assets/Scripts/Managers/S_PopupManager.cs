using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;
using DG.Tweening;

public class S_PopupManager : MonoBehaviour
{
    //private variables
    private S_Global g_global;

    [Header("Clearing Bool")]
    public bool PopupClear; 

    [Header("Position Data")]
    [SerializeField] Vector3 v3_startingTextPopupPosition; 
    [SerializeField] Vector3 p_v3_playerHealthBarPosition;
    [SerializeField] Vector3 e_v3_enemy1HealthBarPosition;
    [SerializeField] Vector3 e_v3_enemy2HealthBarPosition;
    [SerializeField] Vector3 e_v3_enemy3HealthBarPosition;
    [SerializeField] Vector3 e_v3_enemy4HealthBarPosition;
    [SerializeField] Vector3 e_v3_enemy5HealthBarPosition;

    [Header("Prefabs")]
    public GameObject textPopupPrefab;
    public GameObject energyPopupPrefab;

    [Header("Canvas")]
    public GameObject popUpCanvas;

    [Header("Line Multiplier Tier")]
    public int i_lineTier; // Inform this from energy manager

    //get the transform component of the text
    private void Awake()
    {
        g_global = S_Global.Instance;
        DOTween.Init();
        PopupClear = false; 
    }

    /// <summary>
    /// Create and activate a popup for Character UI
    /// -Josh
    /// </summary>
    /// <param name="character"></param>
    public void CreatePopupForCharacter(Vector3 _characterLocation)
    {
        GameObject _textPopUpObject = Instantiate(textPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
        S_TextPopUp _textPopUpScript = _textPopUpObject.GetComponent<S_TextPopUp>();
        _textPopUpScript.SetGivenPosition(_characterLocation);
        _textPopUpScript.StartCoroutine(_textPopUpScript.MovePopUp());
    }


    /// <summary>
    /// Create and activate a popup for the constellation
    /// Use current line tier from the constellation to generate the proper star amounts
    /// - Josh
    /// </summary>
    /// <param name="_star"></param>
    /// <param name="_starLocation"></param>
    public void CreatePopUpForStar(S_StarClass _star, Vector3 _starLocation)
    {
        int _lineTier = LineTiers();

        if(_lineTier == 1)
        {
            // Int for tracking how many popups there have been
            int _popupCount = 0;

            //Spawn Star 1
            GameObject _starPopup1 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
            S_StarPopUp _starPopupScript1 = _starPopup1.GetComponent<S_StarPopUp>();
            _popupCount += 1;

            // Set up Star 1
            _starPopupScript1.SetPosition(_popupCount, _star);
            _starPopupScript1.SetGraphic(_star.starType);

        }
        else if(_lineTier == 2)
        {
            // Int for tracking how many popups there have been
            int _popupCount = 0;

            // Spawn Star 1
            GameObject _starPopup1 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
            S_StarPopUp _starPopupScript1 = _starPopup1.GetComponent<S_StarPopUp>();
            _popupCount += 1;

            // Set up Star 1
            _starPopupScript1.SetPosition(_popupCount, _star);
            _starPopupScript1.SetGraphic(_star.starType);

            // Spawn Star 2
            GameObject _starPopup2 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
            S_StarPopUp _starPopupScript2 = _starPopup2.GetComponent<S_StarPopUp>();
            _popupCount += 1;

            // Set up Star 2
            _starPopupScript2.SetPosition(_popupCount, _star);
            _starPopupScript2.SetGraphic(_star.starType);

        }
        else if(_lineTier == 3)
        {
            // Int for tracking how many popups there have been
            int _popupCount = 0;

            // Spawn Star 1
            GameObject _starPopup1 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
            S_StarPopUp _starPopupScript1 = _starPopup1.GetComponent<S_StarPopUp>();
            _popupCount += 1;

            // Set up Star 1
            _starPopupScript1.SetPosition(_popupCount, _star);
            _starPopupScript1.SetGraphic(_star.starType);

            // Spawn Star 2
            GameObject _starPopup2 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
            S_StarPopUp _starPopupScript2 = _starPopup2.GetComponent<S_StarPopUp>();
            _popupCount += 1;

            // Set up Star 2
            _starPopupScript2.SetPosition(_popupCount, _star);
            _starPopupScript2.SetGraphic(_star.starType);

            // Spawn Star 3
            GameObject _starPopup3 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
            S_StarPopUp _starPopupScript3 = _starPopup3.GetComponent<S_StarPopUp>();
            _popupCount += 1;

            // Set up Star 3
            _starPopupScript3.SetPosition(_popupCount, _star);
            _starPopupScript3.SetGraphic(_star.starType);
        }

        
    }

    public int LineTiers()
    {
        foreach (GameObject _line in g_global.g_ls_lineRendererList.ToList())
        {
            g_global.g_lineMultiplierManager.LineMultiplier(_line);
        }
        return (int)g_global.g_lineMultiplierManager.f_totalLineLength; 
    }

    public IEnumerator ClearAllPopups()
    {
        foreach(S_StarPopUp starPop in g_global.ls_starPopup.ToList())
        {
            starPop.DeletePopup();
        }
        PopupClear = true; 
        yield return PopupClear == true; 
    }
}
