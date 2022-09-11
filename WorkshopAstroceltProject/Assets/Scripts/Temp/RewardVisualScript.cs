using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardVisualScript : MonoBehaviour
{
    [SerializeField] GameObject lReward;
    [SerializeField] GameObject rReward;
    [SerializeField] GameObject lRewardCover;
    [SerializeField] GameObject rRewardCover;

    [SerializeField] int[] ls_cardBundle1;
    [SerializeField] int[] ls_cardBundle2;


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

        foreach(int _cardID in ls_cardBundle1) 
        {
            s_gameManager.gm_ls_p_playerDeck.Add(_cardID);
        }
    }
    public void RightRewardButtonClick()
    {
        lRewardCover.SetActive(false);
        rRewardCover.SetActive(false);
        rReward.SetActive(true);

        foreach (int _cardID in ls_cardBundle2)
        {
            s_gameManager.gm_ls_p_playerDeck.Add(_cardID);
        }
    }
}
