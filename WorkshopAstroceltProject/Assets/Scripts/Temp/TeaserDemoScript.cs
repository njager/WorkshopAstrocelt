using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaserDemoScript : MonoBehaviour
{
    [SerializeField] GameObject demoCard;
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;

    

    private void Awake()
    {
       
    }

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

        if (Input.GetKeyDown(KeyCode.O))
        {
            
        }
    }
}
