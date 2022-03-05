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

    void Awake()
    {
        p_playerRectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData _eventData)
    {
        if (_eventData.pointerDrag != null)
        {
            _eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<Transform>().position;
        }
    }
}
