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


    void Awake()
    {
        p_playerRectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData _eventData)
    {
        if (_eventData.pointerDrag != null)
        {
            c_cardData = _eventData.pointerDrag.GetComponent<S_Card>();
            if(c_cardData.c_b_affectsPlayer == true)
            {

            }
        }
    }
}
