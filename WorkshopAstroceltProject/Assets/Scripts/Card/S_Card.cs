using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Card : MonoBehaviour
{
    [Header("Card Basics")]
    public string c_str_cardName;
    public string c_str_flavorText;

    public int c_i_cardRarity;
    public int c_i_attackVal;

    public GameObject cardArtAssetObj;

    [Header("Color Types")]
    public bool c_b_redColorType;
    public bool c_b_blueColorType;
    public bool c_b_greenColorType;
    public bool c_b_colorlessType;

    [Header("Effect Types")]
    public bool c_b_damageEffectType;
    public bool c_b_healEffectType;
    public bool c_b_shieldEffectType;

    [Header("Status Effect Triggers")]
    public bool c_b_bleedStatusEffectType;
    public bool c_b_poisonStatusEffectType;

    private void Awake()
    {
        c_b_damageEffectType = false;
        c_b_healEffectType = false;
        c_b_shieldEffectType = false;

        c_b_redColorType = false;
        c_b_blueColorType = false;
        c_b_greenColorType = false;
        c_b_colorlessType = false;

        c_b_bleedStatusEffectType = false;
        c_b_poisonStatusEffectType = false;
    }
}
