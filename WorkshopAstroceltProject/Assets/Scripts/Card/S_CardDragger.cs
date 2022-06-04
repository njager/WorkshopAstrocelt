using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_CardDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler // Event Handling to best facilitate interscript and attribute usage
{
    private S_Global g_global; 
  
    [Header("Useful Variables")]
    public Vector3 c_v3_initialPosition;
    public RectTransform c_cardTransform; 
    public S_Card c_card;

    public int transformCounter = 0; // Use this to trigger bheavior only once;

    void Awake()
    {
        g_global = S_Global.Instance;
        c_card = GetComponent<S_Card>();
        c_cardTransform = gameObject.GetComponent<RectTransform>();
    }

    /// <summary>
    /// Empty for right now
    /// - Josh
    /// </summary>
    /// <param name="_eventData"></param>
    public void OnBeginDrag(PointerEventData _eventData)
    {

    }

    /// <summary>
    /// Grab the initial position data, and facilitate drag correlative to mouse position OnDrag
    /// - Josh
    /// </summary>
    /// <param name="_eventData"></param>
    public void OnDrag(PointerEventData _eventData)
    {
        if (transformCounter == 0)
        {
            c_v3_initialPosition = GetComponent<Transform>().position;
            transformCounter++; // Increment counter to make this happen only once
        }
        c_cardTransform.anchoredPosition += _eventData.delta / g_global.g_UIManager.greyboxCanvas.GetComponent<Canvas>().scaleFactor; // Take the change in mouse position and divide it by the size of the box it's in
        
    }

    /// <summary>
    /// Debug checking
    /// </summary>
    /// <param name="_eventData"></param>
    public void OnEndDrag(PointerEventData _eventData)
    {
        Debug.Log(c_card.c_str_cardName + " : This card ended drag and now is in reset position");
        //reset the card if it didnt trigger the CharacterCardInterface
        //_eventData.pointerDrag.GetComponent<S_Card>().ResetPosition();

        //start the audio
        if (g_global.g_c_b_firstCard)
        {
            g_global.g_c_b_firstCard = false;
            FMODUnity.StudioEventEmitter _gameMusic = g_global.g_a_audioPlayer.GetComponent<FMODUnity.StudioEventEmitter>();
            _gameMusic.SetParameter("Music_Combat_01", 1);
        }

        //reset position
        c_card.ResetPosition();

    }
}
