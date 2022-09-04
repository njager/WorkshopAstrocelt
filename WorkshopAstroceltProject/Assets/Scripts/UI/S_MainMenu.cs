using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_MainMenu: MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }   
    }

    public void Play()
    {
        //SceneManger.LoadScene(7);
        SceneManger.LoadScene(SceneManager.GetActiveScene());
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    /*public void LoadMenu()
    {
        //Unity
    }*/

    public void QuitGame()
    {
        Debug.Log("Quit");
// Application.Quit();
    }
}
