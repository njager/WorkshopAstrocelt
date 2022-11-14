using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;
    public TMP_Text resolutionLabel;
    public Toggle fullscreenTog;

    [Header("Tutorial Canvas Bool")]
    public bool tutorialBoolState;

    [Header("Background")]
    public GameObject UI_background;
    public GameObject mainMenuAssets;
    public GameObject optionsMenuAssets;

    private S_Global g_global;

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(optionsMenuAssets.activeInHierarchy == false) 
            {
                Debug.Log("esc hit");
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
    }

    public void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;
        bool foundRes = false;
        for (int i =0; i < resolutions.Count; i++)
        {
            if(Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
            {
                foundRes = true;
                selectedResolution = i;
                updateResLabel();
            }
        }

      /*  if (tutorialCanvas.isActiveAndEnabled)
        {
            GameObject.setActive = false;
        }*/
    }

    public void Resume()
    {
        UI_background.SetActive(false);
        mainMenuAssets.SetActive(false);
        optionsMenuAssets.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        UI_background.SetActive(true);
        mainMenuAssets.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    /*public void LoadMenu()
    {
        //Unity
    }*/

    public void QuitGame()
    {
        //Debug.Log("Quit");
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
    }

    public void TutorialCanvasToggle() 
    {
        g_global.g_tutorialCanvas.SetActive(g_global.g_b_tutorialCanvasState);
        g_global.g_b_tutorialCanvasState = !g_global.g_b_tutorialCanvasState;
    }
}



[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
