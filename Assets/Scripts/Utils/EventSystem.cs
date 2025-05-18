using UnityEngine;
using UnityEngine.Events;

public class EventSystem
{
    public static UnityEvent<ChoiceSide, DialogeChoiceScriptableObject> OnChoiceMade = new UnityEvent<ChoiceSide, DialogeChoiceScriptableObject>();
    public static UnityEvent<string> OnLose = new UnityEvent<string>();

    public static void SendChoiceMade(ChoiceSide choiceSide, DialogeChoiceScriptableObject dialogChoiceScriptableObject)
    {
        if (dialogChoiceScriptableObject.IsEndGame)
        {
            SendLose(dialogChoiceScriptableObject.EndGameDescription);
            return;
        }
        OnChoiceMade.Invoke(choiceSide, dialogChoiceScriptableObject);
    }

    public static void SendLose(string message)
    {
        OnLose.Invoke(message);
    }
}
