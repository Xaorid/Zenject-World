using System.Collections;
using UnityEngine;

public class DynamiteAnimation : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _animSpeed;

    private void Start()
    {
        StartCoroutine(DynamiteAnimRoutine());
    }

    private IEnumerator DynamiteAnimRoutine()
    {
        var index = 0;
        while (true)
        {
            yield return new WaitForSeconds(_animSpeed);
            _spriteRenderer.sprite = _sprites[index];
            index = (index + 1) % _sprites.Length;
        }
    }
}
