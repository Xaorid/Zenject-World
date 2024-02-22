using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public abstract class Bonus<T> : InteractableObject
{
    [SerializeField] protected float _bonusDuration;

    public static UnityEvent<T> OnBonusActivated = new();

    public abstract T GetValue();
    public virtual void PickUpBonus()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Interact();
        }
    }   

    public override void Interact()
    {
        OnBonusActivated.Invoke(GetValue());
    }

    public IEnumerator BonusDurationRoutine()
    {
        yield return new WaitForSeconds(_bonusDuration);
    }
}
