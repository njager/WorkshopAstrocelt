using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_SceneManager : MonoBehaviour
{
    [Header("Scene Changes")]
    public int i_rewardSceneIndex;

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
    /// Change the scene to the scene with that index
    /// -Riley Halloran
    /// </summary>
    /// <param name="_index"></param>
    public void ChangeScene(int _index)
    {
        SceneManager.LoadScene(_index);
    }


    /// <summary>
    /// This function changes the scene to the player reward scene
    /// -Riley
    /// </summary>
    public void RewardScene()
    {
        Debug.Log("Have not set the index for the reward scene");
        SceneManager.LoadScene(i_rewardSceneIndex);
    }
}
