using UnityEngine;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Image _losePanel;

    public static GameManager Instance { get; private set; }

    private DialogeManager _dialogeManager;
    private StatsManager _statsManager;
    private UIManager _uiManager;

    private void Awake()
    {
        EventSystem.OnChoiceMade.AddListener(OnChoiseMade);
        EventSystem.OnLose.AddListener(OnLose);

        _dialogeManager = GetComponent<DialogeManager>();
        _statsManager = GetComponent<StatsManager>();
        _uiManager = GetComponent<UIManager>();
    }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializeGame();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeGame()
    {
        StartNewDialog(0);
        _statsManager.UpdateUI();
    }

    public void StartNewDialog(ChoiceSide choiceType)
    {
        DialogeData nextDialog = _dialogeManager.GetNextDialog(choiceType, _statsManager.CurrentStats);
        if (nextDialog != null)
        {
            _uiManager.ShowDialog(nextDialog);
        }
    }

    private void OnChoiseMade(ChoiceSide choiceType, DialogeChoiceScriptableObject dialogChoiceScriptableObject)
    {
        _statsManager.ApplyStatModifiers(dialogChoiceScriptableObject.StatModifiers);
        StartNewDialog(choiceType);
    }

    private void OnLose(string message)
    {
        _losePanel.gameObject.SetActive(true);
        _losePanel.GetComponentInChildren<TextMeshProUGUI>().text = message;
    }
}