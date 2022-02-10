using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class S_Star
{
    private S_Global g_global;

    //put in start to avoid any race conditions (doesnt need to be in awake)
    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    // Stars used to connect to it's other two lines
    [Header("Other Stars")]
    public S_StarClass m_previous;
    public S_StarClass m_next;

    // Lines that were made with this star
    [Header("Lines Attached to Star")]
    public LineRenderer m_previousLine;
    public LineRenderer m_nextLine;
    
    //Functions can be added to be used in other star scripts, tested and works - Josh
}
