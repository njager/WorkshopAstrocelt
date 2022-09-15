using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_CardDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler // Event Handling to best facilitate interscript and attribute usage
{
    private S_Global g_global; 
  
    [Header("Useful Variables")]
    public Vector3 c_v3_initialPosition;
    public Transform c_cardTransform; 
    public S_Card c_card;

    void Awake()
    {
        g_global = S_Global.Instance;
        c_card = GetComponent<S_Card>();
        c_cardTransform = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (c_card.c_b_cardIsDragged == false)
        {
            Vector2 _newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(_newPosition);
        }
    }

    /// <summary>
    /// Empty for right now
    /// - Josh
    /// </summary>
    /// <param name="_eventData"></param>
    public void OnBeginDrag(PointerEventData _eventData)
    {
        c_card.c_b_cardIsDragged = true;
    }

    public void OnMouseDown()
    {
        c_card.c_b_cardIsDragged = true;
    }

    public void OnMouseUp()
    {
        c_card.c_b_cardIsDragged = false;
    }

    /// <summary>
    /// Facilitate drag correlative to mouse position OnDrag
    /// - Josh
    /// </summary>
    /// <param name="_eventData"></param>
    public void OnDrag(PointerEventData _eventData)
    {
        c_cardTransform.position += new Vector3(_eventData.delta.x, _eventData.delta.y, 0f);
    }

    /// <summary>
    /// Debug checking
    /// </summary>
    /// <param name="_eventData"></param>
    public void OnEndDrag(PointerEventData _eventData)
    {
        //Debug.Log(c_card.c_str_cardName + " : This card ended drag and now is in reset position");
        //reset the card if it didnt trigger the CharacterCardInterface
        //_eventData.pointerDrag.GetComponent<S_Card>().ResetPosition();

        //start the audio
        if (g_global.g_c_b_firstCard)
        {
            g_global.g_c_b_firstCard = false;
            //FMODUnity.StudioEventEmitter _gameMusic = g_global.g_a_audioPlayer.GetComponent<FMODUnity.StudioEventEmitter>();
            //_gameMusic.SetParameter("Music_Combat_01", 1);
        }

        //reset position
        //c_card.ResetPosition();

    }
}
