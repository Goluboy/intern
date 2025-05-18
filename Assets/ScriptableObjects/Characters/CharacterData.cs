using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Character", menuName = "DialogGame/Character")]
public class CharacterData : ScriptableObject
{
    [Header("Basic Info")]
    public string characterId;           // Unique identifier for the character
    public string characterName;         // Display name
    public string title;                 // Optional title/role

    [TextArea(3, 5)]
    public string description;           // Character description/backstory

    [Header("Visual Elements")]
    public Sprite defaultPortrait;       // Default character portrait
    public List<CharacterExpression> expressions = new List<CharacterExpression>();

    [Header("Voice & Sound")]
    public AudioClip voiceClip;         // Optional voice sample for character
    [Range(0.8f, 1.2f)]
    public float voicePitch = 1f;       // Pitch modifier for text sounds

    [Header("Relationship Settings")]
    public float initialRelationship;    // Starting relationship value
    public float minRelationship = -100f;
    public float maxRelationship = 100f;

    [Header("Dialog Styling")]
    public Color nameColor = Color.white;
    public Color dialogTextColor = Color.white;
    [TextArea(2, 3)]
    public string dialoguePrefix = "";    // Optional text to prefix character's dialogs
}

[Serializable]
public class CharacterExpression
{
    public string expressionName;        // Name/ID of the expression
    public Sprite portraitSprite;        // The actual expression sprite
    public AnimationClip transitionAnimation; // Optional animation for transitioning to this expression

    [Header("Expression Triggers")]
    public bool shakePortrait;           // Should portrait shake when showing this expression
    public bool flashPortrait;           // Should portrait flash when showing this expression

    [Header("Sound Effect")]
    public AudioClip expressionSFX;      // Sound effect for this expression
}