using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_VFXManager : MonoBehaviour
{
    [Header("Global Track")]
    [SerializeField] S_Global g_global;

    [Header("Enemy Hurts Player")]
    [SerializeField] ParticleSystem pe_enemyAttacksPlayer;

    [Header("Player Hurts Enemy")]
    [SerializeField] ParticleSystem pe_playerAttacksEnemy;

    [Header("Player Shields")]
    [SerializeField] ParticleSystem pe_playerShields;

    [Header("Enemy Shields")]
    [SerializeField] ParticleSystem pe_enemyShields;

    [Header("Enemy Special - General")]
    [SerializeField] ParticleSystem pe_enemySpecialGeneral;

    [Header("Red Card Spawn")]
    [SerializeField] ParticleSystem pe_redCardSpawn;

    [Header("Blue Card Spawn")]
    [SerializeField] ParticleSystem pe_blueCardSpawn;

    [Header("Yellow Card spawn")]
    [SerializeField] ParticleSystem pe_yellowCardSpawn;

    [Header("White Card Spawn")]
    [SerializeField] ParticleSystem pe_whiteCardSpawn;

    [Header("Enemy Died")]
    [SerializeField] ParticleSystem pe_enemyDied;

    [Header("Reward Scene")]
    [SerializeField] ParticleSystem pe_rewardScene;

    [Header("Reward Chosen")]
    [SerializeField] ParticleSystem pe_rewardChosen;

    [Header("End Turn Clicked")]
    [SerializeField] ParticleSystem pe_endTurnClicked;

    [Header("Star Connected")]
    [SerializeField] ParticleSystem pe_starConnected;

    [Header("Constellation Completed")]
    [SerializeField] ParticleSystem pe_constellationCompleted;

    [Header("Ui for down camera")]
    public List<GameObject> ls_downCamUI;

    [Header("Ui for up camera")]
    public List<GameObject> ls_upCamUI;

    [Header("MapPan Button")]
    public GameObject bt_mapPanButton;

    [Header("EnemyUI Slots")]
    public GameObject e_enemyUI1;
    public GameObject e_enemyUI2;
    public GameObject e_enemyUI3;

    [Header("EnemyUI Slots")]
    public Image e_enemyImageUI1;
    public Image e_enemyImageUI2;
    public Image e_enemyImageUI3;

    [Header("EnemyUI Headshot Images")]
    public Sprite i_clurichaunHeadshot;
    public Sprite i_pucaHeadshot;
    public Sprite i_troupeHeadshot;
    public Sprite i_bananachHeadshot;
    public Sprite i_bodachHeadshot;

    //private vars
    private bool b_camPanPos = false; //false means down true means up

    private void Awake()
    {
        g_global = S_Global.Instance;

        //turn off up ui
        foreach (GameObject ui in ls_upCamUI)
        {
            StartCoroutine(FadeOut(ui.GetComponent<CanvasGroup>()));
        }
    }


    private void Start()
    {
        foreach (S_Enemy _enemy in g_global.g_ls_activeEnemies)
        {
            _enemy.UpdateEnemyHealthUI();
        }

        //Set the number and image for the enemy ui
        if (g_global.g_enemyState.GetEnemyActiveState(1) == true)
        {
            e_enemyUI1.SetActive(true);

            if (g_global.g_enemyAttributeSheet1.e_str_enemyType == "Magician")
            {
                e_enemyImageUI1.sprite = i_clurichaunHeadshot;
            }
            if (g_global.g_enemyAttributeSheet1.e_str_enemyType == "Brawler")
            {

            }
        }
        else { e_enemyUI1.SetActive(false); }

        //Set the number and image for the enemy ui
        if (g_global.g_enemyState.GetEnemyActiveState(2) == true)
        {
            e_enemyUI2.SetActive(true);

            if (g_global.g_enemyAttributeSheet2.e_str_enemyType == "Magician")
            {
                e_enemyImageUI2.sprite = i_clurichaunHeadshot;
            }
            if (g_global.g_enemyAttributeSheet2.e_str_enemyType == "Brawler")
            {

            }
        }
        else
        { e_enemyUI2.SetActive(false); }

        //Set the number and image for the enemy ui
        if (g_global.g_enemyState.GetEnemyActiveState(3) == true)
        {
            e_enemyUI3.SetActive(true);

            if (g_global.g_enemyAttributeSheet3.e_str_enemyType == "Magician")
            {
                e_enemyImageUI3.sprite = i_clurichaunHeadshot;
            }
            if (g_global.g_enemyAttributeSheet3.e_str_enemyType == "Brawler")
            {

            }
        }
        else { e_enemyUI3.SetActive(false); }
    }

    /// <summary>
    /// Card spawn particle effect triggers
    /// - Josh
    /// </summary>
    /// <param name="_color"></param>
    public void TriggerParticleEffects(string _color)
    {
        if (_color == "blue")
        {
            pe_blueCardSpawn.Play();
        }
        else if (_color == "red")
        {
            pe_redCardSpawn.Play();
        }
        else if (_color == "yellow")
        {
            pe_yellowCardSpawn.Play();
        }
        else if (_color == "white")
        {
            pe_whiteCardSpawn.Play();
        }
    }

    /// <summary>
    /// function is tied to a button that pans the camera in the overworld. 
    /// the camera can only be one or the other state
    /// -Thats Riley Halloran to you Sir
    /// </summary>
    public void PanCamera()
    {
        if (g_global.g_cam != null)
        {
            if (b_camPanPos == true) //is up
            {
                //swap the val
                b_camPanPos = false;

                //Pan the camera down
                g_global.g_cam.transform.DOMove(g_global.g_cam.transform.position + Vector3.up * -12, 1f);

                //Set rotation for the button
                bt_mapPanButton.transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);

                //turn off up ui
                foreach (GameObject ui in ls_upCamUI)
                {
                    StartCoroutine(FadeOut(ui.GetComponent<CanvasGroup>()));
                }

                //turn on down ui
                foreach (GameObject ui in ls_downCamUI)
                {
                    StartCoroutine(FadeIn(ui.GetComponent<CanvasGroup>()));
                }

                //check if there is an available card ball
                g_global.g_altar.CreateCardFromList();
            }
            else //is down
            {
                //swap the val
                b_camPanPos = true;

                //Pan the camera up
                g_global.g_cam.transform.DOMove(g_global.g_cam.transform.position + Vector3.up * 12, 1f);

                //turn off down ui
                foreach (GameObject ui in ls_downCamUI)
                {
                    StartCoroutine(FadeOut(ui.GetComponent<CanvasGroup>()));
                }

                //turn on up ui
                foreach (GameObject ui in ls_upCamUI)
                {
                    StartCoroutine(FadeIn(ui.GetComponent<CanvasGroup>()));
                }

                //set rotation for the button
                bt_mapPanButton.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            }
        }
    }

    /// <summary>
    /// Fade out elements
    /// </summary>
    /// <param name="canvas"></param>
    /// <returns></returns>
    public IEnumerator FadeOut(CanvasGroup canvas)
    {
        for (float i = 1; i >= 0; i -= 0.05f)
        {
            canvas.alpha = i;
            yield return new WaitForEndOfFrame();
        }

        canvas.alpha = 0;
    }

    /// <summary>
    /// Fade in elements 
    /// </summary>
    /// <param name="canvas"></param>
    /// <returns></returns>
    public IEnumerator FadeIn(CanvasGroup canvas)
    {
        for (float i = 0; i <= 1; i += 0.05f)
        {
            canvas.alpha = i;
            yield return new WaitForEndOfFrame();
        }

        canvas.alpha = 1;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_enemyAttacksPlayer
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_enemyAttacksPlayer
    /// </returns>
    public ParticleSystem GetEnemyAttackedPlayerParticle()
    {
        return pe_enemyAttacksPlayer;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_playerShields
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_playerShields
    /// </returns>
    public ParticleSystem PlayerShieldsParticle()
    {
        return pe_playerShields;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_enemyShields
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_enemyShields
    /// </returns>
    public ParticleSystem EnemyShieldsParticle()
    {
        return pe_enemyShields;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_enemySpecialGeneral
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_enemySpecialGeneral
    /// </returns>
    public ParticleSystem GeneralEnemySpecialParticle()
    {
        return pe_enemySpecialGeneral;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_redCardSpawn
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_redCardSpawn
    /// </returns>
    public ParticleSystem RedCardSpawnParticle()
    {
        return pe_redCardSpawn;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_blueCardSpawn
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_blueCardSpawn
    /// </returns>
    public ParticleSystem BlueCardSpawnParticle()
    {
        return pe_blueCardSpawn;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_yellowCardSpawn
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_yellowCardSpawn
    /// </returns>
    public ParticleSystem YellowCardSpawnParticle()
    {
        return pe_yellowCardSpawn;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_whiteCardSpawn
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_whiteCardSpawn
    /// </returns>
    public ParticleSystem WhiteCardSpawnParticle()
    {
        return pe_whiteCardSpawn;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_enemyDied
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_enemyDied
    /// </returns>
    public ParticleSystem EnemyDied()
    {
        return pe_enemyDied;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_rewardScene
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_rewardScene
    /// </returns>
    public ParticleSystem RewardScene()
    {
        return pe_rewardScene;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_rewardChosen
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_rewardChosen
    /// </returns>
    public ParticleSystem RewardChosen()
    {
        return pe_rewardChosen;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_endTurnClicked
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_endTurnClicked
    /// </returns>
    public ParticleSystem EndTurnClicked()
    {
        return pe_rewardChosen;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_starConnected
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_starConnected
    /// </returns>
    public ParticleSystem StarConnected() 
    {
        return pe_starConnected;
    }

    /// <summary>
    /// Return the ParticleSystem of S_VFXManager.a_constellationCompleted
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_VFXManager.a_constellationCompleted
    /// </returns>
    public ParticleSystem ConstellationCompleted() 
    {
        return pe_constellationCompleted;
    }
}
