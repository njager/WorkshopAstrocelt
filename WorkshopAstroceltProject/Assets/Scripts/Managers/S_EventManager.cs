using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class S_EventManager
{
    public delegate IEnumerator EnemyTurnDelegate(int x);
    public static event EnemyTurnDelegate e_enemyPhaseEvent;

    public static void Broadcast(int _enemyNum)
    {
        Debug.Log("Event Broadcasted");
        e_enemyPhaseEvent(_enemyNum);
    }
}