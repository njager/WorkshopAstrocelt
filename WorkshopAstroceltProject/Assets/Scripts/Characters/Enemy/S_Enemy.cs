using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Enemy : MonoBehaviour
{
    private S_Global g_global;

    private S_EnemyAttributes e_enemyAttributes;

    public int e_i_enemyCount;

    void Awake()
    {
        g_global = S_Global.g_instance;
        g_global.g_i_enemyCount += 1;
        e_i_enemyCount = g_global.g_i_enemyCount;
        Debug.Log("Testing for enemy count: " + e_i_enemyCount.ToString()); 
    }

   
    public void EnemyAttacked(string _enemyType, int _damageVal)
    {
        if (_enemyType == "Lumberjack")
        {
            if (e_enemyAttributes.e_i_shield <= 0)
            {
                e_enemyAttributes.e_i_health -= _damageVal;
                Debug.Log("Enemy Attacked!");
            }
            else
            {
                int _tempVal = e_enemyAttributes.e_i_shield - _damageVal;
                if (_tempVal < 0)
                {
                    e_enemyAttributes.e_i_shield -= _damageVal;
                    if (e_enemyAttributes.e_i_shield < 0)
                    {
                        e_enemyAttributes.e_i_shield = 0;
                    }
                    EnemyAttacked(_enemyType, Mathf.Abs(_tempVal));
                    Debug.Log("Enemy didn't have enough shields!");
                }
                else
                {
                    e_enemyAttributes.e_i_shield -= _damageVal;
                    Debug.Log("Enemy had shields!");
                }
            }
        }
    }

    public void EnemyShielded(int _shieldVal)
    {
        e_enemyAttributes.e_i_shield += _shieldVal;
        Debug.Log("Enemy Shields");
    }

    public void EnemyHealed(int _healthVal)
    {
        e_enemyAttributes.e_i_health += _healthVal;
        Debug.Log("Enemy Heals");
    }

    public void EnemySpecialAbility(string _enemyType)
    {
        if(_enemyType == "Lumberjack")
        {
            Debug.Log("Lumberjack doesn't have a special ability!");
            return;
        }
    } 

    public void EnemyDied(string _enemyType)
    {
        g_global.g_i_enemyCount -= 1;
        Debug.Log("Enemy Perished");
        gameObject.SetActive(false);
    }
}
