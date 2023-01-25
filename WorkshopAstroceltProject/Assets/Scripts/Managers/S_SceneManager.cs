using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SceneManager : MonoBehaviour
{
    [Header("Scene Changes")]
    public int i_sceneIndex;

    [Header("Reward Canvas")]
    public GameObject r_rewardCanvas;

    [Header("Final Scene Bool")]
    public bool b_finalScene = false;

    [Header("After this reward scene")]
    public bool b_toEventScene = false;
    public int[] ls_i_eventIndices;

    [Header("Next Turn Button")]
    public GameObject nextTurnButton;

    private S_Global g_global;

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    /// <summary>
    /// Used to by end and lose screens to bring back to the first scene
    /// - Josh
    /// </summary>
    public void Scene0()
    {
        SceneManager.LoadSceneAsync(0);
    }


    /// <summary>
    /// Used to exit the game on the win and lose screens
    /// - Josh
    /// </summary>
    public void Exit()
    {
        Debug.Log("Exit the Game!!!");
        Application.Quit();
    }


    /// <summary>
    /// This function changes the scene to the player reward scene
    /// -Riley
    /// </summary>
    public void ChangeSceneReward()
    {
        if(g_global.g_rewardVisualScript.b_rewardClaimed)
        {
            SceneManager.LoadScene(i_sceneIndex);
        }
    }

    public void ChangeScene() 
    {
        SceneManager.LoadScene(i_sceneIndex);
    }

    public void ToEventScene()
    {
            //if this goes to a reward scene chose a random one
            SceneManager.LoadScene(ls_i_eventIndices[Random.Range(0, ls_i_eventIndices.Length)]);
    }

    public void DisplayRewards()
    {
        nextTurnButton.SetActive(false);

        //lock out the player from drawing
        g_global.g_ConstellationManager.SetStarLockOutBool(false);

        g_global.g_ConstellationManager.DeleteWholeCurConstellation();

        // Line removal
        g_global.g_DrawingManager.b_lineDeletionCompletion = false;
        StartCoroutine(g_global.g_DrawingManager.LineDeletion());

        //clear the energy
        g_global.g_energyManager.ClearEnergy();

        // Turn Off Maps
        g_global.g_backgroundManager.TurnOffMaps();

        //Clear Popups
        //StartCoroutine(g_global.g_popupManager.ClearAllPopups());

        r_rewardCanvas.SetActive(true);
    }
}
