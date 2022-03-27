using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VectorGraphics;
using Unity.VectorGraphics.Editor;
using UnityEngine.EventSystems;

public class S_CardDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private S_Global g_global; 
  
    [Header("Useful Variables")]
    public Vector3 c_v3_initialPosition;
    public RectTransform c_cardTransform;
    public S_CardTemplate c_card;

    public int transformCounter = 0; // Use this to trigger bheavior only once;

    void Awake()
    {
        g_global = S_Global.Instance;
        c_cardTransform = GetComponent<RectTransform>();
        c_card = GetComponent<S_Card>().c_cardTemplate;
    }

    public void OnBeginDrag(PointerEventData _eventData)
    {
        g_global.g_objectBeingDragged = null;

        g_global.g_objectBeingDragged = _eventData.pointerDrag;
    }

    public void OnDrag(PointerEventData _eventData)
    {
        //only trigger if your the front card in the hand
        if (c_card == g_global.lst_p_playerHand[0])
        {


            if (transformCounter == 0)
            {
                c_v3_initialPosition = gameObject.transform.position;
                transformCounter++; // Increment counter to make this happen only once
            }
            c_cardTransform.anchoredPosition += _eventData.delta / g_global.g_UIManager.greyboxCanvas.GetComponent<Canvas>().scaleFactor; // Take the change in mouse position and divide it by the size of the box it's in
        }
    }

    public void OnEndDrag(PointerEventData _eventData)
    {
        //Nothing yet
        //remove card from hand

        //start the audio
        if (g_global.b_firstCard)
        {
            g_global.b_firstCard = false;
            FMODUnity.StudioEventEmitter _gameMusic = g_global.a_audioPlayer.GetComponent<FMODUnity.StudioEventEmitter>();
            _gameMusic.SetParameter("Music_Combat_01", 1);
        }
    }
}
