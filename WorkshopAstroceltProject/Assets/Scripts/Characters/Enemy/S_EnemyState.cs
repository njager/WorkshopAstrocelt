using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyState : MonoBehaviour
{
    // Controls the state for the entierety of enemies 
    private S_Global g_global;

    // Five max potential enemes, left blank for enemies to self inform themselves to. 
    public S_Enemy enemy1;
    public S_Enemy enemy2;
    public S_Enemy enemy3;
    public S_Enemy enemy4;
    public S_Enemy enemy5;

    public string str_enemy1Type;
    public string str_enemy2Type;
    public string str_enemy3Type;
    public string str_enemy4Type;
    public string str_enemy5Type;

    void Awake()
    {
        g_global = S_Global.g_instance;
    }

    // Update is called once per frame
    void Update()
    {
        //If the enemy 1 healths or goes over in shields from abilities, or they die
        if(g_global.g_enemyAttributeSheet1 != null)
        {
            if (g_global.g_enemyAttributeSheet1.e_i_health > g_global.g_enemyAttributeSheet1.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet1.e_i_health = g_global.g_enemyAttributeSheet1.e_i_healthMax;
            }

            if (g_global.g_enemyAttributeSheet1.e_i_shield > g_global.g_enemyAttributeSheet1.e_i_shieldMax)
            {
                g_global.g_enemyAttributeSheet1.e_i_shield = g_global.g_enemyAttributeSheet1.e_i_shieldMax;
            }

            if (g_global.g_enemyAttributeSheet1.e_i_health <= 0)
            {
                enemy1.EnemyDied(str_enemy1Type);
            }
        }
        


        // Same for enemy 2
        if(g_global.g_enemyAttributeSheet2 != null)
        {
            if (g_global.g_enemyAttributeSheet2.e_i_health > g_global.g_enemyAttributeSheet2.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet2.e_i_health = g_global.g_enemyAttributeSheet2.e_i_healthMax;
            }

            if (g_global.g_enemyAttributeSheet2.e_i_shield > g_global.g_enemyAttributeSheet2.e_i_shieldMax)
            {
                g_global.g_enemyAttributeSheet2.e_i_shield = g_global.g_enemyAttributeSheet2.e_i_shieldMax;
            }

            if (g_global.g_enemyAttributeSheet2.e_i_health <= 0)
            {
                enemy2.EnemyDied(str_enemy2Type);
            }
        }
        


        // Same for enemy 3
        if(g_global.g_enemyAttributeSheet3 != null)
        {
            if (g_global.g_enemyAttributeSheet3.e_i_health > g_global.g_enemyAttributeSheet3.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet3.e_i_health = g_global.g_enemyAttributeSheet3.e_i_healthMax;
            }

            if (g_global.g_enemyAttributeSheet3.e_i_shield > g_global.g_enemyAttributeSheet3.e_i_shieldMax)
            {
                g_global.g_enemyAttributeSheet3.e_i_shield = g_global.g_enemyAttributeSheet3.e_i_shieldMax;
            }

            if (g_global.g_enemyAttributeSheet3.e_i_health <= 0)
            {
                enemy3.EnemyDied(str_enemy3Type);
            }
        }
        

        // Same for enemy 4
        if(g_global.g_enemyAttributeSheet4 != null)
        {
            if (g_global.g_enemyAttributeSheet4.e_i_health > g_global.g_enemyAttributeSheet4.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet4.e_i_health = g_global.g_enemyAttributeSheet4.e_i_healthMax;
            }

            if (g_global.g_enemyAttributeSheet4.e_i_shield > g_global.g_enemyAttributeSheet4.e_i_shieldMax)
            {
                g_global.g_enemyAttributeSheet4.e_i_shield = g_global.g_enemyAttributeSheet4.e_i_shieldMax;
            }

            if (g_global.g_enemyAttributeSheet4.e_i_health <= 0)
            {
                enemy4.EnemyDied(str_enemy4Type);
            }
        }

        // Same for enemy 5
        if(g_global.g_enemyAttributeSheet5 != null)
        {
            if (g_global.g_enemyAttributeSheet5.e_i_health > g_global.g_enemyAttributeSheet5.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet5.e_i_health = g_global.g_enemyAttributeSheet5.e_i_healthMax;
            }

            if (g_global.g_enemyAttributeSheet5.e_i_shield > g_global.g_enemyAttributeSheet5.e_i_shieldMax)
            {
                g_global.g_enemyAttributeSheet5.e_i_shield = g_global.g_enemyAttributeSheet5.e_i_shieldMax;
            }

            if (g_global.g_enemyAttributeSheet5.e_i_health <= 0)
            {
                enemy5.EnemyDied(str_enemy5Type);
            }
        }
    }

    
}
