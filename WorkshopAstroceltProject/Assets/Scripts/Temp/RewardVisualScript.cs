using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardVisualScript : MonoBehaviour
{
    [SerializeField] GameObject lReward;
    [SerializeField] GameObject rReward;
    [SerializeField] GameObject lRewardCover;
    [SerializeField] GameObject rRewardCover;

    [SerializeField] GameObject lRewardSelector;
    [SerializeField] GameObject rRewardSelector;

    [SerializeField] int[] ls_cardBundle1;
    [SerializeField] int[] ls_cardBundle2;

    private bool b_rewardClaimed = false;

    public S_GameManager s_gameManager;

    private void Start()
    {
        s_gameManager = S_GameManager.Instance;
    }

    public void LeftRewardButtonClick()
    {
        if (!b_rewardClaimed)
        {
            b_rewardClaimed = true;

            lRewardCover.SetActive(false);
            lReward.SetActive(true);

            rRewardCover.SetActive(false);
            rRewardSelector.SetActive(false);

            foreach (int _cardID in ls_cardBundle1)
            {
                s_gameManager.gm_ls_p_playerDeck.Add(_cardID);
            }
        }
    }
    public void RightRewardButtonClick()
    {
        if (!b_rewardClaimed)
        {
            b_rewardClaimed = true;

            rRewardCover.SetActive(false);
            rReward.SetActive(true);


            lRewardCover.SetActive(false);
            lRewardSelector.SetActive(false);

            foreach (int _cardID in ls_cardBundle2)
            {
                s_gameManager.gm_ls_p_playerDeck.Add(_cardID);
            }
        }
    }
}
