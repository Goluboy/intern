using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Linq;

public class UIManager : MonoBehaviour
{
    [SerializeField] private DialogBox _dialogBox;
    [SerializeField] private TextMeshProUGUI _reputation;
    [SerializeField] private TextMeshProUGUI _solidarity;
    [SerializeField] private TextMeshProUGUI _trust;

    public void ShowDialog(DialogeData dialog)
    {
        StartCoroutine(TransitionDialog(dialog));
    }

    public void UpdateStats(PlayerStats playerStats)
    {
        _reputation.text = playerStats.Reputation.ToString();
        _trust.text = playerStats.Trust.ToString();
        _solidarity.text = playerStats.Solidarity.ToString();
    }

    private IEnumerator TransitionDialog(DialogeData dialog)
    {
        // Fade out current dialog
        yield return _dialogBox.FadeOut();

        // Update content
        _dialogBox.SetText(dialog);
        //dialogBox.CharacterPortrait.SetCharacter(dialog.Speaker);

        // Fade in new dialog
        yield return _dialogBox.FadeIn();
    }
}