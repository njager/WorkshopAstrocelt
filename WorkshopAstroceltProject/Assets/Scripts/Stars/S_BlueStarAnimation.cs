using System.Collections;
using UnityEngine;

public class S_BlueStarAnimation : MonoBehaviour
{
    //Get the blue graphic animator
    public GameObject a_blueGraphic;

    public Animator an_blueStarAnimator;

    [Header("percent chance that the Animation plays")]
    public double i_chance = 0.0000002;

    [Header("# of frames before attempting to play animation")]
    public int i_frames;

    public IEnumerator PlayBlueAnimation()
    {
        yield return new WaitForEndOfFrame();

        an_blueStarAnimator.Play("BlueAnim");        
    }
}
