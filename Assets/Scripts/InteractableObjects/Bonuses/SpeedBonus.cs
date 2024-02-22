using UnityEngine;

public class SpeedBonus : Bonus<float>
{
    [SerializeField] private float _bonusPercentSpeed;

    public override float GetValue()
    {
        return _bonusPercentSpeed;
    }
}
