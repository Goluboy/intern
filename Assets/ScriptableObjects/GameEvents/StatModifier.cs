using UnityEngine;
using System;

[Serializable]
public class StatModifier
{
    public StatType statType;     // Type of stat being modified
    public float value;           // Amount to modify the stat by
    public string characterId;    // Used only for relationship modifications

    [Tooltip("Optional description of what caused this modification")]
    public string description;    // For debugging/UI feedback
}

// Enum defining all possible stat types that can be modified
public enum StatType
{
    Reputation,     // Player's general popularity
    Trust,          // Player's trust level
    Solidarity,   // Relationship with a specific character
}