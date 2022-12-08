using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SceneManager : MonoBehaviour
{
    [Header("Scene Changes")]
    public int i_sceneIndex;


    [Header("Final Scene Bool")]
    public bool b_finalScene = false;

    [Header("After this reward scene")]
    public bool b_toRewardScene = false;
    public int[] ls_i_rewardIndices;



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
    public void ChangeScene()
    {
        Debug.Log("Have not set the index for the reward scene");
        if (b_toRewardScene)
        {
            //if this goes to a reward scene chose a random one
            SceneManager.LoadScene(ls_i_rewardIndices[Random.Range(0, ls_i_rewardIndices.Length)]); 
        }
        else
        {
            SceneManager.LoadScene(i_sceneIndex);
        }
    }
}
