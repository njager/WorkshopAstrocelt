using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_CardDragger : MonoBehaviour // Event Handling to best facilitate interscript and attribute usage
{
    private S_Global g_global; 
  
    [Header("Useful Variables")]
    public Vector3 c_v3_initialPosition;
    public Transform c_cardTransform; 
    public S_Card cd_cardData;

    void Awake()
    {
        g_global = S_Global.Instance;
        cd_cardData = GetComponent<S_Card>();
        c_cardTransform = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (cd_cardData.c_b_cardIsDragged == true)
        {
            if(cd_cardData.cd_b_resetPositionFlag == false) 
            {
                Vector2 _newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                gameObject.transform.position = _newPosition;
            }
            else 
            {
                cd_cardData.c_b_cardIsDragged = false;
                cd_cardData.ResetPosition();
            }
        }
    }

    public void OnMouseDown()
    {
        cd_cardData.c_b_cardIsDragged = true;
    }

    public void OnMouseUp()
    {
        cd_cardData.c_b_cardIsDragged = false;
    }
}
