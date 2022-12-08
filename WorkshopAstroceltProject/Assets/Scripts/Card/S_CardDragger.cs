using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_CardDragger : MonoBehaviour // Event Handling to best facilitate interscript and attribute usage
{
    private S_Global g_global; 
  
    [Header("Useful Variables")]
    public Vector3 crd_v3_initialPosition;
    public Transform crd_cardTransform; 
    public S_Card crd_cardData;

    void Awake()
    {
        g_global = S_Global.Instance;
        crd_cardData = GetComponent<S_Card>();
        crd_cardTransform = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (crd_cardData.crd_b_cardIsDragged == true)
        {
            if(crd_cardData.crd_b_resetPositionFlag == false) 
            {
                Vector2 _newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                gameObject.transform.position = _newPosition;
            }
            else 
            {
                crd_cardData.crd_b_cardIsDragged = false;
                crd_cardData.ResetPosition();
            }
        }

        if(crd_cardData.crd_b_resetPositionFlag == true) 
        {
            crd_cardData.ResetPosition();
        }
    }

    public void OnMouseDown()
    {
        crd_cardData.crd_b_cardIsDragged = true;
    }

    public void OnMouseUp()
    {
        crd_cardData.crd_b_cardIsDragged = false;
        crd_cardData.CheckResetOrPlay();
    }
}
