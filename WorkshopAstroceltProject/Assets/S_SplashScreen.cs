using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SplashScreen : MonoBehaviour
{
    // Timer
    [SerializeField] float f_timer = 10f;

    // Splash Screen
    [SerializeField] GameObject splashScreen;

    // Update is called once per frame
    void Update()
    {
        if(splashScreen.activeInHierarchy == true) 
        {
            if (f_timer < 0)
            {
                splashScreen.SetActive(false);
            }
            else 
            {
                f_timer -= Time.deltaTime;
            }
        }
    }
}
