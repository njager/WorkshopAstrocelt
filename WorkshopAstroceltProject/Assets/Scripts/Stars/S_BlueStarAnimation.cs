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

    private void Awake()
    {
        StartCoroutine(PlayBlueAnimation());
    }

    public IEnumerator PlayBlueAnimation()
    {
        for (int i = 0; i <= i_frames; i++)
        {
            yield return new WaitForEndOfFrame();
        }

        float _percent = Random.value;

        if (_percent < i_chance)
        {
            //print("Blue");

            //Send the message to the Animator to activate the trigger parameter named "BlueAnim"
            an_blueStarAnimator.Play("BlueAnim");
        }
        StartCoroutine(PlayBlueAnimation());
    }
}
