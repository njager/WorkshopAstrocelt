using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class S_Enemy : MonoBehaviour
{
    private S_Global g_global;

    [SerializeField] S_EnemyAttributes e_enemyAttributes;

    public int e_i_enemyCount;

    public GameObject e_sp_spriteIcon; 

    void Awake()
    {
        g_global = S_Global.Instance;

        SetCount(); 
        
        Debug.Log("Testing for enemy count: " + e_i_enemyCount.ToString());

        g_global.e_l_enemyList.Add(this);
    }

    void SetCount()
    {
        g_global.g_i_enemyCount += 1;
        e_i_enemyCount = g_global.g_i_enemyCount;
        return; 
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


    // Require enemytype in case we need to do death behavior
    public void EnemyDied(string _enemyType)
    {
        g_global.g_i_enemyCount -= 1;
        Debug.Log("Enemy Perished");
        gameObject.SetActive(false);
    }

    public void OnMouseDown()
    {
        g_global.g_selectorManager.EnemySelected(this); 
    }


    //Eventually use this? Check with designers, imported code. 
    public void EnemyDamageChange(S_Enemy enemy)
    {
        int _randEnemyDamageInt = Random.Range(6, 12);
        //enemy.enemyDamage = _randEnemyDamageInt;
    }
}
