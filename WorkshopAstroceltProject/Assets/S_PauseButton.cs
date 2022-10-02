using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PauseButton : MonoBehaviour
{
    public S_PauseMenu pm_pauseMenuObj;

    void OnMouseDown()
    {
        pm_pauseMenuObj.Pause();
    }
}
