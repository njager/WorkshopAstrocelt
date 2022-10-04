using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AudioManager : MonoBehaviour
{
    private S_Global g_global;

    [Header("Combat Scene?")]
    public bool b_combatScene;

    [Header("the time in game")]
    public float f_timeInScene = 0;

    [Header("The player health")]
    public int p_i_playerHealth;

    private void Start()
    {
        g_global = S_Global.Instance;
    }

    private void Update()
    {
        f_timeInScene += Time.deltaTime;


    }
}
