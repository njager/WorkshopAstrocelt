using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CardPosition : MonoBehaviour
{
    public S_Card c_card;

    [Header("Testing")]
    public bool c_b_cardHovered; 

    private void Awake()
    {
        c_card = null;
    }
    // Setter \\
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_cardScript"></param>
    public void SetCardScriptReference(S_Card _cardScript) 
    {
        c_card = _cardScript;
    }

    public void OnHoverEnter()
    {
        if(c_card != null) 
        {
            if (c_card.c_b_cardIsDragged == false)
            {
                c_card.c_v3_CardPosition.z = -10;
                c_b_cardHovered = true;
            }
            else
            {
                return;
            }
        }
    }

    /// <summary>
    /// Return back to original sorting order when mouse exits the hover
    ///  - Josh
    /// </summary>
    public void OnHoverExit()
    {
        if (c_card != null) 
        {
            if (c_card.c_b_cardIsDragged == false)
            {
                c_card.c_v3_CardPosition.z = c_card.c_v3_intialPositionZ;
                c_b_cardHovered = false;
            }
            else
            {
                return;
            }
        }
    }
}
