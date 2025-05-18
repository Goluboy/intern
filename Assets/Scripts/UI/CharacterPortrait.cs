using UnityEngine;

public class CharacterPortrait : MonoBehaviour
{
    public bool IsMouseOver { get; set; } = false;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FadeOut()
    {
        transform.position = Vector2.zero;
        _spriteRenderer.enabled = false;
    }

    public void FadeIn()
    {
        _spriteRenderer.enabled = true;
    }

    public void SetCharacter(CharacterData character)
    {
        _spriteRenderer.sprite = character.defaultPortrait;
    }

    private void OnMouseOver()
    {
        IsMouseOver = true;
    }

    private void OnMouseExit()
    {
        IsMouseOver = false;
    }
}
