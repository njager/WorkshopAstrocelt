using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class S_EventManager
{
    public delegate void EnemyTurnDelegate(int x);

    // Enemy Events for Delegates
    public static event EnemyTurnDelegate e_enemy1PhaseEvent;
    public static event EnemyTurnDelegate e_enemy2PhaseEvent;
    public static event EnemyTurnDelegate e_enemy3PhaseEvent;
    public static event EnemyTurnDelegate e_enemy4PhaseEvent;
    public static event EnemyTurnDelegate e_enemy5PhaseEvent;

    // Null Bools
    public static bool e_b_enemy1PhaseNull;
    public static bool e_b_enemy2PhaseNull;
    public static bool e_b_enemy3PhaseNull;
    public static bool e_b_enemy4PhaseNull;
    public static bool e_b_enemy5PhaseNull;

    public static void BroadcastForEnemy1()
    {
        Debug.Log("Enemy 1 Broadcasted");
        e_enemy1PhaseEvent(1);
    }

    public static void BroadcastForEnemy2()
    {
        Debug.Log("Enemy 2 Broadcasted");
        e_enemy2PhaseEvent(2);
    }

    public static void BroadcastForEnemy3()
    {
        Debug.Log("Enemy 3 Broadcasted");
        e_enemy3PhaseEvent(3);
    }

    public static void BroadcastForEnemy4()
    {
        Debug.Log("Enemy 4 Broadcasted");
        e_enemy4PhaseEvent(4);
    }

    public static void BroadcastForEnemy5()
    {
        Debug.Log("Enemy 5 Broadcasted");
        e_enemy5PhaseEvent(5);
    }

    public static void ClearEnemyEvents()
    {
        // Clear events
        e_enemy1PhaseEvent = null;
        e_enemy2PhaseEvent = null;
        e_enemy3PhaseEvent = null;
        e_enemy4PhaseEvent = null;
        e_enemy5PhaseEvent = null;

        // Set bools
        e_b_enemy1PhaseNull = true;
        e_b_enemy2PhaseNull = true;
        e_b_enemy3PhaseNull = true;
        e_b_enemy4PhaseNull = true;
        e_b_enemy5PhaseNull = true;
    }
}

