using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card Template")]
public class S_CardTemplate : ScriptableObject
{
    [Header("Card Basics")]
    public string CardName;
    public string FlavorText;

    public int EnergyCost;
    public int EffectValue;
    public float CardRarity;

    [Header("Number of Characters Affected")]
    public bool AffectsSelf;
    public bool Affects1Character;
    public bool Affects2Characters; 
    
    [Header("Art (subject to change)")]
    public GameObject CardArtAssetPrefab;

    [Header("Toggle Color Types")]
    public bool RedColorType;
    public bool BlueColorType;
    public bool GreenColorType;
    public bool WhiteColorType; 

    [Header("Main Effect Types")]
    public bool DamageEffectType;
    public bool HealEffectType;
    public bool ShieldEffectType;
    public bool UniqueEffectType;

    [Header("Status Effect Types")]
    public bool NoEffect; 
    public bool BleedingStatusEffect;
    public bool StunStatusEffect;
    public bool PoisonStatusEffect;
    public bool EmpoweredStatusEffect;
    public bool LuckyStatusEffect;
    public bool RestrainStatusEffect;
    public bool BurnStatusEffect;
    public bool ShockStatusEffect; 

    [Header("Bleeding Status Effect Variables")]
    public int DamagePercentagePerTurn; //40% of the card's
    public int TurnCount; 

    [Header("Poison Status Effect Variables")]
}
