using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DialogeManager : MonoBehaviour
{
    [SerializeField] private List<DialogeData> allDialogs;

    public DialogeData CurrentDialogeData { get; private set; }
    public Dictionary<DialogeData, DialogeChoiceScriptableObject> CompletedDialogs { get; private set; } = new();

    public DialogeData GetNextDialog(ChoiceSide choiceType, PlayerStats currentStats)
    {
        if (CurrentDialogeData == null)
        {
            CurrentDialogeData = allDialogs
                .OrderBy(x => x.DialogId)
                .FirstOrDefault();
            CurrentDialogeData.IsCompleted = false;
            return CurrentDialogeData;
        }
        CompletedDialogs.Add(CurrentDialogeData, CurrentDialogeData.Choices[(int)choiceType]);

        if (CompletedDialogs[CurrentDialogeData].NextDialogId != default)
        {
            CurrentDialogeData = allDialogs
                .Where(x => x.DialogId == CompletedDialogs[CurrentDialogeData].NextDialogId)
                .FirstOrDefault();
            CurrentDialogeData.IsCompleted = false;
            return CurrentDialogeData;
        }

        var availableDialogs = allDialogs.Where(dialog =>
            IsDialogAvailable(dialog, CompletedDialogs, currentStats)).ToList();

        if (availableDialogs.Count > 0)
        {
            CurrentDialogeData = availableDialogs[Random.Range(0, availableDialogs.Count)];
            CurrentDialogeData.IsCompleted = false;
            CurrentDialogeData.IsCompleted = false;
            return CurrentDialogeData;
        }

        return null;
    }

    private bool IsDialogAvailable(DialogeData dialog, Dictionary<DialogeData, DialogeChoiceScriptableObject> completedDialogs, PlayerStats stats)
    {
        var requirements = dialog.Requirements;

        // Check basic stats requirements
        if (stats.Reputation < requirements.minReputation)
        {
            return false;
        }

        // Check required previous dialogs
        foreach (var requiredDialogChoise in requirements.requiredPreviousDialogeChoise)
        {
            if (completedDialogs.Values.Where(x => x == requiredDialogChoise).FirstOrDefault() == null)
            {
                return false;
            }
        }

        return true;
    }
}