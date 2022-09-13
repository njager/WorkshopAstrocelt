using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Respose", menuName = "Response")]
public class Response : ScriptableObject
{
    [Header("Text for the response")]
    [TextArea(3, 10)]
    public string s_responseText;

    public Reward r_reward;

    [Header("Percent chance that the player fails as an int from 1-100")]
    public int f_failureChance;

    [Header("Text if Player fails")]
    [TextArea(3, 10)]
    public string s_failureText;
}
