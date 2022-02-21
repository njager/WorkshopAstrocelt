using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMan : MonoBehaviour
{
    public void Scene0()
    {
        SceneManager.LoadSceneAsync(0); 
    }
    public void Exit()
    {
        Debug.Log("Exit the Game!!!");
        Application.Quit();
    }
}
