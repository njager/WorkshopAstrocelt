using UnityEngine;

public class S_EnemyState : MonoBehaviour
{
    // Controls the state for the entierety of enemies 
    private S_Global g_global;

    [Header("Enemy References")]
    public S_Enemy enemy1;
    public S_Enemy enemy2;
    public S_Enemy enemy3;
    public S_Enemy enemy4;
    public S_Enemy enemy5;

    [Header("Enemy Turn Actions")]
    public string e_str_enemy1Action;
    public string e_str_enemy2Action;
    public string e_str_enemy3Action;
    public string e_str_enemy4Action;
    public string e_str_enemy5Action;

    [Header("Enemy Types")]
    public string e_str_enemy1Type;
    public string e_str_enemy2Type;
    public string e_str_enemy3Type;
    public string e_str_enemy4Type;
    public string e_str_enemy5Type;

    [Header("Bool Living Status Check")]
    public bool e_b_enemy1Dead;
    public bool e_b_enemy2Dead;
    public bool e_b_enemy3Dead;
    public bool e_b_enemy4Dead;
    public bool e_b_enemy5Dead;

    [Header("Current Enemys Turn Check")]
    public bool e_b_enemy1Turn;
    public bool e_b_enemy2Turn;
    public bool e_b_enemy3Turn;
    public bool e_b_enemy4Turn;
    public bool e_b_enemy5Turn;

    [Header("Enemy Turn Skips")]
    [SerializeField] bool e_b_enemy1TurnSkipped;
    [SerializeField] bool e_b_enemy2TurnSkipped;
    [SerializeField] bool e_b_enemy3TurnSkipped;
    [SerializeField] bool e_b_enemy4TurnSkipped;
    [SerializeField] bool e_b_enemy5TurnSkipped;

    //Check thse for their next turn actions 
    [Header("Enemy Shielding Bools")]
    public bool e_b_enemy1Shielding;
    public bool e_b_enemy2Shielding;
    public bool e_b_enemy3Shielding;
    public bool e_b_enemy4Shielding;
    public bool e_b_enemy5Shielding;

    [Header("Enemy Attacking Bools")]
    public bool e_b_enemy1Attacking;
    public bool e_b_enemy2Attacking;
    public bool e_b_enemy3Attacking;
    public bool e_b_enemy4Attacking;
    public bool e_b_enemy5Attacking;

    [Header("Enemy Ability Bools")]
    public bool e_b_enemy1SpecialAbility;
    public bool e_b_enemy2SpecialAbility;
    public bool e_b_enemy3SpecialAbility;
    public bool e_b_enemy4SpecialAbility;
    public bool e_b_enemy5SpecialAbility;

    [Header("Status Effect Stack Count For Enemy 1")]
    [SerializeField] int e_i_acidStackCountEnemy1;
    [SerializeField] int e_i_bleedStackCountEnemy1;
    [SerializeField] int e_i_frailtyStackCountEnemy1;
    [SerializeField] int e_i_stunStackCountEnemy1;
    [SerializeField] int e_i_resistantStackCountEnemy1;

    [Header("Status Effect Stack Count For Enemy 2")]
    [SerializeField] int e_i_acidStackCountEnemy2;
    [SerializeField] int e_i_bleedStackCountEnemy2;
    [SerializeField] int e_i_frailtyStackCountEnemy2;
    [SerializeField] int e_i_stunStackCountEnemy2;
    [SerializeField] int e_i_resistantStackCountEnemy2;

    [Header("Status Effect Stack Count For Enemy 3")]
    [SerializeField] int e_i_acidStackCountEnemy3;
    [SerializeField] int e_i_bleedStackCountEnemy3;
    [SerializeField] int e_i_frailtyStackCountEnemy3;
    [SerializeField] int e_i_stunStackCountEnemy3;
    [SerializeField] int e_i_resistantStackCountEnemy3;

    [Header("Status Effect Stack Count For Enemy 4")]
    [SerializeField] int e_i_acidStackCountEnemy4;
    [SerializeField] int e_i_bleedStackCountEnemy4;
    [SerializeField] int e_i_frailtyStackCountEnemy4;
    [SerializeField] int e_i_stunStackCountEnemy4;
    [SerializeField] int e_i_resistantStackCountEnemy4;

    [Header("Status Effect Stack Count For Enemy 5")]
    [SerializeField] int e_i_acidStackCountEnemy5;
    [SerializeField] int e_i_bleedStackCountEnemy5;
    [SerializeField] int e_i_frailtyStackCountEnemy5;
    [SerializeField] int e_i_stunStackCountEnemy5;
    [SerializeField] int e_i_resistantStackCountEnemy5;

    [Header("Status Effect Enemy 1 Remainders")]
    [SerializeField] int e_i_frailtyStackRemainderEnemy1;
    [SerializeField] int e_i_resistantStackRemainderEnemy1;

    [Header("Status Effect Enemy 2 Remainders")]
    [SerializeField] int e_i_frailtyStackRemainderEnemy2;
    [SerializeField] int e_i_resistantStackRemainderEnemy2;

    [Header("Status Effect Enemy 3 Remainders")]
    [SerializeField] int e_i_frailtyStackRemainderEnemy3;
    [SerializeField] int e_i_resistantStackRemainderEnemy3;

    [Header("Status Effect Enemy 4 Remainders")]
    [SerializeField] int e_i_frailtyStackRemainderEnemy4;
    [SerializeField] int e_i_resistantStackRemainderEnemy4;

    [Header("Status Effect Enemy 5 Remainders")]
    [SerializeField] int e_i_frailtyStackRemainderEnemy5;
    [SerializeField] int e_i_resistantStackRemainderEnemy5;

    [Header("Status Effect States For Enemy 1")]
    [SerializeField] bool e_b_inAcidicStateEnemy1;
    [SerializeField] bool e_b_inBleedStateEnemy1;
    [SerializeField] bool e_b_inFralitizedStateEnemy1;
    [SerializeField] bool e_b_inStunStateEnemy1;
    [SerializeField] bool e_b_inResistantStateEnemy1;

    [Header("Status Effect States For Enemy 2")]
    [SerializeField] bool e_b_inAcidicStateEnemy2;
    [SerializeField] bool e_b_inBleedStateEnemy2;
    [SerializeField] bool e_b_inFralitizedStateEnemy2;
    [SerializeField] bool e_b_inStunStateEnemy2;
    [SerializeField] bool e_b_inResistantStateEnemy2;

    [Header("Status Effect States For Enemy 3")]
    [SerializeField] bool e_b_inAcidicStateEnemy3;
    [SerializeField] bool e_b_inBleedStateEnemy3;
    [SerializeField] bool e_b_inFralitizedStateEnemy3;
    [SerializeField] bool e_b_inStunStateEnemy3;
    [SerializeField] bool e_b_inResistantStateEnemy3;

    [Header("Status Effect States For Enemy 4")]
    [SerializeField] bool e_b_inAcidicStateEnemy4;
    [SerializeField] bool e_b_inBleedStateEnemy4;
    [SerializeField] bool e_b_inFralitizedStateEnemy4;
    [SerializeField] bool e_b_inStunStateEnemy4;
    [SerializeField] bool e_b_inResistantStateEnemy4;

    [Header("Status Effect States For Enemy 5")]
    [SerializeField] bool e_b_inAcidicStateEnemy5;
    [SerializeField] bool e_b_inBleedStateEnemy5;
    [SerializeField] bool e_b_inFralitizedStateEnemy5;
    [SerializeField] bool e_b_inStunStateEnemy5;
    [SerializeField] bool e_b_inResistantStateEnemy5;

    [Header("Active (true) or Inactive (false) Bool Check for Enemies")]
    [SerializeField] bool e_b_enemy1IsActive;
    [SerializeField] bool e_b_enemy2IsActive;
    [SerializeField] bool e_b_enemy3IsActive;
    [SerializeField] bool e_b_enemy4IsActive;
    [SerializeField] bool e_b_enemy5IsActive;

    [Header("Magician Ability")]
    [SerializeField] int e_i_magicianAbilityValue;
    [SerializeField] bool e_b_magicianAbilityBool;

    private void Awake()
    {
        g_global = S_Global.Instance;
    }

    // Update is called once per frame
    private void Update()
    {
        //If the enemy 1 healths or goes over in shields from abilities, or they die
        if(g_global.g_enemyAttributeSheet1 != null)
        {
            if (g_global.g_enemyAttributeSheet1.e_i_health > g_global.g_enemyAttributeSheet1.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet1.e_i_health = g_global.g_enemyAttributeSheet1.e_i_healthMax;
            }

            if(e_b_enemy1Dead != true)
            {
                if (g_global.g_enemyAttributeSheet1.e_i_health <= 0)
                {
                    // Turn off status effects
                    e_b_inAcidicStateEnemy1 = false;
                    e_b_inBleedStateEnemy1 = false;
                    e_b_inFralitizedStateEnemy1 = false;
                    e_b_inResistantStateEnemy1 = false;
                    e_b_inStunStateEnemy1 = false;

                    enemy1.EnemyDied(e_str_enemy1Type);
                    e_b_enemy1Dead = true; 
                }
            }
        }
        
        // Same for enemy 2
        if(g_global.g_enemyAttributeSheet2 != null)
        {
            if (g_global.g_enemyAttributeSheet2.e_i_health > g_global.g_enemyAttributeSheet2.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet2.e_i_health = g_global.g_enemyAttributeSheet2.e_i_healthMax;
            }

            if (e_b_enemy2Dead != true)
            {
                if (g_global.g_enemyAttributeSheet2.e_i_health <= 0)
                {
                    // Turn off status effects
                    e_b_inAcidicStateEnemy2 = false;
                    e_b_inBleedStateEnemy2 = false;
                    e_b_inFralitizedStateEnemy2 = false;
                    e_b_inResistantStateEnemy2 = false;
                    e_b_inStunStateEnemy2 = false;

                    enemy2.EnemyDied(e_str_enemy2Type);
                    e_b_enemy2Dead = true;
                }
            }
        }
        
        // Same for enemy 3
        if(g_global.g_enemyAttributeSheet3 != null)
        {
            if (g_global.g_enemyAttributeSheet3.e_i_health > g_global.g_enemyAttributeSheet3.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet3.e_i_health = g_global.g_enemyAttributeSheet3.e_i_healthMax;
            }

            if (e_b_enemy3Dead != true)
            {
                if (g_global.g_enemyAttributeSheet3.e_i_health <= 0)
                {
                    // Turn off status effects
                    e_b_inAcidicStateEnemy3 = false;
                    e_b_inBleedStateEnemy3 = false;
                    e_b_inFralitizedStateEnemy3 = false;
                    e_b_inResistantStateEnemy3 = false;
                    e_b_inStunStateEnemy3 = false;

                    enemy3.EnemyDied(e_str_enemy3Type);
                    e_b_enemy3Dead = true; 
                }
            }
        }
        
        // Same for enemy 4
        if(g_global.g_enemyAttributeSheet4 != null)
        {
            if (g_global.g_enemyAttributeSheet4.e_i_health > g_global.g_enemyAttributeSheet4.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet4.e_i_health = g_global.g_enemyAttributeSheet4.e_i_healthMax;
            }

            if (e_b_enemy4Dead != true)
            {
                if (g_global.g_enemyAttributeSheet4.e_i_health <= 0)
                {
                    // Turn off status effects
                    e_b_inAcidicStateEnemy4 = false;
                    e_b_inBleedStateEnemy4 = false;
                    e_b_inFralitizedStateEnemy4 = false;
                    e_b_inResistantStateEnemy4 = false;
                    e_b_inStunStateEnemy4 = false;

                    enemy4.EnemyDied(e_str_enemy4Type);
                    e_b_enemy4Dead = true;
                }
            }
        }

        // Same for enemy 5
        if(g_global.g_enemyAttributeSheet5 != null)
        {
            if (g_global.g_enemyAttributeSheet5.e_i_health > g_global.g_enemyAttributeSheet5.e_i_healthMax)
            {
                g_global.g_enemyAttributeSheet5.e_i_health = g_global.g_enemyAttributeSheet5.e_i_healthMax;
            }

            if(e_b_enemy5Dead != true)
            {
                if (g_global.g_enemyAttributeSheet5.e_i_health <= 0)
                {
                    // Turn off status effects
                    e_b_inAcidicStateEnemy5 = false;
                    e_b_inBleedStateEnemy5 = false;
                    e_b_inFralitizedStateEnemy5 = false;
                    e_b_inResistantStateEnemy5 = false;
                    e_b_inStunStateEnemy5 = false;

                    enemy5.EnemyDied(e_str_enemy5Type);
                    e_b_enemy5Dead = true;
                }
            }
        }
    }

