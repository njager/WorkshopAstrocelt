using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_ResponseManager : MonoBehaviour
{
    public Image i_responseBackground;

    [Header("Colors for Hovering")]
    public Color cl_responseNormalColor;
    public Color cl_responseColor;

    public Response r_response;

    public S_EventManager s_eventManager;

    //Vars for changing the scene in the event encounter
    public bool b_clicked = false;
    public int i_sceneID;

    private S_GameManager s_gameManager;

    private void Start()
    {
        s_gameManager = S_GameManager.Instance;
    }

    /// <summary>
    /// This function starts the logic to deal out a failure to the player and change the text
    /// </summary>
    public void Failure()
    {
        if (r_response.r_reward.b_healthReward)
        {
            s_gameManager.SetHealth(s_gameManager.GetHealth() - r_response.r_reward.i_failureValue);
        }
        else if (r_response.r_reward.b_boneReward)
        {
            s_gameManager.SetBones(s_gameManager.GetBones() - r_response.r_reward.i_failureValue);
        }
        else if (r_response.r_reward.b_cardReward)
        {
            Debug.Log("Not implamented random card removal");
        }
        else
        {
            Debug.Log("This response doesnt have a failure type");
        }

        //set the text for the event description 
        s_eventManager.SetDescriptionBox(r_response.s_failureText);

        //remove all the responses
        s_eventManager.DeleteResponses();

        //load in the new response that will change the scene
        s_eventManager.NewResopnse("Click to go to the next level");
    }

    /// <summary>
    /// This function starts the logic chain to give the reward to the player and change the text
    /// </summary>
    public void Rewarding()
    {
        if (r_response.r_reward.b_healthReward)
        {
            s_gameManager.SetHealth(s_gameManager.GetHealth() + r_response.r_reward.i_value);
        }
        else if (r_response.r_reward.b_boneReward)
        {
            s_gameManager.SetBones(s_gameManager.GetBones() + r_response.r_reward.i_value);
        }
        else if (r_response.r_reward.b_cardReward)
        {
            s_gameManager.AddCards(r_response.r_reward.i_value);
        }
        else
        {
            Debug.Log("This response doesnt have a reward type");
        }

        //set the text box
        s_eventManager.SetDescriptionBox(r_response.r_reward.s_rewardString);

        //delete all the other responses
        s_eventManager.DeleteResponses();

        //create the next turn and scene text
        s_eventManager.NewResopnse("Click to go to the next level");
    }


    /// <summary>
    /// Trigger the function to deal a reward or failure
    /// gets called from an event listener
    /// </summary>
    public void TriggerResponse()
    {
        //if this is the second response, jut trigger the scene manager
        if (b_clicked)
        {
            SceneManager.LoadScene(i_sceneID);
        }
        else
        {
            int _random = Random.Range(0, 100);

            //if below the percent chance then trigger a failure otherwise give them a reward
            if (_random <= r_response.f_failureChance)
            {
                Failure();
            }
            else
            {
                Rewarding();
            }
        }
    }

    /// <summary>
    /// Change the color to a darker one when hovered
    /// </summary>
    public void ChangeHoverColor()
    {
        i_responseBackground.color = cl_responseColor;
    }

    /// <summary>
    /// reset the color to the original one
    /// </summary>
    public void RestoreHoverColor()
    {
        i_responseBackground.color = cl_responseNormalColor;
    }
}
