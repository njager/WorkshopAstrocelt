using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RewardParticles : MonoBehaviour
{
    [SerializeField] ParticleSystem cardHover;
    [SerializeField] ParticleSystem cardClick;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CardTake()
    {
        cardClick.Play();
    }

    public void CardHover()
    {

    }
}
