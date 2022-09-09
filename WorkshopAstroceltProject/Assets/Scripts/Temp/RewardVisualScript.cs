using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardVisualScript : MonoBehaviour
{
    [SerializeField] GameObject lReward;
    [SerializeField] GameObject rReward;
    [SerializeField] GameObject lRewardCover;
    [SerializeField] GameObject rRewardCover;

    public S_GameManager s_gameManager;

    private void Start()
    {
        s_gameManager = S_GameManager.Instance;
    }

    public void LeftRewardButtonClick()
    {
        lRewardCover.SetActive(false);
        rRewardCover.SetActive(false);
        lReward.SetActive(true);

        s_gameManager.gm_ls_p_playerDeck.Add(11);
    }
    public void RightRewardButtonClick()
    {
        lRewardCover.SetActive(false);
        rRewardCover.SetActive(false);
        rReward.SetActive(true);

        s_gameManager.gm_ls_p_playerDeck.Add(10);
    }
}
