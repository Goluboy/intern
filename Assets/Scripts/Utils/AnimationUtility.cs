using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnimationUtility : MonoBehaviour
{
    [SerializeField] private CharacterPortrait _portrait;
    [SerializeField] private float _movingSpeed;

    [SerializeField] private TextMeshProUGUI _leftText;
    [SerializeField] private TextMeshProUGUI _rightText;

    private DialogeManager _dialogManager;
    private SpriteRenderer _portraitSpriteRenderer;

    private void Awake()
    {
        _dialogManager = GetComponent<DialogeManager>();
        _portraitSpriteRenderer = _portrait.GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Creates a typewriter effect for text display
    /// </summary>
    public IEnumerator TypewriterEffect(TextMeshProUGUI textComponent, string textToType, float typingSpeed = 0.05f)
    {
        textComponent.text = "";
        foreach (char c in textToType)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void Update()
    {
        if (!_portraitSpriteRenderer.enabled)
            return;

        if (Input.GetMouseButton(0) && _portrait.IsMouseOver)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _portrait.transform.position = pos;
        }
        else
        {
            _portrait.transform.position = Vector2.MoveTowards(_portrait.transform.position, Vector2.zero, _movingSpeed * Time.deltaTime);
        }

        if (_portrait.transform.position.x > 2)
        {
            OnSwipe(_rightText);
        }
        else if (_portrait.transform.position.x < -2)
        {
            OnSwipe(_leftText);
        }
        else
        {
            _leftText.gameObject.SetActive(false);
            _rightText.gameObject.SetActive(false);
        }
    }

    private void OnSwipe(TextMeshProUGUI text)
    {
        if (!text.gameObject.activeSelf)
            text.gameObject.SetActive(true);

        if (!Input.GetMouseButton(0) && !_dialogManager.CurrentDialogeData.IsCompleted)
        {
            text.gameObject.SetActive(false);

            if (text.text == _leftText.text && !_dialogManager.CurrentDialogeData.IsCompleted)
                EventSystem.SendChoiceMade(ChoiceSide.Left, _dialogManager.CurrentDialogeData.Choices[0]);
            else
                EventSystem.SendChoiceMade(ChoiceSide.Right, _dialogManager.CurrentDialogeData.Choices[1]);
        }
    }
}
