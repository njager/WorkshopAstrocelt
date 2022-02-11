using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card Template")]
public class S_CardTemplate : ScriptableObject
{
    [Header("Card Basics")]
    public string CardName;
    public string FlavorText;

    public int CardRarity; 
    public int AttackVal;

    public GameObject cardArtAssetPrefab;

    [Header("Toggle Color Types")]
    public bool RedColorType;
    public bool BlueColorType;
    public bool GreenColorType;
    public bool ColorlessType; 

    [Header("Effect Types")]
    public bool DamageEffectType;
    public bool HealEffectType;
    public bool ShieldEffectType;

    [Header("Status Effect Triggers")]
    public bool c_b_bleedStatusEffectType;
    public bool c_b_poisonStatusEffectType;
}
