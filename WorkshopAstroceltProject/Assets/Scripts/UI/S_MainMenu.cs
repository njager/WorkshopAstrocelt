using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class S_MainMenu: MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;
    public TMP_Text resolutionLabel;
    public TMP_Text resolutionLabel2;
    public Toggle fullscreenTog;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                //Resume();
            }
            else
            {
                Pause();
            }
        }   
    }

    public void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;
        bool foundRes = false;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selectedResolution = i;
                updateResLabel();
            }
        }
    }




    public void Play()
    {
        //SceneManger.LoadScene(7);
        //SceneManger.LoadScene(SceneManager.GetActiveScene());
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
        Application.Quit();
    }


    public void ResLeft()
    {
        Debug.Log("left clicked");
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        updateResLabel();
        print(selectedResolution);

    }
    public void ResRight()
    {
        Debug.Log("right clicked");
        selectedResolution++;
        if (selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }
        updateResLabel();
        print(selectedResolution);
    }

    public void ApplyGraphics()
    {
        Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);
    }

    public void updateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
        resolutionLabel2.text = resolutionLabel.text;
    }
}
