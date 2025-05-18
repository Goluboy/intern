using UnityEngine;
using System.Collections.Generic;
using System;

public class StatsManager : MonoBehaviour
{
    public PlayerStats CurrentStats { get; private set; }

    private UIManager _uiManager;

    private void Awake()
    {
        _uiManager = GetComponent<UIManager>();
        CurrentStats = GetComponent<PlayerStats>();
    }

    public void ApplyStatModifiers(StatModifier[] modifiers)
    {
        foreach (var modifier in modifiers)
        {
            switch (modifier.statType)
            {
                case StatType.Reputation:
                    CurrentStats.ModifyReputation(modifier.value);
                    break;
                case StatType.Solidarity:
                    CurrentStats.ModifySolidarity(modifier.value);
                    break;
                case StatType.Trust:
                    CurrentStats.ModifyTrust(modifier.value);
                    break;
            }
        }

        UpdateUI();
    }

    public void UpdateUI()
    {
        _uiManager.UpdateStats(CurrentStats);
    }
}