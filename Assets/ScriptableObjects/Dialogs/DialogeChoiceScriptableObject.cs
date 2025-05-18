using UnityEngine;

[CreateAssetMenu(fileName = "DialogChoice", menuName = "DialogGame/DialogChoice")]
public class DialogeChoiceScriptableObject : ScriptableObject
{
    [SerializeField] private string _choiceText;            
    [SerializeField] private string _nextDialogId;
    [SerializeField] private StatModifier[] _statModifiers;
    [SerializeField] private bool _isEndGame;
    [SerializeField] private string _endGameDescription;

    public bool IsEndGame => _isEndGame;
    public string EndGameDescription => _endGameDescription;
    public string ChoiceText => _choiceText;
    public string NextDialogId => _nextDialogId;
    public StatModifier[] StatModifiers => _statModifiers;
}