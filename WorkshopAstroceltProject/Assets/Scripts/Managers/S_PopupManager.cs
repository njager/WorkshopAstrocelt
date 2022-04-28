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
    public bool b_popupClear;
    public bool b_popupMove;

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

    [Header("Altar Position")]
    public GameObject altarTargetPosition;

    //get the transform component of the text
    private void Awake()
    {
        g_global = S_Global.Instance;
        DOTween.Init();
        b_popupClear = false; 
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
    /// <param name="_energy"></param>
    public void CreatePopUpForStar(S_StarClass _star, int _energy)
    {
        int _lineTier = _energy;
        if(_star.starType == "NodeStar")
        {
            return; 
        }
        else
        {
            if (_lineTier == 1)
            {
                // Int for tracking how many popups there have been
                int _popupCount = 0;

                //Spawn Star 1
                GameObject _starPopup1 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
                S_StarPopUp _starPopupScript1 = _starPopup1.GetComponent<S_StarPopUp>();
                _popupCount += 1;

                // Set up Star 1
                _starPopupScript1.SetPosition(_popupCount, _star);
                _starPopupScript1.SetGraphic(_star.colorType);

            }
            else if (_lineTier == 2)
            {
                // Int for tracking how many popups there have been
                int _popupCount = 0;

                // Spawn Star 1
                GameObject _starPopup1 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
                S_StarPopUp _starPopupScript1 = _starPopup1.GetComponent<S_StarPopUp>();
                _popupCount += 1;

                // Set up Star 1
                _starPopupScript1.SetPosition(_popupCount, _star);
                _starPopupScript1.SetGraphic(_star.colorType);

                // Spawn Star 2
                GameObject _starPopup2 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
                S_StarPopUp _starPopupScript2 = _starPopup2.GetComponent<S_StarPopUp>();
                _popupCount += 1;

                // Set up Star 2
                _starPopupScript2.SetPosition(_popupCount, _star);
                _starPopupScript2.SetGraphic(_star.colorType);

            }
            else if (_lineTier == 3)
            {
                print("popup?");
                // Int for tracking how many popups there have been
                int _popupCount = 0;

                // Spawn Star 1
                GameObject _starPopup1 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
                S_StarPopUp _starPopupScript1 = _starPopup1.GetComponent<S_StarPopUp>();
                _popupCount += 1;

                // Set up Star 1
                _starPopupScript1.SetPosition(_popupCount, _star);
                _starPopupScript1.SetGraphic(_star.colorType);

                // Spawn Star 2
                GameObject _starPopup2 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
                S_StarPopUp _starPopupScript2 = _starPopup2.GetComponent<S_StarPopUp>();
                _popupCount += 1;

                // Set up Star 2
                _starPopupScript2.SetPosition(_popupCount, _star);
                _starPopupScript2.SetGraphic(_star.colorType);

                // Spawn Star 3
                GameObject _starPopup3 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
                S_StarPopUp _starPopupScript3 = _starPopup3.GetComponent<S_StarPopUp>();
                _popupCount += 1;

                // Set up Star 3
                _starPopupScript3.SetPosition(_popupCount, _star);
                _starPopupScript3.SetGraphic(_star.colorType);
            }
        }
    }

    public IEnumerator TriggerPopupMove()
    {
        foreach(S_StarPopUp _starPopup in g_global.ls_starPopup.ToList())
        {
            _starPopup.MoveToAltar();
        }
        yield return b_popupMove == true;
    }

    public IEnumerator ClearAllPopups()
    {
        foreach(S_StarPopUp _starPop in g_global.ls_starPopup.ToList())
        {
            _starPop.DeletePopup();
        }
        b_popupClear = true; 
        yield return b_popupClear == true; 
    }
}
