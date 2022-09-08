using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Reward : MonoBehaviour
{

    protected int i_value;

    protected string s_rewardString;

    public abstract string toText();

    public abstract void reward();

    public S_GameManager s_gameManager;

    private void Start()
    {
        s_gameManager = S_GameManager.Instance;
    }
}

public class BoneReward : Reward
{
    public override string toText()
    {
        return "test";
    }

    public override void reward()
    {
        s_gameManager.SetBones(s_gameManager.GetBones() + i_value);
    }
}

public class CardReward : Reward
{
    public override string toText()
    {
        return "test";
    }

    public override void reward()
    {
        s_gameManager.SetBones(s_gameManager.GetBones() + i_value);
    }
}

public class CoinReward : Reward
{
    public override string toText()
    {
        return "test";
    }

    public override void reward()
    {
        s_gameManager.SetHealth(s_gameManager.GetHealth() + i_value);
    }
}
