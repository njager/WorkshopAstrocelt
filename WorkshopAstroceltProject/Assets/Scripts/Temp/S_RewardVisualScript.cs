using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RewardVisualScript : MonoBehaviour
{
    [SerializeField] GameObject lReward;
    [SerializeField] GameObject rReward;

    [SerializeField] GameObject lRewardSelector;
    [SerializeField] GameObject rRewardSelector;

    [SerializeField] int[] ls_cardBundle1;
    [SerializeField] int[] ls_cardBundle2;

    public bool b_rewardClaimed = false;

    public S_GameManager s_gameManager;

    private void Start()
    {
        s_gameManager = S_GameManager.Instance;
    }

    public void LeftRewardButtonClick()
    {
        Debug.Log("Did this happen?");
        if (!b_rewardClaimed)
        {
            b_rewardClaimed = true;

            lReward.SetActive(true);

            lRewardSelector.SetActive(false);


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

            rReward.SetActive(true);

            rRewardSelector.SetActive(false);

            foreach (int _cardID in ls_cardBundle2)
            {
                s_gameManager.gm_ls_p_playerDeck.Add(_cardID);
            }
        }
    }
}
