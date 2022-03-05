using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VectorGraphics;
using Unity.VectorGraphics.Editor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class S_CharacterCardInterface : MonoBehaviour, IDropHandler
{
    private RectTransform p_playerRectTransform;
    private S_Card c_cardData;
    private S_Global g_global;

    void Awake()
    {
        p_playerRectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData _eventData)
    {
        if (_eventData.pointerDrag != null)
        {
            c_cardData = _eventData.pointerDrag.GetComponent<S_Card>();
            if(g_global.g_ConstellationManager.i_energyCount >= c_cardData.c_i_energyCost)
            {
                if (c_cardData.c_b_affectsPlayer == true) //check to see if it affects player
                {
                    if (c_cardData.c_b_shieldMainEffect == true) //check to see if it's a shield card
                    {
                        c_cardData.PlayCard(g_global.g_player.gameObject);
                    }
                }
            }
        }
    }
}
