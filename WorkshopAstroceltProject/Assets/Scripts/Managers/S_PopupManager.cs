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
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Script Setup \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    
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
    [SerializeField] public Transform v3_vfxContainer; 

    [Header("Prefabs")]
    public GameObject textPopupPrefab;
    public GameObject energyPopupPrefab;

    [Header("Canvas")]
    public GameObject popUpCanvas;

    [Header("Altar Popup Target Positions")]
    public GameObject redEnergyUITargetPosition;
    public GameObject blueEnergyUITargetPosition;
    public GameObject yellowEnergyUITargetPosition;

    [Header("Popup Visual Decrement Bool")]
    public bool b_visualPopupFinished;

    [Header("Int test value")]
    public int i_popupUpClearInt;

    [Header("Particle effects")]
    [SerializeField] ParticleSystem pe_redParticle;
    [SerializeField] ParticleSystem pe_blueParticle;
    [SerializeField] ParticleSystem pe_yellowParticle;

    [Header("Temporary Popup Colors")]
    [SerializeField] Color redPopupTempColor;
    [SerializeField] Color bluePopupTempColor;
    [SerializeField] Color yellowPopupTempColor;

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
    /// /// <param name="_isTempStar"></param>
    public void CreatePopUpForStar(S_StarClass _star, int _energy, bool _isTempStar)
    {
        if (_star.starType.Equals("Node") || _star.starType.Equals("Null"))
        {
            return; 
        }
        else
        {
            if (_energy == 1)
            {
                // Int for tracking how many popups there have been
                int _popupCount = 0;

                //Spawn Star 1
                GameObject _starPopup1 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
                S_StarPopUp _starPopupScript1 = _starPopup1.GetComponent<S_StarPopUp>();
                _popupCount += 1;

                // Set up Star 1 V3 Position
                _starPopupScript1.SetPosition(_popupCount, _star);

                // Set Star 1 Graphic
                _starPopupScript1.SetTempStatus(_isTempStar);
                _starPopupScript1.SetGraphic(_star.colorType);

                // Add Popup to list
                _star.ls_energyPopups.Add(_starPopupScript1);

                // Move popup to container
                _starPopup1.transform.SetParent(v3_vfxContainer);

            }
            else if (_energy == 2)
            {
                // Int for tracking how many popups there have been
                int _popupCount = 0;

                // Spawn Star 1
                GameObject _starPopup1 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
                S_StarPopUp _starPopupScript1 = _starPopup1.GetComponent<S_StarPopUp>();
                _popupCount += 1;

                // Set up Star 1 V3 Position
                _starPopupScript1.SetPosition(_popupCount, _star);

                // Set Star 1 Graphic
                _starPopupScript1.SetTempStatus(_isTempStar);
                _starPopupScript1.SetGraphic(_star.colorType);

                // Spawn Star 2
                GameObject _starPopup2 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
                S_StarPopUp _starPopupScript2 = _starPopup2.GetComponent<S_StarPopUp>();
                _popupCount += 1;

                // Set up Star 2 V3 Position
                _starPopupScript2.SetPosition(_popupCount, _star);

                // Set Star 2 Graphic
                _starPopupScript2.SetTempStatus(_isTempStar);
                _starPopupScript2.SetGraphic(_star.colorType);

                // Add Popup to list
                _star.ls_energyPopups.Add(_starPopupScript1);
                _star.ls_energyPopups.Add(_starPopupScript2);

                // Move popups to container
                _starPopup1.transform.SetParent(v3_vfxContainer);
                _starPopup2.transform.SetParent(v3_vfxContainer);

            }
            else if (_energy == 3)
            {
                Debug.Log("Were spawning 3 popup");

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

                // Set up Star 2 V3 Position
                Debug.Log("Popup Count: " + _popupCount);
                _starPopupScript2.SetPosition(_popupCount, _star);

                // Set Star 2 Graphic
                _starPopupScript2.SetTempStatus(_isTempStar);
                _starPopupScript2.SetGraphic(_star.colorType);

                // Spawn Star 3
                GameObject _starPopup3 = Instantiate(energyPopupPrefab, v3_startingTextPopupPosition, Quaternion.identity);
                S_StarPopUp _starPopupScript3 = _starPopup3.GetComponent<S_StarPopUp>();
                _popupCount += 1;

                // Set up Star 3 V3 Position
                Debug.Log("Popup Count: " + _popupCount);
                _starPopupScript3.SetPosition(_popupCount, _star);

                // Set Star 3 Graphic
                _starPopupScript3.SetTempStatus(_isTempStar);
                _starPopupScript3.SetGraphic(_star.colorType);

                // Add Popup to list
                _star.ls_energyPopups.Add(_starPopupScript1);
                _star.ls_energyPopups.Add(_starPopupScript2);
                _star.ls_energyPopups.Add(_starPopupScript3);

                // Move popups to container
                _starPopup1.transform.SetParent(v3_vfxContainer);
                _starPopup2.transform.SetParent(v3_vfxContainer);
                _starPopup3.transform.SetParent(v3_vfxContainer);
            }
        }
    }

    /// <summary>
    /// Move all popups currently spawned to the altar
    /// - Josh
    /// </summary>
    /// <returns></returns>
    public IEnumerator TriggerPopupMove()
    {
        Debug.Log("Move bich");
        yield return new S_WaitForConstellationFinish();
        b_visualPopupFinished = true;

        foreach (S_StarPopUp _starPopup in g_global.g_ls_starPopup.ToList())
        {
            _starPopup.MovePopupToEnergyTracker();
        }

        b_popupClear = false;
        i_popupUpClearInt = g_global.g_ls_starPopup.Count;
        StartCoroutine(ClearPopupsForRound());
    }

    /// <summary>
    /// Someone's particle effect trigger
    /// - Josh
    /// </summary>
    /// <param name="_color"></param>
    public void TriggerParticleEffects(string _color)
    {
        if (_color == "blue")
        {
            pe_blueParticle.Play();
        }
        else if (_color == "red")
        {
            pe_redParticle.Play();
        }
        else if (_color == "yellow")
        {
            pe_yellowParticle.Play();
        }
        else if (_color == "white")
        {
            pe_blueParticle.Play();
            pe_redParticle.Play();
            pe_yellowParticle.Play();
        }
    }

    /// <summary>
    /// Remove all popups currently spawned from the scene
    /// - Josh
    /// </summary>
    /// <returns></returns>
    public IEnumerator ClearAllPopups()
    {

        Debug.Log("clear popup");

        foreach (S_StarPopUp _starPop in g_global.g_ls_starPopup.ToList())
        {
            _starPop.DeletePopup();
        }

        b_popupClear = true; 
        yield return b_popupClear == true; 
    }

    /// <summary>
    /// Remove all popups currently spawned from the scene
    /// - Josh
    /// </summary>
    /// <returns></returns>
    public IEnumerator ClearPopupsForRound()
    {
        foreach (S_StarPopUp _starPop in g_global.g_ls_starPopup.ToList())
        {
            StartCoroutine(_starPop.DeletionTimer());
            yield return new WaitForSeconds(0.5f);
        }

        if (i_popupUpClearInt == 0)
        {
            b_popupClear = true;
        }
        
        yield return b_popupClear == true;
    }

    /// <summary>
    /// Fix the color of a temporary popup and a new popup
    /// - Josh
    /// </summary>
    public void ConfirmTemporaryPopup()
    {
        // Grab the temp popup, should be last one in the list
        S_StarClass _lastStar = g_global.g_ConstellationManager.ls_curConstellation.ToList().Last();

        if(_lastStar.GetTemporaryVisualBool() == true)
        {
            foreach(Transform _parentTransform in _lastStar.tr_ls_popupParentTransforms.ToList())
            {
                if(_parentTransform.childCount == 1)
                {
                    // Access Popup
                    S_StarPopUp _childPopupScript = _parentTransform.GetChild(0).gameObject.GetComponent<S_StarPopUp>();

                    // Set to base color for graphic
                    _childPopupScript.ChangeToPermanentColor();
                }
            }
        }
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 

    /// <summary>
    /// /// Set the v3 value of S_PopupManager.redEnergyUITargetPosition.transform.position
    /// - Josh
    /// </summary>
    /// <param name="_newPosition"></param>
    public void SetRedPopupTargetPosition(Vector3 _newPosition) 
    {
        redEnergyUITargetPosition.transform.position = _newPosition;
    }

    /// <summary>
    /// /// Set the v3 value of S_PopupManager.blueEnergyUITargetPosition.transform.position
    /// - Josh
    /// </summary>
    /// <param name="_newPosition"></param>
    public void SetBluePopupTargetPosition(Vector3 _newPosition)
    {
        blueEnergyUITargetPosition.transform.position = _newPosition;
    }

    /// <summary>
    /// /// Set the v3 value of S_PopupManager.yellowEnergyUITargetPosition.transform.position
    /// - Josh
    /// </summary>
    /// <param name="_newPosition"></param>
    public void SetYellowPopupTargetPosition(Vector3 _newPosition)
    {
        yellowEnergyUITargetPosition.transform.position = _newPosition;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the v3 value of S_PopupManager.redEnergyTargetPosition
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PopupManager.redEnergyTargetPosition.transform.position
    /// </returns>
    public Vector3 GetRedPopupTargetPosition()
    {
        return redEnergyUITargetPosition.transform.position;
    }

    /// <summary>
    /// Return the v3 value of S_PopupManager.blueEnergyTargetPosition
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PopupManager.blueEnergyTargetPosition.transform.position
    /// </returns>
    public Vector3 GetBluePopupTargetPosition()
    {
        return blueEnergyUITargetPosition.transform.position;
    }

    /// <summary>
    /// Return the v3 value of S_PopupManager.yellowEnergyTargetPosition
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PopupManager.yellowEnergyTargetPosition.transform.position
    /// </returns>
    public Vector3 GetYellowPopupTargetPosition()
    {
        return yellowEnergyUITargetPosition.transform.position;
    }

    /// <summary>
    /// Return the bool value of S_PopupManager.b_visualPopupFinished
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PopupManager.b_visualPopupFinished
    /// </returns>
    public bool GetPopupVisualDecrementBool()
    {
        return b_visualPopupFinished;
    }

    /// <summary>
    /// Return the color value of S_PopupManager.redPopupTempColor
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PopupManager.redPopupTempColor
    /// </returns>
    public Color GetRedPopupTempColor()
    {
        return redPopupTempColor;
    }

    /// <summary>
    /// Return the color value of S_PopupManager.bluePopupTempColor
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PopupManager.bluePopupTempColor
    /// </returns>
    public Color GetBluePopupTempColor()
    {
        return bluePopupTempColor;
    }

    /// <summary>
    /// Return the color value of S_PopupManager.yellowPopupTempColor
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_PopupManager.yellowPopupTempColor
    /// </returns>
    public Color GetYellowPopupTempColor()
    {
        return yellowPopupTempColor;
    }
}
