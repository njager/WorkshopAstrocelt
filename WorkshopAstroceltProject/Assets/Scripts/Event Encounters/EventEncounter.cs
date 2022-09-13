using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EventEncounter 
{
    [Header("Image for the Event")]
    public Sprite a_eventImage;

    [Header("Name for the Event")]
    [TextArea(3, 10)]
    public string s_eventName;

    [Header("Text description of the event")]
    [TextArea(3, 10)]
    public string s_eventSummary;

    public Response[] ls_responses;
}
