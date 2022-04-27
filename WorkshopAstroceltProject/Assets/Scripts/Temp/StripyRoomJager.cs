using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StripyRoomJager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DigSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/stat-resist");
        FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
    }
}
