using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RedStarAnimation : MonoBehaviour
{
    //Get the red graphic animator
    public GameObject a_redGraphic;

    public Animator an_redStarAnimator;

    [Header("percent chance that the Animation plays")]
    public double i_chance = 0.0000002;

    [Header("# of frames before attempting to play animation")]
    public int i_frames;

    public IEnumerator PlayAnimation()
    {
        yield return new WaitForEndOfFrame();

        
        an_redStarAnimator.Play("RedAnim");
    }
}
