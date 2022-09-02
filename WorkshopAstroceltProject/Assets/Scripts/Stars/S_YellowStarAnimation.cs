using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_YellowStarAnimation : MonoBehaviour
{
    //Get the redgraphic animator
    public GameObject g_yellowGraphic;

    public Animator an_animator;

    [Header("percent chance that the Animation plays")]
    public double i_chance = 0.0000002;

    [Header("# of frames before attempting to play animation")]
    public int i_frames;

    private void Awake()
    {
        an_animator = g_yellowGraphic.GetComponent<Animator>();

        StartCoroutine(PlayYellowAnimation());
    }

    public IEnumerator PlayYellowAnimation()
    {
        for (int i = 0; i <= i_frames; i++)
        {
            yield return new WaitForEndOfFrame();
        }

        float _percent = Random.value;

        if (_percent < i_chance)
        {
            print("Yellow");
            //Reset the "Crouch" trigger
            //a_animator.ResetTrigger("YellowAnim");

            an_animator.Play("YellowAnim");
        }
        StartCoroutine(PlayYellowAnimation());
    }
}
