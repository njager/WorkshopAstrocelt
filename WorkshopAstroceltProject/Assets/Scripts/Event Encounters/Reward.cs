using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Reward
{

    [Header("Bone/Health amt or CardID")]
    [SerializeField] public int i_value;

    [Header("Message to the player after selecting the reward")]
    [TextArea(3,10)] 
    [SerializeField] public string s_rewardString;

    [Header("Bool for event type")]
    public bool b_boneReward;
    public bool b_healthReward;
    public bool b_cardReward;
}
