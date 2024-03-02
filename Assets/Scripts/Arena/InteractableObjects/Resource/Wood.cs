using System.Collections;
using UnityEngine;

public class Wood : Resource
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _spawnAnimSpeed;
    public override float DropChance => 0.05f;

    private IEnumerator SpawnAnim()
    {
        foreach (var sprite in _sprites)
        {
            yield return new WaitForSeconds(_spawnAnimSpeed);
            _spriteRenderer.sprite = sprite;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnAnim());
    }
}
