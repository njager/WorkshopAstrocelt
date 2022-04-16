using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaserDemoScript : MonoBehaviour
{
    [SerializeField] GameObject demoCard;

    // Start is called before the first frame update
    void Start()
    {
        demoCard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            demoCard.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            demoCard.SetActive(false);
        }
    }
}
