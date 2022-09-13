using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class S_CardDatabase : MonoBehaviour
{
    //Ask will how to iterate objects into a list
    private S_Global g_global;

    [Header("Vertical Slice Deck")]
    public S_CardTemplate cardScript0; // Barkskin, ID 0
    public S_CardTemplate cardScript1; // Bludgeon, ID 1
    public S_CardTemplate cardScript2; // Deflect, ID 2
    public S_CardTemplate cardScript3; // Dig In, ID 3
    public S_CardTemplate cardScript4; // Flair, ID 4
    public S_CardTemplate cardScript5; // Fortify, ID 5
    public S_CardTemplate cardScript6; // Lacerate, ID 6
    public S_CardTemplate cardScript7; // Preserve, ID 7
    public S_CardTemplate cardScript8; // Demoralize, ID 8 // Previously reposte
    public S_CardTemplate cardScript9; // Stone Strike, ID 9
    public S_CardTemplate cardScript10; // Fury, ID 10
    public S_CardTemplate cardScript11; // Thornshield, ID 11
    public S_CardTemplate cardScript12; // Freeze, ID 12
    public S_CardTemplate cardScript13; // Refelect, ID 13
    public S_CardTemplate cardScript14; // Agonizing Spirit, ID 14
    public S_CardTemplate cardScript15; // Ambush, ID 15
    public S_CardTemplate cardScript16; // Zealous Storm, ID 16  
    public S_CardTemplate cardScript17; // Barkskin, ID 17
    public S_CardTemplate cardScript18; // Bolster, ID 18
    public S_CardTemplate cardScript19; // Fervoured, ID 19
    public S_CardTemplate cardScript20; // Impair, ID 20
    public S_CardTemplate cardScript21; // Earthy Bastion, ID 21
    public S_CardTemplate cardScript22; // Pierce, ID 22
    public S_CardTemplate cardScript23; // Protect, ID 23
    public S_CardTemplate cardScript24; // Shielded, ID 24
    public S_CardTemplate cardScript25; // Wall of Wonder, ID 25
    public S_CardTemplate cardScript26; // Windbreaker, ID 26

    [Header("Battle 1 Rewards")]
    public S_CardTemplate battleRewardCard1; // Fury, ID 10
    public S_CardTemplate battleRewardCard2; // Thornshield, ID 11

    [Header("Battle 2 Rewards")]
    public S_CardTemplate battleRewardCard3; // Freeze, ID 12
    public S_CardTemplate battleRewardCard4; // Reflect, ID 13

    [Header("Reward Card Bools for Scene Toggle")]
    public bool encounter2;
    public bool encounter3;

    public Dictionary<int, S_CardTemplate> dict_CardDatabase = new Dictionary<int, S_CardTemplate>();

    void Awake()
    {
        g_global = S_Global.Instance;

        // Add initial cards to dictionary
        dict_CardDatabase.Add(0, cardScript0); // Barkskin
        dict_CardDatabase.Add(1, cardScript1); // Bludgeon
        dict_CardDatabase.Add(2, cardScript2); // Deflect
        dict_CardDatabase.Add(3, cardScript3); // Dig In
        dict_CardDatabase.Add(4, cardScript4); // Flair
        dict_CardDatabase.Add(5, cardScript5); // Fortifiy
        dict_CardDatabase.Add(6, cardScript6); // Lacerate
        dict_CardDatabase.Add(7, cardScript7); // Preserve
        dict_CardDatabase.Add(8, cardScript8); // Demoralize
        dict_CardDatabase.Add(9, cardScript9); // Stone Strike
        dict_CardDatabase.Add(10, cardScript10); // Fury
        dict_CardDatabase.Add(11, cardScript11); // Thornshield
        dict_CardDatabase.Add(12, cardScript12); // Freeze
        dict_CardDatabase.Add(13, cardScript13); // Reflect
        dict_CardDatabase.Add(14, cardScript14); // Agonizing
        dict_CardDatabase.Add(15, cardScript15); // Ambush
        dict_CardDatabase.Add(16, cardScript16); // Zealous Storm
        dict_CardDatabase.Add(17, cardScript17); //Barkskin
        dict_CardDatabase.Add(18, cardScript18); // Bolster
        dict_CardDatabase.Add(19, cardScript19); // Fervoured
        dict_CardDatabase.Add(20, cardScript20); // Impair
        dict_CardDatabase.Add(21, cardScript21); // Earthy Bastion
        dict_CardDatabase.Add(22, cardScript22); // Pierce
        dict_CardDatabase.Add(23, cardScript23); // Protect
        dict_CardDatabase.Add(24, cardScript24); // Shielded
        dict_CardDatabase.Add(25, cardScript25); // Wall of Wonder
        dict_CardDatabase.Add(26, cardScript26); // Windbreaker

    }

    /// <summary>
    /// Function will return the game object when given an indice
    /// -Josh
    /// </summary>
    /// <param name="_index"></param>
    /// <returns></returns>
    public S_CardTemplate GetCard(int _index)
    {
        S_CardTemplate _returnCard = dict_CardDatabase[_index];
        return _returnCard;
    }
}
