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

    public int EnergyCost;
    public int EffectValue;
    public float CardRarity;
    
    [Header("Number of Characters Affected")]
    public bool AffectsPlayer;
    public bool Affects1Character;
    public bool AffectsAllOtherCharacters;

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

    [Header("Potential Status Effect Values")]
    public int DamagePercentage; 
    public int TurnCount;

    [Header("If Unique, toggle what Unique card it is.")]
    public bool Payback;

    [Header("Extra Info")]
    public string ExtraInfo;
}