    /// <summary>
    /// Decrement the turn count for effects
    /// Add status effects as needed, call this in turn manager at the beginning of enemy turn
    /// - Josh
    /// </summary>
    public void EnemyStatusEffectDecrement()
    {
        // Check Enemy 1
        if (GetEnemyActiveState(1) == true) 
        { 
            Enemy1StatusChecks(); 
        }

        // Check Enemy 2
        if (GetEnemyActiveState(2) == true) 
        { 
            Enemy2StatusChecks(); 
        }

        // Check Enemy 3
        if (GetEnemyActiveState(2) == true) 
        { 
            Enemy3StatusChecks(); 
        }

        // Check Enemy 4
        if (GetEnemyActiveState(4) == true) 
        { 
            Enemy4StatusChecks(); 
        }

        // Check Enemy 5
        if (GetEnemyActiveState(5) == true) 
        { 
            Enemy5StatusChecks(); 
        }
    }

    /// <summary>
    /// Function for initial trigger for Enemy Acidic Effects
    /// - Josh
    /// </summary>
    /// <param name="_stackValue"></param>
    /// /// <param name="_enemyNum"></param>
    public void EnemyAcidStatusEffect(int _stackValue, int _enemyNum)
    {
        // If the Enemy was Enemy 1
        if (_enemyNum == 1)
        {
            if (GetEnemyAcidEffectState(1) == false)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleAcidEnemyUI(true, 1);
                SetEnemyAcidicEffectStackCount(_stackValue, 1);
                SetEnemyAcidEffectState(true, 1);
            }

            if (GetEnemyDataSheet(1).GetEnemyShieldValue() >= 1)
            {
                int _doubleStack = _stackValue * 2;
                GetEnemyScript(1).EnemyAttacked(GetEnemyScript(1).e_str_enemyType, _doubleStack);
            }
            else
            {
                GetEnemyScript(1).EnemyAttacked(GetEnemyScript(1).e_str_enemyType, _stackValue);
            }
        }

        // If the Enemy was Enemy 2
        if (_enemyNum == 2)
        {
            if (GetEnemyAcidEffectState(2) == false)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleAcidEnemyUI(true, 2);
                SetEnemyAcidicEffectStackCount(_stackValue, 2);
                SetEnemyAcidEffectState(true, 2);
            }

