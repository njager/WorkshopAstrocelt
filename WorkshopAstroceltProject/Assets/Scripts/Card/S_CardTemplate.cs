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

    [Header("Status Effect Stack Count")]
    public int StackCount1;
    public int StackCount2;
    public int StackCount3;

    [Header("Status Effect IDs (On Card Excel Doc)")]
    public int IDForStatusEffectOne;
    public int IDForStatusEffectTwo;
    public int IDForStatusEffectThree;

    [Header("Card Rarity Tiers")]
    public bool Common;
    public bool Uncommon;
    public bool Rare;
    public bool VeryRare;
    public bool Legendary;

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
    public bool AcidicStatusEffect;
    public bool BleedStatusEffect;
    public bool FralityStatusEffect;
    public bool ResistantStatusEffect;
    public bool StunnedStatusEffect;

    // These will probably be strings as the sound effect list grows
    [Header("Shield Sound Effect: True if Magic, false if Physical")]
    public bool PhysicalOrMagicalBoolForShield;

    [Header("Attack Sound Effect: True if Magic, false if Physical")]
    public bool PhysicalOrMagicalBoolForAttack;

    [Header("Card ID")]
    public int CardDatabaseID;

    [Header("Extra Info")]
    public string ExtraInfo;
}
