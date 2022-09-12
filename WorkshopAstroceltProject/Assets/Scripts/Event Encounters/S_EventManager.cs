using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class S_EventManager : MonoBehaviour
{
    [Header("UI from Scene")]
    public Image i_eventImageBox;
    public TextMeshProUGUI t_titleTextBox;
    public TextMeshProUGUI t_descriptionTextBox;

    [Header("Vertical Grid Holder")]
    public GameObject v_verticalGrid;

    [Header("Response Prefab")]
    public GameObject g_reponsePrefab;

    public EventEncounter e_event;

    private void Start()
    {
        i_eventImageBox.sprite = e_event.a_eventImage;
        t_descriptionTextBox.text = e_event.s_eventSummary;

        foreach(Response _response in e_event.ls_responses)
        {
            //instantiat the prefab, parent it to the vlg, and change its scale to fit the vgl
            GameObject _newResponse = Instantiate(g_reponsePrefab);
            Vector3 _scale = _newResponse.transform.localScale;
            _newResponse.transform.parent = v_verticalGrid.transform;
            _newResponse.transform.localScale = _scale;

            //get the text box of the child
            _newResponse.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _response.s_responseText;
        }
    }

    /// <summary>
    /// This function sets the text for the main text box of the event encounter scene
    /// </summary>
    /// <param name="_str"></param>
    public void SetDescriptionBox(string _str)
    {
        t_descriptionTextBox.text = _str;
    }

    /// <summary>
    /// This function loops through all the responses and deletes them
    /// </summary>
    public void DeleteResponses()
    {

    }
}
