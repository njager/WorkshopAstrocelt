using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_CardDragger : MonoBehaviour, IDragHandler 
{
    private S_Global global; 
    private RectTransform c_cardTransform;

    public Vector3 c_v3_initialPosition;

    public int transformCounter = 0; // Use this to trigger bheavior only once;

    void Awake()
    {
        global = S_Global.Instance;
        c_cardTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData _eventData)
    {
        if( transformCounter == 0)
        {
            c_v3_initialPosition = gameObject.transform.position;
            transformCounter++; // Increment counter to make this happen only once
        }
        c_cardTransform.anchoredPosition += _eventData.delta / global.g_UIManager.greyboxCanvas.GetComponent<Canvas>().scaleFactor; // Take the change in mouse position and divide it by the size of the box it's in
    }
}