            if (GetEnemyDataSheet(2).GetEnemyShieldValue() >= 1)
            {
                int _doubleStack = _stackValue * 2;
                GetEnemyScript(2).EnemyAttacked(GetEnemyScript(2).e_str_enemyType, _doubleStack);
            }
            else
            {
                GetEnemyScript(2).EnemyAttacked(GetEnemyScript(2).e_str_enemyType, _stackValue);
            }
        }

        // If the Enemy was Enemy 3
        if (_enemyNum == 3)
        {
            if (GetEnemyAcidEffectState(3) == false)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleAcidEnemyUI(true, 3);
                SetEnemyAcidicEffectStackCount(_stackValue, 3);
                SetEnemyAcidEffectState(true, 3);
            }

            if (GetEnemyDataSheet(3).GetEnemyShieldValue() >= 1)
            {
                int _doubleStack = _stackValue * 2;
                GetEnemyScript(3).EnemyAttacked(GetEnemyScript(3).e_str_enemyType, _doubleStack);
            }
            else
            {
                GetEnemyScript(3).EnemyAttacked(GetEnemyScript(3).e_str_enemyType, _stackValue);
            }
        }

        // If the Enemy was Enemy 4
        if (_enemyNum == 4)
        {
            if (GetEnemyAcidEffectState(4) == false)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleAcidEnemyUI(true, 4);
                SetEnemyAcidicEffectStackCount(_stackValue, 4);
                SetEnemyAcidEffectState(true, 4);
            }

            if (GetEnemyDataSheet(4).GetEnemyShieldValue() >= 1)
            {
                int _doubleStack = _stackValue * 2;
                GetEnemyScript(4).EnemyAttacked(GetEnemyScript(4).e_str_enemyType, _doubleStack);
            }
            else
            {
                GetEnemyScript(4).EnemyAttacked(GetEnemyScript(4).e_str_enemyType, _stackValue);
            }
        }

        // If the Enemy was Enemy 5
        if (_enemyNum == 5)
        {
            if (GetEnemyAcidEffectState(5) == false)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleAcidEnemyUI(true, 5);
                SetEnemyAcidicEffectStackCount(_stackValue, 5);
                SetEnemyAcidEffectState(true, 5);
            }

            if (GetEnemyDataSheet(5).GetEnemyShieldValue() >= 1)
            {
                int _doubleStack = _stackValue * 2;
                GetEnemyScript(5).EnemyAttacked(GetEnemyScript(5).e_str_enemyType ,_doubleStack);
            }
            else
            {
                GetEnemyScript(5).EnemyAttacked(GetEnemyScript(5).e_str_enemyType, _stackValue);
            }
        }
    }

    /// <summary>
    /// Function for initial trigger for Enemy Bleeding Effect
    /// - Josh
    /// </summary>
    /// <param name="_stackValue"></param>
    /// /// <param name="_enemyNum"></param>
    public void EnemyBleedStatusEffect(int _stackValue, int _enemyNum)
    {
        // If the Enemy was Enemy 1
        if(_enemyNum == 1)
        {
            if (GetEnemyBleedEffectState(1) == false)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 1);
                SetEnemyBleedEffectStackCount(_stackValue, 1);
                SetEnemyBleedEffectState(true, 1);
            }
            else
            {
                Debug.Log("Enemy 1 Bleed Effect already active!");
                SetEnemyBleedEffectStackCount((GetEnemyBleedEffectStackCount(1) + _stackValue), 1);
            }
        }

        // If the Enemy was Enemy 2
        if (_enemyNum == 2)
        {
            if (GetEnemyBleedEffectState(2) == false)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 2);
                SetEnemyBleedEffectStackCount(_stackValue, 2);
                SetEnemyBleedEffectState(true, 2);
            }
            else
            {
                Debug.Log("Enemy 2 Bleed Effect already active!");
                SetEnemyBleedEffectStackCount((GetEnemyBleedEffectStackCount(2) + _stackValue), 2);
            }
        }

        // If the Enemy was Enemy 3
        if (_enemyNum == 3)
        {
            if (GetEnemyBleedEffectState(3) == false)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 3);
                SetEnemyBleedEffectStackCount(_stackValue, 3);
                SetEnemyBleedEffectState(true, 3);
            }
            else
            {
                Debug.Log("Enemy 3 Bleed Effect already active!");
                SetEnemyBleedEffectStackCount((GetEnemyBleedEffectStackCount(3) + _stackValue), 3);
            }
        }

        // If the Enemy was Enemy 4
        if (_enemyNum == 4)
        {
            if (GetEnemyBleedEffectState(4) == false)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 4);
                SetEnemyBleedEffectStackCount(_stackValue, 4);
                SetEnemyBleedEffectState(true, 4);
            }
            else
            {
                Debug.Log("Enemy 4 Bleed Effect already active!");
                SetEnemyBleedEffectStackCount((GetEnemyBleedEffectStackCount(4) + _stackValue), 4);
            }
        }

        // If the Enemy was Enemy 5
        if (_enemyNum == 5)
        {
            if (GetEnemyBleedEffectState(5) == false)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 5);
                SetEnemyBleedEffectStackCount(_stackValue, 5);
                SetEnemyBleedEffectState(true, 5);
            }
            else
            {
                Debug.Log("Enemy 5 Bleed Effect already active!");
                SetEnemyBleedEffectStackCount((GetEnemyBleedEffectStackCount(5) + _stackValue), 5);
            }
        }
    }

    /// <summary>
    /// Function for initial trigger for Enemy Frality Effect
    /// - Josh
    /// </summary>
    /// <param name="_stackValue"></param>
    /// /// <param name="_enemyNum"></param>
    public void EnemyFrailtyStatusEffect(int _stackValue, int _enemyNum)
    {
        if (GetEnemyResistantEffectStackCount(_enemyNum) == 0)
        {
            int _combinedTotal = GetEnemyFrailtyEffectStackCount(_enemyNum) + _stackValue;
            int _remainder = _stackValue - GetEnemyFrailtyEffectStackCount(_enemyNum);
            if (_combinedTotal <= 5)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, _enemyNum);
                SetEnemyFrailtyEffectState(true, _enemyNum);
                SetEnemyFrailtyEffectStackCount(_combinedTotal, _enemyNum);
            }
            else
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, _enemyNum);
                SetEnemyFrailtyEffectState(true, _enemyNum);
                SetEnemyFrailtyEffectStackRemainder((_remainder + GetEnemyFrailtyEffectStackRemainder(_enemyNum)), _enemyNum);
                SetEnemyFrailtyEffectStackCount(5, _enemyNum);
            }
        }
        else
        {
            int _totalResistant = GetEnemyResistantEffectStackCount(_enemyNum) + GetEnemyResistantEffectStackRemainder(_enemyNum) + _stackValue;
            int _totalFrality = GetEnemyFrailtyEffectStackCount(_stackValue) + GetEnemyFrailtyEffectStackRemainder(_stackValue);

            int _option1 = _totalResistant - _totalFrality; // Higher Resistant
            int _option2 = _totalFrality - _totalResistant; // Higher Frality

            if (_option1 > _option2)
            {
                // Set up Resistant
                if (_option1 <= 5)
                {
                    SetEnemyResistantEffectStackCount(_option1, _stackValue);
                }
                else
                {
                    int _remainder = _option1 - 5;
                    SetEnemyResistantEffectStackCount(5, _enemyNum);
                    SetEnemyResistantEffectStackRemainder((_remainder + GetEnemyResistantEffectStackRemainder(_enemyNum)), _enemyNum);
                }
                SetEnemyResistantEffectState(true, _enemyNum);
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(true, _enemyNum);

                // Turn off Frailty 
                SetEnemyFrailtyEffectStackCount(0, _enemyNum);
                SetEnemyFrailtyEffectStackRemainder(0, _enemyNum);
                SetEnemyFrailtyEffectState(false, _enemyNum);
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(false, _enemyNum);
            }
            else if (_option1 == _option2)
            {
                // Turn off Resistant 
                SetEnemyResistantEffectStackCount(0, _enemyNum);
                SetEnemyResistantEffectStackRemainder(0, _enemyNum);
                SetEnemyResistantEffectState(false, _enemyNum);
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(false, _enemyNum);

                // Turn off Frailty 
                SetEnemyFrailtyEffectStackCount(0, _enemyNum);
                SetEnemyFrailtyEffectStackRemainder(0, _enemyNum);
                SetEnemyFrailtyEffectState(false, _enemyNum);
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(false, _enemyNum);
            }
            else
            {
                // Set up Frality
                if (_option2 <= 5)
                {
                    SetEnemyFrailtyEffectStackCount(_option2, _enemyNum);
                }
                else
                {
                    int _remainder = _option2 - 5;
                    SetEnemyFrailtyEffectStackCount(5, _enemyNum);
                    SetEnemyFrailtyEffectStackRemainder((_remainder + GetEnemyFrailtyEffectStackRemainder(_enemyNum)), _enemyNum);
                }
                SetEnemyFrailtyEffectState(true, _enemyNum);
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, _enemyNum);

                // Turn off Resistant 
                SetEnemyResistantEffectStackCount(0, _enemyNum);
                SetEnemyResistantEffectStackRemainder(0, _enemyNum);
                SetEnemyResistantEffectState(false, _enemyNum);
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(false, _enemyNum);
            }
        }
    }

    /// <summary>
    /// Function for initial trigger for Enemy Resistant Effects
    /// - Josh
    /// </summary>
    /// <param name="_stackValue"></param>
    /// <param name="_enemyNum"></param>
    public void EnemyResistantStatusEffect(int _stackValue, int _enemyNum)
    {
        if (GetEnemyResistantEffectStackCount(_enemyNum) == 0)
        {
            int _combinedTotal = GetEnemyFrailtyEffectStackCount(_enemyNum) + _stackValue;
            int _remainder = _stackValue - GetEnemyFrailtyEffectStackCount(_enemyNum);
            if (_combinedTotal <= 5)
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, _enemyNum);
                SetEnemyFrailtyEffectState(true, _enemyNum);
                SetEnemyFrailtyEffectStackCount(_combinedTotal, _enemyNum);
            }
            else
            {
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, _enemyNum);
                SetEnemyFrailtyEffectState(true, _enemyNum);
                SetEnemyFrailtyEffectStackRemainder((_remainder + GetEnemyFrailtyEffectStackRemainder(_enemyNum)), _enemyNum);
                SetEnemyFrailtyEffectStackCount(5, _enemyNum);
            }
        }
        else
        {
            int _totalResistant = GetEnemyResistantEffectStackCount(_enemyNum) + GetEnemyResistantEffectStackRemainder(_enemyNum) + _stackValue;
            int _totalFrality = GetEnemyFrailtyEffectStackCount(_enemyNum) + GetEnemyFrailtyEffectStackRemainder(_enemyNum);

            int _option1 = _totalResistant - _totalFrality; // Higher Resistant
            int _option2 = _totalFrality - _totalResistant; // Higher Frality

            if (_option1 > _option2)
            {
                // Set up Resistant
                if (_option1 <= 5)
                {
                    SetEnemyResistantEffectStackCount(_option1, _enemyNum);
                }
                else
                {
                    int _remainder = _option1 - 5;
                    SetEnemyResistantEffectStackCount(5, _enemyNum);
                    SetEnemyResistantEffectStackRemainder((_remainder + GetEnemyResistantEffectStackRemainder(_enemyNum)), _enemyNum);
                }
                SetEnemyResistantEffectState(true, _enemyNum);
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(true, _enemyNum);

                // Turn off Frailty 
                SetEnemyFrailtyEffectStackCount(0, _enemyNum);
                SetEnemyFrailtyEffectStackRemainder(0, _enemyNum);
                SetEnemyFrailtyEffectState(false, _enemyNum);
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(false, _enemyNum);
            }
            else if (_option1 == _option2)
            {
                // Turn off Resistant 
                SetEnemyResistantEffectStackCount(0, _enemyNum);
                SetEnemyResistantEffectStackRemainder(0, _enemyNum);
                SetEnemyResistantEffectState(false, _enemyNum);
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(false, _enemyNum);

                // Turn off Frailty 
                SetEnemyFrailtyEffectStackCount(0, _enemyNum);
                SetEnemyFrailtyEffectStackRemainder(0, _enemyNum);
                SetEnemyFrailtyEffectState(false, _enemyNum);
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(false, _enemyNum);
            }
            else
            {
                // Set up Frality
                if (_option2 <= 5)
                {
                    SetEnemyFrailtyEffectStackCount(_option2, _enemyNum);
                }
                else
                {
                    int _remainder = _option2 - 5;
                    SetEnemyFrailtyEffectStackCount(5, _enemyNum);
                    SetEnemyFrailtyEffectStackRemainder(_remainder + GetEnemyFrailtyEffectStackRemainder(_enemyNum), _enemyNum);
                }
                SetEnemyFrailtyEffectState(true, _enemyNum);
                g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, _enemyNum);

                // Turn off Resistant 
                SetEnemyResistantEffectStackCount(0, _enemyNum);
                SetEnemyResistantEffectStackRemainder(0, _enemyNum);
                SetEnemyResistantEffectState(false, _enemyNum);
                g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(false, _enemyNum);
            }
        }
    }

    /// <summary>
    /// Function for initial trigger for Enemy Stuns
    /// - Josh
    /// </summary>
    /// <param name="_stackValue"></param>
    /// <param name="_enemyNum"></param>
    public void EnemyStunStatusEffect(int _stackValue, int _enemyNum)
    {
        //If enemy was enemy 1
        if (_enemyNum == 1)
        {
            if (GetEnemyStunEffectState(1) == false)
            {
                SetEnemySkipTurnState(true, 1);
                g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(true, 1);
                SetEnemyStunEffectStackCount(_stackValue, 1);
                SetEnemyStunEffectState(true, 1);
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        //If enemy was enemy 2
        if (_enemyNum == 2)
        {
            if (GetEnemyStunEffectState(2) == false)
            {
                SetEnemySkipTurnState(true, 2);
                g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(true, 2);
                SetEnemyStunEffectStackCount(_stackValue, 2);
                SetEnemyStunEffectState(true, 2);
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        //If enemy was enemy 3
        if (_enemyNum == 3)
        {
            if (GetEnemyStunEffectState(3) == false)
            {
                SetEnemySkipTurnState(true, 3);
                g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(true, 3);
                SetEnemyStunEffectStackCount(_stackValue, 3);
                SetEnemyStunEffectState(true, 3);
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        //If enemy was enemy 4
        if (_enemyNum == 4)
        {
            if (GetEnemyStunEffectState(4) == false)
            {
                SetEnemySkipTurnState(true, 4);
                g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(true, 4);
                SetEnemyStunEffectStackCount(_stackValue, 4);
                SetEnemyStunEffectState(true, 4);
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }

        //If enemy was enemy 5
        if (_enemyNum == 5)
        {
            if (GetEnemyStunEffectState(5) == false)
            {
                SetEnemySkipTurnState(true, 5);
                g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(true, 5);
                SetEnemyStunEffectStackCount(_stackValue, 5);
                SetEnemyStunEffectState(true, 5);
            }
            else
            {
                Debug.Log("Effect already active!");
            }
        }
    }

    /// <summary>
    /// Helper function of a helper function, used to calculate new bleed damage effect
    /// - Josh
    /// </summary>
    /// <param name="_currentDamage"></param>
    /// <returns>
    /// _bleedingCalc (int)
    /// </returns>
    private int BleedEffectCalculator(int _currentDamage)
    {
        float _seperateCalc = _currentDamage * 0.5f;
        int _bleedingCalc = Mathf.FloorToInt(_seperateCalc); 
        return _bleedingCalc;
    }

    /// <summary>
    /// Helper to trigger bleed after intial function
    /// - Josh
    /// </summary>
    /// <param name="_currentDamage"></param>
    /// <param name="_enemyNum"></param>
    private int BleedEffectPerTurn(int _currentDamage, int _enemyNum)
    {
        int _bleedingDamageForTurn = BleedEffectCalculator(_currentDamage);
        GetEnemyScript(_enemyNum).EnemyAttacked(e_str_enemy1Type, _bleedingDamageForTurn);
        return _bleedingDamageForTurn;
    }

    /// <summary>
    /// Helper function for status effect checking legibility
    /// Controller for Enemy 1 Status Effects
    /// - Josh
    /// </summary>
    private void Enemy1StatusChecks()
    {
        // Update Bleed state For Enemy 1
        if (GetEnemyBleedEffectState(1) == true)
        {
            SetEnemyBleedEffectStackCount(BleedEffectPerTurn(GetEnemyBleedEffectStackCount(1), 1), 1);
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 1);
        }

        // Update Frailty state For Enemy 1
        if (GetEnemyFrailtyEffectState(1) == true)
        {
            SetEnemyFrailtyEffectStackCount(0, 1);
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, 1);
            // Check Stack Remainder
            UpdateEnemyFrailtyStackRemainder(1);
        }

        // Update Resistant state For Enemy 1
        if (GetEnemyResistantEffectState(1) == true)
        {
            SetEnemyResistantEffectStackCount(0, 1);
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(true, 1);
            //Check Stack Remainder
            UpdateEnemyResistantStackRemainder(1);
        }

        // Update Stun state For Enemy 1
        if (GetEnemyStunEffectState(1) == true)
        {
            e_i_stunStackCountEnemy1 -= 1;
            g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(false, 1);
        }

        // Check Acid state For Enemy 1 is over
        if (GetEnemyAcidEffectStackCount(1) <= 0)
        {
            SetEnemyAcidEffectState(false, 1);
            g_global.g_UIManager.sc_characterGraphics.ToggleAcidEnemyUI(false, 1);
        }

        // Check Bleed state For Enemy 1 is over
        if (GetEnemyBleedEffectStackCount(1) <= 0)
        {
            SetEnemyBleedEffectState(false, 1);
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(false, 1);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 1);
        }

        // Check Frailty state For Enemy 1 is over
        if (GetEnemyFrailtyEffectStackCount(1) <= 0)
        {
            SetEnemyFrailtyEffectState(false, 1);
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(false, 1);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, 1);
        }

        // Check Resistant state For Enemy 1 is over
        if (GetEnemyResistantEffectStackCount(1) <= 0)
        {
            SetEnemyResistantEffectState(false, 1);
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(false, 1);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(true, 1);
        }

        // Check Stun state For Enemy 1 is over
        if (GetEnemyStunEffectStackCount(1) <= 0)
        {
            SetEnemyStunEffectState(false, 1);
            g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(false, 1);
        }
    }

    /// <summary>
    /// Helper function for status effect checking legibility
    /// Controller for Enemy 2 Status Effects
    /// - Josh
    /// </summary>
    private void Enemy2StatusChecks()
    {
        // Update Bleed state For Enemy 2
        if (GetEnemyBleedEffectState(2) == true)
        {
            SetEnemyBleedEffectStackCount(BleedEffectPerTurn(GetEnemyBleedEffectStackCount(2), 2), 2);
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 2);
        }

        // Update Frailty state For Enemy 2
        if (GetEnemyFrailtyEffectState(2) == true)
        {
            SetEnemyFrailtyEffectStackCount(0, 2);
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, 2);
            // Check Stack Remainder
            UpdateEnemyFrailtyStackRemainder(2);
        }

        // Update Resistant state For Enemy 2
        if (GetEnemyResistantEffectState(2) == true)
        {
            SetEnemyResistantEffectStackCount(0, 2);
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(true, 2);
            //Check Stack Remainder
            UpdateEnemyResistantStackRemainder(2);
        }

        // Update Stun state For Enemy 2
        if (GetEnemyStunEffectState(2) == true)
        {
            e_i_stunStackCountEnemy2 -= 1;
            g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(false, 2);
        }

        // Check Acid state For Enemy 2 is over
        if (GetEnemyAcidEffectStackCount(2) <= 0)
        {
            SetEnemyAcidEffectState(false, 2);
            g_global.g_UIManager.sc_characterGraphics.ToggleAcidEnemyUI(false, 2);
        }

        // Check Bleed state For Enemy 2 is over
        if (GetEnemyBleedEffectStackCount(2) <= 0)
        {
            SetEnemyBleedEffectState(false, 2);
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(false, 2);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 2);
        }

        // Check Frailty state For Enemy 2 is over
        if (GetEnemyFrailtyEffectStackCount(2) <= 0)
        {
            SetEnemyFrailtyEffectState(false, 2);
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(false, 2);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, 2);
        }

        // Check Resistant state For Enemy 2 is over
        if (GetEnemyResistantEffectStackCount(2) <= 0)
        {
            SetEnemyResistantEffectState(false, 2);
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(false, 2);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(true, 2);
        }

        // Check Stun state For Enemy 2 is over
        if (GetEnemyStunEffectStackCount(2) <= 0)
        {
            SetEnemyStunEffectState(false, 2);
            g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(false, 2);
        }
    }

    /// <summary>
    /// Helper function for status effect checking legibility
    /// Controller for Enemy 3 Status Effects
    /// - Josh
    /// </summary>
    private void Enemy3StatusChecks()
    {
        // Update Bleed state For Enemy 3
        if (GetEnemyBleedEffectState(3) == true)
        {
            SetEnemyBleedEffectStackCount(BleedEffectPerTurn(GetEnemyBleedEffectStackCount(3), 3), 3);
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 3);
        }

        // Update Frailty state For Enemy 3
        if (GetEnemyFrailtyEffectState(3) == true)
        {
            SetEnemyFrailtyEffectStackCount(0, 3);
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, 3);
            // Check Stack Remainder
            UpdateEnemyFrailtyStackRemainder(3);
        }

        // Update Resistant state For Enemy 3
        if (GetEnemyResistantEffectState(3) == true)
        {
            SetEnemyResistantEffectStackCount(0, 3);
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(true, 3);
            //Check Stack Remainder
            UpdateEnemyResistantStackRemainder(3);
        }

        // Update Stun state For Enemy 3
        if (GetEnemyStunEffectState(3) == true)
        {
            e_i_stunStackCountEnemy3 -= 1;
            g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(false, 3);
        }

        // Check Acid state For Enemy 3 is over
        if (GetEnemyAcidEffectStackCount(3) <= 0)
        {
            SetEnemyAcidEffectState(false, 3);
            g_global.g_UIManager.sc_characterGraphics.ToggleAcidEnemyUI(false, 3);
        }

        // Check Bleed state For Enemy 3 is over
        if (GetEnemyBleedEffectStackCount(3) <= 0)
        {
            SetEnemyBleedEffectState(false, 3);
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(false, 3);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 3);
        }

        // Check Frailty state For Enemy 3 is over
        if (GetEnemyFrailtyEffectStackCount(3) <= 0)
        {
            SetEnemyFrailtyEffectState(false, 3);
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(false, 3);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, 3);
        }

        // Check Resistant state For Enemy 3 is over
        if (GetEnemyResistantEffectStackCount(3) <= 0)
        {
            SetEnemyResistantEffectState(false, 3);
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(false, 3);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(true, 3);
        }

        // Check Stun state For Enemy 3 is over
        if (GetEnemyStunEffectStackCount(3) <= 0)
        {
            SetEnemyStunEffectState(false, 3);
            g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(false, 3);
        }
    }

    /// <summary>
    /// Helper function for status effect checking legibility
    /// Controller for Enemy 4 Status Effects
    /// - Josh
    /// </summary>
    private void Enemy4StatusChecks()
    {
        // Update Bleed state For Enemy 4
        if (GetEnemyBleedEffectState(4) == true)
        {
            SetEnemyBleedEffectStackCount(BleedEffectPerTurn(GetEnemyBleedEffectStackCount(4), 4), 4);
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 4);
        }

        // Update Frailty state For Enemy 4
        if (GetEnemyFrailtyEffectState(4) == true)
        {
            SetEnemyFrailtyEffectStackCount(0, 4);
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, 4);
            // Check Stack Remainder
            UpdateEnemyFrailtyStackRemainder(4);
        }

        // Update Resistant state For Enemy 4
        if (GetEnemyResistantEffectState(4) == true)
        {
            SetEnemyResistantEffectStackCount(0, 4);
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(true, 4);
            //Check Stack Remainder
            UpdateEnemyResistantStackRemainder(4);
        }

        // Update Stun state For Enemy 4
        if (GetEnemyStunEffectState(4) == true)
        {
            e_i_stunStackCountEnemy4 -= 1;
            g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(false, 4);
        }

        // Check Acid state For Enemy 4 is over
        if (GetEnemyAcidEffectStackCount(4) <= 0)
        {
            SetEnemyAcidEffectState(false, 4);
            g_global.g_UIManager.sc_characterGraphics.ToggleAcidEnemyUI(false, 4);
        }

        // Check Bleed state For Enemy 4 is over
        if (GetEnemyBleedEffectStackCount(4) <= 0)
        {
            SetEnemyBleedEffectState(false, 4);
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(false, 4);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 4);
        }

        // Check Frailty state For Enemy 4 is over
        if (GetEnemyFrailtyEffectStackCount(4) <= 0)
        {
            SetEnemyFrailtyEffectState(false, 4);
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(false, 4);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, 4);
        }

        // Check Resistant state For Enemy 4 is over
        if (GetEnemyResistantEffectStackCount(4) <= 0)
        {
            SetEnemyResistantEffectState(false, 4);
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(false, 4);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(true, 4);
        }

        // Check Stun state For Enemy 1 is over
        if (GetEnemyStunEffectStackCount(4) <= 0)
        {
            SetEnemyStunEffectState(false, 4);
            g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(false, 4);
        }
    }

    /// <summary>
    /// Helper function for status effect checking legibility
    /// Controller for Enemy 5 Status Effects
    /// - Josh
    /// </summary>
    private void Enemy5StatusChecks()
    {
        // Update Bleed state For Enemy 5
        if (GetEnemyBleedEffectState(5) == true)
        {
            SetEnemyBleedEffectStackCount(BleedEffectPerTurn(GetEnemyBleedEffectStackCount(5), 5), 5);
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 5);
        }

        // Update Frailty state For Enemy 5
        if (GetEnemyFrailtyEffectState(5) == true)
        {
            SetEnemyFrailtyEffectStackCount(0, 5);
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, 5);
            // Check Stack Remainder
            UpdateEnemyFrailtyStackRemainder(5);
        }

        // Update Resistant state For Enemy 5
        if (GetEnemyResistantEffectState(5) == true)
        {
            SetEnemyResistantEffectStackCount(0, 5);
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(true, 5);
            //Check Stack Remainder
            UpdateEnemyResistantStackRemainder(5);
        }

        // Update Stun state For Enemy 5
        if (GetEnemyStunEffectState(5) == true)
        {
            e_i_stunStackCountEnemy5 -= 1;
            g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(false, 5);
        }

        // Check Acid state For Enemy 5 is over
        if (GetEnemyAcidEffectStackCount(5) <= 0)
        {
            SetEnemyAcidEffectState(false, 5);
            g_global.g_UIManager.sc_characterGraphics.ToggleAcidEnemyUI(false, 5);
        }

        // Check Bleed state For Enemy 5 is over
        if (GetEnemyBleedEffectStackCount(5) <= 0)
        {
            SetEnemyBleedEffectState(false, 5);
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(false, 5);
        }
        else 
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleBleedEnemyUI(true, 5);
        }

        // Check Frailty state For Enemy 5 is over
        if (GetEnemyFrailtyEffectStackCount(5) <= 0)
        {
            SetEnemyFrailtyEffectState(false, 5);
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(false, 5);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleFrailtyEnemyUI(true, 5);
        }

        // Check Resistant state For Enemy 5 is over
        if (GetEnemyResistantEffectStackCount(5) <= 0)
        {
            SetEnemyResistantEffectState(false, 5);
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(false, 5);
        }
        else
        {
            g_global.g_UIManager.sc_characterGraphics.ToggleResistantEnemyUI(true, 5);
        }

        // Check Stun state For Enemy 5 is over
        if (GetEnemyStunEffectStackCount(5) <= 0)
        {
            SetEnemyStunEffectState(false, 5);
            g_global.g_UIManager.sc_characterGraphics.ToggleStunEnemyUI(false, 5);
        }
    }

    /// <summary>
    /// This helper function switches whether the enemy is going to attack or defend
    /// Called in S_TurnManager
    /// -Josh & Riley
    /// </summary>
    public void EnemyActionCheck()
    {
        if (GetEnemyActiveState(1) == true) // Check if enemy 1 is present
        {
            if (g_global.g_iconManager.ls_e_statusStrings[0] == "attack") //Enemy 1 Attack
            {
                e_b_enemy1Attacking = true;
                e_b_enemy1Shielding = false;
                e_b_enemy1SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[0] == "shield") // Enemy 1 Shields
            {
                e_b_enemy1Attacking = false;
                e_b_enemy1Shielding = true;
                e_b_enemy1SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[0] == "ability") // Enemy 1 does their ability
            {
                e_b_enemy1Attacking = false;
                e_b_enemy1Shielding = false;
                e_b_enemy1SpecialAbility = true;
            }
        }

        if (GetEnemyActiveState(2) == true) // Check if enemy 2 is present
        {
            if (g_global.g_iconManager.ls_e_statusStrings[1] == "attack") //Enemy 2 Attack
            {
                e_b_enemy2Attacking = true;
                e_b_enemy2Shielding = false;
                e_b_enemy2SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[1] == "shield") // Enemy 2 Shields
            {
                e_b_enemy2Attacking = false;
                e_b_enemy2Shielding = true;
                e_b_enemy2SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[1] == "ability") // Enemy 2 does their ability
            {
                e_b_enemy2Attacking = false;
                e_b_enemy2Shielding = false;
                e_b_enemy2SpecialAbility = true;
            }
        }

        if (GetEnemyActiveState(3) == true) // Check if enemy 3 is present
        {
            if (g_global.g_iconManager.ls_e_statusStrings[2] == "attack") //Enemy = 3 Attack
            {
                e_b_enemy3Attacking = true;
                e_b_enemy3Shielding = false;
                e_b_enemy3SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[2] == "shield") // Enemy 3 Shields
            {
                e_b_enemy3Attacking = false;
                e_b_enemy3Shielding = true;
                e_b_enemy3SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[2] == "ability") // Enemy 3 does their ability
            {
                e_b_enemy3Attacking = false;
                e_b_enemy3Shielding = false;
                e_b_enemy3SpecialAbility = true;
            }
        }

        if (GetEnemyActiveState(4) == true) // Check if enemy 4 is present
        {
            if (g_global.g_iconManager.ls_e_statusStrings[3] == "attack") //Enemy 4 Attack
            {
                e_b_enemy4Attacking = true;
                e_b_enemy4Shielding = false;
                e_b_enemy4SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[3] == "shield") // Enemy 4 Shields
            {
                e_b_enemy4Attacking = false;
                e_b_enemy4Shielding = true;
                e_b_enemy4SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[3] == "ability") // Enemy 4 does their ability
            {
                e_b_enemy4Attacking = false;
                e_b_enemy4Shielding = false;
                e_b_enemy4SpecialAbility = true;
            }
        }

        if (GetEnemyActiveState(5) == true) // Check if enemy 5 is present
        {
            if (g_global.g_iconManager.ls_e_statusStrings[4] == "attack") //Enemy 5 Attack
            {
                e_b_enemy5Attacking = true;
                e_b_enemy5Shielding = false;
                e_b_enemy5SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[4] == "shield") // Enemy 5 Shields
            {
                e_b_enemy5Attacking = false;
                e_b_enemy5Shielding = true;
                e_b_enemy5SpecialAbility = false;
            }
            else if (g_global.g_iconManager.ls_e_statusStrings[4] == "ability") // Enemy 5 does their ability
            {
                e_b_enemy5Attacking = false;
                e_b_enemy5Shielding = false;
                e_b_enemy5SpecialAbility = true;
            }
        }
    }


   /// <summary>
   /// Useful to see what enemy's turn should be active
   /// - Josh
   /// </summary>
   /// <returns></returns>
    public int CurrentEnemyTurnNumber()
    {
        if (e_b_enemy1Turn == true)
        {
            return 1;
        }
        else if (e_b_enemy2Turn == true)
        {
            return 2;
        }
        else if (e_b_enemy3Turn == true)
        {
            return 3;
        }
        else if (e_b_enemy4Turn == true)
        {
            return 4;
        }
        else if (e_b_enemy5Turn == true)
        {
            return 5;
        }
        else 
        {
            return 0; 
        }
    }


    /// <summary>
    /// Let the delegate list know which enemies should be considered in play or not
    /// - Josh
    /// </summary>
    public void UpdateActiveEnemies()
    {
        // Check Enemy 1
        if (g_global.g_enemyState.enemy1 != null)
        {
            if (g_global.g_enemyState.e_b_enemy1Dead == false)
            {
                g_global.g_enemyState.e_b_enemy1IsActive = true; 
            }
            else
            {
                g_global.g_enemyState.e_b_enemy1IsActive = false;
            }
        }
        else
        {
            g_global.g_enemyState.e_b_enemy1IsActive = false;
        }

        // Check Enemy 2
        if (g_global.g_enemyState.enemy2 != null)
        {
            if (g_global.g_enemyState.e_b_enemy2Dead == false)
            {
                g_global.g_enemyState.e_b_enemy2IsActive = true;
            }
            else
            {
                g_global.g_enemyState.e_b_enemy2IsActive = false;
            }
        }
        else
        {
            g_global.g_enemyState.e_b_enemy2IsActive = false;
        }

        // Check Enemy 3
        if (g_global.g_enemyState.enemy3 != null)
        {
            if (g_global.g_enemyState.e_b_enemy3Dead == false)
            {
                g_global.g_enemyState.e_b_enemy3IsActive = true;
            }
            else
            {
                g_global.g_enemyState.e_b_enemy3IsActive = false;
            }
        }
        else
        {
            g_global.g_enemyState.e_b_enemy3IsActive = false;
        }

        // Check Enemy 4
        if (g_global.g_enemyState.enemy4 != null)
        {
            if (g_global.g_enemyState.e_b_enemy4Dead == false)
            {
                g_global.g_enemyState.e_b_enemy4IsActive = true;
            }
            else
            {
                g_global.g_enemyState.e_b_enemy4IsActive = false;
            }
        }
        else
        {
            g_global.g_enemyState.e_b_enemy4IsActive = false;
        }

        // Check Enemy 5
        if (g_global.g_enemyState.enemy5 != null)
        {
            if (g_global.g_enemyState.e_b_enemy5Dead == false)
            {
                g_global.g_enemyState.e_b_enemy5IsActive = true;
            }
            else
            {
                g_global.g_enemyState.e_b_enemy5IsActive = false;
            }
        }
        else
        {
            g_global.g_enemyState.e_b_enemy5IsActive = false;
        }
    }

    /// <summary>
    /// Return the current state of the given enemy based off enemy number
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public bool EnemyStateCheck(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            if (g_global.g_enemyState.enemy1 != null)
            {
                if (g_global.g_enemyState.e_b_enemy1Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (_enemyNum == 2)
        {
            if (g_global.g_enemyState.enemy2 != null)
            {
                if (g_global.g_enemyState.e_b_enemy2Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (_enemyNum == 3)
        {
            if (g_global.g_enemyState.enemy3 != null)
            {
                if (g_global.g_enemyState.e_b_enemy3Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (_enemyNum == 4)
        {
            if (g_global.g_enemyState.enemy4 != null)
            {
                if (g_global.g_enemyState.e_b_enemy4Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else if (_enemyNum == 5)
        {
            if (g_global.g_enemyState.enemy5 != null)
            {
                if (g_global.g_enemyState.e_b_enemy5Dead == false)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// If _characterIdentifier == 0, player's turn
    /// Else if _characterIdentifier == 1, 2, 3, 4, 5, it's that enemies turn
    /// For Debug Purposes
    /// - Josh
    /// </summary>
    /// <param name="_characterIdentifier"></param>
    public void DeclareCurrentTurn(int _characterIdentifier)
    {
        if (_characterIdentifier == 0) // Player's Turn
        {
            e_b_enemy1Turn = false;
            e_b_enemy2Turn = false;
            e_b_enemy3Turn = false;
            e_b_enemy4Turn = false;
            e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 1) // Enemy 1's Turn
        {
            e_b_enemy1Turn = true;
            e_b_enemy2Turn = false;
            e_b_enemy3Turn = false;
            e_b_enemy4Turn = false;
            e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 2) // Enemy 2's Turn
        {
            e_b_enemy1Turn = false;
            e_b_enemy2Turn = true;
            e_b_enemy3Turn = false;
            e_b_enemy4Turn = false;
            e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 3) // Enemy 3's Turn
        {
            e_b_enemy1Turn = false;
            e_b_enemy2Turn = false;
            e_b_enemy3Turn = true;
            e_b_enemy4Turn = false;
            e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 4) // Enemy 4's Turn
        {
            e_b_enemy1Turn = false;
            e_b_enemy2Turn = false;
            e_b_enemy3Turn = false;
            e_b_enemy4Turn = true;
            e_b_enemy5Turn = false;
        }
        else if (_characterIdentifier == 5) // Enemy 5's Turn
        {
            e_b_enemy1Turn = false;
            e_b_enemy2Turn = false;
            e_b_enemy3Turn = false;
            e_b_enemy4Turn = false;
            e_b_enemy5Turn = true;
        }
    }

    /// <summary>
    /// Reset the magician special ability as it is only supposed to last one turn
    /// - Josh
    /// </summary>
    public void ResetMagicianAbility() 
    {
        e_i_magicianAbilityValue = 0;
        e_b_magicianAbilityBool = false;
    }

    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////---------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 

    /// <summary>
    /// Return the state of the bool for if an enemy is active or not
    /// Active = true
    /// Not Active = false
    /// - Josh
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns>
    /// S_EnemyState.e_b_enemy1IsActive || S_EnemyState.e_b_enemy2IsActive || S_EnemyState.e_b_enemy3IsActive || S_EnemyState.e_b_enemy4IsActive || S_EnemyState.e_b_enemy5IsActive
    /// </returns>
    public bool GetEnemyActiveState(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_b_enemy1IsActive;
        }
        else if (_enemyNum == 2)
        {
            return e_b_enemy2IsActive;
        }
        else if (_enemyNum == 3)
        {
            return e_b_enemy3IsActive;
        }
        else if (_enemyNum == 4)
        {
            return e_b_enemy4IsActive;
        }
        else if (_enemyNum == 5)
        {
            return e_b_enemy5IsActive;
        }
        else
        {
            Debug.Log("DEBUGL: RETURNED NULL FALSE - S_EnemyState - GetEnemyActiveState()");
            return false;
        }
    }

    /// <summary>
    /// Return the data sheet for a given enemy help
    /// - Josh
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public S_EnemyAttributes GetEnemyDataSheet(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return g_global.g_enemyAttributeSheet1;
        }
        else if (_enemyNum == 2)
        {
            return g_global.g_enemyAttributeSheet2;
        }
        else if (_enemyNum == 3)
        {
            return g_global.g_enemyAttributeSheet3;
        }
        else if (_enemyNum == 4)
        {
            return g_global.g_enemyAttributeSheet4;
        }
        else if (_enemyNum == 5)
        {
            return g_global.g_enemyAttributeSheet5;
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// Return the enemy script based off the given number
    /// - Josh
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public S_Enemy GetEnemyScript(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return g_global.g_enemyState.enemy1;
        }
        if (_enemyNum == 2)
        {
            return g_global.g_enemyState.enemy2;
        }
        if (_enemyNum == 3)
        {
            return g_global.g_enemyState.enemy3;
        }
        if (_enemyNum == 4)
        {
            return g_global.g_enemyState.enemy4;
        }
        if (_enemyNum == 5)
        {
            return g_global.g_enemyState.enemy5;
        }
        else
        {
            Debug.Log("DEBUG: S_EnemyState - RETURNED NULL FALSE - GetEnemyScript()");
            return null;
        }
    }

    /// <summary>
    /// 6 for shield,
    /// 7 for attack,
    /// 8 for Special Ability
    /// </summary>
    /// <param name="_enemyNum"></param>
    /// <returns></returns>
    public int GetEnemyAction(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            if (g_global.g_enemyState.e_b_enemy1Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy1Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy1SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else if (_enemyNum == 2)
        {
            if (g_global.g_enemyState.e_b_enemy2Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy2Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy2SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else if (_enemyNum == 3)
        {
            if (g_global.g_enemyState.e_b_enemy3Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy3Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy3SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else if (_enemyNum == 4)
        {
            if (g_global.g_enemyState.e_b_enemy4Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy4Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy4SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else if (_enemyNum == 5)
        {
            if (g_global.g_enemyState.e_b_enemy5Shielding)
            {
                return 6;
            }
            else if (g_global.g_enemyState.e_b_enemy5Attacking)
            {
                return 7;
            }
            else if (g_global.g_enemyState.e_b_enemy5SpecialAbility)
            {
                return 8;
            }
            else
            {
                Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
                return 0;
            }
        }
        else
        {
            Debug.Log("DEBUG: UNWANTED NULL VALUE RETURNED!");
            return 0;
        }
    }

    /// <summary>
    /// Helper function for updating the frailty stack remainder
    /// - Josh
    /// </summary>
    private void UpdateEnemyFrailtyStackRemainder(int _enemyNum) 
    {
        if (GetEnemyFrailtyEffectStackCount(_enemyNum) == 0 && GetEnemyFrailtyEffectStackRemainder(_enemyNum) >= 1)
        {
            if (GetEnemyFrailtyEffectStackRemainder(_enemyNum) <= 5)
            {
                SetEnemyFrailtyEffectStackCount(GetEnemyFrailtyEffectStackRemainder(_enemyNum), _enemyNum);
                SetEnemyFrailtyEffectStackRemainder(0, _enemyNum);
            }
            else
            {
                int _remainder = GetEnemyFrailtyEffectStackRemainder(_enemyNum) - 5;
                SetEnemyFrailtyEffectStackCount(5, _enemyNum);
                SetEnemyFrailtyEffectStackRemainder(_remainder, _enemyNum);
            }
        }
    }

    /// <summary>
    /// Helper function for updating the resistant stack remainder
    /// - Josh
    /// </summary>
    private void UpdateEnemyResistantStackRemainder(int _enemyNum)
    {
        if(GetEnemyResistantEffectStackCount(_enemyNum) == 0 && GetEnemyResistantEffectStackRemainder(_enemyNum) >= 1)
        {
            if(GetEnemyResistantEffectStackRemainder(_enemyNum) <= 5) 
            {
                SetEnemyResistantEffectStackCount(GetEnemyResistantEffectStackRemainder(_enemyNum), _enemyNum);
                SetEnemyResistantEffectStackRemainder(0, _enemyNum);
            }
            else 
            {
                int _remainder = GetEnemyFrailtyEffectStackRemainder(_enemyNum) - 5;
                SetEnemyResistantEffectStackCount(5, _enemyNum);
                SetEnemyResistantEffectStackRemainder(_remainder, _enemyNum);
            }
        }
    }

    /////////////////////////////-----------------------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Enemy Status Effect Stack Count Setters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////-----------------------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Set the int value of S_EnemyState.e_i_acidStackCountEnemy1 || S_EnemyState.e_i_acidStackCountEnemy2 || S_EnemyState.e_i_acidStackCountEnemy3 || S_EnemyState.e_i_acidStackCountEnemy4 || S_EnemyState.e_i_acidStackCountEnemy5
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyAcidicEffectStackCount(int _stackCount, int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_i_acidStackCountEnemy1 = _stackCount;
        }
        else if (_enemyNum == 2)
        {
            e_i_acidStackCountEnemy2 = _stackCount;
        }
        else if (_enemyNum == 3)
        {
            e_i_acidStackCountEnemy3 = _stackCount;
        }
        else if (_enemyNum == 4)
        {
            e_i_acidStackCountEnemy4 = _stackCount;
        }
        else if (_enemyNum == 5)
        {
            e_i_acidStackCountEnemy5 = _stackCount;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - SetEnemyAcidicEffectStackCount()");
        }
    }

    /// <summary>
    /// Set the int value of S_EnemyState.e_i_bleedStackCountEnemy1 || S_EnemyState.e_i_bleedStackCountEnemy2 || S_EnemyState.e_i_bleedStackCountEnemy3 || S_EnemyState.e_i_bleedStackCountEnemy4 || S_EnemyState.e_i_bleedStackCountEnemy5
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyBleedEffectStackCount(int _stackCount, int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_i_bleedStackCountEnemy1 = _stackCount;
        }
        else if (_enemyNum == 2)
        {
            e_i_bleedStackCountEnemy2 = _stackCount;
        }
        else if (_enemyNum == 3)
        {
            e_i_bleedStackCountEnemy3 = _stackCount;
        }
        else if (_enemyNum == 4)
        {
            e_i_bleedStackCountEnemy4 = _stackCount;
        }
        else if (_enemyNum == 5)
        {
            e_i_bleedStackCountEnemy5 = _stackCount;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - SetEnemyBleedEffectStackCount()");
        }
    }

    /// <summary>
    /// Set the int value of S_EnemyState.e_i_frailtyStackCountEnemy1 || S_EnemyState.e_i_frailtyStackCountEnemy2 || e_i_frailtyStackCountEnemy3 || e_i_frailtyStackCountEnemy4 || S_EnemyState.e_i_frailtyStackCountEnemy5
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyFrailtyEffectStackCount(int _stackCount, int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_i_frailtyStackCountEnemy1 = _stackCount;
        }
        else if (_enemyNum == 2)
        {
            e_i_frailtyStackCountEnemy2 = _stackCount;
        }
        else if (_enemyNum == 3)
        {
            e_i_frailtyStackCountEnemy3 = _stackCount;
        }
        else if (_enemyNum == 4)
        {
            e_i_frailtyStackCountEnemy4 = _stackCount;
        }
        else if (_enemyNum == 5)
        {
            e_i_frailtyStackCountEnemy5 = _stackCount;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - SetEnemyFrailtyEffectStackCount()");
        }
    }

    /// <summary>
    /// Set the int value of S_EnemyState.e_i_resistantStackCountEnemy1 || S_EnemyState.e_i_resistantStackCountEnemy2 || S_EnemyState.e_i_resistantStackCountEnemy3 || S_EnemyState.e_i_resistantStackCountEnemy4 || S_EnemyState.e_i_resistantStackCountEnemy5
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyResistantEffectStackCount(int _stackCount, int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_i_resistantStackCountEnemy1 = _stackCount;
        }
        else if (_enemyNum == 2)
        {
            e_i_resistantStackCountEnemy2 = _stackCount;
        }
        else if (_enemyNum == 3)
        {
            e_i_resistantStackCountEnemy3 = _stackCount;
        }
        else if (_enemyNum == 4)
        {
            e_i_resistantStackCountEnemy4 = _stackCount;
        }
        else if (_enemyNum == 5)
        {
            e_i_resistantStackCountEnemy5 = _stackCount;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - SetEnemyResistantEffectStackCount()");
        }
    }

    /// <summary>
    /// Set the int value of S_EnemyState.e_i_stunStackCountEnemy1 || S_EnemyState.e_i_stunStackCountEnemy2 || S_EnemyState.e_i_stunStackCountEnemy3 || S_EnemyState.e_i_stunStackCountEnemy4 || S_EnemyState.e_i_stunStackCountEnemy5
    /// - Josh
    /// </summary>
    /// <param name="_stackCount"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyStunEffectStackCount(int _stackCount, int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_i_stunStackCountEnemy1 = _stackCount;
        }
        else if (_enemyNum == 2)
        {
            e_i_stunStackCountEnemy2 = _stackCount;
        }
        else if (_enemyNum == 3)
        {
            e_i_stunStackCountEnemy3 = _stackCount;
        }
        else if (_enemyNum == 4)
        {
            e_i_stunStackCountEnemy4 = _stackCount;
        }
        else if (_enemyNum == 5)
        {
            e_i_stunStackCountEnemy5 = _stackCount;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - SetEnemyStunnedEffectStackCount()");
        }
    }

    /// <summary>
    /// Set the bool state of S_EnemyState.e_b_inAcidicStateEnemy1 || S_EnemyState.e_b_inAcidicStateEnemy2 || S_EnemyState.e_b_inAcidicStateEnemy3 || S_EnemyState.e_b_inAcidicStateEnemy4 || S_EnemyState.e_b_inAcidicStateEnemy5
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyAcidEffectState(bool _state, int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_b_inAcidicStateEnemy1 = _state;
        }
        else if (_enemyNum == 2)
        {
            e_b_inAcidicStateEnemy2 = _state;
        }
        else if (_enemyNum == 3)
        {
            e_b_inAcidicStateEnemy3 = _state;
        }
        else if (_enemyNum == 4)
        {
            e_b_inAcidicStateEnemy4 = _state;
        }
        else if (_enemyNum == 5)
        {
            e_b_inAcidicStateEnemy5 = _state;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - SetEnemyAcidicEffectState()");
        }
    }

    /// <summary>
    /// Set the bool state of S_EnemyState.e_b_inBleedStateEnemy1 || S_EnemyState.e_b_inBleedStateEnemy2 || S_EnemyState.e_b_inBleedStateEnemy3 || S_EnemyState.e_b_inBleedStateEnemy4 || S_EnemyState.e_b_inBleedStateEnemy5
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyBleedEffectState(bool _state, int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_b_inBleedStateEnemy1 = _state;
        }
        else if (_enemyNum == 2)
        {
            e_b_inBleedStateEnemy2 = _state;
        }
        else if (_enemyNum == 3)
        {
            e_b_inBleedStateEnemy3 = _state;
        }
        else if (_enemyNum == 4)
        {
            e_b_inBleedStateEnemy4 = _state;
        }
        else if (_enemyNum == 5)
        {
            e_b_inBleedStateEnemy5 = _state;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - SetEnemyBleedEffectState()");
        }
    }

    /// <summary>
    /// Set the bool state of S_EnemyState.e_b_inFralitizedStateEnemy1 || S_EnemyState.e_b_inFralitizedStateEnemy2 || S_EnemyState.e_b_inFralitizedStateEnemy3 || S_EnemyState.e_b_inFralitizedStateEnemy4 || S_EnemyState.e_b_inFralitizedStateEnemy5
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyFrailtyEffectState(bool _state, int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_b_inFralitizedStateEnemy1 = _state;
        }
        else if (_enemyNum == 2)
        {
            e_b_inFralitizedStateEnemy2 = _state;
        }
        else if (_enemyNum == 3)
        {
            e_b_inFralitizedStateEnemy3 = _state;
        }
        else if (_enemyNum == 4)
        {
            e_b_inFralitizedStateEnemy4 = _state;
        }
        else if (_enemyNum == 5)
        {
            e_b_inFralitizedStateEnemy5 = _state;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - SetEnemyFrailtyEffectState()");
        }
    }

    /// <summary>
    /// Set the bool state of S_EnemyState.e_b_inResistantStateEnemy1 || S_EnemyState.e_b_inResistantStateEnemy2 || S_EnemyState.e_b_inResistantStateEnemy3 || S_EnemyState.e_b_inResistantStateEnemy4 || S_EnemyState.e_b_inResistantStateEnemy5
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyResistantEffectState(bool _state, int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_b_inResistantStateEnemy1 = _state;
        }
        else if (_enemyNum == 2)
        {
            e_b_inResistantStateEnemy2 = _state;
        }
        else if (_enemyNum == 3)
        {
            e_b_inResistantStateEnemy3 = _state;
        }
        else if (_enemyNum == 4)
        {
            e_b_inResistantStateEnemy4 = _state;
        }
        else if (_enemyNum == 5)
        {
            e_b_inResistantStateEnemy5 = _state;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - SetEnemyResistantEffectState()");
        }
    }

    /// <summary>
    /// Set the bool state of S_EnemyState.e_b_inStunStateEnemy1 || S_EnemyState.e_b_inStunStateEnemy2 || S_EnemyState.e_b_inStunStateEnemy3 || S_EnemyState.e_b_inStunStateEnemy4 || S_EnemyState.e_b_inStunStateEnemy5
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyStunEffectState(bool _state, int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_b_inStunStateEnemy1 = _state;
        }
        else if (_enemyNum == 2)
        {
            e_b_inStunStateEnemy2 = _state;
        }
        else if (_enemyNum == 3)
        {
            e_b_inStunStateEnemy3 = _state;
        }
        else if (_enemyNum == 4)
        {
            e_b_inStunStateEnemy4 = _state;
        }
        else if (_enemyNum == 5)
        {
            e_b_inStunStateEnemy5 = _state;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - SetEnemyStunEffectState()");
        }
    }

    /// <summary>
    /// Set the bool state of S_EnemyState.e_b_enemy1TurnSkipped || S_EnemyState.e_b_enemy2TurnSkipped || S_EnemyState.e_b_enemy3TurnSkipped || S_EnemyState.e_b_enemy4TurnSkipped || S_EnemyState.e_b_enemy5TurnSkipped
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemySkipTurnState(bool _state, int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_b_enemy1TurnSkipped = _state;
        }
        else if (_enemyNum == 2)
        {
            e_b_enemy2TurnSkipped = _state;
        }
        else if (_enemyNum == 3)
        {
            e_b_enemy3TurnSkipped = _state;
        }
        else if (_enemyNum == 4)
        {
            e_b_enemy4TurnSkipped = _state;
        }
        else if (_enemyNum == 5)
        {
            e_b_enemy5TurnSkipped = _state;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - SetEnemySkipTurnState()");
        }
    }

    /// <summary>
    /// Set the int value of S_EnemyState.e_i_frailtyStackRemainderEnemy1 || S_EnemyState.e_i_frailtyStackRemainderEnemy2 || S_EnemyState.e_i_frailtyStackRemainderEnemy3 || S_EnemyState.e_i_frailtyStackRemainderEnemy4 || S_EnemyState.e_i_frailtyStackRemainderEnemy5
    /// - Josh
    /// </summary>
    /// <param name="_stackRemainder"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyFrailtyEffectStackRemainder(int _stackRemainder, int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_i_frailtyStackRemainderEnemy1 = _stackRemainder;
        }
        else if (_enemyNum == 2)
        {
            e_i_frailtyStackRemainderEnemy2 = _stackRemainder;
        }
        else if (_enemyNum == 3)
        {
            e_i_frailtyStackRemainderEnemy3 = _stackRemainder;
        }
        else if (_enemyNum == 4)
        {
            e_i_frailtyStackRemainderEnemy4 = _stackRemainder;
        }
        else if (_enemyNum == 5)
        {
            e_i_frailtyStackRemainderEnemy5 = _stackRemainder;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - SetEnemyFrailtyEffectStackRemainder");
        }
    }

    /// <summary>
    /// Set the int value of S_EnemyState.e_i_resistantStackRemainderEnemy1 || S_EnemyState.e_i_resistantStackRemainderEnemy2 || S_EnemyState.e_i_resistantStackRemainderEnemy3 || S_EnemyState.e_i_resistantStackRemainderEnemy4 || S_EnemyState.e_i_resistantStackRemainderEnemy5
    /// - Josh
    /// </summary>
    /// <param name="_stackRemainder"></param>
    /// <param name="_enemyNum"></param>
    public void SetEnemyResistantEffectStackRemainder(int _stackRemainder, int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            e_i_resistantStackRemainderEnemy1 = _stackRemainder;
        }
        else if (_enemyNum == 2)
        {
            e_i_resistantStackRemainderEnemy2 = _stackRemainder;
        }
        else if (_enemyNum == 3)
        {
            e_i_resistantStackRemainderEnemy3 = _stackRemainder;
        }
        else if (_enemyNum == 4)
        {
            e_i_resistantStackRemainderEnemy4 = _stackRemainder;
        }
        else if (_enemyNum == 5)
        {
            e_i_resistantStackRemainderEnemy5 = _stackRemainder;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - SetEnemyResistantEffectStackRemainder()");
        }
    }

    /// <summary>
    /// Set the int value of S_EnemyState.e_i_magicianAbilityValue
    /// - Josh
    /// </summary>
    /// <param name="e_i_magicianAbilityValue"></param>
    public void SetMagicianAbilityValue(int _magicianAbilityValue) 
    {
        e_i_magicianAbilityValue += _magicianAbilityValue;
    }

    /// <summary>
    /// Set the bool state of S_EnemyState.e_b_magicianAbilityBool
    /// - Josh
    /// </summary>
    /// <param name="_state"></param>
    public void SetMagicianAbilityBool(bool _state)
    {
        e_b_magicianAbilityBool = _state;
    }

    /////////////////////////////-----------------------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    ///////////////////////////// Enemy Status Effect Stack Count Getters \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\ 
    /////////////////////////////-----------------------------------------\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

    /// <summary>
    /// Return the int value of the acidic effect stack count for a specified enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_i_acidStackCountEnemy1 || S_EnemyState.e_i_acidStackCountEnemy2 || S_EnemyState.e_i_acidStackCountEnemy3 || S_EnemyState.e_i_acidStackCountEnemy4 || S_EnemyState.e_i_acidStackCountEnemy5
    /// </returns>
    /// <param name="_enemyNum"></param>
    public int GetEnemyAcidEffectStackCount(int _enemyNum)
    {
        if(_enemyNum == 1) 
        {
            return e_i_acidStackCountEnemy1;
        }
        else if(_enemyNum == 2) 
        {
            return e_i_acidStackCountEnemy2;
        }
        else if (_enemyNum == 3)
        {
            return e_i_acidStackCountEnemy3;
        }
        else if (_enemyNum == 4)
        {
            return e_i_acidStackCountEnemy4;
        }
        else if (_enemyNum == 5)
        {
            return e_i_acidStackCountEnemy5;
        }
        else 
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - GetEnemyAcidEffectStackCount()");
            return 0;
        }
    }

    /// <summary>
    /// Return the int value of the bleeding effect stack count for a specified enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_i_bleedStackCountEnemy1 || S_EnemyState.e_i_bleedStackCountEnemy2 || S_EnemyState.e_i_bleedStackCountEnemy3 || S_EnemyState.e_i_bleedStackCountEnemy4 || S_EnemyState.e_i_bleedStackCountEnemy5
    /// </returns>
    /// <param name="_enemyNum"></param>
    public int GetEnemyBleedEffectStackCount(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_i_bleedStackCountEnemy1;
        }
        else if (_enemyNum == 2)
        {
            return e_i_bleedStackCountEnemy2;
        }
        else if (_enemyNum == 3)
        {
            return e_i_bleedStackCountEnemy3;
        }
        else if (_enemyNum == 4)
        {
            return e_i_bleedStackCountEnemy4;
        }
        else if (_enemyNum == 5)
        {
            return e_i_bleedStackCountEnemy5;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - GetEnemyBleedEffectStackCount()");
            return 0;
        }
    }

    /// <summary>
    /// Return the int value of the frailty effect stack count for a specified enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_i_frailtyStackCountEnemy1 || S_EnemyState.e_i_frailtyStackCountEnemy2 || e_i_frailtyStackCountEnemy3 || e_i_frailtyStackCountEnemy4 || S_EnemyState.e_i_frailtyStackCountEnemy5
    /// </returns>
    /// <param name="_enemyNum"></param>
    public int GetEnemyFrailtyEffectStackCount(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_i_frailtyStackCountEnemy1;
        }
        else if (_enemyNum == 2)
        {
            return e_i_frailtyStackCountEnemy2;
        }
        else if (_enemyNum == 3)
        {
            return e_i_frailtyStackCountEnemy3;
        }
        else if (_enemyNum == 4)
        {
            return e_i_frailtyStackCountEnemy4;
        }
        else if (_enemyNum == 5)
        {
            return e_i_frailtyStackCountEnemy5;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - GetEnemyFrailtyEffectStackCount()");
            return 0;
        }
    }

    /// <summary>
    /// Return the int value of the resistant effect stack count for a specified enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_i_resistantStackCountEnemy1 || S_EnemyState.e_i_resistantStackCountEnemy2 || S_EnemyState.e_i_resistantStackCountEnemy3 || S_EnemyState.e_i_resistantStackCountEnemy4 || S_EnemyState.e_i_resistantStackCountEnemy5
    /// </returns>
    /// <param name="_enemyNum"></param>
    public int GetEnemyResistantEffectStackCount(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_i_resistantStackCountEnemy1;
        }
        else if (_enemyNum == 2)
        {
            return e_i_resistantStackCountEnemy2;
        }
        else if (_enemyNum == 3)
        {
            return e_i_resistantStackCountEnemy3;
        }
        else if (_enemyNum == 4)
        {
            return e_i_resistantStackCountEnemy4;
        }
        else if (_enemyNum == 5)
        {
            return e_i_resistantStackCountEnemy5;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - GetEnemyResistantEffectStackCount()");
            return 0;
        }
    }

    /// <summary>
    /// Return the int value of the stunned effect stack count for a specified enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_i_stunStackCountEnemy1 || S_EnemyState.e_i_stunStackCountEnemy2 || S_EnemyState.e_i_stunStackCountEnemy3 || S_EnemyState.e_i_stunStackCountEnemy4 || S_EnemyState.e_i_stunStackCountEnemy5
    /// </returns>
    /// <param name="_enemyNum"></param>
    public int GetEnemyStunEffectStackCount(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_i_stunStackCountEnemy1;
        }
        else if (_enemyNum == 2)
        {
            return e_i_stunStackCountEnemy2;
        }
        else if (_enemyNum == 3)
        {
            return e_i_stunStackCountEnemy3;
        }
        else if (_enemyNum == 4)
        {
            return e_i_stunStackCountEnemy4;
        }
        else if (_enemyNum == 5)
        {
            return e_i_stunStackCountEnemy5;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - GetEnemyStunEffectStackCount()");
            return 0;
        }
    }

    /// <summary>
    /// Return the bool state of whether stun is active for a specified enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_b_enemy1TurnSkipped || S_EnemyState.e_b_enemy2TurnSkipped || S_EnemyState.e_b_enemy3TurnSkipped || S_EnemyState.e_b_enemy4TurnSkipped || S_EnemyState.e_b_enemy5TurnSkipped
    /// </returns>
    /// <param name="_enemyNum"></param>
    public bool GetEnemySkipTurnState(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_b_enemy1TurnSkipped;
        }
        else if (_enemyNum == 2)
        {
            return e_b_enemy2TurnSkipped;
        }
        else if (_enemyNum == 3)
        {
            return e_b_enemy3TurnSkipped;
        }
        else if (_enemyNum == 4)
        {
            return e_b_enemy4TurnSkipped;
        }
        else if (_enemyNum == 5)
        {
            return e_b_enemy5TurnSkipped;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - GetEnemySkipTurn()");
            return false;
        }
    }

    /// <summary>
    /// Return the bool state of whether acid effect is active for a specified enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_b_inAcidicStateEnemy1 || S_EnemyState.e_b_inAcidicStateEnemy2 || S_EnemyState.e_b_inAcidicStateEnemy3 || S_EnemyState.e_b_inAcidicStateEnemy4 || S_EnemyState.e_b_inAcidicStateEnemy5
    /// </returns>
    /// <param name="_enemyNum"></param>
    public bool GetEnemyAcidEffectState(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_b_inAcidicStateEnemy1;
        }
        else if (_enemyNum == 2)
        {
            return e_b_inAcidicStateEnemy2;
        }
        else if (_enemyNum == 3)
        {
            return e_b_inAcidicStateEnemy3;
        }
        else if (_enemyNum == 4)
        {
            return e_b_inAcidicStateEnemy4;
        }
        else if (_enemyNum == 5)
        {
            return e_b_inAcidicStateEnemy5;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - GetEnemyAcidEffectState()");
            return false;
        }
    }

    /// <summary>
    /// Return the bool state of whether bleed effect is active for a specified enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_b_inBleedStateEnemy1 || S_EnemyState.e_b_inBleedStateEnemy2 || S_EnemyState.e_b_inBleedStateEnemy3 || S_EnemyState.e_b_inBleedStateEnemy4 || S_EnemyState.e_b_inBleedStateEnemy5
    /// </returns>
    /// <param name="_enemyNum"></param>
    public bool GetEnemyBleedEffectState(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_b_inBleedStateEnemy1;
        }
        else if (_enemyNum == 2)
        {
            return e_b_inBleedStateEnemy2;
        }
        else if (_enemyNum == 3)
        {
            return e_b_inBleedStateEnemy3;
        }
        else if (_enemyNum == 4)
        {
            return e_b_inBleedStateEnemy4;
        }
        else if (_enemyNum == 5)
        {
            return e_b_inBleedStateEnemy5;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - GetEnemyBleedEffectState()");
            return false;
        }
    }

    /// <summary>
    /// Return the bool state of whether Frailitize effect is active for a specified enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_b_inFralitizedStateEnemy1 || S_EnemyState.e_b_inFralitizedStateEnemy2 || S_EnemyState.e_b_inFralitizedStateEnemy3 || S_EnemyState.e_b_inFralitizedStateEnemy4 || S_EnemyState.e_b_inFralitizedStateEnemy5
    /// </returns>
    /// <param name="_enemyNum"></param>
    public bool GetEnemyFrailtyEffectState(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_b_inFralitizedStateEnemy1;
        }
        else if (_enemyNum == 2)
        {
            return e_b_inFralitizedStateEnemy2;
        }
        else if (_enemyNum == 3)
        {
            return e_b_inFralitizedStateEnemy3;
        }
        else if (_enemyNum == 4)
        {
            return e_b_inFralitizedStateEnemy4;
        }
        else if (_enemyNum == 5)
        {
            return e_b_inFralitizedStateEnemy5;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - GetEnemyFrailtyEffectState()");
            return false;
        }
    }

    /// <summary>
    /// Return the bool state of whether resistant effect is active for a specified enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_b_inResistantStateEnemy1 || S_EnemyState.e_b_inResistantStateEnemy2 || S_EnemyState.e_b_inResistantStateEnemy3 || S_EnemyState.e_b_inResistantStateEnemy4 || S_EnemyState.e_b_inResistantStateEnemy5
    /// </returns>
    /// <param name="_enemyNum"></param>
    public bool GetEnemyResistantEffectState(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_b_inResistantStateEnemy1;
        }
        else if (_enemyNum == 2)
        {
            return e_b_inResistantStateEnemy2;
        }
        else if (_enemyNum == 3)
        {
            return e_b_inResistantStateEnemy3;
        }
        else if (_enemyNum == 4)
        {
            return e_b_inResistantStateEnemy4;
        }
        else if (_enemyNum == 5)
        {
            return e_b_inResistantStateEnemy5;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - GetEnemyResistantEffectState()");
            return false;
        }
    }

    /// <summary>
    /// Return the bool state of whether stunned effect is active for a specified enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_b_inStunStateEnemy1 || S_EnemyState.e_b_inStunStateEnemy2 || S_EnemyState.e_b_inStunStateEnemy3 || S_EnemyState.e_b_inStunStateEnemy4 || S_EnemyState.e_b_inStunStateEnemy5
    /// </returns>
    /// <param name="_enemyNum"></param>
    public bool GetEnemyStunEffectState(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_b_inStunStateEnemy1;
        }
        else if (_enemyNum == 2)
        {
            return e_b_inStunStateEnemy2;
        }
        else if (_enemyNum == 3)
        {
            return e_b_inStunStateEnemy3;
        }
        else if (_enemyNum == 4)
        {
            return e_b_inStunStateEnemy4;
        }
        else if (_enemyNum == 5)
        {
            return e_b_inStunStateEnemy5;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - GetEnemyStunnedEffectState()");
            return false;
        }
    }

    /// <summary>
    /// Return the int value of the frailty effect stack count remainder for a specified enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_i_frailtyStackRemainderEnemy1 || S_EnemyState.e_i_frailtyStackRemainderEnemy2 || S_EnemyState.e_i_frailtyStackRemainderEnemy3 || S_EnemyState.e_i_frailtyStackRemainderEnemy4 || S_EnemyState.e_i_frailtyStackRemainderEnemy5
    /// </returns>
    /// <param name="_enemyNum"></param>
    public int GetEnemyFrailtyEffectStackRemainder(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_i_frailtyStackRemainderEnemy1;
        }
        else if (_enemyNum == 2)
        {
            return e_i_frailtyStackRemainderEnemy2;
        }
        else if (_enemyNum == 3)
        {
            return e_i_frailtyStackRemainderEnemy3;
        }
        else if (_enemyNum == 4)
        {
            return e_i_frailtyStackRemainderEnemy4;
        }
        else if (_enemyNum == 5)
        {
            return e_i_frailtyStackRemainderEnemy5;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - GetEnemyFrailtyEffectStackRemainder");
            return 0;
        }
    }

    /// <summary>
    /// Return the int value of the resistant effect stack count remainder for a specified enemy
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_i_resistantStackRemainderEnemy1 || S_EnemyState.e_i_resistantStackRemainderEnemy2 || S_EnemyState.e_i_resistantStackRemainderEnemy3 || S_EnemyState.e_i_resistantStackRemainderEnemy4 || S_EnemyState.e_i_resistantStackRemainderEnemy5
    /// </returns>
    /// <param name="_enemyNum"></param>
    public int GetEnemyResistantEffectStackRemainder(int _enemyNum)
    {
        if (_enemyNum == 1)
        {
            return e_i_resistantStackRemainderEnemy1;
        }
        else if (_enemyNum == 2)
        {
            return e_i_resistantStackRemainderEnemy2;
        }
        else if (_enemyNum == 3)
        {
            return e_i_resistantStackRemainderEnemy3;
        }
        else if (_enemyNum == 4)
        {
            return e_i_resistantStackRemainderEnemy4;
        }
        else if (_enemyNum == 5)
        {
            return e_i_resistantStackRemainderEnemy5;
        }
        else
        {
            Debug.Log("DEBUG: FAILED FUNCTION - S_EnemyState - GetEnemyResistantEffectStackRemainder()");
            return 0;
        }
    }

    /// <summary>
    /// Get the int value of S_EnemyState.e_i_magicianAbilityValue
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_i_magicianAbilityValue
    /// </returns>
    public int GetMagicianAbilityValue()
    {
        return e_i_magicianAbilityValue;
    }

    /// <summary>
    /// Get the bool state of S_EnemyState.e_b_magicianAbilityBool
    /// - Josh
    /// </summary>
    /// <returns>
    /// S_EnemyState.e_b_magicianAbilityBool
    /// </returns>
    public bool GetMagicianAbilityBool()
    {
        return e_b_magicianAbilityBool;
    }
}
