using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class S_EventManager
{
    public delegate IEnumerator EnemyTurnDelegate(int x);
    public static event EnemyTurnDelegate e_enemyPhaseEvent;

    public static void EnemyPhaseEventTrigger(int _enemyNum)
    {
        e_enemyPhaseEvent(_enemyNum); 
    }
}