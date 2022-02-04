using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Enemy : MonoBehaviour
{
    private S_Global g_global;

    private S_EnemyAttributes e_enemyAttributes; 

    void Awake()
    {
        g_global = S_Global.g_instance;
        g_global.g_i_enemyCount += 1; 
    }

   
   public void EnemyAttacked(string _enemyType)
   {

   }

   public void EnemyShielded(string _enemyType)
   {

   }

   public void EnemySpecialAbility(string _enemyType)
   {

   } 

   public void EnemyDied(string _enemyType)
   {
        g_global.g_i_enemyCount -= 1; 
        gameObject.SetActive(false);
   }
}
