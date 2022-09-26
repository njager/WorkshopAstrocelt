using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_WaitForCardPlay : CustomYieldInstruction
{
    private S_Global g_global;

    // Set the g_global variable
    private void SetGlobal()
    {
        g_global = S_Global.Instance;
    }

    /// <summary>
    /// Override the wait condition that an IEnumerator checks for
    /// Have it be based on waiting until the player plays the active card
    /// - Josh
    /// </summary>
    public override bool keepWaiting
    {
        get
        {
            return !g_global.g_altar.GetCardBeingActiveBool();
        }
    }

    // Constructor 
    public S_WaitForCardPlay()
    {
        SetGlobal();
        Debug.Log("Creating a new yield instruction for Card play");
    }
}
