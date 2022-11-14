using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_YellowStarAnimation : MonoBehaviour
{
    //Get the yellow graphic animator
    public GameObject a_yellowGraphic;

    public Animator an_yellowStarAnimator;

    [Header("percent chance that the Animation plays")]
    public double i_chance = 0.0000002;

    [Header("# of frames before attempting to play animation")]
    public int i_frames;

    public IEnumerator PlayYellowAnimation()
    {
        yield return new WaitForEndOfFrame();

        an_yellowStarAnimator.Play("YellowAnim");
    }
}
