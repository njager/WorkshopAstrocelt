using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardVisualScript : MonoBehaviour
{
    [SerializeField] GameObject lReward;
    [SerializeField] GameObject rReward;
    [SerializeField] GameObject lRewardCover;
    [SerializeField] GameObject rRewardCover;

    public void LeftRewardButtonClick()
    {
        lRewardCover.SetActive(false);
        rRewardCover.SetActive(false);
        lReward.SetActive(true);
    }
    public void RightRewardButtonClick()
    {
        lRewardCover.SetActive(false);
        rRewardCover.SetActive(false);
        rReward.SetActive(true);
    }
}
