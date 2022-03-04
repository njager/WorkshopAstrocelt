using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_CardDragger : MonoBehaviour, IDragHandler 
{
    private S_Global global; 
    private RectTransform c_cardTransform; 

    void Awake()
    {
        global = S_Global.Instance;
        c_cardTransform = GetComponent<RectTransform>();
         
    }

    public void OnDrag(PointerEventData _eventData)
    {
        c_cardTransform.anchoredPosition += _eventData.delta / global.g_UIManager.greyboxCanvas.GetComponent<Canvas>().scaleFactor; // Take the change in mouse position and divide it by the size of the box it's in
    }
}
