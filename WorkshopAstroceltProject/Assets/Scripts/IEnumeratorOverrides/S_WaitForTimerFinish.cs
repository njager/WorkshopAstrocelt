using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_WaitForTimerFinish : CustomYieldInstruction
{
    private S_Global g_global;

    // Set the g_global variable
    private void SetGlobal()
    {
        g_global = S_Global.Instance;
    }

    /// <summary>
    /// Override the wait condition that an IEnumerator checks for
    /// Have it be based on waiting until an enemy is not active
    /// - Josh
    /// </summary>
    public override bool keepWaiting
    {
        get
        {
            return !g_global.g_turnManager.GetEnemyActiveBool();
        }
    }

    // Constructor 
    public S_WaitForTimerFinish()
    {
        SetGlobal();
        Debug.Log("Creating a new yield instruction for enemy turn");
    }
}
