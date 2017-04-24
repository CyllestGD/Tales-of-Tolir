using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TargetingOptions{
    NoTarget,
    AllMinions, 
    EnemyMinions,
    YourMinions, 
    AllCharacters, 
    EnemyCharacters,
    YourCharacters
}

public class CardAsset : ScriptableObject {
    [Header("General info")]
    public CharacterAsset characterAsset;  // Allows the creation of neutral cards
    [TextArea(2,3)]
    public string description;  // Description text for spell/minion
	public Sprite cardImage;
    public int manaCost;

    [Header("Creature Info")]
    public int maxHealth;
    public int attack;
    public int attacksForOneTurn = 1;
    public bool block;
    public bool haste;
    public string creatureScriptName;
    public int specialCreatureAmount;

    [Header("SpellInfo")]
    public string spellScriptName;
    public int specialSpellAmount;
    public TargetingOptions targets;
}
