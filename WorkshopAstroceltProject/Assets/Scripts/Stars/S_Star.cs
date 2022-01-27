using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class S_Star
{
    // Stars used to connect to it's other two lines
    [Header("Other Stars")]
    public S_StarClass m_previous;
    public S_StarClass m_next;

    // Lines that were made with this star
    [Header("Lines Attached to Star")]
    public S_LineRenderer m_previousLine;
    public S_LineRenderer m_nextLine;

    //Functions can be added to be used in other star scripts, tested and works - Josh
}
