using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BlueStarAnimation : MonoBehaviour
{
    //Get the redgraphic animator
    public GameObject g_blueGraphic;

    public Animator a_animator;

    [Header("percent chance that the Animation plays")]
    public double i_chance = 0.0000002;

    [Header("# of frames before attempting to play animation")]
    public int i_frames;

    private void Awake()
    {
        a_animator = g_blueGraphic.GetComponent<Animator>();

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
            a_animator.Play("BlueAnim");
        }
        StartCoroutine(PlayBlueAnimation());
    }
}
