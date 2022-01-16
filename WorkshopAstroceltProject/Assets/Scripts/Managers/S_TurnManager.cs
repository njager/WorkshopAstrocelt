using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TurnManager : MonoBehaviour
{
    public bool b_playerTurn = true;
    public bool b_enemyTurn = false;

    /// <summary>
    /// Change the state to the player turn 
    /// - Riley & Josh
    /// </summary>
    public void PlayerStateChange()
    {
        b_playerTurn = true;
        b_enemyTurn = false;
    }

    /// <summary>
    /// Change the state to the enemy turn
    /// - Riley & Josh
    /// </summary>
    public void EnemyStateChange()
    {
        b_playerTurn = false;
        b_enemyTurn = true;
    }
}
