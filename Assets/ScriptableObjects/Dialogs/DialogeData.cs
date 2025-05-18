using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Dialog", menuName = "DialogGame/Dialog")]
public class DialogeData : ScriptableObject
{
    [SerializeField] private string _dialogId;
    //[SerializeField] private CharacterData _speaker;
    [SerializeField] private string _dialogText;
    [SerializeField] private List<DialogeChoiceScriptableObject> _choices;
    [SerializeField] private DialogRequirements _requirements;
    [SerializeField] private string _commentary;

    public string DialogId => _dialogId;
    public string Commentary => _commentary;
    //public CharacterData Speaker => _speaker;
    public string DialogeText => _dialogText;
    public List<DialogeChoiceScriptableObject> Choices => _choices;
    public DialogRequirements Requirements => _requirements;
    
    public bool IsCompleted { get; set; } = false;

    [Serializable]
    public class DialogRequirements
    {
        public float minReputation;
        public Dictionary<string, float> characterRelationshipRequirements;
        public DialogeChoiceScriptableObject[] requiredPreviousDialogeChoise;
    }
}