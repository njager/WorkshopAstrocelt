using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VectorGraphics;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class S_CharacterCardInterface : MonoBehaviour, IDropHandler
{
    private S_Card c_cardData;
    private S_Global g_global;

    [Header("Enemy Reference")]
    public S_Enemy e_attachedEnemy;

    [Header("Bools")]
    public bool p_b_attachedToPlayer;
    public bool e_b_attachedToEnemy; 

    void Awake()
    {
        g_global = S_Global.Instance;
    }

    void Start()
    {
        if(tag == "Player") // If on player, set bools accordingly
        {
            p_b_attachedToPlayer = true;
            e_b_attachedToEnemy = false;
        }
        if(tag == "Enemy") // If on an enemy, set bools accordingly
        {
            p_b_attachedToPlayer = false;
            e_b_attachedToEnemy = true;
        }
    }

    /// <summary>
    /// The recipricating event for OnDragEnd,
    /// this is a built-in event handler that will automatically respond to an object ending it's drag on the collision
    /// Used in conjunction with S_CardDragger
    /// </summary>
    /// <param name="_eventData"></param>
    public void OnDrop(PointerEventData _eventData)
    {
        Debug.Log("Trying to Play the card");

        if (_eventData.pointerDrag != null)
        {
            c_cardData = _eventData.pointerDrag.GetComponent<S_Card>();

            print("Made it to player v enemy");
            if (p_b_attachedToPlayer == true) //check to see if this object is the player
            {
                if (c_cardData.c_b_affectsPlayer == true) //check to see if it affects player
                {
                    if (c_cardData.c_b_shieldMainEffect == true) //check to see if it's a shield card
                    {
                        print("Card played?");
                        //play the card
                        c_cardData.PlayCard(g_global.g_player.gameObject);
                    }
                    else
                    {
                        Debug.Log("Wrong effect type!");
                        c_cardData.ResetPosition();
                        return;
                    }
                }
                else
                {
                    Debug.Log("Card Cannot affect player!");
                    c_cardData.ResetPosition();
                    return;
                }
            }
            else if (e_b_attachedToEnemy == true) // I like to make bool checks clear in what they are checking, but could be optimized
            {
                print("Affecting Enemy");
                if (c_cardData.c_b_affectsOne == true) //check to see if it affects enemy
                {
                    if (c_cardData.c_b_attackMainEffect == true) //check to see if it's an attack card
                    {
                        if (e_attachedEnemy == g_global.g_enemyState.enemy1)
                        {
                            c_cardData.PlayCard(g_global.g_enemyState.enemy1.gameObject);
                        }
                        else if (e_attachedEnemy == g_global.g_enemyState.enemy2)
                        {
                            c_cardData.PlayCard(g_global.g_enemyState.enemy2.gameObject);
                        }
                        else if (e_attachedEnemy == g_global.g_enemyState.enemy3)
                        {
                            c_cardData.PlayCard(g_global.g_enemyState.enemy3.gameObject);
                        }
                        else if (e_attachedEnemy == g_global.g_enemyState.enemy4)
                        {
                            c_cardData.PlayCard(g_global.g_enemyState.enemy4.gameObject);
                        }
                        else if (e_attachedEnemy == g_global.g_enemyState.enemy5)
                        {
                            c_cardData.PlayCard(g_global.g_enemyState.enemy5.gameObject);
                        }
                    }
                    else
                    {
                        Debug.Log("Not an attack card");
                        c_cardData.ResetPosition();
                        return;
                    }
                }
                else if (c_cardData.c_b_affectsAllEnemies == true) // Activate on all enemies
                {
                    if (c_cardData.c_b_attackMainEffect == true) //check to see if it's an attack card
                    {
                        if (g_global.g_enemyAttributeSheet1 != null) // Activate on all enemies then
                        {
                            if (g_global.g_enemyState.e_b_enemy1Dead == false)
                            {
                                c_cardData.PlayCard(g_global.g_enemyState.enemy1.gameObject);
                            }
                            else
                            {
                                Debug.Log("Enemy is already Dead");
                                c_cardData.ResetPosition();
                                return;
                            }
                        }
                        if (g_global.g_enemyAttributeSheet2 != null) // enemy 2
                        {
                            if (g_global.g_enemyState.e_b_enemy2Dead == false)
                            {
                                c_cardData.PlayCard(g_global.g_enemyState.enemy2.gameObject);
                            }
                            else
                            {
                                Debug.Log("Enemy is already Dead");
                                c_cardData.ResetPosition();
                                return;
                            }
                        }
                        if (g_global.g_enemyAttributeSheet3 != null) // Enemy 3
                        {
                            if (g_global.g_enemyState.e_b_enemy3Dead == false)
                            {
                                c_cardData.PlayCard(g_global.g_enemyState.enemy3.gameObject);
                            }
                            else
                            {
                                Debug.Log("Enemy is already Dead");
                                c_cardData.ResetPosition();
                                return;
                            }
                        }
                        if (g_global.g_enemyAttributeSheet4 != null) // Enemy 4
                        {
                            if (g_global.g_enemyState.e_b_enemy4Dead == false)
                            {
                                c_cardData.PlayCard(g_global.g_enemyState.enemy4.gameObject);
                            }
                            else
                            {
                                Debug.Log("Enemy is already Dead");
                                c_cardData.ResetPosition();
                                return;
                            }
                        }
                        if (g_global.g_enemyAttributeSheet5 != null) // Enemy 5
                        {
                            if (g_global.g_enemyState.e_b_enemy5Dead == false)
                            {
                                c_cardData.PlayCard(g_global.g_enemyState.enemy5.gameObject);
                            }
                            else
                            {
                                Debug.Log("Enemy is already Dead");
                                c_cardData.ResetPosition();
                                return;
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("not a main attack for all");
                        c_cardData.ResetPosition();
                        return;
                    }
                }
                else
                {
                    Debug.Log("Doesn't effect one, doesn't effect all");
                    c_cardData.ResetPosition();
                    return;
                }
            }
            else
            {
                Debug.Log("Wrong Character Type!");
                c_cardData.ResetPosition();
                return;
            }

        }
        else
        {
            Debug.Log("Pointer Event Data is Null");
            c_cardData.ResetPosition();
            return;
        }
    }
}
