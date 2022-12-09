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

    [Header("Real name identifier")]
    [SerializeField] string e_str_enemyName;

    // Private variables
    private int e_i_tempSheild;
    private int e_i_shield;
    private int e_i_enemyDamageValue; 

    [Header("Challenge Rating")]
    public float e_f_challengeRating;

    [Header("Enemy Type")]
    public string e_str_enemyType; 

    // Add more enemies to toggle on and off as needed, are these even used? Perhaps there will be a use down the line
    [Header("Enemy Type Bools")]
    public bool e_b_Lumberjack;
    public bool e_b_Magician;
    public bool e_b_Beast;
    public bool e_b_Brawler;

    [Header("Status Effects")]
    [SerializeField] bool e_b_acidic;
    [SerializeField] bool e_b_bleeding;
    [SerializeField] bool e_b_resistant;
    [SerializeField] bool e_b_stunned;

    //It's attached enemy script
    [Header("Attached Enemy Script")]
    public S_Enemy e_enemy;

    [Header("Particle Effects")]
    [SerializeField] ParticleSystem e_pe_enemyAttacked;
    [SerializeField] ParticleSystem e_pe_enemyShielded;
    [SerializeField] ParticleSystem e_pe_enemySufficientShield;
    [SerializeField] ParticleSystem e_pe_enemyCardFailed;

    [Header("Animatiors")]
    public Animator e_a_AttackAnimator;
    public Animator e_a_DamagedAnimator;

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
    /// - Riley and Josh
    /// </summary>
    /// <returns>
    ///
    /// </returns>
    public List<S_EnemyMoves> GetMoveQueue()
    {
        return ls_e_moveQueue;
    }

    /// <summary>
    /// Get the Damage Value for the enemy (assigned from move queue)
    /// - Riley and Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_i_enemyDamageValue
    /// </returns>
    public int GetEnemyDamageValue()
    {
        return e_i_enemyDamageValue;
    }

    /// <summary>
    /// Get the Tempshield for the enemy (assigned from move queue)
    /// - Riley and Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_i_tempSheild
    /// </returns>
    public int GetEnemyTempShield()
    {
        return e_i_tempSheild;
    }

    /// <summary>
    /// Get the bool state for acidic for the enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_b_acidic
    /// </returns>
    public bool GetEnemyAcidicBool()
    {
        return e_b_acidic;
    }

    /// <summary>
    /// Get the bool state for bleed for the enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_b_bleeding
    /// </returns>
    public bool GetEnemyBleedingBool()
    {
        return e_b_bleeding;
    }

    /// <summary>
    /// Get the bool state for resistant for the enemy 
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_b_resistant
    /// </returns>
    public bool GetEnemyResistantBool()
    {
        return e_b_resistant;
    }

    /// <summary>
    /// Get the bool state for stun for the enemy 
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_b_stunned
    /// </returns>
    public bool GetEnemyStunnedBool()
    {
        return e_b_stunned;
    }

    /// <summary>
    /// Get the string text for S_EnemyAttributes.e_str_enemyName
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_str_enemyName
    /// </returns>
    public string GetEnemyName()
    {
        return e_str_enemyName;
    }

    /// <summary>
    /// Get the ParticleSystem for S_EnemyAttributes.e_pe_enemyAttacked
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_pe_enemyAttacked
    /// </returns>
    public ParticleSystem GetEnemyAttackedParticle()
    {
        return e_pe_enemyAttacked;
    }

    /// <summary>
    /// Get the ParticleSystem for S_EnemyAttributes.e_pe_enemyShielded
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_pe_enemyShielded
    /// </returns>
    public ParticleSystem GetEnemyShieldedParticle()
    {
        return e_pe_enemyShielded;
    }

    /// <summary>
    /// Get the ParticleSystem for S_EnemyAttributes.e_pe_enemySufficientShield
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_pe_enemySufficientShield
    /// </returns>
    public ParticleSystem GetEnemySufficientShieldParticle()
    {
        return e_pe_enemySufficientShield;
    }

    /// <summary>
    /// Get the ParticleSystem for S_EnemyAttributes.e_pe_enemySufficientShield
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyAttributes.e_pe_enemySufficientShield
    /// </returns>
    public ParticleSystem GetEnemyCardFailedParticle()
    {
        return e_pe_enemyCardFailed;
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
