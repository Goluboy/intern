using UnityEngine;
using System;
using System.Collections.Generic;
using static DialogeData;
using System.Linq;

[Serializable]
public class PlayerStats : MonoBehaviour
{
    // Core stats
    public float Reputation { get; private set; } = DEFAULT_REPUTATION_VALUE;
    public float Trust { get; private set; } = DEFAULT_VALUE;
    public float Solidarity { get; private set; } = DEFAULT_VALUE;

    // Track unlocked dialog paths and completed dialogs
    private HashSet<string> _unlockedDialogPaths = new HashSet<string>();
    private DialogeManager _dialogeManager;
    private StatsManager _statsManager;

    // Constants for stat limits
    private const float MIN_STAT_VALUE = 0f;
    private const float MAX_STAT_VALUE = 100f;
    private const float DEFAULT_VALUE = 50f;
    private const float DEFAULT_REPUTATION_VALUE = 10f;

    private void Awake()
    {
        // Initialize the dialog manager
        _statsManager = GetComponent<StatsManager>();
        _dialogeManager = GetComponent<DialogeManager>();
        EventSystem.OnChoiceMade.AddListener(OnChoiceMade);
    }

    private void OnChoiceMade(ChoiceSide choiceSide, DialogeChoiceScriptableObject dialogeChoiceScriptableObject)
    {

        _statsManager.UpdateUI();
    }

    // Methods for managing core stats
    public void ModifyReputation(float amount)
    {
        Reputation = Mathf.Clamp(Reputation + amount, MIN_STAT_VALUE, MAX_STAT_VALUE);
    }

    public void ModifyTrust(float amount)
    {
        Trust = Mathf.Clamp(Trust + amount, MIN_STAT_VALUE, MAX_STAT_VALUE);
    }
    public void ModifySolidarity(float amount)
    {
        Solidarity = Mathf.Clamp(Solidarity + amount, MIN_STAT_VALUE, MAX_STAT_VALUE);
    }

    public void UnlockDialogPath(string path)
    {
        _unlockedDialogPaths.Add(path);
    }

    public bool IsDialogPathUnlocked(string path)
    {
        return _unlockedDialogPaths.Contains(path);
    }

    // Method to check if the player meets specific requirements
    public bool MeetsRequirements(DialogRequirements requirements)
    {
        if (requirements == null) return true;

        if (Reputation < requirements.minReputation) return false;


        // Check required previous dialogs
        foreach (var requiredDialogOption in requirements.requiredPreviousDialogeChoise)
        {
            if (!_dialogeManager.CompletedDialogs.Values.Contains(requiredDialogOption))
                return false;
        }

        return true;
    }
}

// Class to handle stat change notifications
public class StatChangeEvent
{
    public StatType Type { get; private set; }
    public float OldValue { get; private set; }
    public float NewValue { get; private set; }
    public string CharacterId { get; private set; } // Only for relationship changes

    public StatChangeEvent(StatType type, float oldValue, float newValue, string characterId = null)
    {
        Type = type;
        OldValue = oldValue;
        NewValue = newValue;
        CharacterId = characterId;
    }
}