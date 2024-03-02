using System.Collections;
using UnityEngine;

public class Gold : Resource
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _spawnAnimSpeed;
    public override float DropChance => 0.15f;
    private int minCount = 0, maxCount = 4;

    public void RandomizeItemCount(float difficult, int waveCount, float recoverableGold)
    {
        var rndValue = Random.Range(minCount, maxCount);
        _itemCount = (int)((rndValue + waveCount) * difficult * recoverableGold);
        UpdateNotificationText();
    }

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
