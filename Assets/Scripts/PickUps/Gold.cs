using UnityEngine;

public class Gold : Resource
{
    public override float DropChance => 0.15f;
    private int minCount = 0, maxCount = 4;

    public void RandomizeItemCount(float difficult, int waveCount, float recoverableGold)
    {
        var rndValue = Random.Range(minCount, maxCount);
        _itemCount = (int)((rndValue + waveCount) * difficult * recoverableGold);
        UpdateNotificationText();
    }
}
