using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class S_CardScaler : MonoBehaviour
{
    private S_Global g_global;
    //Card to eventually modify the rest of the elements of the card object, including it's rigidbody

    [Header("Other card elements")]
    public S_Card c_card;
    public BoxCollider2D c_BoxCollider2D;

    [Header("Text Objects")]
    public GameObject c_headerTextObject;
    public GameObject c_bodyTextObject;
    public GameObject c_energyCostTextObject;
    public GameObject c_flavorTextObject;

    [Header("Text Components")]
    public TextMeshProUGUI c_tx_headerText;
    public TextMeshProUGUI c_tx_bodyText;
    public TextMeshProUGUI c_tx_energyCostText;
    public TextMeshProUGUI c_tx_flavorText;

    //Feel free to change any of these elements around, I just thought they may be useful - Josh

    // Start is called before the first frame update
    void Awake()
    {
        g_global = S_Global.Instance;
    }

    /// <summary>
    /// AutoScaler for a card's text boxes
    /// </summary>
    public void SizeTextElements()
    {
        // Resize Header Text
        RectTransform _headerRect = c_headerTextObject.GetComponent<RectTransform>();
        _headerRect.localScale = new Vector2(_headerRect.localScale.x * 2, _headerRect.localScale.y * 2);

        // Resize Description Text
        RectTransform _descriptionRect = c_bodyTextObject.GetComponent<RectTransform>();
        _descriptionRect.sizeDelta = new Vector2(_descriptionRect.sizeDelta.x * c_card.i_hoverX, _descriptionRect.sizeDelta.y * c_card.i_hoverY);


        // Resize Energy Cost Text
        RectTransform _energyCostRect = c_energyCostTextObject.GetComponent<RectTransform>();
        _energyCostRect.sizeDelta = new Vector2(_energyCostRect.sizeDelta.x * c_card.i_hoverX, _energyCostRect.sizeDelta.y * c_card.i_hoverY);


        // Resize Flavor text
        RectTransform _flavorRect = c_flavorTextObject.GetComponent<RectTransform>();
        _flavorRect.sizeDelta = new Vector2(_flavorRect.sizeDelta.x * c_card.i_hoverX, _flavorRect.sizeDelta.y * c_card.i_hoverY);
    }
}
