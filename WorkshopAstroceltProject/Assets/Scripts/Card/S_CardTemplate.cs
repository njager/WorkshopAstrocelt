using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

[CreateAssetMenu(fileName = "New Card", menuName = "Card Template")]
public class S_CardTemplate : ScriptableObject
{
    [Header("Card Basics")]
    public string CardName;
    public string HeaderText;
    public string BodyText;
    public string FlavorText;

    [Header("Color String")]
    public string ColorString;

    [Header("Energy Cost")]
    public int EnergyCost;

    [Header("Main Effect Numbers")]
    public int DamageValue;
    public int ShieldValue; 

    [Header("Status Effect Numbers")]
    public int EffectValue1;
    public int EffectValue2;
    public int EffectValue3;
    public float BleedEffectValue; 

    [Header("Turn Counts")]
    public int TurnCountForStatusEffect1;
    public int TurnCountForStatusEffect2;
    public int TurnCountForStatusEffect3;

    [Header("Status Effect IDs (On Card Excel Doc)")]
    public int IDForStatusEffectOne;
    public int IDForStatusEffectTwo;
    public int IDForStatusEffectThree;

    [Header("Card Rarity")]
    public float CardRarity;

    [Header("Primary Destinaton for Main Effect")]
    public bool AffectsNone; 
    public bool AffectsPlayer;
    public bool Affects1Character;
    public bool AffectsAllEnemies;
    public bool AffectsAllCharacters; 

    [Header("Secondary Destination for Status Effect")]
    public bool PlayerEffect;
    public bool EnemyEffect;

    [Header("Toggle Color Types")]
    public bool RedColorType;
    public bool BlueColorType;
    public bool YellowColorType;
    public bool WhiteColorType; 

    [Header("Main Effect Types")]
    public bool AttackEffect;
    public bool ShieldEffect;
    public bool UniqueEffect;

    [Header("Status Effect Types")]
    public bool NoEffect; 
    public bool BleedStatusEffect;
    public bool AcidStatusEffect;
    public bool BurnStatusEffect;
    public bool ResistStatusEffect;
    public bool SiphonStatusEffect;
    public bool StunStatusEffect;
    public bool DrawStatusEffect;
    public bool FralityStatusEffect;
    public bool ManipulateStatusEffect;
    public bool ThornStatusEffect; 

    [Header("Extra Info")]
    public string ExtraInfo;
}
