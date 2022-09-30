using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyAttributes : MonoBehaviour
{
    //public S_EnemyTemplate enemyTemplate;

    private S_Global g_global;

    [Header("Enemy Move Queue (string names: attack, ability, shield")]
    List<S_EnemyMoves> ls_e_moveQueue = null;

    [SerializeField] public List<S_EnemyMoves> ls_e_moveQueue1 = null;
    [SerializeField] public List<S_EnemyMoves> ls_e_moveQueue2 = null;
    [SerializeField] public List<S_EnemyMoves> ls_e_moveQueue3 = null;

    [Header("Enemy Attributes")]
    public int e_i_health;
    public int e_i_healthMax;

    // Private variables
    int e_i_tempSheild;
    int e_i_shield;
    int e_i_enemyDamageValue; 

    public float e_f_challengeRating;

    [Header("Typing")]
    public string e_str_enemyType; 

    // Add more enemies to toggle on and off as needed, are these even used? Perhaps there will be a use down the line
    [Header("Enemy Type Bools")]
    public bool e_b_Lumberjack;
    public bool e_b_Magician;
    public bool e_b_Beast;
    public bool e_b_Brawler;

    [Header("Status Effects")]
    public bool e_b_poisoned;
    public bool e_b_stunned;
    public bool e_b_bleeding;
    public bool e_b_empowered;
    public bool e_b_lucky;
    public bool e_b_resistant;
    public bool e_b_burned;
    public bool e_b_shocked;

    //It's attached enemy script
    [Header("Attached Enemy Script")]
    public S_Enemy e_enemy;

    [Header("Particle Effect")]
    public ParticleSystem e_pe_blood;

    [Header("Animator")]
    public Animator e_a_animator;

    [Header("Highlight Circle")]
    public GameObject e_highlightCircle;

    public void Awake()
    {
        g_global = S_Global.Instance; 

        //Inform Global
        //InstanceVariables();
        e_enemy = gameObject.GetComponent<S_Enemy>();

        //add nums to the list so we dont use an unimlamented list
        List<int> _randomList = new List<int>();

        //randomly select a list
        if (ls_e_moveQueue1 != null)
        {
            _randomList.Add(1);
        }
        if (ls_e_moveQueue2 != null)
        {
            _randomList.Add(2);
        }
        if (ls_e_moveQueue3 != null)
        {
            _randomList.Add(3);
        }

        int _value = Random.Range(0, _randomList.Count);

        //set the move queue initially
        if (_randomList[_value] == 1)
        {
            SetMoveQueue(ls_e_moveQueue1);
        }
        else if (_randomList[_value] == 2)
        {
            SetMoveQueue(ls_e_moveQueue2);
        }
        else if (_randomList[_value] == 3)
        {
            SetMoveQueue(ls_e_moveQueue3);
        }
        else { Debug.Log("Move list never assigned"); }
    }

    private void Start()
    {
        //Fill sheet 1 in global if enemy 1
        if (gameObject.GetComponent<S_Enemy>().e_i_enemyCount == 1)
        {
            if (g_global.g_enemyAttributeSheet1 == null)
            {
                g_global.g_enemyAttributeSheet1 = this;
            }
            else
            {
                Debug.Log("Something Already filled up this Sheet! And wasn't supposed to!");
            }
        }

        //Fill sheet 2 in global if enemy 2
        if (gameObject.GetComponent<S_Enemy>().e_i_enemyCount == 2)
        {
            if (g_global.g_enemyAttributeSheet2 == null)
            {
                g_global.g_enemyAttributeSheet2 = this;
            }
            else
            {
                Debug.Log("Something Already filled up this Sheet! And wasn't supposed to!");
            }
        }

        //Fill sheet 3 in global if enemy 3
        if (gameObject.GetComponent<S_Enemy>().e_i_enemyCount == 3)
        {
            if (g_global.g_enemyAttributeSheet3 == null)
            {
                g_global.g_enemyAttributeSheet3 = this;
            }
            else
            {
                Debug.Log("Something Already filled up this Sheet! And wasn't supposed to!");
            }
        }

        //Fill sheet 4 in global if enemy 4
        if (gameObject.GetComponent<S_Enemy>().e_i_enemyCount == 4)
        {
            if (g_global.g_enemyAttributeSheet4 == null)
            {
                g_global.g_enemyAttributeSheet4 = this;
            }
            else
            {
                Debug.Log("Something Already filled up this Sheet! And wasn't supposed to!");
            }
        }

        //Fill sheet 5 in global if enemy 5
        if (gameObject.GetComponent<S_Enemy>().e_i_enemyCount == 5)
        {
            if (g_global.g_enemyAttributeSheet5 == null)
            {
                g_global.g_enemyAttributeSheet5 = this;
            }
            else
            {
                Debug.Log("Something Already filled up this Sheet! And wasn't supposed to!");
            }
        }

        g_global.g_iconManager.EnemyIconNextTurn(e_enemy);

        if (e_enemy.e_i_enemyCount == 1)
        {
            g_global.g_enemyState.enemy1 = e_enemy;
        }
        if (e_enemy.e_i_enemyCount == 2)
        {
            g_global.g_enemyState.enemy2 = e_enemy;
        }
        if (e_enemy.e_i_enemyCount == 3)
        {
            g_global.g_enemyState.enemy3 = e_enemy;
        }
        if (e_enemy.e_i_enemyCount == 4)
        {
            g_global.g_enemyState.enemy4 = e_enemy;
        }
        if (e_enemy.e_i_enemyCount == 5)
        {
            g_global.g_enemyState.enemy5 = e_enemy;
        }

        e_enemy.UpdateEnemyHealthUI();
    }

    /// <summary>
    /// Return the int value from S_EnemyAttributes.e_i_health
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_i_health
    /// </returns>
    public int GetEnemyHealthValue()
    {
        return e_i_health;
    }

    /// <summary>
    /// Return the int value from S_EnemyAttributes.e_i_healthMax
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_i_healthMax 
    /// </returns>
    public int GetEnemyMaxHealthValue()
    {
        return e_i_healthMax;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the int value from S_EnemyAttributes.e_i_shield
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_i_shield 
    /// </returns>
    public int GetEnemyShieldValue()
    {
        return e_i_shield;
    }

    /// <summary>
    /// Getter for the MoveQueue
    /// </summary>
    /// <returns></returns>
    public List<S_EnemyMoves> GetMoveQueue()
    {
        return ls_e_moveQueue;
    }

    /// <summary>
    /// Get the Damage Value for the enemy (assigned from move queue)
    /// </summary>
    /// <returns></returns>
    public int GetEnemyDamageValue()
    {
        return e_i_enemyDamageValue;
    }

    public int GetEnemyTempShield()
    {
        return e_i_tempSheild;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Setter for the MoveQueue
    /// </summary>
    /// <param name="_ls"></param>
    public void SetMoveQueue(List<S_EnemyMoves> _ls)
    {
        ls_e_moveQueue = _ls;
    }

    /// <summary>
    /// Set the Damage Value for the enemy
    /// </summary>
    /// <param name="_value"></param>
    public void SetEnemyDamageValue(int _value)
    {
        e_i_enemyDamageValue = _value;
    }

    public void SetEnemyShield(int _value)
    {
        e_i_shield = _value;
    }

    public void SetEnemyTempShield(int _value)
    {
        e_i_tempSheild = _value;
    }
}
