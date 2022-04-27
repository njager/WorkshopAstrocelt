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
    public void PlayPhysicalAttack()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Sounds/Attack & Ability/Attack_Vanilla");
    }
    public void PlayMagicAttack()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/attack-magic");
    }
    public void PlayPhysicalShield()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/shield-physical");
    }
    public void PlayMagicShield()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/shield-magic");
    }
    public void PlayStun()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/stat-stun");
    }
    public void PlayResist()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/stat-resist");
    }
    public void PlayPoison()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/stat-poison");
    }
    public void PlayBleed()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Jager G421/stat-bleed");
    }
}
