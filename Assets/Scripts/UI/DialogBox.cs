using System;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private TextMeshProUGUI _leftText;
    [SerializeField] private TextMeshProUGUI _rightText;
    [SerializeField] private TextMeshProUGUI _Commentary;

    private CharacterPortrait CharacterPortrait;

    private void Awake()
    {
        EventSystem.OnLose.AddListener(OnLose);
        CharacterPortrait = GetComponentInChildren<CharacterPortrait>();
    }

    private void OnLose(string arg0)
    {
        CharacterPortrait.GetComponent<BoxCollider2D>().enabled = false;
    }

    public void SetText(DialogeData dialog)
    {
        _dialogText.text = dialog.DialogeText;
        _leftText.text = dialog.Choices[0].ChoiceText;
        _rightText.text = dialog.Choices[1].ChoiceText;
        _Commentary.text = dialog.Commentary;
    }
    public object FadeOut()
    {
        CharacterPortrait.FadeOut();
        return 1;
    }

    public object FadeIn()
    {
        CharacterPortrait.FadeIn();
        return 1;
    }
}
