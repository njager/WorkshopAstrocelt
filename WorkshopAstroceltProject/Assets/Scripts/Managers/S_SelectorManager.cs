using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class S_SelectorManager : MonoBehaviour
{
    [Header("Selector Graphic Sprite")]

    public GameObject selector;

    //[Header("DON'T FILL, Supposed to be null")]
    //public S_Enemy e_enemySelected;

    // Side note: Find how to remove the ability to see a public variable in editors

    //Functions
    public void Awake()
    {
        SelectorReset(); // Start invisible upon play
    }


    /// <summary>
    /// Move the selector
    /// - Josh
    /// </summary>
    /// <param name="_enemySelected"></param>
    public void EnemySelected(S_Enemy _enemySelected)
    {
        //e_enemySelected = _enemySelected;
        if (selector.activeInHierarchy == false) // If not active, make active then move
        {
            selector.SetActive(true);
            selector.transform.position = _enemySelected.transform.position;
        }
        else // Move to other enemy
        {
            selector.transform.position = _enemySelected.transform.position;
        }
    }

    /// <summary>
    /// Reset the selector to be invisible
    /// - Josh
    /// </summary>
    public void SelectorReset()
    {
        selector.SetActive(false);
        // e_enemySelected = null; 
    }
}
